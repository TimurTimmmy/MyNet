using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Net;
using System.Net.NetworkInformation;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace MyNet
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
            label1.Visible = false;
            label2.Visible = false;
            label3.Visible = false;
            label1.Font = new Font(label1.Font, label1.Font.Style | FontStyle.Bold);
        }

        private void button1_Click(object sender, EventArgs e)
        {
            label1.Visible = true;
            label2.Visible = true;
            label3.Visible = true;
            label1.Text = null;
            label2.Text = null;
            label3.Text = null;

            Ping ping = new System.Net.NetworkInformation.Ping();
            try
            {
                PingReply pingreply = ping.Send(textBox1.Text);
                if (pingreply.Status == IPStatus.Success)
                {
                    
                    label1.ForeColor = Color.Green;
                    label1.Text = "Success";
                    label2.Text = pingreply.Address.ToString();
                    label3.Text = pingreply.Options.Ttl.ToString();
                }
                else
                {
                    label1.ForeColor = Color.Red;
                    label1.Text = "False";
                }
            }
            catch (PingException ex)
            {
                label1.Text = "IP - не найден";              
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            IPHostEntry ipHost = Dns.GetHostEntry(Dns.GetHostName());
            IPAddress ipAddr = ipHost.AddressList[0];
           
            label4.Text = Dns.GetHostName().ToString();
            label5.Text = ipAddr.ToString();            
        }
    }
}
