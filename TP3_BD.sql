CREATE TABLE [dbo].[user] (
    [id_user]         INT           IDENTITY (1, 1) NOT NULL,
    [login]           NVARCHAR (10) NOT NULL,
    [motdepasse]      NVARCHAR (20) NOT NULL,
    [permis_conduire] NVARCHAR (13) NOT NULL,
    [nom]             NVARCHAR (50) NOT NULL,
    [prenom]          NVARCHAR (50) NULL,
    [type]            NVARCHAR (10) NOT NULL,
    [type_compte]     NVARCHAR (10) NOT NULL,
    PRIMARY KEY CLUSTERED ([id_user] ASC)
);

CREATE TABLE [dbo].[marque] (
    [id_marque] INT           IDENTITY (1, 1) NOT NULL,
    [nom]       NVARCHAR (20) NOT NULL,
    PRIMARY KEY CLUSTERED ([id_marque] ASC)
);

CREATE TABLE [dbo].[modele] (
    [id_modele] INT           IDENTITY (1, 1) NOT NULL,
    [nom]       NVARCHAR (20) NULL,
    [id_marque] INT           NULL,
    PRIMARY KEY CLUSTERED ([id_modele] ASC),
    CONSTRAINT [FK1_dbo] FOREIGN KEY ([id_marque]) REFERENCES [dbo].[marque] ([id_marque]) ON DELETE CASCADE
);

CREATE TABLE [dbo].[option] (
    [id_option] INT            IDENTITY (1, 1) NOT NULL,
    [prix]      DECIMAL (6, 2) NULL,
    [nom]       NVARCHAR (50)  NOT NULL,
    PRIMARY KEY CLUSTERED ([id_option] ASC)
);

CREATE TABLE [dbo].[couleur] (
    [id_couleur] INT           IDENTITY (1, 1) NOT NULL,
    [nom]        NVARCHAR (20) NOT NULL,
    PRIMARY KEY CLUSTERED ([id_couleur] ASC)
);

CREATE TABLE [dbo].[etat] (
    [id_etat] INT           IDENTITY (1, 1) NOT NULL,
    [nom]     NVARCHAR (20) NOT NULL,
    PRIMARY KEY CLUSTERED ([id_etat] ASC)
);

CREATE TABLE [dbo].[carburant] (
    [id_carburant] INT           IDENTITY (1, 1) NOT NULL,
    [nom]          NVARCHAR (20) NOT NULL,
    PRIMARY KEY CLUSTERED ([id_carburant] ASC)
);

CREATE TABLE [dbo].[type] (
    [id_type] INT           IDENTITY (1, 1) NOT NULL,
    [nom]     NVARCHAR (20) NOT NULL,
    PRIMARY KEY CLUSTERED ([id_type] ASC)
);

CREATE TABLE [dbo].[mode_paiement] (
    [id_mode_paiement] INT           IDENTITY (1, 1) NOT NULL,
    [nom]              NVARCHAR (20) NOT NULL,
    PRIMARY KEY CLUSTERED ([id_mode_paiement] ASC)
);

CREATE TABLE [dbo].[status] (
    [id_status] INT           IDENTITY (1, 1) NOT NULL,
    [nom]       NVARCHAR (20) NOT NULL,
    PRIMARY KEY CLUSTERED ([id_status] ASC)
);

