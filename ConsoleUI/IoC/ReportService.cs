using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleUI.IoC
{
    public interface IReportService
    {
        void GenerateReport();
    }

    public class ReportService : IReportService
    {
        private readonly ILogger _logger;

        public ReportService(ILogger logger)
        {
            _logger = logger;
        }

        public void GenerateReport()
        {
            _logger.Log("Report generated successfully.");
        }
    }

}
