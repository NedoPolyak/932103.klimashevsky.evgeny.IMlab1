using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Windows.Forms.DataVisualization.Charting;

namespace lab2
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }
        bool isModelingStarted = false;
        double priceCurrency1, priceCurrency2;
        const double k = 0.02;
        Random rnd = new Random();
        private void btStart_Click(object sender, EventArgs e)
        {
            if (!isModelingStarted)
            {

                priceCurrency1 = (double)inputPrice1.Value;
                priceCurrency2 = (double)inputPrice2.Value;

                chart1.Series[0].Points.Clear();
                chart1.Series[1].Points.Clear();
                chart1.Series[0].Points.AddXY(0, priceCurrency1);
                chart1.Series[1].Points.AddXY(0, priceCurrency2);

                timer1.Start();
                isModelingStarted = true;
            }
            else
            {
                timer1.Stop();
                isModelingStarted = false;
            }
        }

        private void Timer_Tick(object sender, EventArgs e)
        {
            
            int days = (int)inputDays.Value;
            for (int i = 1; i <= days; i++)
            {
                priceCurrency1 *= (1 + k * (rnd.NextDouble() - 0.5));
                priceCurrency2 *= (1 + k * (rnd.NextDouble() - 0.5));
                chart1.Series[0].Points.AddXY(chart1.Series[0].Points.Count, priceCurrency1);
                chart1.Series[1].Points.AddXY(chart1.Series[1].Points.Count, priceCurrency2);
            }
            
        }
    }
}
