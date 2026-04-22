if exists (select * from sysobjects where id = object_id(N'prekodiraneRadiatori') and OBJECTPROPERTY(id, N'IsProcedure') = 1)
drop procedure prekodiraneRadiatori
GO

CREATE PROCEDURE prekodiraneRadiatori 
	@@pIDDOGLICE	NUMERIC
	,@@pUSER		varchar(128)	
as
DECLARE
	@v_Error				int
BEGIN
	SET NOCOUNT ON

	IF OBJECT_ID('tempdb..#TMP_lica_dogovor_uredi') IS NOT NULL 
		DROP TABLE #TMP_lica_dogovor_uredi;

	IF OBJECT_ID('tempdb..#TMP_xxx') IS NOT NULL 
		DROP TABLE IF EXISTS #TMP_xxx;

	SELECT du.Id_L,u.Id,u.Id2,u.Nime2
		,du.Status, du.Status_U, du.Porychani     
		,du.Broi,du.ID_DOG_L,du.[user],GETDATE() koga
	INTO #TMP_lica_dogovor_uredi
	FROM lica_dogovor_uredi du  
		INNER JOIN n_uredi u ON u.Id = du.Id_KT 
	WHERE du.ID_DOG_L = @@pIDDOGLICE

	SELECT DISTINCT ldu.ID_DOG_L,x.Id_L, x.ID2 Id_KT, x.Br Broi,
			ldu.Status_U, ldu.Status, ldu.[user], x.Koga, x.Porychani 
	INTO #TMP_xxx 
	FROM #TMP_lica_dogovor_uredi ldu
		INNER JOIN (SELECT Id_L, id2, SUM(Broi) Br, MIN(Koga) Koga, SUM(Porychani) Porychani  
						FROM #TMP_lica_dogovor_uredi 
						GROUP BY Id_L, id2) x
		ON x.Id_L=ldu.Id_L AND x.id2=ldu.Id2;

	BEGIN TRY
		BEGIN TRANSACTION
			UPDATE ld
				SET ld.Comentar= COALESCE(ld.Comentar, ' ') + 
								' Прекодирани радиатори.' + 
								' Заявени: '+ v.Rad    
				FROM lica_dogovor ld 
						INNER JOIN vwOPOS v ON v.ID_L=ld.Id_L
				WHERE ld.ID_DOG_L = @@pIDDOGLICE

			INSERT INTO lica_dogovor_uredi_arhiv
					(ID_DOG_L,Id_L,Id_KT,Broi,Status_U,Status,[user],Koga,Porychani)
				SELECT ID_DOG_L,Id_L,Id_KT,Broi,8 Status_U,Status,[user],Koga,Porychani
					FROM lica_dogovor_uredi
					WHERE ID_DOG_L = @@pIDDOGLICE
					  AND Id_KT between 32 and 49

			DELETE FROM lica_dogovor_uredi
				WHERE ID_DOG_L = @@pIDDOGLICE

			INSERT INTO lica_dogovor_uredi (ID_DOG_L,Id_L,Id_KT,Broi,Status_U,Status,[user],Koga,Porychani)
				SELECT ID_DOG_L,Id_L, Id_KT, Broi,Status_U, Status, @@pUSER, GETDATE(), Porychani
					FROM #TMP_xxx
		COMMIT

		SELECT 0 result
	END TRY
	BEGIN CATCH
		ROLLBACK
		PRINT ERROR_MESSAGE()

		SELECT -1 result
	END CATCH;	
END
GO

SET QUOTED_IDENTIFIER OFF 
GO
SET ANSI_NULLS ON 
GO
