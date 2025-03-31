﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Library.Common
{
    public class PaginationQuery
    {
        public int? PageSize { get; set; }
        public int? PageNumber { get; set; }
        public string? SortBy { get; set; }
        public bool? IsDescending { get; set; }
    }
}
