using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace magnumOpus
{

    public partial class Form2 : Form
    {
        List<Label> labels = new List<Label>();
        


        public Form2(Settings setting)
        {
            InitializeComponent();


        }

        private void button1_Click(object sender, EventArgs e)
        {
            //label1.Visible = false;
            // Form2.ActiveForm.Height = 100;
            //labels.Add(new Label());
            ////labels[0] = label1;
            //labels[0].BackColor = Color.DarkGray;
            //labels[0].Visible = true;
            //labels[0].Text = "dsfsdf";
            Label i = new Label();
            i.Text = "dd";
            i.Location = new Point(0, 0);
            //labels[0].Location = new Point(30, 20);
            //label1.Location = new Point(0, 0);

        }
    }
}
