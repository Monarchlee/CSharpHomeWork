using Microsoft.VisualStudio.TestTools.UnitTesting;
using OrderSystemNew;
using System;
using System.Collections.Generic;
using System.Text;
using System.IO;
using System.Linq;

namespace OrderSystemNew.Tests
{
    [TestClass()]
    public class OrderServiceTests
    {

        public Customer testCustomer = new Customer("administrator", Level.Diamond);
        public Customer testCustomerCopy = new Customer("administratorcopy", Level.Diamond);
        public List<OrderItem> KaraItems = new List<OrderItem>
            {
                new OrderItem(new Commodity("Alter saber lily", 999.5), 1),
                new OrderItem(new Commodity("Merlin", 1256), 1),
                new OrderItem(new Commodity("Sukura", 1305), 1),
                new OrderItem(new Commodity("Burger King", 56.3), 25)
            };
        public List<OrderItem> LeeItems = new List<OrderItem>
            {
                new OrderItem(new Commodity("Rem", 799), 1),
                new OrderItem(new Commodity("Battlefield BOSS", 49.5), 1),
                new OrderItem(new Commodity("RIO", 13), 15),
                new OrderItem(new Commodity("Burger King", 56.3), 13)
            };
        [TestMethod()]
        [ExpectedException(typeof(OrderException))]
        public void AddOrderTest()
        {
            OrderService orderService = new OrderService();
            Order testOrder = new Order(-1);
            testOrder.Customer = testCustomer;
            orderService.AddOrder(testOrder);
        }
        [TestMethod()]
        [ExpectedException(typeof(OrderException))]
        public void AddOrderTest_1()
        {
            OrderService orderService = new OrderService();
            Order testOrder1 = new Order(1);
            testOrder1.Customer = testCustomer.ShallowClone();
            Order testOrder2 = new Order(1);
            orderService.AddOrder(testOrder1);
            orderService.AddOrder(testOrder2);
        }
        [TestMethod()]
        public void AddOrderTest_2()
        {
            OrderService orderService = new OrderService();
            Order order = new Order(10);
            order.Customer = testCustomer;
            orderService.AddOrder(order);
            Assert.IsTrue(order.Equals(orderService.Orders[0]));
        }


        [TestMethod()]
        [ExpectedException(typeof(OrderException))]
        public void AddOrderTest1()
        {

            OrderService orderService = new OrderService();
            orderService.AddOrder(null, 10);
        }

        [TestMethod()]
        public void AddOrderTest2()
        {
            OrderService orderService = new OrderService();
            for (int i = 2; i < 10; i++)
            {
                orderService.AddOrder(testCustomer, i);
            }
            orderService.AddOrder(testCustomer);
            Assert.AreEqual(orderService.Orders[8].ID, 10);
        }

        [TestMethod()]
        [ExpectedException(typeof(OrderException))]
        public void UpdataItemsTest_1()
        {
            OrderService orderService = new OrderService();
            orderService.AddOrder(testCustomer);
            List<OrderItem> orderItems = new List<OrderItem>();
            orderItems.Add(new OrderItem(new Commodity("gun", 12.5), 3));
            orderService.UpdateItems(1, orderItems);
        }
        [TestMethod()]
        [ExpectedException(typeof(OrderException))]
        public void UpdataItemsTest_2()
        {
            OrderService orderService = new OrderService();
            orderService.AddOrder(testCustomer);
            orderService.UpdateItems(0, null);
        }

        [TestMethod()]
        public void UpdataItemsTest_3()
        {
            OrderService orderService = new OrderService();
            orderService.AddOrder(testCustomer);
            List<OrderItem> orderItems = new List<OrderItem>();
            orderItems.Add(new OrderItem(new Commodity("gun", 12.5), 3));
            orderService.UpdateItems(0, orderItems);
            Order expect = new Order(0);
            expect.Customer = testCustomer;
            expect.OrderItems.Add(orderItems[0]);
            Assert.AreEqual(expect, orderService.Orders[0]);
        }

        [TestMethod()]
        public void UpdateTest_1()
        {
            OrderService orderService = new OrderService();
            orderService.AddOrder(testCustomer);
            Order expect = new Order(0);
            expect.Customer = testCustomer.ShallowClone();
            orderService.Update(expect);
            Assert.AreEqual(expect, orderService.Orders[0]);
        }
        [TestMethod()]
        [ExpectedException(typeof(OrderException))]
        public void UpdateTest_2()
        {
            OrderService orderService = new OrderService();
            orderService.AddOrder(testCustomer);
            Order expect = new Order(2);
            orderService.Update(expect);
            Assert.AreEqual(expect, orderService.Orders[0]);
        }

        [TestMethod()]
        public void DeleteOneTest()
        {
            OrderService orderService = new OrderService();
            orderService.AddOrder(testCustomer);
            orderService.DeleteOne(0);
            Assert.AreEqual(0, orderService.Orders.Count);
        }

        [TestMethod()]
        public void DeleteAllTest()
        {
            OrderService orderService = new OrderService();
            orderService.AddOrder(testCustomer);
            orderService.DeleteAll();
            Assert.AreEqual(0, orderService.Orders.Count);
        }

        [TestMethod()]
        [ExpectedException(typeof(OrderException))]
        public void SortOrdersTest()
        {
            OrderService orderService = new OrderService();
            orderService.AddOrder(testCustomer);
            orderService.SortOrders(null);
        }



