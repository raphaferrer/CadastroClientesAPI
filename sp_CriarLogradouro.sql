CREATE PROCEDURE sp_CriarLogradouro
    @ClienteEmail NVARCHAR(100),
    @Endereco NVARCHAR(255),
    @Id UNIQUEIDENTIFIER OUTPUT
AS
BEGIN
    SET NOCOUNT ON;

    IF NOT EXISTS (SELECT 1 FROM Clientes WHERE Email = @ClienteEmail)
    BEGIN
        RAISERROR ('Cliente não encontrado.', 16, 1);
        RETURN;
    END

    SET @Id = NEWID();

    INSERT INTO Logradouros (Id, ClienteEmail, Endereco)
    VALUES (@Id, @ClienteEmail, @Endereco);
END;
