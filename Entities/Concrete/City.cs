﻿using Core.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities.Concrete
{
    public class City:IEntity
    {
        public int Id { get; set; }
        public string? Name { get; set; }
        public ICollection<Courthouse>? Courthouses { get; set; }
    }
}
