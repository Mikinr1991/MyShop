using MyShop.Core.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web;

namespace MyShop.Core.ViewModels
{
    public class BasketSummaryViewModel
    {
        public int BasketCount { get; set; }
        public Decimal BasketTotal { get; set; }


        public BasketSummaryViewModel() { }

        public BasketSummaryViewModel(int basketCount,int basketTotal) {
            this.BasketCount = basketCount;
            this.BasketTotal = basketTotal;
        }

        
    }
}
