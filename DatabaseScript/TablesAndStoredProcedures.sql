USE [DB_CMS]
GO
/****** Object:  Table [dbo].[CMSPage]    Script Date: 07/07/2020 9:14:18 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[CMSPage](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[Slug] [nvarchar](100) NOT NULL,
	[PTitle] [nvarchar](500) NULL,
	[PKeyword] [nvarchar](500) NULL,
	[PDescription] [nvarchar](500) NULL,
	[PageContent] [nvarchar](max) NULL,
	[IsActive] [bit] NOT NULL DEFAULT ((0)),
	[IsDelete] [bit] NOT NULL DEFAULT ((0)),
	[Create_On] [datetime] NOT NULL DEFAULT (getdate()),
	[Modify_On] [datetime] NOT NULL DEFAULT (getdate()),
PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON)
)

GO
/****** Object:  StoredProcedure [dbo].[AddPage]    Script Date: 07/07/2020 9:14:21 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROC [dbo].[AddPage]
@Id INT,
@Slug NVARCHAR(100),
@PTitle  NVARCHAR(500),
@PKeyword  NVARCHAR(500),
@PDescription  NVARCHAR(500),
@PageContent NVARCHAR(max),
@IsActive bit=0,
@IsDelete bit=0
AS
IF NOT EXISTS (SELECT * FROM CMSPage WHERE Slug=@Slug)
BEGIN
INSERT INTO CMSPage (Slug,PTitle,PKeyword,PDescription,PageContent,IsActive,IsDelete)
VALUES (@Slug,@PTitle,@PKeyword,@PDescription,@PageContent,@IsActive,@IsDelete)
SELECT @@IDENTITY
END

GO
/****** Object:  StoredProcedure [dbo].[DeletePageById]    Script Date: 07/07/2020 9:14:21 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE proc [dbo].[DeletePageById]  
@Id bigint,
@Result VARCHAR(50) OUTPUT    
as    
if EXISTS (select * from CMSPage where Id=@Id)    
begin    
delete CMSPage where Id=@Id    
SET @Result='deleted'   
end 
GO
/****** Object:  StoredProcedure [dbo].[EditPage]    Script Date: 07/07/2020 9:14:21 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROC [dbo].[EditPage]
@Id INT,
@Slug NVARCHAR(100),
@PTitle  NVARCHAR(500),
@PKeyword  NVARCHAR(500),
@PDescription  NVARCHAR(500),
@PageContent NVARCHAR(max),
@IsActive bit=0,
@IsDelete bit=0,
@Result VARCHAR(50) OUTPUT
AS
IF EXISTS (SELECT * FROM CMSPage WHERE Id=@Id)
BEGIN
UPDATE CMSPage SET Slug=@Slug, PTitle=@PTitle, PKeyword=@PKeyword, PDescription=@PDescription
,PageContent=@PageContent, IsActive=@IsActive, IsDelete=@IsDelete,Modify_On=GETDATE()
WHERE Id=@Id
SET @Result='Edited Successful'
END
GO
/****** Object:  StoredProcedure [dbo].[FetchAllPages]    Script Date: 07/07/2020 9:14:21 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROC [dbo].[FetchAllPages]
AS
SELECT Id, Slug, PTitle, PKeyword, PDescription, PageContent, IsActive, IsDelete, Create_On, Modify_On
FROM CMSPage order by Modify_On DESC

GO
/****** Object:  StoredProcedure [dbo].[FetchPageById]    Script Date: 07/07/2020 9:14:21 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROC [dbo].[FetchPageById]
@Id INT
AS
SELECT Id, Slug, PTitle, PKeyword, PDescription, PageContent, IsActive, IsDelete, Create_On, Modify_On
FROM CMSPage WHERE ID=@Id

GO
/****** Object:  StoredProcedure [dbo].[FetchPageBySlug]    Script Date: 07/07/2020 9:14:21 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROC [dbo].[FetchPageBySlug]
@Slug  NVARCHAR(100) 
AS
SELECT Id, Slug, PTitle, PKeyword, PDescription, PageContent, IsActive, IsDelete, Create_On, Modify_On
FROM CMSPage WHERE Slug=@Slug

GO
/****** Object:  StoredProcedure [dbo].[FetchPageInfoById]    Script Date: 07/07/2020 9:14:21 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROC [dbo].[FetchPageInfoById]
@Id INT
AS
SELECT *
FROM CMSPage WHERE ID=@Id

GO
/****** Object:  StoredProcedure [dbo].[InsertPage]    Script Date: 07/07/2020 9:14:21 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROC [dbo].[InsertPage]
@Id INT,
@Slug NVARCHAR(100),
@PTitle  NVARCHAR(500),
@PKeyword  NVARCHAR(500),
@PDescription  NVARCHAR(500),
@PageContent NVARCHAR(max),
@IsActive bit=0,
@IsDelete bit=0,
@Result VARCHAR(50) OUTPUT,
@CreatedId INT OUTPUT    
AS
IF NOT EXISTS (SELECT * FROM CMSPage WHERE Slug=@Slug)
BEGIN
INSERT INTO CMSPage (Slug,PTitle,PKeyword,PDescription,PageContent,IsActive,IsDelete)
VALUES (@Slug,@PTitle,@PKeyword,@PDescription,@PageContent,@IsActive,@IsDelete)
SET @Result='Insert Successful'
SET @CreatedId=@@IDENTITY
END
GO
/****** Object:  StoredProcedure [dbo].[UpdatePage]    Script Date: 07/07/2020 9:14:21 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROC [dbo].[UpdatePage]
@Id INT,
@Slug NVARCHAR(100),
@PTitle  NVARCHAR(500),
@PKeyword  NVARCHAR(500),
@PDescription  NVARCHAR(500),
@PageContent NVARCHAR(max),
@IsActive bit=0,
@IsDelete bit=0
AS
IF EXISTS (SELECT * FROM CMSPage WHERE Id=@Id)
BEGIN
UPDATE CMSPage SET Slug=@Slug, PTitle=@PTitle, PKeyword=@PKeyword, PDescription=@PDescription
,PageContent=@PageContent, IsActive=@IsActive, IsDelete=@IsDelete,Modify_On=GETDATE()
WHERE Id=@Id
Select @Id
END
GO
