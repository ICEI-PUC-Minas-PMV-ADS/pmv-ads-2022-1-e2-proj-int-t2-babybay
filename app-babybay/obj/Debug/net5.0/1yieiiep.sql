IF OBJECT_ID(N'[__EFMigrationsHistory]') IS NULL
BEGIN
    CREATE TABLE [__EFMigrationsHistory] (
        [MigrationId] nvarchar(150) NOT NULL,
        [ProductVersion] nvarchar(32) NOT NULL,
        CONSTRAINT [PK___EFMigrationsHistory] PRIMARY KEY ([MigrationId])
    );
END;
GO

BEGIN TRANSACTION;
GO

CREATE TABLE [Produtos] (
    [Id] int NOT NULL IDENTITY,
    [Nome] nvarchar(max) NOT NULL,
    [Cor] nvarchar(max) NOT NULL,
    [Idade] int NOT NULL,
    [TempoUso] int NOT NULL,
    [Descricao] nvarchar(120) NOT NULL,
    [Tamanho] int NOT NULL,
    [Categoria] int NOT NULL,
    CONSTRAINT [PK_Produtos] PRIMARY KEY ([Id])
);
GO

INSERT INTO [__EFMigrationsHistory] ([MigrationId], [ProductVersion])
VALUES (N'20220426001031_V01', N'5.0.16');
GO

COMMIT;
GO

BEGIN TRANSACTION;
GO

CREATE TABLE [GuardaRoupas] (
    [Id] int NOT NULL IDENTITY,
    [QtdProduto] int NOT NULL,
    [ProdutoId] int NOT NULL,
    CONSTRAINT [PK_GuardaRoupas] PRIMARY KEY ([Id]),
    CONSTRAINT [FK_GuardaRoupas_Produtos_ProdutoId] FOREIGN KEY ([ProdutoId]) REFERENCES [Produtos] ([Id]) ON DELETE CASCADE
);
GO

CREATE INDEX [IX_GuardaRoupas_ProdutoId] ON [GuardaRoupas] ([ProdutoId]);
GO

INSERT INTO [__EFMigrationsHistory] ([MigrationId], [ProductVersion])
VALUES (N'20220426214942_V02', N'5.0.16');
GO

COMMIT;
GO

BEGIN TRANSACTION;
GO

DROP TABLE [GuardaRoupas];
GO

CREATE TABLE [Usuarios] (
    [Id] int NOT NULL IDENTITY,
    [Nome] nvarchar(max) NOT NULL,
    [DataNascimento] datetime2 NOT NULL,
    [Cpf] nvarchar(11) NOT NULL,
    [Telefone] nvarchar(max) NOT NULL,
    [Rua] nvarchar(max) NOT NULL,
    [Bairro] nvarchar(max) NOT NULL,
    [Cidade] nvarchar(max) NOT NULL,
    [Estado] int NOT NULL,
    [Email] nvarchar(max) NOT NULL,
    [Senha] nvarchar(max) NOT NULL,
    [ConfirmarSenha] nvarchar(max) NOT NULL,
    CONSTRAINT [PK_Usuarios] PRIMARY KEY ([Id])
);
GO

CREATE TABLE [Carteira] (
    [Id] int NOT NULL IDENTITY,
    [UsuarioId] int NOT NULL,
    [Saldo] int NOT NULL,
    CONSTRAINT [PK_Carteira] PRIMARY KEY ([Id]),
    CONSTRAINT [FK_Carteira_Usuarios_UsuarioId] FOREIGN KEY ([UsuarioId]) REFERENCES [Usuarios] ([Id]) ON DELETE CASCADE
);
GO

CREATE INDEX [IX_Carteira_UsuarioId] ON [Carteira] ([UsuarioId]);
GO

INSERT INTO [__EFMigrationsHistory] ([MigrationId], [ProductVersion])
VALUES (N'20220502215603_V03', N'5.0.16');
GO

COMMIT;
GO

BEGIN TRANSACTION;
GO

ALTER TABLE [Carteira] DROP CONSTRAINT [FK_Carteira_Usuarios_UsuarioId];
GO

ALTER TABLE [Carteira] DROP CONSTRAINT [PK_Carteira];
GO

EXEC sp_rename N'[Carteira]', N'Carteiras';
GO

EXEC sp_rename N'[Carteiras].[IX_Carteira_UsuarioId]', N'IX_Carteiras_UsuarioId', N'INDEX';
GO

ALTER TABLE [Carteiras] ADD CONSTRAINT [PK_Carteiras] PRIMARY KEY ([Id]);
GO

ALTER TABLE [Carteiras] ADD CONSTRAINT [FK_Carteiras_Usuarios_UsuarioId] FOREIGN KEY ([UsuarioId]) REFERENCES [Usuarios] ([Id]) ON DELETE CASCADE;
GO

INSERT INTO [__EFMigrationsHistory] ([MigrationId], [ProductVersion])
VALUES (N'20220511020808_V04', N'5.0.16');
GO

COMMIT;
GO

BEGIN TRANSACTION;
GO

ALTER TABLE [Produtos] ADD [UsuarioId] int NOT NULL DEFAULT 0;
GO

CREATE INDEX [IX_Produtos_UsuarioId] ON [Produtos] ([UsuarioId]);
GO

ALTER TABLE [Produtos] ADD CONSTRAINT [FK_Produtos_Usuarios_UsuarioId] FOREIGN KEY ([UsuarioId]) REFERENCES [Usuarios] ([Id]) ON DELETE CASCADE;
GO

INSERT INTO [__EFMigrationsHistory] ([MigrationId], [ProductVersion])
VALUES (N'20220511231551_V05', N'5.0.16');
GO

COMMIT;
GO

BEGIN TRANSACTION;
GO

CREATE TABLE [Trocas] (
    [Id] int NOT NULL,
    [ProdutoId] int NOT NULL,
    [UsuarioId] int NOT NULL,
    [Date] datetime2 NOT NULL,
    CONSTRAINT [PK_Trocas] PRIMARY KEY ([Id]),
    CONSTRAINT [FK_Trocas_Usuarios_Id] FOREIGN KEY ([Id]) REFERENCES [Usuarios] ([Id]) ON DELETE NO ACTION,
    CONSTRAINT [FK_Trocas_Produtos_ProdutoId] FOREIGN KEY ([ProdutoId]) REFERENCES [Produtos] ([Id]) ON DELETE CASCADE
);
GO

CREATE INDEX [IX_Trocas_ProdutoId] ON [Trocas] ([ProdutoId]);
GO

CREATE INDEX [IX_Trocas_UsuarioId] ON [Trocas] ([UsuarioId]);
GO

INSERT INTO [__EFMigrationsHistory] ([MigrationId], [ProductVersion])
VALUES (N'20220513005231_V06', N'5.0.16');
GO

COMMIT;
GO

