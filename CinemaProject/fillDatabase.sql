SET IDENTITY_INSERT [dbo].[Caps] ON
INSERT INTO [dbo].[Caps] ([Id], [Capacity]) VALUES (1, 15)
SET IDENTITY_INSERT [dbo].[Caps] OFF

SET IDENTITY_INSERT [dbo].[Screens] ON
INSERT INTO [dbo].[Screens] ([Id], [CapId]) VALUES (1, 1)
INSERT INTO [dbo].[Screens] ([Id], [CapId]) VALUES (2, 1)
INSERT INTO [dbo].[Screens] ([Id], [CapId]) VALUES (3, 1)
INSERT INTO [dbo].[Screens] ([Id], [CapId]) VALUES (4, 1)
INSERT INTO [dbo].[Screens] ([Id], [CapId]) VALUES (5, 1)
INSERT INTO [dbo].[Screens] ([Id], [CapId]) VALUES (6, 1)
INSERT INTO [dbo].[Screens] ([Id], [CapId]) VALUES (7, 1)
INSERT INTO [dbo].[Screens] ([Id], [CapId]) VALUES (8, 1)
SET IDENTITY_INSERT [dbo].[Screens] OFF

SET IDENTITY_INSERT [dbo].[Genres] ON
INSERT INTO [dbo].[Genres] ([Id], [Name]) VALUES (1, N'Western')
INSERT INTO [dbo].[Genres] ([Id], [Name]) VALUES (2, N'Horror')
INSERT INTO [dbo].[Genres] ([Id], [Name]) VALUES (3, N'Drama')
INSERT INTO [dbo].[Genres] ([Id], [Name]) VALUES (4, N'Kids')
SET IDENTITY_INSERT [dbo].[Genres] OFF

