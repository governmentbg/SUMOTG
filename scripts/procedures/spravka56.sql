if exists (select * from sysobjects where id = object_id(N'spravka56') and OBJECTPROPERTY(id, N'IsProcedure') = 1)
drop procedure spravka56
GO

CREATE PROCEDURE spravka56
as
DECLARE
	@v_broi			int
	,@v_curdate		datetime
	,@v_coef		numeric(21,6)

BEGIN
	SET NOCOUNT ON

	CREATE TABLE #TMP_spravka56_1 (
		id			int
		,nime		varchar(100)
		,broi		int
		,calc		numeric(10,2)
		,broiuredi	int
		,calcuredi	numeric(10,2)
	)

	INSERT INTO #TMP_spravka56_1
		EXEC spravka55 0

	CREATE TABLE #TMP_spravka56_2 (
		id			int
		,nime		varchar(100)
		,broi		int
		,calc		numeric(10,2)
		,broiuredi	int
		,calcuredi	numeric(10,2)
	)

	INSERT INTO #TMP_spravka56_2
		EXEC spravka55 1


	SELECT @v_coef= Koeficient
		FROM n_fp4_tablica3
		WHERE ID = 99

	SELECT 1 id
			, Nime+'*' Nime
			, 0 broi
			, Koeficient calc
			, 0 broiuredi
			, 0.0 calcuredi
		FROM n_fp4_tablica3
		WHERE ID = 99
	UNION
		select 2 id
			,'Актуализирана целева стойност на инд.ФПЧ10' nime
			,SUM(broi) broi
			,@v_coef-SUM(calc)/1000 calc
			,0 broiuredi
			,0.0 calcuredi
			from #TMP_spravka56_1
	UNION
		select 3 id
			,'Актуализирана целева стойност на инд.ФПЧ10 (домакинства)' nime
			,SUM(broi) broi
			,@v_coef-SUM(calc)/1000 calc
			,0 broiuredi
			,0.0 calcuredi
			from #TMP_spravka56_2
	UNION
		select 4 id
			,'Актуализирана целева стойност на инд.ФПЧ10 (уреди)' nime
			,SUM(broiuredi) broi
			,@v_coef-SUM(calcuredi)/1000 calc
			,0 broiuredi
			,0.0 calcuredi
			from #TMP_spravka56_2

END
GO

SET QUOTED_IDENTIFIER OFF 
GO
SET ANSI_NULLS ON 
GO
