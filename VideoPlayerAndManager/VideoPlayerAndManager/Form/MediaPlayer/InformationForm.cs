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
    public partial class InformationForm : Form
    {
        public InformationForm(string name,string length,string url,string skin)
        {
            InitializeComponent();
            label4.Text = name;
            label5.Text = length;
            label6.Text = url;
            skinEngine1.SkinFile = skin;
        }
    }
}
