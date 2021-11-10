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

namespace TaskProject.pages
{
    /// <summary>
    /// Interaction logic for Dashboard.xaml
    /// </summary>
    public partial class Dashboard : Page
    {
        ToDoListEntities _TaskContext = new ToDoListEntities();
        TaskViewModel _viewModelTasks = new TaskViewModel();
        public Dashboard()
        {
            InitializeComponent();
        }

        private void Page_Loaded(object sender, RoutedEventArgs e)
        {
            // fetch incomplete tasks
            var incompleTasks = _TaskContext.Tasks.Where(t => t.Status == false).ToList();
            _viewModelTasks.Tasks = incompleTasks;

            this.DataContext = _viewModelTasks;
        }

        private void btnWork_Click(object sender, RoutedEventArgs e)
        {
            ((MainWindow)System.Windows.Application.Current.MainWindow).viewAllTasks();
        }
    }
}
