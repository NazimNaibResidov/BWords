using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BWords.Common.Models.Pages
{

    public class Page
    {
        public Page():this(0)
        {

        }
        public Page(int TotalRowCount):this(1,10, TotalRowCount)
        {

        }
        public Page(int PageSize,int TotalRowCount):this(1,PageSize,TotalRowCount)
        {

        }

        public Page(int currentPage, int pageSize, int totalRowCount) 
        {
            if (currentPage < 1)
                throw new ArgumentException("Invalid page number!");
            if (pageSize<1)
                throw new ArgumentException("Invalid page number!");
            this.CurrentPage = currentPage;
            this.PageSize = pageSize;
            this.TotalRowCount = totalRowCount;

        }

        public int CurrentPage { get; set; }
        public int PageSize { get; set; }
        public int TotalRowCount { get; set; }
        public int TotoalPageCount => (int)Math.Ceiling((double)TotalRowCount / PageSize);
        public int Skip => (CurrentPage - 1) * PageSize;
    }

   
   
}
  

