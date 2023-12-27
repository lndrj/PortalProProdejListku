﻿using Portal.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Portal.Application.ViewModels
{
    public class CartViewModel
    {
        public List<OrderItem> orderItems { get; set; }
        public double totalPrice { get; set; }
    }
}
