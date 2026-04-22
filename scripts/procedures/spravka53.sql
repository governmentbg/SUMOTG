if exists (select * from sysobjects where id = object_id(N'spravka53') and OBJECTPROPERTY(id, N'IsProcedure') = 1)
drop procedure spravka53
GO

CREATE PROCEDURE spravka53
as
DECLARE
	@v_broi				int
	,@v_curdate			datetime
BEGIN
	SET NOCOUNT ON

	select u.id2 idured,sum(p.broi) broi,sum(p.broi*du.Ed_cena) stoinost
		INTO #tmp_ceni_mon_uredi
		from mon_porychka p
			inner join mon_porychkamain m
				on p.IdPorachkaMain = m.IDPorachkamain
			inner join mon_dgv_uredi du
				on du.IdFirmaMn = m.IdDogovorFirma and du.ID_kn = p.IdUred
			inner join n_uredi u
				on du.ID_kn = u.Id
		where StatusG in (0,1) and StatusM in (0,1)
			and p.Status=1
		group by u.id2

	CREATE TABLE #TMP_spravka53 (
		idured		int
		,broi		int
		,broimon	int
		,broizaq	int
		,price		numeric(10,2)
		,budget		numeric(10,2)
		,vid		varchar(3)
	)

	INSERT INTO #TMP_spravka53 (idured,broi,broimon,broizaq,vid)
		SELECT u.id2
				,SUM(CASE WHEN Status_U in (5)	THEN Broi ELSE 0 END)
				,SUM(CASE WHEN Status_U in (3,5) THEN Broi ELSE 0 END)
				,SUM(CASE WHEN Status_U in (1,2) THEN Broi ELSE 0 END)
				,max(vid) vid
			FROM n_uredi u
					left join lica_dogovor_uredi l
					ON l.Id_KT = u.Id
			GROUP BY u.Id2

	UPDATE t
		SET t.budget = isnull(b.Price*t.broizaq,0)
		FROM #TMP_spravka53 t
			inner join n_uredi u
				ON t.idured = u.id2
			inner join n_uredi_budget b
				ON u.id = b.Id

	UPDATE t
		SET  t.budget = t.budget + isnull(stoinost,0)
		FROM #TMP_spravka53 t
			inner join #tmp_ceni_mon_uredi b
			ON t.idured = b.IdUred

	UPDATE t
		SET  t.price = t.budget/ isnull(t.broimon+t.broizaq,0)
		FROM #TMP_spravka53 t
		WHERE isnull(t.broimon+t.broizaq,0) > 0

	UPDATE t
		SET t.price = CASE WHEN (x.broimon+x.broizaq) > 0 
							THEN x.budget/(x.broimon+x.broizaq) 
							ELSE 0 
					  END
			,t.broi	   = x.broi
			,t.broimon = x.broimon
			,t.broizaq = x.broizaq
			,t.budget  = x.budget
		FROM #TMP_spravka53 t
			inner join (SELECT vid
								, min(idured) idured
								,SUM(broi) broi
								,SUM(broimon) broimon
								,SUM(broizaq) broizaq
								,sum(budget) budget
							from #TMP_spravka53
							group by vid) x
			ON t.idured = x.idured

	SELECT idured,u.nkod, u.nime
			,broi as broimon
			,broizaq+broimon-broi broizaq
			,ISNULL(price,0) price,ISNULL(budget,0) budget
	  FROM #TMP_spravka53 t
			inner join n_uredi u
				ON t.idured = u.id
	  WHERE u.id not between 30 and 50
	  ORDER BY idured
END
GO

SET QUOTED_IDENTIFIER OFF 
GO
SET ANSI_NULLS ON 
GO
