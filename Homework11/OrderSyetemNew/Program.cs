using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Xml.Serialization;
using System.IO;
using System.Data.Entity;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using OrderSyetemNew;
using System.Threading;
using System.Data.Entity.Validation;

namespace OrderSystemNew
{
    public enum Level { Bronze, Silver, Gold, Diamond };
    [Serializable]
    public class Customer
    {
        [Key]
        public string Name { get; set; }
        public Level Level { get; set; }
        [XmlIgnore]
        public List<Order> Orders { get; set; }//一对多关联
        public Customer() { }
        public Customer(string name, Level level)
        {
            Name = name;
            Level = level;
        }
        public override bool Equals(object obj)
        {
            Customer customer = obj as Customer;
            if (customer == null)
            {
                // throw new ArgumentException();
                return false;
            }
            return Name.Equals(customer.Name);
        }

        public override string ToString()
        {
            return "Level " + Level + ":" + Name;
        }
        public Customer ShallowClone()
        {
            return (Customer)this.MemberwiseClone();
        }

        public override int GetHashCode()
        {
            int hashCode = 1635173235;
            hashCode = hashCode * -1521134295 + EqualityComparer<string>.Default.GetHashCode(Name);
            hashCode = hashCode * -1521134295 + Level.GetHashCode();
            return hashCode;
        }
    }
    [Serializable]
    public class Commodity
    {
        [Key]
        public string Name { get; set; }
        public double Price { get; set; }
        [XmlIgnore]
        public List<OrderItem> OrderItems { get; set; }//一对多关联
        public Commodity() { }
        public Commodity(string name, double price)
        {
            Name = name;
            Price = price;
            if (price < 0)
            {
                throw new OrderException("Invalid price.", 5);
            }
        }
        public override bool Equals(object obj)
        {
            Commodity commodity = obj as Commodity;
            if (commodity == null)
            {
                // throw new ArgumentException();
                return false;
            }
            return Name.Equals(commodity.Name);
        }

        public override string ToString()
        {
            return Name + ":$" + Price;
        }
        public Commodity ShallowClone()
        {
            return (Commodity)this.MemberwiseClone();
        }

        public override int GetHashCode()
        {
            int hashCode = -44027456;
            hashCode = hashCode * -1521134295 + EqualityComparer<string>.Default.GetHashCode(Name);
            hashCode = hashCode * -1521134295 + Price.GetHashCode();
            return hashCode;
        }
    }
    public class Repository
    {
        public Dictionary<Commodity, int> commodities;
        public void ExecuteOrder(ref Order order)
        {
            foreach (OrderItem orderItem in order.OrderItems)
            {
                if (!commodities.TryGetValue(orderItem.Commodity, out int numofGoods))
                {
                    throw new OrderException("No such commodity.", 1);
                }
                numofGoods -= orderItem.Quantity;
                if (numofGoods <= 0)
                {
                    throw new OrderException("Repository can't satisfy this order!", 0);
                }
                commodities[orderItem.Commodity] = numofGoods;
            }
            order.IfSolved = true;
        }
        public void AddCommodities(Commodity commodity, int num)
        {

            if (!commodities.TryGetValue(commodity, out int existNum))
            {
                commodities.Add(commodity, num);
            }
            else
            {
                commodities[commodity] = existNum + num;
            }
        }
    }
    [Serializable]
    public class OrderItem
    {
        public int OrderItemId { get; set; }
        public int Quantity { get; set; }
        [ForeignKey("CommodityName")]
        public Commodity Commodity { get; set; }//多对一关联
        public string CommodityName { get; set; }
        [XmlIgnore]
        public Order Order { get; set; } //多对一关联
        public int OrderId { get; set; }
        public OrderItem(Commodity commodity, int num)
        {
            Commodity = new Commodity(commodity.Name, commodity.Price);
            Quantity = num;
        }
        public OrderItem() { Commodity = new Commodity(); }

        public override bool Equals(object obj)
        {
            OrderItem orderItem = obj as OrderItem;
            if (orderItem == null)
            {
                throw new ArgumentException();
            }
            return orderItem.OrderId==OrderId&&orderItem.CommodityName==CommodityName;
        }


