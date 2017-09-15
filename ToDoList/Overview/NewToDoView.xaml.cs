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

namespace ToDoList.Overview
{
    /// <summary>
    /// Interaction logic for NewToDoView.xaml
    /// </summary>
    public partial class NewToDoView : UserControl
    {
        public NewToDoView()
        {
            InitializeComponent();
            this.DataContext =new ToDoItemViewModel();
        }

        //public new ToDoItemViewModel DataContext { get { return base.DataContext as ToDoItemViewModel; } set { base.DataContext = value; } }
    }
}
