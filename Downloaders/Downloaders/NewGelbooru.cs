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
            string[] temp = tbSearchTags.Text.Split(',');
            for (int i = 0; i < temp.Count(); i++)
                {temp[i] = temp[i].Trim();}
            seedURL += String.Join("+", temp);
            if(tbUsername.Text.Length > 0)
            {
                seedURL += "%user:" + tbUsername.Text;
            }
            if(cbRating.SelectedItem.ToString() != "")
            {
                seedURL += "%rating:" + cbRating.SelectedItem.ToString();
            }
            if(nudId.Value != 0)
            {
                seedURL += "%id:" + cbGLEId.SelectedValue.ToString() + nudId.Value.ToString();
            }
            return seedURL;
        }
    }
}
