using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using WebAppResturantDemoApp.Models;

namespace WebAppResturantDemoApp.Repositories
{
    public class CustomerRepository
    {
        private ResturantDbEntities objResturantDBEntities;
        public CustomerRepository()
        {
            objResturantDBEntities = new ResturantDbEntities();
        }

        public IEnumerable<System.Web.Mvc.SelectListItem> GetAllCustomer()
        {
            var objSelectListItems = new List<System.Web.Mvc.SelectListItem>();
            objSelectListItems = (from obj in objResturantDBEntities.Customers
                                  select new System.Web.Mvc.SelectListItem()
                                  {
                                      Text = obj.CustomerName,
                                      Value = obj.CustomerId.ToString(),
                                      Selected = true
                                  }).ToList();
            return objSelectListItems;
        }
    }
}