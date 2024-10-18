CREATE FUNCTION dbo.fn_ValidarEmail(@Email Varchar(255))
RETURNS Char(1)
AS
BEGIN
    DECLARE @Resultado Char(1) = 'N';

    -- Verifica se o e-mail cont�m um "@" e um "." ap�s o "@"
    IF @Email LIKE '%_@__%.__%'
        SET @resultado = 'S'; -- E-mail v�lido

    RETURN @resultado;
END;