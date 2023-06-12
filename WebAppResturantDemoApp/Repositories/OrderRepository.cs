using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using WebAppResturantDemoApp.Models;
using WebAppResturantDemoApp.ViewModel;

namespace WebAppResturantDemoApp.Repositories
{
    public class OrderRepository
    {
        private readonly ResturantDbEntities resturantDBEntities;

        public OrderRepository()
        {
            resturantDBEntities = new ResturantDbEntities();
        }

  
        public bool AddOrder(OrderViewModel orderViewModel)
        {
            try
            {
                Order objOrder = new Order()
                {
                    CustomerId = orderViewModel.CustomerId,
                    FinalTotal = orderViewModel.FinalTotal,
                    OrderDate = orderViewModel.OrderDate,
                    OrderNumber = String.Format("{0:ddmmyyyyhhmmss}", DateTime.Now),
                    PaymentTypeId = orderViewModel.PaymentTypeId,
                };
                resturantDBEntities.Orders.Add(objOrder);
                resturantDBEntities.SaveChanges();

                foreach (var item in orderViewModel.listOrderDetailViewModel)
                {
                    var objOrderDetails = new Orderdeatil()
                    {
                        Discount = item.Discount,
                        ItemId = item.ItemId,
                        Quantity = item.Quantity,
                        OredrId = objOrder.OrderId,
                        Total = item.Total,
                        UnitePrice = item.UnitPrice
                    };
                    resturantDBEntities.Orderdeatils.Add(objOrderDetails);
                    resturantDBEntities.SaveChanges();

                    Transaction objTransaction = new Transaction()
                    {
                        ItemId = item.ItemId,
                        Quantity = (-1) * item.Quantity,
                        TransactionDate = orderViewModel.OrderDate,
                        TypeId = 2
                    };
                    resturantDBEntities.Transactions.Add(objTransaction);
                    resturantDBEntities.SaveChanges();
                }
                return true;
            }
            catch
            {
                return false;
            }
        }       
    }
}