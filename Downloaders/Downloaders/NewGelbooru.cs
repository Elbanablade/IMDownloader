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
            Gelbooru.seedUrls.Add(buildURL());
            this.Close();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private string buildURL()
        {
            string seedURL = "http://www.gelbooru.com/index.php?page=post&tags=";
            
            return "";
        }
    }
}
