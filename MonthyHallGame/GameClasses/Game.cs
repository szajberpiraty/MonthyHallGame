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
        private System.Windows.Controls.Image[] ablak_kepek=new System.Windows.Controls.Image[3];
        private BitmapImage[] kepek= new BitmapImage[3];
        private BitmapImage[] kepek_mogott = new BitmapImage[3];
        private BitmapImage auto;
        Random veletlenSzam = new Random();





        public Game(MainWindow mainWindow)
        {
            this.mainWindow = mainWindow;
        }

        public void Start()
        {
            
            kepek[0] = new BitmapImage(new Uri("/pics/door_closed.png", UriKind.Relative));
            kepek[1] = new BitmapImage(new Uri("/pics/door_closed.png", UriKind.Relative));
            kepek[2] = new BitmapImage(new Uri("/pics/door_closed.png", UriKind.Relative));

            kepek_mogott[0]= new BitmapImage(new Uri("/pics/Goat.png", UriKind.Relative));
            kepek_mogott[1] = new BitmapImage(new Uri("/pics/Goat.png", UriKind.Relative));
            kepek_mogott[2] = new BitmapImage(new Uri("/pics/Goat.png", UriKind.Relative));
            auto= new BitmapImage(new Uri("/pics/car.png", UriKind.Relative));

            ablak_kepek[0] = mainWindow.elsoAjto;
            ablak_kepek[1] = mainWindow.masodikAjto;
            ablak_kepek[2] = mainWindow.harmadikAjto;

            ablak_kepek[0].MouseDown += kep_MouseDown;
            ablak_kepek[1].MouseDown += kep_MouseDown;
            ablak_kepek[2].MouseDown += kep_MouseDown;

            var autopoz = veletlenSzam.Next(0,kepek.Length);
            kepek_mogott[autopoz] = auto;
                     

            //todo: megcsinálni és nullázni a számlálókat
        }

        public void kep_MouseDown(object sender,MouseEventArgs e)
        {
            for (int i = 0; i < ablak_kepek.Length; i++)
            {
                ablak_kepek[i].Opacity = 1;
            }

            System.Windows.Controls.Image kep = (System.Windows.Controls.Image)sender;
            kep.Opacity = 0.7;
        }

        public void Mutat()
        {
            KepFrissit(kepek_mogott);
        }

        public void Kepcsere(string pic,int index)
        {
            kepek[index]= new BitmapImage(new Uri(pic, UriKind.Relative));
            KepFrissit(kepek);
        }

        public void Kepcsere(string pic, int index, BitmapImage[] kepek)
        {
            kepek[index] = new BitmapImage(new Uri(pic, UriKind.Relative));
            KepFrissit(kepek);
        }
        

        private void KepFrissit(BitmapImage[] kepek)
        {
            ablak_kepek[0].Source = kepek[0];
            ablak_kepek[1].Source =kepek[1];
            ablak_kepek[2].Source = kepek[2];
                     
        }


    }
}
