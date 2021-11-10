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
    /// Interaction logic for Task.xaml
    /// </summary>
    public partial class TaskPage : Page
    {
        ToDoListEntities _TaskContext = new ToDoListEntities();
        TaskViewModel _viewModelTasks = new TaskViewModel();
        public TaskPage()
        {
            InitializeComponent();
        }

        private void Page_Loaded(object sender, RoutedEventArgs e)
        {
            // populate category dropdown
            var categories = _TaskContext.Categories.Select(c => c).ToList();
            categories.Add(new Category() { CategoryId = 0, CategoryName = "----- Select -----" });
            categories.OrderBy(c => c.CategoryId);
            categories.Reverse();
            _viewModelTasks.Categories = categories;

            this.DataContext = _viewModelTasks;
        }

        private void btnCancel_Click(object sender, RoutedEventArgs e)
        {
            // redirect to all tasks
            ((MainWindow)System.Windows.Application.Current.MainWindow).viewAllTasks();
        }

        private void btnSubmit_Click(object sender, RoutedEventArgs e)
        {
            service.TaskService service = new service.TaskService();
            
            // basic validation
            bool validTaskName = true;
            bool validCategory = true;

            if(string.IsNullOrEmpty(txtName.Text))
            {
                validTaskName = false;
            }

            if((cbCategory.SelectedItem as Category).CategoryId == 0)
            {
                validCategory = false;
            }

            // if both task name & category are valid...
            if(validTaskName && validCategory)
            {
                // New Task object
                Task task = new Task()
                {
                    Name = txtName.Text,
                    Category = (cbCategory.SelectedItem as Category).CategoryId,
                    Description = txtDescription.Text
                };

                if (service.AddTask(task))
                {
                    // If successful, redirect to all tasks
                    ((MainWindow)System.Windows.Application.Current.MainWindow).viewAllTasks();
                }
            }
            else
            {
                // either task name or category was not entered, let user know
                MessageBox.Show("Name and category are required","Invalid Entry", MessageBoxButton.OK, MessageBoxImage.Exclamation);
            }
        }

        private void txtName_TextChanged(object sender, TextChangedEventArgs e)
        {
            if (!string.IsNullOrWhiteSpace(txtName.Text))
            {
                validationName.Visibility = Visibility.Hidden;
                warningName.Visibility = Visibility.Hidden;
            }
            else
            {
                validationName.Visibility = Visibility.Visible;
                warningName.Visibility = Visibility.Visible;
            }
        }

        private void cbCategory_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if ((cbCategory.SelectedItem as Category).CategoryId != 0)
            {
                validationCategory.Visibility = Visibility.Hidden;
                warningCategory.Visibility = Visibility.Hidden;
            }
            else
            {
                validationCategory.Visibility = Visibility.Visible;
                warningCategory.Visibility = Visibility.Visible;
            }
        }
    }
}
