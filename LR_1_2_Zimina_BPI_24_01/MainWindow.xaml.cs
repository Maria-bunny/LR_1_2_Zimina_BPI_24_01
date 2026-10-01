using System;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Media;

namespace LR_1_2_Zimina_BPI_24_01
{
    public partial class MainWindow : Window
    {
        private Figure currentFigure = null;

        private bool isFigureCreated = false;

        public MainWindow()
        {
            InitializeComponent();

            circleRadio.Checked += SelectFigure;
            rectangleRadio.Checked += SelectFigure;
            triangleRadio.Checked += SelectFigure;

            calculateS.Click += CalculateArea;
            calculateP.Click += CalculatePerimeter;

            UpdatePanelsVisibility();
        }

        private void UpdatePanelsVisibility()
        {
            if (circleRadio.IsChecked == true)
            {
                circlePanel.Visibility = Visibility.Visible;
                rectanglePanel.Visibility = Visibility.Collapsed;
                trianglePanel.Visibility = Visibility.Collapsed;
                settingsColumn.Height = new GridLength(40);
            }
            else if (rectangleRadio.IsChecked == true)
            {
                circlePanel.Visibility = Visibility.Collapsed;
                rectanglePanel.Visibility = Visibility.Visible;
                trianglePanel.Visibility = Visibility.Collapsed;
                settingsColumn.Height = new GridLength(80);
            }
            else
            {
                circlePanel.Visibility = Visibility.Collapsed;
                rectanglePanel.Visibility = Visibility.Collapsed;
                trianglePanel.Visibility = Visibility.Visible;
                settingsColumn.Height = new GridLength(120);
            }

            resultS.Content = "Не посчитана";
            resultP.Content = "Не посчитан";
            message.Content = "Нет";

            ResetFigure();
        }

        private void ResetFigure()
        {
            currentFigure = null;
            isFigureCreated = false;
        }

        private void SelectFigure(object sender, RoutedEventArgs e)
        {
            UpdatePanelsVisibility();
        }

        private bool ValidateTextBox(TextBox input)
        {
            if (string.IsNullOrWhiteSpace(input.Text))
            {
                input.Background = Brushes.Red;
                return false;
            }

            if (double.TryParse(input.Text, out double value) && value > 0)
            {
                input.Background = Brushes.Green;
                return true;
            }
            else
            {
                input.Background = Brushes.Red;
                return false;
            }
        }

        private bool AreAllInputsValid()
        {
            if (circleRadio.IsChecked == true)
            {
                return ValidateTextBox(inputCircleRadius);
            }

            if (rectangleRadio.IsChecked == true)
            {
                bool lengthOk = ValidateTextBox(inputRectLength);
                bool widthOk = ValidateTextBox(inputRectWidth);
                return lengthOk && widthOk;
            }

            if (triangleRadio.IsChecked == true)
            {
                bool aOk = ValidateTextBox(inputTriSideA);
                bool bOk = ValidateTextBox(inputTriSideB);
                bool cOk = ValidateTextBox(inputTriSideC);

                if (aOk && bOk && cOk)
                {
                    double a = double.Parse(inputTriSideA.Text);
                    double b = double.Parse(inputTriSideB.Text);
                    double c = double.Parse(inputTriSideC.Text);

                    if (a + b <= c || a + c <= b || b + c <= a)
                    {
                        inputTriSideA.Background = Brushes.Red;
                        inputTriSideB.Background = Brushes.Red;
                        inputTriSideC.Background = Brushes.Red;
                        return false;
                    }
                }
                return aOk && bOk && cOk;
            }

            return false;
        }

        private Figure GetFigure()
        {
            if (isFigureCreated && currentFigure != null)
            {
                return currentFigure;
            }

            if (circleRadio.IsChecked == true)
            {
                double radius = double.Parse(inputCircleRadius.Text);
                currentFigure = new Circle(radius);
            }
            else if (rectangleRadio.IsChecked == true)
            {
                double length = double.Parse(inputRectLength.Text);
                double width = double.Parse(inputRectWidth.Text);
                currentFigure = new Rectangle(length, width);
            }
            else
            {
                double sideA = double.Parse(inputTriSideA.Text);
                double sideB = double.Parse(inputTriSideB.Text);
                double sideC = double.Parse(inputTriSideC.Text);
                currentFigure = new Triangle(sideA, sideB, sideC);
            }

            isFigureCreated = true;
            return currentFigure;
        }

        private void CalculateArea(object sender, RoutedEventArgs e)
        {
            message.Content = "Ошибка";
            resultS.Content = "Не посчитана";

            if (!AreAllInputsValid())
            {
                ResetFigure();
                message.Content = "Ошибка";
                return;
            }

            try
            {
                Figure figure = GetFigure();
                double area = figure.GetArea();
                resultS.Content = area.ToString("F2");
                message.Content = "Площадь посчитана";
            }
            catch (Exception)
            {
                ResetFigure();
                message.Content = "Ошибка";
            }
        }

        private void CalculatePerimeter(object sender, RoutedEventArgs e)
        {
            message.Content = "Ошибка";
            resultP.Content = "Не посчитан";

            if (!AreAllInputsValid())
            {
                ResetFigure();
                message.Content = "Ошибка";
                return;
            }

            try
            {
                Figure figure = GetFigure();
                double perimeter = figure.GetPerimeter();
                resultP.Content = perimeter.ToString("F2");
                message.Content = "Периметр посчитан";
            }
            catch (Exception)
            {
                ResetFigure();
                message.Content = "Ошибка";
            }
        }

        public void checkInputData(object sender, RoutedEventArgs e)
        {
            var textBox = sender as TextBox;
            if (textBox == null) return;

            ValidateTextBox(textBox);

            ResetFigure();
        }
    }
}