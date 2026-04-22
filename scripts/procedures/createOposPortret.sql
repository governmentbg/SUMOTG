if exists (select * from sysobjects where id = object_id(N'createOposPortret') and OBJECTPROPERTY(id, N'IsProcedure') = 1)
drop procedure createOposPortret
GO

CREATE PROCEDURE createOposPortret 
	@@pFAZA		NUMERIC
	,@@pUNOMER	NUMERIC
	,@@pVID		NUMERIC
	,@@pVERSION int = 0
as

DECLARE 
	@vcode				varchar(4)
    ,@vtext				VARCHAR(max)
    ,@vtext2			NVARCHAR(max)
	,@vcnt				int
	,@vidured			numeric
	,@vbroi				numeric
	,@vIdPorachkaMain	numeric
	,@visbold			int
	,@tmpdate			datetime
BEGIN
	SET NOCOUNT ON

	CREATE TABLE #TMP_SHABLON (
		CODE	varchar(4)
		,TEXT	varchar(max)
		,ISBOLD int
	)

	CREATE TABLE #TMP_OPOS (
		CODE	varchar(10)
		,TEXT	varchar(max)
		,TEXT2	nvarchar(max)
		,ISBOLD int
	)

	INSERT INTO #TMP_SHABLON
		SELECT CODE, TEXT, ISBOLD
			FROM [n_shablon_opos]
			WHERE Faza  = 0 
			  AND Status = 1
              AND ISSHORT = CASE WHEN @@pVERSION = 1 THEN 1 ELSE ISSHORT END
			ORDER BY ID
	
	SELECT l.IME, l.v_ident, l.IDENT, l.TypeLice, l.V7, l.nV8 as v8
			,dbo.genFullAddress (l.A_Raion,l.nm, l.jk, l.ul, l.nomer, l.blok, l. vh, l.etaj, l.ap) As Adres
			,l.N_LK, l.e_mail E_Mail, l.tel Telefon,f.*
		INTO #tmp_formulaqr
		FROM dbo.lica m
			inner join dbo.lica_formuliar f 
				ON m.ID_L = f.Id_L AND m.v_lice = @@pVID
			inner JOIN dbo.lica_formuliar_kolektiv l 
				ON f.Id_L=l.IdL and l.IsTitulqr =1 and l.Status = 1	
		WHERE f.UNomer -(f.Faza* 100000) = @@pUNOMER
		  AND f.faza = @@pFAZA

	SELECT TOP 1
			@vcode = code
			,@vtext = TEXT
			,@visbold = ISBOLD
		FROM #TMP_SHABLON

	WHILE @vcode is not null
	BEGIN
		SET @vtext2 = ''
		DELETE FROM #TMP_SHABLON 
			WHERE code = @vcode

		IF @vcode = 'р02' BEGIN
			SELECT @vtext = @vtext
				FROM #tmp_formulaqr

			SELECT @vtext2 =U_nom
				FROM #tmp_formulaqr t 
		END
		ELSE
		IF @vcode = 'р03' BEGIN
			SELECT @vtext2 = n.Text
				FROM #tmp_formulaqr t 
						inner join n_statusi n 
						ON t.Status_F = n.Status_Code and n.status_name = 'Status_F'

		END
		ELSE
		IF @vcode = 'р04' BEGIN
			SELECT @vtext2 = n.Text
				FROM n_nmn_obshti n 
				WHERE n.id_kn = @@pVID 
				  AND n.kod_nmn = '01'
		END
		ELSE
		IF @vcode = 'р05' BEGIN
			SELECT @vtext2 = n.Text
				FROM #tmp_formulaqr t 
						inner join lica_formuliar_kolektiv l 
							ON t.Id_L = l.IdL AND l.IsTitulqr = 1 AND l.Status=1
						inner join n_statusi n
							ON l.StatusL = n.Status_Code and n.status_name = 'Status_L'
		END
		ELSE
		IF @vcode = 'р06' BEGIN
			SELECT @vtext = SPACE(1) +t.IME
				FROM #tmp_formulaqr t 
		END
		ELSE
		IF @vcode = 'р07' BEGIN
			SELECT @vtext = SPACE(1)+n.Text
				FROM #tmp_formulaqr t 
					inner join n_nmn_obshti n 
						ON n.id_kn = CASE WHEN t.v_ident = 0 THEN 4 ELSE t.v_ident END 
							AND n.kod_nmn = '02'

			SELECT @vtext2 = t.IDENT
				FROM #tmp_formulaqr t 			
		END
		ELSE
		IF @vcode = 'р08' BEGIN
			SELECT @vtext2 = t.N_LK
				FROM #tmp_formulaqr t 
		END
		ELSE
		IF @vcode = 'р09' BEGIN
			SELECT @vtext2 = t.Telefon
				FROM #tmp_formulaqr t 
		END
		ELSE
		IF @vcode = 'р10' BEGIN
			SELECT @vtext2 = t.E_Mail
				FROM #tmp_formulaqr t 
		END
		ELSE
		IF @vcode = 'р11' BEGIN
			SELECT @vtext2 = SPACE(1) + t.Adres
				FROM #tmp_formulaqr t 

			INSERT INTO #TMP_OPOS 
				VALUES (@vcode,@vtext,@vtext2,@visbold)	

			IF @@pVID = 2 BEGIN
				IF EXISTS (SELECT 1 
								FROM #tmp_formulaqr t 
									  inner join lica_formuliar_kolektiv l 
									  ON t.Id_L = l.IdL 
										AND l.IsTitulqr = 0 
										AND l.Status=1)
				BEGIN
					INSERT INTO #TMP_OPOS 
						VALUES (@vcode,'КОЛЕКТИВ',@vtext2,@visbold)	
				
					INSERT INTO #TMP_OPOS 
						SELECT @vcode, l.IME, n.Text,0
							FROM #tmp_formulaqr t 
									inner join lica_formuliar_kolektiv l 
										ON t.Id_L = l.IdL AND l.IsTitulqr = 0 AND l.Status=1
									inner join n_statusi n
										ON l.StatusL = n.Status_Code and n.status_name = 'Status_L'
					SET @vcode = null
				END
				ELSE BEGIN
					INSERT INTO #TMP_OPOS 
						VALUES (@vcode,'КОЛЕКТИВ','няма',@visbold)	
				END
			END
			ELSE
			IF @@pVID = 3 BEGIN
				INSERT INTO #TMP_OPOS 
					SELECT @vcode+'.2','ФИРМА',f.Ime,@visbold
						FROM #tmp_formulaqr t 
							inner join lica_formuliar_firma f
							ON t.Id_L = f.IdL

				IF (@@pVERSION = 0) BEGIN
					INSERT INTO #TMP_OPOS 
							SELECT @vcode+'.3','Булстат',f.Ident,0
								FROM #tmp_formulaqr t 
									inner join lica_formuliar_firma f
									ON t.Id_L = f.IdL
					
					INSERT INTO #TMP_OPOS 
							SELECT @vcode+'.4','Адрес на фирмата'
									,dbo.genFullAddress (f.ARaion,f.nm, f.jk, f.ul, f.nomer, f.blok, f.vh, f.etaj, f.ap) As Adres
									,0
								FROM #tmp_formulaqr t 
									inner join lica_formuliar_firma f
									ON t.Id_L = f.IdL
				END
			END

			SET @vcode = null
		END
		ELSE
		IF @vcode = 'р12' BEGIN
			SET @vcode = null
		END
		ELSE
		IF @vcode = 'р13' BEGIN
			IF EXISTS (SELECT 1 
							FROM #tmp_formulaqr t 
								  inner join lica_formuliar_kolektiv l 
								  ON t.Id_L = l.IdL AND l.IsTitulqr = 0 AND l.Status=0)
			BEGIN
				INSERT INTO #TMP_OPOS 
					VALUES (@vcode,@vtext,@vtext2,@visbold)	
				
				INSERT INTO #TMP_OPOS 
					SELECT @vcode, l.IME, n.Text,0
						FROM #tmp_formulaqr t 
								inner join lica_formuliar_kolektiv l 
									ON t.Id_L = l.IdL AND l.IsTitulqr = 0 AND l.Status=0
								inner join n_statusi n
									ON l.StatusL = n.Status_Code and n.status_name = 'Status_L'
				SET @vcode = null
			END
			ELSE BEGIN
				SET @vtext2 = 'няма'
			END
		END
		ELSE
		IF @vcode = 'р15' BEGIN
			SELECT @vtext = @vtext + ' '+ ISNULL(t.v7,'')
				FROM #tmp_formulaqr t 
		END
		ELSE
		IF @vcode = 'р16' BEGIN
			SELECT @vtext2 = ISNULL(n.Text,'')
				FROM #tmp_formulaqr t 
					inner join n_nmn_obshti n 
						ON n.id_kn = t.v8 AND n.kod_nmn = '03'
		END
		ELSE
		IF @vcode = 'р17' BEGIN			
			SELECT @vtext2 = ISNULL(n.Text,'')
				FROM #tmp_formulaqr t 
					inner join n_nmn_obshti n 
						ON n.id_kn = t.nV9 AND n.kod_nmn = '04'
		END
		ELSE
		IF @vcode = 'р18' BEGIN
			SELECT @vtext2 = ISNULL(n.Text,'')
				FROM #tmp_formulaqr t 
					inner join n_nmn_obshti n 
						ON n.id_kn = t.nV10 AND n.kod_nmn = '05'
		END
		ELSE
		IF @vcode = 'р19' BEGIN
			SELECT @vtext2 = convert(varchar,t.V11)
				FROM #tmp_formulaqr t 
		END
		ELSE
		IF @vcode = 'р20' BEGIN
			SELECT @vtext2 = convert(varchar,t.V12)
				FROM #tmp_formulaqr t 
		END
		ELSE
		IF @vcode = 'р21' BEGIN
			SELECT @vtext2 = convert(varchar,t.V13)
				FROM #tmp_formulaqr t 
		END
		ELSE
		IF @vcode = 'р22' BEGIN
			SELECT @vtext2 = convert(varchar,t.V14)
				FROM #tmp_formulaqr t 
		END
		ELSE
		IF @vcode = 'р23' BEGIN
			SELECT @vtext2 = convert(varchar,t.V15)
				FROM #tmp_formulaqr t 
		END
		ELSE
		IF @vcode = 'р24' BEGIN
			SELECT @vtext2 = CASE WHEN t.V16 = 1 THEN 'Да'
									  WHEN t.V16 = 2 THEN 'Не'
									  ELSE 'Без отговор'
								  END
				FROM #tmp_formulaqr t 
		END
		ELSE
		IF @vcode = 'р25' BEGIN
				SELECT @vtext2 = CASE WHEN t.V17 = 1 THEN 'Да'
									  WHEN t.V17 = 2 THEN 'Не'
									  ELSE 'Без отговор'
								  END
				FROM #tmp_formulaqr t 
		END
		ELSE
		IF @vcode = 'р27' BEGIN
			INSERT INTO #TMP_OPOS 
				VALUES (@vcode,@vtext,@vtext2,@visbold)	
				
			INSERT INTO #TMP_OPOS 
				SELECT @vcode
					   ,' 18.'+convert(varchar,ROW_NUMBER() OVER(ORDER BY n.id_kn ASC))+' '+n.Text
					   , convert(varchar,l.broi)
					   , 0
					FROM #tmp_formulaqr t 
							inner join lica_formuliar_olduredi l
								ON t.Id_L = l.Id_L AND l.Status=1
							inner join n_nmn_obshti n 
								ON n.id_kn = l.Id_KT AND n.kod_nmn = '06'
			SET @vcode = null
		END
		ELSE
		IF @vcode = 'р28' BEGIN
				SELECT @vtext2 = ISNULL(n.Text,'')
				FROM #tmp_formulaqr t 
					inner join n_nmn_obshti n 
						ON n.id_kn = t.nV19 AND n.kod_nmn = '07'
		END
		ELSE
		IF @vcode = 'р29' BEGIN
			SELECT @vtext2 = convert(varchar,t.V20)
				FROM #tmp_formulaqr t 
		END
		ELSE
		IF @vcode = 'р31' BEGIN
			SELECT @vtext2 = convert(varchar,t.V211)
				FROM #tmp_formulaqr t 
		END
		ELSE
		IF @vcode = 'р32' BEGIN
			SELECT @vtext2 = convert(varchar,t.V212)
				FROM #tmp_formulaqr t 
		END
		ELSE
		IF @vcode = 'р33' BEGIN
			SELECT @vtext2 = convert(varchar,t.V213)
				FROM #tmp_formulaqr t 
		END
		ELSE
		IF @vcode = 'р34' BEGIN
			SELECT @vtext2 = convert(varchar,t.V22)
				FROM #tmp_formulaqr t 
		END
		ELSE
		IF @vcode = 'р35' BEGIN
				SELECT @vtext2 = CASE WHEN t.V23 = 1 THEN 'Да'
									  WHEN t.V23 = 2 THEN 'Не'
									  ELSE 'Без отговор'
								  END
				FROM #tmp_formulaqr t 
		END
		ELSE
		IF @vcode = 'р36' BEGIN
			SELECT @vtext2 = convert(varchar,t.V24)
				FROM #tmp_formulaqr t 
		END
		ELSE
		IF @vcode = 'р37' BEGIN
				SELECT @vtext2 = CASE WHEN t.V25 = 1 THEN 'Да'
									  WHEN t.V25 = 2 THEN 'Не'
									  ELSE 'Без отговор'
								  END
				FROM #tmp_formulaqr t 
		END
		ELSE
		IF @vcode = 'р38' BEGIN
			SELECT @vtext2 = convert(varchar,t.V26)
				FROM #tmp_formulaqr t 
		END
		ELSE
		IF @vcode = 'р39' BEGIN
				SELECT @vtext2 = CASE WHEN t.V27 = 1 THEN 'Да'
									  WHEN t.V27 = 2 THEN 'Не'
									  ELSE 'Без отговор'
								  END
				FROM #tmp_formulaqr t 
		END
		ELSE
		IF @vcode = 'р40' BEGIN
			SELECT @vtext2 = convert(varchar,t.V28)
				FROM #tmp_formulaqr t 
		END
		ELSE
		IF @vcode = 'р41' BEGIN
				SELECT @vtext2 = ISNULL(n.Text,'')
				FROM #tmp_formulaqr t 
					inner join n_nmn_obshti n 
						ON n.id_kn = t.nV29 AND n.kod_nmn = '08'
		END
		ELSE
		IF @vcode = 'р42' BEGIN
				SELECT @vtext2 = CASE WHEN t.V30 = 1 THEN 'Да'
									  WHEN t.V30 = 2 THEN 'Не'
									  ELSE 'Без отговор'
								  END
				FROM #tmp_formulaqr t 
		END
		ELSE
		IF @vcode = 'р43' BEGIN
			SELECT @vtext2 = convert(varchar,t.V31)
				FROM #tmp_formulaqr t 
		END
		ELSE
		IF @vcode = 'р44' BEGIN
			SELECT @vtext2 = convert(varchar,t.V32)
				FROM #tmp_formulaqr t 
		END
		ELSE
		IF @vcode = 'р45' BEGIN
			SELECT @vtext2 = convert(varchar,t.V33)
				FROM #tmp_formulaqr t 
		END
		ELSE
		IF @vcode = 'р47' BEGIN
				SELECT @vtext2 = CASE WHEN t.V34 = 1 THEN 'Да'
									  WHEN t.V34 = 2 THEN 'Не'
									  ELSE 'Без отговор'
								  END
				FROM #tmp_formulaqr t 
		END
		ELSE
		IF @vcode = 'р48' BEGIN
				SELECT @vtext2 = CASE WHEN t.V35 = 1 THEN 'Да'
									  WHEN t.V35 = 2 THEN 'Не'
									  ELSE 'Без отговор'
								  END
				FROM #tmp_formulaqr t 
		END
		ELSE
		IF @vcode = 'р49' BEGIN
				SELECT @vtext2 = CASE WHEN t.V36 = 1 THEN 'Да'
									  WHEN t.V36 = 2 THEN 'Не'
									  ELSE 'Без отговор'
								  END
				FROM #tmp_formulaqr t 
		END
		ELSE
		IF @vcode = 'р50' BEGIN
				SELECT @vtext2 = CASE WHEN t.V37 = 1 THEN 'Да'
									  WHEN t.V37 = 2 THEN 'Не'
									  ELSE 'Без отговор'
								  END
				FROM #tmp_formulaqr t 
		END
		ELSE
		IF @vcode = 'р51' BEGIN
				SELECT @vtext2 = CASE WHEN t.V38 = 1 THEN 'Да'
									  WHEN t.V38 = 2 THEN 'Не'
									  ELSE 'Без отговор'
								  END
				FROM #tmp_formulaqr t 
		END
		ELSE
		IF @vcode = 'р53' BEGIN
			SELECT @vtext2 = convert(varchar,t.V391)
				FROM #tmp_formulaqr t 
		END
		ELSE
		IF @vcode = 'р54' BEGIN
			SELECT @vtext2 = convert(varchar,t.V392)
				FROM #tmp_formulaqr t 
		END
		ELSE
		IF @vcode = 'р56' BEGIN
			SELECT @vtext2 = convert(varchar,t.V401)
				FROM #tmp_formulaqr t 
		END
		ELSE
		IF @vcode = 'р57' BEGIN
			SELECT @vtext2 = convert(varchar,t.V402)
				FROM #tmp_formulaqr t 
		END
		ELSE
		IF @vcode = 'р58' BEGIN
			SELECT @vtext2 = convert(varchar,t.V41)
				FROM #tmp_formulaqr t 
		END
		ELSE
		IF @vcode = 'р60' BEGIN
			SELECT @vtext2 = convert(varchar,t.V421)
				FROM #tmp_formulaqr t 
		END
		ELSE
		IF @vcode = 'р61' BEGIN
			SELECT @vtext2 = convert(varchar,t.V422)
				FROM #tmp_formulaqr t 
		END
		ELSE
		IF @vcode = 'р62' BEGIN
			SELECT @vtext2 = convert(varchar,t.V423)
				FROM #tmp_formulaqr t 
		END
		ELSE
		IF @vcode = 'р63' BEGIN
			SELECT @vtext2 = t.Comentar
				FROM #tmp_formulaqr t 
		END
		ELSE
		IF @vcode = 'р65' BEGIN
			INSERT INTO #TMP_OPOS 
				VALUES (@vcode,@vtext,@vtext2,@visbold)	
				
			INSERT INTO #TMP_OPOS 
				SELECT @vcode
					   ,' 43.'+convert(varchar,ROW_NUMBER() OVER(ORDER BY n.id ASC))+' '+n.nkod+' '+n.nime
					   , convert(varchar,l.broi)
					   , 0
					FROM #tmp_formulaqr t 
							inner join lica_formuliar_uredi l
								ON t.Id_L = l.Id_L AND l.Status=1
							inner join n_uredi n
								ON n.id = l.Id_KT
			SET @vcode = null
		END
		ELSE
		IF @vcode = 'р66' BEGIN
			IF EXISTS (SELECT 1 
							FROM #tmp_formulaqr t 
								  inner join lica_dogovor_uredi l 
								  ON t.Id_L = l.Id_L AND l.Status=1)
			BEGIN
				INSERT INTO #TMP_OPOS 
					VALUES (@vcode,@vtext,@vtext2,@visbold)	
				
				INSERT INTO #TMP_OPOS 
					SELECT @vcode
							, ' '+u.nkod+' '+u.nime+ ', Статус: '+ n.Text
							, convert(varchar,l.Broi)
							, 0
						FROM #tmp_formulaqr t 
								inner join lica_dogovor_uredi l 
									ON t.Id_L = l.Id_L AND l.Status=1
								inner join n_uredi u 
									ON l.Id_KT = u.Id
								inner join n_statusi n
									ON l.Status_U = n.Status_Code and n.status_name = 'Status_U'
				SET @vcode = null
			END
			ELSE BEGIN
				SET @vtext2 = 'няма'
			END
		END
		ELSE
		IF @vcode = 'р67' BEGIN
			IF EXISTS(SELECT 1 
						FROM #tmp_formulaqr t 
							inner join lica_dogovor_uredi_arhiv l 
								ON t.Id_L = l.Id_L 
									AND l.Status=1
									AND l.Status_U =4)
			BEGIN
				INSERT INTO #TMP_OPOS 
					VALUES (@vcode,@vtext,@vtext2,@visbold)	

				INSERT INTO #TMP_OPOS 
					SELECT @vcode
							, ' '+u.nkod+' '+u.nime+ ', Статус: '+ n.Text
							, convert(varchar,l.Broi)
							, 0
						FROM #tmp_formulaqr t 
								inner join lica_dogovor_uredi_arhiv l 
									ON t.Id_L = l.Id_L AND l.Status=1
								inner join n_uredi u 
									ON l.Id_KT = u.Id
								inner join n_statusi n
									ON l.Status_U = n.Status_Code and n.status_name = 'Status_U'
						WHERE l.Status_U = 4
				SET @vcode = null
			END
			ELSE BEGIN
				SET @vtext2 = 'няма'
			END
		END
		ELSE
		IF @vcode = 'р68' BEGIN
			IF EXISTS(SELECT 1 
						FROM #tmp_formulaqr t 
							inner join lica_dogovor_uredi_arhiv l 
								ON t.Id_L = l.Id_L 
									AND l.Status=1
									AND l.Status_U =8)
			BEGIN
				INSERT INTO #TMP_OPOS 
					VALUES (@vcode,@vtext,@vtext2,@visbold)	

				INSERT INTO #TMP_OPOS 
					SELECT @vcode
							, ' '+u.nkod+' '+u.nime+ ', Статус: '+ n.Text
							, convert(varchar,l.Broi)
							, 0
						FROM #tmp_formulaqr t 
								inner join lica_dogovor_uredi_arhiv l 
									ON t.Id_L = l.Id_L AND l.Status=1
								inner join n_uredi u 
									ON l.Id_KT = u.Id
								inner join n_statusi n
									ON l.Status_U = n.Status_Code and n.status_name = 'Status_U'
						WHERE l.Status_U = 8
				SET @vcode = null
			END
			ELSE BEGIN
				SET @vtext2 = 'няма'
			END
		END
		ELSE
		IF @vcode = 'р69' BEGIN
			SELECT @vtext2 = n.Text
				FROM #tmp_formulaqr t 
					inner join lica_dogovor d
						ON t.Id_L = d.Id_L
					inner join n_statusi n 
						ON d.Status_DL = n.Status_Code and n.status_name = 'Status_DL'
		END
		ELSE
		IF @vcode = 'р70' BEGIN
			SELECT @vtext2 = l.Reg_N
				FROM #tmp_formulaqr t 
					inner join lica_dogovor l 
					ON t.Id_L = l.Id_L
		END
		ELSE
		IF @vcode = 'р71' BEGIN
			SELECT @vtext2 = ISNULL(convert(varchar,l.Data_reg_N,104),'')
				FROM #tmp_formulaqr t 
					inner join lica_dogovor l 
					ON t.Id_L = l.Id_L
		END
		ELSE
		IF @vcode = 'р72' BEGIN
			SELECT @vtext2 = convert(varchar,l.SrokSobstvenost)
				FROM #tmp_formulaqr t 
					inner join lica_dogovor l 
					ON t.Id_L = l.Id_L
		END
		ELSE
		IF @vcode = 'р73' BEGIN
			SELECT @vtext2 = convert(varchar,l.SrokDogovor)
				FROM #tmp_formulaqr t 
					inner join lica_dogovor l 
					ON t.Id_L = l.Id_L
		END
		ELSE
		IF @vcode = 'р74' BEGIN
			SELECT @vtext2 = l.Comentar
				FROM #tmp_formulaqr t 
					inner join lica_dogovor l 
					ON t.Id_L = l.Id_L
		END
		ELSE
		IF @vcode = 'р75' BEGIN
			SELECT @vcnt = COUNT(*)
				FROM #tmp_formulaqr t 
						inner join lica_dopsporazumeniq l 
						ON t.Id_L = l.Id_L

			IF ISNULL(@vcnt,0) > 0 BEGIN
				INSERT INTO #TMP_OPOS 
					VALUES (@vcode,@vtext,convert(varchar,@vcnt),@visbold)	
				
				INSERT INTO #TMP_OPOS 
					SELECT @vcode
							, ' '+u.RegNomer+' '+u.Komentar
							, n.Text
							, 0
						FROM #tmp_formulaqr t 
								inner join lica_dopsporazumeniq u 
									ON t.Id_L = u.Id_L 
								inner join n_nmn_obshti n
									ON u.IdDopSp = n.id_kn
				SET @vcode = null
			END
			ELSE BEGIN
				SET @vtext2 = '0'
			END
		END
		ELSE
		IF @vcode = 'р76' BEGIN
			SELECT @vcnt = COUNT(*)
				FROM #tmp_formulaqr t 
						inner join lica_dogovor l 
							ON t.Id_L = l.Id_L
						inner join mon_porychka p
							ON p.IdDogovorLice = l.Id_dog_L

			IF ISNULL(@vcnt,0) > 0 BEGIN
				INSERT INTO #TMP_OPOS 
					VALUES (@vcode,@vtext,@vtext2,@visbold)	

				SELECT p.IdUred, p.Broi, p.IdPorachkaMain, p.StatusG, p.StatusM, p.MonData
					INTO #TMPMONUREDI
					FROM #tmp_formulaqr t 
						inner join lica_dogovor l 
							ON t.Id_L = l.Id_L
						inner join mon_porychka p
							ON p.IdDogovorLice = l.Id_dog_L
					WHERE p.Status=1
					ORDER BY p.IdPorachkaMain

				SELECT DISTINCT IdPorachkaMain
					INTO #TMPMONPORYCHKI
					FROM #TMPMONUREDI  						
					ORDER BY IdPorachkaMain

				SELECT TOP 1 @vIdPorachkaMain=IdPorachkaMain
					FROM #TMPMONPORYCHKI
					ORDER BY IdPorachkaMain

				WHILE @vIdPorachkaMain is not null
				BEGIN

					--row 1					
					INSERT INTO #TMP_OPOS 
						SELECT @vcode
								, 'Поръчка № '+ convert(varchar,@vIdPorachkaMain) 
								, 'Статус: '+IIF(LEN(ISNULL(n.Text,''))=0,'няма',n.Text)
								, 0
							FROM mon_porychkamain p
								inner join n_statusi n
								on p.StatusPM = n.Status_Code and n.status_name = 'Status_DPM'
							WHERE IDPorachkamain = @vIdPorachkaMain

					--row 2					
					INSERT INTO #TMP_OPOS 
						SELECT @vcode
								, f.Ime
								, d.Reg_Index
								, 0
							FROM mon_porychkamain p
								inner join mon_dogovor d
									on p.IdDogovorFirma = d.IdFirmaMn
								inner join firmi f
									on p.IdFirma = f.IdFirma
							WHERE IDPorachkamain = @vIdPorachkaMain


					SELECT TOP 1 @vidured= IdUred, @vbroi = Broi
						FROM #TMPMONUREDI
						WHERE IdPorachkaMain = @vIdPorachkaMain
						ORDER BY IdPorachkaMain, Idured

					WHILE @vidured is not null
					BEGIN

						--row 3					
						INSERT INTO #TMP_OPOS 
							SELECT @vcode
									, u.nkod+' '+u.nime
									, convert(varchar,@vbroi)+' бр.'
									, 0
								FROM n_uredi u
								WHERE id = @vidured


						--row 4					
						INSERT INTO #TMP_OPOS 
							SELECT @vcode
									, 'График'
									,  'Статус: '+IIF(LEN(ISNULL(n.Text,''))=0,'няма',n.Text)
									, 0
								FROM #TMPMONUREDI t
									left join n_statusi n
									ON t.StatusG = n.Status_Code and n.Status_name = 'StatusG'
								WHERE IdUred = @vidured
								and IDPorachkamain = @vIdPorachkaMain

						--row 5					
						INSERT INTO #TMP_OPOS 
							SELECT @vcode
									, 'Монтаж, '+ISNULL('дата '+convert(varchar,t.MonData,104),'')
									, 'Статус: '+IIF(LEN(ISNULL(n.Text,''))=0,'няма',n.Text)
									, 0
								FROM #TMPMONUREDI t
									left join n_statusi n
									ON t.StatusM = n.Status_Code and n.Status_name = 'StatusM'
								WHERE IdUred = @vidured
								and IDPorachkamain = @vIdPorachkaMain

						DELETE FROM #TMPMONUREDI 
							WHERE IDURED = @vidured 
							and IDPorachkamain = @vIdPorachkaMain

						SET @vidured = null
						SELECT TOP 1 @vidured= IdUred, @vbroi = Broi, @vIdPorachkaMain=IdPorachkaMain
							FROM #TMPMONUREDI
							WHERE IdPorachkaMain = @vIdPorachkaMain
							ORDER BY IdPorachkaMain, Idured
					END
				
					DELETE FROM #TMPMONPORYCHKI 
						WHERE IDPorachkamain = @vIdPorachkaMain

					SET @vIdPorachkaMain = null
					SELECT TOP 1 @vIdPorachkaMain=IdPorachkaMain
						FROM #TMPMONPORYCHKI
						ORDER BY IdPorachkaMain
				END

				SET @vcode = null
			END
			ELSE BEGIN
				SET @vtext2 = 'няма'
			END
		END
		ELSE
		IF @vcode = 'р77' BEGIN
			SELECT @vcnt = COUNT(*)
				FROM #tmp_formulaqr t 
					inner join lica_dogovor l 
						ON t.Id_L = l.Id_L
					inner join dem_porychka p
						ON p.IdDogovorLice = l.Id_dog_L

			IF ISNULL(@vcnt,0) > 0 BEGIN
				INSERT INTO #TMP_OPOS 
					VALUES (@vcode,@vtext,@vtext2, @visbold)	

				SELECT p.IdUred, p.Broi, p.IdPorachkaMain, p.StatusG, p.StatusM, p.DemData
					INTO #TMPDEMONUREDI
					FROM #tmp_formulaqr t 
						inner join lica_dogovor l 
							ON t.Id_L = l.Id_L
						inner join dem_porychka p
							ON p.IdDogovorLice = l.Id_dog_L

				SELECT TOP 1 @vidured= IdUred, @vbroi = Broi, @vIdPorachkaMain=IdPorachkaMain
					FROM #TMPDEMONUREDI

				WHILE @vidured is not null
				BEGIN
					--row 1					
					INSERT INTO #TMP_OPOS 
						SELECT @vcode
								, n.Text
								, convert(varchar,@vbroi)+' бр.'
								, 0
							FROM n_nmn_obshti n
							WHERE n.id_kn = @vidured AND n.kod_nmn = '06'

					--row 2					
					INSERT INTO #TMP_OPOS 
						SELECT @vcode
								, 'Поръчка № '+ convert(varchar,@vIdPorachkaMain) 
								, 'Статус: '+IIF(LEN(ISNULL(n.Text,''))=0,'няма',n.Text)
								, 0
							FROM dem_porychkamain p
								inner join n_statusi n
								on p.StatusDM = n.Status_Code and n.status_name = 'Status_DP'
							WHERE IDPorachkamain = @vIdPorachkaMain

					--row 3					
					INSERT INTO #TMP_OPOS 
						SELECT @vcode
								, f.Ime
								, d.Reg_Index
								, 0
							FROM dem_porychkamain p
								inner join dem_dogovor d
									on p.IdDogovorFirma = d.Id_firma_DM
								inner join firmi f
								on p.IdFirma = f.IdFirma
							WHERE IDPorachkamain = @vIdPorachkaMain

					--row 4					
					INSERT INTO #TMP_OPOS 
						SELECT @vcode
								, 'График'
								, 'Статус: '+IIF(LEN(ISNULL(n.Text,''))=0,'няма',n.Text)
								, 0
							FROM #TMPDEMONUREDI t
								left join n_statusi n
									ON t.StatusG = n.Status_Code and n.Status_name = 'StatusGD'
							WHERE IdUred = @vidured

					--row 5					
					INSERT INTO #TMP_OPOS 
						SELECT @vcode
								, 'Демонтаж, '+ISNULL('дата '+convert(varchar,t.DemData,104),'')
								, 'Статус: '+IIF(LEN(ISNULL(n.Text,''))=0,'няма',n.Text)
								,0
							FROM #TMPDEMONUREDI t
								left join n_statusi n
								ON t.StatusM = n.Status_Code and n.Status_name = 'StatusMD'
							WHERE IdUred = @vidured

					DELETE FROM #TMPDEMONUREDI 
						WHERE IDURED = @vidured

					SET @vidured = null
					SELECT TOP 1 @vidured= IdUred, @vbroi = Broi, @vIdPorachkaMain=IdPorachkaMain
						FROM #TMPDEMONUREDI
				END
				

				SET @vcode = null
			END
			ELSE BEGIN
				SET @vtext2 = 'няма'
			END
		END
		ELSE
		IF @vcode = 'р78' BEGIN
			IF EXISTS(SELECT 1 
						FROM #tmp_formulaqr t 
							inner join mon_profilaktika l 
								ON t.Id_L = l.IdL AND l.IdUred < 30)
			BEGIN
				INSERT INTO #TMP_OPOS 
					VALUES (@vcode,@vtext,@vtext2, 1)	

				INSERT INTO #TMP_OPOS 
					SELECT @vcode
							, u.nime
							, s.Text +ISNULL(' - '+convert(varchar,CASE WHEN l.Status_PF>1 THEN l.OtchetData ELSE l.Data END,104),'')
							, @visbold
						FROM #tmp_formulaqr t 
								inner join mon_profilaktika l 
									ON t.Id_L = l.IdL AND l.IdUred < 30
								inner join n_uredi u
									ON l.IdUred = u.Id
								inner join n_statusi s
									ON s.Status_Code = l.Status_PF and s.Status_name='Status_PF'
				SET @vcode = null
			END
			ELSE BEGIN
				SET @vtext2 = 'няма'
			END		
		END
		ELSE
		IF @vcode = 'р79' BEGIN
			IF EXISTS(SELECT 1 
						FROM #tmp_formulaqr t 
							inner join lica_dogovor d
								ON t.Id_L = d.Id_L 
							inner join mon_porychka l 
								ON d.Id_dog_L = l.IdDogovorLice AND l.IdUred < 30
						WHERE l.StatusM = 1)
			BEGIN				
				SELECT @tmpdate = MAX(DATEADD(month,d.SrokDogovor, l.MonData))
					FROM #tmp_formulaqr t 
								inner join lica_dogovor d
									ON t.Id_L = d.Id_L 
								inner join mon_porychka l 
									ON d.Id_dog_L = l.IdDogovorLice AND l.IdUred < 30
					WHERE l.StatusM = 1

				INSERT INTO #TMP_OPOS 
					SELECT @vcode
							, @vtext
							, convert(varchar,@tmpdate,104)
							, @visbold
						FROM #tmp_formulaqr t 
								inner join mon_profilaktika l 
								ON t.Id_L = l.IdL AND l.IdUred < 30
				SET @vcode = null
			END
			ELSE BEGIN
				SET @vtext2 = 'няма'
			END		
		END
		ELSE
		IF @vcode = 'р80' BEGIN
			IF EXISTS(SELECT 1 
						FROM #tmp_formulaqr t 
							inner join lica_dogovor d
								ON t.Id_L = d.Id_L 
							inner join mon_porychka l 
								ON d.Id_dog_L = l.IdDogovorLice AND l.IdUred < 30
						WHERE l.StatusM = 1)
			BEGIN				
				SELECT @tmpdate = MAX(DATEADD(month,d.SrokSobstvenost, l.MonData))
					FROM #tmp_formulaqr t 
								inner join lica_dogovor d
									ON t.Id_L = d.Id_L 
								inner join mon_porychka l 
									ON d.Id_dog_L = l.IdDogovorLice AND l.IdUred < 30
					WHERE l.StatusM = 1

				INSERT INTO #TMP_OPOS 
					SELECT @vcode
							, @vtext
							, convert(varchar,@tmpdate,104)
							, @visbold
						FROM #tmp_formulaqr t 
								inner join mon_profilaktika l 
								ON t.Id_L = l.IdL AND l.IdUred < 30
				SET @vcode = null
			END
			ELSE BEGIN
				SET @vtext2 = 'няма'
			END		
		END

		IF @vcode is not null BEGIN
			INSERT INTO #TMP_OPOS 
				VALUES (@vcode,@vtext,@vtext2,@visbold)	
		END

		SET @vcode = null
		SELECT TOP 1
				@vcode = code
				,@vtext = TEXT
				,@visbold = ISBOLD
			FROM #TMP_SHABLON

	END

	SELECT convert(varchar,ROW_NUMBER() OVER(ORDER BY t.code ASC)) as CODE, t.TEXT, t.TEXT2, t.isbold--,t.code
		FROM #TMP_OPOS t
END

GO
SET QUOTED_IDENTIFIER OFF 
GO
SET ANSI_NULLS ON 
GO
