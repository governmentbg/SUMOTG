if exists (select * from sysobjects where id = object_id(N'spravka50') and OBJECTPROPERTY(id, N'IsProcedure') = 1)
drop procedure spravka50
GO

CREATE PROCEDURE spravka50 
	@@pIDFIRMA	NUMERIC
	,@@pLIMIT	numeric
as
DECLARE
	@v_Error				int
BEGIN
	SET NOCOUNT ON

	CREATE TABLE #TMP_spravka50 (
		idured		int
		,ured		varchar(100)
		,broi		int
		,price		numeric(12,2)
		,budget		numeric(12,2)
		,calcbudget	numeric(12,2)
		,procbudget numeric(12,2)
		,vid		varchar(3)
	)

	CREATE TABLE #TMP_spravka50a (
		idured		int
		,broi		int
		,price		numeric(12,2)
	)

	INSERT INTO #TMP_spravka50a
	SELECT p.IdUred
		  ,p.Broi 
		  ,du.Ed_cena price
		FROM mon_porychka p 
				inner join mon_porychkamain m 
					on p.IdPorachkaMain = m.IDPorachkamain AND m.StatusPM < 9
				inner join mon_dgv_uredi du
					on m.IdDogovorFirma = du.IdFirmaMn and du.ID_kn = p.IdUred
		where  p.StatusM = 1
			AND m.IdFirma = CASE WHEN @@pIDFIRMA > 0 THEN @@pIDFIRMA ELSE m.IdFirma END	

	INSERT INTO #TMP_spravka50
	SELECT u.id2
		  ,'' ured
		  ,SUM(x.Broi) broi 
		  ,ISNULL(SUM(x.price*x.broi) /SUM(x.broi),0)
		  ,0.0 budget
		  ,SUM(x.price*x.broi) 
		  ,0.0 procbudget
		  ,MAX(vid) vid
		FROM n_uredi u
				left join #TMP_spravka50a x
				on x.idured = u.Id 
		GROUP BY u.Id2

	UPDATE t
		SET t.ured = b.nime
		FROM #TMP_spravka50 t
			inner join n_uredi b
			ON t.idured = b.Id

	UPDATE t
		SET t.budget = isnull(b.Price*b.Quantity,0)
		FROM #TMP_spravka50 t
			inner join n_uredi_budget b
			ON t.idured = b.Id


	UPDATE t
		SET t.procbudget = CASE WHEN budget > 0 
									THEN (calcbudget/budget)*100 
									ELSE 0 
							END
		FROM #TMP_spravka50 t

	UPDATE t
		SET t.price = x.price
			,t.broi = x.broi
			,t.budget = x.budget
			,t.calcbudget = x.calcbudget
			,t.procbudget = CASE WHEN x.budget > 0 
									THEN (x.calcbudget/x.budget)*100 
									ELSE 0 
							END
		FROM #TMP_spravka50 t
			inner join (SELECT vid, min(idured) idured
								,SUM(broi) broi
								,CASE WHEN sum(broi) > 0 
										THEN SUM(calcbudget)/sum(broi) 
										ELSE 0 
								  END price
								,sum(budget) budget
								,sum(calcbudget) calcbudget
							from #TMP_spravka50
							group by vid) x
			ON t.idured = x.idured

/*
	IF @@pLIMIT > 0 BEGIN
		DELETE FROM #TMP_spravka50
			WHERE procbudget < @@pLIMIT
	END
*/
	SELECT idured , ured, broi, price,budget,calcbudget,procbudget 
	  FROM #TMP_spravka50
	  WHERE price > 0
	  ORDER BY idured
END
GO

SET QUOTED_IDENTIFIER OFF 
GO
SET ANSI_NULLS ON 
GO
