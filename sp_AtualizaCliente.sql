CREATE PROCEDURE sp_AtualizarCliente
    @Nome NVARCHAR(255),
    @Email NVARCHAR(255),
    @Logotipo VARBINARY(MAX) 
AS
BEGIN
    SET NOCOUNT ON;

    UPDATE Clientes
    SET 
        Nome = @Nome,
        Email = @Email,
        Logotipo = @Logotipo
    WHERE Email = @Email;
    
    IF @@ROWCOUNT > 0
        RETURN 1; 
    ELSE
        RETURN 0;
END;
