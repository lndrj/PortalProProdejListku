﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Portal.Domain.Entities
{
    public class OrderItem : Entity<int>
    {
        //Cizí klíč
        [ForeignKey(nameof(Order))]
        public int OrderID { get; set; }
        [ForeignKey(nameof(Akce))]
        public int AkceID { get; set; }
        public int Amount { get; set; }
        public double Price { get; set; }
        public Order Order { get; set; }
        public Akce Akce { get; set; }
    }
}
