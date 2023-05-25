using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
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

        private void buttonAnimate_Click(object sender, EventArgs e)
        {
            Process.Start(Paths.ANIMATE_PRESENTATION_NAME);
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
            Process.Start(url);
        }

        private void button1_Click(object sender, EventArgs e)
        {
            FormPresentation formOkd = new FormPresentation(this, PresentationTypes.OKD, checkBox1.Checked);
            Hide();
            formOkd.Show();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            FormConsultants consultants = new FormConsultants(this);
            Hide();
            consultants.Show();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            FormPresentation formAutoCad = new FormPresentation(this, PresentationTypes.AUTOCAD, checkBox1.Checked);
            Hide();
            formAutoCad.Show();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            FormPresentation formThreeDS = new FormPresentation(this, PresentationTypes.THREEDS, checkBox1.Checked);
            Hide();
            formThreeDS.Show();
        }
    }
}