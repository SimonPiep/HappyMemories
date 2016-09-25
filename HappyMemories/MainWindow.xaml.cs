using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Timers;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using System.Windows.Threading;

namespace HappyMemories
{
    /// test
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private SpeechAnal anaS;
        public MainWindow()
        {
            InitializeComponent();
            anaS = new SpeechAnal();
            //  MessageBox.Show(System.IO.Directory.GetCurrentDirectory());
        }


        private void FeelHappy_Click(object sender, RoutedEventArgs e)
        {

        }
       
        private void Micro_click(object sender, RoutedEventArgs e)
        {
            mems = new List<MyMemory>();
            MyMemory m = new MyMemory();
          

            m.Thememory = TellMeInput.Text;

            var happiness = anaS.callOnlineAPI(m.Thememory);

            m.HappinessRating = happiness;

            mems.Add(m);


            speechProgress.Value = 0;

            for (int i = 0; i < 10; i++)
            {
                System.Threading.Thread.Sleep(250);

            }
            System.Threading.Thread.Sleep(500);



            DispatcherTimer aTimer = new DispatcherTimer();
            dispatcherTimer = new DispatcherTimer();
            dispatcherTimer.Tick += new EventHandler(tick);
            dispatcherTimer.Interval = new TimeSpan(0, 0, 1);

            speechProgress.Value = 25;
            dispatcherTimer.Start();

            this.speechProgress.Value = this.speechProgress.Value + 10;
            this.speechProgress.UpdateLayout();
            if (speechProgress.Value >= 100)
                updateFeelingsList();

        }

        private void tick(object sender, EventArgs e)
        {
            this.speechProgress.Value = this.speechProgress.Value + 25;
            this.speechProgress.UpdateLayout();
            if (speechProgress.Value >= 100)
            {
                updateFeelingsList();
                speechProgress.Value = 0;
                dispatcherTimer.Stop();
            }

        }

        private void updateFeelingsList()
        {
            foreach (MyMemory m in mems)
            {
                StackPanel myStack = new StackPanel();
                myStack.Orientation = Orientation.Vertical;

                StackPanel hs = new StackPanel();
                myStack.Orientation = Orientation.Horizontal;


                TextBlock printTextBlock = new TextBlock();
                string s;
                s = DateTime.Now.Year.ToString() + "." + DateTime.Now.Month.ToString() + "." + DateTime.Now.Day.ToString() + " || ";

                if (m.Thememory.Length > 25)
                    s = s + m.Thememory.Substring(0, 25) + "[...]";
                else
                    s = s + m.Thememory;
                printTextBlock.Text = s;

                Button btn = new Button();
                btn.Content = "Read it again";
                btn.Click += new RoutedEventHandler(showOld);

                Grid aGrid = new Grid();
                aGrid.Height = 10;

                hs.Children.Add(printTextBlock);
                hs.Children.Add(btn);
                hs.Children.Add(aGrid);


                myStack.Children.Add(hs);
                Image Img = new Image();

                Uri uri;
                
                if(m.HappinessRating == 0)
                {
                    uri = new Uri("sad.png", UriKind.Relative);

                }
                else if(m.HappinessRating == 1)
                {
                    uri = new Uri("neutral.png", UriKind.Relative);

                }
                else
                {
                    uri = new Uri("happy.png", UriKind.Relative);

                }



                BitmapImage imgSource = new BitmapImage(uri);
                Img.Source = imgSource;
                Img.Width = 50;
                Img.Height = 50;
                Img.HorizontalAlignment = HorizontalAlignment.Right;

                Grid ag = new Grid();
                ag.Width = 20;


                myStack.Children.Add(ag);

                myStack.Children.Add(Img);
                memStack.Children.Add(myStack);





            }
        }

        private void showOld(object sender, RoutedEventArgs e)
        {
            TextShow ts = new TextShow();
            ts.Show();
        }

        private List<MyMemory> mems;
        private DispatcherTimer dispatcherTimer;
    }
}
