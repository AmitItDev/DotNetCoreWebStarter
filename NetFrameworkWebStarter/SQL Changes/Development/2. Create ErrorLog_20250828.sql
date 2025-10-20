IF NOT EXISTS 
(
  SELECT * 
  FROM INFORMATION_SCHEMA.COLUMNS 
  WHERE table_name = 'ErrorLog]'
)

CREATE TABLE [dbo].[ErrorLog](
	[ErrorLogId] [int] IDENTITY(1,1) NOT NULL,
	[ErrorDate] [datetime] NULL,
	[LoginID] [int] NULL,
	[IPAddress] [nvarchar](20) NULL,
	[ClientBrowser] [nvarchar](50) NULL,
	[ErrorMessage] [nvarchar](max) NULL,
	[ErrorStackTrace] [nvarchar](max) NULL,
	[URL] [nvarchar](max) NULL,
	[URLReferrer] [nvarchar](max) NULL,
	[ErrorSource] [nvarchar](max) NULL,
	[ErrorTargetSite] [nvarchar](max) NULL,
	[QueryString] [nvarchar](max) NULL,
	[PostData] [nvarchar](max) NULL,
	[SessionInfo] [nvarchar](max) NULL,
PRIMARY KEY CLUSTERED 
(
	[ErrorLogId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO

