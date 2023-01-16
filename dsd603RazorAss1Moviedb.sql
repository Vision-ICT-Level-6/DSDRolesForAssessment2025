USE [aspnet-dsd03Razor2020Assessment-53bc9b9d-9d6a-45d4-8429-2a2761773502]
GO
/****** Object:  Table [dbo].[Cast]    Script Date: 7/07/2022 10:28:32 am ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Cast](
	[Id] [uniqueidentifier] NOT NULL,
	[FirstName] [nvarchar](max) NULL,
	[LastName] [nvarchar](max) NULL,
	[ScreenName] [nvarchar](max) NULL,
	[MovieId] [uniqueidentifier] NULL,
 CONSTRAINT [PK_Cast] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Movie]    Script Date: 7/07/2022 10:28:32 am ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Movie](
	[Id] [uniqueidentifier] NOT NULL,
	[Title] [nvarchar](max) NOT NULL,
	[ReleaseDate] [datetime2](7) NOT NULL,
	[Genre] [nvarchar](max) NOT NULL,
	[Price] [decimal](18, 2) NOT NULL,
	[Overview] [nvarchar](max) NOT NULL,
 CONSTRAINT [PK_Movie] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
INSERT [dbo].[Cast] ([Id], [FirstName], [LastName], [ScreenName], [MovieId]) VALUES (N'6da9bbb4-019f-4e90-a589-08da5f8fa30a', N' Leonardo ', N'DiCaprio', N'Dr. Randall Mindy', N'7e5706f9-f7c7-4c8e-f408-08da5f8f26c7')
GO
INSERT [dbo].[Cast] ([Id], [FirstName], [LastName], [ScreenName], [MovieId]) VALUES (N'5de8e0bb-73b9-4f62-a58a-08da5f8fa30a', N'Jennifer', N'Lawrence', N'Kate Dibiasky', N'7e5706f9-f7c7-4c8e-f408-08da5f8f26c7')
GO
INSERT [dbo].[Cast] ([Id], [FirstName], [LastName], [ScreenName], [MovieId]) VALUES (N'8f7134a8-1d99-4718-a58b-08da5f8fa30a', N'Meryl ', N'Streep', N'President Orlean', N'7e5706f9-f7c7-4c8e-f408-08da5f8f26c7')
GO
INSERT [dbo].[Cast] ([Id], [FirstName], [LastName], [ScreenName], [MovieId]) VALUES (N'02b7a523-4748-4b01-a58c-08da5f8fa30a', N'Steve ', N'Carell', N'Gru', N'435a9c5b-e16f-49b2-f409-08da5f8f26c7')
GO
INSERT [dbo].[Cast] ([Id], [FirstName], [LastName], [ScreenName], [MovieId]) VALUES (N'475545bb-af4d-4e4f-a58d-08da5f8fa30a', N'Taraji P. ', N'Henson', N'Belle Bottom', N'435a9c5b-e16f-49b2-f409-08da5f8f26c7')
GO
INSERT [dbo].[Cast] ([Id], [FirstName], [LastName], [ScreenName], [MovieId]) VALUES (N'42f7ba9d-542d-4402-a58e-08da5f8fa30a', N'Michelle ', N'Yeoh', N'Master Chow', N'435a9c5b-e16f-49b2-f409-08da5f8f26c7')
GO
INSERT [dbo].[Cast] ([Id], [FirstName], [LastName], [ScreenName], [MovieId]) VALUES (N'48f6904a-b073-46f7-a58f-08da5f8fa30a', N'Miranda ', N'July', N'Narrator', N'a3ddd696-442a-4fa3-f40a-08da5f8f26c7')
GO
INSERT [dbo].[Cast] ([Id], [FirstName], [LastName], [ScreenName], [MovieId]) VALUES (N'73eb6a44-33d2-4b4a-a590-08da5f8fa30a', N'Sara ', N'Dosa', N'Director', N'a3ddd696-442a-4fa3-f40a-08da5f8f26c7')
GO
INSERT [dbo].[Cast] ([Id], [FirstName], [LastName], [ScreenName], [MovieId]) VALUES (N'74eec0fe-76d2-4f57-a591-08da5f8fa30a', N'Shane ', N'Boris', N'Producer', N'a3ddd696-442a-4fa3-f40a-08da5f8f26c7')
GO
INSERT [dbo].[Movie] ([Id], [Title], [ReleaseDate], [Genre], [Price], [Overview]) VALUES (N'7e5706f9-f7c7-4c8e-f408-08da5f8f26c7', N'Don''t Look Up', CAST(N'2022-07-07T00:00:00.0000000' AS DateTime2), N'Comedy', CAST(123.00 AS Decimal(18, 2)), N'Kate Dibiasky (Jennifer Lawrence), an astronomy grad student, and her professor Dr. Randall Mindy (Leonardo DiCaprio) make an astounding discovery of a comet orbiting within the solar system. The problem: it''s on a direct collision course with Earth. The other problem? No one really seems to care. Turns out warning mankind about a planet-killer the size of Mount Everest is an inconvenient fact to navigate. With the help of Dr. Oglethorpe (Rob Morgan), Kate and Randall embark on a media tour that takes them from the office of an indifferent President Orlean (Meryl Streep) and her sycophantic son and Chief of Staff, Jason (Jonah Hill), to the airwaves of The Daily Rip, an upbeat morning show hosted by Brie (Cate Blanchett) and Jack (Tyler Perry). With only six months until the comet makes impact, managing the 24-hour news cycle and gaining the attention of the social media obsessed public before it''s too late proves shockingly comical -- what will it take to get the world to just look up?!')
GO
INSERT [dbo].[Movie] ([Id], [Title], [ReleaseDate], [Genre], [Price], [Overview]) VALUES (N'435a9c5b-e16f-49b2-f409-08da5f8f26c7', N'Minions: The rise of Gru', CAST(N'2022-07-06T00:00:00.0000000' AS DateTime2), N'Comedy, Adventure', CAST(123.00 AS Decimal(18, 2)), N'In the heart of the 1970s, amid a flurry of feathered hair and flared jeans, Gru (Oscar® nominee Steve Carell) is growing up in the suburbs. A fanboy of a supervillain supergroup known as the Vicious 6, Gru hatches a plan to become evil enough to join them. Luckily, he gets some mayhem-making backup from his loyal followers, the Minions. Together, Kevin, Stuart, Bob, and Otto--a new Minion sporting braces and a desperate need to please--deploy their skills as they and Gru build their first lair, experiment with their first weapons and pull off their first missions. When the Vicious 6 oust their leader, legendary fighter Wild Knuckles (Oscar® winner Alan Arkin), Gru interviews to become their newest member. It doesn''t go well (to say the least), and only gets worse after Gru outsmarts them and suddenly finds himself the mortal enemy of the apex of evil. On the run, Gru will turn to an unlikely source for guidance, Wild Knuckles himself, and discover that even bad guys need a little help from their friends.')
GO
INSERT [dbo].[Movie] ([Id], [Title], [ReleaseDate], [Genre], [Price], [Overview]) VALUES (N'a3ddd696-442a-4fa3-f40a-08da5f8f26c7', N'Fire of Love', CAST(N'2022-07-06T00:00:00.0000000' AS DateTime2), N'Documentary, Biography', CAST(123.00 AS Decimal(18, 2)), N'Fire of Love tells the story of two French lovers, Katia and Maurice Krafft, who died in a volcanic explosion doing the very thing that brought them together: unraveling the mysteries of our planet, while simultaneously capturing the most explosive volcano imagery ever recorded. Along the way, they changed our understanding of the natural world, and saved tens of thousands of lives. Previously unseen hours of pristine 16-millimeter film and thousands of photographs reveal the birth of modern volcanology through an unlikely lens -- the love of its two pioneers.')
GO
ALTER TABLE [dbo].[Movie] ADD  DEFAULT (N'') FOR [Overview]
GO
ALTER TABLE [dbo].[Cast]  WITH CHECK ADD  CONSTRAINT [FK_Cast_Movie_MovieId] FOREIGN KEY([MovieId])
REFERENCES [dbo].[Movie] ([Id])
GO
ALTER TABLE [dbo].[Cast] CHECK CONSTRAINT [FK_Cast_Movie_MovieId]
GO
