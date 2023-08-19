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

namespace PanelMaker.UI.Views
{
    /// <summary>
    /// Interaction logic for PrefixTextBox.xaml
    /// </summary>
    public partial class SuffixTextBox : UserControl
    {
        /// <summary>
        /// Gets or sets the Prefix
        /// </summary>
        public string Suffix
        {
            get => (string)GetValue(SuffixProperty);
            set => SetValue(SuffixProperty, value);
        }

        /// <summary>
        /// Prefix dependency property
        /// </summary>
        public static readonly DependencyProperty SuffixProperty =
            DependencyProperty.Register("Suffix", typeof(string),
              typeof(SuffixTextBox), new PropertyMetadata(""));

        /// <summary>
        /// Gets or sets the Text
        /// </summary>
        public string Text
        {
            get => (string)GetValue(TextProperty);
            set => SetValue(TextProperty, value);
        }

        /// <summary>
        /// Text dependency property
        /// </summary>
        public static readonly DependencyProperty TextProperty =
            DependencyProperty.Register("Text", typeof(string),
              typeof(SuffixTextBox), new PropertyMetadata(""));

        public SuffixTextBox()
        {
            InitializeComponent();
        }

    }
}