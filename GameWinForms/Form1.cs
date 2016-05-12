using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace GameWinForms
{
    public partial class Form1 : Form
    {
        WhatNumberLibrary.WhatNumber gamenumber;
        public Form1()
        {
            InitializeComponent();
            gamenumber = new WhatNumberLibrary.WhatNumber();
        }

        private void button1_Click(object sender, EventArgs e)
        {

            if (textBox1.Text != "")
            {
                if (gamenumber.Check(int.Parse(textBox1.Text)) && gamenumber.Counter > 0)
                {
                    if (gamenumber.Win(int.Parse(textBox1.Text)))
                    {
                        DialogResult d = MessageBox.Show($"Вы отгадали число. Хотите продолжить игру?\nДля продолжения нажмите \"ДА\". Для выхода из игры \"Нет\"", "Игра окончена", MessageBoxButtons.YesNo);
                        if (d == DialogResult.Yes)
                        {
                            gamenumber = new WhatNumberLibrary.WhatNumber();
                            textBox1.Text = "";
                        }
                        else Close();
                    }
                    else
                    {
                        if (gamenumber.MoreLess(int.Parse(textBox1.Text)))
                            MessageBox.Show($"Загаднное число меньше. Осталось попыток: {gamenumber.Counter}");
                        else
                            MessageBox.Show($"Загаднное число больше. Осталось попыток: {gamenumber.Counter}");
                    }
                }
                else
                {
                    DialogResult d = MessageBox.Show($"Вы исчерпали число попыток.\nЗагаданное число: {gamenumber.Random}\nХотите продолжить игру?\nДля продолжения нажмите \"ДА\". Для выхода из игры \"Нет\"", "Игра окончена", MessageBoxButtons.YesNo);
                    if (d == DialogResult.Yes)
                    {
                        gamenumber = new WhatNumberLibrary.WhatNumber();
                        textBox1.Text = "";
                    }
                    else Close();
                }
            }
            else
                MessageBox.Show("Введите число!", "Ошибка.", MessageBoxButtons.OKCancel, MessageBoxIcon.Error);
        }

        private void новаяИграToolStripMenuItem_Click(object sender, EventArgs e)
        {
            gamenumber = new WhatNumberLibrary.WhatNumber();
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {
            TextBox tex = (TextBox)sender;
            if (tex.Text.Contains(" "))
                tex.Text = tex.Text.Trim();
            if (tex.Text != string.Empty)
                if (int.Parse(tex.Text) > 100)
                    tex.Text = string.Empty;
        }
    }
}
