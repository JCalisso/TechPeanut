IF DB_ID('TechPeanut_dev') IS NULL
BEGIN
  CREATE DATABASE TechPeanut_dev
END
GO

USE TechPeanut_dev
GO


IF NOT EXISTS (SELECT 1 FROM sys.tables WHERE name = 'Privilegio')
BEGIN
  CREATE TABLE dbo.Privilegio (ID             Integer Primary Key Identity(1,1)
                              ,CD_Privilegio Char(6)     COLLATE LATIN1_GENERAL_CI_AS NOT NULL
                              ,NM_Privilegio Varchar(80) COLLATE LATIN1_GENERAL_CI_AS NOT NULL
                              ,SN_Ativo      Bit         DEFAULT 0 NOT NULL)
END
GO


IF NOT EXISTS (SELECT 1 FROM sys.tables WHERE name = 'Funcao')
BEGIN
  CREATE TABLE dbo.Funcao (ID        Integer Primary Key Identity(1,1)
                          ,CD_Funcao Char(3)     COLLATE LATIN1_GENERAL_CI_AS NOT NULL
                          ,NM_Funcao Varchar(80) COLLATE LATIN1_GENERAL_CI_AS NOT NULL
                          ,SN_Ativo  Bit         DEFAULT 0) 
END
GO

IF NOT EXISTS (SELECT 1 FROM sys.tables WHERE name = 'FuncaoPrivilegio')
BEGIN
  CREATE TABLE dbo.FuncaoPrivilegio (ID                   Integer Primary Key Identity(1,1)
                                    ,ID_Privilegio        Integer   NOT NULL
                                    ,ID_Funcao            Integer   NOT NULL
                                    ,CONSTRAINT FK_ID_Privilegio FOREIGN KEY (ID_Privilegio) REFERENCES dbo.Privilegio (ID)
                                    ,CONSTRAINT FK_ID_Funcao FOREIGN KEY (ID_Funcao) REFERENCES dbo.Funcao (ID)) 
END
GO


IF NOT EXISTS (SELECT 1 FROM sys.tables WHERE name = 'Banco')
BEGIN
  CREATE TABLE dbo.Banco (ID       Integer Primary Key Identity(1,1)
                         ,CD_Banco Char(6)     COLLATE LATIN1_GENERAL_CI_AS
                         ,NM_Banco Varchar(60) COLLATE LATIN1_GENERAL_CI_AS)
END
GO


IF NOT EXISTS (SELECT 1 FROM sys.tables WHERE name = 'Cargos')
BEGIN
  CREATE TABLE dbo.Cargos (ID       Integer Primary Key Identity(1,1)
                          ,CD_Cargo Char(6)     COLLATE LATIN1_GENERAL_CI_AS
                          ,NM_Cargo Varchar(80) COLLATE LATIN1_GENERAL_CI_AS
                          ,SN_Ativo Bit  DEFAULT 0)
END
GO

IF NOT EXISTS (SELECT 1 FROM sys.tables WHERE name = 'DadosBancarios')
BEGIN
  CREATE TABLE dbo.DadosBancarios (ID                 Integer Primary Key Identity(1,1)
                                  ,ID_Banco           Integer
                                  ,ST_Tipo_Conta      Char(2)     COLLATE LATIN1_GENERAL_CI_AS
                                  ,CD_Conta           Varchar(20) COLLATE LATIN1_GENERAL_CI_AS
                                  ,CD_Agencia         Varchar(6)  COLLATE LATIN1_GENERAL_CI_AS
                                  ,CONSTRAINT FK_ID_Banco FOREIGN KEY (ID_Banco) REFERENCES dbo.DadosBancarios (ID))
                                    
END
GO

IF NOT EXISTS (SELECT 1 FROM sys.tables WHERE name = 'DadosPessoaJuridica')
BEGIN
  CREATE TABLE dbo.DadosPessoaJuridica (ID                Integer 
                                       ,CD_CNPJ           Varchar(14) COLLATE LATIN1_GENERAL_CI_AS
                                       ,CD_Documento      Varchar(20) COLLATE LATIN1_GENERAL_CI_AS
                                       ,ST_Tipo_Documento Char(1)     COLLATE LATIN1_GENERAL_CI_AS
                                       ,DT_Fundacao       Datetime)
END
GO