SET IDENTITY_INSERT [dbo].[Films] ON
INSERT INTO [dbo].[Films] ([Id], [Title], [Description], [PosterLink], [GenreId], [TrailerLink], [Runtime]) VALUES (1, N'The Shining', N'Jack Torrance is a winter caretaker at the Overlook Hotel. He lives there with his wife Wendy and son Danny. However, things take a turn when Danny and his family start witnessing supernatural events.', N'\Images\Films\1ec70bf4-1bf3-4bc1-9a12-2804c55b0279.jpg', 2, N'https://www.youtube.com/embed/FZQvIJxG9Xs?si=bR3pUHXksmUCdtKI', 146)
INSERT INTO [dbo].[Films] ([Id], [Title], [Description], [PosterLink], [GenreId], [TrailerLink], [Runtime]) VALUES (2, N'The Good the Bad and the Ugly', N'A bounty hunting expedition brings two men together in an uncomfortable alliance while looking for buried treasure. They also battle with a wanted outlaw who wants to settle an old score with them.', N'\Images\Films\bbf93702-550e-4dac-8342-7b728735e3c0.jfif', 1, N'https://www.youtube.com/embed/IFNUGzCOQoI?si=kGpFBY8RVZ18-l6A', 161)
INSERT INTO [dbo].[Films] ([Id], [Title], [Description], [PosterLink], [GenreId], [TrailerLink], [Runtime]) VALUES (3, N'For a Few Dollars More', N'While chasing El Indio, a most-wanted criminal, Monco meets Colonel Douglas Mortimer, who incidentally is also looking for El Indio. They enter into a partnership and decide to split the reward.', N'\Images\Films\35a2b286-5d34-43cd-ab64-8c3a1a867fee.jpg', 1, N'https://www.youtube.com/embed/bNt9NcLteoU?si=c_jXQBTt_yucWl4O', 132)
INSERT INTO [dbo].[Films] ([Id], [Title], [Description], [PosterLink], [GenreId], [TrailerLink], [Runtime]) VALUES (4, N'Alien', N'The crew of a spacecraft, Nostromo, intercept a distress signal from a planet and set out to investigate it. However, to their horror, they are attacked by an alien which later invades their ship.', N'\Images\Films\ca8fbd2c-6e29-48e4-86d9-d0b2f1aa987c.jpg', 2, N'https://www.youtube.com/embed/4lRNBd8Vook?si=iQr1ndnHLusTIVnh', 117)
INSERT INTO [dbo].[Films] ([Id], [Title], [Description], [PosterLink], [GenreId], [TrailerLink], [Runtime]) VALUES (5, N'Little Women', N'19th century Massachusetts. While the March sisters - Jo, Meg, Amy, and Beth - enter the threshold of womanhood, they go through many ups and downs in life and endeavor to make important decisions that can affect their future.', N'\Images\Films\09935a61-a519-4466-8690-cc3492c0c4e9.jpg', 3, N'https://www.youtube.com/embed/AST2-4db4ic?si=KErFylROU-otewWc', 135)
INSERT INTO [dbo].[Films] ([Id], [Title], [Description], [PosterLink], [GenreId], [TrailerLink], [Runtime]) VALUES (6, N'Once Upon A time In America', N'A former Prohibition-era Jewish gangster returns to the Lower East Side of Manhattan 35 years later, where he must once again confront the ghosts and regrets of his old life.', N'\Images\Films\f04e17aa-4652-49e9-ab04-7d6348db049d.jpg', 3, N'https://www.youtube.com/embed/lFw062jAYR0?si=TgO7HWMEK5s7D57A', 269)
INSERT INTO [dbo].[Films] ([Id], [Title], [Description], [PosterLink], [GenreId], [TrailerLink], [Runtime]) VALUES (7, N'Bambi', N'The story of a young deer growing up in the forest.', N'\Images\Films\30e09a97-babe-4a29-8267-699df3204b71.jpeg', 4, N'https://www.youtube.com/embed/yDGv4GIR7A4?si=BxHu2kQfJsAxiHmr', 69)
INSERT INTO [dbo].[Films] ([Id], [Title], [Description], [PosterLink], [GenreId], [TrailerLink], [Runtime]) VALUES (8, N'WALL-E', N'A robot who is responsible for cleaning a waste-covered Earth meets another robot and falls in love with her. Together, they set out on a journey that will alter the fate of mankind.', N'\Images\Films\718c4a08-b996-4dd9-867a-e25de1e704d5.jpg', 4, N'https://www.youtube.com/embed/geplBr2fcZc?si=1nRo0JQr3LpW6SSE', 108)
SET IDENTITY_INSERT [dbo].[Films] OFF

SET IDENTITY_INSERT [dbo].[Screenings] ON
INSERT INTO [dbo].[Screenings] ([Id], [Time], [ScreenID], [FilmID]) VALUES (1, N'2025-04-12 12:30:00', 1, 1)
INSERT INTO [dbo].[Screenings] ([Id], [Time], [ScreenID], [FilmID]) VALUES (2, N'2025-04-12 14:30:00', 1, 1)
INSERT INTO [dbo].[Screenings] ([Id], [Time], [ScreenID], [FilmID]) VALUES (3, N'2025-04-12 16:30:00', 1, 1)
INSERT INTO [dbo].[Screenings] ([Id], [Time], [ScreenID], [FilmID]) VALUES (4, N'2025-04-12 18:30:00', 1, 1)

INSERT INTO [dbo].[Screenings] ([Id], [Time], [ScreenID], [FilmID]) VALUES (5, N'2025-04-12 12:30:00', 2, 2)
INSERT INTO [dbo].[Screenings] ([Id], [Time], [ScreenID], [FilmID]) VALUES (6, N'2025-04-12 14:30:00', 2, 2)
INSERT INTO [dbo].[Screenings] ([Id], [Time], [ScreenID], [FilmID]) VALUES (7, N'2025-04-12 16:30:00', 2, 2)
INSERT INTO [dbo].[Screenings] ([Id], [Time], [ScreenID], [FilmID]) VALUES (8, N'2025-04-12 18:30:00', 2, 2)

