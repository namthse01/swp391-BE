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

CREATE TABLE [Categories] (
    [Id] uniqueidentifier NOT NULL,
    [Name] nvarchar(255) NULL,
    [CreatedBy] nvarchar(256) NULL,
    [Created] datetime2 NOT NULL,
    [LastModifiedBy] nvarchar(256) NULL,
    [LastModified] datetime2 NULL,
    [IsDeleted] bit NOT NULL,
    CONSTRAINT [PK_Categories] PRIMARY KEY ([Id])
);
GO

CREATE TABLE [Roles] (
    [Id] uniqueidentifier NOT NULL,
    [Name] nvarchar(max) NULL,
    [CreatedBy] nvarchar(256) NULL,
    [Created] datetime2 NOT NULL,
    [LastModifiedBy] nvarchar(256) NULL,
    [LastModified] datetime2 NULL,
    [IsDeleted] bit NOT NULL,
    CONSTRAINT [PK_Roles] PRIMARY KEY ([Id])
);
GO

CREATE TABLE [Users] (
    [Id] uniqueidentifier NOT NULL,
    [Username] nvarchar(255) NULL,
    [Password] nvarchar(255) NULL,
    [Email] nvarchar(150) NULL,
    [Phone] nvarchar(20) NULL,
    [CreatedBy] nvarchar(256) NULL,
    [Created] datetime2 NOT NULL,
    [LastModifiedBy] nvarchar(256) NULL,
    [LastModified] datetime2 NULL,
    [IsDeleted] bit NOT NULL,
    CONSTRAINT [PK_Users] PRIMARY KEY ([Id])
);
GO

CREATE TABLE [Managers] (
    [Id] uniqueidentifier NOT NULL,
    [UserId] uniqueidentifier NOT NULL,
    [RoleId] uniqueidentifier NOT NULL,
    [CreatedBy] nvarchar(256) NULL,
    [Created] datetime2 NOT NULL,
    [LastModifiedBy] nvarchar(256) NULL,
    [LastModified] datetime2 NULL,
    [IsDeleted] bit NOT NULL,
    CONSTRAINT [PK_Managers] PRIMARY KEY ([Id]),
    CONSTRAINT [FK_Managers_Roles_RoleId] FOREIGN KEY ([RoleId]) REFERENCES [Roles] ([Id]) ON DELETE CASCADE,
    CONSTRAINT [FK_Managers_Users_UserId] FOREIGN KEY ([UserId]) REFERENCES [Users] ([Id]) ON DELETE CASCADE
);
GO

CREATE TABLE [Players] (
    [Id] uniqueidentifier NOT NULL,
    [UserId] uniqueidentifier NOT NULL,
    [CreatedBy] nvarchar(256) NULL,
    [Created] datetime2 NOT NULL,
    [LastModifiedBy] nvarchar(256) NULL,
    [LastModified] datetime2 NULL,
    [IsDeleted] bit NOT NULL,
    CONSTRAINT [PK_Players] PRIMARY KEY ([Id]),
    CONSTRAINT [FK_Players_Users_UserId] FOREIGN KEY ([UserId]) REFERENCES [Users] ([Id]) ON DELETE CASCADE
);
GO

CREATE TABLE [Fields] (
    [Id] uniqueidentifier NOT NULL,
    [Name] nvarchar(max) NULL,
    [Description] nvarchar(max) NULL,
    [Address] nvarchar(max) NULL,
    [CategoryId] uniqueidentifier NOT NULL,
    [ManagerId] uniqueidentifier NOT NULL,
    [CreatedBy] nvarchar(256) NULL,
    [Created] datetime2 NOT NULL,
    [LastModifiedBy] nvarchar(256) NULL,
    [LastModified] datetime2 NULL,
    [IsDeleted] bit NOT NULL,
    CONSTRAINT [PK_Fields] PRIMARY KEY ([Id]),
    CONSTRAINT [FK_Fields_Categories_CategoryId] FOREIGN KEY ([CategoryId]) REFERENCES [Categories] ([Id]) ON DELETE CASCADE,
    CONSTRAINT [FK_Fields_Managers_ManagerId] FOREIGN KEY ([ManagerId]) REFERENCES [Managers] ([Id]) ON DELETE CASCADE
);
GO

