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
    public partial class Form1 : Form
    {
        private OrderService orderService=new OrderService();
        public OrderService OrderService { get { return orderService; } }

        public Form1()
        {
            InitializeComponent();
            orderService.AddOrder(new Customer("kara", Level.Bronze), 1);
            orderService.AddOrder(new Customer("lee", Level.Diamond), 2);
            orderService.Orders[0].UpdateItems(new OrderItem(new Commodity("caps", 10), 10));
            orderService.Orders[1].UpdateItems(new OrderItem(new Commodity("caps", 10), 10));
            orderService.Orders[1].UpdateItems(new OrderItem(new Commodity("zd", 10), 10));
            bdsOrder.DataSource = orderService.Orders;
        }

        private void bdsOrder_CurrentChanged(object sender, EventArgs e)
        {
            bdsItem.DataSource =(Order)bdsOrder.Current;
        }

        //查到null之后再查就无法显示细节了？
        private void btnQueryStart_Click(object sender, EventArgs e)
        {
            List<Order> Query = null;
            OrderService tempService = null;
            if (txbID.Text!="")
            {
                Int32.TryParse(txbID.Text, out int id);
                Query = orderService.Query(id).ToList();
            }
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
                    if (addForm.Order.ID == -1)
                    {
                        orderService.AddOrder(addForm.Order.Customer);
                        orderService.UpdateItems(orderService.Orders[orderService.Orders.Count - 1].ID,addForm.Order.OrderItems);
                    }
                    else
                    {
                        orderService.AddOrder(addForm.Order);
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
                    orderService.UpdateItems(addForm.Order.ID,addForm.Order.OrderItems);
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
                        bdsOrder.DataSource = orderService.Orders;
                    }
                    break;
                case 1:
                    orderService.DeleteAll();
                    bdsOrder.DataSource = orderService.Orders;
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
            bdsOrder.DataSource = orderService.Orders;
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
