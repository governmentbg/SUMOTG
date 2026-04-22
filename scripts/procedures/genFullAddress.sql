--FUNCTION--
IF EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[genFullAddress]') AND type in (N'FN', N'IF', N'TF', N'FS', N'FT'))
	DROP FUNCTION [dbo].[genFullAddress]
GO


CREATE FUNCTION genFullAddress (
	@@pRaion	varchar(10)
	,@@pNM		varchar(10)
	,@@pJK		varchar(10)
	,@@pUL		varchar(10)
	,@@pNomer	varchar(100)
	,@@pBlok	varchar(100)
	,@@pVh		varchar(100)
	,@@pEtaj	varchar(100)
	,@@pAp		varchar(100)
)
RETURNS varchar(max)
AS
BEGIN
	DECLARE
		@ret	          	varchar(max),
		@rName	          	varchar(max),
		@nmName	          	varchar(max),
		@jkName	          	varchar(max),
		@ulName				varchar(max)

	SELECT @rName = r.NIME 
		FROM dbo.n_raioni r 
		WHERE r.NKOD = @@pRaion

	SELECT @nmName = nm.nime
		FROM dbo.n_ns_mesta nm
		WHERE nm.NKOD = @@pNM

	SELECT @jkName = jk.nime
		FROM dbo.n_jk jk
		WHERE jk.NKOD = @@pJK

	SELECT @ulName = ul.nime
		FROM dbo.n_ulicii ul
		WHERE ul.NKOD = @@pUL

	SET @ret = IIF(@rName is not null, 'район: '+ @rName + ', ','') + 
				IIF(@nmName is not null, @nmName+', ','') +
				IIF(@jkName IS NOT NULL , @jkName+', ' , '')+
				IIF(@ulName IS NOT NULL , @ulName, '')+
				IIF(LEN(ISNULL(@@pNomer,'')) > 0, ' № ' + @@pNomer, '')+
				IIF(LEN(ISNULL(@@pBlok,'')) > 0, ', бл. ' + @@pBlok, '')+
				IIF(LEN(ISNULL(@@pVh,'')) > 0, ', вх. ' + @@pVh, '')+
				IIF(LEN(ISNULL(@@pEtaj,'')) > 0, ', ет. ' + @@pEtaj, '')+
				IIF(LEN(ISNULL(@@pAp,'')) > 0, ', ап. ' + @@pAp, '') 	
	RETURN @ret
END
GO
