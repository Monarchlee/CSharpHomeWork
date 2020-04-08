using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using OrderSystemNew;

namespace OrderSystemSurface
{
    public partial class AddUpdateForm : Form
    {
        Dictionary<string, Level> LevelDic = new Dictionary<string, Level> { { "Bronze", Level.Bronze }, { "Silver", Level.Silver }, { "Gold", Level.Gold }, { "Diamond", Level.Diamond } };
        private Order order = new Order(-1);
        public Order Order { get { return order; }set { order = value; } }
        public int Mode { get; set; }
        public AddUpdateForm()
        {
            InitializeComponent();
            Mode = -1;
        }

        private void btnStart_Click(object sender, EventArgs e)
        {
            if(txbCustomerName.Text!=""&&cmbLevel.SelectedIndex<0)
            {
                Order.Customer = new Customer(txbCustomerName.Text, Level.Bronze);
            }
            else if(txbCustomerName.Text != "" && cmbLevel.SelectedIndex > 0)
            {
                Order.Customer = new Customer(txbCustomerName.Text,LevelDic[cmbLevel.SelectedItem.ToString()]);
            }
            OrderItem item = GetItemInfo();
            if(item!=null)
            {
                Order.UpdateItems(item);
            }
            Mode = 0;
            Close();
        }

        private void txbID_TextChanged(object sender, EventArgs e)
        {
            if(!Int32.TryParse(txbID.Text,out int id))
            {
                txbID.Clear();
                Order.ID = -1;
            }
            else
            {
                Order.ID = id;
            }
            
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            order = null;
            Close();
        }


        private OrderItem GetItemInfo()
        {
            if(txbCmName.TextLength==0||!Int32.TryParse(txbCmQuantity.Text,out int quantity))
            {
                return null;
            }
            OrderItem orderItem = new OrderItem();
            if(txbCmPrice.TextLength!=0)
            {
                Double.TryParse(txbCmPrice.Text, out double price);
                orderItem.Commodity.Price = price;
            }
            orderItem.Commodity.Name = txbCmName.Text;
            orderItem.Quantity = quantity;
            return orderItem;
        }

        private void txbCmQuantity_TextChanged(object sender, EventArgs e)
        {
            if (!Int32.TryParse(txbCmQuantity.Text, out int quantity))
            {
                txbCmQuantity.Clear();
            }
        }

        private void txbCmPrice_TextChanged(object sender, EventArgs e)
        {
            if(!Double.TryParse(txbCmPrice.Text,out double price)||price<0)
            {
                txbCmPrice.Clear();
            }
        }

        private void btnUpdata_Click(object sender, EventArgs e)
        {

            OrderItem orderItem = GetItemInfo();
            if (txbCustomerName.TextLength != 0)
            {
                Order.Customer = new Customer();
                Order.Customer.Name = txbCustomerName.Text;
            }

            if(cmbLevel.SelectedIndex>=0)
            {
                if (Order.Customer != null)
                    Order.Customer = new Customer();
                Order.Customer.Level = LevelDic[cmbLevel.SelectedItem.ToString()];
            }
            if(orderItem!=null)
            {
                Order.UpdateItems(orderItem);
            }
            Mode = 1;
            Close();
        }
    }
}
