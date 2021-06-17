
-- --------------------------------------------------
-- Entity Designer DDL Script for SQL Server 2005, 2008, 2012 and Azure
-- --------------------------------------------------
-- Date Created: 06/15/2021 01:54:17
-- Generated from EDMX file: C:\Users\İbrahim\Source\Repos\HaberBülteniAPİ\HaberBülteniAPİ\Models\Modeldb.edmx
-- --------------------------------------------------

SET QUOTED_IDENTIFIER OFF;
GO
USE [HaberBülteniDB];
GO
IF SCHEMA_ID(N'dbo') IS NULL EXECUTE(N'CREATE SCHEMA [dbo]');
GO

-- --------------------------------------------------
-- Dropping existing FOREIGN KEY constraints
-- --------------------------------------------------

IF OBJECT_ID(N'[dbo].[FK_Haber_ToKategori]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[Haber] DROP CONSTRAINT [FK_Haber_ToKategori];
GO
IF OBJECT_ID(N'[dbo].[FK_Haber_ToYazar]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[Haber] DROP CONSTRAINT [FK_Haber_ToYazar];
GO
IF OBJECT_ID(N'[dbo].[FK_Yorum_ToHaber]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[Yorum] DROP CONSTRAINT [FK_Yorum_ToHaber];
GO
IF OBJECT_ID(N'[dbo].[FK_Yorum_ToUye]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[Yorum] DROP CONSTRAINT [FK_Yorum_ToUye];
GO

-- --------------------------------------------------
-- Dropping existing tables
-- --------------------------------------------------

IF OBJECT_ID(N'[dbo].[Haber]', 'U') IS NOT NULL
    DROP TABLE [dbo].[Haber];
GO
IF OBJECT_ID(N'[dbo].[Kategori]', 'U') IS NOT NULL
    DROP TABLE [dbo].[Kategori];
GO
IF OBJECT_ID(N'[dbo].[Uye]', 'U') IS NOT NULL
    DROP TABLE [dbo].[Uye];
GO
IF OBJECT_ID(N'[dbo].[Yazar]', 'U') IS NOT NULL
    DROP TABLE [dbo].[Yazar];
GO
IF OBJECT_ID(N'[dbo].[Yorum]', 'U') IS NOT NULL
    DROP TABLE [dbo].[Yorum];
GO

-- --------------------------------------------------
-- Creating all tables
-- --------------------------------------------------

-- Creating table 'Haber'
CREATE TABLE [dbo].[Haber] (
    [haberId] int IDENTITY(1,1) NOT NULL,
    [haberBaslik] nvarchar(max)  NOT NULL,
    [haberOzet] nvarchar(max)  NOT NULL,
    [haber] nvarchar(max)  NOT NULL,
    [haberFoto] nvarchar(max)  NOT NULL,
    [haberYazarId] int  NOT NULL,
    [haberKategoriId] int  NOT NULL,
    [haberTarih] nvarchar(50)  NOT NULL
);
GO

-- Creating table 'Kategori'
CREATE TABLE [dbo].[Kategori] (
    [kategoriId] int IDENTITY(1,1) NOT NULL,
    [kategoriAd] nchar(20)  NOT NULL
);
GO

-- Creating table 'Uye'
CREATE TABLE [dbo].[Uye] (
    [uyeId] int IDENTITY(1,1) NOT NULL,
    [uyeMail] nvarchar(50)  NOT NULL,
    [uyeSifre] nvarchar(10)  NOT NULL,
    [uyeAd] nvarchar(50)  NOT NULL,
    [uyeYetki] nvarchar(max)  NOT NULL
);
GO

-- Creating table 'Yazar'
CREATE TABLE [dbo].[Yazar] (
    [yazarId] int IDENTITY(1,1) NOT NULL,
    [yazarAdSoyad] nvarchar(20)  NOT NULL,
    [yazarBilgi] nvarchar(max)  NOT NULL,
    [yazarResim] nvarchar(max)  NOT NULL
);
GO

-- Creating table 'Yorum'
CREATE TABLE [dbo].[Yorum] (
    [yorumId] int IDENTITY(1,1) NOT NULL,
    [yorumIcerik] nvarchar(50)  NOT NULL,
    [yorumUyeId] int  NOT NULL,
    [yorumHaberId] int  NOT NULL,
    [yorumTarih] nvarchar(50)  NOT NULL
);
GO

-- --------------------------------------------------
-- Creating all PRIMARY KEY constraints
-- --------------------------------------------------

-- Creating primary key on [haberId] in table 'Haber'
ALTER TABLE [dbo].[Haber]
ADD CONSTRAINT [PK_Haber]
    PRIMARY KEY CLUSTERED ([haberId] ASC);
GO

-- Creating primary key on [kategoriId] in table 'Kategori'
ALTER TABLE [dbo].[Kategori]
ADD CONSTRAINT [PK_Kategori]
    PRIMARY KEY CLUSTERED ([kategoriId] ASC);
GO

-- Creating primary key on [uyeId] in table 'Uye'
ALTER TABLE [dbo].[Uye]
ADD CONSTRAINT [PK_Uye]
    PRIMARY KEY CLUSTERED ([uyeId] ASC);
GO

-- Creating primary key on [yazarId] in table 'Yazar'
ALTER TABLE [dbo].[Yazar]
ADD CONSTRAINT [PK_Yazar]
    PRIMARY KEY CLUSTERED ([yazarId] ASC);
GO

-- Creating primary key on [yorumId] in table 'Yorum'
ALTER TABLE [dbo].[Yorum]
ADD CONSTRAINT [PK_Yorum]
    PRIMARY KEY CLUSTERED ([yorumId] ASC);
GO

-- --------------------------------------------------
-- Creating all FOREIGN KEY constraints
-- --------------------------------------------------

-- Creating foreign key on [haberKategoriId] in table 'Haber'
ALTER TABLE [dbo].[Haber]
ADD CONSTRAINT [FK_Haber_ToKategori]
    FOREIGN KEY ([haberKategoriId])
    REFERENCES [dbo].[Kategori]
        ([kategoriId])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_Haber_ToKategori'
CREATE INDEX [IX_FK_Haber_ToKategori]
ON [dbo].[Haber]
    ([haberKategoriId]);
GO

-- Creating foreign key on [haberYazarId] in table 'Haber'
ALTER TABLE [dbo].[Haber]
ADD CONSTRAINT [FK_Haber_ToYazar]
    FOREIGN KEY ([haberYazarId])
    REFERENCES [dbo].[Yazar]
        ([yazarId])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_Haber_ToYazar'
CREATE INDEX [IX_FK_Haber_ToYazar]
ON [dbo].[Haber]
    ([haberYazarId]);
GO

-- Creating foreign key on [yorumHaberId] in table 'Yorum'
ALTER TABLE [dbo].[Yorum]
ADD CONSTRAINT [FK_Yorum_ToHaber]
    FOREIGN KEY ([yorumHaberId])
    REFERENCES [dbo].[Haber]
        ([haberId])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_Yorum_ToHaber'
CREATE INDEX [IX_FK_Yorum_ToHaber]
ON [dbo].[Yorum]
    ([yorumHaberId]);
GO

-- Creating foreign key on [yorumUyeId] in table 'Yorum'
ALTER TABLE [dbo].[Yorum]
ADD CONSTRAINT [FK_Yorum_ToUye]
    FOREIGN KEY ([yorumUyeId])
    REFERENCES [dbo].[Uye]
        ([uyeId])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_Yorum_ToUye'
CREATE INDEX [IX_FK_Yorum_ToUye]
ON [dbo].[Yorum]
    ([yorumUyeId]);
GO

-- --------------------------------------------------
-- Script has ended
-- --------------------------------------------------