INSERT INTO [dbo].[Screenings] ([Id], [Time], [ScreenID], [FilmID]) VALUES (9, N'2025-04-12 12:30:00', 3, 3)
INSERT INTO [dbo].[Screenings] ([Id], [Time], [ScreenID], [FilmID]) VALUES (10, N'2025-04-12 14:30:00', 3, 3)
INSERT INTO [dbo].[Screenings] ([Id], [Time], [ScreenID], [FilmID]) VALUES (11, N'2025-04-12 16:30:00', 3, 3)
INSERT INTO [dbo].[Screenings] ([Id], [Time], [ScreenID], [FilmID]) VALUES (12, N'2025-04-12 18:30:00', 3, 3)

INSERT INTO [dbo].[Screenings] ([Id], [Time], [ScreenID], [FilmID]) VALUES (13, N'2025-04-12 12:30:00', 4, 4)
INSERT INTO [dbo].[Screenings] ([Id], [Time], [ScreenID], [FilmID]) VALUES (14, N'2025-04-12 14:30:00', 4, 4)
INSERT INTO [dbo].[Screenings] ([Id], [Time], [ScreenID], [FilmID]) VALUES (15, N'2025-04-12 16:30:00', 4, 4)
INSERT INTO [dbo].[Screenings] ([Id], [Time], [ScreenID], [FilmID]) VALUES (16, N'2025-04-12 18:30:00', 4, 4)

INSERT INTO [dbo].[Screenings] ([Id], [Time], [ScreenID], [FilmID]) VALUES (17, N'2025-04-12 12:30:00', 5, 5)
INSERT INTO [dbo].[Screenings] ([Id], [Time], [ScreenID], [FilmID]) VALUES (18, N'2025-04-12 14:30:00', 5, 5)
INSERT INTO [dbo].[Screenings] ([Id], [Time], [ScreenID], [FilmID]) VALUES (19, N'2025-04-12 16:30:00', 5, 5)
INSERT INTO [dbo].[Screenings] ([Id], [Time], [ScreenID], [FilmID]) VALUES (20, N'2025-04-12 18:30:00', 5, 5)

INSERT INTO [dbo].[Screenings] ([Id], [Time], [ScreenID], [FilmID]) VALUES (21, N'2025-04-12 12:30:00', 6, 6)
INSERT INTO [dbo].[Screenings] ([Id], [Time], [ScreenID], [FilmID]) VALUES (22, N'2025-04-12 14:30:00', 6, 6)
INSERT INTO [dbo].[Screenings] ([Id], [Time], [ScreenID], [FilmID]) VALUES (23, N'2025-04-12 16:30:00', 6, 6)
INSERT INTO [dbo].[Screenings] ([Id], [Time], [ScreenID], [FilmID]) VALUES (24, N'2025-04-12 18:30:00', 6, 6)

INSERT INTO [dbo].[Screenings] ([Id], [Time], [ScreenID], [FilmID]) VALUES (25, N'2025-04-12 12:30:00', 7, 7)
INSERT INTO [dbo].[Screenings] ([Id], [Time], [ScreenID], [FilmID]) VALUES (26, N'2025-04-12 14:30:00', 7, 7)
INSERT INTO [dbo].[Screenings] ([Id], [Time], [ScreenID], [FilmID]) VALUES (27, N'2025-04-12 16:30:00', 7, 7)
INSERT INTO [dbo].[Screenings] ([Id], [Time], [ScreenID], [FilmID]) VALUES (28, N'2025-04-12 18:30:00', 7, 7)

