using PanelMaker.UI.ViewModels;
using Rhino.Commands;
using System;
using System.Windows.Controls;

namespace PanelMaker.UI.Views
{
    /// <summary>
    /// Interaction logic for MainView.xaml
    /// </summary>

    [System.Runtime.InteropServices.Guid("902F58C0-FEEF-4EB0-95AE-657CF340D0C5")]
    [CommandStyle(Rhino.Commands.Style.ScriptRunner)]
    public partial class MainView : UserControl
    {

        public MainViewModel ViewModel;
        public static Guid PanelId => typeof(MainView).GUID;

        public MainView()
        {
            InitializeComponent();
            DataContext = MainViewModel.Instance;
        }
    }
}
