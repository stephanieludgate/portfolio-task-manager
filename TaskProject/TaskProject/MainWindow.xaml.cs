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
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        
        public MainWindow()
        {
            InitializeComponent();
        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            menuDashboard.IsChecked = true;
            pageFrame.Source = new Uri("pages/Dashboard.xaml", UriKind.Relative);
        }

        private void btnShowTasks_Click(object sender, RoutedEventArgs e)
        {
            viewAllTasks();
        }

        private void btnShowCategories_Click(object sender, RoutedEventArgs e)
        {
            viewCategories();
        }

        private void btnShowCompleted_Click(object sender, RoutedEventArgs e)
        {
            viewCompletedTasks();
        }

        private void closeWindow_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }

        public void viewAllTasks()
        {
            // handle menu > view > checked properties
            menuCategories.IsChecked = false;
            menuCompleted.IsChecked = false;
            menuDashboard.IsChecked = false;
            menuSQL.IsChecked = false;
            menuTasks.IsChecked = true;
            // update frame
            pageFrame.Source = new Uri("pages/TaskFrame.xaml", UriKind.Relative);
        }

        public void viewCompletedTasks()
        {
            // handle menu > view > checked properties
            menuCategories.IsChecked = false;
            menuTasks.IsChecked = false;
            menuDashboard.IsChecked = false;
            menuSQL.IsChecked = false;
            menuCompleted.IsChecked = true;
            // update frame
            pageFrame.Source = new Uri("pages/CompleteTasks.xaml", UriKind.Relative);
        }

        public void viewCategories()
        {
            // handle menu > view > checked properties
            menuCompleted.IsChecked = false;
            menuTasks.IsChecked = false;
            menuDashboard.IsChecked = false;
            menuSQL.IsChecked = false;
            menuCategories.IsChecked = true;
            // update frame
            pageFrame.Source = new Uri("pages/CategoryFrame.xaml", UriKind.Relative);
        }

        public void viewNewTask()
        {
            // handle menu > view > checked properties
            menuCompleted.IsChecked = false;
            menuTasks.IsChecked = false;
            menuDashboard.IsChecked = false;
            menuCategories.IsChecked = false;
            menuSQL.IsChecked = false;
            // update frame
            pageFrame.Source = new Uri("pages/TaskPage.xaml", UriKind.Relative);
        }

        public void viewDashboard()
        {
            // handle menu > view > checked properties
            menuCompleted.IsChecked = false;
            menuTasks.IsChecked = false;
            menuCategories.IsChecked = false;
            menuSQL.IsChecked = false;
            menuDashboard.IsChecked = true;
            // update frame
            pageFrame.Source = new Uri("pages/Dashboard.xaml", UriKind.Relative);
        }

        private void menuCompleted_Checked(object sender, RoutedEventArgs e)
        {
            viewCompletedTasks();
        }

        private void menuCategories_Checked(object sender, RoutedEventArgs e)
        {
            viewCategories();
        }

        private void menuTasks_Checked(object sender, RoutedEventArgs e)
        {
            viewAllTasks();
        }

        private void menuNewTask_Click(object sender, RoutedEventArgs e)
        {
            viewNewTask();
        }

        private void menuDashboard_Checked(object sender, RoutedEventArgs e)
        {
            viewDashboard();
        }

        private void menuSQL_Checked(object sender, RoutedEventArgs e)
        {
            // handle menu > view > checked properties
            menuCompleted.IsChecked = false;
            menuTasks.IsChecked = false;
            menuDashboard.IsChecked = false;
            menuCategories.IsChecked = false;
            menuSQL.IsChecked = true;
            // update frame
            pageFrame.Source = new Uri("pages/SQLTables.xaml", UriKind.Relative);
        }
    }
}
