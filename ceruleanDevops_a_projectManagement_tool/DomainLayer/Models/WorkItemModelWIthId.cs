﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLOgic.Models
{
    public class WorkItemModelWIthId
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public int status { get; set; }
        public string Description { get; set; }
        public string Type { get; set; }
        public string area { get; set; }
        public string iteration { get; set; }
        public string priority { get; set; }
        public DateTime startDate { get; set; }
        public DateTime endDate { get; set; }
        public string user {  get; set; }
    }
}