CREATE TABLE [dbo].[vehicule] (
    [id_vehicule]       INT             IDENTITY (1, 1) NOT NULL,
    [immatriculation]   NVARCHAR (7)    NULL,
    [prix]              DECIMAL (6, 2)  NULL,
    [kilometrage]       INT             NULL,
    [date_construction] DATE            NULL,
    [date_mise_vente]   DATE            NULL,
    [est_vendu]         BIT             DEFAULT ((0)) NOT NULL,
    [id_type]           INT             NULL,
    [id_modele]         INT             NULL,
    [id_couleur]        INT             NULL,
    [id_carburant]      INT             NULL,
    [id_etat]           INT             NULL,
    [image]             VARBINARY (MAX) NULL,
    [description]       NVARCHAR (150)  NULL,
    PRIMARY KEY CLUSTERED ([id_vehicule] ASC),
    CONSTRAINT [FK2_dbo] FOREIGN KEY ([id_type]) REFERENCES [dbo].[type] ([id_type]) ON DELETE CASCADE,
    CONSTRAINT [FK3_dbo] FOREIGN KEY ([id_modele]) REFERENCES [dbo].[modele] ([id_modele]) ON DELETE CASCADE,
    CONSTRAINT [FK4_dbo] FOREIGN KEY ([id_couleur]) REFERENCES [dbo].[couleur] ([id_couleur]) ON DELETE CASCADE,
    CONSTRAINT [FK5_dbo] FOREIGN KEY ([id_carburant]) REFERENCES [dbo].[carburant] ([id_carburant]) ON DELETE CASCADE,
    CONSTRAINT [FK6_dbo] FOREIGN KEY ([id_etat]) REFERENCES [dbo].[etat] ([id_etat]) ON DELETE CASCADE
);

CREATE TABLE [dbo].[commande] (
    [id_commande]      INT  IDENTITY (1, 1) NOT NULL,
    [date_rdv]         DATE NULL,
    [id_user]          INT  NULL,
    [id_status]        INT  NULL,
    [id_mode_paiement] INT  NULL,
    PRIMARY KEY CLUSTERED ([id_commande] ASC),
    CONSTRAINT [FK7_dbo] FOREIGN KEY ([id_user]) REFERENCES [dbo].[user] ([id_user]) ON DELETE CASCADE,
    CONSTRAINT [FK8_dbo] FOREIGN KEY ([id_status]) REFERENCES [dbo].[status] ([id_status]) ON DELETE CASCADE,
    CONSTRAINT [FK9_dbo] FOREIGN KEY ([id_mode_paiement]) REFERENCES [dbo].[mode_paiement] ([id_mode_paiement]) ON DELETE CASCADE
);

CREATE TABLE [dbo].[bon_commande] (
    [id_bon_commande] INT IDENTITY (1, 1) NOT NULL,
    [id_vehicule]     INT NULL,
    [id_commande]     INT NULL,
    PRIMARY KEY CLUSTERED ([id_bon_commande] ASC),
    CONSTRAINT [FK10_dbo] FOREIGN KEY ([id_vehicule]) REFERENCES [dbo].[vehicule] ([id_vehicule]) ON DELETE CASCADE,
    CONSTRAINT [FK11_dbo] FOREIGN KEY ([id_commande]) REFERENCES [dbo].[commande] ([id_commande]) ON DELETE CASCADE
);

CREATE TABLE [dbo].[list_option] (
    [id_bon_commande] INT NULL,
    [id_option]       INT NULL,
    CONSTRAINT [FK12_dbo] FOREIGN KEY ([id_bon_commande]) REFERENCES [dbo].[bon_commande] ([id_bon_commande]) ON DELETE CASCADE,
    CONSTRAINT [FK13_dbo] FOREIGN KEY ([id_option]) REFERENCES [dbo].[option] ([id_option]) ON DELETE CASCADE
);



INSERT INTO [dbo].[user] ([login],[motdepasse],[permis_conduire],[nom],[prenom],[type],[type_compte])
VALUES ('ben', 'qwerty', 'L123456789012', 'Ben Slim', 'Hamdi', 'normal', 'client');
INSERT INTO [dbo].[user] ([login],[motdepasse],[permis_conduire],[nom],[prenom],[type],[type_compte])
VALUES ('autosale', 'qwerty', 'L999999999999', 'AUTOSALE.LTD', '', 'societe', 'client');
INSERT INTO [dbo].[user] ([login],[motdepasse],[permis_conduire],[nom],[prenom],[type],[type_compte])
VALUES ('admin', 'qwerty', '0000000000000', 'administrateur', 'bd', 'admin', 'admin');

