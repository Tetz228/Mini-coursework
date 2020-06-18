using System;
using System.Collections.Generic;
using System.Data.Entity;
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
using System.Windows.Shapes;

namespace Practical
{
    public partial class LoginWindow : Window
    {
        dbEntities db;

        public LoginWindow()
        {
            InitializeComponent();


            db = new dbEntities();

            db.Posts_employees.Load();
            phonesGrid.ItemsSource = db.Posts_employees.Local.ToBindingList();

            this.Closing += MainWindow_Closing;
        }

        private void MainWindow_Closing(object sender, System.ComponentModel.CancelEventArgs e)
        {
            db.Dispose();
        }
    }
}
