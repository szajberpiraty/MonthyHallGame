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
using MonthyHallGame.GameClasses;
using FontAwesome.WPF;

namespace MonthyHallGame
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        //dependency injection!!
        Game Game;
        public MainWindow()
        {
                                   
            InitializeComponent();
    
            //átadom a mainwindow-t           
            Game = new Game(this);
            Game.Start();
            //Game.Mutat();
            

        }



    }
}
