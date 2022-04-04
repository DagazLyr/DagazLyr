using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.Linq;
using System.Runtime.Remoting.Channels;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;

namespace WindowsFormsApp1
{
    public partial class Form2 : Form
    {
        int quection_count = 0;
        int balls = 0;
        int wrong_answer = 0;

        string[] array;

        int select;
        int prav_otvet;

        System.IO.StreamReader read;

        void start()
        {
            var Encoding = System.Text.Encoding.GetEncoding(65001);
            try
            {
                read = new System.IO.StreamReader(System.IO.Directory.GetCurrentDirectory()
                    + @"\test.txt", Encoding);
                this.Text = read.ReadLine();
                
                quection_count = 0;
                balls = 0;
                wrong_answer = 0;


                array = new string[33];
            }
            catch (Exception)
            {
                MessageBox.Show("ошибка");
            }
            вопрос();

        }
        void вопрос()
        {
            label1.Text = read.ReadLine();

            radioButton1.Text = read.ReadLine();
            radioButton2.Text = read.ReadLine();
            radioButton3.Text = read.ReadLine();

            prav_otvet = Convert.ToInt32(read.ReadLine().ToString());

            radioButton1.Checked = false;
            radioButton2.Checked = false;
            radioButton3.Checked = false;

            button1.Enabled = false;
            quection_count = quection_count + 1;

            if (read.EndOfStream == true) button1.Text = "Завершить";
        }


        void переключение(object sender, EventArgs e)
        {
            button1.Enabled = true;
            button1.Focus();
            RadioButton Переключатель = (RadioButton)sender;
            var tmp = Переключатель.Name;

            select = int.Parse(tmp.Substring(11));
        }

        public Form2()
        {
            InitializeComponent();
        }

        private void Form2_Load(object sender, EventArgs e)
        {
            button1.Text = "Следующий вопрос";
            button2.Text = "Выход";
            radioButton1.CheckedChanged += new EventHandler(переключение);
            radioButton2.CheckedChanged += new EventHandler(переключение);
            radioButton3.CheckedChanged += new EventHandler(переключение);
            start();
        }

        

        private void button1_Click_1(object sender, EventArgs e)
        {
            if (select == prav_otvet) balls = balls + 1;
            if (select != prav_otvet)
            {
                wrong_answer = wrong_answer + 1;
                array[wrong_answer] = label1.Text;
            }
            if (button1.Text == "Начать тестирование сначала")
            {
                button1.Text = "Следующий вопрос";
                radioButton1.Visible = true;
                radioButton2.Visible = true;
                radioButton3.Visible = true;
                start();
                return;
            }
            if (button1.Text == "Завершить")
            {
                read.Close();

                radioButton1.Visible = false;
                radioButton2.Visible = false;
                radioButton3.Visible = false;
                label1.Text = String.Format("Тестирование завершено.\n " +
                    "Правильных ответов: {0} из {1}.\n " + "Набранные балы: {2:F2}.",
                    balls, quection_count, (balls * 5.0F) / quection_count);

                button1.Text = "Начать тестирование сначала";
                var str = "Список ошибок " + ":\n\n";
                for (int i = 1; i <= wrong_answer; i++)
                    str = str + array[i] + "\n";
                if (wrong_answer != 0) MessageBox.Show(str, "Тестирование звершено");
            }

            if (button1.Text == "Следующий вопрос") вопрос();
        }

        private void button2_Click_1(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
