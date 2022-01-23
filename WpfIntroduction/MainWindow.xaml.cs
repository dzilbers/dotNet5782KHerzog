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

namespace WpfIntroduction
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
            wndStart.Title = "Kiriat Herzog";
            btnOK.Content = "אשר";
            tbName.Text = "Adir";
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
            if (!myChkBox.IsChecked ?? false)
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

    }

    public class MyClass { }
}
