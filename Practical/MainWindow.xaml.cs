using Practical.Post;
using Practical.Post_employee;
using System.Windows;

namespace Practical
{
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();

            mainFrame.Navigate(new EmployeesPage());
        }

        private void Employees_Click(object sender, RoutedEventArgs e)
        {
            mainFrame.Navigate(new EmployeesPage());
        }

        private void Posts_Click(object sender, RoutedEventArgs e)
        {
            mainFrame.Navigate(new PostsPage());
        }

        private void Posts_emp_Click(object sender, RoutedEventArgs e)
        {
            mainFrame.Navigate(new Posts_employeesPage());
        }
    }
}
