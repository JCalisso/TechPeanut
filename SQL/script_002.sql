

IF NOT EXISTS (SELECT 1 FROM dbo.Privilegio WHERE CD_Privilegio = 'SYSADM')
BEGIN
  INSERT INTO dbo.Privilegio (CD_Privilegio
                             ,NM_Privilegio
                             ,SN_Ativo) 
  VALUES('SYSADM'
        ,'System Admin'
        ,1)
END
GO


IF NOT EXISTS (SELECT 1 FROM dbo.Funcao WHERE CD_Funcao = 'ADM')
BEGIN
  INSERT INTO dbo.Funcao (CD_Funcao
                         ,NM_Funcao
                         ,SN_Ativo) 
  VALUES('ADM'
        ,'System Admin'
        ,1)
END
GO

IF NOT EXISTS (SELECT 1 
               FROM dbo.FuncaoPrivilegio 
                    INNER JOIN dbo.Privilegio
                    ON Privilegio.ID = FuncaoPrivilegio.ID_Privilegio
                    INNER JOIN dbo.Funcao 
                    ON Funcao.ID = FuncaoPrivilegio.ID_Funcao
               WHERE CD_Funcao = 'SYSADM')
BEGIN
  DECLARE @ID_Privilegio Integer
         ,@ID_Funcao     Integer;

  SELECT TOP 1
       @ID_Privilegio = ID
  FROM dbo.Privilegio 
  WHERE CD_Privilegio = 'SYSADM'

  SELECT TOP 1
       @ID_Funcao = ID
  FROM dbo.Funcao 
  WHERE CD_Funcao = 'ADM'

  INSERT INTO dbo.FuncaoPrivilegio (ID_Privilegio
                                   ,ID_Funcao) 
  VALUES(@ID_Privilegio
        ,@ID_Funcao)
END
GO

IF NOT EXISTS (SELECT 1 FROM dbo.Cargos WHERE CD_Cargo = 'SYSADM')
BEGIN
  INSERT INTO dbo.Cargos (CD_Cargo
                         ,NM_Cargo
                         ,SN_Ativo)
  VALUES ('SYSADM'
         ,'SYSADMIN'
         ,1)
END


IF NOT EXISTS (SELECT 1
               FROM dbo.Pessoas 
               WHERE NM_Pessoa = 'SYSADMIN')
BEGIN
  INSERT INTO dbo.Pessoas (NM_Pessoa
                          ,ST_Tipo_Pessoa
                          ,CD_Documento_Pessoa
                          ,DT_Nascimento
                          ,ST_Genero)
  VALUES ('SYSADMIN'
         ,'J'
         ,'00000000000000'
         ,CAST(GETDATE() AS Date)
         ,'M')
END
GO

IF EXISTS (SELECT 1 FROM dbo.Pessoas WHERE NM_Pessoa = 'SYSADMIN')
BEGIN
  DECLARE @ID_Pessoa Integer
         ,@ID_Funcao Integer
         ,@ID_Cargo  Integer

  SELECT @ID_Funcao = ID
  FROM dbo.Funcao 
  WHERE Funcao.CD_Funcao = 'ADM'

  SELECT @ID_Cargo = ID
  FROM dbo.Cargos
  WHERE CD_Cargo = 'SYSADM'

  SELECT @ID_Pessoa = ID
  FROM dbo.Pessoas 
  WHERE NM_Pessoa = 'SYSADMIN'

  UPDATE Pessoas
  SET ID_Funcao = @ID_Funcao
     ,ID_Cargo  = @ID_Cargo
  WHERE ID = @ID_Pessoa
END
GO

IF EXISTS (SELECT 1 FROM dbo.Pessoas WHERE NM_Pessoa = 'SYSADMIN')
BEGIN
  DECLARE @ID_Pessoa Integer

  SELECT @ID_Pessoa = ID
  FROM dbo.Pessoas 
  WHERE NM_Pessoa = 'SYSADMIN'

  IF (ISNULL(@ID_Pessoa, 0) <> 0) AND 
     (NOT EXISTS (SELECT 1
                  FROM dbo.Emails 
                  WHERE ID_Pessoa = @ID_Pessoa))
  BEGIN
    INSERT INTO dbo.Emails (E_Mail
                           ,SN_Email_Principal
                           ,ID_Pessoa
                           ,Senha)
    VALUES ('sysadmin@sysadmin.com'
           ,'S'
           ,@ID_Pessoa
           ,'Admin123')
  END
END

IF NOT EXISTS (SELECT 1 FROM dbo.Telefones)
BEGIN
  INSERT INTO dbo.Telefones (Telefone
                            ,ST_Tipo_Telefone
                            ,SN_Principal
                            ,ID_Pessoa)
  VALUES ('14999999999', 'C', 'S',1)
END