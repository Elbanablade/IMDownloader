﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Timers;

namespace Downloaders
{
    public partial class Form1 : Form
    {
        //global variables
        public Form1()
        {
            System.Timers.Timer aTimer = new System.Timers.Timer();
            aTimer.Elapsed += new ElapsedEventHandler(refresh);
            aTimer.Interval = 50;
            aTimer.Enabled = true;
            InitializeComponent();
        }

        private void refresh(object source, ElapsedEventArgs e)
        {
            if(Gelbooru.seedUrls.Count > 0)
            {
                string tempUrl = Gelbooru.seedUrls.First();
                string tempLocation = Gelbooru.downloadDirectory;

                Gelbooru.seedUrls.RemoveAt(0);

                List<string> pageURLs = Gelbooru.getIndividualPageUrls(tempUrl);
                List<string> imageUrls = new List<string>();
                foreach(string page in pageURLs)
                {
                    List<string> tempImageurls = Gelbooru.getImageUrlsFromPage(page);
                    foreach(string s in tempImageurls )
                    {
                        imageUrls.Add(s);
                    }
                }
                foreach(string s in imageUrls)
                {

                }
            }
/*            string tempUrl = "";
            if(Gelbooru.seedUrls.Count > 0)
            {
                tempUrl = Gelbooru.seedUrls.First();
                int tempImageCount = Gelbooru.numberOfPages;
                Gelbooru.seedUrls.RemoveAt(0);
                printToMainRTB("getting urls");
                for (int i = 0; i < tempImageCount; i++ )
                {
                    Gelbooru.getImageUrlsFromPage(tempUrl + "&pid=" + (63*i));
                }
                Gelbooru.getImageUrlsFromPage(tempUrl);
                printToMainRTB("Done");
            }
            if(Gelbooru.imageUrls.Count > 0)
            {
                tempUrl = Gelbooru.imageUrls.First();
                Gelbooru.imageUrls.RemoveAt(0);
                if(Gelbooru.downloadImage(tempUrl))
                {
                    printToMainRTB("Downloaded: " + tempUrl);
                }
                else
                {
                    printToMainRTB("Download Failed: " + tempUrl);
                }
            }
*/
        }

        private void gelbooruToolStripMenuItem_Click(object sender, EventArgs e)
        {
            NewGelbooru entryForm = new NewGelbooru();
            entryForm.Show();
        }

        private void printToMainRTB(string text)
        {
            richTextBox1.Invoke((Action)delegate() { richTextBox1.Text += text + "\n"; });
        }

        private void testToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Gelbooru.seedUrls.Add( "http://gelbooru.com/index.php?page=post&s=list&tags=rating%3asafe");
        }
    }
}
