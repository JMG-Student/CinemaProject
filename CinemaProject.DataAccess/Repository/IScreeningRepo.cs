using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CinemaProject.DataAccess.Repository;
using CinemaProject.Models.Models;

namespace CinemaProject.DataAccess.Repository
{
	public interface IScreeningRepo: IRepository<Screening>
	{

		void SaveAll();

}
}
