if exists (select * from sysobjects where id = object_id(N'genProfilaktikaDati') and OBJECTPROPERTY(id, N'IsProcedure') = 1)
drop procedure genProfilaktikaDati
GO


CREATE PROCEDURE genProfilaktikaDati (
	@@pIDPorachkaMian		numeric
	,@@pIDLiceDogovor		numeric
	,@@pIDUred				numeric
	,@@pDataMontazj			datetime
	,@@pUser				nvarchar(128)
)
AS
DECLARE
	@ret	          	int,
	@vmonth         	int,
	@firstDate          datetime,
	@vExist				int,	
	@vBroi				int,
	@vModel				varchar(max),
	@vPeriod			numeric,
	@vIDL				numeric
BEGIN

	--bez radiatori
	IF @@pIDUred > 29 
		RETURN

	SELECT @vExist = 1
		  ,@vBroi = p.Broi
		  ,@vModel = p.Model
		  ,@vPeriod = du.Profilaktika
		  ,@vIDL	= l.Id_L
		FROM mon_porychka p
				inner join lica_dogovor l
					on p.IdDogovorLice = l.Id_dog_L
				inner join mon_porychkamain m
					on p.IdPorachkaMain = m.IDPorachkamain
				inner join mon_dogovor d
					on m.IdDogovorFirma = d.IdFirmaMn
				inner join mon_dgv_uredi du
					on d.IdFirmaMn = du.IdFirmaMn And du.ID_kn = p.IdUred
		WHERE p.IdPorachkaMain = @@pIDPorachkaMian
			AND p.IdDogovorLice  = @@pIDLiceDogovor
			AND p.IdUred		 = @@pIDUred
			AND p.StatusM		 = 1
	
	IF ISNULL(@vExist,0) = 1 BEGIN
		SET @ret = null
		SET @vmonth = MONTH(@@pDataMontazj)
		SET @firstDate = DATEADD(day,365,@@pDataMontazj)
	
		-- ne e klimatik
		IF NOT EXISTS ( SELECT 1 
						FROM n_uredi 
						WHERE ID =@@pIDUred AND VID = 'KLM')
		BEGIN
			IF @vmonth BETWEEN 1 AND 3
				SET @firstDate = DATEADD(day,90,@firstDate)
			ELSE
			IF @vmonth BETWEEN 10 AND 12
				SET @firstDate = DATEADD(day,-90,@firstDate)
		END

		INSERT INTO mon_profilaktika (
				IdPorachkaMain
				,IdDogovorLice
				,IdUred
				,Data
				,Note
				,Status_PF
				,[User]
				,Koga
				,PNomer
				,Broi
				,Model
				,[Period]
				,IDL)
			VALUES(@@pIDPorachkaMian
					,@@pIDLiceDogovor
					,@@pIDUred
					,@firstDate
					,''
					,0
					,@@pUser
					,GETDATE()
					,1
					,@vBroi
					,@vModel
					,@vPeriod
					,@vIDL
			)
	END
END
GO
