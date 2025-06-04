using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities.DTOs
{
    public class TransferRequestDto
    {
        public int CityId { get; set; }
        public int DestinationCourthouseId { get; set; }
        public int TransferTypeId { get; set; }
    }
}
