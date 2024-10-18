CREATE FUNCTION dbo.fn_ValidarEmail(@Email Varchar(255))
RETURNS Char(1)
AS
BEGIN
    DECLARE @Resultado Char(1) = 'N';

    -- Verifica se o e-mail contém um "@" e um "." após o "@"
    IF @Email LIKE '%_@__%.__%'
        SET @resultado = 'S'; -- E-mail válido

    RETURN @resultado;
END;