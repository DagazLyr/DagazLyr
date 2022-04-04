using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WindowsFormsApp1
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            label1.Text = "   Данная программа предназначена для прохождения экзамена и подготовке к нему \n в виде тестирования по основным темам в дисциплине астрономии .\n   Пожалуйста, выберите режим прохождения тестирования.";
            label1.Update();
            label2.Text = "Учебный режим";
            label2.Update();
            label3.Text = "Экзаменационный режим";
            label3.Update();
            button3.Text = "Выход";
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Form2 frm1 = new Form2();
            frm1.Show();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            Form3 frm2 = new Form3();
            frm2.Show();
           
        }

        private void button3_Click(object sender, EventArgs e)
        {
            Close();
        }
    }
}