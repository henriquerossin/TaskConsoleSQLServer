USE [AulaADO]
GO
 
/****** Object:  Table [dbo].[Enderecos]    Script Date: 11/18/2025 14:25:14 ******/
SET ANSI_NULLS ON
GO
 
SET QUOTED_IDENTIFIER ON
GO
 
CREATE TABLE [dbo].[Enderecos](
	[id] [int] IDENTITY(1,1) NOT NULL,
	[logradouro] [varchar](100) NOT NULL,
	[numero] [int] NULL,
	[complemento] [varchar](100) NULL,
	[bairro] [varchar](100) NOT NULL,
	[cidade] [varchar](100) NOT NULL,
	[estado] [varchar](2) NOT NULL,
	[cep] [varchar](10) NOT NULL,
	[pessoaId] [int] NOT NULL,
PRIMARY KEY CLUSTERED 
(
	[id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
 
ALTER TABLE [dbo].[Enderecos]  WITH CHECK ADD FOREIGN KEY([pessoaId])
REFERENCES [dbo].[Pessoas] ([id])
GO