        public override string ToString()
        {

            StringBuilder itemList = new StringBuilder();
            itemList.Append(Commodity.ToString());
            itemList.Append(" num:" + Quantity + "\n");
            return itemList.ToString();
        }
        public OrderItem DeepClone()
        {
            OrderItem orderItem = (OrderItem)this.MemberwiseClone();
            orderItem.Commodity = Commodity.ShallowClone();
            return orderItem;
        }

        public override int GetHashCode()
        {
            int hashCode = 1490080954;
            hashCode = hashCode * -1521134295 + EqualityComparer<Commodity>.Default.GetHashCode(Commodity);
            hashCode = hashCode * -1521134295 + Quantity.GetHashCode();
            return hashCode;
        }
    }


    [Serializable]
    public class Order
    {
        public int OrderId { get; set; }
        public List<OrderItem> OrderItems { get; set; }//一对多关联
        public bool IfSolved { get; set; }
        public DateTime Date { get; set; }

        [ForeignKey("CustomerName")]
        public Customer Customer { get; set; }//多对一关联

        public string CustomerName { get; set; }
        public double Sum
        {
            get
            {
                double sum = 0;
                using (var context=new OrderContext())
                {
                    var query = context.OrderItems
                        .Where(x => x.OrderId == OrderId);
                    
                    foreach(var orderItem in query.ToList())
                    {
                        var target = context.Commodities.FirstOrDefault(x => x.Name == orderItem.CommodityName);
                        if(target==null)
                        {
                            continue;
                        }
                        sum += orderItem.Quantity * target.Price;
                    }
                }
                return sum;
            }
            set
            {
            }
        }
        public Order(int id)
        {
            OrderItems = new List<OrderItem>();
            OrderId = id;
            Date = DateTime.Now;
            IfSolved = false;
        }
        public Order()
        {
            OrderItems = new List<OrderItem>();
            Date = DateTime.Now;
        }
        public override bool Equals(object obj)
        {
            Order order = (Order)obj;
            if (order == null)
            {
                throw new ArgumentException();
            }
            return OrderId == order.OrderId
                && IfSolved == order.IfSolved;
        }

        public override string ToString()
        {
            StringBuilder allItems = new StringBuilder("----------------\n");
            allItems.Append(Customer.ToString());
            foreach (OrderItem orderItems in OrderItems)
            {
                allItems.Append(orderItems.ToString());
            }
            allItems.Append(IfSolved ? "Solved" : "Unsolved");
            allItems.Append("\n" + Date + "\n--------------------------");
            return allItems.ToString();
        }
        public Order DeepClone()
        {
            Order order = (Order)this.MemberwiseClone();
            order.Customer = Customer==null? null:Customer.ShallowClone();
            order.OrderItems = new List<OrderItem>();
            order.Date = Date;
            foreach (OrderItem orderItems in OrderItems)
            {
                order.OrderItems.Add(orderItems.DeepClone());
            }
            return order;
        }
        public void UpdateItems(OrderItem orderItem)
        {
            using (var context=new OrderContext())
            {
                var target = context.OrderItems
                    .SingleOrDefault(x => x.CommodityName == orderItem.CommodityName && x.OrderId == orderItem.OrderId);
                if (target == null)
                {
                    orderItem.OrderId = OrderId;
                    context.Entry(orderItem).State = EntityState.Added;
                    context.SaveChanges();
                }
                else
                {
                    target.Quantity += orderItem.Quantity;
                    context.SaveChanges();
                    if (target.Quantity <= 0)
                    {
                        Delete(target);
                    }
                }
            }
 
        }
        public void Delete(OrderItem orderItem)
        {
            using (var context=new OrderContext())
            {
                var target = context.OrderItems
                    .SingleOrDefault(x => x.CommodityName == orderItem.CommodityName && x.OrderId == orderItem.OrderId);
                if(target!=null)
                {
                    context.OrderItems.Remove(target);
                    context.SaveChanges();
                }
            }
               // OrderItems.RemoveAll(item => item.Commodity.Equals(orderItem.Commodity));
        }