INSERT INTO [dbo].[Screenings] ([Id], [Time], [ScreenID], [FilmID]) VALUES (29, N'2025-04-12 12:30:00', 8, 8)
INSERT INTO [dbo].[Screenings] ([Id], [Time], [ScreenID], [FilmID]) VALUES (30, N'2025-04-12 14:30:00', 8, 8)
INSERT INTO [dbo].[Screenings] ([Id], [Time], [ScreenID], [FilmID]) VALUES (31, N'2025-04-12 16:30:00', 8, 8)
INSERT INTO [dbo].[Screenings] ([Id], [Time], [ScreenID], [FilmID]) VALUES (32, N'2025-04-12 18:30:00', 8, 8)

INSERT INTO [dbo].[Screenings] ([Id], [Time], [ScreenID], [FilmID]) VALUES (33, N'2025-04-15 12:30:00', 1, 1)
INSERT INTO [dbo].[Screenings] ([Id], [Time], [ScreenID], [FilmID]) VALUES (34, N'2025-04-15 14:30:00', 1, 1)
INSERT INTO [dbo].[Screenings] ([Id], [Time], [ScreenID], [FilmID]) VALUES (35, N'2025-04-15 16:30:00', 1, 1)
INSERT INTO [dbo].[Screenings] ([Id], [Time], [ScreenID], [FilmID]) VALUES (36, N'2025-04-15 18:30:00', 1, 1)

INSERT INTO [dbo].[Screenings] ([Id], [Time], [ScreenID], [FilmID]) VALUES (37, N'2025-04-15 12:30:00', 2, 2)
INSERT INTO [dbo].[Screenings] ([Id], [Time], [ScreenID], [FilmID]) VALUES (38, N'2025-04-15 14:30:00', 2, 2)
INSERT INTO [dbo].[Screenings] ([Id], [Time], [ScreenID], [FilmID]) VALUES (39, N'2025-04-15 16:30:00', 2, 2)
INSERT INTO [dbo].[Screenings] ([Id], [Time], [ScreenID], [FilmID]) VALUES (40, N'2025-04-15 18:30:00', 2, 2)

INSERT INTO [dbo].[Screenings] ([Id], [Time], [ScreenID], [FilmID]) VALUES (41, N'2025-04-15 12:30:00', 3, 3)
INSERT INTO [dbo].[Screenings] ([Id], [Time], [ScreenID], [FilmID]) VALUES (42, N'2025-04-15 14:30:00', 3, 3)
INSERT INTO [dbo].[Screenings] ([Id], [Time], [ScreenID], [FilmID]) VALUES (43, N'2025-04-15 16:30:00', 3, 3)
INSERT INTO [dbo].[Screenings] ([Id], [Time], [ScreenID], [FilmID]) VALUES (44, N'2025-04-15 18:30:00', 3, 3)

INSERT INTO [dbo].[Screenings] ([Id], [Time], [ScreenID], [FilmID]) VALUES (45, N'2025-04-15 12:30:00', 4, 4)
INSERT INTO [dbo].[Screenings] ([Id], [Time], [ScreenID], [FilmID]) VALUES (46, N'2025-04-15 14:30:00', 4, 4)
INSERT INTO [dbo].[Screenings] ([Id], [Time], [ScreenID], [FilmID]) VALUES (47, N'2025-04-15 16:30:00', 4, 4)
INSERT INTO [dbo].[Screenings] ([Id], [Time], [ScreenID], [FilmID]) VALUES (48, N'2025-04-15 18:30:00', 4, 4)


SET IDENTITY_INSERT [dbo].[Screenings] OFF

SET IDENTITY_INSERT [dbo].[TicketType] ON
INSERT INTO [dbo].[TicketType] ([Id], [Name], [Price]) VALUES (1, N'Adult', 9.99)
INSERT INTO [dbo].[TicketType] ([Id], [Name], [Price]) VALUES (2, N'Student', 6.99)
INSERT INTO [dbo].[TicketType] ([Id], [Name], [Price]) VALUES (3, N'Child', 4.99)
SET IDENTITY_INSERT [dbo].[TicketType] OFF

