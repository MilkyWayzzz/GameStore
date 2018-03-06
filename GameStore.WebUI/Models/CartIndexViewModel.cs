using GameStore.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace GameStore.WebUI.Models
{
    public class CartIndexViewModel
    {
        //vlad test
        public Cart Cart { get; set; }
        public string ReturnUrl { get; set; }
    }
}