        public override int GetHashCode()
        {
            int hashCode = 1158521302;
            hashCode = hashCode * -1521134295 + OrderId.GetHashCode();
            hashCode = hashCode * -1521134295 + EqualityComparer<List<OrderItem>>.Default.GetHashCode(OrderItems);
            hashCode = hashCode * -1521134295 + IfSolved.GetHashCode();
            hashCode = hashCode * -1521134295 + Date.GetHashCode();
            hashCode = hashCode * -1521134295 + EqualityComparer<Customer>.Default.GetHashCode(Customer);
            hashCode = hashCode * -1521134295 + Sum.GetHashCode();
            return hashCode;
        }
    }

    public class OrderService
    {
        public enum Type { order, customer, commodity };


        public void AddOrder(Customer customer, int id)
        {
            if (customer is null)
            {
                throw new OrderException("Customer is null.", 8);
            }
            Order order = new Order(id);
            order.Customer = customer;
            AddOrder(order);
        }
        public int AddOrder(Customer customer)
        {
            bool flag = false;
            int count = 0;
            Order order = null;
            using (var context=new OrderContext())
            {
                count = context.Orders.Count();
                while (!flag)
                {
                    flag = true;
                    order = context.Orders.SingleOrDefault(x => x.OrderId == count);
                    if (order != null)
                    {
                        count++;
                        flag = false;
                    }
                }
            }
            AddOrder(customer, count);
            return count;

        }
        public void AddOrder(Order order)
        {
            if (order.OrderId < 0)
            {
                throw new OrderException("Invalid id.", 3);
            }
            using (var context=new OrderContext())
            {
                var exist = context.Orders.SingleOrDefault(x => x.OrderId == order.OrderId);
                if (exist != null)
                {
                    throw new OrderException("Id has existed.", 3);
                }
                else
                {
                    var existCustomer = context.Customers.SingleOrDefault(x=>x.Name==order.CustomerName||x.Name==order.Customer.Name);
                    if(existCustomer!=null)
                    {
                        order.Customer = existCustomer;
                    }
                    foreach(OrderItem orderItem in order.OrderItems)
                    {
                        var existCommodity = context.Commodities.SingleOrDefault(x => x.Name == orderItem.CommodityName || x.Name == orderItem.Commodity.Name);
                        if(existCommodity!=null)
                        {
                            orderItem.Commodity = existCommodity;
                        }
                    }
                    context.Orders.Add(order);
                    context.SaveChanges();
                }
            }
                
        }
        public void UpdateItems(int id, List<OrderItem> otherItems)
        {
            if (otherItems is null)
            {
                throw new OrderException("Input is null", 10);
            }
            using (var context=new OrderContext())
            {
                var targetOrder = context.Orders
                    .SingleOrDefault(x => x.OrderId == id);
                if(targetOrder!=null)
                {
                    foreach(OrderItem orderItem in otherItems)
                    {
                        targetOrder.UpdateItems(orderItem);
                    }
                    context.SaveChanges();
                }
                else
                {
                    throw new OrderException("No such target order.", 6);
                }
            }
        }
        public void Update(Order newOrder)
        {
            using (var context=new OrderContext())
            {
                var targetMaybe = context.Orders
                    .SingleOrDefault(order=>order.OrderId==newOrder.OrderId);
                if(targetMaybe==null)
                {
                    AddOrder(newOrder);
                }
                else
                {
                    context.Entry(newOrder).State = EntityState.Modified;
                    context.SaveChanges();
                }
            }
        }

        public bool DeleteOne(int id)
        {
            using (var context=new OrderContext())
            {
                var order = context.Orders.FirstOrDefault(x => x.OrderId == id);
                if (order != null)
                {
                    context.Orders.Remove(order);
                    context.SaveChanges();
                    return true;
                }
            }
            return false;
        }

        public void DeleteAll()
        {
            using (var context = new OrderContext())
            {
                var allOrder = context.Orders.Where(x=>x.OrderId>=0);
                foreach(Order target in allOrder)
                {
                    context.Orders.Remove(target);
                }
                context.SaveChanges();
            }
        }

     /*   public void SortOrders()
        {
            orders.Sort((x, y) => x.OrderId - y.OrderId);
        }
        */
    /*    public void SortOrders(Func<Order, Order, int> method)
        {
            if (method is null)
            {
                throw new OrderException("Sort method is null", 10);
            }
            orders.Sort((a, b) => method(a, b));
        }
        */