        [TestMethod()]
        [ExpectedException(typeof(OrderException))]
        public void QueryTest()
        {
            OrderService orderService = new OrderService();
            orderService.AddOrder(testCustomer);
            orderService.Query((Commodity)null);
        }

        [TestMethod()]
        [ExpectedException(typeof(OrderException))]
        public void QueryTest1()
        {
            OrderService orderService = new OrderService();
            orderService.AddOrder(testCustomer);
            orderService.Query((Customer)null);
        }

        [TestMethod()]
        public void QueryTest2()//test query through customer name
        {
            OrderService orderServiceQuery = new OrderService();
            orderServiceQuery.AddOrder(testCustomer);
            orderServiceQuery.UpdateItems(0, KaraItems);
            orderServiceQuery.AddOrder(testCustomerCopy);
            orderServiceQuery.UpdateItems(1, LeeItems);
            List<Order> customerQuery = orderServiceQuery.Query("administrator", OrderService.Type.customer).ToList();
            Assert.IsTrue(customerQuery[0].Customer.Equals(testCustomer));
        }

        [TestMethod()]
        public void QueryTest3()//test query through commodity name
        {
            OrderService orderServiceQuery = new OrderService();
            orderServiceQuery.AddOrder(testCustomer);
            orderServiceQuery.UpdateItems(0, KaraItems);
            orderServiceQuery.AddOrder(testCustomerCopy);
            orderServiceQuery.UpdateItems(1, LeeItems);
            List<Order> customerQuery = orderServiceQuery.Query("Sukura", OrderService.Type.commodity).ToList();
            Assert.IsTrue(customerQuery[0].Customer.Equals(testCustomer));
        }

        [TestMethod()]
        public void QueryTest4()// test query through order id
        {
            OrderService orderServiceQuery = new OrderService();
            orderServiceQuery.AddOrder(testCustomer);
            orderServiceQuery.UpdateItems(0, KaraItems);
            orderServiceQuery.AddOrder(testCustomerCopy);
            orderServiceQuery.UpdateItems(1, LeeItems);
            List<Order> customerQuery = (List<Order>)orderServiceQuery.Query("1", OrderService.Type.order).ToList();
            Assert.IsTrue(customerQuery[0].Customer.Equals(testCustomerCopy));
        }

        [TestMethod()]
        public void ExportTest_1()
        {
            OrderService orderServiceI_O = new OrderService();
            orderServiceI_O.AddOrder(testCustomer);
            orderServiceI_O.UpdateItems(0, KaraItems);
            orderServiceI_O.AddOrder(testCustomerCopy);
            orderServiceI_O.UpdateItems(1, LeeItems);
            orderServiceI_O.Export("Test_Exp.xml");
            Assert.IsTrue(File.Exists("Test_Exp.xml"));
        }
        [TestMethod()]
        public void ExportTest_2()
        {
            OrderService orderServiceI_O = new OrderService();
            orderServiceI_O.AddOrder(testCustomer);
            orderServiceI_O.UpdateItems(0, KaraItems);
            orderServiceI_O.AddOrder(testCustomerCopy);
            orderServiceI_O.UpdateItems(1, LeeItems);
            orderServiceI_O.Export("Test_Exp.xml");
            List<Order> temp = new List<Order>(orderServiceI_O.Orders);
            orderServiceI_O.Import("Test_Exp.xml");

            Assert.IsTrue(temp[0].Equals(orderServiceI_O.Orders[0]) && temp[1].Equals(orderServiceI_O.Orders[1]));
        }


        [TestMethod()]
        [ExpectedException(typeof(OrderException))]
        public void ExportTest_3()
        {
            OrderService orderServiceI_O = new OrderService();
            orderServiceI_O.AddOrder(testCustomer);
            orderServiceI_O.UpdateItems(0, KaraItems);
            orderServiceI_O.AddOrder(testCustomerCopy);
            orderServiceI_O.UpdateItems(1, LeeItems);
            orderServiceI_O.Export("Test_Exp");
        }


        [TestMethod()]
        public void ImportTest_1()
        {
            OrderService orderServiceI_O = new OrderService();
            orderServiceI_O.AddOrder(testCustomer);
            orderServiceI_O.UpdateItems(0, KaraItems);
            orderServiceI_O.AddOrder(testCustomerCopy);
            orderServiceI_O.UpdateItems(1, LeeItems);
            orderServiceI_O.Export("Test_Exp.xml");
            OrderService orderServiceIn = new OrderService();
            orderServiceIn.Import("Test_Exp.xml");
            Assert.IsTrue(orderServiceI_O.Orders[0].Equals(orderServiceIn.Orders[0])
                        && orderServiceI_O.Orders[1].Equals(orderServiceIn.Orders[1]));
        }
        [TestMethod()]
        [ExpectedException(typeof(OrderException))]
        public void ImportTest_2()
        {
            OrderService orderServiceIn = new OrderService();
            orderServiceIn.Import("x");
        }
        [TestMethod()]
        [ExpectedException(typeof(OrderException))]
        public void ImportTest_3()
        {
            OrderService orderServiceIn = new OrderService();
            orderServiceIn.Import(null);
        }
    }
}

namespace Class2Tests
{
    class OrderServiceTests
    {
    }
}
