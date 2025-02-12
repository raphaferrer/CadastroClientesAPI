CREATE PROCEDURE sp_AtualizarLogradouro
    @Id UNIQUEIDENTIFIER,
    @Endereco NVARCHAR(255)
AS
BEGIN
    SET NOCOUNT ON;

    IF NOT EXISTS (SELECT 1 FROM Logradouros WHERE Id = @Id)
    BEGIN
        RAISERROR ('Logradouro não encontrado.', 16, 1);
        RETURN;
    END

    UPDATE Logradouros
    SET Endereco = @Endereco
    WHERE Id = @Id;
END;
