using System.Linq;
using System.Windows;
using System.Windows.Controls;

namespace Practical.Supplier
{ 
    public partial class SuppliersPage : Page
    {
        dbEntities db = new dbEntities();

        public SuppliersPage()
        {
            InitializeComponent();

            SuppliersGrid.ItemsSource = db.Suppliers.ToList();
        }

        private void Add_Click(object sender, RoutedEventArgs e)
        {
            SuppliersAdd suppliersAdd = new SuppliersAdd();

            suppliersAdd.ShowDialog();

            SuppliersGrid.ItemsSource = db.Suppliers.ToList();
        }

        private void Edit_Click(object sender, RoutedEventArgs e)
        {
            if (SuppliersGrid.SelectedCells.Count > 0)
            {
                SuppliersEdit suppliersEdit = new SuppliersEdit();

                var id = (SuppliersGrid.SelectedItem as Suppliers).id_supplier;

                ClassID.id_supplier = id;

                suppliersEdit.ShowDialog();

                SuppliersGrid.ItemsSource = db.Suppliers.ToList();
            }
        }

        private void Delete_Click(object sender, RoutedEventArgs e)
        {
            if (SuppliersGrid.SelectedCells.Count > 0)
            {
                var id = (SuppliersGrid.SelectedItem as Suppliers).id_supplier;

                Suppliers suppliers = db.Suppliers.Find(id);

                db.Suppliers.Remove(suppliers);

                db.SaveChanges();

                SuppliersGrid.ItemsSource = db.Suppliers.ToList();
            }
        }
    }
}
