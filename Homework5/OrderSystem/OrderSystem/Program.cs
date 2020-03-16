using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace GenericApplication
{

    public enum Level { Bronze, Silver, Gold, Diamond };
    public class Customer
    {
        public string Name { get; set; }
        public Level Level { get; set; }
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
            return Name.GetHashCode() & Level.GetHashCode();
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

    public class Commodity
    {
        public string Name { get; set; }
        public double Price { get; set; }
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
            return Name.GetHashCode() & Price.GetHashCode();
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

    public class OrderItem
    {
        public OrderItem(Commodity commodity, int num)
        {
            Commodity = new Commodity(commodity.Name, commodity.Price);
            Quantity = num;
        }
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
            return Commodity.GetHashCode() * Quantity;
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
    public class Order
    {
        public int ID { get; set; }
        public List<OrderItem> OrderItems { get; set; }
        public bool IfSolved { get; set; }
        public DateTime Data { get; }
        public Customer Customer { get; set; }

        public Order(int id)
        {
            ID = id;
            Data = DateTime.Now;
            OrderItems = new List<OrderItem>();
            IfSolved = false;
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
            return OrderItems.GetHashCode() & ID.GetHashCode() * IfSolved.GetHashCode();
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

        public double Sum()
        {
            double sum = 0;
            foreach (OrderItem orderItem in OrderItems)
            {
                sum += orderItem.Quantity * orderItem.Commodity.Price;
            }
            return sum;
        }

    }

    public class OrderService
    {
        private List<Order> orders = new List<Order>();

        public void AddOrder(Customer customer, int id)
        {
            if (id <= 0)
            {
                throw new OrderException("Invalid id.", 3);
            }
            foreach (Order existOrder in orders)
            {
                if (existOrder.ID == id)
                {
                    throw new OrderException("This id has already existed.", 4);
                }
            }
            orders.Add(new Order(id));
            orders.Last().Customer = customer.ShallowClone();
        }
        public int AddOrder(Customer customer)
        {
            orders.Add(new Order(orders.Count + 1));
            orders.Last().Customer = customer.ShallowClone();
            return orders.Last().ID;
        }
        public void AddOrder(Order order)
        {
            if (order.ID <= 0)
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

        public bool Delete(int id)
        {
            int num = 0;
            num = orders.RemoveAll(order => id == order.ID);
            return num == 0 ? false : true;
        }

        public void SortOrders()
        {
            orders.Sort((x, y) => x.ID - y.ID);
        }
        public void SortOrders(Func<Order, Order, int> method)
        {
            orders.Sort((a, b) => method(a, b));
        }

        public IEnumerable<Order> Query(int id)
        {
            var query = from order in orders
                        where order.ID == id
                        orderby order.Sum() descending
                        select order;
            return query;
        }
        public IEnumerable<Order> Query(Commodity target)
        {
            var query = from order in orders
                        where order.OrderItems.FindIndex(item => item.Commodity.Equals(target)) != -1
                        orderby order.Sum() descending
                        select order;
            return query;
        }
        public IEnumerable<Order> Query(Customer target)
        {
            var query = from order in orders
                        where order.Customer.Equals(target)
                        orderby order.Sum() descending
                        select order;
            return query;
        }
        public IEnumerable<Order> Query()
        {
            var query = from order in orders
                        orderby order.Sum() descending
                        select order;
            return query;
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

            List<Order> karaOrders = service.Query(kara).ToList();
            List<Order> leeOrders = service.Query(lee).ToList();
            List<Order> burgerKingOrders = service.Query(burger).ToList();

            foreach (Order order in karaOrders)
            {
                Console.Write(order.ToString());
            }
            foreach (Order order in leeOrders)
            {
                Console.Write(order.ToString());
            }
            foreach (Order order in burgerKingOrders)
            {
                Console.Write(order.ToString());
            }





        }

    }


    class OrderException : ApplicationException
    {
        private int code;
        public int Code { get => code; }
        public OrderException(string reason, int code) : base(reason)
        {
            this.code = code;
        }
    }
}

