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
            {
                if (gamenumber.Check(int.Parse(textBox.Text)) && gamenumber.Counter > 0)
                {
                    if (gamenumber.Win(int.Parse(textBox.Text)))
                    {
                        MessageBoxResult d = MessageBox.Show($"Вы отгадали число. Хотите продолжить игру?\nДля продолжения нажмите \"ДА\". Для выхода из игры \"Нет\"", "Игра окончена", MessageBoxButton.YesNo);
                        if (d == MessageBoxResult.Yes)
                        {
                            MenuItem_Click(null, null);
                            textBox.Text = "";
                        }
                        else Close();
                    }
                    else
                    {
                        if (gamenumber.MoreLess(int.Parse(textBox.Text)))
                            MessageBox.Show($"Загаднное число меньше. Осталось попыток: {gamenumber.Counter}");
                        else
                            MessageBox.Show($"Загаднное число больше. Осталось попыток: {gamenumber.Counter}");
                    }
                }
                else
                {
                    MessageBoxResult d = MessageBox.Show($"Вы исчерпали число попыток.\nЗагаданное число: {gamenumber.Random}\nХотите продолжить игру?\nДля продолжения нажмите \"ДА\". Для выхода из игры \"Нет\"", "Игра окончена", MessageBoxButton.YesNo);
                    if (d == MessageBoxResult.Yes)
                    {
                        MenuItem_Click(null, null);
                        textBox.Text = "";
                    }
                    else Close();
                }
            }
            else
                MessageBox.Show("Введите число!", "Ошибка.", MessageBoxButton.OK, MessageBoxImage.Error);
        }

        private void MenuItem_Click(object sender, RoutedEventArgs e)
        {
            gamenumber = new WhatNumberLibrary.WhatNumber();
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
