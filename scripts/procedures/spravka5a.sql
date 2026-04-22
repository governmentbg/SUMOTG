if exists (select * from sysobjects where id = object_id(N'spravka5a') and OBJECTPROPERTY(id, N'IsProcedure') = 1)
drop procedure spravka5a
GO


CREATE PROCEDURE spravka5a 
	@@pTIP			NUMERIC
	,@@pFAZA		NUMERIC
	,@@pRAION		varchar(2)
	,@@pTIPURED		varchar(3)
	,@@pURED		varchar(5)
	,@@pSTATUSDL	numeric
	,@@pSTATUSU		numeric
	,@@pUNOMER		numeric
as
DECLARE
	@v_Error				int
BEGIN
	SET NOCOUNT ON

	select f.ID_Formuliar,f.Id_L,f.Faza,l.A_Raion,l.Ime,u.Status_U
		   ,f.U_nom,u.idured,u.Broi,u.Nkod,u.Vid,f.UNomer - (f.Faza * 100000) UNomer 
		   ,u.IdDogL,u.Nime ured,d.Status_Dl,d.Reg_N ,u.TipUrIme,l.Id
	into #tmp_doguredi
	from lica_formuliar f
			inner join [dbo].[lica_formuliar_kolektiv] l
				on f.Id_L = l.IdL and l.IsTitulqr = 1 and l.Status = 1
			inner join [dbo].[lica_dogovor] d
				on f.Id_L = d.Id_L
			inner join [dbo].[vwLicaDogovorUredi] u
				on u.IdDogL = d.Id_dog_L

	if (@@pUNOMER > 0) 
		DELETE FROM #tmp_doguredi WHERE UNomer <> @@pUNOMER
	ELSE BEGIN
		if (@@pFAZA > 0)
			DELETE FROM #tmp_doguredi WHERE Faza <> @@pFAZA

		if (LEN(ISNULL(@@pRAION,'')) > 0)
			DELETE FROM #tmp_doguredi WHERE A_Raion <> @@pRAION

		if (LEN(ISNULL(@@pTIPURED,'')) > 0 AND  @@pTIPURED <> 'ALL' )
			DELETE FROM #tmp_doguredi WHERE Vid <> @@pTIPURED

		if (LEN(ISNULL(@@pURED,'')) > 0)
			DELETE FROM #tmp_doguredi WHERE Nkod <> @@pURED

		if (@@pSTATUSDL > -1) 
			DELETE FROM #tmp_doguredi WHERE Status_Dl <> @@pSTATUSDL

		if (@@pSTATUSU > 0) 
			DELETE FROM #tmp_doguredi WHERE Status_U <> @@pSTATUSU
	END
		
	CREATE TABLE #tmp_porychki (
		IdDogovorLice	int
		,IDPorachkaBody	int
		,IdPorachkaMain	int
		,idured			int
		,statusG		int
		,statusM		int
	)

	IF @@pTIP = 1
		WITH cte AS (
			SELECT
				IdDogovorLice,IDPorachkaBody, IdPorachkaMain, idured,statusG, statusM,
				ROW_NUMBER() OVER(PARTITION BY IdDogovorLice, idured ORDER BY statusG, statusM DESC) AS row_number
			FROM mon_porychka
		)
		INSERT INTO #tmp_porychki
			SELECT IdDogovorLice,IDPorachkaBody, IdPorachkaMain,idured,statusG, statusM 
			  FROM cte 
			  WHERE row_number = 1
				and IdDogovorLice in (SELECT IdDogL from #tmp_doguredi)
	ELSE
	INSERT INTO #tmp_porychki
		SELECT IdDogovorLice,IDPorachkaBody, IdPorachkaMain,idured,statusG, statusM 
		  FROM mon_porychka
		  WHERE IdDogovorLice in (SELECT IdDogL from #tmp_doguredi);


	SELECT l.Id idl
		,f.ID_Formuliar idformulqr
		,f.U_nom unom		
		,r.Nime raion		
		,l.ime		
		,a.adres		
		,u.nkod		
		,u.nime ured		
		,s2.Text statusU	
		,f.unomer		
		,u.broi		
		,ISNULL(p.IdPorachkaMain,0) idporychka
		,d.Reg_N regdog		
		,s1.Text statusDL	
		,u.TipUrIme tipuredime	
		,'' statdog
	  FROM (SELECT DISTINCT Id_L 
				FROM #tmp_doguredi) t
			inner join lica_formuliar f
				on t.Id_l = f.Id_l
			inner join [dbo].[lica_formuliar_kolektiv] l
				on f.Id_L = l.IdL and l.IsTitulqr = 1 and l.Status = 1
			inner join [dbo].[lica_dogovor] d
				on f.Id_L = d.Id_L
			inner join [dbo].[vwLicaDogovorUredi] u
				on u.IdDogL = d.Id_dog_L
			inner join vwAdres a
				on a.ID_L = t.Id_L
			inner join [dbo].[n_statusi] s1
				on d.Status_DL = s1.[Status_Code] and s1.[Status_name] = 'Status_DL'
			inner join [dbo].[n_statusi] s2
				on u.Status_U = s2.[Status_Code] and s2.[Status_name] = 'Status_U'
			inner join [dbo].[n_raioni] r
				on  r.NKOD = l.A_Raion
			left join #tmp_porychki p
				on u.IdDogL = p.IdDogovorLice AND  p.idured = u.idured
	 ORDER BY f.unomer, u.idured		

END
GO

SET QUOTED_IDENTIFIER OFF 
GO
SET ANSI_NULLS ON 
GO
