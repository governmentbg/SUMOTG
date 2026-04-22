if exists (select * from sysobjects where id = object_id(N'spravka25') and OBJECTPROPERTY(id, N'IsProcedure') = 1)
drop procedure spravka25
GO


CREATE PROCEDURE spravka25
	@@pRAIONID	varchar(5)
	,@@pADRES	varchar(200)
as
BEGIN
	SET NOCOUNT ON

	CREATE TABLE #TMP_dublirani_adresi (
		id				numeric(10)
		,raion			varchar(max)
		,adres			varchar(max)
	)

	insert into #TMP_dublirani_adresi
		SELECT  f.id
				,r.NIME raion
				, dbo.genFullAddress (A_Raion, nm, jk, ul, nomer, blok, vh, etaj, ap) adres
		FROM form_collecting_info f
				inner join n_raioni r
					ON f.A_Raion = r.NKOD AND r.[Status] = 1
		WHERE f.A_Raion = CASE WHEN LEN(ISNULL(@@pRAIONID,'')) > 0 THEN @@pRAIONID ELSE f.A_Raion END

	IF  LEN(ISNULL(@@pADRES,'')) > 0 BEGIN
		DELETE FROM #TMP_dublirani_adresi
			WHERE CHARINDEX(@@pADRES,adres)= 0
	END

	SELECT  t.raion
			,ime+' '+ISNULL(prezime+' ','')+familiq ime
			,CASE WHEN n1.Kod_pozicia = 1 THEN f.v101 ELSE 0 END dbroi
			,CASE WHEN n1.Kod_pozicia = 2 THEN f.v101 ELSE 0 END vbroi
			,CASE WHEN n1.Kod_pozicia = 3 THEN f.v101 ELSE 0 END sbroi
			,n2.Text montazj
			,cast(f.v201 as integer) mbroi
			,t.adres
			,f.tel
			,f.e_mail email
			,f.descript
	FROM #TMP_dublirani_adresi t
			inner join form_collecting_info f
				ON t.id = f.id
			inner join [n_nmn_obshti] n1
				ON n1.id_kn = f.v1 AND n1.kod_nmn = '15' AND n1.[status] = 1
			inner join [n_nmn_obshti] n2
				ON n2.id_kn = f.v2 AND n2.kod_nmn = '16' AND n2.[status] = 1

END
GO

SET QUOTED_IDENTIFIER OFF 
GO
SET ANSI_NULLS ON 
GO
