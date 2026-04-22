if exists (select * from sysobjects where id = object_id(N'spravka52') and OBJECTPROPERTY(id, N'IsProcedure') = 1)
drop procedure spravka52
GO

CREATE PROCEDURE spravka52
as
DECLARE
	@v_broi				int
	,@v_broi3			int
	,@v_broi6			int
	,@v_broi7			int
	,@v_broi8			int
	,@v_curdate			datetime
BEGIN
	SET NOCOUNT ON

	CREATE TABLE #TMP_spravka52 (
		id			numeric(5,1)
		,text		varchar(max)
		,broi		int
	)

	SELECT @v_broi6 = COUNT(*)
		FROM lica_dogovor  l
		WHERE l.Status = 1
		and l.Status_DL in (0,1)
/*
	SELECT @v_broi6 = @v_broi6+COUNT(*)
		FROM lica_formuliar l
		WHERE l.Status=1
		and l.Status_F in (0,1)
		and l.Id_L not in (	SELECT id_L
								FROM lica_dogovor  l
								WHERE l.Status = 1
								and l.Status_DL in (0,1))
*/

	SELECT @v_broi3 = COUNT(*)
		FROM lica_dogovor l
		WHERE l.Status_DL < 6

	SELECT @v_broi7 = COUNT(*)
		FROM lica_dogovor  l
		WHERE l.Status_DL = 6

	SELECT @v_broi8 = COUNT(*)
		FROM lica_formuliar l
		WHERE l.Status_F in (7,8)

	INSERT INTO #TMP_spravka52 
		VALUES (1
				,'Общ брой на домакинствата/крайни получатели, заявили интерес за участие по проекта (т.1+т.2+т.3+т.4)'
				,@v_broi3+@v_broi7+@v_broi8)


	INSERT INTO #TMP_spravka52 
		VALUES (3
				,'Бр. домакинства, заявили алтернативно отопление, без отказани (т.1+т.2)'
				,@v_broi3)

	SELECT @v_broi = COUNT(*)
		FROM lica_dogovor  l
		WHERE l.Status = 1
		and l.Status_DL in (2,3,4,5)

	INSERT INTO #TMP_spravka52 
		VALUES (5
				,'1. Брой домакинства/крайни получатели, със сключени договори'
				,@v_broi)

	INSERT INTO #TMP_spravka52 
		VALUES (6
				,'2. Брой домакинства/крайни получатели, с които предстои да се сключат договори'
				,@v_broi6)

	INSERT INTO #TMP_spravka52 
		VALUES (7
				,'3. Брой домакинства/крайни получатели, които са се отказали  от договор'
				,@v_broi7)

	INSERT INTO #TMP_spravka52 
	SELECT 7+(ROW_NUMBER() OVER(ORDER BY u.vid ASC))/10.0
			,CASE WHEN vid ='GAZ' THEN '3.1 За Уреди на природен газ'
				  WHEN vid ='KLM' THEN '3.2 За Климатици'
				  WHEN vid ='PEL' THEN '3.3 За Уреди на пелети'
--				  WHEN vid ='RAD' THEN 'Радиатори'
			 END vid
			, COUNT(distinct l.Id_dog_L)
		FROM lica_dogovor  l
				inner join lica_dogovor_uredi du 
					on l.Id_dog_L = du.ID_DOG_L
				inner join n_uredi u
					on du.Id_KT = u.Id
		WHERE l.Status_DL = 6
		  AND vid <> 'RAD' 
        GROUP BY u.Vid


	INSERT INTO #TMP_spravka52 
		VALUES (8
				,'4. Общ брой на домакинствата/крайни получатели, с неодобрени формуляри за кандидатстване'
				,@v_broi8)

	SELECT id, text nime, broi
	  FROM #TMP_spravka52
	  ORDER BY id
END
GO

SET QUOTED_IDENTIFIER OFF 
GO
SET ANSI_NULLS ON 
GO
