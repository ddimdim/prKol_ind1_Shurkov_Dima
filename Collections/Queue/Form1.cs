using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;

namespace Queue_students
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            try
            {
                listBox1.Items.Clear();
                Queue good_students = new Queue();
                Queue bad_students = new Queue();
                StreamReader sr = File.OpenText("students.txt");
                while (!sr.EndOfStream)
                {
                    string line = sr.ReadLine();
                    string[] info = line.Split(' ');
                    string surname = info[0];
                    string name = info[1];
                    string otchestvo = info[2];
                    string group = info[3];
                    int grade1 = Convert.ToInt32(info[4]);
                    int grade2 = Convert.ToInt32(info[5]);
                    int grade3 = Convert.ToInt32(info[6]);
                    if (grade1 <= 2 || grade2 <= 2 || grade3 <= 2)
                    {
                        bad_students.Enqueue($"Студент: {surname} {name} {otchestvo} {group}   Результаты сессии: РМП - {grade1}, ПиТПМ - {grade2}, ОПБД - {grade3}");
                    }
                    else
                    {
                        good_students.Enqueue($"Студент: {surname} {name} {otchestvo} {group}   Результаты сессии: РМП - {grade1}, ПиТПМ - {grade2}, ОПБД - {grade3}");
                    }

                }
                listBox1.Items.Add("----------------- Студенты, успешно сдавшие сессию -------------------");
                foreach (string str in good_students)
                {
                    listBox1.Items.Add(str);
                }
                listBox1.Items.Add("----------------- Студенты, сдавшие сессию неудачно -------------------");
                foreach (string str in bad_students)
                {
                    listBox1.Items.Add(str);
                }
            }
            catch
            {
                MessageBox.Show("Файл не был обнаружен", "Ошибка");
            }
            
        }
    }
}
