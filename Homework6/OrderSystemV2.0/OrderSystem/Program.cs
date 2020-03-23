using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Xml.Serialization;
using System.IO;
namespace GenericApplication
{

    public enum Level { Bronze, Silver, Gold, Diamond };
    [Serializable]
    public class Customer
    {
        public string Name { get; set; }
        public Level Level { get; set; }
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
                throw new ArgumentException();
            }
            return Name.Equals(customer.Name) && Level == customer.Level;
        }
        public override int GetHashCode()
        {
            return HashCode.Combine(Name, Level);
        }
        public override string ToString()
        {
            return "Level " + Level + " " + Name + "\n";
        }
        public Customer ShallowClone()
        {
            return (Customer)this.MemberwiseClone();
        }
    }
    [Serializable]
    public class Commodity
    {
        public string Name { get; set; }
        public double Price { get; set; }
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
                throw new ArgumentException();
            }
            return Name.Equals(commodity.Name) && Price == commodity.Price;
        }
        public override int GetHashCode()
        {
            return HashCode.Combine(Name, Price);
        }
        public override string ToString()
        {
            return Name + " with price: " + Price;
        }
        public Commodity ShallowClone()
        {
            return (Commodity)this.MemberwiseClone();
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
        public OrderItem(Commodity commodity, int num)
        {
            Commodity = new Commodity(commodity.Name, commodity.Price);
            Quantity = num;
        }
        public OrderItem() { }
        public Commodity Commodity { get; set; }
        public int Quantity { get; set; }
        public override bool Equals(object obj)
        {
            OrderItem orderItem = obj as OrderItem;
            if (orderItem == null)
            {
                throw new ArgumentException();
            }
            return Commodity.Equals(orderItem.Commodity);
        }
        public override int GetHashCode()
        {
            return HashCode.Combine(Commodity, Quantity);
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

    }


    [Serializable]
    public class Order
    {
        public int ID { get; set; }
        public List<OrderItem> OrderItems { get; set; }
        public bool IfSolved { get; set; }
        public DateTime Data { get; set; }
        public Customer Customer { get; set; }
        public double Sum
        {
            get
            {
                double sum = 0;
                foreach (OrderItem orderItem in OrderItems)
                {
                    sum += orderItem.Quantity * orderItem.Commodity.Price;
                }
                return sum;
            }
        }
        public Order(int id)
        {
            ID = id;
            Data = DateTime.Now;
            OrderItems = new List<OrderItem>();
            IfSolved = false;
        }
        public Order()
        {

        }
        public override bool Equals(object obj)
        {
            Order order = (Order)obj;
            if (order == null)
            {
                throw new ArgumentException();
            }
            return ID == order.ID
                && IfSolved == order.IfSolved;
        }
        public override int GetHashCode()
        {
            return HashCode.Combine(ID, OrderItems, IfSolved, Data, Customer);
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
            allItems.Append("\n" + Data + "\n--------------------------");
            return allItems.ToString();
        }
        public Order DeepClone()
        {
            Order order = (Order)this.MemberwiseClone();
            order.Customer = Customer.ShallowClone();
            order.OrderItems = new List<OrderItem>();
            foreach (OrderItem orderItems in OrderItems)
            {
                order.OrderItems.Add(orderItems.DeepClone());
            }
            return order;
        }
        public void UpdateItems(OrderItem orderItem)
        {
            int index = OrderItems.FindIndex(item => item.Commodity.Equals(orderItem.Commodity));
            if (index == -1)
            {
                OrderItems.Add(orderItem.DeepClone());
            }
            else
            {
                OrderItems[index].Quantity += orderItem.Quantity;
                if (OrderItems[index].Quantity <= 0)
                {
                    Delete(OrderItems[index]);
                }
            }
        }
        public void Delete(OrderItem orderItem)
        {
            OrderItems.RemoveAll(item => item.Commodity.Equals(orderItem.Commodity));
        }
    }

    public class OrderService
    {
        public enum Type { order, customer, commodity };

        private List<Order> orders = new List<Order>();

        public List<Order> Orders
        {
            get
            {
                return orders;
            }
            set
            {
                orders = value;
            }
        }

        public void AddOrder(Customer customer, int id)
        {
            if (customer is null)
            {
                throw new OrderException("Customer is null.", 8);
            }
            Order order = new Order(id);
            order.Customer = customer.ShallowClone();
            AddOrder(order);
        }
        public int AddOrder(Customer customer)
        {
            bool flag = false;
            int count = orders.Count;
            while (!flag)
            {
                flag = true;
                foreach (Order order in orders)
                {
                    if (order.ID == count)
                    {
                        flag = false;
                        count++;
                        break;
                    }
                }
            }
            AddOrder(customer, count);
            return count;
        }
        public void AddOrder(Order order)
        {
            if (order.ID < 0)
            {
                throw new OrderException("Invalid id.", 3);
            }
            foreach (Order existOrder in orders)
            {
                if (existOrder.ID == order.ID)
                {
                    throw new OrderException("This order has already existed.", 6);
                }
            }
            orders.Add(order.DeepClone());
        }
        public void UpdataItems(int id, List<OrderItem> otherItems)
        {
            if (otherItems is null)
            {
                throw new OrderException("Input is null", 10);
            }
            int index = -1;
            index = orders.FindIndex(order => order.ID == id);
            if (index == -1)
            {
                throw new OrderException("No such target order.", 6);
            }
            foreach (OrderItem orderItem in otherItems)
            {
                orders[index].UpdateItems(orderItem);
            }
        }
        public void Update(Order newOrder)
        {
            int index = -1;

            index = orders.FindIndex(order => order.ID == newOrder.ID);
            if (index == -1)
            {
                throw new OrderException("No such target order.", 6);
            }

            orders[index] = newOrder.DeepClone();
        }

        public bool DeleteOne(int id)
        {
            int num = 0;
            num = orders.RemoveAll(order => id == order.ID);
            return num == 0 ? false : true;
        }

        public void DeleteAll()
        {
            Orders = new List<Order>();
        }

        public void SortOrders()
        {
            orders.Sort((x, y) => x.ID - y.ID);
        }
        public void SortOrders(Func<Order, Order, int> method)
        {
            if (method is null)
            {
                throw new OrderException("Sort method is null", 10);
            }
            orders.Sort((a, b) => method(a, b));
        }

        public IEnumerable<Order> Query(int id)
        {
            var query = from order in orders
                        where order.ID == id
                        orderby order.Sum descending
                        select order;
            return query;
        }
        public IEnumerable<Order> Query(Commodity target)
        {
            if (target is null)
            {
                throw new OrderException("Target commodity is null", 10);
            }
            var query = from order in orders
                        where order.OrderItems.FindIndex(item => item.Commodity.Equals(target)) != -1
                        orderby order.Sum descending
                        select order;
            return query;
        }
        public IEnumerable<Order> Query(Customer target)
        {
            if (target is null)
            {
                throw new OrderException("Target customer is null", 10);
            }
            var query = from order in orders
                        where order.Customer.Equals(target)
                        orderby order.Sum descending
                        select order;
            return query;
        }
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
                           where _order.ID.ToString().Equals(name)
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
        public IEnumerable<Order> Query()
        {
            var query = from order in orders
                        orderby order.Sum descending
                        select order;
            return query;
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
            int id;
            OrderService service = new OrderService();
            List<OrderItem> KaraItems = new List<OrderItem>
            {
                new OrderItem(new Commodity("Alter saber lily", 999.5), 1),
                new OrderItem(new Commodity("Merlin", 1256), 1),
                new OrderItem(new Commodity("Sukura", 1305), 1),
                new OrderItem(new Commodity("Burger King", 56.3), 25)
            };
            List<OrderItem> LeeItems = new List<OrderItem>
            {
                new OrderItem(new Commodity("Rem", 799), 1),
                new OrderItem(new Commodity("Battlefield BOSS", 49.5), 1),
                new OrderItem(new Commodity("RIO", 13), 15),
                new OrderItem(new Commodity("Burger King", 56.3), 13)
            };
            Customer kara = new Customer("Kara", (Level)2), lee = new Customer("Lee", (Level)3);
            Commodity burger = new Commodity("Burger King", 56.3);
            id = service.AddOrder(kara);
            service.UpdataItems(id, KaraItems);
            id = service.AddOrder(lee);
            service.UpdataItems(id, LeeItems);
            string filePath = "Tst.xml";
            service.Export(filePath);
            Console.WriteLine(File.ReadAllText(filePath));

            service.Import(filePath);
            foreach (Order order in service.Orders)
            {
                Console.WriteLine(order.ToString());
            }
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
