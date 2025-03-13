﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CinemaProject.DataAccess.DataAccess;
using CinemaProject.DataAccess.Repository;
using CinemaProject.Models.Models;

namespace CinemaProject.DataAccess.Repository
{
	public class ScreeningRepo : Repository<Screening>, IScreeningRepo
	{
		private readonly AppDBContext _dbContext;
		public ScreeningRepo(AppDBContext dbContext) : base(dbContext)
		{
			_dbContext = dbContext;
		}
		public void SaveAll()
		{
			_dbContext.SaveChanges();
		}
	}

}