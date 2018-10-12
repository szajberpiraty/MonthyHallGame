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
using System.Diagnostics;

namespace MonthyHallGame.GameClasses
{
    class Game
    {


        private MainWindow mainWindow;
        private System.Windows.Controls.Image[] ablak_kepek = new System.Windows.Controls.Image[3];
        private BitmapImage[] kepek = new BitmapImage[3];
        private BitmapImage[] kepek_mogott = new BitmapImage[3];
        private BitmapImage auto;
        Random veletlenSzam = new Random();
        int valasztottkep = 4;
        int uj_valasztottkep = 4;
        List<int> kecskePoz = new List<int>();
        int autoPoz;
        int jatekAllapot;





        public Game(MainWindow mainWindow)
        {
            this.mainWindow = mainWindow;
        }

        public void Start()
        {
            KepInit();
                                 

            ablak_kepek[0].MouseDown += kep_MouseDown;
            ablak_kepek[1].MouseDown += kep_MouseDown;
            ablak_kepek[2].MouseDown += kep_MouseDown;

            AutoElhelyezes();


            //todo: megcsinálni és nullázni a számlálókat
        }

        private void AutoElhelyezes()
        {
            autoPoz = veletlenSzam.Next(0, kepek.Length);
            Debug.WriteLine("Autó helye:{0}", autoPoz);
            kepek_mogott[autoPoz] = auto;
            jatekAllapot = 0;
            kecskePoz.Clear();
            for (int i = 0; i < kepek_mogott.Length; i++)
            {
                if (kepek_mogott[i] != auto)
                {
                    kecskePoz.Add(i);
                    Debug.WriteLine("Kecskék:{0}", i);
                }
            }
        }

        private void KepInit()
        {
            kepek[0] = new BitmapImage(new Uri("/pics/door_closed.png", UriKind.Relative));
            kepek[1] = new BitmapImage(new Uri("/pics/door_closed.png", UriKind.Relative));
            kepek[2] = new BitmapImage(new Uri("/pics/door_closed.png", UriKind.Relative));
            kepek_mogott[0] = new BitmapImage(new Uri("/pics/Goat.png", UriKind.Relative));
            kepek_mogott[1] = new BitmapImage(new Uri("/pics/Goat.png", UriKind.Relative));
            kepek_mogott[2] = new BitmapImage(new Uri("/pics/Goat.png", UriKind.Relative));
            auto = new BitmapImage(new Uri("/pics/car.png", UriKind.Relative));

            ablak_kepek[0] = mainWindow.elsoAjto;
            ablak_kepek[1] = mainWindow.masodikAjto;
            ablak_kepek[2] = mainWindow.harmadikAjto;
        }

        public void ElsoAjtoNyitas()
        {
            var melyikAjto = veletlenSzam.Next(0, kecskePoz.Count);
            while (kecskePoz[melyikAjto] == valasztottkep)
            {
                melyikAjto = veletlenSzam.Next(0, kecskePoz.Count);

            }
            Debug.WriteLine("Ennek kecskének kéne lennie:{0}", kecskePoz[melyikAjto]);
            Debug.WriteLine("Ezt választja a kecskepoz-ból:{0},aminek értéke:{1}", melyikAjto, kecskePoz[melyikAjto]);
            Debug.WriteLine("Először kiválasztott ajtó:{0}", valasztottkep);

            kepek[kecskePoz[melyikAjto]] = kepek_mogott[kecskePoz[melyikAjto]];
            KepFrissit(kepek);
        }


        public void kep_MouseDown(object sender, MouseEventArgs e)
        {
            for (int i = 0; i < ablak_kepek.Length; i++)
            {
                ablak_kepek[i].Opacity = 1;
            }

            System.Windows.Controls.Image kep = (System.Windows.Controls.Image)sender;
            kep.Opacity = 0.7;

            for (int i = 0; i < ablak_kepek.Length; i++)
            {
                if (ablak_kepek[i].Opacity == 0.7)
                {
                    valasztottkep = i;
                }
            }
            mainWindow.valasztott.Content = valasztottkep;

            switch (jatekAllapot)
            {
                case 0:
                    ElsoAjtoNyitas();
                    jatekAllapot++;
                    break;
                case 1:
                    Mutat();
                    jatekAllapot++;
                    break;
                case 2:
                    UjJatek();
                    ablak_kepek[valasztottkep].Opacity = 1;
                    break;
                default:
                    break;
            }

            //if (jatekAllapot == 1)
            //{
            //    Mutat();
            //}

            //if (jatekAllapot == 0)
            //{
            //    ElsoAjtoNyitas();
            //    jatekAllapot++;
            //}


        }

        public void Mutat()
        {
            KepFrissit(kepek_mogott);
        }

        public void UjJatek()
        {
            KepInit();
            KepFrissit(kepek);
            AutoElhelyezes();
            jatekAllapot = 0;
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
