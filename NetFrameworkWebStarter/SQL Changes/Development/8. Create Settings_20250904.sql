IF NOT EXISTS 
(
  SELECT * 
  FROM INFORMATION_SCHEMA.COLUMNS 
  WHERE table_name = 'Settings'
)
CREATE TABLE [dbo].[Settings](
    [SettingId] int IDENTITY(1,1) NOT NULL,
    [SysproOperator] VARCHAR(100),
    [SysproOperatorPassword] VARCHAR(100),
    [SysproCompany] VARCHAR(100),
    [SysproCompanyPassword] VARCHAR(100),
    [WebserviceURL] VARCHAR(255),
	[SysproWCFBinding] int NOT NULL
 CONSTRAINT [PK_Settings] PRIMARY KEY CLUSTERED 
(
    [SettingId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
);
