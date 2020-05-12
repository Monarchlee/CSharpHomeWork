using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Threading.Tasks;

namespace OrderApi.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class OrderController:ControllerBase
    {
        private readonly OrderContext orderDb;
        public OrderController(OrderContext context)
        {
            this.orderDb = context;
        }
        [HttpGet]
        public ActionResult<List<Order>> GetOrder(string cusName,string comName,double? amount)
        {
            IQueryable<Order> query = AllOrders();
            if(comName!=null)
            {
                query = GetByCommodity(comName);
            }
            if(cusName!=null)
            {
                query = query.Where(x => x.CustomerName == cusName);
            }
            if(amount!=null)
            {
                query = query.Where(o => o.OrderItems.Sum(item => item.Quantity * item.Commodity.Price) > amount);
            }
            if (query.Any()==false)
                return NoContent();

            return query.ToList();

        }

        [HttpGet("{id}")]
        public ActionResult<Order> GetOrderById(int id)
        {
            return GetById(id);
        }

        [HttpPost]
        public ActionResult<Order> PostOrder(Order order)
        {
            try
            {
                Customer test = GetCustomer(order);
                if(test!=null)
                {
                    order.Customer = test;
                }
                foreach(OrderItem item in order.OrderItems)
                {
                    Commodity temp = orderDb.Commodities.SingleOrDefault(i => i.Name == item.CommodityName||i.Name==item.Commodity.Name);
                    if (temp!=null)
                    {
                        item.Commodity = temp;
                    }
                }
                orderDb.Orders.Add(order);
                orderDb.SaveChanges();
            }
            catch(Exception e)
            {
                return BadRequest(e.InnerException.Message);
            }
            return order;
        }

        [HttpDelete("{id}")]
        public ActionResult DeleteOrder(int id)
        {
            try
            {
                var target = orderDb.Orders.Include("OrderItems").SingleOrDefault(o => o.OrderId == id);
                if(target!=null)
                {
                    orderDb.Orders.Remove(target);
                    orderDb.SaveChanges();
                }
            }
            catch(Exception e)
            {
                return BadRequest(e.InnerException.Message);
            }
            return NoContent();
        }


        [HttpPut("{id}")]
        public ActionResult<Order> PutOrder(int id,Order order)
        {
            if(id!=order.OrderId)
            {
                return BadRequest("Id can't be modified!");
            }
            try
            {
                DeleteOrder(id);
                PostOrder(order);
            }
            catch(Exception e)
            {
                string error = e.Message;
                if(e.InnerException!=null)
                {
                    error = e.InnerException.Message;
                }
                return BadRequest(error);
            }
            return NoContent();
        }




        private Order GetById(int id)
        {
            return orderDb.Orders.Include("OrderItems").Include("Customer").SingleOrDefault(x => x.OrderId == id);
        }
        private IQueryable<Order> AllOrders()
        {
            return orderDb.Orders.Include("OrderItems")
                .Include("Customer");
        }
        private IQueryable<Order> GetByCommodity(string name)
        {
            return AllOrders().Where(x => x.OrderItems.Count(i => i.CommodityName == name) > 0);
        }
        private IQueryable<Order> GetByCustomer(string name)
        {
            return AllOrders().Where(x => x.CustomerName == name);
        }
        private Customer GetCustomer(Order order)
        {
            return orderDb.Customers.SingleOrDefault(o => o.Name == order.CustomerName||o.Name==order.Customer.Name);
        }
    }
}