CREATE TABLE [Services] (
    [Id] uniqueidentifier NOT NULL,
    [Name] nvarchar(max) NULL,
    [Price] decimal(18,6) NOT NULL,
    [ManagerId] uniqueidentifier NOT NULL,
    [CreatedBy] nvarchar(256) NULL,
    [Created] datetime2 NOT NULL,
    [LastModifiedBy] nvarchar(256) NULL,
    [LastModified] datetime2 NULL,
    [IsDeleted] bit NOT NULL,
    CONSTRAINT [PK_Services] PRIMARY KEY ([Id]),
    CONSTRAINT [FK_Services_Managers_ManagerId] FOREIGN KEY ([ManagerId]) REFERENCES [Managers] ([Id]) ON DELETE CASCADE
);
GO

CREATE TABLE [Transactions] (
    [Id] uniqueidentifier NOT NULL,
    [Name] nvarchar(max) NULL,
    [Slot] int NOT NULL,
    [Date] datetime2 NOT NULL,
    [PlayerId] uniqueidentifier NOT NULL,
    [FieldId] uniqueidentifier NOT NULL,
    [CreatedBy] nvarchar(256) NULL,
    [Created] datetime2 NOT NULL,
    [LastModifiedBy] nvarchar(256) NULL,
    [LastModified] datetime2 NULL,
    [IsDeleted] bit NOT NULL,
    CONSTRAINT [PK_Transactions] PRIMARY KEY ([Id]),
    CONSTRAINT [FK_Transactions_Fields_FieldId] FOREIGN KEY ([FieldId]) REFERENCES [Fields] ([Id]) ON DELETE CASCADE,
    CONSTRAINT [FK_Transactions_Players_PlayerId] FOREIGN KEY ([PlayerId]) REFERENCES [Players] ([Id])
);
GO

CREATE TABLE [ServiceFields] (
    [Id] uniqueidentifier NOT NULL,
    [ServiceId] uniqueidentifier NOT NULL,
    [FieldId] uniqueidentifier NOT NULL,
    [CreatedBy] nvarchar(256) NULL,
    [Created] datetime2 NOT NULL,
    [LastModifiedBy] nvarchar(256) NULL,
    [LastModified] datetime2 NULL,
    [IsDeleted] bit NOT NULL,
    CONSTRAINT [PK_ServiceFields] PRIMARY KEY ([Id]),
    CONSTRAINT [FK_ServiceFields_Fields_FieldId] FOREIGN KEY ([FieldId]) REFERENCES [Fields] ([Id]),
    CONSTRAINT [FK_ServiceFields_Services_ServiceId] FOREIGN KEY ([ServiceId]) REFERENCES [Services] ([Id])
);
GO

CREATE TABLE [Orders] (
    [Id] uniqueidentifier NOT NULL,
    [Name] nvarchar(max) NULL,
    [TotalPrice] decimal(18,6) NOT NULL,
    [TransactionId] uniqueidentifier NOT NULL,
    [CreatedBy] nvarchar(256) NULL,
    [Created] datetime2 NOT NULL,
    [LastModifiedBy] nvarchar(256) NULL,
    [LastModified] datetime2 NULL,
    [IsDeleted] bit NOT NULL,
    CONSTRAINT [PK_Orders] PRIMARY KEY ([Id]),
    CONSTRAINT [FK_Orders_Transactions_TransactionId] FOREIGN KEY ([TransactionId]) REFERENCES [Transactions] ([Id]) ON DELETE CASCADE
);
GO

CREATE TABLE [TransactionServices] (
    [Id] uniqueidentifier NOT NULL,
    [ServiceId] uniqueidentifier NOT NULL,
    [TransactionId] uniqueidentifier NOT NULL,
    [CreatedBy] nvarchar(256) NULL,
    [Created] datetime2 NOT NULL,
    [LastModifiedBy] nvarchar(256) NULL,
    [LastModified] datetime2 NULL,
    [IsDeleted] bit NOT NULL,
    CONSTRAINT [PK_TransactionServices] PRIMARY KEY ([Id]),
    CONSTRAINT [FK_TransactionServices_Services_ServiceId] FOREIGN KEY ([ServiceId]) REFERENCES [Services] ([Id]),
    CONSTRAINT [FK_TransactionServices_Transactions_TransactionId] FOREIGN KEY ([TransactionId]) REFERENCES [Transactions] ([Id])
);
GO

