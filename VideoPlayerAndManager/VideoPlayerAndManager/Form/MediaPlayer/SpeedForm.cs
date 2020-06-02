using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace VideoPlayerAndManager
{
    public partial class SpeedForm : Form
    {
        public SpeedForm(string skin)
        {
            InitializeComponent();
            skinEngine1.SkinFile = skin;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Double value;
            while (!Double.TryParse(textBox1.Text, out value))
            {
                MessageBox.Show("请重新输入");
            }
            while (value > 2 && value <= 0)
            {
                MessageBox.Show("请重新输入");
            }
            this.DialogResult = DialogResult.OK;
            this.Close();
           // MessageBox.Show(comboBox1.Items[comboBox1.SelectedIndex].ToString());
        }

        public Double getValue() {
            Double value = Double.Parse(textBox1.Text);
            return value;
        }
    }
}
