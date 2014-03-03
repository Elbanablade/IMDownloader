using System;
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
                int numPages = Gelbooru.numberOfPages;
                Gelbooru.seedUrls.RemoveAt(0);
                printToMainRTB("starting information collection");
                List<string> pageURLs = Gelbooru.getIndividualPageUrls(tempUrl);
                List<string> imageUrls = new List<string>();
                for (int i = 0; i < numPages; i++)
                {
                    try
                    {
                        List<string> tempImageurls = Gelbooru.getImageUrlsFromPage(pageURLs[i] + "&pid=" + (63 * i));
                        foreach (string s in tempImageurls)
                        {
                            List<string> temp = new List<string>();
                            temp.Add(tempUrl);
                            temp.Add(s);
                            temp.Add(tempLocation);
                            Gelbooru.imageData.Add(temp);
                        }
                    }
                    catch { }
                }
                printToMainRTB("information collection complete");
            }
            if(Gelbooru.imageData.Count > 0)
            {
                List<string> tempData = Gelbooru.imageData.First();
                Gelbooru.imageData.RemoveAt(0);
                if(Gelbooru.downloadImage(tempData[1], tempData[2]))
                {
                    //printToMainRTB("Downloaded: " + tempData[1]);
                }
                else
                {
                    //printToMainRTB("Download Failed: " + tempData[1]);
                }
            }

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