CREATE INDEX [IX_Fields_CategoryId] ON [Fields] ([CategoryId]);
GO

CREATE INDEX [IX_Fields_ManagerId] ON [Fields] ([ManagerId]);
GO

CREATE INDEX [IX_Managers_RoleId] ON [Managers] ([RoleId]);
GO

CREATE INDEX [IX_Managers_UserId] ON [Managers] ([UserId]);
GO

CREATE UNIQUE INDEX [IX_Orders_TransactionId] ON [Orders] ([TransactionId]);
GO

CREATE INDEX [IX_Players_UserId] ON [Players] ([UserId]);
GO

CREATE INDEX [IX_ServiceFields_FieldId] ON [ServiceFields] ([FieldId]);
GO

CREATE INDEX [IX_ServiceFields_ServiceId] ON [ServiceFields] ([ServiceId]);
GO

CREATE INDEX [IX_Services_ManagerId] ON [Services] ([ManagerId]);
GO

CREATE INDEX [IX_Transactions_FieldId] ON [Transactions] ([FieldId]);
GO

CREATE INDEX [IX_Transactions_PlayerId] ON [Transactions] ([PlayerId]);
GO

CREATE INDEX [IX_TransactionServices_ServiceId] ON [TransactionServices] ([ServiceId]);
GO

CREATE INDEX [IX_TransactionServices_TransactionId] ON [TransactionServices] ([TransactionId]);
GO

INSERT INTO [__EFMigrationsHistory] ([MigrationId], [ProductVersion])
VALUES (N'20230222141933_InitalizeDB', N'6.0.9');
GO

COMMIT;
GO

BEGIN TRANSACTION;
GO

DECLARE @var0 sysname;
SELECT @var0 = [d].[name]
FROM [sys].[default_constraints] [d]
INNER JOIN [sys].[columns] [c] ON [d].[parent_column_id] = [c].[column_id] AND [d].[parent_object_id] = [c].[object_id]
WHERE ([d].[parent_object_id] = OBJECT_ID(N'[Users]') AND [c].[name] = N'Email');
IF @var0 IS NOT NULL EXEC(N'ALTER TABLE [Users] DROP CONSTRAINT [' + @var0 + '];');
ALTER TABLE [Users] ALTER COLUMN [Email] nvarchar(255) NULL;
GO

DECLARE @var1 sysname;
SELECT @var1 = [d].[name]
FROM [sys].[default_constraints] [d]
INNER JOIN [sys].[columns] [c] ON [d].[parent_column_id] = [c].[column_id] AND [d].[parent_object_id] = [c].[object_id]
WHERE ([d].[parent_object_id] = OBJECT_ID(N'[Transactions]') AND [c].[name] = N'Name');
IF @var1 IS NOT NULL EXEC(N'ALTER TABLE [Transactions] DROP CONSTRAINT [' + @var1 + '];');
ALTER TABLE [Transactions] ALTER COLUMN [Name] nvarchar(255) NULL;
GO

DECLARE @var2 sysname;
SELECT @var2 = [d].[name]
FROM [sys].[default_constraints] [d]
INNER JOIN [sys].[columns] [c] ON [d].[parent_column_id] = [c].[column_id] AND [d].[parent_object_id] = [c].[object_id]
WHERE ([d].[parent_object_id] = OBJECT_ID(N'[Services]') AND [c].[name] = N'Name');
IF @var2 IS NOT NULL EXEC(N'ALTER TABLE [Services] DROP CONSTRAINT [' + @var2 + '];');
ALTER TABLE [Services] ALTER COLUMN [Name] nvarchar(255) NULL;
GO

DECLARE @var3 sysname;
SELECT @var3 = [d].[name]
FROM [sys].[default_constraints] [d]
INNER JOIN [sys].[columns] [c] ON [d].[parent_column_id] = [c].[column_id] AND [d].[parent_object_id] = [c].[object_id]
WHERE ([d].[parent_object_id] = OBJECT_ID(N'[Roles]') AND [c].[name] = N'Name');
IF @var3 IS NOT NULL EXEC(N'ALTER TABLE [Roles] DROP CONSTRAINT [' + @var3 + '];');
ALTER TABLE [Roles] ALTER COLUMN [Name] nvarchar(255) NULL;
GO

