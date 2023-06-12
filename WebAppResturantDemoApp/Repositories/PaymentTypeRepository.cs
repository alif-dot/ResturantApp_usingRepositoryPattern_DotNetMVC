using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.WebPages.Html;
using WebAppResturantDemoApp.Models;

namespace WebAppResturantDemoApp.Repositories
{
    public class PaymentTypeRepository
    {
        private ResturantDbEntities objResturantDBEntities;
        public PaymentTypeRepository()
        {
            objResturantDBEntities = new ResturantDbEntities();
        }

        public IEnumerable<System.Web.Mvc.SelectListItem> GetAllPaymentType()
        {
            var objSelectListItems = new List<System.Web.Mvc.SelectListItem>();
            objSelectListItems = (from obj in objResturantDBEntities.PaymentTypes
                select new System.Web.Mvc.SelectListItem()
                {
                    Text = obj.PaymentTypeName,
                    Value = obj.PaymentTypeId.ToString(),
                    Selected = true
                }).ToList();
            return objSelectListItems;
        }
    }
}