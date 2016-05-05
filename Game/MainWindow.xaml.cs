using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace Game
{
    /// <summary>
    /// Логика взаимодействия для MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        WhatNumberLibrary.WhatNumber gamenumber;
        public MainWindow()
        {
            InitializeComponent();
            MenuItem_Click(null, null);
        }

        private void button_Click(object sender, RoutedEventArgs e)
        {
            if (textBox.Text != "")
                gamenumber.Check(int.Parse(textBox.Text));
            else
                MessageBox.Show("Введите число!", "Ошибка.", MessageBoxButton.OK);
        }

        private void MenuItem_Click(object sender, RoutedEventArgs e)
        {
            gamenumber = new WhatNumberLibrary.WhatNumber();
            gamenumber.message += Gamenumber_message;
            gamenumber.gameover += Gamenumber_gameover;
        }

        private void Gamenumber_gameover(object sender, WhatNumberLibrary.WhatNumber.EventMessage e)
        {
            MessageBoxResult d = MessageBox.Show(e.Message, "Игра окончена", MessageBoxButton.YesNo);
            if (d == MessageBoxResult.Yes)
            {
                MenuItem_Click(null, null);
                textBox.Text = "";
            }
            else Close();
        }

        private void Gamenumber_message(object sender, WhatNumberLibrary.WhatNumber.EventMessage e)
        {
            MessageBox.Show(e.Message);
        }

        private void MenuItem_Click_1(object sender, RoutedEventArgs e)
        {
            Close();
        }

        private void textBox_PreviewTextInput(object sender, TextCompositionEventArgs e)
        {
            if (!char.IsDigit(e.Text, 0)) { e.Handled = true; return; }
        }

        private void textBox_TextChanged(object sender, TextChangedEventArgs e)
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
