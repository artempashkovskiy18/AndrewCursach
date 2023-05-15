using System;
using System.Drawing;
using System.IO;
using System.Windows.Forms;
using WindowsFormsApp2.Constants;
using WindowsFormsApp2.Services;

namespace WindowsFormsApp2
{
    public partial class FormPresentation : Form
    {
        private readonly Editing _editing = new Editing();
        private readonly Form _mainForm;
        private int _slidesAmount;
        private int _currentSlide;
        private readonly PresentationTypes _type;
        private bool _editModeIsTurnedOn;

        public FormPresentation(Form mainForm, PresentationTypes type, bool editModeIsTurnedOn)
        {
            _type = type;
            _slidesAmount = _editing.GetSlidesAmount(_type);
            _currentSlide = 1;
            _mainForm = mainForm;
            _editModeIsTurnedOn = editModeIsTurnedOn;
            InitializeComponent();
        }


        private void RefreshSlide(Bitmap image, string text)
        {
            pictureBox1.Image = image;
            pictureBox1.Invalidate();
            textBox1.Text = text;
            textBox1.Invalidate();
            label1.Text = _currentSlide.ToString();
        }

        private void ResizeSlide()
        {
            if (_editModeIsTurnedOn)
            {
                ResizeObjectsOnSlideEditMode();
            }
            else
            {
                ResizeObjectsOnSlide();
            }
        }

        private void ResizeObjectsOnSlideEditMode()
        {
            double groupBoxWidthCoef = 1;
            double groupBoxHeightCoef = 0.95;

            double pictureBoxHeightCoef = 0.8;
            double pictureBoxWidthCoef = 1;

            double textBoxWidthCoef = 1;
            double textBoxHeightCoef = 1 - pictureBoxHeightCoef;

            double buttonWidth = 100;
            double buttonHeight = ClientRectangle.Height - ClientRectangle.Height * groupBoxHeightCoef;


            groupBox1.Left = 0;
            groupBox1.Top = 0;
            groupBox1.Width = (int)(ClientRectangle.Width * groupBoxWidthCoef);
            groupBox1.Height = (int)(ClientRectangle.Height * groupBoxHeightCoef);

            pictureBox1.Top = 0;
            pictureBox1.Left = 0;
            pictureBox1.Width = (int)(groupBox1.Width * pictureBoxWidthCoef);
            pictureBox1.Height = (int)(groupBox1.Height * pictureBoxHeightCoef);

            textBox1.Width = (int)(groupBox1.Width * textBoxWidthCoef);
            textBox1.Height = (int)(groupBox1.Height * textBoxHeightCoef);
            textBox1.Left = 0;
            textBox1.Top = pictureBox1.Bottom;

            button1.Top = groupBox1.Bottom;
            button1.Left = 0;
            button1.Height = (int)buttonHeight;
            button1.Width = (int)buttonWidth;
            button1.Refresh();

            button2.Top = groupBox1.Bottom;
            button2.Left = (int)buttonWidth;
            button2.Height = (int)(buttonHeight);
            button2.Width = (int)buttonWidth;
            button2.Refresh();

            button3.Top = groupBox1.Bottom;
            button3.Left = (int)buttonWidth * 2;
            button3.Height = (int)(buttonHeight);
            button3.Width = (int)buttonWidth;
            button3.Refresh();

            label1.Top = 0;
            label1.Left = 0;
        }

        private void ResizeObjectsOnSlide()
        {
            double groupBoxWidthCoef = 1;
            double groupBoxHeightCoef = 1;

            double pictureBoxHeightCoef = 0.8;
            double pictureBoxWidthCoef = 1;

            double textBoxWidthCoef = 1;
            double textBoxHeightCoef = 1 - pictureBoxHeightCoef;


            groupBox1.Left = 0;
            groupBox1.Top = 0;
            groupBox1.Width = (int)(ClientRectangle.Width * groupBoxWidthCoef);
            groupBox1.Height = (int)(ClientRectangle.Height * groupBoxHeightCoef);

            pictureBox1.Top = 0;
            pictureBox1.Left = 0;
            pictureBox1.Width = (int)(groupBox1.Width * pictureBoxWidthCoef);
            pictureBox1.Height = (int)(groupBox1.Height * pictureBoxHeightCoef);

            textBox1.Width = (int)(groupBox1.Width * textBoxWidthCoef);
            textBox1.Height = (int)(groupBox1.Height * textBoxHeightCoef);
            textBox1.Left = 0;
            textBox1.Top = pictureBox1.Bottom;

            label1.Top = 0;
            label1.Left = 0;
        }


        private void ChangeSlideForward()
        {
            if (_currentSlide != _slidesAmount)
            {
                _currentSlide++;
            }
        }

        private void ChangeSlideBackward()
        {
            if (_currentSlide != 1)
            {
                _currentSlide--;
            }
        }

        private void DisableEditingButtons()
        {
            button1.Hide();
            button1.Enabled = false;
            button2.Hide();
            button2.Enabled = false;
            button3.Hide();
            button3.Enabled = false;
        }


        private void FormAutoCad_FormClosing(object sender, FormClosingEventArgs e)
        {
            _editing.SaveText(textBox1.Text, _currentSlide, _type);
            _mainForm.Show();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Image image = _editing.AddPicture(pictureBox1);
            _editing.SavePicture(new Bitmap(image), _currentSlide, _type);
        }

        private void FormAutoCad_KeyDown(object sender, KeyEventArgs e)
        {
            _editing.SaveText(textBox1.Text, _currentSlide, _type);
            switch (e.KeyCode)
            {
                case Keys.PageUp:
                    ChangeSlideForward();
                    break;
                case Keys.PageDown:
                    ChangeSlideBackward();
                    break;
            }

            RefreshSlide(_editing.GetPicture(_currentSlide, _type), _editing.GetText(_currentSlide, _type));
        }

        private void button2_Click(object sender, EventArgs e)
        {
            _slidesAmount++;
            _currentSlide = _slidesAmount;
            RefreshSlide(null, null);
        }

        private void button3_Click(object sender, EventArgs e)
        {
            DialogResult result = MessageBox.Show("Вы уверены, что хотите удалить слайд?", "Подтверждение",
                MessageBoxButtons.YesNo);
            if (result == DialogResult.Yes)
            {
                _editing.DeleteSlide(_currentSlide, _type, _slidesAmount);
                _slidesAmount--;
                if (_currentSlide != 1)
                {
                    _currentSlide--;
                }

                RefreshSlide(_editing.GetPicture(_currentSlide, _type), _editing.GetText(_currentSlide, _type));
            }
        }

        private void FormAutoCad_Click(object sender, EventArgs e)
        {
            ActiveControl = null;
        }

        private void FormAutoCad_Load(object sender, EventArgs e)
        {
            RefreshSlide(_editing.GetPicture(_currentSlide, _type), _editing.GetText(_currentSlide, _type));
            if (_editModeIsTurnedOn)
            {
                ResizeSlide();
            }
            else
            {
                DisableEditingButtons();
                ResizeSlide();
            }
        }

        private void FormAutoCad_SizeChanged(object sender, EventArgs e)
        {
            ResizeSlide();
        }
    }
}