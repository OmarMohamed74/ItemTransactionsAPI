﻿// <auto-generated> This file has been auto generated by EF Core Power Tools. </auto-generated>
#nullable disable
using System;
using System.Collections.Generic;

namespace ItemTransactionsAPI.Models
{
    public partial class Balance
    {
        public int Id { get; set; }
        public int Quantity { get; set; }
        public int ItemId { get; set; }
        public int WarHouseId { get; set; }

        public virtual Item Item { get; set; }
        public virtual Warhouse WarHouse { get; set; }
    }
}