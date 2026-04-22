if exists (select * from sysobjects where id = object_id(N'spravka54') and OBJECTPROPERTY(id, N'IsProcedure') = 1)
drop procedure spravka54
GO

CREATE PROCEDURE spravka54
as
DECLARE
	@v_broi			int
	,@v_curdate		datetime

BEGIN
	SET NOCOUNT ON

	CREATE TABLE #TMP_spravka54 (
		vid		varchar(4)
		,col2	int
		,col3	int
		,col4	int
		,col5	int
		,col6	int
		,col7	int
		,col8	int
		,col9	int
		,col10	int
		,col11	int
		,col12	int		
	)

	INSERT INTO #TMP_spravka54 (vid) VALUES ('PEL')
	INSERT INTO #TMP_spravka54 (vid) VALUES ('GAZ')
	INSERT INTO #TMP_spravka54 (vid) VALUES ('KLM')

	SELECT distinct t.vid, l.Id_L
		into #tmp_spravka54a
		from lica_dogovor_uredi l
			inner join lica_dogovor ld
				on l.ID_DOG_L = ld.Id_dog_L and ld.Status_DL < 6
			inner join n_uredi u
				on l.Id_KT = u.Id
			inner join #TMP_spravka54 t
				on u.Vid = t.vid
	
/*
	INSERT INTO #tmp_spravka54a
		select distinct vid, l.Id_L
		  from lica_formuliar_uredi l
					inner join lica_formuliar f
						on l.Id_L = f.Id_L
					inner join n_uredi u
						on l.Id_KT = u.Id
		  where f.Status_F <= 1
		    and l.Id_L not in (select id_l from #tmp_spravka54a)
*/

	UPDATE t
		SET col2 = x.zaqvili
		FROM #TMP_spravka54 t
				inner join 
					(SELECT vid, count(distinct Id_L) zaqvili
						from #tmp_spravka54a
						GROUP BY vid) x
				ON t.vid = x.Vid
	
	SELECT l.Id_L
		, vid
		,CASE WHEN ISNULL(V401,0) = 0 AND  ISNULL(V402,0) > 0 THEN  1 
				WHEN ISNULL(V402,0) > 0 AND  ISNULL(V401,0) > 0 THEN
				CASE WHEN ISNULL(V402,0) >= (600*ISNULL(V401,0))/2 
					THEN 1
					ELSE 0 
				END	
				ELSE 0 
			END col3
		,CASE WHEN ISNULL(V402,0) = 0 AND  ISNULL(V401,0) > 0 THEN 1 
				WHEN ISNULL(V402,0) > 0 AND  ISNULL(V401,0) > 0 THEN
				CASE WHEN ISNULL(V402,0) < (600*ISNULL(V401,0))/2 
					THEN 1
					ELSE 0 
				END	
			ELSE 0 
		END col6
		,CASE WHEN ISNULL(V401,0) = 0 AND  ISNULL(V402,0) > 0 THEN  BROI 
				WHEN ISNULL(V402,0) > 0 AND  ISNULL(V401,0) > 0 THEN
				CASE WHEN ISNULL(V402,0) >= (600*ISNULL(V401,0))/2 
					THEN BROI
					ELSE 0 
				END	
				ELSE 0 
		END col4
		,CASE WHEN ISNULL(V402,0) = 0 AND  ISNULL(V401,0) > 0 THEN BROI 
				WHEN ISNULL(V402,0) > 0 AND  ISNULL(V401,0) > 0 THEN
				CASE WHEN ISNULL(V402,0) < (600*ISNULL(V401,0))/2 
					THEN BROI
					ELSE 0 
				END	
			ELSE 0 
		END col7
		,CASE WHEN ISNULL(V401,0) = 0 AND  ISNULL(V402,0) > 0 THEN  V402 
			  WHEN ISNULL(V402,0) > 0 AND  ISNULL(V401,0) > 0 THEN
					CASE WHEN ISNULL(V402,0) >= (600*ISNULL(V401,0))/2 
						 THEN ISNULL(V402,0) + (600*ISNULL(V401,0))/2
						 ELSE 0 
					END	
			   ELSE 0 
		END col5
		,CASE WHEN ISNULL(V402,0) = 0 AND  ISNULL(V401,0) > 0 THEN V401 
			  WHEN ISNULL(V402,0) > 0 AND  ISNULL(V401,0) > 0 THEN
					CASE WHEN ISNULL(V402,0) < (600*ISNULL(V401,0))/2 
						 THEN ISNULL(V401,0) + (2*ISNULL(V402,0))/600 
						 ELSE 0 
					END	
			  ELSE 0 
		END col8
		,CASE WHEN ISNULL(V402,0) > 0 AND  ISNULL(V401,0) > 0
			THEN 1
			ELSE 0 
		END col9
		,CASE WHEN ISNULL(V402,0) > 0 AND  ISNULL(V401,0) > 0
			THEN BROI
			ELSE 0 
		END col10
		,CASE WHEN ISNULL(V401,0) = 0 AND  ISNULL(V402,0) = 0 THEN 1
				ELSE 0 
			END col11
		,CASE WHEN ISNULL(V401,0) > 100000 OR ISNULL(V402,0) > 100000 THEN 1
				ELSE 0 
			END col12
		, 1 cnt
		, Broi
	into #tmp_spravka54b
	from #tmp_spravka54a l
		inner join lica_formuliar k
			on l.Id_L = k.Id_L
		left join (SELECT Id_L, SUM(BROI) broi 
						FROM lica_formuliar_olduredi l
						GROUP BY Id_L) o
			on k.Id_L = o.Id_L

	UPDATE t
		SET t.col3 = y.col3
			,t.col4 = y.col4
			,t.col5 = y.col5
			,t.col6 = y.col6
			,t.col7 = y.col7
			,t.col8 = y.col8
			,t.col9 = y.col9
			,t.col10 = y.col10
			,t.col11 = y.col11
			,t.col12 = y.col12
		FROM #TMP_spravka54 t
				inner join 
					(SELECT vid
						, sum(col3) col3
						, sum(col4) col4
						, sum(col5) col5
						, sum(col6) col6
						, sum(col7) col7
						, sum(col8) col8
						, sum(col9) col9
						, sum(col10) col10
						, sum(col11) col11
						, sum(col12) col12
					FROM #tmp_spravka54b 
				    GROUP BY vid) y
		on t.vid = y.vid

	select CASE WHEN vid ='PEL' THEN 'Уреди на пелети'
				WHEN vid ='GAZ' THEN 'Уреди на природен газ'
				WHEN vid ='KLM' THEN 'Климатици'
			END vid
			,col2,col3,col4,col5,col6,col7,col8,col9,col10,col11,isnull(col12,0) col12, col3+col6+col11 sumcol
	  from #TMP_spravka54

END
GO

SET QUOTED_IDENTIFIER OFF 
GO
SET ANSI_NULLS ON 
GO
