﻿// <auto-generated> This file has been auto generated by EF Core Power Tools. </auto-generated>
#nullable disable
using System;
using System.Collections.Generic;

namespace ItemTransactionsAPI.Models
{
    public partial class Unit
    {
        public Unit()
        {
            Item = new HashSet<Item>();
        }

        public int Id { get; set; }
        public string UnitName { get; set; }

        public virtual ICollection<Item> Item { get; set; }
    }
}