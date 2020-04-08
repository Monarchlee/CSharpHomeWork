using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace OrderSystemSurface
{
    public partial class DeleteForm : Form
    {
        public int ID { get; set; }
        public int Mode { get; set; }
        public DeleteForm()
        {
            InitializeComponent();
            ID = -1;
            Mode = -1;
        }

        private void txbID_TextChanged(object sender, EventArgs e)
        {
            if(!Int32.TryParse(txbID.Text,out int id))
            {
                txbID.Clear();
                ID = -1;
            }
            else
            {
                ID = id;
            }
        }

        private void btnDel_Click(object sender, EventArgs e)
        {
            Mode = 0;
            Close();
        }

        private void btnDelAll_Click(object sender, EventArgs e)
        {
            Mode = 1;
            Close();
        }
    }
}
