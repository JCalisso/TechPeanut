

IF NOT EXISTS (SELECT 1 FROM dbo.Cidades WHERE ID_UF = 'SP')
BEGIN 
  -- Inser��o das cidades de S�o Paulo
  INSERT INTO Cidades (NM_Cidades, ID_UF) VALUES
  ('Adamantina'                 , 'SP'),
  ('Adolfo'                     , 'SP'),
  ('Agudos'                     , 'SP'),
  ('Alambari'                   , 'SP'),
  ('Alfredo Marcondes'          , 'SP'),
  ('Altair'                     , 'SP'),
  ('Alum�nio'                   , 'SP'),
  ('Americana'                  , 'SP'),
  ('Am�rico Brasiliense'        , 'SP'),
  ('Andradina'                  , 'SP'),
  ('Angatuba'                   , 'SP'),
  ('Anhembi'                    , 'SP'),
  ('Aparecida'                  , 'SP'),
  ('Ara�ariguama'               , 'SP'),
  ('Ara�atuba'                  , 'SP'),
  ('Araraquara'                 , 'SP'),
  ('Araras'                     , 'SP'),
  ('Arco-�ris'                  , 'SP'),
  ('Aruj�'                      , 'SP'),
  ('Barra Bonita'               , 'SP'),
  ('Barretos'                   , 'SP'),
  ('Barrinha'                   , 'SP'),
  ('Bastos'                     , 'SP'),
  ('Bauru'                      , 'SP'),
  ('Bebedouro'                  , 'SP'),
  ('Bento de Abreu'             , 'SP'),
  ('Bernardino de Campos'       , 'SP'),
  ('Bertioga'                   , 'SP'),
  ('Bilac'                      , 'SP'),
  ('Birigui'                    , 'SP'),
  ('Boituva'                    , 'SP'),
  ('Bom Jesus dos Perd�es'      , 'SP'),
  ('Borac�ia'                   , 'SP'),
  ('Bor�'                       , 'SP'),
  ('Botucatu'                   , 'SP'),
  ('Bragan�a Paulista'          , 'SP'),
  ('Brail�ndia Paulista'        , 'SP'),
  ('Campinas'                   , 'SP'),
  ('Campo Limpo Paulista'       , 'SP'),
  ('Campo Grande'               , 'SP'),
  ('Canan�ia'                   , 'SP'),
  ('Cap�o Bonito'               , 'SP'),
  ('Capela do Alto'             , 'SP'),
  ('Caraguatatuba'              , 'SP'),
  ('Carapicu�ba'                , 'SP'),
  ('Cardoso Pimentel'           , 'SP'),
  ('Casa Branca'                , 'SP'),
  ('Casimiro de Abreu'          , 'SP'),
  ('Catal�o'                    , 'SP'),
  ('Catanduva'                  , 'SP'),
  ('Cotia'                      , 'SP'),
  ('Cravinhos'                  , 'SP'),
  ('Cristais Paulista'          , 'SP'),
  ('Cubat�o'                    , 'SP'),
  ('Cunha'                      , 'SP'),
  ('Descalvado'                 , 'SP'),
  ('Diadema'                    , 'SP'),
  ('Divinol�ndia'               , 'SP'),
  ('Dolcin�polis'               , 'SP'),
  ('Dourado'                    , 'SP'),
  ('Dracena'                    , 'SP'),
  ('Echapor�'                   , 'SP'),
  ('Eldorado'                   , 'SP'),
  ('Elias Fausto'               , 'SP'),
  ('Embu das Artes'             , 'SP'),
  ('Embu-Gua�u'                 , 'SP'),
  ('Em�lia'                     , 'SP'),
  ('Engenheiro Coelho'          , 'SP'),
  ('Esmeralda'                  , 'SP'),
  ('Estiva Gerbi'               , 'SP'),
  ('Fernand�polis'              , 'SP'),
  ('Fern�o'                     , 'SP'),
  ('Ferraz de Vasconcelos'      , 'SP'),
  ('Floreal'                    , 'SP'),
  ('Fl�rida Paulista'           , 'SP'),
  ('Francisco Morato'           , 'SP'),
  ('Franca'                     , 'SP'),
  ('Francisco Alves'            , 'SP'),
  ('Gabriel Monteiro'           , 'SP'),
  ('G�lia'                      , 'SP'),
  ('Gar�a'                      , 'SP'),
  ('Gavi�o Peixoto'             , 'SP'),
  ('General Salgado'            , 'SP'),
  ('Getulina'                   , 'SP'),
  ('Glic�rio'                   , 'SP'),
  ('Guaraci'                    , 'SP'),
  ('Guara�a�'                   , 'SP'),
  ('Guaruj�'                    , 'SP'),
  ('Guarulhos'                  , 'SP'),
  ('Iacanga'                    , 'SP'),
  ('Ibi�na'                     , 'SP'),
  ('Ic�m'                       , 'SP'),
  ('Igarat�'                    , 'SP'),
  ('Igarapava'                  , 'SP'),
  ('Iguape'                     , 'SP'),
  ('Ilhabela'                   , 'SP'),
  ('Indaiatuba'                 , 'SP'),
  ('Ipau�u'                     , 'SP'),
  ('Iper�'                      , 'SP'),
  ('Ipe�na'                     , 'SP'),
  ('Ipu�'                       , 'SP'),
  ('Iracem�polis'               , 'SP'),
  ('Irapu�'                     , 'SP'),
  ('Irara'                      , 'SP'),
  ('Itatiba'                    , 'SP'),
  ('It�polis'                   , 'SP'),
  ('Itapevi'                    , 'SP'),
  ('Itapecerica da Serra'       , 'SP'),
  ('Itapetininga'               , 'SP'),
  ('Itapeva'                    , 'SP'),
  ('Itatiaia'                   , 'SP'),
  ('Itirapina'                  , 'SP'),
  ('Itu'                        , 'SP'),
  ('Jaboticabal'                , 'SP'),
  ('Jacare�'                    , 'SP'),
  ('Jaguari�na'                 , 'SP'),
  ('Jales'                      , 'SP'),
  ('Jandira'                    , 'SP'),
  ('Jarinu'                     , 'SP'),
  ('Ja�'                        , 'SP'),
  ('Joan�polis'                 , 'SP'),
  ('Jundia�'                    , 'SP'),
  ('Juqui�'                     , 'SP'),
  ('Juventude'                  , 'SP'),
  ('Lagoinha'                   , 'SP'),
  ('Laranjal Paulista'          , 'SP'),
  ('Lavrinhas'                  , 'SP'),
  ('Limeira'                    , 'SP'),
  ('Lind�ia'                    , 'SP'),
  ('Lourdes'                    , 'SP'),
  ('Luc�lia'                    , 'SP'),
  ('Lu�s Antonio'               , 'SP'),
  ('Macaubal'                   , 'SP'),
  ('Mau�'                       , 'SP'),
  ('Mendon�a'                   , 'SP'),
  ('Meridiano'                  , 'SP'),
  ('Mes�polis'                  , 'SP'),
  ('Mogi das Cruzes'            , 'SP'),
  ('Mogi Mirim'                 , 'SP'),
  ('Mombuca'                    , 'SP'),
  ('Monte Alto'                 , 'SP'),
  ('Monte Mor'                  , 'SP'),
  ('Monte Verde'                , 'SP'),
  ('Morro Agudo'                , 'SP'),
  ('Morro do Chap�u'            , 'SP'),
  ('Natividade da Serra'        , 'SP'),
  ('Nazareth'                   , 'SP'),
  ('Neves Paulista'             , 'SP'),
  ('Nhandeara'                  , 'SP'),
  ('Nipo�'                      , 'SP'),
  ('Nogueira'                   , 'SP'),
  ('Ol�mpia'                    , 'SP'),
  ('Osasco'                     , 'SP'),
  ('Ourinhos'                   , 'SP'),
  ('Pacaembu'                   , 'SP'),
  ('Palestina'                  , 'SP'),
  ('Palmeira d�Oeste'           , 'SP'),
  ('Pardinho'                   , 'SP'),
  ('Pariquera-A�u'              , 'SP'),
  ('Parna�ba'                   , 'SP'),
  ('Parque Tr�s Marias'         , 'SP'),
  ('Paul�nia'                   , 'SP'),
  ('Pedro de Toledo'            , 'SP'),
  ('Pereira Barreto'            , 'SP'),
  ('Piedade'                    , 'SP'),
  ('Pilar do Sul'               , 'SP'),
  ('Piracaia'                   , 'SP'),
  ('Piracicaba'                 , 'SP'),
  ('Pirassununga'               , 'SP'),
  ('Planalto'                   , 'SP'),
  ('Pontal'                     , 'SP'),
  ('Porteira Preta'             , 'SP'),
  ('Porto Ferreira'             , 'SP'),
  ('Potim'                      , 'SP'),
  ('Prat�nia'                   , 'SP'),
  ('Presidente Epit�cio'        , 'SP'),
  ('Presidente Prudente'        , 'SP'),
  ('Quat�'                      , 'SP'),
  ('Queiroz'                    , 'SP'),
  ('Rafard'                     , 'SP'),
  ('Rancharia'                  , 'SP'),
  ('Regente Feij�'              , 'SP'),
  ('Registro'                   , 'SP'),
  ('Ribeir�o Bonito'            , 'SP'),
  ('Ribeir�o Preto'             , 'SP'),
  ('Rinc�o'                     , 'SP'),
  ('Rio Claro'                  , 'SP'),
  ('Rio das Pedras'             , 'SP'),
  ('Rio Grande da Serra'        , 'SP'),
  ('Riversul'                   , 'SP'),
  ('Rochedo'                    , 'SP'),
  ('Rodolfo Fernandes'          , 'SP'),
  ('Rubiataba'                  , 'SP'),
  ('Salto'                      , 'SP'),
  ('Salto de Pirapora'          , 'SP'),
  ('Salto Grande'               , 'SP'),
  ('Santa Ad�lia'               , 'SP'),
  ('Santa B�rbara d�Oeste'      , 'SP'),
  ('Santa Branca'               , 'SP'),
  ('Santa Clara d�Oeste'        , 'SP'),
  ('Santa Cruz das Palmeiras'   , 'SP'),
  ('Santa F� do Sul'            , 'SP'),
  ('Santa Rita do Passa Quatro' , 'SP'),
  ('Santa Rosa de Viterbo'      , 'SP'),
  ('Santo Andr�'                , 'SP'),
  ('Santo Ant�nio do Jardim'    , 'SP'),
  ('Santo Ant�nio do Pinhal'    , 'SP'),
  ('Santos'                     , 'SP'),
  ('S�o Bento do Sapuca�'       , 'SP'),
  ('S�o Bernardo do Campo'      , 'SP'),
  ('S�o Caetano do Sul'         , 'SP'),
  ('S�o Carlos'                 , 'SP'),
  ('S�o Jo�o da Boa Vista'      , 'SP'),
  ('S�o Jo�o de Iracema'        , 'SP'),
  ('S�o Jos� do Barreiro'       , 'SP'),
  ('S�o Jos� do Rio Pardo'      , 'SP'),
  ('S�o Jos� dos Campos'        , 'SP'),
  ('S�o Manuel'                 , 'SP'),
  ('S�o Miguel Paulista'        , 'SP'),
  ('S�o Paulo'                  , 'SP'),
  ('S�o Pedro'                  , 'SP'),
  ('S�o Sebasti�o'              , 'SP'),
  ('S�o Sim�o'                  , 'SP'),
  ('Sorocaba'                   , 'SP'),
  ('Tatu�'                      , 'SP'),
  ('Taubat�'                    , 'SP'),
  ('Teodoro Sampaio'            , 'SP'),
  ('Templo de Salom�o'          , 'SP'),
  ('Torrinha'                   , 'SP'),
  ('Trememb�'                   , 'SP'),
  ('Tubar�o'                    , 'SP'),
  ('Valinhos'                   , 'SP'),
  ('Valpara�so'                 , 'SP'),
  ('Vargem Grande Paulista'     , 'SP'),
  ('V�rzea Paulista'            , 'SP'),
  ('Venceslau Br�s'             , 'SP'),
  ('Votorantim'                 , 'SP'),
  ('Votuporanga'                , 'SP');
END
