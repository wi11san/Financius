USE FinanciusDB;
GO

CREATE OR ALTER PROCEDURE dbo.sp_BuscaUsuarios
AS
BEGIN
    SELECT IdUsuario, Nome, Email, SenhaHash 
    FROM dbo.Usuarios;
END;
GO


CREATE OR ALTER PROCEDURE dbo.sp_BuscaUsuarioPorId
    @Id INT
AS
BEGIN
    SELECT IdUsuario, Nome, Email, SenhaHash 
    FROM dbo.Usuarios 
    WHERE IdUsuario = @Id;
END;
GO


CREATE OR ALTER PROCEDURE dbo.sp_CriaUsuario
    @Nome NVARCHAR(100),
    @Email NVARCHAR(100),
    @SenhaHash NVARCHAR(200)
AS
BEGIN
    INSERT INTO dbo.Usuarios (Nome, Email, SenhaHash)
    VALUES (@Nome, @Email, @SenhaHash);

    SELECT SCOPE_IDENTITY()
END;
GO


CREATE OR ALTER PROCEDURE dbo.sp_AtualizaUsuario
    @IdUsuario INT,
    @Nome NVARCHAR(100),
    @Email NVARCHAR(100),
    @SenhaHash NVARCHAR(200)
AS
BEGIN
    UPDATE dbo.Usuarios
    SET Nome = @Nome, Email = @Email, SenhaHash = @SenhaHash
    WHERE IdUsuario = @IdUsuario;

    SELECT @@ROWCOUNT;
END;
GO


CREATE OR ALTER PROCEDURE dbo.sp_DeleteUsuario
    @Id INT
AS
BEGIN
    DELETE FROM dbo.Usuarios 
    WHERE IdUsuario = @Id;

    SELECT @@ROWCOUNT;
END;
GO
