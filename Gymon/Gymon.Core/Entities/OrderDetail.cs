﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Gymon.Core.Entities
{
    public class OrderDetail : BaseEntity
    {
        public string FullName { get; set; }
        public User User { get; set; }
        public int UserId { get; set; }
        public string Email { get; set; }
        public string City { get; set; }
        public string State { get; set; }
        public string Country { get; set; }
        public string PostalCode { get; set; }
        public string Phone { get; set; }
        public string Address { get; set; }
        public string OrderNote { get; set; }
        public decimal TotalAmount { get; set; } // Toplam tutar
    }
}
