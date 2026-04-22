if exists (select * from sysobjects where id = object_id(N'checkCollectingInformation') and OBJECTPROPERTY(id, N'IsProcedure') = 1)
drop procedure checkCollectingInformation
GO

CREATE PROCEDURE checkCollectingInformation 
	@@pEMAIL	varchar(max)
	,@vRaion	varchar(10)
	,@vnm		varchar(10)
	,@vjk		varchar(10)
	,@vul		varchar(10)
	,@nomer		varchar(10)
	,@vblok		varchar(10)
	,@vh		varchar(10)
	,@etaj 		varchar(10)
	,@ap 		varchar(10)
	,@@pID		numeric
as
DECLARE
	@v_Error	int
BEGIN
	SET NOCOUNT ON
	SET @v_Error = 0

/*
	IF EXISTS (SELECT 1
					FROM form_collecting_info
					WHERE ID <> @@pID
					  AND LOWER(ltrim(rtrim(e_mail))) = lower(@@pEMAIL))	
	BEGIN
		SET @v_Error = -1
	END
*/
	IF  @v_Error = 0 BEGIN
		IF EXISTS (	SELECT 1
						FROM form_collecting_info
						WHERE lower(dbo.genFullAddress (A_Raion, nm, jk, ul, nomer, blok, vh, etaj, ap)) 
								= lower(dbo.genFullAddress (@vRaion, @vnm, @vjk, @vul, @nomer, @vblok, @vh, @etaj, @ap)) 
						  AND ID <> @@pID)
		 BEGIN
			SET @v_Error = -2
		 END
	 END

	 SELECT @v_Error result
END
GO

SET QUOTED_IDENTIFIER OFF 
GO
SET ANSI_NULLS ON 
GO