IF NOT EXISTS (SELECT 1 FROM sys.tables WHERE name = 'DadosPessoasFisica')
BEGIN
  CREATE TABLE dbo.DadosPessoasFisica (ID                Integer
                                      ,CD_CPF            Varchar(11) COLLATE LATIN1_GENERAL_CI_AS
                                      ,CD_Documento      Varchar(20) COLLATE LATIN1_GENERAL_CI_AS
                                      ,ST_Tipo_Documento Char(1)     COLLATE LATIN1_GENERAL_CI_AS
                                      ,ST_Estado_Civil   Char(1)     COLLATE LATIN1_GENERAL_CI_AS 
                                      ,DT_Nascimento     Datetime
                                      ,ST_Genero         Char(1)     COLLATE LATIN1_GENERAL_CI_AS)
END
GO


IF NOT EXISTS (SELECT 1 FROM sys.tables WHERE name = 'Endereco')
BEGIN
  CREATE TABLE dbo.Endereco (ID          Integer Primary Key Identity(1,1)
                            ,Endereco		 Varchar (100) COLLATE LATIN1_GENERAL_CI_AS NOT NULL 
                            ,Bairro	  	 Varchar (60)  COLLATE LATIN1_GENERAL_CI_AS NOT NULL
                            ,NO_Endereco Varchar (10)  COLLATE LATIN1_GENERAL_CI_AS NOT NULL
                            ,Observacao	 Varchar (255) COLLATE LATIN1_GENERAL_CI_AS
                            ,CEP			   Varchar (8)   COLLATE LATIN1_GENERAL_CI_AS NOT NULL)
END
GO


IF NOT EXISTS (SELECT 1 FROM sys.tables WHERE name = 'Cidades')
BEGIN
  CREATE TABLE dbo.Cidades (ID         Integer Primary Key Identity(1,1)
                           ,ID_UF      Char(2)       COLLATE LATIN1_GENERAL_CI_AS NOT NULL
                           ,NM_Cidades Varchar (100) COLLATE LATIN1_GENERAL_CI_AS NOT NULL)
END 
GO

IF NOT EXISTS (SELECT 1 FROM sys.tables WHERE name = 'Telefones')
BEGIN
  CREATE TABLE dbo.Telefones (ID               Integer Primary Key Identity(1,1)
                             ,Telefone         Varchar(100) COLLATE LATIN1_GENERAL_CI_AS NOT NULL
                             ,ST_Tipo_Telefone Char(2)      COLLATE LATIN1_GENERAL_CI_AS NOT NULL
                             ,ID_Cidade        Integer                                   NOT NULL
                             ,ID_Pessoa        Integer                                   NOT NULL
                             ,CONSTRAINT FK_ID_Cidade FOREIGN KEY (ID_Cidade) REFERENCES dbo.Cidades (ID))
END 
GO


IF NOT EXISTS (SELECT 1 FROM sys.tables WHERE name = 'Pessoas')
BEGIN
  CREATE TABLE dbo.Pessoas (ID                    Integer Primary Key Identity(1,1)
                           ,NM_Pessoa             Varchar(80)  COLLATE LATIN1_GENERAL_CI_AS NOT NULL
                           ,ST_Tipo_Pessoa        Char(1)      COLLATE LATIN1_GENERAL_CI_AS NOT NULL
                           ,CD_Documento_Pessoa   Varchar(14)  COLLATE LATIN1_GENERAL_CI_AS NOT NULL
                           ,DT_Nascimento         Datetime                                  NOT NULL
                           ,ST_Genero             Char(1)      COLLATE LATIN1_GENERAL_CI_AS NOT NULL
                           ,ID_Telefone_Principal Integer 
                           ,ID_Endereco           Integer
                           ,ID_Funcao             Integer  
                           ,ID_Cargo              Integer
                           ,ID_Dados_Bancarios    Integer)
END
GO


IF NOT EXISTS (SELECT 1 FROM sys.tables WHERE name = 'Emails')
BEGIN
  CREATE TABLE dbo.Emails (ID                 Integer Primary Key Identity(1,1)
                          ,E_Mail             Varchar(100) COLLATE LATIN1_GENERAL_CI_AS NOT NULL
                          ,SN_Email_Principal Char(1)      COLLATE LATIN1_GENERAL_CI_AS NOT NULL
                          ,ID_Pessoa          Integer
                          ,Senha              Varchar(50)  COLLATE LATIN1_GENERAL_CI_AS NOT NULL
                          ,CONSTRAINT FK_ID_Pessoa FOREIGN KEY (ID_Pessoa) REFERENCES dbo.Pessoas (ID))
END 
GO

