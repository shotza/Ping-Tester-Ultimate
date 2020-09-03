using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Net.NetworkInformation;

namespace pingTester
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void aboutToolStripMenuItem_Click(object sender, EventArgs e)
        {
            MessageBox.Show("By Shota Abzhandadze for Bank of Georgia");
        }

        private void cMDToolStripMenuItem_Click(object sender, EventArgs e)
        {
            System.Diagnostics.Process.Start("CMD.exe");
        }
        private void textBox1_Validated(object sender, EventArgs e)
        {

        }
        private void pingBtn_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(ipAdd.Text) || ipAdd.Text == "")
            {
                MessageBox.Show("Please use valid IP or web address!");
            }
            Ping p = new Ping();
            PingReply r;
            string s;
            s = ipAdd.Text;
            r = p.Send(s);
            if (r.Status == IPStatus.Success)
            {
                statusLabel.Text = "Ping to " + s.ToString() + "[" + r.Address.ToString() + "]" + " Successful"
                   + " Response delay = " + r.RoundtripTime.ToString() + " ms" + "\n";

                systemLabel.Text = r.Options.Ttl.ToString();
                int yourInt = int.Parse(systemLabel.Text);
                if (yourInt > 64){
                    systemLabel.Text = "Windows";
                } else
                {
                    systemLabel.Text = "Linux";
                }
            }
            else if (r.Status == IPStatus.TimedOut)
            {
                statusLabel.Text = "Destination TimeOut";
            }

        }

        private void clearToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ipAdd.Text = "";
            statusLabel.Text = "---";
            systemLabel.Text = "---";
        }
    }
}
