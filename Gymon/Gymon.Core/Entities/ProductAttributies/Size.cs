﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Gymon.Core.Entities.ProductAttributies
{
    public class Size : BaseEntity
    {
        public string Name { get; set; }
        public ICollection<ProductAttributeSize> ProductAttributeSizes { get; set; } // Navigation property
    }

}
