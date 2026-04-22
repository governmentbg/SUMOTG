IF EXISTS (SELECT 1 FROM sysobjects WHERE name = 'MON_PORYCHKA_UPD' AND type = 'TR')
    DROP TRIGGER MON_PORYCHKA_UPD
GO
  
-- SQL-23499
	--Set the options to support indexed views.
	SET NUMERIC_ROUNDABORT OFF;
	SET ANSI_PADDING, ANSI_WARNINGS, CONCAT_NULL_YIELDS_NULL, ARITHABORT,
	   QUOTED_IDENTIFIER, ANSI_NULLS ON;
	go


create TRIGGER MON_PORYCHKA_UPD
	ON	MON_PORYCHKA
	FOR	UPDATE 
AS
DECLARE
	@vIDPorachkaMian		numeric
	,@vIDLiceDogovor		numeric
	,@vIDUred				numeric
	,@vDataMontazj			datetime
	,@vUser					nvarchar(128)
	,@statusM				numeric
begin

	if update([statusM]) begin
		select						
			LTRIM(RTRIM(d.[StatusM])) as d_status_M,
			LTRIM(RTRIM(i.[StatusM])) as i_status_M,
			i.IdPorachkaMain,i.IdDogovorLice,i.IdUred,i.MonData,i.[user]
		into #_porychka
		from INSERTED i inner join DELETED d
		on i.IDPorachkaBody =d.IDPorachkaBody

		if exists (select 1 from #_porychka where d_status_M <> i_status_M) 
		BEGIN
			SELECT TOP 1
					@vIDPorachkaMian	= IdPorachkaMain
					,@vIDLiceDogovor	= IdDogovorLice
					,@vIDUred			= IdUred
					,@vDataMontazj		= MonData
					,@vUser				= user
					,@statusM			=  i_status_M
				FROM #_porychka

			BEGIN
				DELETE FROM mon_profilaktika
					WHERE IdPorachkaMain = @vIDPorachkaMian	
						AND IdDogovorLice = @vIDLiceDogovor
						AND IdUred = @vIDUred			

				IF @statusM = 1 BEGIN
					 EXEC genProfilaktikaDati 
							@vIDPorachkaMian
							,@vIDLiceDogovor
							,@vIDUred	
							,@vDataMontazj	
							,@vUser
				END
			END
		END
		drop table #_porychka
	end

end
go