CREATE PROCEDURE sp_RemoverCliente
    @Email NVARCHAR(255)
AS
BEGIN
    SET NOCOUNT ON;

    DELETE FROM Clientes
    WHERE Email = @Email;

    IF @@ROWCOUNT > 0
        RETURN 1; 
    ELSE
        RETURN 0; 
END;