        public List<Order> Query(int id)
        {
            using (var context = new OrderContext())
            {
                var query = context.Orders.Include("OrderItems").Include("Customer")
                    .Where(o => o.OrderId == id)
                    .OrderByDescending(o=>o.Sum);
                return query.ToList();
            }
        }
        public List<Order> Query(string comTarget)
        {
            if (comTarget is null)
            {
                throw new OrderException("Target commodity is null", 10);
            }
            List<int> orderId = new List<int>();
            using (var context = new OrderContext())
            {
                var query1 = context.OrderItems
                    .Where(x =>x.CommodityName==comTarget);
                if(query1==null)
                {
                    throw new OrderException("Target commodity not exists", 10);
                }
                foreach(OrderItem item in query1)
                {
                    orderId.Add(item.OrderId);
                }
            }
            using (var context=new OrderContext())
            {
                List<Order> targetOrder = new List<Order>();
                foreach(int id in orderId)
                {
                    var order = context.Orders.Include("OrderItems").Include("Customer")
                        .SingleOrDefault(x => x.OrderId == id);
                    targetOrder.Add(order);
                }
                return targetOrder;
            }
        }
        public List<Order> Query(Customer target)
        {
            if (target is null)
            {
                throw new OrderException("Target customer is null", 10);
            }
            using (var context = new OrderContext())
            {
                var query = context.Orders.Include("OrderItems").Include("Customer")
                    .Where(x => x.CustomerName == target.Name)
                            .OrderByDescending(x=>x.Sum);
                return query.ToList();
            }
        }
        /*
        public IEnumerable<Order> Query(string name, Type type)
        {
            if (name is null || (int)type > 3 || (int)type < 0)
            {
                throw new OrderException("Arguements are not valid", 1);
            }
            switch (type)
            {
                case Type.order:
                    return from _order in orders
                           where _order.OrderId.ToString().Equals(name)
                           orderby _order.Sum descending
                           select _order;
                case Type.customer:
                    return from _order in orders
                           where _order.Customer.Name.Equals(name)
                           orderby _order.Sum descending
                           select _order;
                case Type.commodity:
                    return orders.Where(
                        order => {
                            foreach (OrderItem item in order.OrderItems)
                            {
                                if (item.Commodity.Name.Equals(name)) return true;
                            }
                            return false;
                        }
                        );
                default: return null;
            }

        }
        */
        public List<Order> Query()
        {
            using (var context = new OrderContext())
            {
                var query = context.Orders.Include("OrderItems").Include("Customer")
                    .Where(x => x.OrderId >= 0);
                return query.ToList();
            }
        }

        public void Export(string fileName)
        {
            XmlSerializer xml = new XmlSerializer(typeof(List<Order>));
            if (!fileName.Contains(".xml"))
            {
                throw new OrderException("Invalid exception name.Should be .xml", 11);
            }
            using (FileStream file = new FileStream(fileName, FileMode.Create))
            {
                List<Order> Orders = Query();
                using (var context=new OrderContext())
                {
                    foreach(Order order in Orders)
                    {
                        foreach(OrderItem orderItem in order.OrderItems)
                        {
                            orderItem.Commodity = context.Commodities.SingleOrDefault(x => x.Name == orderItem.CommodityName);
                        }
                    }
                }
                xml.Serialize(file, Orders);
            }
        }

        public void Import(string fileName)
        {
            if (!File.Exists(fileName))
            {
                throw new OrderException("This file is not exist.", 11);
            }

            XmlSerializer xml = new XmlSerializer(typeof(List<Order>));
            List<Order> temp;
            using (FileStream file = new FileStream(fileName, FileMode.Open))
            {
                temp = (List<Order>)xml.Deserialize(file);
            }
            DeleteAll();
            foreach (Order order in temp)
            {
                AddOrder(order);
            }
        }



    }
    class Program
    {
        static void Main(string[] args)
        {
            OrderService orderService = new OrderService();
            orderService.AddOrder(new Customer("Kara", Level.Bronze));
        }

    }


    public class OrderException : ApplicationException
    {
        private int code;
        public int Code { get => code; }
        public OrderException(string reason, int code) : base(reason)
        {
            this.code = code;
        }
    }
}
