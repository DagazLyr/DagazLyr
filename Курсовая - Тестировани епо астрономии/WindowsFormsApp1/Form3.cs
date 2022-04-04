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
using static System.Random;


namespace WindowsFormsApp1
{
    public partial class Form3 : Form
    {
        int p;
        
        int quection_count = 0;
        int balls = 0;
        int wrong_answer = 0;

        string[] array;

      
        int select;
        int prav_otvet;

        System.IO.StreamReader test;

        Timer timer = new Timer();
        int timerCounter = 0;
        int timerMinutes = 0;

        Random rand = new Random();
       
        void start()
        {
            var Encoding = System.Text.Encoding.GetEncoding(65001);
            try
            {
                p = rand.Next(3)+1;
               
                switch(p)
                {
                    case 1: test = new System.IO.StreamReader(System.IO.Directory.GetCurrentDirectory()
                    + @"\test1.txt", Encoding); break;
                    case 2:
                        test = new System.IO.StreamReader(System.IO.Directory.GetCurrentDirectory()
                    + @"\test2.txt", Encoding); break;
                    case 3:
                        test = new System.IO.StreamReader(System.IO.Directory.GetCurrentDirectory()
            + @"\test3.txt", Encoding); break;
                    case 4:
                        test = new System.IO.StreamReader(System.IO.Directory.GetCurrentDirectory()
            + @"\test4.txt", Encoding); break;
                    default:
                        test = new System.IO.StreamReader(System.IO.Directory.GetCurrentDirectory()
               + @"\test1.txt", Encoding); break;
                }
              

               
                this.Text = test.ReadLine();
;
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
            label1.Text = test.ReadLine();

            radioButton1.Text = test.ReadLine();
            radioButton2.Text = test.ReadLine();
            radioButton3.Text = test.ReadLine();

            prav_otvet = Convert.ToInt32(test.ReadLine().ToString());

            radioButton1.Checked = false;
            radioButton2.Checked = false;
            radioButton3.Checked = false;

            button1.Enabled = false;
            quection_count = quection_count + 1;

            if (test.EndOfStream == true) button1.Text = "Завершить";
        }
        

        void переключение(object sender, EventArgs e)
        {
            button1.Enabled = true;
            button1.Focus();
            RadioButton Переключатель = (RadioButton)sender;
            var tmp = Переключатель.Name;

            select = int.Parse(tmp.Substring(11));
        }

        public Form3()
        {
            InitializeComponent();
            timer.Interval = 1000;
            timer.Tick += new EventHandler(timer1_Tick);
            
        }

        private void Form3_Load(object sender, EventArgs e)
        {
            button1.Text = "Следующий вопрос";
            button2.Text = "Выход";
            radioButton1.CheckedChanged += new EventHandler(переключение);
            radioButton2.CheckedChanged += new EventHandler(переключение);
            radioButton3.CheckedChanged += new EventHandler(переключение);
            label1.Visible = false;
            button1.Visible = false;
            button2.Visible = false;
            radioButton1.Visible = false;
            radioButton2.Visible = false;
            radioButton3.Visible = false;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (select == prav_otvet) balls = balls + 1;
            if (select != prav_otvet)
            {
                wrong_answer = wrong_answer + 1;
                array[wrong_answer] = label1.Text;
            }
            
            if (button1.Text == "Завершить")
            {
                
                 timer.Stop();
                label2.Visible = false;
                label3.Visible = false;
                radioButton1.Visible = false;
                radioButton2.Visible = false;
                radioButton3.Visible = false;
                button1.Visible = false;
                label1.Text = String.Format("Тестирование завершено.\n " +
                    "Правильных ответов: {0} из {1}.\n " + "Набранные балы: {2:F2}.",
                    balls, quection_count, (balls * 5.0F) / quection_count);

                
                var str = "Список ошибок " + ":\n\n";
                for (int i = 1; i <= wrong_answer; i++)
                    str = str + array[i] +"\n";
                if (wrong_answer != 0) MessageBox.Show(str, "Тестирование звершено");
                button1.Visible = false;
            }
            
            if (button1.Text == "Следующий вопрос") вопрос();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            if (label2.Text != "60с")
            {
                this.label2.Text = (++timerCounter).ToString() + "с";
            }
            else
            {
                timerCounter = 0;
                timerMinutes += 1;
                label3.Text = timerMinutes + "м";
                label2.Text = 0 + "с";
            }
            if (label3.Text=="25м")
            {
                timer.Stop();
                button1.Text = "Завершить";
                button1.Visible = false;
                
                label2.Visible = false;
                label3.Visible = false;
            }
        }

        private void button3_Click(object sender, EventArgs e)
        {
            timer.Start();
            start();
            label1.Visible = true;
            button1.Visible = true;
            button2.Visible = true;
            radioButton1.Visible = true;
            radioButton2.Visible = true;
            radioButton3.Visible = true;
            button3.Visible = false;
        }
    }
}
