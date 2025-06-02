using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleUI.IoC
{
    public class App
    {
        private readonly IReportService _reportService;

        public App(IReportService reportService)
        {
            _reportService = reportService;
        }

        public void Run()
        {
            _reportService.GenerateReport();
        }
    }

}
