using FontAwesome.WPF;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Input;
using System.Windows.Controls;
using MonthyHallGame;
using System.Windows.Media.Imaging;

namespace MonthyHallGame.GameClasses
{
    class Game
    {

        
        private MainWindow mainWindow;
        FontAwesome.WPF.FontAwesomeIcon[] ikonok = new FontAwesome.WPF.FontAwesomeIcon[3];
        


        public Game(MainWindow mainWindow)
        {
            this.mainWindow = mainWindow;
        }

        public void Start()
        {
            mainWindow.elsoAjto.Icon = FontAwesome.WPF.FontAwesomeIcon.Star;
            mainWindow.pik.Source = new BitmapImage(new Uri(@"d:\razgon\ali.jpg"));
            ikonok[0] = FontAwesome.WPF.FontAwesomeIcon.Star;
            ikonok[1] = FontAwesome.WPF.FontAwesomeIcon.Save;
            ikonok[2] = FontAwesome.WPF.FontAwesomeIcon.Save;
            mainWindow.elsoAjto.Icon = ikonok[0];
            
        }
     


    }
}
