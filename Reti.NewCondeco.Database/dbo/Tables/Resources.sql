CREATE TABLE [dbo].[Resources](
	[ResourceID] [int] NOT NULL,
	[UserName] [nvarchar](200) NOT NULL,
	[SurName] [nvarchar](200) NOT NULL,
	[Name] [nvarchar](200) NOT NULL,
	[Mail] [nvarchar](200) NOT NULL,
	[IsAvaible] [bit] NOT NULL,
 CONSTRAINT [PK_Resources] PRIMARY KEY CLUSTERED 
(
	[ResourceID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
ALTER TABLE [dbo].[Resources] ADD  CONSTRAINT [DF_Resources_State]  DEFAULT ((1)) FOR [IsAvaible]