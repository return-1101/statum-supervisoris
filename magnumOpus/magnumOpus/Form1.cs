//using magnumOpus.Common.Diagnostics.SystemInfo;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Threading;

namespace magnumOpus
{
    public partial class Form1 : Form
    {
        CpuInfo cpu = new CpuInfo();
        MotherBoard boardInfo = new MotherBoard();
        Ram ramInfo = new Ram();
        
        Settings setting = new Settings();
        string[] InfCpu;

        public Form1()
        {            
            InitializeComponent();
            //cpu.findValueIndex();
            timer1.Interval = 1000; timer1.Start();
            

            Thread myThread = new Thread(new ThreadStart(cpu.CpuUsage));
            myThread.Start();


            
            InfCpu = cpu.moreCpuInfo();
            //timer2.Start();

        }
             
       

        private void button2_Click(object sender, EventArgs e)
        {
            string[] infBoard = boardInfo.motherBoardInfo();
            cpu.active = false; timer2.Stop();
            label36.Text = infBoard[0];
            label35.Text = infBoard[1];
            label34.Text = infBoard[2];
            label38.Text = infBoard[3];
            label37.Text = infBoard[4];

            panel2.Visible = true;
            panel1.Visible = false;
            panel3.Visible = false;
            panel4.Visible = false;
        }

        private void button3_Click(object sender, EventArgs e)
        {            
            timer2.Stop(); cpu.active = true;
            label17.Text = InfCpu[0];
            label18.Text = InfCpu[1];
            label19.Text = InfCpu[2];
            label20.Text = InfCpu[3];
            label21.Text = InfCpu[4];
            label22.Text = InfCpu[5];
            label23.Text = InfCpu[6];
            label24.Text = InfCpu[7];
            label25.Text = InfCpu[8];
            label26.Text = InfCpu[9];
            panel1.Visible = true;
            panel2.Visible = false;
            panel3.Visible = false;
            panel4.Visible = false;
        }

        public List<Label> labels = new List<Label>();
        private void button1_Click(object sender, EventArgs e)
        {
            cpu.active = false;
            timer2.Start();
            panel1.Visible = false;
            panel2.Visible = false;
            panel3.Visible = true;
            panel4.Visible = false;

            label40.Text = ramInfo.manufaxturer;
            label39.Text = ramInfo.bank;
            label51.Text = ramInfo.capacity;
            label50.Text = ramInfo.speed;
            label55.Text = ramInfo.serialNumb;
            label54.Text = ramInfo.fizicalMemory;                        
        }

        private void button4_Click(object sender, EventArgs e)
        {
            cpu.active = false; timer2.Stop();
            panel1.Visible = false;
            panel2.Visible = false;
            panel3.Visible = false;
            panel4.Visible = true;
            
            checkBox1.Checked = setting.cpuLoad;
            checkBox2.Checked = setting.cpuTemperature;
            checkBox3.Checked = setting.cpuFrequency;
            checkBox4.Checked = setting.cpuFrequencyTimer;
            checkBox5.Checked = setting.cpuTemperatureTimer;
            checkBox6.Checked = setting.cpuLoadTimer;
            checkBox7.Checked = setting.ramFreeTimer;
            checkBox8.Checked = setting.ramUsedTimer;
            checkBox9.Checked = setting.ramLoadTimer;
            checkBox10.Checked = setting.ramFree;
            checkBox11.Checked = setting.ramUsed;
            checkBox12.Checked = setting.ramLoad;
        }

        public void updateDate(object sender, EventArgs e)
        {
            label29.Text = cpu.ClokVoltage[1] ;            
            label15.Text = cpu.ClokVoltage[0] + "%";
            label16.Text = cpu.CpuTemp();
                        
        }

        private void button5_Click(object sender, EventArgs e)
        {            
            setting.cpuLoad = checkBox1.Checked;
            setting.cpuTemperature = checkBox2.Checked;
            setting.cpuFrequency = checkBox3.Checked;
            setting.cpuFrequencyTimer = checkBox4.Checked;
            setting.cpuTemperatureTimer = checkBox5.Checked;
            setting.cpuLoadTimer = checkBox6.Checked;
            setting.ramFreeTimer = checkBox7.Checked;
            setting.ramUsedTimer = checkBox8.Checked;
            setting.ramLoadTimer = checkBox9.Checked;
            setting.ramFree = checkBox10.Checked;
            setting.ramUsed = checkBox11.Checked;
            setting.ramLoad = checkBox12.Checked;

           
        }

        private void button6_Click(object sender, EventArgs e)
        {
            Form2 frm2 = new Form2(setting); frm2.Show();
        }
        private void updateRam(object sender, EventArgs e)
        {
            string[] ramLoad = ramInfo.getRamInfo();

            label43.Text = ramLoad[0];
            label42.Text = ramLoad[1];
            label41.Text = ramLoad[2];
        }

        private void panel2_Paint(object sender, PaintEventArgs e)
        {

        }

        private void label35_Click(object sender, EventArgs e)
        {

        }
        private void label1_Click(object sender, EventArgs e)
        {

        }

       
        private void label73_Click(object sender, EventArgs e)
        {

        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void panel4_Paint(object sender, PaintEventArgs e)
        {

        }

        
    }
}
