using Core.Entities;
using Core.Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities.DTOs
{
    public class TransferRequestDetailDto : IDto
    {
        public int Id { get; set; }
        public User? User { get; set; } 
        public string? DestinationCourthouseName { get; set; }
        public string? TransferTypeName { get; set; }
        public DateTime RequestDate { get; set; }
    }
}
