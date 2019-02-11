using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WindowsFormsApp1
{
    public partial class Form2 : Form
    {
        public Form2()
        {
            InitializeComponent();
        }

        private void Form2_Load(object sender, EventArgs e)
        {
           
        }

        public string LabelText
        {
            get
            {
                return this.label1.Text;
            }
            set
            {
                value = value.Replace('#', '\n');
                this.label1.Text = value;
            }
        }
    }
}