INSERT INTO [dbo].[marque] ([nom]) VALUES ('TOYOTA');
INSERT INTO [dbo].[marque] ([nom]) VALUES ('HONDA');
INSERT INTO [dbo].[marque] ([nom]) VALUES ('FORD');
INSERT INTO [dbo].[marque] ([nom]) VALUES ('NISSAN');
INSERT INTO [dbo].[marque] ([nom]) VALUES ('MAZDA');

INSERT INTO [dbo].[modele] ([nom],[id_marque]) VALUES ('YARIS', 1);
INSERT INTO [dbo].[modele] ([nom],[id_marque]) VALUES ('RAV4', 1);
INSERT INTO [dbo].[modele] ([nom],[id_marque]) VALUES ('CRV', 2);
INSERT INTO [dbo].[modele] ([nom],[id_marque]) VALUES ('Civic', 2);
INSERT INTO [dbo].[modele] ([nom],[id_marque]) VALUES ('FUSION', 3);
INSERT INTO [dbo].[modele] ([nom],[id_marque]) VALUES ('ESCAPE', 3);
INSERT INTO [dbo].[modele] ([nom],[id_marque]) VALUES ('ROGUE', 4);
INSERT INTO [dbo].[modele] ([nom],[id_marque]) VALUES ('MAXIMA', 4);
INSERT INTO [dbo].[modele] ([nom],[id_marque]) VALUES ('MAZDA3', 5);
INSERT INTO [dbo].[modele] ([nom],[id_marque]) VALUES ('CX-5', 5);

INSERT INTO [dbo].[option] ([prix],[nom]) VALUES (100.20, 'sieges chauffants');
INSERT INTO [dbo].[option] ([prix],[nom]) VALUES (69.59, 'jentes en alliage de serie');
INSERT INTO [dbo].[option] ([prix],[nom]) VALUES (205.05, 'elements de design sport');

INSERT INTO [dbo].[couleur] ([nom]) VALUES ('rouge');
INSERT INTO [dbo].[couleur] ([nom]) VALUES ('gris');
INSERT INTO [dbo].[couleur] ([nom]) VALUES ('noire');
INSERT INTO [dbo].[couleur] ([nom]) VALUES ('blanche');
INSERT INTO [dbo].[couleur] ([nom]) VALUES ('jaune');
INSERT INTO [dbo].[couleur] ([nom]) VALUES ('bleu');
INSERT INTO [dbo].[couleur] ([nom]) VALUES ('vert');

INSERT INTO [dbo].[etat] ([nom]) VALUES ('neuf');
INSERT INTO [dbo].[etat] ([nom]) VALUES ('usagé');


INSERT INTO [dbo].[carburant] ([nom]) VALUES ('essence');
INSERT INTO [dbo].[carburant] ([nom]) VALUES ('diesel');
INSERT INTO [dbo].[carburant] ([nom]) VALUES ('hybride');
INSERT INTO [dbo].[carburant] ([nom]) VALUES ('electrique');

INSERT INTO [dbo].[type] ([nom]) VALUES ('berline');
INSERT INTO [dbo].[type] ([nom]) VALUES ('minifourgonnettes');
INSERT INTO [dbo].[type] ([nom]) VALUES ('camions');
INSERT INTO [dbo].[type] ([nom]) VALUES ('coupe');

INSERT INTO [dbo].[mode_paiement] ([nom]) VALUES ('au comptant');
INSERT INTO [dbo].[mode_paiement] ([nom]) VALUES ('demande de crédit');

INSERT INTO [dbo].[status] ([nom]) VALUES ('en cours');
INSERT INTO [dbo].[status] ([nom]) VALUES ('validée');
INSERT INTO [dbo].[status] ([nom]) VALUES ('livrée');


INSERT INTO [dbo].[vehicule] ([immatriculation],[prix],[kilometrage],[date_construction],[date_mise_vente],
            [est_vendu],[id_type],[id_modele],[id_couleur],[id_carburant],[id_etat])
VALUES ('L9999D', 8000, 100000, CONVERT(DATETIME, '2010-08-27',120), SYSDATETIME(),0, 1, 4, 2, 1, 4);