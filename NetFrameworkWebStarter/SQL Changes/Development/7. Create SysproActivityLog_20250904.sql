IF NOT EXISTS 
(
  SELECT * 
  FROM INFORMATION_SCHEMA.COLUMNS 
  WHERE table_name = 'SysproActivityLog'
)
CREATE TABLE [dbo].[SysproActivityLog](
    [LogId] [int] IDENTITY(1,1) NOT NULL,
	[SourceUser] [varchar](100) NOT NULL,
	[SysproOperator] [varchar](100) NOT NULL,
	[SysproCompany] [varchar](50) NOT NULL,
	[Action] [varchar](20) NOT NULL,
	[DateLogged] [datetime] NOT NULL,
	[DateProcessed] [datetime] NULL,
	[BusinessObject] [varchar](20) NULL,
	[SysproInput] [text] NULL,
	[SysproOutput] [text] NULL,
	[SysproParameter] [text] NULL,
	[SysproKey] [varchar](500) NULL,
	[SourceKey] [varchar](500) NULL,
	[AdditionData] [varchar](500) NULL,
	[ErrorMessage] [varchar](max) NULL,
	[Status] [varchar](100) NOT NULL,
	[ApplicationId] [int] NULL,
 CONSTRAINT [PK_SysproActivityLog] PRIMARY KEY CLUSTERED 
(
    [LogId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
);
