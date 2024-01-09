USE [jaziradb]
GO
/****** Object:  User [admin]    Script Date: 03/10/2021 08:32:15 ******/
CREATE USER [admin] WITHOUT LOGIN WITH DEFAULT_SCHEMA=[dbo]
GO
/****** Object:  User [jazira]    Script Date: 03/10/2021 08:32:15 ******/
CREATE USER [jazira] WITHOUT LOGIN WITH DEFAULT_SCHEMA=[dbo]
GO
/****** Object:  ApplicationRole [grant]    Script Date: 03/10/2021 08:32:15 ******/
/* To avoid disclosure of passwords, the password is generated in script. */
declare @idx as int
declare @randomPwd as nvarchar(64)
declare @rnd as float
select @idx = 0
select @randomPwd = N''
select @rnd = rand((@@CPU_BUSY % 100) + ((@@IDLE % 100) * 100) + 
       (DATEPART(ss, GETDATE()) * 10000) + ((cast(DATEPART(ms, GETDATE()) as int) % 100) * 1000000))
while @idx < 64
begin
   select @randomPwd = @randomPwd + char((cast((@rnd * 83) as int) + 43))
   select @idx = @idx + 1
select @rnd = rand()
end
declare @statement nvarchar(4000)
select @statement = N'CREATE APPLICATION ROLE [grant] WITH DEFAULT_SCHEMA = [dbo], ' + N'PASSWORD = N' + QUOTENAME(@randomPwd,'''')
EXEC dbo.sp_executesql @statement
GO
/****** Object:  ApplicationRole [role]    Script Date: 03/10/2021 08:32:15 ******/
/* To avoid disclosure of passwords, the password is generated in script. */
declare @idx as int
declare @randomPwd as nvarchar(64)
declare @rnd as float
select @idx = 0
select @randomPwd = N''
select @rnd = rand((@@CPU_BUSY % 100) + ((@@IDLE % 100) * 100) + 
       (DATEPART(ss, GETDATE()) * 10000) + ((cast(DATEPART(ms, GETDATE()) as int) % 100) * 1000000))
while @idx < 64
begin
   select @randomPwd = @randomPwd + char((cast((@rnd * 83) as int) + 43))
   select @idx = @idx + 1
select @rnd = rand()
end
declare @statement nvarchar(4000)
select @statement = N'CREATE APPLICATION ROLE [role] WITH DEFAULT_SCHEMA = [dbo], ' + N'PASSWORD = N' + QUOTENAME(@randomPwd,'''')
EXEC dbo.sp_executesql @statement
GO
/****** Object:  FullTextCatalog [pk_GoldTypeId]    Script Date: 03/10/2021 08:32:15 ******/
CREATE FULLTEXT CATALOG [pk_GoldTypeId]WITH ACCENT_SENSITIVITY = ON
AUTHORIZATION [dbo]
GO
/****** Object:  Table [dbo].[Tbl_StoneShapeCUT]    Script Date: 03/10/2021 08:32:06 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[Tbl_StoneShapeCUT](
	[StoneCUTId] [int] IDENTITY(1,1) NOT NULL,
	[StoneCUTCode] [int] NULL,
	[StoneShapeCUTName] [nvarchar](200) NULL,
	[Status] [char](1) NULL,
	[LoginId] [int] NULL,
	[LogDateTime] [datetime] NULL,
 CONSTRAINT [PK_Tbl_StoneShapeCUT] PRIMARY KEY CLUSTERED 
(
	[StoneCUTId] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[Tbl_StoneShape]    Script Date: 03/10/2021 08:32:06 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[Tbl_StoneShape](
	[StoneShapeId] [int] IDENTITY(1,1) NOT NULL,
	[StoneShapeCode] [int] NULL,
	[StoneShapeName] [nvarchar](255) NULL,
	[Status] [char](1) NULL,
	[LoginId] [int] NULL,
	[LogDateTime] [datetime] NULL,
 CONSTRAINT [PK_Tbl_StoneShape] PRIMARY KEY CLUSTERED 
(
	[StoneShapeId] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[Tbl_StoneColor]    Script Date: 03/10/2021 08:32:06 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[Tbl_StoneColor](
	[StoneColorId] [int] IDENTITY(1,1) NOT NULL,
	[StoneColorCode] [int] NULL,
	[StoneColorName] [nvarchar](255) NULL,
	[Status] [char](1) NULL,
	[LoginId] [int] NULL,
	[LogDateTime] [datetime] NULL,
 CONSTRAINT [PK_Tbl_StoneColor] PRIMARY KEY CLUSTERED 
(
	[StoneColorId] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[Tbl_StoneClearity]    Script Date: 03/10/2021 08:32:06 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[Tbl_StoneClearity](
	[StoneClearityId] [int] IDENTITY(1,1) NOT NULL,
	[StoneClearityCode] [int] NULL,
	[StoneClearityName] [nvarchar](255) NULL,
	[Status] [char](1) NULL,
	[LoginId] [int] NULL,
	[LogDateTime] [datetime] NULL,
 CONSTRAINT [PK_Tbl_StoneClearity] PRIMARY KEY CLUSTERED 
(
	[StoneClearityId] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[Tbl_SerialMaster]    Script Date: 03/10/2021 08:32:06 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[Tbl_SerialMaster](
	[SerialMasterId] [int] IDENTITY(1,1) NOT NULL,
	[SafeNo] [int] NULL,
	[SerialNo] [int] NULL,
	[FirstLetter] [char](10) NULL,
	[NextSerialNo] [int] NULL,
	[Status] [char](1) NULL,
	[LoginId] [int] NULL,
	[LogDateTime] [datetime] NULL,
 CONSTRAINT [PK_Tbl_SrialMaster] PRIMARY KEY CLUSTERED 
(
	[SerialMasterId] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[Tbl_Section]    Script Date: 03/10/2021 08:32:06 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[Tbl_Section](
	[SectionId] [int] IDENTITY(1,1) NOT NULL,
	[SectionCode] [int] NOT NULL,
	[SectionName] [nvarchar](255) NULL,
	[Status] [char](1) NULL,
	[LoginId] [int] NULL,
	[LogDateTime] [datetime] NULL,
 CONSTRAINT [PK_Tbl_Section_1] PRIMARY KEY CLUSTERED 
(
	[SectionCode] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[Tbl_SalaryType]    Script Date: 03/10/2021 08:32:06 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[Tbl_SalaryType](
	[SalaryTypeId] [int] IDENTITY(1,1) NOT NULL,
	[SalaryTypeCode] [int] NOT NULL,
	[SalaryTypeName] [nvarchar](250) NULL,
	[Status] [char](1) NULL,
	[LoginId] [int] NULL,
	[LogDateTime] [datetime] NULL,
 CONSTRAINT [PK_Tbl_SalaryType_1] PRIMARY KEY CLUSTERED 
(
	[SalaryTypeCode] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[Tbl_MasterOrnament]    Script Date: 03/10/2021 08:32:06 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[Tbl_MasterOrnament](
	[MasterOrnamentId] [int] IDENTITY(1,1) NOT NULL,
	[OrnamentCode] [int] NULL,
	[MasterOrnamentName] [nvarchar](255) NULL,
	[Status] [char](1) NULL,
	[LoginId] [int] NULL,
	[LogDateTime] [datetime] NULL,
 CONSTRAINT [PK_Tbl_Ornament] PRIMARY KEY CLUSTERED 
(
	[MasterOrnamentId] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[Tbl_WorkingSection]    Script Date: 03/10/2021 08:32:06 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[Tbl_WorkingSection](
	[WorkingSectionId] [int] IDENTITY(1,1) NOT NULL,
	[WorkingSectionCode] [int] NULL,
	[WorkingSectionName] [nvarchar](255) NULL,
	[Status] [char](1) NULL,
	[LoginId] [int] NULL,
	[LogDateTime] [datetime] NULL,
 CONSTRAINT [PK_Tbl_WorkingSection] PRIMARY KEY CLUSTERED 
(
	[WorkingSectionId] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[Tbl_UserType]    Script Date: 03/10/2021 08:32:06 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[Tbl_UserType](
	[UserTypeId] [int] IDENTITY(1,1) NOT NULL,
	[UserTypeName] [nvarchar](255) NOT NULL,
	[Status] [char](1) NOT NULL,
	[LoginId] [int] NOT NULL,
	[LogDateTime] [datetime] NOT NULL,
 CONSTRAINT [PK_Tbl_UserType] PRIMARY KEY CLUSTERED 
(
	[UserTypeId] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[Tbl_UserPermission]    Script Date: 03/10/2021 08:32:06 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[Tbl_UserPermission](
	[PurmissionId] [int] IDENTITY(1,1) NOT NULL,
	[UserId] [int] NOT NULL,
	[FormId] [int] NULL,
	[FormCode] [int] NULL,
	[NewAllow] [bit] NULL,
	[ViewAllow] [bit] NULL,
	[DeleteAllow] [bit] NULL,
	[PrintAllow] [bit] NULL,
	[Status] [char](1) NOT NULL,
	[LoginId] [int] NOT NULL,
	[LogDateTime] [datetime] NOT NULL,
 CONSTRAINT [PK_Tbl_UserPermission] PRIMARY KEY CLUSTERED 
(
	[PurmissionId] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[Tbl_UserLoginStatus]    Script Date: 03/10/2021 08:32:06 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[Tbl_UserLoginStatus](
	[UserId] [int] NULL,
	[LoginDateTime] [datetime] NOT NULL,
	[LogOutDateTime] [datetime] NULL,
	[Status] [char](1) NOT NULL,
	[LoginCount] [int] NULL
) ON [PRIMARY]
GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[Tbl_GoldType]    Script Date: 03/10/2021 08:32:06 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[Tbl_GoldType](
	[GoldTypeId] [int] IDENTITY(1,1) NOT NULL,
	[GoldTypeCode] [int] NOT NULL,
	[GoldTypeName] [nvarchar](255) NULL,
	[Status] [char](1) NULL,
	[LoginId] [int] NULL,
	[LogDateTime] [datetime] NULL,
 CONSTRAINT [PK_Tbl_GoldType_1] PRIMARY KEY CLUSTERED 
(
	[GoldTypeCode] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[Tbl_Form]    Script Date: 03/10/2021 08:32:06 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[Tbl_Form](
	[FormId] [int] IDENTITY(1,1) NOT NULL,
	[DisplayName] [nvarchar](255) NOT NULL,
	[PagenName] [nvarchar](255) NOT NULL,
	[FormCode] [int] NOT NULL,
	[Status] [char](1) NOT NULL,
	[LoginId] [int] NOT NULL,
	[LogDateTime] [datetime] NOT NULL,
 CONSTRAINT [PK_Tbl_Form] PRIMARY KEY CLUSTERED 
(
	[FormId] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[Tbl_GroupCodeO]    Script Date: 03/10/2021 08:32:06 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[Tbl_GroupCodeO](
	[GroupCodeOId] [int] IDENTITY(1,1) NOT NULL,
	[GroupNo] [int] NULL,
	[DelCode] [nvarchar](50) NULL,
	[RecCode] [nvarchar](50) NULL,
	[Status] [char](1) NULL,
	[LoginId] [int] NULL,
	[LogDateTime] [datetime] NULL,
 CONSTRAINT [PK_Tbl_GourpCodeO] PRIMARY KEY CLUSTERED 
(
	[GroupCodeOId] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[Tbl_TypeMaster]    Script Date: 03/10/2021 08:32:06 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[Tbl_TypeMaster](
	[TypeMastId] [int] IDENTITY(1,1) NOT NULL,
	[TypeCodee] [nvarchar](255) NOT NULL,
	[TypeDescription] [nvarchar](255) NOT NULL,
	[TypePricePC] [decimal](18, 2) NULL,
	[TypeCarat] [decimal](18, 2) NULL,
	[TypeDWL] [bit] NULL,
	[TypeRWL] [bit] NULL,
	[TypeStone] [bit] NULL,
	[TypeSize] [nvarchar](255) NULL,
	[TypeEntryDate] [datetime] NULL,
	[StoneColorId] [int] NULL,
	[StoneCUTId] [int] NULL,
	[StoneShapeId] [int] NULL,
	[StoneClearityId] [int] NULL,
	[RPTColumnD] [nvarchar](255) NULL,
	[RPTColumnR] [nvarchar](255) NULL,
	[WeightPC] [decimal](18, 2) NULL,
	[ROL] [decimal](18, 2) NULL,
	[TypeDelCharge] [bit] NULL,
	[TypeRecChage] [bit] NULL,
	[Stype] [nvarchar](255) NULL,
	[Status] [char](1) NULL,
	[LoginId] [int] NULL,
	[LogDateTime] [datetime] NULL,
 CONSTRAINT [PK_Tbl_TypeMaster] PRIMARY KEY CLUSTERED 
(
	[TypeMastId] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
SET ANSI_PADDING OFF
GO
/****** Object:  StoredProcedure [dbo].[Sp_WorkingSection]    Script Date: 03/10/2021 08:32:15 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE Proc [dbo].[Sp_WorkingSection]
(
	@WorkingSectionId	int=0,
	@WorkingSectionCode	int=0,
	@WorkingSectionName	nvarchar(255)='',
	@Status			char(1)='A',
	@LoginId		int=0,
	@LogDateTime	datetime,
	@Mode			char(2)
)as 
Begin
if(@Mode='I')
Begin
	Insert Into Tbl_WorkingSection (WorkingSectionCode, WorkingSectionName ,Status,LoginId ,LogDateTime)
				   Values(@WorkingSectionCode, @WorkingSectionName  ,@Status,@loginId,GETDATE())
				   SET @WorkingSectionId=SCOPE_IDENTITY()
End

if(@Mode='U')
Begin
	Update Tbl_WorkingSection   Set WorkingSectionCode=@WorkingSectionCode, WorkingSectionName=@WorkingSectionName  ,Status =@Status ,LoginId =@LoginId ,LogDateTime=GETDATE()
	Where WorkingSectionId =@WorkingSectionId
End


if(@Mode='D')
Begin
	declare @WSId as int
	select count(WorkingSectionId) from Tbl_WorkingSection
	set @WSId=@WorkingSectionId;
	
	Delete Tbl_WorkingSection    Where WorkingSectionId =@WorkingSectionId DBCC CHECKIDENT (Tbl_WorkingSection, RESEED,@WorkingSectionCode) 
End
end
GO
/****** Object:  StoredProcedure [dbo].[Sp_UserType]    Script Date: 03/10/2021 08:32:15 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE Proc [dbo].[Sp_UserType]
(
	@UserTypeId			int=0,
	@UserTypeName		nvarchar(255)='',
	@Status				char(1)='A',
	@LoginId			int=0,
	@LogDateTime		datetime,
	@Mode				char(2)
)
as 
	
Begin
if(@Mode='I')
Begin
	Insert Into Tbl_UserType(UserTypeName,Status,LoginId ,LogDateTime)
				Values(@UserTypeName  ,@Status,@LoginId,getdate());
				
End

if(@Mode='U')
Begin
	Update Tbl_UserType Set UserTypeName=@UserTypeName,Status=@Status ,LoginId =@LoginId ,LogDateTime=@LogDateTime
	Where UserTypeId=@UserTypeId 
End

if(@Mode='CP')
Begin
	Update Tbl_UserType  Set  UserTypeName =@UserTypeName ,LogDateTime=@LogDateTime
	Where UserTypeId =@UserTypeId 
End

if(@Mode='D')
Begin
	Delete from Tbl_UserType  
	 Where UserTypeId=@UserTypeId 
End
end
GO
/****** Object:  Table [dbo].[Tbl_UserGroup]    Script Date: 03/10/2021 08:32:06 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[Tbl_UserGroup](
	[UserGroupId] [int] IDENTITY(1,1) NOT NULL,
	[UserGroupName] [nvarchar](255) NOT NULL,
	[UserTypeId] [int] NOT NULL,
	[Status] [char](1) NOT NULL,
	[LoginId] [int] NOT NULL,
	[LogDateTime] [datetime] NOT NULL,
 CONSTRAINT [PK_Tbl_UserGroup] PRIMARY KEY CLUSTERED 
(
	[UserGroupId] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
SET ANSI_PADDING OFF
GO
/****** Object:  StoredProcedure [dbo].[Sp_StoneShapeCUT]    Script Date: 03/10/2021 08:32:14 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE Proc [dbo].[Sp_StoneShapeCUT]
(
	@StoneCUTId			int=0,
	@StoneCUTCode		int=0,
	@StoneShapeCUTName	nvarchar(255)='',
	@Status				char(1)='A',
	@LoginId			int=0,
	@LogDateTime		datetime,
	@Mode				char(2)
)as 
Begin
if(@Mode='I')
Begin
	Insert Into Tbl_StoneShapeCUT (StoneCUTCode, StoneShapeCUTName ,Status,LoginId ,LogDateTime)
				   Values(@StoneCUTCode, @StoneShapeCUTName  ,@Status,@loginId,GETDATE())
				   SET @StoneCUTId=SCOPE_IDENTITY()
End

if(@Mode='U')
Begin
	Update Tbl_StoneShapeCUT   Set StoneCUTCode=@StoneCUTCode, StoneShapeCUTName  =@StoneShapeCUTName  ,Status =@Status ,LoginId =@LoginId ,LogDateTime=GETDATE()
	Where StoneCUTId =@StoneCUTId
End

if(@Mode='CP')
Begin
	Update Tbl_StoneShapeCUT Set  StoneCUTCode=@StoneCUTCode, StoneShapeCUTName  =@StoneShapeCUTName   ,LogDateTime=GETDATE()
	Where StoneCUTId  =@StoneCUTId  
End

if(@Mode='D')
Begin
	declare @StoneSCId as int
	select count(StoneCUTId) from Tbl_StoneShapeCUT
	set @StoneSCId=@StoneCUTId;
	Delete Tbl_StoneShapeCUT    Where StoneCUTId =@StoneCUTId DBCC CHECKIDENT (Tbl_StoneShapeCUT, RESEED,@StoneCUTId) 
End
end
GO
/****** Object:  StoredProcedure [dbo].[Sp_StoneShape]    Script Date: 03/10/2021 08:32:14 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE Proc [dbo].[Sp_StoneShape]
(
	@StoneShapeId		int=0,
	@StoneShapeCode		int=0,
	@StoneShapeName		nvarchar(255)='',
	@Status				char(1)='A',
	@LoginId			int=0,
	@LogDateTime		datetime,
	@Mode				char(2)
)as 
Begin
if(@Mode='I')
Begin
	Insert Into Tbl_StoneShape (StoneShapeCode, StoneShapeName ,Status,LoginId ,LogDateTime)
				   Values(@StoneShapeCode, @StoneShapeName  ,@Status,@loginId,GETDATE())
				   SET @StoneShapeId=SCOPE_IDENTITY()
End

if(@Mode='U')
Begin
	Update Tbl_StoneShape   Set StoneShapeCode=@StoneShapeCode, StoneShapeName  =@StoneShapeName  ,Status =@Status ,LoginId =@LoginId ,LogDateTime=GETDATE()
	Where StoneShapeId =@StoneShapeId
End

if(@Mode='CP')
Begin
	Update Tbl_StoneShape  Set  StoneShapeCode=@StoneShapeCode, StoneShapeName  =@StoneShapeName   ,LogDateTime=GETDATE()
	Where StoneShapeId  =@StoneShapeId  
End

if(@Mode='D')
Begin
	declare @StoneId as int
	select count(StoneShapeId) from Tbl_StoneShape
	set @StoneId=@StoneShapeId;
	Delete Tbl_StoneShape    Where StoneShapeId =@StoneShapeId DBCC CHECKIDENT (Tbl_StoneShape, RESEED,@StoneShapeId) 
End
end
GO
/****** Object:  StoredProcedure [dbo].[Sp_StoneColor]    Script Date: 03/10/2021 08:32:14 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE Proc [dbo].[Sp_StoneColor]
(
	@StoneColorId		int=0,
	@StoneColorCode		int=0,
	@StoneColorName		nvarchar(255)='',
	@Status				char(1)='A',
	@LoginId			int=0,
	@LogDateTime		datetime,
	@Mode				char(2)
)as 
Begin
if(@Mode='I')
Begin
	Insert Into Tbl_StoneColor (StoneColorCode, StoneColorName ,Status,LoginId ,LogDateTime)
				   Values(@StoneColorCode, @StoneColorName  ,@Status,@loginId,GETDATE())
				   SET @StoneColorId=SCOPE_IDENTITY()
End

if(@Mode='U')
Begin
	Update Tbl_StoneColor   Set StoneColorCode=@StoneColorCode, StoneColorName  =@StoneColorName  ,Status =@Status ,LoginId =@LoginId ,LogDateTime=GETDATE()
	Where StoneColorId =@StoneColorId
End

if(@Mode='CP')
Begin
	Update Tbl_StoneColor Set StoneColorCode=@StoneColorCode,  StoneColorName  =@StoneColorName   ,LogDateTime=GETDATE()
	Where StoneColorId  =@StoneColorId  
End

if(@Mode='D')
Begin
	declare @StoneCId as int
	select count(StoneColorId) from Tbl_StoneColor
	set @StoneCId=@StoneColorId;
	Delete Tbl_StoneColor    Where StoneColorId =@StoneColorId DBCC CHECKIDENT (Tbl_StoneColor, RESEED,@StoneColorId) 
End
end
GO
/****** Object:  StoredProcedure [dbo].[Sp_StoneClearity]    Script Date: 03/10/2021 08:32:14 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE Proc [dbo].[Sp_StoneClearity]
(
	@StoneClearityId		int=0,
	@StoneClearityCode		int=0,
	@StoneClearityName		nvarchar(255)='',
	@Status					char(1)='A',
	@LoginId				int=0,
	@LogDateTime			datetime,
	@Mode					char(2)
)as 
Begin
if(@Mode='I')
Begin
	Insert Into Tbl_StoneClearity (StoneClearityCode, StoneClearityName ,Status,LoginId ,LogDateTime)
				   Values(@StoneClearityCode, @StoneClearityName  ,@Status,@loginId,GETDATE())
				   SET @StoneClearityId=SCOPE_IDENTITY()
End

if(@Mode='U')
Begin
	Update Tbl_StoneClearity   Set StoneClearityCode=@StoneClearityCode, StoneClearityName  =@StoneClearityName  ,Status =@Status ,LoginId =@LoginId ,LogDateTime=GETDATE()
	Where StoneClearityId =@StoneClearityId
End

if(@Mode='CP')
Begin
	Update Tbl_StoneClearity Set  StoneClearityCode=@StoneClearityCode, StoneClearityName  =@StoneClearityName   ,LogDateTime=GETDATE()
	Where StoneClearityId  =@StoneClearityId  
End

if(@Mode='D')
Begin
	declare @SClearId as int
	select count(StoneClearityId) from Tbl_StoneClearity
	set @SClearId=@StoneClearityId;
	Delete Tbl_StoneClearity    Where StoneClearityId =@StoneClearityId DBCC CHECKIDENT (Tbl_StoneClearity, RESEED,@StoneClearityId) 
End
end
GO
/****** Object:  StoredProcedure [dbo].[Sp_ShowGoldId]    Script Date: 03/10/2021 08:32:14 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE Proc [dbo].[Sp_ShowGoldId]
(
	@GoldTypeId			int OUT,
	@GoldTypeName		nvarchar(255)out,
	@Mode				char(2)
)as 
Begin
if(@Mode='SW')
Begin
	SET NOCOUNT ON;
	Insert Into Tbl_GoldType (GoldTypeName) Values(@GoldTypeName)
	SET	@GoldTypeId=SCOPE_IDENTITY();
End
end
GO
/****** Object:  StoredProcedure [dbo].[Sp_SerialMaster]    Script Date: 03/10/2021 08:32:14 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE Proc [dbo].[Sp_SerialMaster]
(
	@SerialMasterId		int=0,
	@SafeNo				int=0,
	@SerialNo			int=0,
	@FirstLetter		char(10)='',
	@NextSerialNo		int=0,
	@Status				char(1)='A',
	@LoginId			int=0,
	@LogDateTime		datetime,
	@Mode				char(2)
)as 
Begin
if(@Mode='I')
Begin
	Insert Into Tbl_SerialMaster (SafeNo, SerialNo,FirstLetter,NextSerialNo ,Status,LoginId ,LogDateTime)
				   Values(@SafeNo, @SerialNo,@FirstLetter,@NextSerialNo ,@Status,@loginId,GETDATE())
				   SET @SerialMasterId=SCOPE_IDENTITY()
End

if(@Mode='U')
Begin
	Update Tbl_SerialMaster   Set SafeNo=@SafeNo, SerialNo=@SerialNo,FirstLetter=@FirstLetter,NextSerialNo=@NextSerialNo ,Status =@Status ,LoginId =@LoginId ,LogDateTime=GETDATE()
	Where SerialMasterId =@SerialMasterId
End

if(@Mode='CP')
Begin
	Update Tbl_SerialMaster  Set SafeNo=@SafeNo,LogDateTime=GETDATE()
	Where SerialMasterId  =@SerialMasterId  
End

if(@Mode='D')
Begin
	declare @SMId as int
	select count(SerialMasterId) from Tbl_SerialMaster
	set @SMId=@SerialMasterId;
	Delete Tbl_SerialMaster    Where SerialMasterId =@SerialMasterId DBCC CHECKIDENT (Tbl_SerialMaster, RESEED,@SerialMasterId) 
End
end
GO
/****** Object:  StoredProcedure [dbo].[Sp_Section]    Script Date: 03/10/2021 08:32:14 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE Proc [dbo].[Sp_Section]
(
	@SectionId		int=0,
	@SectionCode	int=0,
	@SectionName	nvarchar(255)='',
	@Status			char(1)='A',
	@LoginId		int=0,
	@LogDateTime	datetime,
	@Mode			char(2)
)as 
Begin
if(@Mode='I')
Begin
	Insert Into Tbl_Section (SectionCode, SectionName ,Status,LoginId ,LogDateTime)
				   Values(@SectionCode, @SectionName  ,@Status,@loginId,GETDATE())
				   SET @SectionId=SCOPE_IDENTITY()
End

if(@Mode='U')
Begin
	Update Tbl_Section   Set SectionCode=@SectionCode, SectionName  =@SectionName  ,Status =@Status ,LoginId =@LoginId ,LogDateTime=GETDATE()
	Where SectionId =@SectionId
End

if(@Mode='CP')
Begin
	Update Tbl_Section  Set SectionCode=@SectionCode,  SectionName  =@SectionName   ,LogDateTime=GETDATE()
	Where SectionId  =@SectionId  
End

if(@Mode='D')
Begin
	declare @SId as int
	select count(SectionId) from Tbl_Section
	set @SId=@SectionId;
	Delete Tbl_Section    Where SectionId =@SectionId DBCC CHECKIDENT (Tbl_Section, RESEED,@SectionCode) 
End
end
GO
/****** Object:  StoredProcedure [dbo].[Sp_SalaryType]    Script Date: 03/10/2021 08:32:14 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE Proc [dbo].[Sp_SalaryType]
(
	@SalaryTypeId		int=0,
	@SalaryTypeCode		int=0,
	@SalaryTypeName		nvarchar(255)='',
	@Status				char(1)='A',
	@LoginId			int=0,
	@LogDateTime		datetime,
	@Mode				char(2)
)as 
Begin
if(@Mode='I')
Begin
	Insert Into Tbl_SalaryType (SalaryTypeCode, SalaryTypeName ,Status,LoginId ,LogDateTime)
				   Values(@SalaryTypeCode, @SalaryTypeName  ,@Status,@loginId,GETDATE())
				   SET @SalaryTypeId=SCOPE_IDENTITY()
End

if(@Mode='U')
Begin
	Update Tbl_SalaryType   Set SalaryTypeCode=@SalaryTypeCode, SalaryTypeName  =@SalaryTypeName  ,Status =@Status ,LoginId =@LoginId ,LogDateTime=GETDATE()
	Where SalaryTypeId =@SalaryTypeId
End

if(@Mode='CP')
Begin
	Update Tbl_SalaryType  Set  SalaryTypeCode=@SalaryTypeCode, SalaryTypeName  =@SalaryTypeName   ,LogDateTime=GETDATE()
	Where SalaryTypeId  =@SalaryTypeId  
End

if(@Mode='D')
Begin
	declare @SalId as int
	select count(SalaryTypeId) from Tbl_SalaryType
	set @SalId=@SalaryTypeId;
	Delete Tbl_SalaryType    Where SalaryTypeId =@SalaryTypeId DBCC CHECKIDENT (Tbl_SalaryType, RESEED,@SalaryTypeId) 
End
end
GO
/****** Object:  StoredProcedure [dbo].[Sp_MasterOrnament]    Script Date: 03/10/2021 08:32:14 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE Proc [dbo].[Sp_MasterOrnament]
(
	@MasterOrnamentId		int=0,
	@OrnamentCode			int=0,
	@MasterOrnamentName		nvarchar(255)='',
	@Status					char(1)='A',
	@LoginId				int=0,
	@LogDateTime			datetime,
	@Mode					char(2)
)as 
Begin
if(@Mode='I')
Begin
	Insert Into Tbl_MasterOrnament (OrnamentCode, MasterOrnamentName ,Status,LoginId ,LogDateTime)
				   Values(@OrnamentCode, @MasterOrnamentName  ,@Status,@loginId,GETDATE())
				   SET @MasterOrnamentId=SCOPE_IDENTITY()
End

if(@Mode='U')
Begin
	Update Tbl_MasterOrnament   Set OrnamentCode=@OrnamentCode, MasterOrnamentName  =@MasterOrnamentName  ,Status =@Status ,LoginId =@LoginId ,LogDateTime=GETDATE()
	Where MasterOrnamentId =@MasterOrnamentId
End

if(@Mode='CP')
Begin
	Update Tbl_MasterOrnament Set OrnamentCode=@OrnamentCode,  MasterOrnamentName  =@MasterOrnamentName   ,LogDateTime=GETDATE()
	Where MasterOrnamentId  =@MasterOrnamentId  
End

if(@Mode='D')
Begin
	declare @MOId as int
	select count(MasterOrnamentId) from Tbl_MasterOrnament
	set @MOId=@MasterOrnamentId;
	Delete Tbl_MasterOrnament    Where MasterOrnamentId =@MasterOrnamentId DBCC CHECKIDENT (Tbl_MasterOrnament, RESEED,@MasterOrnamentId) 
End
end
GO
/****** Object:  StoredProcedure [dbo].[Sp_FormMaster]    Script Date: 03/10/2021 08:32:13 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE Proc [dbo].[Sp_FormMaster]
(
	@FormId			int=0,
	@DisplayName	nvarchar(255)='',
	@PagenName		nvarchar(255)='',
	@FormCode		int=0,
	@Status			char(1)='A',
	@LoginId		int=0,
	@LogDateTime	datetime,
	@Mode			char(2)
)as 
Begin
if(@Mode='I')
Begin
	Insert Into Tbl_Form (DisplayName, PagenName,FormCode ,Status,LoginId ,LogDateTime)
				   Values(@DisplayName, @PagenName,@FormCode  ,@Status,@loginId,GETDATE())
				   SET @FormId=SCOPE_IDENTITY()
End

if(@Mode='U')
Begin
	Update Tbl_Form   Set DisplayName=@DisplayName, PagenName=@PagenName,FormCode=@FormCode ,Status =@Status ,LoginId =@LoginId ,LogDateTime=GETDATE()
	Where FormId =@FormId
End

if(@Mode='CP')
Begin
	Update Tbl_Form  Set FormCode=@FormCode   ,LogDateTime=GETDATE()
	Where FormId  =@FormId  
End

if(@Mode='D')
Begin
	--declare @SId as int
	--select count(SectionId) from Tbl_Section
	--set @SId=@SectionId;
	Delete Tbl_Form    Where FormId =@FormId; --DBCC CHECKIDENT (Tbl_Section, RESEED,@SectionCode) 
End
end
GO
/****** Object:  StoredProcedure [dbo].[Sp_Form]    Script Date: 03/10/2021 08:32:13 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE Proc [dbo].[Sp_Form]
(
	@FormId			int=0,
	@DisplayName	nvarchar(255)='',
	@PagenName		nvarchar(255)='',
	@FormCode		int=0,
	@Status			char(1)='A',
	@LoginId		int=0,
	@LogDateTime	datetime,
	@Mode			char(2)
)as 
Begin
if(@Mode='I')
Begin
	Insert Into Tbl_Form (PagenName, DisplayName,FormCode ,Status,LoginId ,LogDateTime)
				   Values(@PagenName, @DisplayName,@FormCode  ,@Status,@loginId,GETDATE())
				   SET @FormId=SCOPE_IDENTITY()
End

if(@Mode='U')
Begin
	Update Tbl_Form   Set PagenName=@PagenName, DisplayName=@DisplayName,FormCode=@FormCode  ,Status =@Status ,LoginId =@LoginId ,LogDateTime=GETDATE()
	Where FormId =@FormId
End

if(@Mode='CP')
Begin
	Update Tbl_Form  Set FormCode=@FormCode  ,LogDateTime=GETDATE()
	Where FormId  =@FormId  
End

if(@Mode='D')
Begin
	declare @fId as int
	select count(FormId) from Tbl_Form
	set @fId=@FormId;
	Delete Tbl_Form    Where FormId =@FormId; DBCC CHECKIDENT (Tbl_Form, RESEED,@FormId) 
End
end
GO
/****** Object:  StoredProcedure [dbo].[Sp_GoldType]    Script Date: 03/10/2021 08:32:14 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE Proc [dbo].[Sp_GoldType]
(
	@GoldTypeId			int=0,
	@GoldTypeCode		int=0,
	@GoldTypeName		nvarchar(255)='',
	@Status				char(1)='A',
	@LoginId			int=0,
	@LogDateTime		datetime,
	@Mode				char(2)
)as 
Begin
if(@Mode='I')
Begin
	--SET NOCOUNT ON;
	Insert Into Tbl_GoldType (GoldTypeCode, GoldTypeName ,Status,LoginId ,LogDateTime)
				   Values(@GoldTypeCode, @GoldTypeName  ,@Status,@loginId,GETDATE())
				   SET @GoldTypeId=SCOPE_IDENTITY()
				   
				  
End

if(@Mode='U')
Begin
	Update Tbl_GoldType   Set GoldTypeCode=@GoldTypeCode, GoldTypeName =@GoldTypeName, Status =@Status, LoginId =@LoginId ,LogDateTime =GETDATE()
	Where GoldTypeId =@GoldTypeId
End

if(@Mode='CP')
Begin
	Update Tbl_GoldType  Set GoldTypeCode=@GoldTypeCode,  GoldTypeName=@GoldTypeName,LogDateTime=GETDATE()
	Where GoldTypeId=@GoldTypeId 
End

if(@Mode='D')
Begin
	--ALTER INDEX PK_Tbl_GoldType ON Tbl_GoldType
	--REBUILD ;
	declare @GId as int
	select count(GoldTypeId) from Tbl_GoldType
	set @GId=@GoldTypeId;
	Delete Tbl_GoldType
	where GoldTypeId=@GoldTypeId DBCC CHECKIDENT (Tbl_GoldType, RESEED,@GoldTypeId) 
End
end
GO
/****** Object:  StoredProcedure [dbo].[Sp_GroupCodeO]    Script Date: 03/10/2021 08:32:14 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE Proc [dbo].[Sp_GroupCodeO]
(
	@GroupCodeOId	int=0,
	@GroupNo		int=0,
	@DelCode		nvarchar(50)='',
	@RecCode		nvarchar(50)='',
	@Status			char(1)='A',
	@LoginId		int=0,
	@LogDateTime	datetime,
	@Mode			char(2)
)as 
Begin
if(@Mode='I')
Begin
	Insert Into Tbl_GroupCodeO (GroupNo,DelCode,RecCode ,Status,LoginId ,LogDateTime)
				   Values(@GroupNo, @DelCode,@RecCode  ,@Status,@loginId,GETDATE())
				   SET @GroupCodeOId=SCOPE_IDENTITY()
End

if(@Mode='U')
Begin
	Update Tbl_GroupCodeO   Set GroupNo=@GroupNo,DelCode=@DelCode,RecCode=@RecCode  ,Status =@Status ,LoginId =@LoginId ,LogDateTime=GETDATE()
	Where GroupCodeOId  =@GroupCodeOId
End



if(@Mode='D')
Begin
	
	Delete Tbl_GroupCodeO    Where GroupCodeOId  =@GroupCodeOId 
End
end
GO
/****** Object:  Table [dbo].[Tbl_GroupMast]    Script Date: 03/10/2021 08:32:06 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[Tbl_GroupMast](
	[GroupMastId] [int] IDENTITY(1,1) NOT NULL,
	[GroupNo] [int] NOT NULL,
	[GroupName] [nvarchar](255) NOT NULL,
	[SectionCode] [int] NOT NULL,
	[SalaryTypeCode] [int] NOT NULL,
	[Salary] [decimal](18, 2) NULL,
	[WorkCarat] [decimal](18, 2) NULL,
	[Productive] [bit] NULL,
	[IsSafe] [bit] NULL,
	[IDRequired] [bit] NULL,
	[IsMainSafe] [bit] NULL,
	[RelatedGroup] [int] NULL,
	[IsActiveGroup] [bit] NULL,
	[WorkingSectionId] [int] NULL,
	[JobNo] [bit] NULL,
	[JobChar] [char](10) NULL,
	[TypeMastId] [int] NULL,
	[TypeDescription] [nvarchar](255) NULL,
	[Status] [char](1) NULL,
	[LoginId] [int] NULL,
	[LogDateTime] [datetime] NULL,
 CONSTRAINT [PK_Tbl_GroupMast] PRIMARY KEY CLUSTERED 
(
	[GroupMastId] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
SET ANSI_PADDING OFF
GO
/****** Object:  StoredProcedure [dbo].[Sp_TypeMasterUnchecked]    Script Date: 03/10/2021 08:32:14 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE Proc [dbo].[Sp_TypeMasterUnchecked]
(
	@TypeMastId			int=0,
	@TypeCodee			nvarchar(255)='',
	@TypeDescription	nvarchar(255)='',
	
	@TypePricePC		decimal(18,2),
	
	@TypeCarat			decimal(18,2),
	@TypeDWL			bit,
	@TypeRWL			bit,
	@RPTColumnD			nvarchar(255)='',
	@RPTColumnR			nvarchar(255)='',
	@TypeDelCharge		bit,
	@TypeRecChage		bit,
	@TypeStone			bit,
	@TypeEntryDate		datetime,
	@Status				char(1)='A',
	@LoginId			int=0,
	@LogDateTime		datetime,
	@Mode				char(2)
)as 
Begin
if(@Mode='I')
Begin
	SET NOCOUNT ON;
	Insert Into Tbl_TypeMaster (TypeCodee, TypeDescription,TypePricePC,TypeCarat ,TypeDWL, TypeRWL,RPTColumnD,RPTColumnR,TypeDelCharge,TypeRecChage,TypeStone,TypeEntryDate,Status,LoginId ,LogDateTime)
				   Values(@TypeCodee, @TypeDescription ,@TypePricePC ,@TypeCarat,@TypeDWL,@TypeRWL,@RPTColumnD,@RPTColumnR,@TypeDelCharge,@TypeRecChage,@TypeStone,GETDATE(),@Status,@loginId,GETDATE())
				   SET @TypeMastId=SCOPE_IDENTITY()
End
if(@Mode='U')
Begin
	Update Tbl_TypeMaster   Set TypeCodee=@TypeCodee , TypeDescription=@TypeDescription,TypePricePC=@TypePricePC,TypeCarat=@TypeCarat ,TypeDWL=@TypeDWL, TypeRWL=@TypeRWL,RPTColumnD=@RPTColumnD,RPTColumnR=@RPTColumnR,TypeDelCharge=@TypeDelCharge,TypeRecChage=@TypeRecChage,TypeStone=@TypeStone,TypeEntryDate=GETDATE(),Status =@Status ,LoginId =@LoginId ,LogDateTime=GETDATE()
	Where TypeMastId =@TypeMastId
End
--if(@Mode='D')
--Begin
	--declare @TypeMCId as int
	--select count(TypeMastId) from Tbl_TypeMaster
	--set @TypeMCId=@TypeMastId;
	--Delete Tbl_TypeMaster    Where TypeMastId =@TypeMastId 
--End
end
GO
/****** Object:  StoredProcedure [dbo].[Sp_TypeMaster]    Script Date: 03/10/2021 08:32:14 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE Proc [dbo].[Sp_TypeMaster]
(
	@TypeMastId			int=0,
	@TypeCodee			nvarchar(255)='',
	@TypeDescription	nvarchar(255)='',
	
	@TypePricePC		decimal(18,2)=0.00,
	
	@TypeCarat			decimal(18,2)=0.00,
	@TypeDWL			bit=null,
	@TypeRWL			bit=null,
	@TypeStone			bit=null,
	@TypeSize			nvarchar(255)='',
	@TypeEntryDate		datetime,
	@StoneColorId		int=0,
	@StoneCUTId			int=0,
	@StoneShapeId		int=0,
	@StoneClearityId	int=0,
	@RPTColumnD			nvarchar(255)='',
	@RPTColumnR			nvarchar(255)='',
	@WeightPC			decimal(18,2)=0.00,
	@ROL				decimal(18,2)=0.00,
	@TypeDelCharge		bit=null,
	@TypeRecChage		bit=null,
	@Status				char(1)='A',
	@LoginId			int=0,
	@LogDateTime		datetime,
	@Mode				char(2)
)as 
Begin
if(@Mode='I')
Begin
	SET NOCOUNT ON;
	Insert Into Tbl_TypeMaster (TypeCodee, TypeDescription,TypePricePC,TypeCarat ,TypeDWL, TypeRWL,TypeStone,TypeSize,TypeEntryDate, StoneColorId,StoneShapeId,StoneCUTId,StoneClearityId,RPTColumnD,RPTColumnR,WeightPC,ROL,TypeDelCharge,TypeRecChage,Status,LoginId ,LogDateTime)
				   Values(@TypeCodee, @TypeDescription ,@TypePricePC ,@TypeCarat,@TypeDWL,@TypeRWL,@TypeStone,@TypeSize,GETDATE(),@StoneColorId,@StoneShapeId,@StoneCUTId,@StoneClearityId,@RPTColumnD,@RPTColumnR,@WeightPC,@ROL,@TypeDelCharge,@TypeRecChage,@Status,@loginId,GETDATE())
				   --SET @TypeMastId=SCOPE_IDENTITY();
End
if(@Mode='U')
Begin
	Update Tbl_TypeMaster   Set TypeCodee=@TypeCodee , TypeDescription=@TypeDescription,TypePricePC=@TypePricePC,TypeCarat=@TypeCarat ,TypeDWL=@TypeDWL, TypeRWL=@TypeRWL,TypeStone=@TypeStone,TypeSize=@TypeSize,TypeEntryDate=GETDATE(), StoneColorId=@StoneColorId,StoneCUTId=@StoneCUTId,StoneClearityId=@StoneClearityId,StoneShapeId=@StoneShapeId,RPTColumnD=@RPTColumnD,RPTColumnR=@RPTColumnR,WeightPC=@WeightPC,ROL=@ROL,TypeDelCharge=@TypeDelCharge,TypeRecChage=@TypeRecChage  ,Status =@Status ,LoginId =@LoginId ,LogDateTime=GETDATE()
	Where TypeMastId =@TypeMastId;
End
if(@Mode='CP')
Begin
	Update Tbl_TypeMaster Set TypeCodee=@TypeCodee, TypeDescription=@TypeDescription,TypePricePC=@TypePricePC,TypeCarat=@TypeCarat ,TypeDWL=@TypeDWL, TypeRWL=@TypeRWL,TypeStone=@TypeStone,TypeSize=@TypeSize,TypeEntryDate=GETDATE(), StoneColorId=@StoneColorId,StoneCUTId=@StoneCUTId,StoneClearityId=@StoneClearityId,StoneShapeId=@StoneShapeId,RPTColumnD=@RPTColumnD,RPTColumnR=@RPTColumnR,WeightPC=@WeightPC,ROL=@ROL,TypeDelCharge=@TypeDelCharge,TypeRecChage=@TypeRecChage  ,LogDateTime=GETDATE()
	Where TypeMastId  =@TypeMastId  ;
End

if(@Mode='D')
Begin
	--declare @TypeMCId as int
	--select count(TypeMastId) from Tbl_TypeMaster
	--set @TypeMCId=@TypeMastId;
	Delete  from Tbl_TypeMaster   Where TypeMastId =@TypeMastId;
	--update Tbl_TypeMaster set Status='D',TypeEntryDate=GETDATE(),LoginId=@LoginId,LogDateTime=GETDATE() where TypeMastId=@TypeMastId;
End
end
GO
/****** Object:  Table [dbo].[Tbl_User]    Script Date: 03/10/2021 08:32:06 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[Tbl_User](
	[UserId] [int] IDENTITY(1,1) NOT NULL,
	[UserCode] [nvarchar](50) NULL,
	[UserName] [nvarchar](255) NOT NULL,
	[LoginName] [nvarchar](225) NOT NULL,
	[Password] [nvarchar](50) NOT NULL,
	[IsLogin] [char](1) NULL,
	[UserGroupId] [int] NOT NULL,
	[BranchId] [int] NULL,
	[SuperUser] [bit] NULL,
	[JobView] [bit] NULL,
	[GroupView] [bit] NULL,
	[IsActive] [bit] NULL,
	[Status] [char](1) NOT NULL,
	[LoginId] [int] NOT NULL,
	[LogDateTime] [datetime] NOT NULL,
 CONSTRAINT [PK_Tbl_User] PRIMARY KEY CLUSTERED 
(
	[UserId] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
SET ANSI_PADDING OFF
GO
/****** Object:  StoredProcedure [dbo].[Sp_UserGroup]    Script Date: 03/10/2021 08:32:15 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE Proc [dbo].[Sp_UserGroup]
(
	@UserGroupId		int=0,
	@UserGroupName		nvarchar(255)='',
	@UserTypeId			int=0,
	@Status				char(1)='A',
	@LoginId			int=0,	
	@LogDateTime		datetime,
	@Mode				char(2)
)as 
Begin
if(@Mode='I')
Begin
	Insert Into Tbl_UserGroup (UserGroupName , UserTypeId, Status,LoginId, LogDateTime)
				       Values(@UserGroupName, @UserTypeId, @Status,@loginId, GETDATE());
End

if(@Mode='U')
Begin
	Update Tbl_UserGroup  Set UserGroupName =@UserGroupName ,UserTypeId =@UserTypeId ,Status =@Status ,LoginId =@LoginId ,LogDateTime =GETDATE()
	Where UserGroupId =@UserGroupId 
End

if(@Mode='CP')
Begin
	Update Tbl_UserGroup  Set  UserTypeId =@UserTypeId  ,LogDateTime=GETDATE()
	Where UserGroupId =@UserGroupId 
End

if(@Mode='D')
Begin
	Delete Tbl_UserGroup  Where UserGroupId  =@UserGroupId  
End
end
GO
/****** Object:  Table [dbo].[Tbl_GroupCode]    Script Date: 03/10/2021 08:32:06 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[Tbl_GroupCode](
	[GroupCodeId] [int] IDENTITY(1,1) NOT NULL,
	[GroupMastId] [int] NULL,
	[GroupNo] [int] NULL,
	[RecCode] [nvarchar](50) NULL,
	[DelCode] [nvarchar](50) NULL,
	[SafeNo] [int] NULL,
	[Status] [char](1) NULL,
 CONSTRAINT [PK_Tbl_GroupCode] PRIMARY KEY CLUSTERED 
(
	[GroupCodeId] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
SET ANSI_PADDING OFF
GO
/****** Object:  StoredProcedure [dbo].[Sp_User]    Script Date: 03/10/2021 08:32:15 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE Proc [dbo].[Sp_User]
(
	@UserId			int=0,
	@UserCode		nvarchar(50)='',
	@UserName		nvarchar(255)='',
	@LoginName		nvarchar(255)='',
	@Password		nvarchar(50)='',
	@IsLogin		char(1)='N',
	@UserGroupId	int=0,	
	@BranchId		int=0,
	@SuperUser		bit=null,
	@JobView		bit=null,
	@GroupView		bit=null,
	@IsActive		bit=null,
	@Status			char(1)='A',
	@LoginId		int=0,
	@LogDateTime	datetime,
	@Mode			char(2)
)
as 
	
Begin
if(@Mode='I')
Begin
	Insert Into Tbl_User(UserCode,UserName,LoginName,Password,IsLogin,UserGroupId,BranchId,SuperUser,JobView,GroupView,IsActive,Status,LoginId ,LogDateTime)
				Values(@UserCode  ,@UserName,@LoginName,@Password,@IsLogin,@UserGroupId,@BranchId,@SuperUser,@JobView,@GroupView,@IsActive,@Status,@LoginId,getdate());
				
End

if(@Mode='U')
Begin
	Update Tbl_User Set UserCode=@UserCode,UserName=@UserName,LoginName=@LoginName,Password=@Password,IsLogin=@IsLogin,UserGroupId=@UserGroupId,BranchId=@BranchId,SuperUser=@SuperUser,JobView=@JobView,GroupView=@GroupView,IsActive=@IsActive,Status=@Status ,LoginId =@LoginId ,LogDateTime=@LogDateTime
	Where UserId=@UserId 
End

if(@Mode='CP')
Begin
	Update Tbl_User  Set  Password=@Password,LogDateTime=@LogDateTime
	Where UserId =@UserId 
End

if(@Mode='D')
Begin
	Delete from Tbl_User  
	 Where UserId=@UserId 
End
end
GO
/****** Object:  StoredProcedure [dbo].[Sp_GroupMast]    Script Date: 03/10/2021 08:32:14 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE Proc [dbo].[Sp_GroupMast]
(
@GroupMastId		int=0,
	@GroupNo			int=0,
	@GroupName			nvarchar(255)='',
	@SectionCode		int=0,
	@SalaryTypeCode		int=0,
	@Salary				decimal(18,2)=0.00,
	@WorkCarat			decimal(18,2)=0.00,
	@Productive			bit=null,
	@IsSafe				bit=null,
	@IDRequired			bit=null,
	@IsMainSafe			bit=null,
	@RelatedGroup		int=0,
	@IsActiveGruop		bit=null,
	@WorkingSectionId	int=0,
	@JobNo				bit=null,
	@JobChar			char='',
	@TypeMastId			int=0,
	@TypeDescription	nvarchar(255)='',
	@Status				char(1)='A',
	@LoginId			int=0,
	@LogDateTime		datetime,
	@Mode				char(2)
)as 
Begin
if(@Mode='I')
Begin
	Insert Into Tbl_GroupMast (GroupNo, GroupName,SectionCode,SalaryTypeCode,Salary,WorkCarat,Productive,IsSafe,IDRequired,IsMainSafe,RelatedGroup,IsActiveGroup,WorkingSectionId,JobNo,JobChar,TypeMastId,TypeDescription,Status,LoginId ,LogDateTime)
				   Values(@GroupNo, @GroupName,@SectionCode,@SalaryTypeCode,@Salary,@WorkCarat,@Productive,@IsSafe,@IDRequired,@IsMainSafe,@RelatedGroup,@IsActiveGruop,@WorkingSectionId,@JobNo,@JobChar,@TypeMastId,@TypeDescription  ,@Status,@loginId,GETDATE())
				   SET @GroupMastId=SCOPE_IDENTITY()
End

if(@Mode='U')
Begin
	Update Tbl_GroupMast   Set GroupNo=@GroupNo, GroupName=@GroupName,SectionCode=@SectionCode,SalaryTypeCode=@SalaryTypeCode,Salary=@Salary,WorkCarat=@WorkCarat,Productive=@Productive,IsSafe=@IsSafe,IDRequired=@IDRequired,IsMainSafe=IsMainSafe,RelatedGroup=@RelatedGroup,IsActiveGroup=@IsActiveGruop,WorkingSectionId=WorkingSectionId,JobNo=@JobNo,JobChar=@JobChar,TypeMastId=@TypeMastId,TypeDescription=@TypeDescription  ,Status =@Status ,LoginId =@LoginId ,LogDateTime=GETDATE()
	Where GroupMastId =@GroupMastId
End

if(@Mode='CP')
Begin
	Update Tbl_GroupMast  Set GroupNo=@GroupNo, GroupName=@GroupName,SectionCode=@SectionCode  ,LogDateTime=GETDATE()
	Where GroupMastId  =@GroupMastId  
End

if(@Mode='D')
Begin
	declare @GMId as int
	select count(GroupMastId) from Tbl_GroupMast
	set @GMId=@GroupMastId;

	Delete Tbl_GroupMast    Where GroupMastId =@GroupMastId DBCC CHECKIDENT (Tbl_GroupMast, RESEED,@GroupMastId) 
End
end
GO
/****** Object:  StoredProcedure [dbo].[Sp_GetUserDetails]    Script Date: 03/10/2021 08:32:14 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:		<Author,,Name>
-- Create date: <Create Date,,>
-- Description:	<Description,,>
-- =============================================
CREATE PROCEDURE [dbo].[Sp_GetUserDetails]
	@loginname nvarchar(50),
	@password nvarchar(50)
	
AS
BEGIN
	select UserId,UserName,LoginName,UserGroupId,Password from [Tbl_User] where LoginName=@loginname and Password=@password;

    
    
END
GO
/****** Object:  StoredProcedure [dbo].[Sp_GroupCode]    Script Date: 03/10/2021 08:32:14 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE Proc [dbo].[Sp_GroupCode]
(
	@GroupCodeId		int=0,
	@GroupMastId		int=0,
    @GroupNo			int=0,
    @RecCode			nvarchar(255)='',
    @DelCode			nvarchar(255)='',
    @SafeNo				int=0,
	@Status				char(1)='A',
	@Mode				char(2)
)as 
Begin
if(@Mode='I')
Begin
	--SET NOCOUNT ON;
	Insert Into Tbl_GroupCode (GroupMastId, GroupNo, RecCode ,DelCode,SafeNo,Status)
				   Values(@GroupMastId,@GroupNo, @RecCode ,@DelCode ,@SafeNo,@Status)
				   SET @GroupCodeId=SCOPE_IDENTITY()
				   
				  
End

if(@Mode='U')
Begin
	Update Tbl_GroupCode   Set GroupMastId=@GroupMastId, GroupNo=@GroupNo, RecCode =@RecCode,DelCode=@DelCode,SafeNo=@SafeNo, Status =@Status
	Where GroupCodeId =@GroupCodeId
End

if(@Mode='CP')
Begin
	Update Tbl_GroupCode  Set GroupNo=@GroupNo,  RecCode=@RecCode,DelCode=@DelCode,Status=@Status
	Where GroupCodeId=@GroupCodeId 
End

if(@Mode='D')
Begin
	--ALTER INDEX PK_Tbl_GoldType ON Tbl_GoldType
	--REBUILD ;
	--declare @GId as int
	--select count(GoldTypeId) from Tbl_GoldType
	--set @GId=@GoldTypeId;
	Delete Tbl_GroupCode
	where GroupCodeId=@GroupCodeId 
End
end
GO
/****** Object:  ForeignKey [FK_Tbl_GroupCode_GroupCode]    Script Date: 03/10/2021 08:32:06 ******/
ALTER TABLE [dbo].[Tbl_GroupCode]  WITH CHECK ADD  CONSTRAINT [FK_Tbl_GroupCode_GroupCode] FOREIGN KEY([GroupMastId])
REFERENCES [dbo].[Tbl_GroupMast] ([GroupMastId])
GO
ALTER TABLE [dbo].[Tbl_GroupCode] CHECK CONSTRAINT [FK_Tbl_GroupCode_GroupCode]
GO
/****** Object:  ForeignKey [FK_Tbl_GroupMast_SalaryType]    Script Date: 03/10/2021 08:32:06 ******/
ALTER TABLE [dbo].[Tbl_GroupMast]  WITH CHECK ADD  CONSTRAINT [FK_Tbl_GroupMast_SalaryType] FOREIGN KEY([SalaryTypeCode])
REFERENCES [dbo].[Tbl_SalaryType] ([SalaryTypeCode])
GO
ALTER TABLE [dbo].[Tbl_GroupMast] CHECK CONSTRAINT [FK_Tbl_GroupMast_SalaryType]
GO
/****** Object:  ForeignKey [FK_Tbl_GroupMast_Section]    Script Date: 03/10/2021 08:32:06 ******/
ALTER TABLE [dbo].[Tbl_GroupMast]  WITH CHECK ADD  CONSTRAINT [FK_Tbl_GroupMast_Section] FOREIGN KEY([SectionCode])
REFERENCES [dbo].[Tbl_Section] ([SectionCode])
GO
ALTER TABLE [dbo].[Tbl_GroupMast] CHECK CONSTRAINT [FK_Tbl_GroupMast_Section]
GO
/****** Object:  ForeignKey [FK_Tbl_GroupMast_Tbl_TypeMaster]    Script Date: 03/10/2021 08:32:06 ******/
ALTER TABLE [dbo].[Tbl_GroupMast]  WITH CHECK ADD  CONSTRAINT [FK_Tbl_GroupMast_Tbl_TypeMaster] FOREIGN KEY([TypeMastId])
REFERENCES [dbo].[Tbl_TypeMaster] ([TypeMastId])
GO
ALTER TABLE [dbo].[Tbl_GroupMast] CHECK CONSTRAINT [FK_Tbl_GroupMast_Tbl_TypeMaster]
GO
/****** Object:  ForeignKey [FK_Tbl_GroupMast_WSection]    Script Date: 03/10/2021 08:32:06 ******/
ALTER TABLE [dbo].[Tbl_GroupMast]  WITH CHECK ADD  CONSTRAINT [FK_Tbl_GroupMast_WSection] FOREIGN KEY([WorkingSectionId])
REFERENCES [dbo].[Tbl_WorkingSection] ([WorkingSectionId])
GO
ALTER TABLE [dbo].[Tbl_GroupMast] CHECK CONSTRAINT [FK_Tbl_GroupMast_WSection]
GO
/****** Object:  ForeignKey [FK_Tbl_TypeMaster_Tbl_StoneClearity]    Script Date: 03/10/2021 08:32:06 ******/
ALTER TABLE [dbo].[Tbl_TypeMaster]  WITH CHECK ADD  CONSTRAINT [FK_Tbl_TypeMaster_Tbl_StoneClearity] FOREIGN KEY([StoneClearityId])
REFERENCES [dbo].[Tbl_StoneClearity] ([StoneClearityId])
GO
ALTER TABLE [dbo].[Tbl_TypeMaster] CHECK CONSTRAINT [FK_Tbl_TypeMaster_Tbl_StoneClearity]
GO
/****** Object:  ForeignKey [FK_Tbl_TypeMaster_Tbl_StoneColor]    Script Date: 03/10/2021 08:32:06 ******/
ALTER TABLE [dbo].[Tbl_TypeMaster]  WITH CHECK ADD  CONSTRAINT [FK_Tbl_TypeMaster_Tbl_StoneColor] FOREIGN KEY([StoneColorId])
REFERENCES [dbo].[Tbl_StoneColor] ([StoneColorId])
GO
ALTER TABLE [dbo].[Tbl_TypeMaster] CHECK CONSTRAINT [FK_Tbl_TypeMaster_Tbl_StoneColor]
GO
/****** Object:  ForeignKey [FK_Tbl_TypeMaster_Tbl_StoneShape]    Script Date: 03/10/2021 08:32:06 ******/
ALTER TABLE [dbo].[Tbl_TypeMaster]  WITH CHECK ADD  CONSTRAINT [FK_Tbl_TypeMaster_Tbl_StoneShape] FOREIGN KEY([StoneShapeId])
REFERENCES [dbo].[Tbl_StoneShape] ([StoneShapeId])
GO
ALTER TABLE [dbo].[Tbl_TypeMaster] CHECK CONSTRAINT [FK_Tbl_TypeMaster_Tbl_StoneShape]
GO
/****** Object:  ForeignKey [FK_Tbl_TypeMaster_Tbl_StoneShapeCUT]    Script Date: 03/10/2021 08:32:06 ******/
ALTER TABLE [dbo].[Tbl_TypeMaster]  WITH CHECK ADD  CONSTRAINT [FK_Tbl_TypeMaster_Tbl_StoneShapeCUT] FOREIGN KEY([StoneCUTId])
REFERENCES [dbo].[Tbl_StoneShapeCUT] ([StoneCUTId])
GO
ALTER TABLE [dbo].[Tbl_TypeMaster] CHECK CONSTRAINT [FK_Tbl_TypeMaster_Tbl_StoneShapeCUT]
GO
/****** Object:  ForeignKey [FK_Tbl_User_Tbl_UserGroup]    Script Date: 03/10/2021 08:32:06 ******/
ALTER TABLE [dbo].[Tbl_User]  WITH CHECK ADD  CONSTRAINT [FK_Tbl_User_Tbl_UserGroup] FOREIGN KEY([UserGroupId])
REFERENCES [dbo].[Tbl_UserGroup] ([UserGroupId])
GO
ALTER TABLE [dbo].[Tbl_User] CHECK CONSTRAINT [FK_Tbl_User_Tbl_UserGroup]
GO
/****** Object:  ForeignKey [FK_Tbl_UserGroup_Tbl_UserType]    Script Date: 03/10/2021 08:32:06 ******/
ALTER TABLE [dbo].[Tbl_UserGroup]  WITH CHECK ADD  CONSTRAINT [FK_Tbl_UserGroup_Tbl_UserType] FOREIGN KEY([UserTypeId])
REFERENCES [dbo].[Tbl_UserType] ([UserTypeId])
GO
ALTER TABLE [dbo].[Tbl_UserGroup] CHECK CONSTRAINT [FK_Tbl_UserGroup_Tbl_UserType]
GO
