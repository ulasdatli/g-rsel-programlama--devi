USE [ulasdb]
GO
/****** Object:  Table [dbo].[derstablo]    Script Date: 8.12.2022 23:10:22 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[derstablo](
	[dersid] [smallint] IDENTITY(1,1) NOT NULL,
	[dersadi] [varchar](30) NULL,
	[derskredisi] [varchar](30) NULL,
	[dersokulyonetimid] [smallint] NULL,
 CONSTRAINT [PK_tbl_ders] PRIMARY KEY CLUSTERED 
(
	[dersid] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[ogrenciderstablo]    Script Date: 8.12.2022 23:10:23 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[ogrenciderstablo](
	[ogrencidersid] [smallint] IDENTITY(1,1) NOT NULL,
	[ogrencidersdersid] [smallint] NULL,
	[ogrencidersogrenciid] [smallint] NULL,
 CONSTRAINT [PK_tbl_ogrenciders] PRIMARY KEY CLUSTERED 
(
	[ogrencidersid] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[ogrencilertablo]    Script Date: 8.12.2022 23:10:23 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[ogrencilertablo](
	[ogrenciid] [smallint] IDENTITY(1,1) NOT NULL,
	[ogrenciadsoyad] [varchar](50) NULL,
	[ogrencikayittarih] [datetime] NULL,
	[ogrencidogumtarih] [datetime] NULL,
	[ogrencibolum] [varchar](50) NULL,
	[ogrencino] [varchar](11) NULL,
 CONSTRAINT [PK_tbl_ogrenciler] PRIMARY KEY CLUSTERED 
(
	[ogrenciid] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[okulyonetimtablo]    Script Date: 8.12.2022 23:10:23 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[okulyonetimtablo](
	[yonetimid] [smallint] IDENTITY(1,1) NOT NULL,
	[yonetimadsoyad] [varchar](30) NULL,
	[yonetimgorevi] [varchar](30) NULL,
	[yonetimtipi] [nchar](10) NULL,
 CONSTRAINT [PK_tbl_okulyonetim] PRIMARY KEY CLUSTERED 
(
	[yonetimid] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
ALTER TABLE [dbo].[derstablo]  WITH CHECK ADD  CONSTRAINT [FK_tbl_ders_tbl_okulyonetim] FOREIGN KEY([dersokulyonetimid])
REFERENCES [dbo].[okulyonetimtablo] ([yonetimid])
GO
ALTER TABLE [dbo].[derstablo] CHECK CONSTRAINT [FK_tbl_ders_tbl_okulyonetim]
GO
ALTER TABLE [dbo].[ogrenciderstablo]  WITH CHECK ADD  CONSTRAINT [FK_tbl_ogrenciders_tbl_ders] FOREIGN KEY([ogrencidersdersid])
REFERENCES [dbo].[derstablo] ([dersid])
GO
ALTER TABLE [dbo].[ogrenciderstablo] CHECK CONSTRAINT [FK_tbl_ogrenciders_tbl_ders]
GO
ALTER TABLE [dbo].[ogrenciderstablo]  WITH CHECK ADD  CONSTRAINT [FK_tbl_ogrenciders_tbl_ogrenciler1] FOREIGN KEY([ogrencidersogrenciid])
REFERENCES [dbo].[ogrencilertablo] ([ogrenciid])
GO
ALTER TABLE [dbo].[ogrenciderstablo] CHECK CONSTRAINT [FK_tbl_ogrenciders_tbl_ogrenciler1]
GO
