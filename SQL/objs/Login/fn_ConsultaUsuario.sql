CREATE OR ALTER FUNCTION dbo.fn_ConsultaUsuario(@E_Mail Varchar(100)
                                      ,@Senha  Varchar(50))
RETURNS Bit
AS
BEGIN
  DECLARE @SN_Valido Bit = 1;

  SELECT @SN_Valido = dbo.fn_ValidarSenha(@Senha);

  IF (@SN_Valido = 0)
    RETURN @SN_Valido;

  SET @SN_Valido = dbo.fn_ValidarEmail(@E_Mail)

  IF (@SN_Valido = 0)
    RETURN @SN_Valido;

  IF EXISTS (SELECT 1
             FROM dbo.Emails 
             WHERE E_Mail = @E_Mail
               AND Senha  = @senha)
  BEGIN
    SET @SN_Valido = 1;
  END

  RETURN @SN_Valido;
END

--SELECT dbo.fn_ConsultaUsuario('sysadmin@sysadmin.com','Admin123')

select * from Emails