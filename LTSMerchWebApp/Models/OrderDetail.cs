﻿using System;
using System.Collections.Generic;

namespace LTSMerchWebApp.Models;

public partial class OrderDetail
{
    public int OrderDetailId { get; set; }

    public int? OrderId { get; set; }

    public int? ProductOptionId { get; set; }

    public int Quantity { get; set; }

    public decimal Price { get; set; }

    public virtual Order? Order { get; set; }

    public virtual ProductOption? ProductOption { get; set; }
}
