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

CREATE TABLE [ContactoUsuarios] (
    [id] int NOT NULL IDENTITY,
    [id_Usuario] int NOT NULL,
    [direccion1] nvarchar(max) NULL,
    [direccion2] nvarchar(max) NULL,
    [ciudad] nvarchar(max) NULL,
    [codigo_postal] nvarchar(max) NULL,
    [telefono] nvarchar(max) NULL,
    CONSTRAINT [PK_ContactoUsuarios] PRIMARY KEY ([id])
);
GO

CREATE TABLE [Locales] (
    [id] int NOT NULL IDENTITY,
    [direccion] nvarchar(max) NULL,
    [nombre_Sede] int NOT NULL,
    CONSTRAINT [PK_Locales] PRIMARY KEY ([id])
);
GO

CREATE TABLE [Telas] (
    [id] int NOT NULL IDENTITY,
    [material] nvarchar(max) NULL,
    CONSTRAINT [PK_Telas] PRIMARY KEY ([id])
);
GO

CREATE TABLE [TipoDocs] (
    [id] int NOT NULL IDENTITY,
    [descrip] nvarchar(max) NULL,
    CONSTRAINT [PK_TipoDocs] PRIMARY KEY ([id])
);
GO

CREATE TABLE [TipoPrendas] (
    [id] int NOT NULL IDENTITY,
    [desc] nvarchar(max) NULL,
    CONSTRAINT [PK_TipoPrendas] PRIMARY KEY ([id])
);
GO

CREATE TABLE [Usuarios] (
    [id] int NOT NULL IDENTITY,
    [nombre_Usuario] nvarchar(max) NULL,
    [email] nvarchar(max) NULL,
    [idtipo_Doc] int NOT NULL,
    [created_at] datetime2 NOT NULL,
    [TipoDocid] int NULL,
    CONSTRAINT [PK_Usuarios] PRIMARY KEY ([id]),
    CONSTRAINT [FK_Usuarios_TipoDocs_TipoDocid] FOREIGN KEY ([TipoDocid]) REFERENCES [TipoDocs] ([id]) ON DELETE NO ACTION
);
GO

CREATE TABLE [Prendas] (
    [id] int NOT NULL IDENTITY,
    [id_Tela] int NOT NULL,
    [id_tipoPrenda] int NOT NULL,
    [Telaid] int NULL,
    [TipoPrendaid] int NULL,
    CONSTRAINT [PK_Prendas] PRIMARY KEY ([id]),
    CONSTRAINT [FK_Prendas_Telas_Telaid] FOREIGN KEY ([Telaid]) REFERENCES [Telas] ([id]) ON DELETE NO ACTION,
    CONSTRAINT [FK_Prendas_TipoPrendas_TipoPrendaid] FOREIGN KEY ([TipoPrendaid]) REFERENCES [TipoPrendas] ([id]) ON DELETE NO ACTION
);
GO

CREATE TABLE [Clientes] (
    [id] int NOT NULL IDENTITY,
    [id_Usuario] int NOT NULL,
    [nombre_Usuario] nvarchar(max) NULL,
    [dni] nvarchar(max) NULL,
    [nombres] nvarchar(max) NULL,
    [apellidos] nvarchar(max) NULL,
    [email] nvarchar(max) NULL,
    [Usuarioid] int NULL,
    CONSTRAINT [PK_Clientes] PRIMARY KEY ([id]),
    CONSTRAINT [FK_Clientes_Usuarios_Usuarioid] FOREIGN KEY ([Usuarioid]) REFERENCES [Usuarios] ([id]) ON DELETE NO ACTION
);
GO

CREATE TABLE [Empresas] (
    [id] int NOT NULL IDENTITY,
    [id_Usuario] int NOT NULL,
    [id_Local] int NOT NULL,
    [nombre] nvarchar(max) NULL,
    [email] nvarchar(max) NULL,
    [ruc] nvarchar(max) NULL,
    [Usuarioid] int NULL,
    [Localid] int NULL,
    CONSTRAINT [PK_Empresas] PRIMARY KEY ([id]),
    CONSTRAINT [FK_Empresas_Locales_Localid] FOREIGN KEY ([Localid]) REFERENCES [Locales] ([id]) ON DELETE NO ACTION,
    CONSTRAINT [FK_Empresas_Usuarios_Usuarioid] FOREIGN KEY ([Usuarioid]) REFERENCES [Usuarios] ([id]) ON DELETE NO ACTION
);
GO

