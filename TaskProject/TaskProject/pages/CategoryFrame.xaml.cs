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

namespace TaskProject
{
    /// <summary>
    /// Interaction logic for CategoryFrame.xaml
    /// </summary>
    public partial class CategoryFrame : Page
    {
        ToDoListEntities _TaskContext = new ToDoListEntities();
        TaskViewModel _viewModelCategories = new TaskViewModel();
        public CategoryFrame()
        {
            InitializeComponent();
        }

        private void Page_Loaded(object sender, RoutedEventArgs e)
        {
            bindData();
        }

        public void bindData()
        {
            // fetch categories
            var categories = _TaskContext.Categories.ToList();
            // add some dummy data to description & image path, if not set
            foreach (Category cat in categories)
            {
                if (cat.CategoryDescription == "")
                    cat.CategoryDescription = "-";
                if (cat.ImageURL == "")
                    cat.ImageURL = "C:/Users/steph/source/repos/TaskProject/TaskProject/assets/folder-blank.png";
                cat.Tasks = cat.Tasks.Where(t => t.Status == false).ToList();
            }
            _viewModelCategories.Categories = categories;

            this.DataContext = _viewModelCategories;
            dgCategories.GetBindingExpression(DataGrid.ItemsSourceProperty).UpdateTarget();
        }
    }
}
