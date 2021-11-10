using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
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
    /// Interaction logic for TaskFrame.xaml
    /// </summary>
    public partial class TaskFrame : Page
    {
        ToDoListEntities _TaskContext = new ToDoListEntities();
        TaskViewModel _viewModelTasks = new TaskViewModel();

        public TaskFrame()
        {
            InitializeComponent();
        }

        private void comboCategories_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            int selectedValue = (comboCategories.SelectedItem as Category).CategoryId;
            var filteredTasks = _TaskContext.Tasks.Where(t => t.Status == false).ToList();
            txtDynamicCategry.Text = "";

            if (selectedValue > 0)
            {
                filteredTasks = _TaskContext.Tasks.Where(t => t.Status == false).Where(ts => ts.Category == selectedValue).ToList();
                Category category = _TaskContext.Categories.Where(c => c.CategoryId == selectedValue).FirstOrDefault();
                txtDynamicCategry.Text = $"- {category.CategoryName}";
            }

            foreach (Task task in filteredTasks)
            {
                if (task.Description == "")
                    task.Description = "-";
            }

            _viewModelTasks.Tasks = filteredTasks;
            this.DataContext = _viewModelTasks;
            dgTasks.GetBindingExpression(DataGrid.ItemsSourceProperty).UpdateTarget();
        }

        private void Page_Loaded(object sender, RoutedEventArgs e)
        {
            bindData();
        }

        private void btnAddTask_Click(object sender, RoutedEventArgs e)
        {
            ((MainWindow)System.Windows.Application.Current.MainWindow).viewNewTask();
        }

        private void btnDeleteTask_Click(object sender, RoutedEventArgs e)
        {
            Task selectedTask = dgTasks.SelectedItem as Task;
            int selectedID = selectedTask.Id;

            service.TaskService service = new service.TaskService();
            if (service.DeleteTask(selectedID))
            {
                MessageBox.Show($"\'{selectedTask.Name}\' has been removed.");
            }
            bindData();
        }

        private void btnComplete_Click(object sender, RoutedEventArgs e)
        {
            Task selectedTask = dgTasks.SelectedItem as Task;
            int selectedID = selectedTask.Id;

            service.TaskService service = new service.TaskService();
            if (service.CompleteTask(selectedID))
            {
                MessageBox.Show($"\'{selectedTask.Name}\' has been completed!");
            }
            bindData();
        }

        public void bindData()
        {
            // fetch incomplete tasks
            var incompleTasks = _TaskContext.Tasks.Where(t => t.Status == false).ToList();
            foreach (Task task in incompleTasks)
            {
                if (task.Description == "")
                    task.Description = "-";
            }
            _viewModelTasks.Tasks = incompleTasks;

            // populate task dropdown
            var filterCaetgories = _TaskContext.Categories.Select(c => c).ToList();
            filterCaetgories.Add(new Category() { CategoryId = 0, CategoryName = "----- All -----" });
            filterCaetgories.OrderBy(c => c.CategoryId);
            filterCaetgories.Reverse();
            _viewModelTasks.Categories = filterCaetgories;

            this.DataContext = _viewModelTasks;
            dgTasks.GetBindingExpression(DataGrid.ItemsSourceProperty).UpdateTarget();
        }
    }
}