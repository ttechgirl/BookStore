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

CREATE TABLE [Books] (
    [Id] uniqueidentifier NOT NULL,
    [Title] nvarchar(max) NULL,
    [Author] nvarchar(max) NULL,
    [Price] float NOT NULL,
    [CoverImageUrl] nvarchar(max) NULL,
    [IsFeatured] bit NOT NULL,
    [Category] nvarchar(max) NULL,
    [CreatedOn] datetime2 NOT NULL,
    [ModifiedOn] datetime2 NULL,
    CONSTRAINT [PK_Books] PRIMARY KEY ([Id])
);
GO

CREATE TABLE [Message] (
    [Id] uniqueidentifier NOT NULL,
    [FullName] nvarchar(max) NULL,
    [Email] nvarchar(max) NULL,
    [PhoneNumber] nvarchar(max) NULL,
    [BookTitle] nvarchar(max) NULL,
    [Message] nvarchar(max) NULL,
    [CreatedOn] datetime2 NOT NULL,
    CONSTRAINT [PK_Message] PRIMARY KEY ([Id])
);
GO

IF EXISTS (SELECT * FROM [sys].[identity_columns] WHERE [name] IN (N'Id', N'Author', N'Category', N'CoverImageUrl', N'CreatedOn', N'IsFeatured', N'ModifiedOn', N'Price', N'Title') AND [object_id] = OBJECT_ID(N'[Books]'))
    SET IDENTITY_INSERT [Books] ON;
INSERT INTO [Books] ([Id], [Author], [Category], [CoverImageUrl], [CreatedOn], [IsFeatured], [ModifiedOn], [Price], [Title])
VALUES ('a24a6355-8f92-4857-9b69-211319dbcb1e', N'Author 4', N'Fiction', N'/images/bookcover1.jpg', '2024-11-07T22:47:46.1187168+01:00', CAST(1 AS bit), '2024-11-07T22:47:46.1187169+01:00', 5.0E0, N'Book 4'),
('a885076f-6d95-4b5a-841f-3afdbd082702', N'Author 2', N'Fiction', N'/images/poster-template-new-scientists.jpg', '2024-11-07T22:47:46.1187156+01:00', CAST(1 AS bit), '2024-11-07T22:47:46.1187157+01:00', 200.0E0, N'Book 2'),
('b12a2281-9db1-4d3d-9dc4-de3881ffdf15', N'Author 5', N'Fiction', N'/images/online-education-poster-template.jpg', '2024-11-07T22:47:46.1187192+01:00', CAST(1 AS bit), '2024-11-07T22:47:46.1187192+01:00', 1409.0E0, N'Book 5'),
('bde62685-6c17-43d1-bcf1-1af39b2d58fc', N'Author 3', N'Tragedy', N'/images/pumpkin-drink-poster.jpg', '2024-11-07T22:47:46.1187163+01:00', CAST(1 AS bit), '2024-11-07T22:47:46.1187163+01:00', 14.0E0, N'Book 3'),
('eb6cbf99-ea1f-40dc-bb4a-80bbc595d234', N'Author 1', N'Drama', N'/images/good-paper-wattpad-book.jpg', '2024-11-07T22:47:46.1187108+01:00', CAST(1 AS bit), '2024-11-07T22:47:46.1187127+01:00', 100.98999999999999E0, N'Book 1'),
('ee95a674-0c4d-4d3b-b676-4e6e25c03732', N'Author 6', N'Fiction', N'/images/bookcover1.jpg', '2024-11-07T22:47:46.1187197+01:00', CAST(1 AS bit), '2024-11-07T22:47:46.1187198+01:00', 5.0E0, N'Book 6');
IF EXISTS (SELECT * FROM [sys].[identity_columns] WHERE [name] IN (N'Id', N'Author', N'Category', N'CoverImageUrl', N'CreatedOn', N'IsFeatured', N'ModifiedOn', N'Price', N'Title') AND [object_id] = OBJECT_ID(N'[Books]'))
    SET IDENTITY_INSERT [Books] OFF;
GO

INSERT INTO [__EFMigrationsHistory] ([MigrationId], [ProductVersion])
VALUES (N'20241107214747_Initial', N'8.0.10');
GO

COMMIT;
GO

