CREATE PROCEDURE sp_CriarCliente
    @Id UNIQUEIDENTIFIER,
    @Nome NVARCHAR(100),
    @Email NVARCHAR(100),
    @Logotipo VARBINARY(MAX) NULL
AS
BEGIN
    SET NOCOUNT ON;

    IF EXISTS (SELECT 1 FROM Clientes WHERE Email = @Email)
    BEGIN
        RAISERROR ('O e-mail informado já está cadastrado.', 16, 1);
        RETURN;
    END

    INSERT INTO Clientes (Id, Nome, Email, Logotipo)
    VALUES (@Id, @Nome, @Email, @Logotipo);
END;
