USE [DOOR]
GO
/****** Object:  Table [dbo].[M_ACCOUNT] ******/
DROP TABLE if EXISTS dbo.M_ACCOUNT

SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[M_ACCOUNT](
	[seq][int] IDENTITY(1,1) NOT NULL,
	[EMail] [varchar](50) NOT NULL,
	[Passwd] [varchar](16) NOT NULL,
	[LastName] [varchar](50) NOT NULL,
	[FirstName] [varchar](50) NOT NULL,
	[Pref] [varchar](50) NOT NULL,
	[City] [varchar](50) NOT NULL,
	[Address] [varchar](50) NOT NULL,
	[Apartment] [varchar](50) NOT NULL,
	[Role] [varchar](50) NOT NULL,
	[SubRole] [varchar](50) NOT NULL,
	[LastNameEn] [varchar](50) NOT NULL,
	[FirstNameEn] [varchar](50) NOT NULL,
	[PrefEn] [varchar](50) NOT NULL,
	[CityEn] [varchar](50) NOT NULL,
	[AddressEn] [varchar](50) NOT NULL,
	[ApartmentEn] [varchar](50) NOT NULL,
	[RoleEn] [varchar](50) NOT NULL,
	[SubRoleEn] [varchar](50) NOT NULL,
	[Tel] [varchar](50) NOT NULL,
	[Fax] [varchar](50) NOT NULL,
	[AdminKbn] [int] NOT NULL,
	[CREATE_DATE] [datetime] NULL,
	[UPDATE_DATE] [datetime] NULL,
 CONSTRAINT [PK_M_ACCOUNT] PRIMARY KEY CLUSTERED 
(
	[seq] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
