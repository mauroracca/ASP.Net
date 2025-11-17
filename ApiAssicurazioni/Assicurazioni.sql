CREATE TABLE [dbo].[tipoAss] (
    [codTipoAss]    VARCHAR (3)  NOT NULL,
    [comparto]      VARCHAR (50) NULL,
    [web]           BIT          NULL,
    [quotataBorsa]  BIT          NULL,
    [interventoH24] BIT          NULL,
    PRIMARY KEY CLUSTERED ([codTipoAss] ASC)
);

CREATE TABLE [dbo].[sedi] (
    [codiceSede]          VARCHAR (3)  NOT NULL,
    [NomeSede]            VARCHAR (20) NULL,
    [Responsabile]        VARCHAR (20) NULL,
    [Citta]               VARCHAR (20) NULL,
    [CodiceAssicurazione] VARCHAR (3)  NULL,
    PRIMARY KEY CLUSTERED ([codiceSede] ASC),
    CONSTRAINT [fk_tipo_ass] FOREIGN KEY ([CodiceAssicurazione]) REFERENCES [dbo].[tipoAss] ([codTipoAss])
);

INSERT INTO [dbo].[tipoAss] ([codTipoAss], [comparto], [web], [quotataBorsa], [interventoH24]) VALUES (N'100', N'Previdenza', 0, 1, 1)
INSERT INTO [dbo].[tipoAss] ([codTipoAss], [comparto], [web], [quotataBorsa], [interventoH24]) VALUES (N'101', N'RC Auto', 1, 0, 1)
INSERT INTO [dbo].[tipoAss] ([codTipoAss], [comparto], [web], [quotataBorsa], [interventoH24]) VALUES (N'102', N'Immobili', 1, 0, 0)
INSERT INTO [dbo].[tipoAss] ([codTipoAss], [comparto], [web], [quotataBorsa], [interventoH24]) VALUES (N'103', N'Cantieri', 1, 1, 1)

INSERT INTO [dbo].[sedi] ([codiceSede], [NomeSede], [Responsabile], [Citta], [CodiceAssicurazione]) VALUES (N'12', N'Ti assicura', N'Ciccio', N'Cavour', N'102')
INSERT INTO [dbo].[sedi] ([codiceSede], [NomeSede], [Responsabile], [Citta], [CodiceAssicurazione]) VALUES (N'21', N'Axa di Fossano', N'Rosso Luigi', N'Torino', N'100')
INSERT INTO [dbo].[sedi] ([codiceSede], [NomeSede], [Responsabile], [Citta], [CodiceAssicurazione]) VALUES (N'26', N'Toro', N'Verdi Lucia', N'Savigliano', N'100')
INSERT INTO [dbo].[sedi] ([codiceSede], [NomeSede], [Responsabile], [Citta], [CodiceAssicurazione]) VALUES (N'51', N'La Toro di Saluzzo', N'Bianchi Mario', N'Saluzzo', N'101')
INSERT INTO [dbo].[sedi] ([codiceSede], [NomeSede], [Responsabile], [Citta], [CodiceAssicurazione]) VALUES (N'54', N'L''Axa', N'Rossi Anna', N'Torino', N'100')
INSERT INTO [dbo].[sedi] ([codiceSede], [NomeSede], [Responsabile], [Citta], [CodiceAssicurazione]) VALUES (N'62', N'Axa uno', N'Bianco Matteo', N'Cuneo', N'102')
INSERT INTO [dbo].[sedi] ([codiceSede], [NomeSede], [Responsabile], [Citta], [CodiceAssicurazione]) VALUES (N'75', N'Il Maira ti assicura', N'Pino', N'Savigliano', N'101')
