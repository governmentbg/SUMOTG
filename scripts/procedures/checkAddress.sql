if exists (select * from sysobjects where id = object_id(N'checkAddress') and OBJECTPROPERTY(id, N'IsProcedure') = 1)
drop procedure checkAddress
GO


CREATE PROCEDURE checkAddress (
	@@pID		numeric
	,@@pRaion	varchar(10)
	,@@pNM		varchar(10)
	,@@pJK		varchar(10)
	,@@pUL		varchar(10)
	,@@pNomer	varchar(100)
	,@@pBlok	varchar(100)
	,@@pVh		varchar(100)
	,@@pEtaj	varchar(100)
	,@@pAp		varchar(100)
)
AS
DECLARE
	@ret	          	int,
	@fromwhere         	int,
	@rAddress          	varchar(max)
	
BEGIN
	SET @ret = null
	SET @fromwhere = 1

	SELECT @ret = ID
		FROM filtri_adresi
		WHERE A_Raion = @@pRaion 
			and NM = @@pNM
			and isnull(JK,'') = isnull(@@pJK,'')
			and isnull(UL,'') = isnull(@@pUL,'')
			and isnull(Nomer,'') = isnull(@@pNomer,'')
			and isnull(Blok,'') = isnull(@@pBlok,'')
			and isnull(vh,'') = isnull(@@pVh,'')
			and isnull(etaj,'') = isnull(@@pEtaj,'')
			and isnull(AP,'') = isnull(@@pAp,'')
			AND Status=1

/*	premahnato TEST 19 - 18.07.20203	
	IF ISNULL(@ret,0) = 0 BEGIN
		SELECT @ret = ID
			FROM filtri_adresi
			WHERE A_Raion = @@pRaion 
				and NM = @@pNM
				and isnull(JK,'') = isnull(@@pJK,'')
				and isnull(UL,'') = isnull(@@pUL,'')
				and isnull(Nomer,'') = isnull(@@pNomer,'')
				and isnull(Blok,'') = isnull(@@pBlok,'')
				and isnull(AP,'') = isnull(@@pAp,'')
				AND Status=0
	END
*/
	IF ISNULL(@ret,0) = 0 BEGIN
		SET @fromwhere = 2
		SET @ret = null

		SELECT @ret = IDL
			FROM lica_formuliar_kolektiv l
				inner join lica_dogovor d 
				on l.IdL = d.Id_L and d.Status_DL < 6
			WHERE IDL <> @@pID
				and l.A_Raion = @@pRaion 
				and NM = @@pNM
				and isnull(JK,'') = isnull(@@pJK,'')
				and isnull(UL,'') = isnull(@@pUL,'')
				and isnull(Nomer,'') = isnull(@@pNomer,'')
				and isnull(Blok,'') = isnull(@@pBlok,'')
				and isnull(vh,'') = isnull(@@pVh,'')
				and isnull(etaj,'') = isnull(@@pEtaj,'')
				and isnull(AP,'') = isnull(@@pAp,'')
				and l.IsTitulqr = 1 
				AND l.Status=1

/*	premahnato TEST 19 - 18.07.20203	
		IF ISNULL(@ret,0) = 0 BEGIN
			SELECT @ret = l.IDL
				FROM lica_formuliar_kolektiv l
						inner join lica_dogovor d 
						on l.IdL = d.Id_L and d.Status_DL < 6
				WHERE l.IDL <> @@pID
					and l.A_Raion = @@pRaion 
					and NM = @@pNM
					and isnull(JK,'') = isnull(@@pJK,'')
					and isnull(UL,'') = isnull(@@pUL,'')
					and isnull(Nomer,'') = isnull(@@pNomer,'')
					and isnull(Blok,'') = isnull(@@pBlok,'')
					and isnull(AP,'') = isnull(@@pAp,'')
					and l.IsTitulqr = 1 
					AND l.Status=1
		END
*/
		SELECT ISNULL(@ret,0) result, @fromwhere fromwhere
	END
	ELSE
		SELECT -1 result, @fromwhere fromwhere
END
GO
