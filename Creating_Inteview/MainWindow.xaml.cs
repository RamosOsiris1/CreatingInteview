using System.Windows;

namespace Creating_Inteview
{
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            IsEnabled = false;

            CreateInterview createInterview = new CreateInterview();
            createInterview.main = this;
            createInterview.Show();
        }

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            IsEnabled = false;

            SelectInterview selectInterview = new SelectInterview();
            selectInterview.main = this;
            selectInterview.Show();
        }
    }
}
