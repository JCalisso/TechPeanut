CREATE FUNCTION dbo.fn_ValidarSenha(@Senha Varchar(100))
RETURNS Char(1)
AS
BEGIN
    DECLARE @SN_Possui_Maiuscula Char(1) = 'N'
           ,@SN_Possui_Minuscula Char(1) = 'N'
           ,@SN_Possui_Numero    Char(1) = 'N'
           ,@SN_Valido           Char(1) = 'N';


    IF LEN(@senha) >= 8
    BEGIN
        -- Verifica se possui letra maiúscula
        IF @senha COLLATE Latin1_General_BIN LIKE '%[A-Z]%' 
            SET @SN_Possui_Maiuscula = 'S';

        -- Verifica se possui letra minúscula
        IF @senha COLLATE Latin1_General_BIN LIKE '%[a-z]%' 
            SET @SN_Possui_Minuscula = 'S';

        -- Verifica se possui número
        IF @senha COLLATE Latin1_General_BIN LIKE '%[0-9]%' 
            SET @SN_Possui_Numero = 'S';
    END

    IF (@SN_Possui_Maiuscula = 'S' AND @SN_Possui_Minuscula = 'S' AND @SN_Possui_Numero = 'S')
        SET @SN_Valido = 'S'; -- Senha válida

    RETURN @SN_Valido
END;