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
using System.IO;
using System.Reflection;
using System.Drawing;

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
            //kibaszott tetű geci megoldás, csak content-ként megy
            //Uri faking=new Uri("pack://application:,,,/pics/ali.jpg");
            Uri faking2 = new Uri("/pics/ali.jpg", UriKind.Relative);
            mainWindow.pik.Source = new BitmapImage(faking2);
            //mainWindow.pik.Source = new BitmapImage(new Uri(@"d:\razgon\ali.jpg"));
           
            
            
            
                
            

            ikonok[0] = FontAwesome.WPF.FontAwesomeIcon.Star;
            ikonok[1] = FontAwesome.WPF.FontAwesomeIcon.Save;
            ikonok[2] = FontAwesome.WPF.FontAwesomeIcon.Save;
            mainWindow.elsoAjto.Icon = ikonok[0];
            
        }
     


    }
}
