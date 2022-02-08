using System;
using System.Collections.Generic;
using System.ComponentModel;
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

namespace WpfIntroduction
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public static string ButtonText { get; set; } = "Next";
        public string ChkBoxText { get; set; } = "Allow Next";
        public bool ChkBoxStatus { get; set; } = true;

        public MainWindow()
        {
            InitializeComponent();
            wndStart.Title = "Kiriat Herzog";
            btnOK.Content = "אשר";
            //tbName.Text = "Adir";
            myList.SelectionChanged += myList_Select;
        }

        private void btnOK_Click(object sender, RoutedEventArgs e)
        {
            btnOK.Content = (btnOK.Content as string) switch
            {
                "OK" => "איתי",
                "איתי" => "מאיר",
                "מאיר" => "יאיר",
                "יאיר" => "אריאל",
                "אריאל" => "OK",
                _ => "OK"
            };

            MessageBoxResult result = MessageBox.Show(
                btnOK.Content as string,
                "Button content",
                MessageBoxButton.YesNoCancel,
                MessageBoxImage.Exclamation,
                MessageBoxResult.Cancel,
                MessageBoxOptions.RightAlign | MessageBoxOptions.RtlReading
                );
            if (result == MessageBoxResult.Cancel)
                btnOK.Content = "OK";
        }

        private void ComboBox_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {

        }

        private void myChk_PutVorX(object sender, RoutedEventArgs e)
        {
            //CheckBox chk = sender as CheckBox;
            //btnOK.IsEnabled = chk?.IsChecked ?? true;
        }

        private void myList_Select(object sender, SelectionChangedEventArgs e)
        {
        }

        private void windowPreviewLeftButton(object sender, MouseButtonEventArgs e)
        {
            if (!ChkBoxStatus)
                e.Handled = true;
        }

        private void btnOK_PreviewMouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
        }

        private static readonly Random random = new();
        void btnMy_MouseMove(object sender, MouseEventArgs e)
        {
            Button btn = sender as Button;
            Size size = (btn.Parent as Grid).RenderSize;
            Thickness margin = btn.Margin;
            margin.Left = random.NextDouble() * (size.Width - btn.ActualWidth);
            margin.Top = random.NextDouble() * (size.Height - btn.ActualHeight);
            btn.Margin = margin;
        }

        private void wndStart_Loaded(object sender, RoutedEventArgs e)
        {
            ResourceDictionary resources = this.Resources;
            resources["user2"] = new User { Name = "ariel", Password = "123" };
        }
    }

    public class User : DependencyObject
    {
        public string Name { get => (string)GetValue(NameDependency); set => SetValue(NameDependency, value); }
        public string Password { get => (string)GetValue(PasswordDependency); set => SetValue(PasswordDependency, value); }

        static readonly DependencyProperty NameDependency =
            DependencyProperty.Register(nameof(Name), typeof(string), typeof(User));
        static readonly DependencyProperty PasswordDependency =
            DependencyProperty.Register(nameof(Password), typeof(string), typeof(User));
    }

    public class Person // if it's not a class I can change then Sutdent can't be DependencyObject...
    {
        public string Name { get; set; }
    }

    public class Student : Person, INotifyPropertyChanged 
    {
        public event PropertyChangedEventHandler PropertyChanged;
        int year;
        public int Year
        {
            get => year;
            set
            {
                year = value;
                PropertyChanged(this, new PropertyChangedEventArgs(nameof(Year)));
            }
        }
    }
}
