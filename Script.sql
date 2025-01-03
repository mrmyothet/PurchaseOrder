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
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Stock]    Script Date: 2024-12-10 1:36:30 pm ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Stock](
	[Id] [varchar](32) NOT NULL,
	[Name] [nvarchar](50) NOT NULL,
	[Description] [nvarchar](300) NULL,
	[Price] [decimal](18, 2) NULL,
	[Quantity] [int] NULL,
 CONSTRAINT [PK_Stock] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Vendor]    Script Date: 2024-12-10 1:36:30 pm ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Vendor](
	[ID] [char](32) NOT NULL,
	[Name] [nvarchar](64) NOT NULL,
	[ContactName] [nvarchar](64) NULL,
	[Phone] [char](32) NULL,
	[Email] [char](64) NULL,
	[Address] [nvarchar](256) NULL,
 CONSTRAINT [PK_Vendor] PRIMARY KEY CLUSTERED 
(
	[ID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
INSERT [dbo].[Stock] ([Id], [Name], [Description], [Price], [Quantity]) VALUES (N'2DD3052411F84BA981FE1BA01A1A1D1D', N'BHZ001-68', N'HYDRAULIC HAND PUMP', CAST(1480.00 AS Decimal(18, 2)), 1)
INSERT [dbo].[Stock] ([Id], [Name], [Description], [Price], [Quantity]) VALUES (N'6153046B7DF4453CB47C29CF9B78FBE0', N'BZA170-38', N'GRAYLOC SEAL RING', CAST(52.00 AS Decimal(18, 2)), 2)
INSERT [dbo].[Stock] ([Id], [Name], [Description], [Price], [Quantity]) VALUES (N'7861F71566AE4A289DEC4FD87B2473E6', N'Y10278-40', N'WELDMENT DETAIL BRACING BAR', CAST(210.00 AS Decimal(18, 2)), 12)
INSERT [dbo].[Stock] ([Id], [Name], [Description], [Price], [Quantity]) VALUES (N'84CD934E7FC8471DA8022CAC58EE29EF', N'BZA237-1', N'ANTI-SEIZE COMPOUND', CAST(20.00 AS Decimal(18, 2)), 2)
INSERT [dbo].[Stock] ([Id], [Name], [Description], [Price], [Quantity]) VALUES (N'8D9D5B944871465B96E9C8D9C263EC49', N'Y10277-50', N'DETAIL SAVER SUB JOINT HANDLING TOOL', CAST(73.00 AS Decimal(18, 2)), 2)
INSERT [dbo].[Stock] ([Id], [Name], [Description], [Price], [Quantity]) VALUES (N'97044BC60B6549C4B9350988EBC39D48', N'T10095-55', N'LOWER SPOOL ADAPTER', CAST(600.00 AS Decimal(18, 2)), 1)
INSERT [dbo].[Stock] ([Id], [Name], [Description], [Price], [Quantity]) VALUES (N'E24DBF005BBE4BA78FDFE4708BFEFCC5', N'BDB220-066', N'FITTING BULKHEAD ADAPTER', CAST(78.00 AS Decimal(18, 2)), 4)
GO
INSERT [dbo].[Vendor] ([ID], [Name], [ContactName], [Phone], [Email], [Address]) VALUES (N'598619184CDB4CB296F68B6EBAB2546B', N'G.B. Industry Co. L.P.', N'David Bahlo', N'281-996-0020                    ', N'david.bahlo@gbindustry.com                                      ', N'PO Box 1622 Friendswood, TX 77549')
INSERT [dbo].[Vendor] ([ID], [Name], [ContactName], [Phone], [Email], [Address]) VALUES (N'60A9B9DCFB6F4A66AD1F68D13D967F62', N'Turcomp Engineering Services Sdn Bhd', N'Siti Syarafana Hussin', N'807 420986                      ', N'mr.myothet@gmail.com                                            ', N'ABS Yard Multibay Workshop No. 10 Rancha-Ranchai Industrial Estate 87014 Labuan F.T')
INSERT [dbo].[Vendor] ([ID], [Name], [ContactName], [Phone], [Email], [Address]) VALUES (N'66A803534CF54163ACA9BB5D71FEC126', N'Singafluid Systems Pte Ltd.', N'Yong Chin Yee', N'65 6363 5238                    ', N'mr.myothet@gmail.com                                            ', N'28 Mandai Estate Singapore 729917')
INSERT [dbo].[Vendor] ([ID], [Name], [ContactName], [Phone], [Email], [Address]) VALUES (N'7E82D79D994045828B458961DEA1CCA5', N'WINSTON ENGINEERING CORPORATION (PTE) LTD', N'Larson Tan', N'+65 9630 7412                   ', N'larsontan@winstonengineering.com.sg                             ', N'1, Joo Koon Way, Singapore 628942')
INSERT [dbo].[Vendor] ([ID], [Name], [ContactName], [Phone], [Email], [Address]) VALUES (N'E2815A3F73E941819A32179742C1E43B', N'Pascal Industries Pte. Ltd.', N'Carey Tan', N'+65 6694 6054                   ', N'carey.tan@pascalindustries.com                                  ', N'41 Tuas Ave 13 Singapore 639000')
GO
ALTER TABLE [dbo].[Stock] ADD  CONSTRAINT [DF_Stock_Price]  DEFAULT ((0.00)) FOR [Price]
GO
ALTER TABLE [dbo].[Stock] ADD  CONSTRAINT [DF_Stock_Quantity]  DEFAULT ((0)) FOR [Quantity]
GO
USE [master]
GO
ALTER DATABASE [PurchaseOrder] SET  READ_WRITE 
GO