using Core.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities.Concrete
{
    public class TransferRequest:IEntity //tayin talep
    {
        public int Id { get; set; }
        public int UsertId { get; set; }
        public int DestinationCourthouseId { get; set; }
        public Courthouse? DestinationCourthouse { get; set; } // Optional, for convenience
        public int TransferTypeId { get; set; }
        public TransferType? TransferType { get; set; } // Optional, for convenience
        public DateTime RequestDate { get; set; }


    }
}
