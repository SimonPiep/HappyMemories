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

namespace HappyMemories
{
    /// test
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        private void FeelHappy_Click(object sender, RoutedEventArgs e)
        {

        }

        private void Micro_click(object sender, RoutedEventArgs e)
        {
            mems = new List<MyMemory>();
            MyMemory m = new MyMemory();
            SpeechAnal a = new SpeechAnal();

            m.Thememory = TellMeInput.Text;

            var happiness = a.callOnlineAPI(m.Thememory);

            m.HappinessRating = happiness;

            mems.Add(m);

            updateFeelingsList();

        }

        private void updateFeelingsList()
        {
            foreach (MyMemory m in mems)
            {
                TextBlock printTextBlock = new TextBlock();
                string s;
                s = DateTime.Now.Year.ToString() + "." + DateTime.Now.Month.ToString() + "." + DateTime.Now.Day.ToString() + " || " ;

                if (m.Thememory.Length > 25)
                    s = s+ m.Thememory.Substring(0, 25) + "[...]";
                else
                    s =s+ m.Thememory;
                printTextBlock.Text = s;

                Button btn = new Button();
                btn.Content = "More";

                Grid aGrid = new Grid();
                aGrid.Height = 10;

                memStack.Children.Add(printTextBlock);
                memStack.Children.Add(btn);
                memStack.Children.Add(aGrid);

            }
        }

        private List<MyMemory> mems;
    }
}
