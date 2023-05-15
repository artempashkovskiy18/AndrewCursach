using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using WindowsFormsApp2.Constants;

namespace WindowsFormsApp2
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void buttonAutoCad_Click(object sender, EventArgs e)
        {
            FormPresentation formAutoCad = new FormPresentation(this, PresentationTypes.AUTOCAD, checkBox1.Checked);
            Hide();
            formAutoCad.Show();
        }

        private void button3DS_Click(object sender, EventArgs e)
        {
            FormPresentation form3Ds = new FormPresentation(this, PresentationTypes.THREEDS, checkBox1.Checked);
            Hide();
            form3Ds.Show();
        }

        private void buttonAnimate_Click(object sender, EventArgs e)
        {
            FormPresentation formAnimate = new FormPresentation(this, PresentationTypes.ANIMATE, checkBox1.Checked);
            Hide();
            formAnimate.Show();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            foreach (KeyValuePair<string, string> keyValuePair in Videos.VIDEOS_NAME_URL)
            {
                ListViewItem item1 = new ListViewItem(keyValuePair.Key);
                item1.SubItems.Add(keyValuePair.Value);
                listView1.Items.Add(item1);
            }
        }

        private void listView1_ItemActivate(object sender, EventArgs e)
        {
            string url = listView1.SelectedItems[0].SubItems[1].Text;
            System.Diagnostics.Process.Start(url);
        }
    }
}