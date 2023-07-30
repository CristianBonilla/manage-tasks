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

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20230730061903_InitialCreate')
BEGIN
    CREATE TABLE [dbo].[Task] (
        [TaskId] uniqueidentifier NOT NULL DEFAULT (NEWID()),
        [TaskAction] nvarchar(50) NOT NULL,
        [Status] int NOT NULL,
        [Created] datetimeoffset NOT NULL,
        CONSTRAINT [PK_Task] PRIMARY KEY ([TaskId])
    );
END;
GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20230730061903_InitialCreate')
BEGIN
    IF EXISTS (SELECT * FROM [sys].[identity_columns] WHERE [name] IN (N'TaskId', N'Created', N'Status', N'TaskAction') AND [object_id] = OBJECT_ID(N'[dbo].[Task]'))
        SET IDENTITY_INSERT [dbo].[Task] ON;
    EXEC(N'INSERT INTO [dbo].[Task] ([TaskId], [Created], [Status], [TaskAction])
    VALUES (''24e01e15-3f23-49e0-b177-0b325ec2af9c'', ''2023-07-17T19:27:50.0000000+03:00'', 0, N''Meditar en la noche''),
    (''49cf31ba-32dc-4ded-817c-f9b5c71c968c'', ''2023-07-28T11:00:00.0000000+03:00'', 1, N''Pasear a mi Pit Bull''),
    (''5d84ed88-8078-4825-b740-02bd71d5346a'', ''2023-05-11T15:30:00.0000000+03:00'', 0, N''Tocar la guitarra''),
    (''a9741f3a-baea-4211-90de-f2fa53c9caa2'', ''2023-06-08T10:42:10.0000000+03:00'', 0, N''Practicar la calistenia''),
    (''ef839c0b-0e57-4bbe-be29-be1c501e82bb'', ''2023-07-01T12:00:44.0000000+03:00'', 1, N''Leer "Menos miedos más Riquezas"'')');
    IF EXISTS (SELECT * FROM [sys].[identity_columns] WHERE [name] IN (N'TaskId', N'Created', N'Status', N'TaskAction') AND [object_id] = OBJECT_ID(N'[dbo].[Task]'))
        SET IDENTITY_INSERT [dbo].[Task] OFF;
END;
GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20230730061903_InitialCreate')
BEGIN
    INSERT INTO [__EFMigrationsHistory] ([MigrationId], [ProductVersion])
    VALUES (N'20230730061903_InitialCreate', N'7.0.9');
END;
GO

COMMIT;
GO
