CREATE TABLE [dbo].[Utenti] (
    [Id]       INT        NOT NULL,
    [username]     VARCHAR(20) NULL,
    [password] VARCHAR(20) NULL,
    PRIMARY KEY CLUSTERED ([Id] ASC)
);

CREATE TABLE [dbo].[classi] (
    [codCl]  INT         NOT NULL,
    [nomeCl] VARCHAR (2) NULL,
    [spec]   VARCHAR (3) NULL,
    PRIMARY KEY CLUSTERED ([codCl] ASC)
);

CREATE TABLE [dbo].[alunni] (
    [matricola] INT          NOT NULL,
    [cognome]   VARCHAR (50) NULL,
    [nome]      VARCHAR (50) NULL,
    [dataN]     DATE         NULL,
    [codCl]     INT          NOT NULL,
    [stage]     VARCHAR (2)  NULL,
    PRIMARY KEY CLUSTERED ([matricola] ASC),
    CONSTRAINT [fk_classi] FOREIGN KEY ([codCl]) REFERENCES [dbo].[classi] ([codCl])
);

INSERT INTO [dbo].[Utenti] ([Id], [user], [password]) VALUES (1, N'Mauro', N'12345')
INSERT INTO [dbo].[Utenti] ([Id], [user], [password]) VALUES (2, N'Paolo', N'4875')
INSERT INTO [dbo].[Utenti] ([Id], [user], [password]) VALUES (3, N'Jessica', N'8759')
INSERT INTO [dbo].[Utenti] ([Id], [user], [password]) VALUES (4, N'Sveva', N'8789')

INSERT INTO [dbo].[classi] ([codCl], [nomeCl], [spec]) VALUES (1, N'5D', N'INF')
INSERT INTO [dbo].[classi] ([codCl], [nomeCl], [spec]) VALUES (2, N'4D', N'INF')
INSERT INTO [dbo].[classi] ([codCl], [nomeCl], [spec]) VALUES (3, N'3D', N'MEC')
INSERT INTO [dbo].[classi] ([codCl], [nomeCl], [spec]) VALUES (4, N'4C', N'LIC')
INSERT INTO [dbo].[classi] ([codCl], [nomeCl], [spec]) VALUES (5, N'4C', N'MEC')
INSERT INTO [dbo].[classi] ([codCl], [nomeCl], [spec]) VALUES (6, N'3D', N'ELT')

INSERT INTO [dbo].[alunni] ([matricola], [cognome], [nome], [dataN], [codCl], [stage]) VALUES (1, N'ROSSI', N'MARIO', N'2000-10-28', 2, N'NO')
INSERT INTO [dbo].[alunni] ([matricola], [cognome], [nome], [dataN], [codCl], [stage]) VALUES (2, N'VERDI', N'PAOLO', N'2001-08-06', 3, N'SI')
INSERT INTO [dbo].[alunni] ([matricola], [cognome], [nome], [dataN], [codCl], [stage]) VALUES (3, N'CICCIO', N'PASTICCIO', N'2002-09-09', 6, N'SI')
INSERT INTO [dbo].[alunni] ([matricola], [cognome], [nome], [dataN], [codCl], [stage]) VALUES (4, N'GIORGIO', N'PASTONE', N'2001-07-08', 3, N'SI')
INSERT INTO [dbo].[alunni] ([matricola], [cognome], [nome], [dataN], [codCl], [stage]) VALUES (5, N'SOGNO', N'RENZO', N'2001-07-09', 4, N'NO')
INSERT INTO [dbo].[alunni] ([matricola], [cognome], [nome], [dataN], [codCl], [stage]) VALUES (6, N'SANNA', N'ROSANNA', N'2001-02-03', 5, N'NO')
INSERT INTO [dbo].[alunni] ([matricola], [cognome], [nome], [dataN], [codCl], [stage]) VALUES (7, N'GIONAS', N'RAFFAELLA', N'2003-04-08', 1, N'SI')
INSERT INTO [dbo].[alunni] ([matricola], [cognome], [nome], [dataN], [codCl], [stage]) VALUES (8, N'RICCI', N'PAOLO', N'2004-07-09', 5, N'SI')
INSERT INTO [dbo].[alunni] ([matricola], [cognome], [nome], [dataN], [codCl], [stage]) VALUES (9, N'GIOVE', N'GINETTA', N'2005-05-05', 6, N'SI')
INSERT INTO [dbo].[alunni] ([matricola], [cognome], [nome], [dataN], [codCl], [stage]) VALUES (10, N'RATTOPPO', N'RINA', N'2003-07-08', 4, N'SI')
INSERT INTO [dbo].[alunni] ([matricola], [cognome], [nome], [dataN], [codCl], [stage]) VALUES (12, N'GIUNTI', N'EDITTA', N'2003-09-08', 2, N'NO')
INSERT INTO [dbo].[alunni] ([matricola], [cognome], [nome], [dataN], [codCl], [stage]) VALUES (13, N'FORNA', N'GIOVANNI', N'2001-04-07', 1, N'SI')
INSERT INTO [dbo].[alunni] ([matricola], [cognome], [nome], [dataN], [codCl], [stage]) VALUES (14, N'FOSSE', N'ROMANO', N'2003-07-04', 4, N'NO')
INSERT INTO [dbo].[alunni] ([matricola], [cognome], [nome], [dataN], [codCl], [stage]) VALUES (15, N'GETTO', N'GIULIA', N'2002-04-04', 3, N'SI')
INSERT INTO [dbo].[alunni] ([matricola], [cognome], [nome], [dataN], [codCl], [stage]) VALUES (16, N'DOTTO', N'DINO', N'2003-07-08', 2, N'SI')
INSERT INTO [dbo].[alunni] ([matricola], [cognome], [nome], [dataN], [codCl], [stage]) VALUES (17, N'ASSO', N'FEDERICA', N'2003-03-03', 5, N'NO')
INSERT INTO [dbo].[alunni] ([matricola], [cognome], [nome], [dataN], [codCl], [stage]) VALUES (18, N'GOTTA', N'ALIDA', N'2000-07-08', 6, N'SI')