CREATE TABLE [DetallePedidos] (
    [id] int NOT NULL IDENTITY,
    [id_Pedido] int NOT NULL,
    [id_Prenda] int NOT NULL,
    [cantidad] int NOT NULL,
    [precio] real NOT NULL,
    [created_at] datetime2 NOT NULL,
    [modified_at] datetime2 NOT NULL,
    [Prendaid] int NULL,
    CONSTRAINT [PK_DetallePedidos] PRIMARY KEY ([id]),
    CONSTRAINT [FK_DetallePedidos_Prendas_Prendaid] FOREIGN KEY ([Prendaid]) REFERENCES [Prendas] ([id]) ON DELETE NO ACTION
);
GO

CREATE TABLE [Medidas] (
    [id] int NOT NULL IDENTITY,
    [id_Cliente] int NOT NULL,
    [datos] nvarchar(max) NULL,
    [Clienteid] int NULL,
    CONSTRAINT [PK_Medidas] PRIMARY KEY ([id]),
    CONSTRAINT [FK_Medidas_Clientes_Clienteid] FOREIGN KEY ([Clienteid]) REFERENCES [Clientes] ([id]) ON DELETE NO ACTION
);
GO

CREATE TABLE [Pedidos] (
    [id] int NOT NULL IDENTITY,
    [id_Cliente] int NOT NULL,
    [id_Empresa] int NOT NULL,
    [id_Local] int NOT NULL,
    [id_Medidas] int NOT NULL,
    [fecha_Entrega] datetime2 NOT NULL,
    [created_at] datetime2 NOT NULL,
    [Clienteid] int NULL,
    [Empresaid] int NULL,
    [Localid] int NULL,
    [Medidasid] int NULL,
    CONSTRAINT [PK_Pedidos] PRIMARY KEY ([id]),
    CONSTRAINT [FK_Pedidos_Clientes_Clienteid] FOREIGN KEY ([Clienteid]) REFERENCES [Clientes] ([id]) ON DELETE NO ACTION,
    CONSTRAINT [FK_Pedidos_Empresas_Empresaid] FOREIGN KEY ([Empresaid]) REFERENCES [Empresas] ([id]) ON DELETE NO ACTION,
    CONSTRAINT [FK_Pedidos_Locales_Localid] FOREIGN KEY ([Localid]) REFERENCES [Locales] ([id]) ON DELETE NO ACTION,
    CONSTRAINT [FK_Pedidos_Medidas_Medidasid] FOREIGN KEY ([Medidasid]) REFERENCES [Medidas] ([id]) ON DELETE NO ACTION
);
GO

CREATE INDEX [IX_Clientes_Usuarioid] ON [Clientes] ([Usuarioid]);
GO

CREATE INDEX [IX_DetallePedidos_Prendaid] ON [DetallePedidos] ([Prendaid]);
GO

CREATE INDEX [IX_Empresas_Localid] ON [Empresas] ([Localid]);
GO

CREATE INDEX [IX_Empresas_Usuarioid] ON [Empresas] ([Usuarioid]);
GO

CREATE INDEX [IX_Medidas_Clienteid] ON [Medidas] ([Clienteid]);
GO

CREATE INDEX [IX_Pedidos_Clienteid] ON [Pedidos] ([Clienteid]);
GO

CREATE INDEX [IX_Pedidos_Empresaid] ON [Pedidos] ([Empresaid]);
GO

CREATE INDEX [IX_Pedidos_Localid] ON [Pedidos] ([Localid]);
GO

CREATE INDEX [IX_Pedidos_Medidasid] ON [Pedidos] ([Medidasid]);
GO

CREATE INDEX [IX_Prendas_Telaid] ON [Prendas] ([Telaid]);
GO

CREATE INDEX [IX_Prendas_TipoPrendaid] ON [Prendas] ([TipoPrendaid]);
GO

CREATE INDEX [IX_Usuarios_TipoDocid] ON [Usuarios] ([TipoDocid]);
GO

INSERT INTO [__EFMigrationsHistory] ([MigrationId], [ProductVersion])
VALUES (N'20210906193342_Inicial', N'5.0.9');
GO

COMMIT;
GO

