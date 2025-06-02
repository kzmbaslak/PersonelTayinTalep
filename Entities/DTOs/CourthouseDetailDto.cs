using Core.Entities.Concrete;
using Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities.DTOs
{
    public class CourthouseDetailDto
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public City City { get; set; }
    }
}
