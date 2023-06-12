using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using WebAppResturantDemoApp.Models;
using WebAppResturantDemoApp.Repositories;
using WebAppResturantDemoApp.ViewModel;

namespace WebAppResturantDemoApp.Controllers
{
    public class HomeController : Controller
    {
        private readonly ResturantDbEntities ResturantDbEntities;
        public HomeController()
        {
            ResturantDbEntities = new ResturantDbEntities();
        }
        public ActionResult Index()
        {
            CustomerRepository objCustomerRepository = new CustomerRepository();
            ItemRepository objItemRepository = new ItemRepository();
            PaymentTypeRepository objPaymentTypeRepository = new PaymentTypeRepository();

            var objMultipleModels = new Tuple<IEnumerable<SelectListItem>, IEnumerable<SelectListItem>, IEnumerable<SelectListItem>>(objCustomerRepository.GetAllCustomer(), objItemRepository.GetAllItem(), objPaymentTypeRepository.GetAllPaymentType());

            return View(objMultipleModels);
        }

        [HttpGet]
        public JsonResult getItemUnitPrice(int itemId)
        {
            decimal UnitPrice = ResturantDbEntities.Items.Single(model => model.ItemId == itemId).ItemPrice;
            return Json(UnitPrice, JsonRequestBehavior.AllowGet);
        }

        [HttpPost]
        public JsonResult Index(OrderViewModel objOrderViewModel)
        {
            OrderRepository objOrderRespository = new OrderRepository();
            bool isStatus = objOrderRespository.AddOrder(objOrderViewModel);
            string SuccessMessage = String.Empty;

            if (isStatus)
            {
                SuccessMessage = "Your Order Has Been Successfully Placed.";
            }
            else
            {
                SuccessMessage = "There Is Some Issue While Placing Order.";
            }

            return Json(SuccessMessage, JsonRequestBehavior.AllowGet);
        }      
    }
}