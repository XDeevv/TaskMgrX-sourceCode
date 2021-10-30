using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace TaskMgrX
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }


        //get the process
        Process[] proc;
        private ImageList imageList1;

        void GetAllProcess()
        {
            proc = Process.GetProcesses();
            process.Items.Clear();
            foreach (Process p in proc)
            {
                process.Items.Add(p.ProcessName);
            }
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            GetAllProcess();
            timer1.Start();
        }

        //end the task
        private void button1_Click(object sender, EventArgs e)
        {
            try
            {
                proc[process.SelectedIndex].Kill();
                GetAllProcess();
                GetAllProcess();
            }

            catch (Exception ex)
            {
                MessageBox.Show("Error: " + ex.Message, "error", MessageBoxButtons.OKCancel, MessageBoxIcon.Error);
            }
        }

        //refresh
        private void startATaskToolStripMenuItem_Click(object sender, EventArgs e)
        {
            GetAllProcess();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            GetAllProcess();
        }

        //open regedit
        private void regeditToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Process.Start("regedit.exe");
        }

        //exit
        private void exitToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        //about
        private void changelogToolStripMenuItem_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Fixed Refresh bug", "Changelog", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
        }




        //pereferences (tab)
        private void timer1_Tick(object sender, EventArgs e)
        {
            //take the text
            float fram = pRam.NextValue();
            float fcpu = pCpu.NextValue();
            
            metroProgressBar2.Value = (int)fcpu;
            metroProgressBar1.Value = (int)fram;

            //configure the progress bars
            lblCpu.Text = string.Format("{0:0.00}%", fcpu);
            lblRam.Text = string.Format("{0:0.00}%", fram);

            //configure the char
            chart1.Series["CPU"].Points.AddY(fcpu);
            chart1.Series["RAM"].Points.AddY(fram);
        }

        //open resmon.exe
        private void linkLabel1_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            Process.Start("resmon.exe");
        }

        private void websiteToolStripMenuItem_Click(object sender, EventArgs e)
        {
            //open webpage:

            string site = "www.taskmgrx.netlify.app";
            System.Diagnostics.Process.Start(site);
        }

        //Faq code
        private void faqcommingSoonToolStripMenuItem_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Faq is comming in a future update", "Comming soon!", MessageBoxButtons.OK, MessageBoxIcon.Warning);
        }





        //how to use code
        private void howToUseToolStripMenuItem_Click(object sender, EventArgs e)
        {
            string site = "www.taskmgrx.netlify.app/htw.html";
            System.Diagnostics.Process.Start(site);
        }
    }
}