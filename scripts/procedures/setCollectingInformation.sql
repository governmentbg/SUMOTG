if exists (select * from sysobjects where id = object_id(N'setCollectingInformation') and OBJECTPROPERTY(id, N'IsProcedure') = 1)
drop procedure setCollectingInformation
GO

CREATE PROCEDURE setCollectingInformation 
	@@pID	numeric
as
DECLARE
	@v_Error				int
	,@vRaion	varchar(10)
	,@vnm		varchar(10)
	,@vjk		varchar(10)
	,@vul		varchar(10)
	,@nomer		varchar(10)
	,@vblok		varchar(10)
	,@vh		varchar(10)
	,@etaj 		varchar(10)
	,@ap 		varchar(10)
	,@vdesc		varchar(100)
BEGIN
	SET NOCOUNT ON

	SELECT @vRaion = A_Raion, @vnm = nm, @vjk = jk, @vul = ul, @nomer = nomer
		 , @vblok = blok, @vh = vh, @etaj = etaj, @ap = ap
		FROM form_collecting_info
		WHERE ID = @@pID

	SELECT U_nom
		INTO #TMP_ADDR
		FROM vwAdres
		WHERE lower(Adres) = lower(dbo.genFullAddress (@vRaion, @vnm, @vjk, @vul, @nomer, @vblok, @vh, @etaj, @ap)) 

	IF EXISTS (SELECT 1 FROM #TMP_ADDR) BEGIN
		SET @vdesc = null
		SELECT @vdesc = COALESCE(@vdesc+', ','')+U_nom
			FROM #TMP_ADDR

		UPDATE form_collecting_info
			SET  [status] =1 
				,descript = @vdesc
			WHERE ID = @@pID
	END

	SELECT 1 result
END
GO

SET QUOTED_IDENTIFIER OFF 
GO
SET ANSI_NULLS ON 
GO
