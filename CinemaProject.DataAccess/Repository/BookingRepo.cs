﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;
using System.Text;
using System.Threading.Tasks;
using CinemaProject.DataAccess.DataAccess;
using CinemaProject.DataAccess.Repository;
using CinemaProject.Models.Models;

namespace CinemaProject.DataAccess.Repository
{
	public class BookingRepo : Repository<Booking>, IBookingRepo
	{
		private readonly AppDBContext _dbContext;
		public BookingRepo(AppDBContext dbContext) : base(dbContext)
		{
			_dbContext = dbContext;
		}
		public void SaveAll()
		{
			_dbContext.SaveChanges();
		}
	}

}
