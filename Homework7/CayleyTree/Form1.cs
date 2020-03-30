using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;


namespace CayleyTree
{
    public partial class Form1 : Form
    {

        private Graphics graphics;
        double th1 = 30 * Math.PI / 180;
        double th2 = 20 * Math.PI / 180;
        double per1 = 0.6;
        double per2 = 0.7;
        int depth = 5;
        double leng = 2;
        Pen pen = Pens.Black;
        Dictionary<int, Pen> colorDialog = new Dictionary<int, Pen> { { 0, Pens.Black }, { 1,Pens.White}
                                                                        ,{ 2,Pens.Red},{ 3,Pens.Silver},
                                                                        {4,Pens.Gray } };
        public Form1()
        {
            InitializeComponent();
        }
        void DrawCayleyTree(Pen pen,int n,double x0,double y0,double leng,double th)
        {
            if (n == 0) return;

            double x1 = x0 + leng * Math.Cos(th);
            double y1 = y0 + leng * Math.Sin(th);

            graphics.DrawLine(pen, (int)x0, (int)y0, (int)x1, (int)y1);
            DrawCayleyTree(pen, n - 1, x1, y1, per1 * leng, th + th1);
            DrawCayleyTree(pen, n - 1, x1, y1, per2 * leng, th - th2);

        }

        private void pnlCanvas_Paint(object sender, PaintEventArgs e)
        {
            graphics = e.Graphics;
            DrawCayleyTree(pen, depth, pnlCanvas.Location.X + pnlCanvas.Size.Width / 2, pnlCanvas.Location.Y + pnlCanvas.Size.Height
                , leng, -0.5*Math.PI);
        }




        private void Form1_Load(object sender, EventArgs e)
        {
        }

        private void btnStart_Click(object sender, EventArgs e)
        {
            th1 = trbRightAngle.Value * Math.PI / 180;
            th2 = trbLeftAngle.Value * Math.PI / 180;
            if(cmbPenColor.SelectedItem!=null)
            pen = colorDialog[cmbPenColor.SelectedIndex];
            pnlCanvas.Invalidate();

        }

        private void txtDepth_Changed(object sender, EventArgs e)
        {
            if(!Int32.TryParse(txtDepth.Text,out int depthTmp)||depthTmp<=0)
            {
                txtDepth.Clear();
            }
            else
            {
                depth = depthTmp;
            }
        }

        private void txtLeng_Changed(object sender, EventArgs e)
        {
            if (!Double.TryParse(txtLeng.Text, out double lengTmp)||lengTmp<=0)
            {
                txtLeng.Clear();
            }
            else
            {
                leng = lengTmp;
            }
        }

        private void txtRightLeng_Changed(object sender, EventArgs e)
        {
            if (!Double.TryParse(txtRightLeng.Text, out double rightLengTmp) || rightLengTmp < 0)
            {
                txtRightLeng.Clear();
            }
            else
            {
                per1 = rightLengTmp;
            }
        }

        private void txtLeftLeng_Changed(object sender, EventArgs e)
        {
            if (!Double.TryParse(txtLeftLeng.Text, out double leftLengTmp) || leftLengTmp < 0)
            {
                txtLeftLeng.Clear();
            }
            else
            {
                per2 = leftLengTmp;
            }
        }
    }
}
