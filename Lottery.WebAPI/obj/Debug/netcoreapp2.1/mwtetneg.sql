IF OBJECT_ID(N'[__EFMigrationsHistory]') IS NULL
BEGIN
    CREATE TABLE [__EFMigrationsHistory] (
        [MigrationId] nvarchar(150) NOT NULL,
        [ProductVersion] nvarchar(32) NOT NULL,
        CONSTRAINT [PK___EFMigrationsHistory] PRIMARY KEY ([MigrationId])
    );
END;

GO

CREATE TABLE [Lotteries] (
    [Id] int NOT NULL,
    [Number] nvarchar(450) NOT NULL,
    [DateOfConducting] datetime2 NOT NULL,
    CONSTRAINT [PK_Lotteries] PRIMARY KEY ([Id])
);

GO

CREATE TABLE [Tickets] (
    [Id] int NOT NULL,
    [Number] nvarchar(7) NOT NULL,
    [IsWinning] bit NOT NULL,
    [LotteryId] int NOT NULL,
    CONSTRAINT [PK_Tickets] PRIMARY KEY ([Id]),
    CONSTRAINT [FK_Tickets_Lotteries_LotteryId] FOREIGN KEY ([LotteryId]) REFERENCES [Lotteries] ([Id]) ON DELETE CASCADE
);

GO

IF EXISTS (SELECT * FROM [sys].[identity_columns] WHERE [name] IN (N'Id', N'DateOfConducting', N'Number') AND [object_id] = OBJECT_ID(N'[Lotteries]'))
    SET IDENTITY_INSERT [Lotteries] ON;
INSERT INTO [Lotteries] ([Id], [DateOfConducting], [Number])
VALUES (1, '2018-05-01T00:00:00.0000000', N'101');
IF EXISTS (SELECT * FROM [sys].[identity_columns] WHERE [name] IN (N'Id', N'DateOfConducting', N'Number') AND [object_id] = OBJECT_ID(N'[Lotteries]'))
    SET IDENTITY_INSERT [Lotteries] OFF;

GO

IF EXISTS (SELECT * FROM [sys].[identity_columns] WHERE [name] IN (N'Id', N'DateOfConducting', N'Number') AND [object_id] = OBJECT_ID(N'[Lotteries]'))
    SET IDENTITY_INSERT [Lotteries] ON;
INSERT INTO [Lotteries] ([Id], [DateOfConducting], [Number])
VALUES (2, '2018-05-10T00:00:00.0000000', N'102');
IF EXISTS (SELECT * FROM [sys].[identity_columns] WHERE [name] IN (N'Id', N'DateOfConducting', N'Number') AND [object_id] = OBJECT_ID(N'[Lotteries]'))
    SET IDENTITY_INSERT [Lotteries] OFF;

GO

IF EXISTS (SELECT * FROM [sys].[identity_columns] WHERE [name] IN (N'Id', N'DateOfConducting', N'Number') AND [object_id] = OBJECT_ID(N'[Lotteries]'))
    SET IDENTITY_INSERT [Lotteries] ON;
INSERT INTO [Lotteries] ([Id], [DateOfConducting], [Number])
VALUES (3, '2018-05-15T00:00:00.0000000', N'103');
IF EXISTS (SELECT * FROM [sys].[identity_columns] WHERE [name] IN (N'Id', N'DateOfConducting', N'Number') AND [object_id] = OBJECT_ID(N'[Lotteries]'))
    SET IDENTITY_INSERT [Lotteries] OFF;

GO

IF EXISTS (SELECT * FROM [sys].[identity_columns] WHERE [name] IN (N'Id', N'IsWinning', N'LotteryId', N'Number') AND [object_id] = OBJECT_ID(N'[Tickets]'))
    SET IDENTITY_INSERT [Tickets] ON;
INSERT INTO [Tickets] ([Id], [IsWinning], [LotteryId], [Number])
VALUES (1, 0, 1, N'AS7239G'),
(2, 0, 1, N'AL7249J'),
(3, 1, 1, N'BS7K3LP'),
(4, 0, 2, N'9L7Y69G'),
(5, 1, 2, N'AY7739U'),
(6, 0, 2, N'A8MN390'),
(7, 1, 3, N'Z888399'),
(8, 0, 3, N'Z677392'),
(9, 0, 3, N'3607391'),
(10, 0, 3, N'08J8K19');
IF EXISTS (SELECT * FROM [sys].[identity_columns] WHERE [name] IN (N'Id', N'IsWinning', N'LotteryId', N'Number') AND [object_id] = OBJECT_ID(N'[Tickets]'))
    SET IDENTITY_INSERT [Tickets] OFF;

GO

CREATE INDEX [INX_NUMBER] ON [Lotteries] ([Number]);

GO

CREATE INDEX [INX_NUMBER] ON [Tickets] ([Number]);

GO

CREATE UNIQUE INDEX [IX_Tickets_LotteryId_Number] ON [Tickets] ([LotteryId], [Number]);

GO

INSERT INTO [__EFMigrationsHistory] ([MigrationId], [ProductVersion])
VALUES (N'20180602185808_InitialDbSchema', N'2.1.0-rtm-30799');

GO

