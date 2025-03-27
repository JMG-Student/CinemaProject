using CinemaProject.Models.Models;
using CinemaProject.Services;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace CinemaProject.Pages.Admin.Reports
{
    public class IndexModel : PageModel
    {
        private readonly IUnitOfWork _unitOfWork;

        public IEnumerable<Pages_Admin_Reports_CreateReport> Reports { get; set; }

        public ReportDataModel ReportData { get; set; }

        public IndexModel(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public void OnGet()
        {
            ReportData = new ReportDataModel
            {
                GeneratedOn = DateTime.Now,
                TotalBookings = 100,
                TotalTicketsSold = 250,
                TotalRevenue = 4000.50m
            };
        }
    }

    public class ReportDataModel
    {
        public DateTime GeneratedOn { get; set; }
        public int TotalBookings { get; set; }
        public int TotalTicketsSold { get; set; }
        public decimal TotalRevenue { get; set; }
    }
}
//using CinemaProject.Models.Models;
//using CinemaProject.Services;
//using Microsoft.AspNetCore.Mvc.RazorPages;

//namespace CinemaProject.Pages.Admin.Reports
//{
//    namespace CinemaProject.Pages.Admin.Reports
//    {
//        public class IndexModel : PageModel
//        {
//            private readonly IUnitOfWork _unitOfWork;

//            public IEnumerable<Pages_Admin_Reports_CreateReport> Reports { get; set; }

//            public ReportDataModel ReportData { get; set; } // Add this class or use your own model

//            public IndexModel(IUnitOfWork unitOfWork)
//            {
//                _unitOfWork = unitOfWork;
//            }

//            public void OnGet()
//            {
//                // Dummy example - replace with actual logic
//                ReportData = new ReportDataModel
//                {
//                    GeneratedOn = DateTime.Now,
//                    TotalBookings = 100,
//                    TotalTicketsSold = 250,
//                    TotalRevenue = 4000.50m
//                };
//            }
//        }

//        public class ReportDataModel
//        {
//            public DateTime GeneratedOn { get; set; }
//            public int TotalBookings { get; set; }
//            public int TotalTicketsSold { get; set; }
//            public decimal TotalRevenue { get; set; }
//        }
//    }
//    //public class IndexModel : PageModel
//    //{
//    //    private readonly IUnitOfWork _unitOfWork;

//    //    public IEnumerable<Pages_Admin_Reports_CreateReport> reports { get; set; }

//    //    public IndexModel(IUnitOfWork unitOfWork)
//    //    {
//    //        _unitOfWork = unitOfWork;
//    //    }
//    //    public void OnGet()
//    //    {
//    //        Genres = _unitOfWork.GenreRepo.GetAll();
//    //    }
//    //}

//}