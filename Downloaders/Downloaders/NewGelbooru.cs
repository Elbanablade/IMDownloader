using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Downloaders
{
    public partial class NewGelbooru : Form
    {
        //global variables
        public NewGelbooru()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            /*if(textBox1.Text.Length > 0 && Gelbooru.validateUrlSyntax(textBox1.Text))
            {
                Gelbooru.seedUrls.Add(textBox1.Text);
            }
             */
            this.Close();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
