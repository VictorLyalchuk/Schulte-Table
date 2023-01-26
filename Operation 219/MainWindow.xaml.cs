using System;
using System.Collections.Generic;
using System.Drawing;
using System.Globalization;
using System.Linq;
using System.Reflection;
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
using System.Windows.Threading;
using System.Xml.Linq;
using Syncfusion.UI.Xaml.ProgressBar;


namespace Operation_219
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        TimeValue time = new TimeValue();

        DispatcherTimer timer = new DispatcherTimer();
        int timerValue = 0;
        int[] arr = new int[] { 1, 2, 3, 4, 5, 6, 7, 8, 9, 10, 11, 12, 13, 14, 15, 16, 17, 18, 19, 20, 21, 22, 23, 24,25 };
        int count = 1;

        public MainWindow()
        {
            this.DataContext = this;
            InitializeComponent();
            timer.Interval = TimeSpan.FromSeconds(1);
            timer.Tick += Timer_Tick;
            ButtonIsEnableFalse();
        }
        private void Timer_Tick(object? sender, EventArgs e)
        {
            if (timerValue > 0)
            {
                timerValue--;
                MyBar.Value--;
            }
            else
            {
                MessageBox.Show($"You lose. Ha-ha\nTime: {timerValue.ToString()}", "Finish", MessageBoxButton.OK, MessageBoxImage.Stop);
                timer.Stop();
                TopTick.IsEnabled = true;
                progresGame.Value = 0;
            }
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            AllReset();
            progresGame.Maximum = 25;
            if (TopTick.Value == 0)
            {
                timerValue = 120;
                MyBar.Value = 120;
                MyBar.Maximum = 120;
                time.MyTime = 120.01;
            }
            else if (TopTick.Value == 1)
            {
                timerValue = 60;
                MyBar.Value = 60;
                MyBar.Maximum = 60;
                time.MyTime = 60.01;
            }
            else if (TopTick.Value == 2)
            {
                timerValue = 20;
                MyBar.Value = 20;
                MyBar.Maximum = 20;
                time.MyTime = 20.01;
            }
            timer.Start();
            TopTick.IsEnabled = false;
            var random = new Random(DateTime.Now.Millisecond);
            arr = arr.OrderBy(x => random.Next()).ToArray();
            SetButtonContent();
            SetButtonColor();
            ButtonIsEnable();
        }

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            Button button = (Button)sender;
            if ((int)button.Content == count)
            {
                button.Style = (Style)Resources["GreenBackground"];
                button.IsEnabled = false;
                count++;
                progresGame.Value++;
            }
            else if ((int)button.Content != count)
            {
                button.Style = (Style)Resources["RedBackground"];
                timer.Stop();
                MessageBox.Show($"You lose. Ha-ha", "Finish", MessageBoxButton.OK, MessageBoxImage.Stop);
                ButtonIsEnableFalse();
                TopTick.IsEnabled = true;
                progresGame.Value = 0;
                count = 1;
            }
            if (count == 26)
            {
                timer.Stop();
                MessageBox.Show($"You won", "Finish", MessageBoxButton.OK, MessageBoxImage.Asterisk);
                TopTick.IsEnabled = true;
                progresGame.Value = 0;
                count = 1;
            }

        }
        private void Button_Click_2(object sender, RoutedEventArgs e)
        {
            AllReset();
        }

        private void MenuItem_Click(object sender, RoutedEventArgs e)
        {
            AllReset();
            progresGame.Maximum = 25;
            if (TopTick.Value == 0)
            {
                timerValue = 120;
                MyBar.Value = 120;
                MyBar.Maximum = 120;
                time.MyTime = 120.01;
            }
            else if (TopTick.Value == 1)
            {
                timerValue = 60;
                MyBar.Value = 60;
                MyBar.Maximum = 60;
                time.MyTime = 60.01;
            }
            else if (TopTick.Value == 2)
            {
                timerValue = 20;
                MyBar.Value = 20;
                MyBar.Maximum = 20;
                time.MyTime = 20.01;
            }
            timer.Start();
            TopTick.IsEnabled = false;
            var random = new Random(DateTime.Now.Millisecond);
            arr = arr.OrderBy(x => random.Next()).ToArray();
            SetButtonContent();
            SetButtonColor();
            ButtonIsEnable();
        }
        private void MenuItem_Click_1(object sender, RoutedEventArgs e)
        {
            this.Close();
        }
        private void MenuItem_Click_2(object sender, RoutedEventArgs e)
        {
            progresGame.Maximum = 120;
            TopTick.Value = 0;
        }
        private void MenuItem_Click_3(object sender, RoutedEventArgs e)
        {
            progresGame.Maximum = 60;
            TopTick.Value = 1;
        }
        private void MenuItem_Click_4(object sender, RoutedEventArgs e)
        {
            progresGame.Maximum = 20;
            TopTick.Value = 2;
        }
        private void SetButtonColor()
        {
            Control element;
            for (int a = 0; a < MyGrid.Children.Count; a++)
            {
                element = (Control)MyGrid.Children[a];
                element.Style = (Style)Resources["WhiteBackground"];
            }
        }
        private void SetButtonContent()
        {
            int a = 0;
            foreach (var item in MyGrid.Children.OfType<Button>())
            {
                item.Content = arr[a];
                a++;
            }
        }
        private void ButtonIsEnable()
        {
            for (int a = 0; a < MyGrid.Children.Count; a++)
            {
                MyGrid.Children[a].IsEnabled = true;
            }
        }
        private void ButtonIsEnableFalse()
        {
            for (int a = 0; a < MyGrid.Children.Count; a++)
            {
                MyGrid.Children[a].IsEnabled = false;
            }
        }
        public void AllReset()
        {

            timer.Stop();
            ButtonIsEnableFalse();
            TopTick.IsEnabled = true;
            progresGame.Value = 0;
            count = 1;
        }

        private void MenuItem_Click_5(object sender, RoutedEventArgs e)
        {
            AllReset();
        }
        private void CloseCommandHandler(object sender, ExecutedRoutedEventArgs e)
        {
            this.Close();
        }
    }
}
