if exists (select * from sysobjects where id = object_id(N'spravka51') and OBJECTPROPERTY(id, N'IsProcedure') = 1)
drop procedure spravka51
GO

CREATE PROCEDURE spravka51
	@@pTIPURED	varchar(3),
	@@pUREDI	varchar(5)
as
DECLARE
	@v_Error				int
BEGIN
	SET NOCOUNT ON

	CREATE TABLE #TMP_spravka51 (
		idured		int
		,ured		varchar(100)
		,broi		int
		,price		numeric(10,2)
		,budget		numeric(10,2)
		,calcbudget	numeric(10,2)
		,procbudget numeric(10,2)
		,tip		int
	)

	CREATE TABLE #TMP_spravka51a (
		idured		int
		,A			int
		,B			int
		,O			int
	)

	CREATE TABLE #TMP_spravka51b (
		idured		int
		,broi		int
		,price		numeric(12,2)
	)


	INSERT INTO #TMP_spravka51a
		select u.id2
			, SUM(CASE WHEN ISNULL(l.Status_U,0) = 1 THEN l.Broi ELSE 0 END) A
			, SUM(CASE WHEN ISNULL(l.Status_U,0) = 2 THEN l.Broi ELSE 0 END) B
			, SUM(CASE WHEN ISNULL(l.Status_U,9) not in (1,2,3,5) THEN l.Broi ELSE 0 END) O
		from  lica_dogovor_uredi l 
				inner join n_uredi u
					on l.Id_KT= u.Id
		group by u.id2

	--dobawqme uredi za koito oshte nqma dogovor
	UPDATE l
		SET l.A = l.A + x.broi
		FROM #TMP_spravka51a l
				inner join (
						SELECT  u.id2, sum(fu.Broi) broi
							FROM lica_formuliar f
									inner join lica_formuliar_uredi fu
										on f.Id_L = fu.Id_L
									inner join n_uredi u
										on fu.Id_KT= u.Id
							WHERE f.Status_F = 1
							GROUP BY u.id2) x
				on l.idured = x.Id2

--row 1
	INSERT INTO #TMP_spravka51
		SELECT u.Id2, u.nime
				, a+b
				, isnull(x.Price,0)
				, (a+b)*isnull(x.Price,0)
				, (a+b)*isnull(x.Price,0)
				, 100,1
			FROM (select distinct id2
						from n_uredi 
						WHERE status = 1)  u1
					inner join n_uredi u
						ON u.id = u1.Id2
					left join(SELECT t.idured, a,b,o, b.Price
									from #TMP_spravka51a t
										inner join n_uredi_budget b
											ON t.idured = b.Id) x
						on u.Id = x.idured
			

	INSERT INTO #TMP_spravka51b
		SELECT u.Id2
			  ,p.Broi 
			  ,du.Ed_cena price
			FROM  mon_porychka p 
					inner join mon_porychkamain m 
						on p.IdPorachkaMain = m.IDPorachkamain AND m.StatusPM < 9
					inner join mon_dgv_uredi du
						on m.IdDogovorFirma = du.IdFirmaMn and du.ID_kn = p.IdUred
					inner join mon_dogovor d
						on du.IdFirmaMn = d.IdFirmaMn and d.STATUS_DM =2
					inner join n_uredi u
						on p.IdUred = u.Id
			where p.StatusG in (0,1)
			  and p.StatusM in (0,1)

--row 2
	--planiran budget da e broi montirani po tqhnata cena ot tehn.zadanie 
	INSERT INTO #TMP_spravka51
		SELECT u.Id2, ''
				, SUM(t.broi)
				, CASE WHEN SUM(t.Broi) > 0 THEN sum(t.price*t.broi)/SUM(t.Broi) ELSE 0 END
				, 0
				, sum(t.price*t.broi),0,2
			FROM (select distinct id2
						from n_uredi 
						WHERE status = 1)  u
					left join #TMP_spravka51b t
						on u.Id2 = t.idured
			GROUP BY u.Id2

	UPDATE t
		SET t.budget = (t.broi*b.Price)
		FROM #TMP_spravka51 t
				inner join n_uredi_budget b
					ON t.idured = b.id
		WHERE t.tip=2

	UPDATE t
		SET t.procbudget = CASE WHEN t.budget > 0 THEN (t.calcbudget/t.budget)*100 ELSE 0 END
		FROM #TMP_spravka51 t
		WHERE t.tip=2

--row 3
	INSERT INTO #TMP_spravka51
		SELECT u.id2, ''
				, SUM(broi)
				, CASE WHEN SUM(broi) > 0 THEN SUM(broi*price)/SUM(broi) ELSE 0 END
				, 0
				, SUM(broi*price)
				,0,3
			FROM (select distinct id2
						from n_uredi 
						WHERE status = 1)  u
					left join #TMP_spravka51 t
						ON t.idured = u.id2
			GROUP BY u.id2

	UPDATE t
		SET t.budget = isnull(b.Price*t.broi,0)
		FROM #TMP_spravka51 t
			inner join n_uredi_budget b
			ON t.idured = b.Id
		WHERE tip=3

	UPDATE t
		SET t.procbudget = CASE WHEN t.budget > 0 THEN (t.calcbudget/t.budget)*100 ELSE 0 END
		FROM #TMP_spravka51 t
		WHERE tip=3

	IF ISNULL(@@pTIPURED,'ALL') <> 'ALL' BEGIN
		SELECT idured , ured, broi, price,budget,calcbudget,procbudget, tip  
		  FROM #TMP_spravka51 t
					inner join n_uredi u
						on t.idured = u.Id
		  WHERE u.Vid = @@pTIPURED
--		     AND price > 0
		  ORDER BY idured,tip
	END
	ELSE
	IF LEN(ISNULL(@@pUREDI,'')) > 0 BEGIN
		SELECT idured , ured, broi, price,budget,calcbudget,procbudget, tip  
		  FROM #TMP_spravka51 t
					inner join n_uredi u
						on t.idured = u.Id
		  WHERE u.nkod = @@pUREDI
--		     AND price > 0
		  ORDER BY idured,tip
	END
	ELSE BEGIN	
		SELECT idured , ured
				, isnull(broi,0) broi
				, isnull( price,0) price
				, isnull(budget,0) budget
				, isnull(calcbudget,0) calcbudget
				, isnull(procbudget,0) procbudget
				, tip 
		  FROM #TMP_spravka51
--		  WHERE price > 0
		  ORDER BY idured,tip
	END
END
GO

SET QUOTED_IDENTIFIER OFF 
GO
SET ANSI_NULLS ON 
GO
