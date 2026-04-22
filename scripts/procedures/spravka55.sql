if exists (select * from sysobjects where id = object_id(N'spravka55') and OBJECTPROPERTY(id, N'IsProcedure') = 1)
drop procedure spravka55
GO

CREATE PROCEDURE spravka55
	@@pTIP	int
as
DECLARE
	@v_broi			int
	,@v_curdate		datetime
	,@v_coef		numeric(21,6)

BEGIN
	SET NOCOUNT ON

	CREATE TABLE #TMP_spravka55 (
		id			int
		,nime		varchar(100)
		,broi		int
		,koef		numeric(10,2)
		,broiuredi	int
	)

	CREATE TABLE #TMP_spravka55a (
		id_l	int
		,v18	int
		,v401	numeric(10,2)
		,v402	numeric(10,2)
	)
	INSERT INTO #TMP_spravka55  
		SELECT ID, nime, 0, Koeficient,0 
			FROM n_fp4_tablica3
			WHERE ID in (1,2,3,4,5,6)

	IF @@pTIP = 1
		INSERT INTO #TMP_spravka55a  
			SELECT distinct ld.Id_L, 0, 0, 0
				from lica_dogovor ld
						inner join lica_dogovor_uredi lu
						on ld.Id_dog_L = lu.ID_DOG_L
				where lu.Status_U in (5)
	ELSE
		INSERT INTO #TMP_spravka55a  
			SELECT distinct ld.Id_L, 0, 0, 0
				from lica_dogovor ld
				where ld.Status_DL < 6

	UPDATE t
		SET v18 = l.Id_KT 
		FROM #tmp_spravka55a t
				inner join lica_dogovor_olduredi l
				on t.Id_L = l.Id_L

	UPDATE t
		SET t.v401 = CASE WHEN ISNULL(f.V401,0) = 0 AND  ISNULL(f.V402,0) = 0 THEN 1 
						  WHEN ISNULL(f.V402,0) = 0 AND  ISNULL(f.V401,0) > 0 THEN 1 
						  WHEN ISNULL(f.V402,0) > 0 AND  ISNULL(f.V401,0) > 0 THEN
								CASE WHEN ISNULL(f.V402,0) < (600*ISNULL(f.V401,0))/2 
									THEN 1
									ELSE 0 
								END	
						  ELSE 0 
					 END
			,t.v402 = CASE WHEN ISNULL(f.V401,0) = 0 AND  ISNULL(f.V402,0) > 0 THEN  1 
						   WHEN ISNULL(f.V402,0) > 0 AND  ISNULL(f.V401,0) > 0 THEN
								CASE WHEN ISNULL(f.V402,0) >= (600*ISNULL(f.V401,0))/2 
										THEN 1
										ELSE 0 
								END	
							ELSE 0 
						END
		FROM #tmp_spravka55a t
				inner join lica_formuliar f
				on t.Id_L = f.Id_L

	UPDATE t
		SET broi = x.broi
		FROM #TMP_spravka55 t
				inner join (SELECT 1 id, count(distinct t.id_l) broi
								from #tmp_spravka55a t
										inner join lica_dogovor_uredi lu
											on t.id_l = lu.Id_L
										inner join n_uredi u
											on lu.Id_KT = u.Id and u.Vid = 'PEL'
								where V402 > 0
							) x
				on t.id = x.id

	UPDATE t
		SET broi = x.broi
		FROM #TMP_spravka55 t
				inner join (SELECT 2 id, count(distinct t.id_l) broi
								from #tmp_spravka55a t
										inner join lica_dogovor_uredi lu
											on t.id_l = lu.Id_L
										inner join n_uredi u
											on lu.Id_KT = u.Id and u.Vid = 'PEL'
								where V401 > 0
							) x
				on t.id = x.id



	UPDATE t
		SET broi = x.broi
		FROM #TMP_spravka55 t
				inner join (SELECT 3 id, count(distinct t.id_l) broi
								from #tmp_spravka55a t
										inner join lica_dogovor_uredi lu
											on t.id_l = lu.Id_L
										inner join n_uredi u
											on lu.Id_KT = u.Id and u.Vid = 'GAZ'
								where V402 > 0
							) x
				on t.id = x.id

	UPDATE t
		SET broi = x.broi
		FROM #TMP_spravka55 t
				inner join (SELECT 4 id, count(distinct t.id_l) broi
								from #tmp_spravka55a t
										inner join lica_dogovor_uredi lu
											on t.id_l = lu.Id_L
										inner join n_uredi u
											on lu.Id_KT = u.Id and u.Vid = 'GAZ'
								where V401 > 0
							) x
				on t.id = x.id

	UPDATE t
		SET broi = x.broi
		FROM #TMP_spravka55 t
				inner join (SELECT 5 id, count(distinct t.id_l) broi
								from #tmp_spravka55a t
										inner join lica_dogovor_uredi lu
											on t.id_l = lu.Id_L
										inner join n_uredi u
											on lu.Id_KT = u.Id and u.Vid = 'KLM'
								where V402 > 0
							) x
				on t.id = x.id

	UPDATE t
		SET broi = x.broi
		FROM #TMP_spravka55 t
				inner join (SELECT 6 id, count(distinct t.id_l) broi
								from #tmp_spravka55a t
										inner join lica_dogovor_uredi lu
											on t.id_l = lu.Id_L
										inner join n_uredi u
											on lu.Id_KT = u.Id and u.Vid = 'KLM'
								  and V401 > 0
							) x
				on t.id = x.id

	--uredi
	UPDATE t
		SET broiuredi = x.broi
		FROM #TMP_spravka55 t
				inner join (SELECT 1 id, sum(lo.Broi) broi
								from (select distinct lu.ID_DOG_L
										from #tmp_spravka55a t
												inner join lica_dogovor_uredi lu
													on t.id_l = lu.Id_L
												inner join n_uredi u
													on lu.Id_KT = u.Id and u.Vid = 'PEL'
										where V402 > 0) t1
									inner join lica_dogovor_olduredi lo on t1.ID_DOG_L = lo.ID_DOG_L
							) x
				on t.id = x.id

	UPDATE t
		SET broiuredi = x.broi
		FROM #TMP_spravka55 t
				inner join (SELECT 2 id, sum(lo.Broi) broi
								from (select distinct lu.ID_DOG_L
										from #tmp_spravka55a t
												inner join lica_dogovor_uredi lu
													on t.id_l = lu.Id_L
												inner join n_uredi u
													on lu.Id_KT = u.Id and u.Vid = 'PEL'
										where V401 > 0) t1
									inner join lica_dogovor_olduredi lo on t1.ID_DOG_L = lo.ID_DOG_L
							) x
				on t.id = x.id


	UPDATE t
		SET broiuredi = x.broi
		FROM #TMP_spravka55 t
				inner join (SELECT 3 id, sum(lo.Broi) broi
								from (select distinct lu.ID_DOG_L
										from #tmp_spravka55a t
												inner join lica_dogovor_uredi lu
													on t.id_l = lu.Id_L
												inner join n_uredi u
													on lu.Id_KT = u.Id and u.Vid = 'GAZ'
										where V402 > 0) t1
									inner join lica_dogovor_olduredi lo on t1.ID_DOG_L = lo.ID_DOG_L
							) x
				on t.id = x.id

	UPDATE t
		SET broiuredi = x.broi
		FROM #TMP_spravka55 t
				inner join (SELECT 4 id, sum(lo.Broi) broi
								from (select distinct lu.ID_DOG_L
										from #tmp_spravka55a t
												inner join lica_dogovor_uredi lu
													on t.id_l = lu.Id_L
												inner join n_uredi u
													on lu.Id_KT = u.Id and u.Vid = 'GAZ'
										where V401 > 0) t1
									inner join lica_dogovor_olduredi lo on t1.ID_DOG_L = lo.ID_DOG_L
							) x
				on t.id = x.id

	UPDATE t
		SET broiuredi = x.broi
		FROM #TMP_spravka55 t
				inner join (SELECT 5 id, sum(lo.Broi) broi
								from (select distinct lu.ID_DOG_L
										from #tmp_spravka55a t
												inner join lica_dogovor_uredi lu
													on t.id_l = lu.Id_L
												inner join n_uredi u
													on lu.Id_KT = u.Id and u.Vid = 'KLM'
										where V402 > 0) t1
									inner join lica_dogovor_olduredi lo on t1.ID_DOG_L = lo.ID_DOG_L
							) x
				on t.id = x.id

	UPDATE t
		SET broiuredi = x.broi
		FROM #TMP_spravka55 t
				inner join (SELECT 6 id, sum(lo.Broi) broi
								from (select distinct lu.ID_DOG_L
										from #tmp_spravka55a t
												inner join lica_dogovor_uredi lu
													on t.id_l = lu.Id_L
												inner join n_uredi u
													on lu.Id_KT = u.Id and u.Vid = 'KLM'
										where V401 > 0) t1
									inner join lica_dogovor_olduredi lo on t1.ID_DOG_L = lo.ID_DOG_L
							) x
				on t.id = x.id

	select id,nime,broi,broi*koef calc, broiuredi, broiuredi*koef calcuredi
		from #TMP_spravka55

END
GO

SET QUOTED_IDENTIFIER OFF 
GO
SET ANSI_NULLS ON 
GO
