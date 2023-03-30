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

CREATE TABLE [Interviewers] (
    [Id] int NOT NULL IDENTITY,
    [FirstName] nvarchar(50) NOT NULL,
    [LastName] nvarchar(50) NOT NULL,
    [Email] nvarchar(2048) NOT NULL,
    [EmployeeIdentityId] uniqueidentifier NOT NULL,
    CONSTRAINT [PK_Interviewers] PRIMARY KEY ([Id])
);
GO

CREATE TABLE [InterviewTypeLookUps] (
    [Id] int NOT NULL IDENTITY,
    [InterviewTypeCode] nvarchar(50) NOT NULL,
    [InterviewTypeDescription] nvarchar(256) NOT NULL,
    CONSTRAINT [PK_InterviewTypeLookUps] PRIMARY KEY ([Id])
);
GO

CREATE TABLE [Interviews] (
    [Id] int NOT NULL IDENTITY,
    [InterviewerId] int NOT NULL,
    [InterviewTypeId] int NOT NULL,
    [CandidateIdentityId] uniqueidentifier NOT NULL,
    [CandidateFirstName] nvarchar(50) NOT NULL,
    [CandidateLastName] nvarchar(50) NOT NULL,
    [CandidateEmail] nvarchar(2048) NOT NULL,
    [SubmissionId] int NOT NULL,
    [BeginTime] datetime2 NOT NULL,
    [EndTime] datetime2 NOT NULL,
    [Rating] int NULL,
    [Feedback] nvarchar(max) NULL,
    [Passed] bit NULL,
    CONSTRAINT [PK_Interviews] PRIMARY KEY ([Id]),
    CONSTRAINT [FK_Interviews_InterviewTypeLookUps_InterviewTypeId] FOREIGN KEY ([InterviewTypeId]) REFERENCES [InterviewTypeLookUps] ([Id]) ON DELETE CASCADE,
    CONSTRAINT [FK_Interviews_Interviewers_InterviewerId] FOREIGN KEY ([InterviewerId]) REFERENCES [Interviewers] ([Id]) ON DELETE CASCADE
);
GO

CREATE INDEX [IX_Interviews_InterviewerId] ON [Interviews] ([InterviewerId]);
GO

CREATE INDEX [IX_Interviews_InterviewTypeId] ON [Interviews] ([InterviewTypeId]);
GO

INSERT INTO [__EFMigrationsHistory] ([MigrationId], [ProductVersion])
VALUES (N'20230328023022_InitialMigration', N'7.0.4');
GO

COMMIT;
GO

