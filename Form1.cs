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
            //Berechne_Parameter_Nach_Statischen_Angaben();
            

            return;
        }
        private void btn_WaehleLeuchten_Click(object sender, EventArgs e)
        {
            Form mySubForm = new LampenWahl();
            mySubForm.ShowDialog();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            this.AutoScroll = true;
        }

        /******************* Haupt-Methoden *******************************************/

        //private double Berechne_Leuchtdichte_Im_Raum(Calculation myCalc, double reflexionOberflächen, int gewünschteLichtmengeImRaum)
        //{
        //    int leuchtdichte = myCalc.LeuchtdichteBerechnen(reflexionOberflächen, gewünschteLichtmengeImRaum);

        //    /* Rechne Lumen/m² in Lux um */
        //    double raumgroesseInm2 = Convert.ToDouble(this.tb_RoomLength.Text) * Convert.ToInt32(this.tb_RoomWidth.Text);

        //    /* Ertelle 2 temp Variablen, um die nachfolgende Berechnung vereinfacht darzustellen */
        //    double tempRoomLength = Convert.ToDouble(this.tb_RoomLength.Text);
        //    double tempRoomWidth = Convert.ToDouble(this.tb_RoomWidth.Text);

        //    double raumgroesseInm2MitRand = raumgroesseInm2 - (tempRoomLength * 0.3) + (tempRoomWidth * 0.3); // 0.3m Abstand zu allen Rändern

        //    return raumgroesseInm2MitRand;
        //}

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

                //Berechne_Parameter_Fuer_Ausgabe(lampentyp, gewünschteLichtmengeImRaum, reflexionOberflächen, leuchtvermögenProLeuchte, leistungProLeuchte_Glühlampe);

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

                //Berechne_Parameter_Fuer_Ausgabe(lampentyp, gewünschteLichtmengeImRaum, reflexionOberflächen, leuchtvermögenProLeuchte, leistungProLeuchte_Glühlampe);

                return gewünschteLichtmengeImRaum;
            }
            return 0;
        }



        //private void Berechne_Neue_Anzahl_ungenuegend_Tageslicht_BreiteSeite()
        //{
        //    /* Berechne Anzahl notwendiger Lichter für Raum */

        //    //1. Berechne neues "Rechteck" für Lichtberechnung
        //    int newRoomWidth = Convert.ToInt32(this.tb_RoomWidth.Text) - 4;

        //    /* Rechne Lumen/m² in Lux um */
        //    double raumgroesseInm2 = Convert.ToDouble(this.tb_RoomLength.Text) * newRoomWidth;

        //    /* Ertelle 2 temp Variablen, um die nachfolgende Berechnung vereinfacht darzustellen */
        //    double tempRoomLength = Convert.ToDouble(this.tb_RoomLength.Text);
        //    double tempRoomWidth = newRoomWidth;

        //    double raumgroesseInm2MitRand = raumgroesseInm2 - (tempRoomLength * 0.3) + (tempRoomWidth * 0.3); // 0.3m Abstand zu allen Rändern

        //    Storage.NeuerDunklerRaum = raumgroesseInm2MitRand;

        //    //2. Berechne Anzahl Lichter
        //    Berechne_Parameter_Neuer_Raum(raumgroesseInm2MitRand);

        //    return;
        //}

        //private void Berechne_Fenster()
        //{
        //    int seite = 0;
        //    switch (Storage.FensterSeiteNorden)
        //    {
        //        case "Längsseite": /* Fenster Norden ist auf der Längsseite des Raumes */
        //            seite = 1;
        //            break;
        //        case "Breitseite":
        //            seite = 2; /* Fenster Norden ist auf der Breitsteite des Raumes */
        //            break;
        //    }

        //    /* Berechne die Nord-Seite */
        //    if (Storage.Fenster_Laenge_Nord != 0)
        //    {
        //        /* Feste Annahme: Nordseite durchschnittlich 20.000 Lux */
        //        int lux_Nord = 10000; // E(h) außen

        //        if (Storage.FensterSeiteNorden == "Längsseite") /* Berechne Einflusstiefe Tageslicht in lange Seite des Raumes */
        //        {
        //            /* Maße der Längsseite verwenden */
        //            int localLength = Convert.ToInt32(this.tb_RoomLength.Text);
        //            Berechne_Tiefe_Einfluss_Sonnenlicht(localLength, lux_Nord);
        //            seite = 1;

        //        }
        //        if (Storage.FensterSeiteNorden == "Breitseite") /* Berechne Einflusstiefe Tageslicht in breite Seite des Raumes */
        //        {
        //            /* Maße der Breitseite verwenden */
        //            int localWidth = Convert.ToInt32(this.tb_RoomWidth.Text);
        //            Berechne_Tiefe_Einfluss_Sonnenlicht(localWidth, lux_Nord);
        //            seite = 2;
        //        }
        //    } /* Ende "Nord-Seite" */

        //    /* Berechne die Ost-Seite */
        //    if (Storage.Fenster_Laenge_Ost != 0)
        //    {
        //        /* Feste Annahme: Ostseite durchschnittlich 15.000 Lux */
        //        int lux_Ost = 15000; // E(h) außen

        //        if (seite == 2) /* Berechne Einflusstiefe Tageslicht in lange Seite des Raumes */
        //        {
        //            /* Maße der Längsseite verwenden */
        //            int localLength = Convert.ToInt32(this.tb_RoomLength.Text);
        //            Berechne_Tiefe_Einfluss_Sonnenlicht(localLength, lux_Ost);

        //        }
        //        if (seite == 1) /* Berechne Einflusstiefe Tageslicht in breite Seite des Raumes */
        //        {
        //            /* Maße der Breitseite verwenden */
        //            int localWidth = Convert.ToInt32(this.tb_RoomWidth.Text);
        //            Berechne_Tiefe_Einfluss_Sonnenlicht(localWidth, lux_Ost);
        //        }
        //    } /* Ende "Ost-Seite" */

        //    /* Berechne die Süd-Seite */
        //    if (Storage.Fenster_Laenge_Sued != 0)
        //    {
        //        /* Feste Annahme: Südseite durchschnittlich 20.000 Lux */
        //        int lux_Sued = 20000; // E(h) außen

        //        if (seite == 1) /* Berechne Einflusstiefe Tageslicht in lange Seite des Raumes */
        //        {
        //            /* Maße der Längsseite verwenden */
        //            int localLength = Convert.ToInt32(this.tb_RoomLength.Text);
        //            Berechne_Tiefe_Einfluss_Sonnenlicht(localLength, lux_Sued);

        //        }
        //        if (seite == 2) /* Berechne Einflusstiefe Tageslicht in breite Seite des Raumes */
        //        {
        //            /* Maße der Breitseite verwenden */
        //            int localWidth = Convert.ToInt32(this.tb_RoomWidth.Text);
        //            Berechne_Tiefe_Einfluss_Sonnenlicht(localWidth, lux_Sued);
        //        }
        //    } /* Ende "Süd-Seite" */

        //    /* Berechne die West-Seite */
        //    if (Storage.Fenster_Laenge_West != 0)
        //    {
        //        /* Feste Annahme: Westseite durchschnittlich 15.000 Lux */
        //        int lux_West = 15000; // E(h) außen

        //        if (seite == 2) /* Berechne Einflusstiefe Tageslicht in lange Seite des Raumes */
        //        {
        //            /* Maße der Längsseite verwenden */
        //            int localLength = Convert.ToInt32(this.tb_RoomLength.Text);
        //            Berechne_Tiefe_Einfluss_Sonnenlicht(localLength, lux_West);

        //        }
        //        if (seite == 1) /* Berechne Einflusstiefe Tageslicht in breite Seite des Raumes */
        //        {
        //            /* Maße der Breitseite verwenden */
        //            int localWidth = Convert.ToInt32(this.tb_RoomWidth.Text);
        //            Berechne_Tiefe_Einfluss_Sonnenlicht(localWidth, lux_West);
        //        }
        //    } /* Ende "West-Seite" */

        //    return;
        //}

        //private void Berechne_Tiefe_Einfluss_Sonnenlicht(int localWidth, int lux_Nord)
        //{
        //    int tempLocalWidth = localWidth;
        //    while (localWidth > 0)
        //    {
        //        if (localWidth == tempLocalWidth)
        //        {
        //            /* Direkt am Fenster */
        //            int E_innen_1Meter = Convert.ToInt32((lux_Nord * 11.0) / 100);
        //        }
        //        if ((localWidth + 1) == tempLocalWidth)
        //        {
        //            /* Nach 1 Meter */
        //            int E_innen_1Meter = Convert.ToInt32((lux_Nord * 6.5) / 100);
        //        }
        //        if ((localWidth + 2) == tempLocalWidth)
        //        {
        //            /* Nach 2 Meter */
        //            int E_innen_2Meter = Convert.ToInt32((lux_Nord * 3.9) / 100);
        //        }
        //        if ((localWidth + 3) == tempLocalWidth)
        //        {
        //            /* Nach 3 Meter */
        //            int E_innen_1Meter = Convert.ToInt32((lux_Nord * 2.7) / 100);
        //        }
        //        if ((localWidth + 4) == tempLocalWidth)
        //        {
        //            /* Nach 4 Meter */
        //            int E_innen_4Meter = Convert.ToInt32((lux_Nord * 2.0) / 100);
        //        }
        //        if ((localWidth + 5) == tempLocalWidth)
        //        {
        //            /* Nach 5 Meter */ /* Tageslicht reicht unter 2% nicht aus */
        //            int E_innen_5Meter = Convert.ToInt32((lux_Nord * 1.8) / 100);
        //            Berechne_Neue_Anzahl_ungenuegend_Tageslicht_BreiteSeite();
        //        }
        //        if ((localWidth + 6) == tempLocalWidth)
        //        {
        //            /* Nach 6 Meter */
        //            int E_innen_6Meter = Convert.ToInt32((lux_Nord * 1.3) / 100);
        //            Berechne_Neue_Anzahl_ungenuegend_Tageslicht_BreiteSeite();
        //        }
        //        localWidth -= 1;
        //    }

        //    return;
        //}



        private void Berechne_Lichtausbeute_Verwendete_Lampen(int leistungProLeuchte_Glühlampe, double neuerRaumMitRand)
        {
            /* Berechne die Lichtausbeute für die verwendeten Lampentypen */
            Calculation myCalc = new Calculation();
            this.tb_RoomCountPower.Text = myCalc.LeistungAllerLeuchtenBerechnen(leistungProLeuchte_Glühlampe, Berechne_Leuchtdichte_Im_Raum(neuerRaumMitRand)).ToString();

            return;
        }










        /******************* Helfer-Methoden ******************************************/
        private void btn_ShowRoom_Click(object sender, EventArgs e)
        {
            this.pictureBox1.Image = Image.FromFile("..\\..\\Bilder\\AnsichtRaum_Küche.png");
        }

        private void btn_WähleFenster_Click(object sender, EventArgs e)
        {

            Form form = new Fenster();
            form.ShowDialog();
        }
        private void btn_BerechneMitTageslicht_Click(object sender, EventArgs e)
        {
            /* Lampen bei Tageslicht berechnen */
            if ((Storage.Fenster_Anzahl_Nord != 0) || (Storage.Fenster_Anzahl_Ost != 0) || (Storage.Fenster_Anzahl_Sued != 0) || (Storage.Fenster_Anzahl_West != 0))
            {
                /* Berechne Tageslicht-Quotient des Raumes */
                //Berechne_Fenster();
                Berechne_Lichtmenge_Mit_Fenster();
            }

            //Berechne_Fenster_NordundSued_an_Laengsseite(); /* temp */

            return;
        }
        private void Setze_Statische_Parameter_Fuer_Raum(double neuerRaumMitRand)
        {
            /* Setze static Parameter */
            string lampentyp = Storage.Leuchtmittel_Typ;
            int gewünschteLichtmengeImRaum = Storage.Raum_Arbeitsplatz_Lichtmenge; //lx
            double reflexionOberflächen = 0.6; /* evtl. Wand- und Fußbodenleuchtdichte hieraus berechnen */
            int leuchtvermögenProLeuchte = Storage.Leuchtmittel_Nutzlichtstrom; //lm
            int leistungProLeuchte_Glühlampe = Storage.Leuchtmittel_Watt; //W

            Berechne_Lichtausbeute_Verwendete_Lampen(leistungProLeuchte_Glühlampe, neuerRaumMitRand);

            /* Setze die "gewünschte Lichtmenge" in der UI */
            this.tb_RoomLux.Text = leuchtvermögenProLeuchte.ToString();

            return;
        }
        private double Berechne_LichtTiefe_im_Raum(double WindowHeightFromFloor)
        {
            /* Berechne die Tiefe im Raum über 2 Winkel (30° Sonneneinfall, 90° Boden) und 1 Seite (maxFensterHoehe) */
            double tiefeRaum = WindowHeightFromFloor / 2.0;

            return tiefeRaum;
        }
        private void Berechne_Parameter_Neuer_Raum(double neuerRaumMitRand)
        {
            if (this.comboBox1.Text.Equals("Küche"))
            {
                Setze_Statische_Parameter_Fuer_Raum(neuerRaumMitRand);

                /* Berechne die benötigte Anzahl der Leuchten */
                this.tb_RoomCountLights.Text = Berechne_Leuchtdichte_Im_Raum(neuerRaumMitRand).ToString();
            }

            if (this.comboBox1.Text.Equals("Arbeitszimmer"))
            {
                Setze_Statische_Parameter_Fuer_Raum(neuerRaumMitRand);

                /* Berechne die benötigte Anzahl der Leuchten */
                this.tb_RoomCountLights.Text = Berechne_Leuchtdichte_Im_Raum(neuerRaumMitRand).ToString();
            }
        }

        /******************* bisher nicht benötigte Methoden **************************/

        //private void BerechneRaumTiefeFuesTageslicht_Version2()
        //{
        //    if (Storage.Fenster_Laenge_Nord != 0)
        //    {
        //        Berechne_LichtTiefe_im_Raum(Storage.Fenster_Laenge_Nord);
        //    }
        //    if (Storage.Fenster_Laenge_Ost != 0)
        //    {
        //        Berechne_LichtTiefe_im_Raum(Storage.Fenster_Laenge_Ost);
        //    }
        //    if (Storage.Fenster_Laenge_Sued != 0)
        //    {
        //        Berechne_LichtTiefe_im_Raum(Storage.Fenster_Laenge_Sued);
        //    }
        //    if (Storage.Fenster_Laenge_West != 0)
        //    {
        //        Berechne_LichtTiefe_im_Raum(Storage.Fenster_Laenge_West);
        //    }

        //    return;
        //}

        //private void Berechne_Neue_Anzahl_ungenuegend_Tageslicht_LangeSeite()
        //{
        //    /* Berechne Anzahl notwendiger Lichter für Raum */

        //    //1. Berechne neues "Rechteck" für Lichtberechnung
        //    int newRoomLength = Convert.ToInt32(this.tb_RoomLength.Text) - 4;

        //    /* Rechne Lumen/m² in Lux um */
        //    double raumgroesseInm2 = Convert.ToDouble(this.tb_RoomLength.Text) * newRoomLength;

        //    /* Ertelle 2 temp Variablen, um die nachfolgende Berechnung vereinfacht darzustellen */
        //    double tempRoomLength = Convert.ToDouble(this.tb_RoomWidth.Text);
        //    double tempRoomWidth = newRoomLength;

        //    double raumgroesseInm2MitRand = raumgroesseInm2 - (tempRoomLength * 0.3) + (tempRoomWidth * 0.3); // 0.3m Abstand zu allen Rändern


        //    //2. Berechne Anzahl Lichter
        //    Berechne_Parameter_Neuer_Raum(raumgroesseInm2MitRand);

        //    return;
        //}

        private void Berechne_Parameter_Fuer_Ausgabe(string lampentyp, int gewünschteLichtmengeImRaum, double reflexionOberflächen, int leuchtvermögenProLeuchte, int leistungProLeuchte_Glühlampe)
        {
            Calculation myCalc = new Calculation();

            /* Berechne die Leuchtdichte im Raum */
            //double raumgroesseInm2MitRand = Berechne_Leuchtdichte_Im_Raum(reflexionOberflächen, gewünschteLichtmengeImRaum);

            int leuchtdichte = myCalc.LeuchtdichteBerechnen(reflexionOberflächen, gewünschteLichtmengeImRaum);

            /* Rechne Lumen/m² in Lux um */
            double raumgroesseInm2MitRand = Convert.ToDouble(this.tb_RoomLength.Text) * Convert.ToInt32(this.tb_RoomWidth.Text);


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

            /* Berechne die benötigte Anzahl der Leuchten */
            this.tb_RoomCountLights.Text = lux.ToString();

            /* Berechne die Lichtausbeute für die verwendeten Lampentypen */
            this.tb_RoomCountPower.Text = myCalc.LeistungAllerLeuchtenBerechnen(leistungProLeuchte_Glühlampe, lux).ToString();

            /* Setze die "gewünschte Lichtmenge" in der UI */
            this.tb_RoomLux.Text = leuchtvermögenProLeuchte.ToString();

            return;
        }
        //public void BerechneErstesFensterNord()
        //{
        //    Calculation myCalc = new Calculation();

        //    /* Berechne Raumgroesse gesamt */
        //    double raumgroessegesamt = Berechne_Leuchtdichte_Im_Raum(myCalc, 0.6, Storage.Raum_Küche_Lichtmenge); //Licht in Küche berechnen

        //    /* Berechne Fenstereinfall */ /* Annahme: Längsseite, Nordfenster */
        //    int lux_Nord = 10000; // E(h) außen
        //    int locallength = Convert.ToInt32(this.tb_RoomLength.Text);
        //    /* berechne Tiefe Einfluss Sonnenlicht */
        //    int neueRaumLaenge = 0;
        //    double raumgroesseInm2 = 0;
        //    int tempLocalWidth = locallength;
        //    while (locallength > 0)
        //    {
        //        if (locallength == tempLocalWidth)
        //        {
        //            /* Direkt am Fenster */
        //            int E_innen_1Meter = Convert.ToInt32((lux_Nord * 11.0) / 100);
        //        }
        //        if ((locallength + 1) == tempLocalWidth)
        //        {
        //            /* Nach 1 Meter */
        //            int E_innen_1Meter = Convert.ToInt32((lux_Nord * 6.5) / 100);
        //        }
        //        if ((locallength + 2) == tempLocalWidth)
        //        {
        //            /* Nach 2 Meter */
        //            int E_innen_2Meter = Convert.ToInt32((lux_Nord * 3.9) / 100);
        //        }
        //        if ((locallength + 3) == tempLocalWidth)
        //        {
        //            /* Nach 3 Meter */
        //            int E_innen_1Meter = Convert.ToInt32((lux_Nord * 2.7) / 100);
        //        }
        //        if ((locallength + 4) == tempLocalWidth)
        //        {
        //            /* Nach 4 Meter */
        //            int E_innen_4Meter = Convert.ToInt32((lux_Nord * 2.0) / 100);
        //        }
        //        if ((locallength + 5) == tempLocalWidth)
        //        {
        //            /* Nach 5 Meter */ /* Tageslicht reicht unter 2% nicht aus */
        //            int E_innen_5Meter = Convert.ToInt32((lux_Nord * 1.8) / 100);
        //            /* Berechne neue Raumgroesse */
        //            neueRaumLaenge = Convert.ToInt32(this.tb_RoomLength.Text);
        //            raumgroesseInm2 = Convert.ToDouble(this.tb_RoomLength.Text) * neueRaumLaenge;
        //        }
        //        if ((locallength + 6) == tempLocalWidth)
        //        {
        //            /* Nach 6 Meter */
        //            int E_innen_6Meter = Convert.ToInt32((lux_Nord * 1.3) / 100);
        //            /* Berechne neue Raumgroesse */
        //            neueRaumLaenge = Convert.ToInt32(this.tb_RoomLength.Text);
        //            raumgroesseInm2 -= Convert.ToDouble(this.tb_RoomLength.Text) * neueRaumLaenge;
        //        }
        //        locallength -= 1;
        //    }



        //    /* Berechne Leuchtdichte in restlichen Raum */
        //    Berechne_Leuchtdichte_Im_Raum(neueRaumLaenge);
        //    double tempRoomLength = Convert.ToDouble(this.tb_RoomWidth.Text);
        //    double tempRoomWidth = neueRaumLaenge;
        //    double raumgroesseInm2MitRand = raumgroesseInm2 - (tempRoomLength) + (tempRoomWidth); // ohne 0.3m Abstand zu allen Rändern, da wohl im Innenraum

        //    /* Berechne notwendige Leuchten */
        //    Berechne_Parameter_Neuer_Raum(raumgroesseInm2MitRand);

        //    /* Berechne Lichtausbeute für verwendete Lampentypen */
        //    this.tb_RoomCountPower.Text = myCalc.LeistungAllerLeuchtenBerechnen(Storage.Leuchtmittel_Watt, Storage.Leuchtmittel_Nutzlichtstrom).ToString();

        //    /* Setze gewünschte Lichtmenge in UI */
        //    this.tb_RoomLux.Text = Storage.Leuchtmittel_Nutzlichtstrom.ToString();

        //    return;
        //}

        //private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        //{
        //    /**/
        //}


        /************** Berechne Helligkeit zwischen 2 Fenstern N und S *******************/

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

            double hoeheFensterNord = Storage.Fenster_Laenge_Nord; // 2.0;
            double hoeheFensterSued = Storage.Fenster_Laenge_Sued; // 2.0;
            double hoeheFensterWest = Storage.Fenster_Laenge_West; // 2.0;
            double hoeheFensterOst = Storage.Fenster_Laenge_Ost;  // 2.0;

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

                //if (neuelaengeRaum != 0)
                //{
                //    neuerRaum = (laengeRaum - neuelaengeRaum) * breiteRaum;
                //}
                //if (neuebreiteRaum != 0)
                //{
                //    neuerRaum = laengeRaum * (breiteRaum - neuebreiteRaum);
                //}
                if ((neuebreiteRaum != 0) && (neuelaengeRaum != 0))
                {
                    /* bei "Überlappung" soll 0 verwendet werden */
                    neuerRaum = (laengeRaum - neuelaengeRaum) * (breiteRaum - neuebreiteRaum);
                }

            }
            else if (Storage.FensterSeiteNorden.Equals("Breitseite"))
            {
                /* Verwende Längsseite des Raumes */
                neuebreiteRaum += raumtiefeNord;
                neuebreiteRaum += raumtiefeSued;
                neuelaengeRaum += raumtiefeWest;
                neuelaengeRaum += raumtiefeOst;

                //if (neuelaengeRaum != 0)
                //{
                //    neuerRaum = (laengeRaum - neuelaengeRaum) * breiteRaum;
                //}
                //if (neuebreiteRaum != 0)
                //{
                //    neuerRaum = laengeRaum * (breiteRaum - neuebreiteRaum);
                //}
                if ((neuebreiteRaum != 0) && (neuelaengeRaum != 0))
                {
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

            /* Berechne Leuchten und Leistung, Ausgabe auf UI */
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
