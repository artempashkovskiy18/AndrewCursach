using System;
using System.Collections.Generic;
using System.Windows.Forms;

namespace WindowsFormsApp2
{
    public partial class FormConsultants : Form
    {
        private Form _mainForm;
        private List<Control> _buttons = new List<Control>();
        private List<Control> _pictureBoxes = new List<Control>();
        

        public FormConsultants(Form mainForm)
        {
            InitializeComponent();
            
            _mainForm = mainForm;
            
            foreach (Control control in Controls)
            {
                if (control is Button)
                {
                    _buttons.Add(control);
                }
                else
                {
                    _pictureBoxes.Add(control);
                }
            }
        }

        private void ResizeForm()
        {
            double pictureBoxHeightCoef = 0.9;
            double buttonHeightCoef = 1 - pictureBoxHeightCoef;
            
            for (int i = 0; i < _pictureBoxes.Count; i++)
            {
                Control control = _pictureBoxes[i];

                control.Top = 0;
                control.Height = (int)(ClientRectangle.Height * pictureBoxHeightCoef);
                control.Left = i * (ClientRectangle.Width / _pictureBoxes.Count);
                control.Width = ClientRectangle.Width / _pictureBoxes.Count;
                control.Invalidate();
            }

            for (int i = 0; i < _buttons.Count; i++)
            {
                Control control = _buttons[i];

                control.Top = (int)(ClientRectangle.Height * pictureBoxHeightCoef);
                control.Height = (int)(ClientRectangle.Height * buttonHeightCoef);
                control.Left = i * (ClientRectangle.Width / _buttons.Count);
                control.Width = ClientRectangle.Width / _buttons.Count;
            }
        }

        private void FormConsultants_Load(object sender, EventArgs e)
        {
            ResizeForm();
        }

        private void FormConsultants_FormClosing(object sender, FormClosingEventArgs e)
        {
            _mainForm.Show();
        }

        private void FormConsultants_SizeChanged(object sender, EventArgs e)
        {
            ResizeForm();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Потрашкова Людмила Володимирівна, 1974 року народження. " +
                            "У 1996 році закінчила з відзнакою Харківський державний університет за спеціальністю " +
                            "«економічна кібернетика» (диплом спеціаліста ЛТ ВЕ № 001116 від 28.08.1996) ");
        }

        private void button4_Click(object sender, EventArgs e)
        {
            MessageBox.Show(
                "ЄВСЄЄВ ОЛЕКСІЙ СЕРГІЙОВИЧ К.Е.Н.,ДОЦЕНТ \n Кандидат економічних наук, доцент Доцент кафедри комп’ютерних систем і технологій \n" +
                "Наукові інтереси: Системний аналіз, системи підтримки прийняття рішень, штучний інтелект, управління розподіленими командами, розробка комп’ютерних ігор \n" +
                "Навчальні дисципліни: \n1)Створення інтерактивних медіа  \n2) Комп’ютерна анімація та віртуальна реальність");
        }

        private void button3_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Гордєєв Андрій Сергійович, 1964 року народження, у 1991 році закінчив Харківський " +
                            "авіаційний інститут за спеціальністю літакобудування. У 1997 році захистив кандидатську " +
                            "дисертацію за темою «Розробка енергетичної моделі операційного припуску при механічній " +
                            "обробці», здобув вчений ступінь кандидата технічних наук за спеціальністю «Технологія " +
                            "машинобудування».");
        }

        private void button2_Click(object sender, EventArgs e)
        {
            MessageBox.Show("БРАТКЕВИЧ ВЯЧЕСЛАВ ВЯЧЕСЛАВОВИЧ К.Т.Н., \n" +
                            "ПРОФЕСОР Підвищення кваліфікації в Центрі заочної, дистанційної та післядипломної освіти " +
                            "ХНЕУ ім. С.Кузнеця з 10.10.2018 р. по 28.02.2019 р. Свідоцтво про підвищення кваліфікації " +
                            "02071211/000002-19. Реєстраційний номер 02/2019. Тема: «Створення інтерактивних електронних " +
                            "навчальних курсів за навчальною дисципліною “Програмування засобів мультимедіа”» ,свідоцтво " +
                            "про підвищення кваліфікації від 12.04.2019 р. ");
        }
    }
}