DECLARE @var4 sysname;
SELECT @var4 = [d].[name]
FROM [sys].[default_constraints] [d]
INNER JOIN [sys].[columns] [c] ON [d].[parent_column_id] = [c].[column_id] AND [d].[parent_object_id] = [c].[object_id]
WHERE ([d].[parent_object_id] = OBJECT_ID(N'[Orders]') AND [c].[name] = N'Name');
IF @var4 IS NOT NULL EXEC(N'ALTER TABLE [Orders] DROP CONSTRAINT [' + @var4 + '];');
ALTER TABLE [Orders] ALTER COLUMN [Name] nvarchar(255) NULL;
GO

DECLARE @var5 sysname;
SELECT @var5 = [d].[name]
FROM [sys].[default_constraints] [d]
INNER JOIN [sys].[columns] [c] ON [d].[parent_column_id] = [c].[column_id] AND [d].[parent_object_id] = [c].[object_id]
WHERE ([d].[parent_object_id] = OBJECT_ID(N'[Fields]') AND [c].[name] = N'Name');
IF @var5 IS NOT NULL EXEC(N'ALTER TABLE [Fields] DROP CONSTRAINT [' + @var5 + '];');
ALTER TABLE [Fields] ALTER COLUMN [Name] nvarchar(255) NULL;
GO

DECLARE @var6 sysname;
SELECT @var6 = [d].[name]
FROM [sys].[default_constraints] [d]
INNER JOIN [sys].[columns] [c] ON [d].[parent_column_id] = [c].[column_id] AND [d].[parent_object_id] = [c].[object_id]
WHERE ([d].[parent_object_id] = OBJECT_ID(N'[Fields]') AND [c].[name] = N'Description');
IF @var6 IS NOT NULL EXEC(N'ALTER TABLE [Fields] DROP CONSTRAINT [' + @var6 + '];');
ALTER TABLE [Fields] ALTER COLUMN [Description] nvarchar(2000) NULL;
GO

DECLARE @var7 sysname;
SELECT @var7 = [d].[name]
FROM [sys].[default_constraints] [d]
INNER JOIN [sys].[columns] [c] ON [d].[parent_column_id] = [c].[column_id] AND [d].[parent_object_id] = [c].[object_id]
WHERE ([d].[parent_object_id] = OBJECT_ID(N'[Fields]') AND [c].[name] = N'Address');
IF @var7 IS NOT NULL EXEC(N'ALTER TABLE [Fields] DROP CONSTRAINT [' + @var7 + '];');
ALTER TABLE [Fields] ALTER COLUMN [Address] nvarchar(255) NULL;
GO

INSERT INTO [__EFMigrationsHistory] ([MigrationId], [ProductVersion])
VALUES (N'20230222142522_SetMaxLength', N'6.0.9');
GO

COMMIT;
GO

BEGIN TRANSACTION;
GO

ALTER TABLE [Fields] DROP CONSTRAINT [FK_Fields_Managers_ManagerId];
GO

DECLARE @var8 sysname;
SELECT @var8 = [d].[name]
FROM [sys].[default_constraints] [d]
INNER JOIN [sys].[columns] [c] ON [d].[parent_column_id] = [c].[column_id] AND [d].[parent_object_id] = [c].[object_id]
WHERE ([d].[parent_object_id] = OBJECT_ID(N'[Fields]') AND [c].[name] = N'ManagerId');
IF @var8 IS NOT NULL EXEC(N'ALTER TABLE [Fields] DROP CONSTRAINT [' + @var8 + '];');
ALTER TABLE [Fields] ALTER COLUMN [ManagerId] uniqueidentifier NULL;
GO

ALTER TABLE [Fields] ADD CONSTRAINT [FK_Fields_Managers_ManagerId] FOREIGN KEY ([ManagerId]) REFERENCES [Managers] ([Id]);
GO

INSERT INTO [__EFMigrationsHistory] ([MigrationId], [ProductVersion])
VALUES (N'20230222145529_EnableNullableManager', N'6.0.9');
GO

COMMIT;
GO

