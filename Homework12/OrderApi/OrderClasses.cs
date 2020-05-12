using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Xml.Serialization;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;


namespace OrderApi
{
    public enum Level { Bronze, Silver, Gold, Diamond };
    [Serializable]
    public class Customer
    {
        [Key]
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

    [Serializable]
    public class OrderItem
    {
        public int OrderItemId { get; set; }
        public int Quantity { get; set; }
        [ForeignKey("CommodityName")]
        public Commodity Commodity { get; set; }//多对一关联
        public string CommodityName { get; set; }
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
            return orderItem.OrderId == OrderId && orderItem.CommodityName == CommodityName;
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
            order.Customer = Customer == null ? null : Customer.ShallowClone();
            order.OrderItems = new List<OrderItem>();
            order.Date = Date;
            foreach (OrderItem orderItems in OrderItems)
            {
                order.OrderItems.Add(orderItems.DeepClone());
            }
            return order;
        }
        public override int GetHashCode()
        {
            int hashCode = 1158521302;
            hashCode = hashCode * -1521134295 + OrderId.GetHashCode();
            hashCode = hashCode * -1521134295 + EqualityComparer<List<OrderItem>>.Default.GetHashCode(OrderItems);
            hashCode = hashCode * -1521134295 + IfSolved.GetHashCode();
            hashCode = hashCode * -1521134295 + Date.GetHashCode();
            hashCode = hashCode * -1521134295 + EqualityComparer<Customer>.Default.GetHashCode(Customer);
            return hashCode;
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

