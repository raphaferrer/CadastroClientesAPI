CREATE PROCEDURE sp_RemoverLogradouro
    @Id UNIQUEIDENTIFIER
AS
BEGIN
    SET NOCOUNT ON;

    IF NOT EXISTS (SELECT 1 FROM Logradouros WHERE Id = @Id)
    BEGIN
        RAISERROR ('Logradouro não encontrado.', 16, 1);
        RETURN;
    END

    DELETE FROM Logradouros WHERE Id = @Id;
END;
