SET IDENTITY_INSERT [dbo].[Caps] ON
INSERT INTO [dbo].[Caps] ([Id], [Capacity]) VALUES (1, 15)
SET IDENTITY_INSERT [dbo].[Caps] OFF

SET IDENTITY_INSERT [dbo].[Screens] ON
INSERT INTO [dbo].[Screens] ([Id], [CapId]) VALUES (1, 1)
INSERT INTO [dbo].[Screens] ([Id], [CapId]) VALUES (2, 1)
INSERT INTO [dbo].[Screens] ([Id], [CapId]) VALUES (3, 1)
INSERT INTO [dbo].[Screens] ([Id], [CapId]) VALUES (4, 1)
SET IDENTITY_INSERT [dbo].[Screens] OFF

SET IDENTITY_INSERT [dbo].[Genres] ON
INSERT INTO [dbo].[Genres] ([Id], [Name]) VALUES (1, N'Western')
INSERT INTO [dbo].[Genres] ([Id], [Name]) VALUES (2, N'Horror')
SET IDENTITY_INSERT [dbo].[Genres] OFF

SET IDENTITY_INSERT [dbo].[Films] ON
INSERT INTO [dbo].[Films] ([Id], [Title], [Description], [PosterLink], [GenreId], [TrailerLink], [Runtime]) VALUES (1, N'The Shining', N'Jack Torrance is a winter caretaker at the Overlook Hotel. He lives there with his wife Wendy and son Danny. However, things take a turn when Danny and his family start witnessing supernatural events.', N'\Images\Films\1ec70bf4-1bf3-4bc1-9a12-2804c55b0279.jpg', 2, N'https://www.youtube.com/embed/FZQvIJxG9Xs?si=bR3pUHXksmUCdtKI', 146)
INSERT INTO [dbo].[Films] ([Id], [Title], [Description], [PosterLink], [GenreId], [TrailerLink], [Runtime]) VALUES (2, N'The Good the Bad and the Ugly', N'A bounty hunting expedition brings two men together in an uncomfortable alliance while looking for buried treasure. They also battle with a wanted outlaw who wants to settle an old score with them.', N'\Images\Films\bbf93702-550e-4dac-8342-7b728735e3c0.jfif', 1, N'https://www.youtube.com/embed/IFNUGzCOQoI?si=kGpFBY8RVZ18-l6A', 161)
INSERT INTO [dbo].[Films] ([Id], [Title], [Description], [PosterLink], [GenreId], [TrailerLink], [Runtime]) VALUES (3, N'For a Few Dollars More', N'While chasing El Indio, a most-wanted criminal, Monco meets Colonel Douglas Mortimer, who incidentally is also looking for El Indio. They enter into a partnership and decide to split the reward.', N'\Images\Films\35a2b286-5d34-43cd-ab64-8c3a1a867fee.jpg', 1, N'https://www.youtube.com/embed/bNt9NcLteoU?si=c_jXQBTt_yucWl4O', 132)
INSERT INTO [dbo].[Films] ([Id], [Title], [Description], [PosterLink], [GenreId], [TrailerLink], [Runtime]) VALUES (4, N'Alien', N'The crew of a spacecraft, Nostromo, intercept a distress signal from a planet and set out to investigate it. However, to their horror, they are attacked by an alien which later invades their ship.', N'\Images\Films\ca8fbd2c-6e29-48e4-86d9-d0b2f1aa987c.jpg', 2, N'https://www.youtube.com/embed/4lRNBd8Vook?si=iQr1ndnHLusTIVnh', 117)
SET IDENTITY_INSERT [dbo].[Films] OFF

SET IDENTITY_INSERT [dbo].[Screenings] ON
INSERT INTO [dbo].[Screenings] ([Id], [Time], [ScreenID], [FilmID]) VALUES (1, N'2025-03-29 18:30:00', 1, 2)
INSERT INTO [dbo].[Screenings] ([Id], [Time], [ScreenID], [FilmID]) VALUES (2, N'2025-03-29 18:30:00', 2, 3)
INSERT INTO [dbo].[Screenings] ([Id], [Time], [ScreenID], [FilmID]) VALUES (3, N'2025-03-29 18:30:00', 3, 1)
INSERT INTO [dbo].[Screenings] ([Id], [Time], [ScreenID], [FilmID]) VALUES (4, N'2025-03-29 18:30:00', 4, 4)
SET IDENTITY_INSERT [dbo].[Screenings] OFF

SET IDENTITY_INSERT [dbo].[TicketType] ON
INSERT INTO [dbo].[TicketType] ([Id], [Name], [Price]) VALUES (1, N'Adult', 9.99)
INSERT INTO [dbo].[TicketType] ([Id], [Name], [Price]) VALUES (2, N'Student', 6.99)
INSERT INTO [dbo].[TicketType] ([Id], [Name], [Price]) VALUES (3, N'Child', 4.99)
SET IDENTITY_INSERT [dbo].[TicketType] OFF

