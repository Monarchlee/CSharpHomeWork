using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using OrderSyetemNew;
using OrderSystemNew;

namespace OrderSystemSurface
{
    public partial class Form1 : Form
    {
        private OrderService orderService=new OrderService();
        public OrderService OrderService { get { return orderService; } }

        public Form1()
        {
            InitializeComponent();
            orderService.AddOrder(new Customer("kara", Level.Bronze), 1);
            orderService.AddOrder(new Customer("lee", Level.Diamond), 2);
            List<OrderItem> orderItemsKara = new List<OrderItem>();
            List<OrderItem> orderItemsLee = new List<OrderItem>();
            orderItemsKara.Add(new OrderItem(new Commodity("caps", 10), 10));
            orderService.UpdateItems(1, orderItemsKara);
            orderItemsLee.Add(new OrderItem(new Commodity("zd", 10), 10));
            orderService.UpdateItems(2, orderItemsLee);
        }


        private void btnQueryStart_Click(object sender, EventArgs e)
        {
            List<Order> Query = null;
           // OrderService tempService = null;
            if (txbID.Text!="")
            {
                Int32.TryParse(txbID.Text, out int id);
                Query = orderService.Query(id);
            }
            else if(txbCustomer.Text!="")
            {
                Query = orderService.Query(new Customer(txbCustomer.Text, Level.Bronze));
            }
            else if(txbCommodity.Text!="")
            {
                Query = orderService.Query(txbCommodity.Text);
            }
            else
            {
                Query = orderService.Query();
            }
            bdsOrder.DataSource = Query;
            /*
            if(txbCustomer.Text!="")
            {
                if (Query != null) {
                    tempService = new OrderService();
                    tempService.Orders = Query;
                    Query = tempService.Query(new Customer(txbCustomer.Text, Level.Bronze)).ToList();
                }
                else
                {
                    Query = orderService.Query(new Customer(txbCustomer.Text, Level.Bronze)).ToList();
                }
            }
            if(txbCommodity.Text!="")
            {
                if(Query!=null)
                {
                    tempService = new OrderService();
                    tempService.Orders = Query;
                    Query = tempService.Query(new Commodity(txbCommodity.Text,0)).ToList();
                }
                else
                {
                    Query = orderService.Query(new Commodity(txbCommodity.Text, 0)).ToList();
                }
            }
            if(Query==null)
            {
                bdsOrder.DataSource = orderService.Query().ToList();
            }
            else
            {
                bdsOrder.DataSource = Query;
            }
            */
        }

        private void txbID_TextChanged(object sender, EventArgs e)
        {
            if(!Int32.TryParse(txbID.Text,out int id)||id<0)
            {
                txbID.Clear();
            }
        }

        private void tsrAdd_Click(object sender, EventArgs e)
        {
            lblErrorInfo.Text = "";
            AddUpdateForm addForm = new AddUpdateForm();
            addForm.ShowDialog();
            if(addForm.Order!=null&&addForm.Mode==0)//Means create;
            {
                try
                {
                    if (addForm.Order.OrderId == -1)
                    {
                        int newId = orderService.AddOrder(addForm.Order.Customer);
                        if(addForm.OrderItem!=null)
                        {
                            List<OrderItem> orderItems = new List<OrderItem>();
                            orderItems.Add(addForm.OrderItem);
                            orderService.UpdateItems(newId, orderItems);
                        }
                    }
                    else
                    {
                        using (var context = new OrderContext())
                        {
                            var exist = context.Customers.FirstOrDefault(x => x.Name == addForm.Order.Customer.Name);
                            if (exist != null)
                            {
                                addForm.Order.CustomerName = exist.Name;
                            }
                        }
                        orderService.AddOrder(addForm.Order);
                        if (addForm.OrderItem != null)
                        {
                            List<OrderItem> orderItems = new List<OrderItem>();
                            orderItems.Add(addForm.OrderItem);
                            orderService.UpdateItems(addForm.Order.OrderId, orderItems);
                        }
                    }

                }
                catch(OrderException x)
                {
                    switch(x.Code)
                    {
                        case 3:lblErrorInfo.Text = "Invalid ID : ID < 0.";
                            break;
                        case 6:lblErrorInfo.Text = "Invalid ID : This ID has already existed.";
                            break;
                        default:
                            break;
                    }
                }
            }
            else if(addForm.Order != null && addForm.Mode == 1)//Means update.
            {
                try
                {
                    List<OrderItem> orderItems = new List<OrderItem>();
                    orderItems.Add(addForm.OrderItem);
                    orderService.UpdateItems(addForm.Order.OrderId,orderItems);
                }
                catch(OrderException x)
                {
                    if (x.Code == 6)
                        lblErrorInfo.Text = "No such target order, id is urgently required.";
                    else
                        lblErrorInfo.Text = "Items are null, meaningless.";
                }
            }
            addForm.Dispose();

        }

        private void tsrDel_Click(object sender, EventArgs e)
        {
            bool flag = false;
            DeleteForm deleteForm = new DeleteForm();
            deleteForm.ShowDialog();
            switch (deleteForm.Mode)
            {
                case 0:
                    flag = orderService.DeleteOne(deleteForm.ID);
                    if(flag==false)
                    {
                        lblErrorInfo.Text = "No such target order.";
                    }
                    else
                    {
                        bdsOrder.DataSource = orderService.Query().ToList();
                    }
                    break;
                case 1:
                    orderService.DeleteAll();
                    bdsOrder.DataSource = orderService.Query().ToList();
                    break;
                default:
                    break;
            }
            deleteForm.Dispose();
        }

        private void tsrImport_Click(object sender, EventArgs e)
        {
            ofdImprot.Filter = "XML文件(*.xml)|*.xml";
            if (ofdImprot.ShowDialog() == DialogResult.OK)
            {
                try
                {
                    orderService.Import(ofdImprot.FileName);
                }
                catch(OrderException)
                {
                    lblErrorInfo.Text = "This file does not exist.";
                }
            }
            bdsOrder.DataSource = orderService.Query().ToList();
        }

        private void tsrExport_Click(object sender, EventArgs e)
        {
            sfdExport.Filter= "XML文件(*.xml)|*.xml";
            if(sfdExport.ShowDialog()==DialogResult.OK)
            {
                try
                {
                    orderService.Export(sfdExport.FileName);
                }
                catch(OrderException)
                {
                    lblErrorInfo.Text = "Filename is not legeal.";
                }
            }
        }
    }

}
