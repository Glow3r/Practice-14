using ArrayManager;
using Microsoft.Win32;
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

namespace Practice_14
{
    /// <summary>
    /// Логика взаимодействия для MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            Authorization auth = new Authorization();
            auth.ShowDialog();
            InitializeComponent();
        }

        private MyArray _myArray;

        private void ExcersizeInformation_Click(object sender, RoutedEventArgs e)
        {
            MessageBox.Show("Дана матрица размером M * N и целое число K (1 < K < N). Найти сумму и произведение элементов К-го столбца матрицы.", "Задание");
        }

        private void FillArray_Click(object sender, RoutedEventArgs e)
        {
            if (string.IsNullOrEmpty(rowInput.Text) || string.IsNullOrEmpty(columnInput.Text) || string.IsNullOrEmpty(kInput.Text))
            {
                MessageBox.Show("Введите значения!", "Ошибка!", MessageBoxButton.OK, MessageBoxImage.Error);
            }
            else
            {
                _myArray = new MyArray(int.Parse(rowInput.Text), int.Parse(columnInput.Text));
                _myArray.Fill();
                dataGridMain.ItemsSource = _myArray.ToDataTable().DefaultView;
            }
            dataGridSize.Text = string.Concat(rowInput.Text, " X ", columnInput.Text);
        }

        private void SumAndProduct_Click(object sender, RoutedEventArgs e)
        {
            if (string.IsNullOrEmpty(rowInput.Text) || string.IsNullOrEmpty(columnInput.Text) || string.IsNullOrEmpty(kInput.Text))
            {
                MessageBox.Show("Введите значения!", "Ошибка!", MessageBoxButton.OK, MessageBoxImage.Error);
            }
            else
            {
                int sum = 0, product = 1;

                for (int i = 0; i < _myArray.ColumnLength; i++)
                {
                    for (int j = 0; j < _myArray.RowLength; j++)
                    {
                        if (i + 1 == int.Parse(kInput.Text))
                        {
                            sum += _myArray[j, i];
                            product *= _myArray[j, i];
                        }
                    }
                }
                resultOutput.Text = string.Concat(sum, ',', product);
            }
        }

        private void OpenMatrix_Click(object sender, RoutedEventArgs e)
        {
            OpenFileDialog openFileDialog = new OpenFileDialog();
            openFileDialog.Filter = "Текстовый документ (*.txt)|*.txt|Все файлы (*.*)|*.*";
            openFileDialog.DefaultExt = ".txt";
            openFileDialog.FilterIndex = 1;
            openFileDialog.Title = "Импорт матрицы";

            if (openFileDialog.ShowDialog() == true)
            {
                _myArray.Import(openFileDialog.FileName);
            }
            resultOutput.Text = string.Empty;
            dataGridMain.ItemsSource = _myArray.ToDataTable().DefaultView;
        }

        private void SaveArray_Click(object sender, RoutedEventArgs e)
        {
            SaveFileDialog saveFileDialog = new SaveFileDialog();
            saveFileDialog.Filter = "Текстовый документ (*.txt)|*.txt|Все файлы (*.*)|*.*";
            saveFileDialog.DefaultExt = ".txt";
            saveFileDialog.FilterIndex = 1;
            saveFileDialog.Title = "Экспорт матрицы";

            if (saveFileDialog.ShowDialog() == true)
            {
                _myArray.Export(saveFileDialog.FileName);
            }
            resultOutput.Text = string.Empty;
            _myArray.Clear();
            dataGridMain.ItemsSource = _myArray.ToDataTable().DefaultView;
        }

        private void ClearMatrix_Click(object sender, RoutedEventArgs e)
        {
            _myArray.Clear();
            resultOutput.Text = string.Empty;
            dataGridMain.ItemsSource = _myArray.ToDataTable().DefaultView;
        }

        private void Information_Click(object sender, RoutedEventArgs e)
        {
            MessageBox.Show("Выполнил Гаврюшин К. А. ИСП-34.", "О программе", MessageBoxButton.OK, MessageBoxImage.Information);
        }

        private void SelectedCell(object sender, MouseButtonEventArgs e)
        {
            selectedCellLocation.Text = string.Concat("[", dataGridMain.Items.IndexOf(dataGridMain.CurrentItem), ";", dataGridMain.CurrentColumn.DisplayIndex, "]");
        }

        private void AllTextBoxes_TextChanged(object sender, TextChangedEventArgs e) => resultOutput.Text = string.Empty;

        private void Exit_Click(object sender, RoutedEventArgs e)
        {
            ExitConfirmation exit = new ExitConfirmation();
            exit.Owner = this;
            exit.ShowDialog();
        }
    }    
}
