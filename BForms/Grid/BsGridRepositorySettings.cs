﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using DocumentFormat.OpenXml.Bibliography;

namespace BForms.Grid
{
    public class BsGridRepositorySettings<TSearch> : BsGridBaseRepositorySettings
    {
        public TSearch Search { get; set; }

        public string QuickSearch { get; set; }
    }



    public class BsGridBaseRepositorySettings : BsBaseRepositorySettings
    {
        public List<BsColumnOrder> OrderableColumns { get; set; } // order grid by column

        public Dictionary<string, int> OrderColumns { get; set; } // swap columns order

        public int DetailsStartIndex { get; set; }

        public int DetailsCount { get; set; }

        public bool DetailsAll { get; set; }

        public BsGridBaseRepositorySettings GetBase()
        {
            return new BsGridBaseRepositorySettings
            {
                OrderColumns = this.OrderColumns,
                OrderableColumns = this.OrderableColumns,
                Page = this.Page,
                PageSize = this.PageSize,
                DetailsAll = DetailsAll,
                DetailsCount = DetailsCount,
                DetailsStartIndex = DetailsStartIndex
            };
        }

        public BsGridBaseRepositorySettings()
        {
            this.Page = 1;
            this.PageSize = 5;
            this.OrderableColumns= new List<BsColumnOrder>();
        }

        public void SetDetailsInterval(int count)
        {
            SetDetailsInterval(0, count);
        }

        public void SetDetailsInterval(int startIndex, int count)
        {
            this.DetailsStartIndex = startIndex;
            this.DetailsCount = count;
        }

        public bool HasDetails(int index)
        {
            return this.DetailsAll || index >= DetailsStartIndex && index <= DetailsStartIndex + DetailsCount - 1;
        }
    }

    public class BsBaseRepositorySettings
    {
        public BsBaseRepositorySettings()
        {
            this.Page = 1;
            this.PageSize = 5;
        }

        public int Page { get; set; }

        public int PageSize { get; set; }
    }
}