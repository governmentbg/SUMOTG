if exists (select * from sysobjects where id = object_id(N'spravka24') and OBJECTPROPERTY(id, N'IsProcedure') = 1)
drop procedure spravka24
GO


CREATE PROCEDURE spravka24
as
BEGIN
	SET NOCOUNT ON

	CREATE TABLE #TMP_dublirani_adresi (
		ID_L			numeric(10)
		,adres			varchar(max)
	)

	insert into #TMP_dublirani_adresi
		SELECT vw.ID_L, vw.Adres
		FROM vwAdres vw
				right JOIN (SELECT vw.Adres, COUNT(vw.Adres) cnt 
								FROM vwAdres vw 
								GROUP BY vw.Adres
								HAVING COUNT(vw.Adres)>1) x 
				ON x.Adres=vw.Adres
		ORDER BY x.Adres


	SELECT l.Id idl
		  ,f1.ID_Formuliar idformulqr
		  ,f1.U_nom opos
		  ,l.IME ime
		  ,a.Adres adres
		  ,ISNULL(x.text,'') status_dl
		FROM #TMP_dublirani_adresi t
				inner join lica_formuliar_kolektiv l
					ON 	t.ID_L = l.IdL AND l.IsTitulqr=1 and l.Status=1
				inner join vwAdres a
					ON 	t.ID_L = a.ID_L
				inner join lica_formuliar f1
					ON 	t.ID_L = f1.Id_L
				left join (SELECT Id_L, s1.Text, ld1.status_dl
							 from lica_dogovor ld1
								inner join n_statusi s1
									ON ld1.Status_DL = s1.Status_Code and s1.Status_name = 'Status_DL'
							) x					
					ON t.ID_L = x.Id_L
		WHERE  isnull(x.Status_DL,0) < 7
		ORDER BY a.Adres
END
GO

SET QUOTED_IDENTIFIER OFF 
GO
SET ANSI_NULLS ON 
GO
