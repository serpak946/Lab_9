using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Lab_9
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }
        public double func(double x, double a, double b)
        {
            double y = a*Math.Pow(x, 3) + Math.Pow(Math.Cos(Math.Pow(x,3)-b), 2);
            return y;
        }
        
        public double func1(double x)
        {
            return Math.Sqrt(x);
        }

        private void button1_Click(object sender, EventArgs e)
        {
            chart1.Series[0].Points.Clear();
            double dx = 0.25, a = 1.35, b = -6.25, x0 = 5.3, xk = 10.3;
            try
            {
                x0 = textBox1.Text == "" ? 5.3 : Convert.ToDouble(textBox1.Text);
                dx = textBox2.Text == "" ? 0.25 : Convert.ToDouble(textBox2.Text);
                xk = textBox3.Text == "" ? 10.3 : Convert.ToDouble(textBox3.Text);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            chart1.ChartAreas[0].AxisX.Minimum = x0;
            chart1.ChartAreas[0].AxisX.Maximum = xk;
            chart1.ChartAreas[0].AxisX.MajorGrid.Interval = dx;
            for (double i = x0; i <= xk; i += dx)
            {
                chart1.Series[0].Points.AddXY(i, func(i, a, b));
            }
            chart1.Series[1].Points.Clear();
            for (double i = x0; i <= xk; i += dx)
            {
                chart1.Series[1].Points.AddXY(i, 600*Math.Cos(1600*i));
            }  
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }
    }
}
