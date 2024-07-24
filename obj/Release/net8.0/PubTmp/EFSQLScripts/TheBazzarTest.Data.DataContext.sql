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

IF NOT EXISTS (
    SELECT * FROM [__EFMigrationsHistory]
    WHERE [MigrationId] = N'20240723125254_Initial'
)
BEGIN
    CREATE TABLE [Games] (
        [Id] int NOT NULL IDENTITY,
        [Username] nvarchar(max) NOT NULL,
        [Email] nvarchar(max) NOT NULL,
        [CurrentLevel] int NOT NULL,
        [ExperiencePoints] int NOT NULL,
        [ExperiencePointsToNextLevel] int NOT NULL,
        [TotalGamesPlayed] int NOT NULL,
        [TotalWins] int NOT NULL,
        [TotalLosses] int NOT NULL,
        [FriendsCount] int NOT NULL,
        [MessagesSent] int NOT NULL,
        [MessagesReceived] int NOT NULL,
        CONSTRAINT [PK_Games] PRIMARY KEY ([Id])
    );
END;
GO

IF NOT EXISTS (
    SELECT * FROM [__EFMigrationsHistory]
    WHERE [MigrationId] = N'20240723125254_Initial'
)
BEGIN
    INSERT INTO [__EFMigrationsHistory] ([MigrationId], [ProductVersion])
    VALUES (N'20240723125254_Initial', N'8.0.7');
END;
GO

COMMIT;
GO

