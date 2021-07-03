using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using YCC.ViewModels.Sales;

namespace YCC.WebApp.Models
{
    public class CheckoutViewModel
    {
        public List<CartItemViewModel> CartItems { get; set; }

        public CheckoutRequest CheckoutModel { get; set; }
    }
}
