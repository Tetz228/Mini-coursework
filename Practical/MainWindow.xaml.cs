using Practical.Post;
using Practical.Post_employee;
using Practical.Role_user;
using Practical.Shop;
using Practical.Supplier;
using Practical.Type_product;
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

        private void Types_Product_Click(object sender, RoutedEventArgs e)
        {
            mainFrame.Navigate(new Types_productPage());
        }

        private void Roles_users_Click(object sender, RoutedEventArgs e)
        {
            mainFrame.Navigate(new Roles_usersPage());
        }

        private void Shop_Click(object sender, RoutedEventArgs e)
        {
            mainFrame.Navigate(new ShopPage());
        }

        private void Suppliers_Click_Click(object sender, RoutedEventArgs e)
        {
            mainFrame.Navigate(new SuppliersPage());
        }
    }
}
