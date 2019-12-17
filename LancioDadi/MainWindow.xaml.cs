using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
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

namespace LancioDadi
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        Random r = new Random();
        public MainWindow()
        {
            InitializeComponent();
        }

        private void Btn_tira_Click(object sender, RoutedEventArgs e)
        {
            int d1 = 0;
            int d2 = 0;
            

            var Dado1 = new Thread((currentIndex) =>
            {
                
                d1 = r.Next(1, 7);
            });

            var Dado2 = new Thread((currentIndex) =>
            {
                
                d2 = r.Next(1, 7);
            });

            Dado1.Start();
            Dado2.Start();

            Dado1.Join(200);
            Dado2.Join(400);

            int Tiro = d1 + d2;

            lbl_tira.Content = Tiro;

            img_dado1.Source = new BitmapImage(new Uri($"{d1}.png", UriKind.Relative));
            img_dado2.Source = new BitmapImage(new Uri($"{d2}.png", UriKind.Relative));

        }
    }
}
