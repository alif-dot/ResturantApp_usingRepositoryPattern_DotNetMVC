using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using WebAppResturantDemoApp.Models;

namespace WebAppResturantDemoApp.Repositories
{
    public class ItemRepository
    {
        private ResturantDbEntities objResturantDBEntities;
        public ItemRepository()
        {
            objResturantDBEntities = new ResturantDbEntities();
        }

        public IEnumerable<System.Web.Mvc.SelectListItem> GetAllItem()
        {
            var objSelectListItems = new List<System.Web.Mvc.SelectListItem>();
            objSelectListItems = (from obj in objResturantDBEntities.Items
                                  select new System.Web.Mvc.SelectListItem()
                                  {
                                      Text = obj.ItemName,
                                      Value = obj.ItemId.ToString(),
                                      Selected = true
                                  }).ToList();
            return objSelectListItems;
        }
    }
}