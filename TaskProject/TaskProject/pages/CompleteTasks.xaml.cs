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
    /// Interaction logic for CompleteTasks.xaml
    /// </summary>
    public partial class CompleteTasks : Page
    {
        ToDoListEntities _TaskContext = new ToDoListEntities();
        TaskViewModel _viewModelTasks = new TaskViewModel();
        public CompleteTasks()
        {
            InitializeComponent();
        }

        private void Page_Loaded(object sender, RoutedEventArgs e)
        {
            bindData();
        }

        public void bindData()
        {
            // fetch completed tasks
            var completedTasks = _TaskContext.Tasks.Where(t => t.Status == true).ToList();
            foreach (var task in completedTasks)
            {
                if (task.Description == "")
                    task.Description = "-";
            }
            _viewModelTasks.Tasks = completedTasks;

            this.DataContext = _viewModelTasks;
            dgCompletedTasks.GetBindingExpression(DataGrid.ItemsSourceProperty).UpdateTarget();
        }
    }
}
