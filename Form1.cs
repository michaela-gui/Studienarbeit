using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;


namespace Studienarbeit
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        /******************* Click-Methoden *******************************************/
        private void btn_Calc_Click(object sender, EventArgs e)
        {
            Berechne_Lichtmenge_Ohne_Fenster();

            return;
        }
        private void btn_WaehleLeuchten_Click(object sender, EventArgs e)
        {
            Form mySubForm = new LampenWahl();
            mySubForm.ShowDialog();
        }
        private void btn_WähleFenster_Click(object sender, EventArgs e)
        {

            Form form = new Fenster();
            form.ShowDialog();
        }
        private void Form1_Load(object sender, EventArgs e)
        {
            this.AutoScroll = true;
        }
        private void btn_ShowRoom_Click(object sender, EventArgs e)
        {
            this.pictureBox1.Image = Image.FromFile("..\\..\\Bilder\\AnsichtRaum_Küche.png");
        }
        private void btn_BerechneMitTageslicht_Click(object sender, EventArgs e)
        {
            /* Lampen bei Tageslicht berechnen */
            if ((Storage.Fenster_Anzahl_Nord != 0) || (Storage.Fenster_Anzahl_Ost != 0) || (Storage.Fenster_Anzahl_Sued != 0) || (Storage.Fenster_Anzahl_West != 0))
            {
                Berechne_Lichtmenge_Mit_Fenster();
            }

            return;
        }

        /******************* Haupt-Methoden *******************************************/

        private int Berechne_Parameter_Nach_Statischen_Angaben()
        {
            /* Default: Glühlampen verwenden, 12lm/W, Ra 90, 500lx, 0.6 Reflex., 800lm Leuchte, 60W, Lichtfarbe 827 (weiß) */
            if (this.comboBox1.Text.Equals("Küche"))
            {
                /* Setze static Parameter */
                string lampentyp = Storage.Leuchtmittel_Typ;
                int gewünschteLichtmengeImRaum = Storage.Raum_Küche_Lichtmenge; //lx
                double reflexionOberflächen = 0.6;
                int leuchtvermögenProLeuchte = Storage.Leuchtmittel_Nutzlichtstrom; //lm
                int leistungProLeuchte_Glühlampe = Storage.Leuchtmittel_Watt; //W

                return gewünschteLichtmengeImRaum;
            }

            /* Default: Glühlampen verwenden, 12lm/W, Ra 80, 500lx, 0.6 Reflex., 800lm Leuchte, 60W, Lichtfarbe 827 (weiß) */
            if (this.comboBox1.Text.Equals("Arbeitszimmer"))
            {
                /* Setze static Parameter */
                string lampentyp = Storage.Leuchtmittel_Typ;
                int gewünschteLichtmengeImRaum = Storage.Raum_Arbeitsplatz_Lichtmenge; //lx
                double reflexionOberflächen = 0.6;
                int leuchtvermögenProLeuchte = Storage.Leuchtmittel_Nutzlichtstrom; //lm
                int leistungProLeuchte_Glühlampe = Storage.Leuchtmittel_Watt; //W

                return gewünschteLichtmengeImRaum;
            }
            return 0;
        }

        void Berechne_Lichtmenge_Ohne_Fenster()
        {
            /* Berechne Anforderung an Lampen ohne Einbezug der Fenster */
            double gesamtraum = 0.0;
            double neuerRaum = 0.0;


            /* Wähle Konstanten für Raum */
            int raumBeleuchtungsstärke = Berechne_Parameter_Nach_Statischen_Angaben();
            
            /* 1. Berechne Raumgroesse */
            neuerRaum = Berechne_Raumgroesse();
            
            /* 3. Berechne Leuchten und Leistung, Ausgabe auf UI */
            Berechne_Lichtmenge_AnzahlLeuchten_LeistungLeuchten(neuerRaum);

            return;
        }

        double Berechne_Raumgroesse()
        {
            double gesamtraum, laengeRaum, breiteRaum = 0.0;

            laengeRaum = Convert.ToDouble(this.tb_RoomLength.Text); // 6.0;
            breiteRaum = Convert.ToDouble(this.tb_RoomWidth.Text); // 5.0;
            gesamtraum = laengeRaum * breiteRaum;

            return gesamtraum;
        }

        double Berechne_Helligkeitseinfluss_Durch_Fenster(double neuerRaum, double laengeRaum, double breiteRaum)
        {
            double raumtiefeNord = 0.0;
            double raumtiefeSued = 0.0;
            double raumtiefeWest = 0.0;
            double raumtiefeOst = 0.0;

            double hoeheFensterNord = Storage.Fenster_Laenge_Nord;
            double hoeheFensterSued = Storage.Fenster_Laenge_Sued;
            double hoeheFensterWest = Storage.Fenster_Laenge_West;
            double hoeheFensterOst = Storage.Fenster_Laenge_Ost;

            if (0 != Storage.Fenster_Anzahl_Nord)
            {
                /* BERECHNE LICHTEINFLUSS-TIEFE AUF NORDSEITE */
                raumtiefeNord = hoeheFensterNord / 2.0; /* Lichteinfluss Tiefe Nordseite */
            }
            if (0 != Storage.Fenster_Anzahl_Sued)
            {
                /* BERECHNE LICHTEINFLUSS-TIEFE AUF SUEDSEITE */
                raumtiefeSued = hoeheFensterSued / 2.0;
            }
            if (0 != Storage.Fenster_Anzahl_West)
            {
                /* BERECHNE LICHTEINFLUSS-TIEFE AUF WESTSEITE */
                raumtiefeWest = hoeheFensterWest / 2.0;
            }
            if (0 != Storage.Fenster_Anzahl_Ost)
            {
                /* BERECHNE LICHTEINFLUSS-TIEFE AUF OSTSEITE */
                raumtiefeOst = hoeheFensterOst / 2.0;
            }

            /* Addiere alle errechneten Seiten */
            double neuerRaumLocal = Addiere_Alle_Errechneten_Seiten(neuerRaum, laengeRaum, breiteRaum, 
                raumtiefeNord, raumtiefeSued, raumtiefeWest, raumtiefeOst);

            return neuerRaumLocal;
        }

        double Addiere_Alle_Errechneten_Seiten(double neuerRaum, double laengeRaum, double breiteRaum, 
            double raumtiefeNord, double raumtiefeSued, double raumtiefeWest, double raumtiefeOst)
        {
            double neuelaengeRaum = 0.0;
            double neuebreiteRaum = 0.0;

            /* Zusammenfassen: Addiere alle errechneten Seiten */
            if (Storage.FensterSeiteNorden.Equals("Längsseite"))
            {
                /* Verwende Längsseite des Raumes */
                neuelaengeRaum += raumtiefeNord;
                neuelaengeRaum += raumtiefeSued;
                neuebreiteRaum += raumtiefeWest;
                neuebreiteRaum += raumtiefeOst;

                if ((neuebreiteRaum != 0) && (neuelaengeRaum != 0))
                {
                    /* bei "Überlappung" soll 0 verwendet werden */
                    neuerRaum = (laengeRaum - neuelaengeRaum) * (breiteRaum - neuebreiteRaum);
                }

                /* gibt negative Werte aus: */
                //if ((neuebreiteRaum != 0) && (neuelaengeRaum != 0))
                //{
                //    /* bei "Überlappung" soll 0 verwendet werden */
                //    if((laengeRaum - neuelaengeRaum) <= 0) { neuerRaum = breiteRaum * 1; }
                //    if ((breiteRaum - neuebreiteRaum) <= 0) { neuerRaum = laengeRaum * 1; }
                //    else { neuerRaum = (laengeRaum - neuelaengeRaum) * (breiteRaum - neuebreiteRaum); }
                //}
                //else
                //{
                //    if(neuebreiteRaum <= 0) { neuebreiteRaum = 1; }
                //    if(neuelaengeRaum <= 0) { neuelaengeRaum = 1; }
                //    neuerRaum = (laengeRaum - neuelaengeRaum) * (breiteRaum - neuebreiteRaum);
                //}

            }
            else if (Storage.FensterSeiteNorden.Equals("Breitseite"))
            {
                /* Verwende Längsseite des Raumes */
                neuebreiteRaum += raumtiefeNord;
                neuebreiteRaum += raumtiefeSued;
                neuelaengeRaum += raumtiefeWest;
                neuelaengeRaum += raumtiefeOst;

                if ((neuebreiteRaum != 0) && (neuelaengeRaum != 0))
                {
                    /* bei "Überlappung" soll 0 verwendet werden */
                    neuerRaum = (laengeRaum - neuelaengeRaum) * (breiteRaum - neuebreiteRaum);
                }
            }

            return neuerRaum;
        }

        void Berechne_Lichtmenge_AnzahlLeuchten_LeistungLeuchten(double neuerRaum)
        {
            Calculation myCalc = new Calculation();
            double reflexionOberfläche = 0.6; /* soll von Param kommen */
            int raumBeleuchtungsstärke = Storage.Raum_Küche_Lichtmenge; /* soll von Param kommen */

            /* 3. Berechne notwendige Lichtmenge im Raum */
            int leuchtdichte = myCalc.LeuchtdichteBerechnen(reflexionOberfläche, raumBeleuchtungsstärke);

            /* 4. Berechne notwendige Anzahl Lampen im Raum */
            int anzahlLeuchten = Berechne_Leuchtdichte_Im_Raum(neuerRaum);
            this.tb_RoomCountLights.Text = anzahlLeuchten.ToString();

            /* 5. Berechne notwendige Leistung im Raum */
            this.tb_RoomCountPower.Text = myCalc.LeistungAllerLeuchtenBerechnen(Storage.Leuchtmittel_Watt, anzahlLeuchten).ToString();

            return;
        }

        void Berechne_Lichtmenge_Mit_Fenster()
        {
            
            double gesamtraum = 0.0;
            double neuerRaum = 0.0;
            

            /* Wähle Konstanten für Raum */
            int raumBeleuchtungsstärke = Berechne_Parameter_Nach_Statischen_Angaben();

            /* 1. Berechne Raumgroesse */
            gesamtraum = Berechne_Raumgroesse();

            /* 2. Helligkeit durch Fenster */
            neuerRaum = Berechne_Helligkeitseinfluss_Durch_Fenster(neuerRaum, Convert.ToDouble(this.tb_RoomLength.Text), Convert.ToDouble(this.tb_RoomWidth.Text));

            /* 3. Berechne Leuchten und Leistung, Ausgabe auf UI */
            Berechne_Lichtmenge_AnzahlLeuchten_LeistungLeuchten(neuerRaum);


            return;
        }

        public int Berechne_Leuchtdichte_Im_Raum(double neuerRaumMitRand)
        {
            /* Berechne die Leuchtdichte im Raum */
            double raumgroesseInm2MitRand = neuerRaumMitRand;

            int lux = 0;

            if (Storage.Leuchtmittel_Abstrahlwinkel == 360)
            {
                lux = Convert.ToInt32(raumgroesseInm2MitRand / 12.6);
            }

            if (Storage.Leuchtmittel_Abstrahlwinkel == 120)
            {
                lux = Convert.ToInt32(raumgroesseInm2MitRand / 3.14);
            }

            if (Storage.Leuchtmittel_Abstrahlwinkel == 38)
            {
                lux = Convert.ToInt32(raumgroesseInm2MitRand / 1.3);
            }

            return lux;
        }
    }
}
