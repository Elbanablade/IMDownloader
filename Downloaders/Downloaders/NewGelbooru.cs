﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
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
            string seedURL = "http://www.gelbooru.com/index.php?page=post&s=list&tags=";
            //build tags url
            string[] temp = tbSearchTags.Text.Split(',');
            for (int i = 0; i < temp.Count(); i++)
                {temp[i] = temp[i].Trim();}
            seedURL += String.Join("+", temp).Replace(" ", "_");
            
            //add username search
            if(tbUsername.Text != "")
            {
                seedURL += "%user:" + tbUsername.Text;
            }
            
            //add rating filtering
            try
            {
                if (cbRating.SelectedItem.ToString() != "")
                {
                    seedURL += "%rating:" + cbRating.SelectedItem.ToString();
                }
            }
            catch { }

            //id filtering
            try
            {
                if (cbGLEId.SelectedItem.ToString() != "" && nudId.Value > 0)
                {
                    seedURL += "%id:" + cbGLEId.SelectedItem.ToString() + nudId.Value.ToString();
                }
            }
            catch { }

            //width filtering
            try
            {
                if (cbGLEWidth.SelectedItem.ToString() != "" && nudWidth.Value > 0)
                {
                    seedURL += "%width:" + cbGLEWidth.SelectedItem.ToString() + nudWidth.Value.ToString();
                }
            }
            catch { }

            
            
            
            
            
            
            
            
            Process.Start(seedURL);
            //test
            //open url in browser
            MessageBox.Show(seedURL);
            return seedURL;
        }
    }
}
