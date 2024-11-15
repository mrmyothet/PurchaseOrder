CREATE TABLE [dbo].[PurchaseOrder](
	[ID] [char](32) NOT NULL,
	[PONo] [char](32) NOT NULL,
	[PODate] [date] NOT NULL,
	[Vendor] [char](32) NOT NULL,
	[TotalAmount] [decimal](18, 2) NOT NULL,
	[Currency] [char](10) NOT NULL,
 CONSTRAINT [PK_PurchaseOrder] PRIMARY KEY CLUSTERED 
(
	[ID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Vendor]    Script Date: 2024-11-15 8:25:40 pm ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Vendor](
	[ID] [char](32) NOT NULL,
	[Name] [nvarchar](64) NOT NULL,
	[ContactName] [nvarchar](64) NULL,
	[Telephone] [char](32) NULL,
	[Email] [char](64) NULL,
	[Address] [nvarchar](256) NULL,
 CONSTRAINT [PK_Vendor] PRIMARY KEY CLUSTERED 
(
	[ID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
USE [master]
GO
ALTER DATABASE [PurchaseOrder] SET  READ_WRITE 
GO
