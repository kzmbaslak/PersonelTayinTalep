using Core.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities.Concrete
{
    public class TransferType:IEntity
    {
        public int Id { get; set; }
        public string? Name { get; set; }
        public ICollection<TransferRequest>? TransferRequests { get; set; } // Optional, for convenience

    }
}
