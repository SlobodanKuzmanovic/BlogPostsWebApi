USE [master]
GO
/****** Object:  Database [BlogPost]    Script Date: 09-Apr-20 2:06:58 AM ******/
--CREATE DATABASE [BlogPost]
-- CONTAINMENT = NONE
-- ON  PRIMARY 
--( NAME = N'BlogPost', FILENAME = N'C:\Program Files\Microsoft SQL Server\MSSQL13.SQLEXPRESS\MSSQL\DATA\BlogPost.mdf' , SIZE = 8192KB , MAXSIZE = UNLIMITED, FILEGROWTH = 65536KB )
-- LOG ON 
--( NAME = N'BlogPost_log', FILENAME = N'C:\Program Files\Microsoft SQL Server\MSSQL13.SQLEXPRESS\MSSQL\DATA\BlogPost_log.ldf' , SIZE = 8192KB , MAXSIZE = 2048GB , FILEGROWTH = 65536KB )
--GO
ALTER DATABASE [BlogPost] SET COMPATIBILITY_LEVEL = 130
GO
IF (1 = FULLTEXTSERVICEPROPERTY('IsFullTextInstalled'))
begin
EXEC [BlogPost].[dbo].[sp_fulltext_database] @action = 'enable'
end
GO
ALTER DATABASE [BlogPost] SET ANSI_NULL_DEFAULT OFF 
GO
ALTER DATABASE [BlogPost] SET ANSI_NULLS OFF 
GO
ALTER DATABASE [BlogPost] SET ANSI_PADDING OFF 
GO
ALTER DATABASE [BlogPost] SET ANSI_WARNINGS OFF 
GO
ALTER DATABASE [BlogPost] SET ARITHABORT OFF 
GO
ALTER DATABASE [BlogPost] SET AUTO_CLOSE OFF 
GO
ALTER DATABASE [BlogPost] SET AUTO_SHRINK OFF 
GO
ALTER DATABASE [BlogPost] SET AUTO_UPDATE_STATISTICS ON 
GO
ALTER DATABASE [BlogPost] SET CURSOR_CLOSE_ON_COMMIT OFF 
GO
ALTER DATABASE [BlogPost] SET CURSOR_DEFAULT  GLOBAL 
GO
ALTER DATABASE [BlogPost] SET CONCAT_NULL_YIELDS_NULL OFF 
GO
ALTER DATABASE [BlogPost] SET NUMERIC_ROUNDABORT OFF 
GO
ALTER DATABASE [BlogPost] SET QUOTED_IDENTIFIER OFF 
GO
ALTER DATABASE [BlogPost] SET RECURSIVE_TRIGGERS OFF 
GO
ALTER DATABASE [BlogPost] SET  DISABLE_BROKER 
GO
ALTER DATABASE [BlogPost] SET AUTO_UPDATE_STATISTICS_ASYNC OFF 
GO
ALTER DATABASE [BlogPost] SET DATE_CORRELATION_OPTIMIZATION OFF 
GO
ALTER DATABASE [BlogPost] SET TRUSTWORTHY OFF 
GO
ALTER DATABASE [BlogPost] SET ALLOW_SNAPSHOT_ISOLATION OFF 
GO
ALTER DATABASE [BlogPost] SET PARAMETERIZATION SIMPLE 
GO
ALTER DATABASE [BlogPost] SET READ_COMMITTED_SNAPSHOT OFF 
GO
ALTER DATABASE [BlogPost] SET HONOR_BROKER_PRIORITY OFF 
GO
ALTER DATABASE [BlogPost] SET RECOVERY SIMPLE 
GO
ALTER DATABASE [BlogPost] SET  MULTI_USER 
GO
ALTER DATABASE [BlogPost] SET PAGE_VERIFY CHECKSUM  
GO
ALTER DATABASE [BlogPost] SET DB_CHAINING OFF 
GO
ALTER DATABASE [BlogPost] SET FILESTREAM( NON_TRANSACTED_ACCESS = OFF ) 
GO
ALTER DATABASE [BlogPost] SET TARGET_RECOVERY_TIME = 60 SECONDS 
GO
ALTER DATABASE [BlogPost] SET DELAYED_DURABILITY = DISABLED 
GO
ALTER DATABASE [BlogPost] SET QUERY_STORE = OFF
GO
USE [BlogPost]
GO
ALTER DATABASE SCOPED CONFIGURATION SET MAXDOP = 0;
GO
ALTER DATABASE SCOPED CONFIGURATION FOR SECONDARY SET MAXDOP = PRIMARY;
GO
ALTER DATABASE SCOPED CONFIGURATION SET LEGACY_CARDINALITY_ESTIMATION = OFF;
GO
ALTER DATABASE SCOPED CONFIGURATION FOR SECONDARY SET LEGACY_CARDINALITY_ESTIMATION = PRIMARY;
GO
ALTER DATABASE SCOPED CONFIGURATION SET PARAMETER_SNIFFING = ON;
GO
ALTER DATABASE SCOPED CONFIGURATION FOR SECONDARY SET PARAMETER_SNIFFING = PRIMARY;
GO
ALTER DATABASE SCOPED CONFIGURATION SET QUERY_OPTIMIZER_HOTFIXES = OFF;
GO
ALTER DATABASE SCOPED CONFIGURATION FOR SECONDARY SET QUERY_OPTIMIZER_HOTFIXES = PRIMARY;
GO
USE [BlogPost]
GO
/****** Object:  Table [dbo].[Posts]    Script Date: 09-Apr-20 2:06:59 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Posts](
	[PkPostId] [bigint] IDENTITY(1,1) NOT NULL,
	[slug] [nvarchar](max) NULL,
	[title] [nvarchar](max) NOT NULL,
	[description] [nvarchar](max) NOT NULL,
	[body] [nvarchar](max) NOT NULL,
	[createdAt] [datetime2](7) NULL,
	[updatedAt] [datetime2](7) NULL,
 CONSTRAINT [PK_Posts] PRIMARY KEY CLUSTERED 
(
	[PkPostId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]

GO
/****** Object:  Table [dbo].[Tags]    Script Date: 09-Apr-20 2:06:59 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Tags](
	[PkTagId] [bigint] IDENTITY(1,1) NOT NULL,
	[tag] [nvarchar](max) NOT NULL,
 CONSTRAINT [PK_Tags] PRIMARY KEY CLUSTERED 
(
	[PkTagId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]

GO
/****** Object:  Table [dbo].[TagsForPost]    Script Date: 09-Apr-20 2:06:59 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[TagsForPost](
	[FkPostId] [bigint] NOT NULL,
	[FkTagId] [bigint] NOT NULL
) ON [PRIMARY]

GO
SET IDENTITY_INSERT [dbo].[Posts] ON 

INSERT [dbo].[Posts] ([PkPostId], [slug], [title], [description], [body], [createdAt], [updatedAt]) VALUES (17, N'na-zelenom-vencu-se-pojavili-dileri-cistog-vazduha', N'Na zelenom vencu se pojavili dileri čistog vazduha', N'BEOGRAD, 26. januar 2020, (Njuz) – Na Zelenom vencu u Beogradu danas su se pojavili prvi dileri čistog vazduha. ', N'Kako su zabeležili reporteri Njuza na licu mesta, dileri čistog vazduha viđeni su u podzemnom prolazu, oko pijace Zeleni venac, ispred Meka i na atuobuskim stajalištima.', CAST(N'2020-04-09T01:56:44.2266667' AS DateTime2), CAST(N'2020-04-09T02:04:48.5900000' AS DateTime2))
INSERT [dbo].[Posts] ([PkPostId], [slug], [title], [description], [body], [createdAt], [updatedAt]) VALUES (18, N'brnabic-od-oktobra-povecanje-broja-obecanja-za-15-odsto', N'Brnabić: Od Oktobra povećanje broja obećanja za 15 odsto', N'BEOGRAD, 17. septembar 2019, (Njuz) – Presednica vlade Ana Brnabić najavila je na konferenciji za štampu da građani Srbije od 1.oktobra mogu da očekuju da će se broj obećanja povećati za 15 odsto.', N'Vlada Srbija usvojila je na sednici predlog da se građanima najviše obećavaju povećanja primanja u zdravstvu, tu ćemo imati rast od oko 15 odsto, zatim u prosveti gde ćemo broj povećati za 10 odsto, dok ćemo penzionerima uputiti jednokratna obećanja o povećanju penzija sledeće godine – objasnila je premijerka.', CAST(N'2020-04-09T01:59:00.8500000' AS DateTime2), NULL)
INSERT [dbo].[Posts] ([PkPostId], [slug], [title], [description], [body], [createdAt], [updatedAt]) VALUES (19, N'programer-se-dvoumi-izmedu-firme-koja-ima-stoni-tenis-i-firme-koja-ima-pikado', N'Programer se dvoumi između firme koja ima stoni tenis i firme koja ima pikado', N'BEOGRAD, 25. oktobar 2019, (Njuz)  – Programer Milutin Sokolov (26) iz Beograda objavio je na LinkedInu pitanje da li odabere kompaniju koja ima stoni tenis ili kompaniju u kojoj zaposleni igraju pikado i izazvao lavinu reakcija i komentara.', N'Sokolov je pitanje postavio jer nije mogao da odluči šta je bolje za njegov lični i profesionalni razvoj, stoni tenis ili pikado, pa je odlučio da čuje mišljenje drugih kolega.– Svi ostali uslovi koje sam dobio u dvema kompanijama su gotovo isti, tako da je ostalo samo da rešim dilemu između pikada i stonog tenisa. Podjednako volim oba ta sporta i zato mi je teško da odlučim – naveo je Sokolov.', CAST(N'2020-04-09T02:01:02.4733333' AS DateTime2), CAST(N'2020-04-09T02:03:49.0533333' AS DateTime2))
INSERT [dbo].[Posts] ([PkPostId], [slug], [title], [description], [body], [createdAt], [updatedAt]) VALUES (20, N'influenser-preti-da-ce-naci-pravi-posao-ako-instagram-ukine-lajkove', N'Influenser preti da će naći pravi posao ako instagram ukine lajkove', N'BEOGRAD, 25. jul 2019, (Njuz) – Ukidanje prikaza broja lajkova koje najavljuje Instagram naišlo je na jednoglasnu osudu influensera širom sveta, a oni najradikalniji među njima prete da će, ako ovo rešenje zaživi, pronaći pravi posao.', N'Broj lajkova na objavama je izuzetno važan, ističu ljudi iz branše, a njihovim sakrivanjem bila bi naneta velika šteta najuticajnijim među njima.– Vredno sam radio na svom Instagram profilu. Redovno sam objavljivao interesantne sadržaje, skupljao pratioce i, uz mnogo truda i odricanja, konačno postao neko za koga se, bez preterivanja, može reći da ima značajan uticaj na ovoj mreži – kaže Jovan Čavić, poznati influenser iz Beograda.', CAST(N'2020-04-09T02:02:49.3300000' AS DateTime2), NULL)
SET IDENTITY_INSERT [dbo].[Posts] OFF
SET IDENTITY_INSERT [dbo].[Tags] ON 

INSERT [dbo].[Tags] ([PkTagId], [tag]) VALUES (34, N'ekonomija')
INSERT [dbo].[Tags] ([PkTagId], [tag]) VALUES (35, N'vazduh')
INSERT [dbo].[Tags] ([PkTagId], [tag]) VALUES (36, N'vlada')
INSERT [dbo].[Tags] ([PkTagId], [tag]) VALUES (37, N'premijer ili premijerka')
INSERT [dbo].[Tags] ([PkTagId], [tag]) VALUES (38, N'posao')
INSERT [dbo].[Tags] ([PkTagId], [tag]) VALUES (39, N'programer')
INSERT [dbo].[Tags] ([PkTagId], [tag]) VALUES (40, N'pikado')
INSERT [dbo].[Tags] ([PkTagId], [tag]) VALUES (41, N'stoni tenis')
INSERT [dbo].[Tags] ([PkTagId], [tag]) VALUES (42, N'instagram')
INSERT [dbo].[Tags] ([PkTagId], [tag]) VALUES (43, N'influenser')
SET IDENTITY_INSERT [dbo].[Tags] OFF
INSERT [dbo].[TagsForPost] ([FkPostId], [FkTagId]) VALUES (17, 34)
INSERT [dbo].[TagsForPost] ([FkPostId], [FkTagId]) VALUES (17, 35)
INSERT [dbo].[TagsForPost] ([FkPostId], [FkTagId]) VALUES (18, 34)
INSERT [dbo].[TagsForPost] ([FkPostId], [FkTagId]) VALUES (18, 36)
INSERT [dbo].[TagsForPost] ([FkPostId], [FkTagId]) VALUES (18, 37)
INSERT [dbo].[TagsForPost] ([FkPostId], [FkTagId]) VALUES (19, 38)
INSERT [dbo].[TagsForPost] ([FkPostId], [FkTagId]) VALUES (19, 39)
INSERT [dbo].[TagsForPost] ([FkPostId], [FkTagId]) VALUES (19, 40)
INSERT [dbo].[TagsForPost] ([FkPostId], [FkTagId]) VALUES (19, 41)
INSERT [dbo].[TagsForPost] ([FkPostId], [FkTagId]) VALUES (20, 38)
INSERT [dbo].[TagsForPost] ([FkPostId], [FkTagId]) VALUES (20, 42)
INSERT [dbo].[TagsForPost] ([FkPostId], [FkTagId]) VALUES (20, 43)
ALTER TABLE [dbo].[TagsForPost]  WITH CHECK ADD  CONSTRAINT [FK_TagsForPost_Posts] FOREIGN KEY([FkPostId])
REFERENCES [dbo].[Posts] ([PkPostId])
GO
ALTER TABLE [dbo].[TagsForPost] CHECK CONSTRAINT [FK_TagsForPost_Posts]
GO
ALTER TABLE [dbo].[TagsForPost]  WITH CHECK ADD  CONSTRAINT [FK_TagsForPost_Tags] FOREIGN KEY([FkTagId])
REFERENCES [dbo].[Tags] ([PkTagId])
GO
ALTER TABLE [dbo].[TagsForPost] CHECK CONSTRAINT [FK_TagsForPost_Tags]
GO
/****** Object:  StoredProcedure [dbo].[st_Create_AddTagToPost]    Script Date: 09-Apr-20 2:06:59 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:		<Author,,Name>
-- Create date: <Create Date,,>
-- Description:	<Description,,>
-- =============================================
CREATE PROCEDURE [dbo].[st_Create_AddTagToPost]
	@PkPostId bigint,
	@PkTagId bigint
AS
BEGIN
	insert into TagsForPost (FkPostId, FkTagId) values (@PkPostId, @PkTagId)
END

GO
/****** Object:  StoredProcedure [dbo].[st_Create_BlogPost]    Script Date: 09-Apr-20 2:06:59 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:		<Author,,Name>
-- Create date: <Create Date,,>
-- Description:	<Description,,>
-- =============================================
CREATE PROCEDURE [dbo].[st_Create_BlogPost]
	@slug nvarchar(max),
	@title nvarchar(max),
	@description nvarchar(max),
	@body nvarchar(max),
	@createdAt datetime2(7)
AS
BEGIN
	insert into Posts (slug, title, description, body, createdAt) 
	values (@slug, @title, @description, @body, @createdAt)

	select * from Posts where slug = slug
END

GO
/****** Object:  StoredProcedure [dbo].[st_Create_Tag]    Script Date: 09-Apr-20 2:06:59 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:		Slobodan Kuzmanovic
-- Create date: <Create Date,,>
-- Description:	Create Tag and return that created tag
-- =============================================
CREATE PROCEDURE [dbo].[st_Create_Tag]
	@tag nvarchar(max)
AS
BEGIN
	insert into Tags (tag) values (@tag)

	select * from Tags where tag = @tag
END

GO
/****** Object:  StoredProcedure [dbo].[st_Delete_BlogPost]    Script Date: 09-Apr-20 2:06:59 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:		<Author,,Name>
-- Create date: <Create Date,,>
-- Description:	<Description,,>
-- =============================================
CREATE PROCEDURE [dbo].[st_Delete_BlogPost]
	@slug nvarchar(max)
AS
BEGIN
	delete from Posts where slug = @slug
END

GO
/****** Object:  StoredProcedure [dbo].[st_Delete_TagsFromPost]    Script Date: 09-Apr-20 2:06:59 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:		<Author,,Name>
-- Create date: <Create Date,,>
-- Description:	<Description,,>
-- =============================================
CREATE PROCEDURE [dbo].[st_Delete_TagsFromPost]
	@slug nvarchar(max)
AS
BEGIN
	delete from TagsForPost where FkPostId = (select PkPostId from Posts where slug = @slug)
END

GO
/****** Object:  StoredProcedure [dbo].[st_Get_MultipleBlogPosts]    Script Date: 09-Apr-20 2:06:59 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:		<Author,,Name>
-- Create date: <Create Date,,>
-- Description:	<Description,,>
-- =============================================
CREATE PROCEDURE [dbo].[st_Get_MultipleBlogPosts]
	@tag nvarchar(max) = null
AS
BEGIN


declare @tagID TABLE(tagInts bigint)

insert into @tagID select PkTagId from Tags where tag = isnull(@tag, tag)

DECLARE @listOfID TABLE(postInts bigint)

insert into @listOfID select PkPostId from Posts where PkPostId in (select FkPostId from TagsForPost where FkTagId in (select * from @tagID))

select slug, title, description, body, createdAt, updatedAt, 
	
	(select tag + '' as tag from Tags as t 
	
	where t.PkTagId in 
	
	(select tfp.FkTagId from TagsForPost as tfp 
	
	where tfp.FkPostId = p.PkPostId ) FOR XML PATH('')) as tags from Posts as p 
	
	where p.PkPostId in (select * from @listOfID)

	order by p.createdAt desc

--	select slug, title, description, body, createdAt, updatedAt
	
--	, COUNT(t.tag)
----	,(select tag + '' as tag from Tags as t where t.tag = ISNULL(@tag, t.tag) and t.PkTagId in (select tfp.FkTagId from TagsForPost as tfp where tfp.FkPostId = p.PkPostId ) FOR XML PATH('')) as tagsSum 
	
--	from Posts as p 

--	inner join TagsForPost as tfp on p.PkPostId = tfp.FkPostId
	
--	inner join Tags as t on tfp.FkTagId = t.PkTagId 

	
	--where t.tag = isnull(@tag, t.tag)

	--group by slug, title, description, body, createdAt, updatedAt

	--group by slug, title, description, body, createdAt, updatedAt
END

GO
/****** Object:  StoredProcedure [dbo].[st_Get_SingleBlogPost]    Script Date: 09-Apr-20 2:06:59 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:		Slobodan Kuzmanovic
-- Create date: <Create Date,,>
-- Description:	<Description,,>
-- =============================================
CREATE PROCEDURE [dbo].[st_Get_SingleBlogPost] 
	@slug nvarchar(max)
AS
BEGIN
	select slug, title, description, body, createdAt, updatedAt, 
	
	(select tag + '' as tag from Tags as t where t.PkTagId in (select tfp.FkTagId from TagsForPost as tfp where tfp.FkPostId = p.PkPostId ) FOR XML PATH('')) as tags from Posts as p 

	where slug = @slug
END

GO
/****** Object:  StoredProcedure [dbo].[st_Get_Tag]    Script Date: 09-Apr-20 2:06:59 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:		<Author,,Name>
-- Create date: <Create Date,,>
-- Description:	<Description,,>
-- =============================================
CREATE PROCEDURE [dbo].[st_Get_Tag]
	@tag nvarchar(max)
AS
BEGIN
	select * from Tags where tag = @tag
END

GO
/****** Object:  StoredProcedure [dbo].[st_Get_Tags]    Script Date: 09-Apr-20 2:06:59 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:		<Author,,Name>
-- Create date: <Create Date,,>
-- Description:	<Description,,>
-- =============================================
CREATE PROCEDURE [dbo].[st_Get_Tags]
	
AS
BEGIN
	select tag from Tags order by tag
END

GO
/****** Object:  StoredProcedure [dbo].[st_Update_BlogPost]    Script Date: 09-Apr-20 2:06:59 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:		<Author,,Name>
-- Create date: <Create Date,,>
-- Description:	<Description,,>
-- =============================================
CREATE PROCEDURE [dbo].[st_Update_BlogPost]
	@oldSlug nvarchar(max),
	@updatedAt datetime2(7),
	@slug nvarchar(max) = null,
	@title nvarchar(max) = null,
	@description nvarchar(max) = null,
	@body nvarchar(max) = null
AS
BEGIN
	
	update Posts 
	set
		slug = ISNULL(@slug, slug),
		title = ISNULL(@title, title),
		description = ISNULL(@description, description),
		body = ISNULL(@body, body),
		updatedAt = @updatedAt

		where slug = @oldSlug

END

GO
USE [master]
GO
ALTER DATABASE [BlogPost] SET  READ_WRITE 
GO
