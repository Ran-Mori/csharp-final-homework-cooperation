using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using DBInterface;

namespace VideoPlayerAndManager
{
    public partial class Notebox : Form
    {
        public string Note { get; set; }
        public string ItemName { get; set; }
        VideoService service;
        public Notebox(string name, string note)
        {
            InitializeComponent();
            service = new VideoService();
            ItemName = name;
            Note = note;
            textBox1.DataBindings.Add("Text", this, "Note");
        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            service.UpdateNote(ItemName, Note);
            this.Close();
        }
    }
}
