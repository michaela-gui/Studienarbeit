﻿using System;
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

        private void btn_WaehleLeuchten_Click(object sender, EventArgs e)
        {
            Form mySubForm = new LampenWahl();
            mySubForm.ShowDialog();
        }
        
        private double Berechne_Leuchtdichte_Im_Raum(Calculation myCalc, double reflexionOberflächen, int gewünschteLichtmengeImRaum)
        {
            int leuchtdichte = myCalc.LeuchtdichteBerechnen(reflexionOberflächen, gewünschteLichtmengeImRaum);

            /* Rechne Lumen/m² in Lux um */
            double raumgroesseInm2 = Convert.ToDouble(this.tb_RoomLength.Text) * Convert.ToInt32(this.tb_RoomWidth.Text);

            /* Ertelle 2 temp Variablen, um die nachfolgende Berechnung vereinfacht darzustellen */
            double tempRoomLength = Convert.ToDouble(this.tb_RoomLength.Text);
            double tempRoomWidth = Convert.ToDouble(this.tb_RoomWidth.Text);

            double raumgroesseInm2MitRand = raumgroesseInm2 - (tempRoomLength * 0.3) + (tempRoomWidth * 0.3); // 0.3m Abstand zu allen Rändern

            return raumgroesseInm2MitRand;
        }

        private void Berechne_Parameter_Fuer_Ausgabe(string lampentyp, int gewünschteLichtmengeImRaum, double reflexionOberflächen, int leuchtvermögenProLeuchte, int leistungProLeuchte_Glühlampe)
        {
            Calculation myCalc = new Calculation();

            /* Berechne die Leuchtdichte im Raum */
            double raumgroesseInm2MitRand = Berechne_Leuchtdichte_Im_Raum(myCalc, reflexionOberflächen, gewünschteLichtmengeImRaum);

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

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            /**/
        }

        private void Berechne_Parameter_Nach_Statischen_Angaben()
        {
            /* Default: Glühlampen verwenden, 12lm/W, Ra 90, 500lx, 0.6 Reflex., 800lm Leuchte, 60W, Lichtfarbe 827 (weiß) */
            if (this.comboBox1.Text.Equals("Küche"))
            {
                /* Setze static Parameter */
                string lampentyp = Storage.Leuchtmittel_Typ;
                int gewünschteLichtmengeImRaum = Storage.Raum_Arbeitsplatz_Lichtmenge; //lx
                double reflexionOberflächen = 0.6;
                int leuchtvermögenProLeuchte = Storage.Leuchtmittel_Nutzlichtstrom; //lm
                int leistungProLeuchte_Glühlampe = Storage.Leuchtmittel_Watt; //W

                Calculation myCalc = new Calculation();

                /* Berechne die Leuchtdichte im Raum */
                double raumgroesseInm2MitRand = Berechne_Leuchtdichte_Im_Raum(myCalc, reflexionOberflächen, gewünschteLichtmengeImRaum);

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

                Calculation myCalc = new Calculation();

                /* Berechne die Leuchtdichte im Raum */
                double raumgroesseInm2MitRand = Berechne_Leuchtdichte_Im_Raum(myCalc, reflexionOberflächen, gewünschteLichtmengeImRaum);

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
            }
        }

        private void btn_Calc_Click(object sender, EventArgs e)
        {
            Berechne_Parameter_Nach_Statischen_Angaben();

            return;
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            this.AutoScroll = true;
        }

        private void groupBox3_Enter(object sender, EventArgs e)
        {

        }

        private void Berechne_Fenster()
        {
            /* Berechne die Nord-Seite */
            if(this.tb_WindowLengthNorth.Text.Length != 0)
            {
                /* Feste Annahme: Nordseite durchschnittlich 20.000 Lux */
                int lux_Nord = 20000; // E(h) außen

                if(this.comboBox2.Text == "Längsseite")
                {
                    /* Maße der Längsseite verwenden */
                    int localLength = Convert.ToInt32(this.tb_RoomLength.Text);
                    int tempLocalLength = localLength;
                    while (localLength > 0)
                    {
                        if (localLength == tempLocalLength)
                        {
                            /* Direkt am Fenster */
                            int E_innen_1Meter = Convert.ToInt32((lux_Nord * 11.0) / 100);
                        }
                        if(localLength == tempLocalLength - 1)
                        {
                            /* Nach 1 Meter */
                            int E_innen_1Meter = Convert.ToInt32((lux_Nord * 6.5) / 100);
                        }
                        if (localLength == tempLocalLength - 2)
                        {
                            /* Nach 2 Meter */
                            int E_innen_2Meter = Convert.ToInt32((lux_Nord * 3.9) / 100);
                        }
                        if (localLength == tempLocalLength - 3)
                        {
                            /* Nach 3 Meter */
                            int E_innen_1Meter = Convert.ToInt32((lux_Nord * 2.7) / 100);
                        }
                        if (localLength == tempLocalLength - 4)
                        {
                            /* Nach 4 Meter */
                            int E_innen_4Meter = Convert.ToInt32((lux_Nord * 2.0) / 100);
                        }
                        if (localLength == tempLocalLength - 5)
                        {
                            /* Nach 5 Meter */
                            int E_innen_5Meter = Convert.ToInt32((lux_Nord * 1.8) / 100);
                            /* Berechne Anzahl notwendiger Lichter für Raum */

                            //1. Berechne neues "Rechteck" für Lichtberechnung
                            int newRoomLength = Convert.ToInt32(this.tb_RoomLength.Text) - 4;

                            /* Rechne Lumen/m² in Lux um */
                            double raumgroesseInm2 = Convert.ToDouble(this.tb_RoomLength.Text) * newRoomLength;

                            /* Ertelle 2 temp Variablen, um die nachfolgende Berechnung vereinfacht darzustellen */
                            double tempRoomLength = Convert.ToDouble(this.tb_RoomWidth.Text);
                            double tempRoomWidth = newRoomLength;

                            double raumgroesseInm2MitRand = raumgroesseInm2 - (tempRoomLength * 0.3) + (tempRoomWidth * 0.3); // 0.3m Abstand zu allen Rändern


                            //2. Berechne Anzahl Lichter
                            Berechne_Parameter_Neuer_Raum(raumgroesseInm2MitRand);
                        }
                        if (localLength == tempLocalLength - 6)
                        {
                            /* Nach 6 Meter */
                            int E_innen_6Meter = Convert.ToInt32((lux_Nord * 1.3) / 100);
                            /* Berechne Anzahl notwendiger Lichter für Raum */

                            //1. Berechne neues "Rechteck" für Lichtberechnung
                            int newRoomLength = Convert.ToInt32(this.tb_RoomLength.Text) - 4;

                            /* Rechne Lumen/m² in Lux um */
                            double raumgroesseInm2 = Convert.ToDouble(this.tb_RoomLength.Text) * newRoomLength;

                            /* Ertelle 2 temp Variablen, um die nachfolgende Berechnung vereinfacht darzustellen */
                            double tempRoomLength = Convert.ToDouble(this.tb_RoomWidth.Text);
                            double tempRoomWidth = newRoomLength;

                            double raumgroesseInm2MitRand = raumgroesseInm2 - (tempRoomLength * 0.3) + (tempRoomWidth * 0.3); // 0.3m Abstand zu allen Rändern


                            //2. Berechne Anzahl Lichter
                            Berechne_Parameter_Neuer_Raum(raumgroesseInm2MitRand);
                        }
                        localLength -= 1;
                    }

                }
                if (this.comboBox2.Text == "Breitseite")
                {
                    /* Maße der Breitseite verwenden */
                    int localWidth = Convert.ToInt32(this.tb_RoomWidth.Text);
                    int tempLocalWidth = localWidth;
                    while (localWidth > 0)
                    {
                        if (localWidth == tempLocalWidth)
                        {
                            /* Direkt am Fenster */
                            int E_innen_1Meter = Convert.ToInt32((lux_Nord * 11.0) / 100);
                        }
                        if ((localWidth + 1) == tempLocalWidth)
                        {
                            /* Nach 1 Meter */
                            int E_innen_1Meter = Convert.ToInt32((lux_Nord * 6.5) / 100);
                        }
                        if ((localWidth + 2) == tempLocalWidth)
                        {
                            /* Nach 2 Meter */
                            int E_innen_2Meter = Convert.ToInt32((lux_Nord * 3.9) / 100);
                        }
                        if ((localWidth + 3) == tempLocalWidth)
                        {
                            /* Nach 3 Meter */
                            int E_innen_1Meter = Convert.ToInt32((lux_Nord * 2.7) / 100);
                        }
                        if ((localWidth + 4) == tempLocalWidth)
                        {
                            /* Nach 4 Meter */
                            int E_innen_4Meter = Convert.ToInt32((lux_Nord * 2.0) / 100);
                        }
                        if ((localWidth + 5 )== tempLocalWidth)
                        {
                            /* Nach 5 Meter */ /* Tageslicht reicht unter 2% nicht aus */
                            int E_innen_5Meter = Convert.ToInt32((lux_Nord * 1.8) / 100);
                            /* Berechne Anzahl notwendiger Lichter für Raum */
                            
                            //1. Berechne neues "Rechteck" für Lichtberechnung
                            int newRoomWidth = Convert.ToInt32(this.tb_RoomWidth.Text) - 4;
                            
                            /* Rechne Lumen/m² in Lux um */
                            double raumgroesseInm2 = Convert.ToDouble(this.tb_RoomLength.Text) * newRoomWidth;

                            /* Ertelle 2 temp Variablen, um die nachfolgende Berechnung vereinfacht darzustellen */
                            double tempRoomLength = Convert.ToDouble(this.tb_RoomLength.Text);
                            double tempRoomWidth = newRoomWidth;

                            double raumgroesseInm2MitRand = raumgroesseInm2 - (tempRoomLength * 0.3) + (tempRoomWidth * 0.3); // 0.3m Abstand zu allen Rändern


                            //2. Berechne Anzahl Lichter
                            Berechne_Parameter_Neuer_Raum(raumgroesseInm2MitRand);
                        }
                        if ((localWidth + 6) == tempLocalWidth)
                        {
                            /* Nach 6 Meter */
                            int E_innen_6Meter = Convert.ToInt32((lux_Nord * 1.3) / 100);

                            /* Berechne Anzahl notwendiger Lichter für Raum */

                            //1. Berechne neues "Rechteck" für Lichtberechnung
                            int newRoomWidth = Convert.ToInt32(this.tb_RoomWidth.Text) - 4;

                            /* Rechne Lumen/m² in Lux um */
                            double raumgroesseInm2 = Convert.ToDouble(this.tb_RoomLength.Text) * newRoomWidth;

                            /* Ertelle 2 temp Variablen, um die nachfolgende Berechnung vereinfacht darzustellen */
                            double tempRoomLength = Convert.ToDouble(this.tb_RoomLength.Text);
                            double tempRoomWidth = newRoomWidth;

                            double raumgroesseInm2MitRand = raumgroesseInm2 - (tempRoomLength * 0.3) + (tempRoomWidth * 0.3); // 0.3m Abstand zu allen Rändern


                            //2. Berechne Anzahl Lichter
                            Berechne_Parameter_Neuer_Raum(raumgroesseInm2MitRand);
                        }
                        localWidth -= 1;
                    }

                    
                }
            } /* Ende "Nord-Seite" */

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

        private void Berechne_Lichtausbeute_Verwendete_Lampen(int leistungProLeuchte_Glühlampe, double neuerRaumMitRand)
        {
            /* Berechne die Lichtausbeute für die verwendeten Lampentypen */
            Calculation myCalc = new Calculation();
            this.tb_RoomCountPower.Text = myCalc.LeistungAllerLeuchtenBerechnen(leistungProLeuchte_Glühlampe, Berechne_Leuchtdichte_Im_Raum(neuerRaumMitRand)).ToString();

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

        private void btn_BerechneMitTageslicht_Click(object sender, EventArgs e)
        {
            /* Lampen bei Tageslicht berechnen */
            if(this.tb_WindowHeightFromFloorNorth.Text.Length == 0)
            {
                this.tb_WindowHeightFromFloorNorth.Text = "Bitte ausfüllen!";
                return;
            }

            /* Berechne Tageslicht-Quotient des Raumes */
            Berechne_Fenster();

            //BerechneRaumTiefeFuerTageslicht();

            return;
        }

        private double Berechne_LichtTiefe_im_Raum(TextBox WindowHeightFromFloor)
        {
            /* Berechne die maximale Höhe des Fensters */
            double windowHeight = Convert.ToDouble(WindowHeightFromFloor.Text);
            double workingHeight = Convert.ToDouble(this.tb_WindowLengthNorth.Text);
            double maxFensterHoehe = windowHeight + workingHeight;
            /* Berechne die Tiefe im Raum über 2 Winkel (30° Sonneneinfall, 90° Boden) und 1 Seite (maxFensterHoehe) */
            double tiefeRaum = maxFensterHoehe / 2.0;

            return tiefeRaum;
        }

        private void BerechneRaumTiefeFuerTageslicht()
        {
            /* Für die Nordseite */
            if ((this.comboBox2.Text == "Längsseite") || (this.comboBox2.Text == "Breitseite"))
            {
                Berechne_LichtTiefe_im_Raum(this.tb_WindowHeightFromFloorNorth);
            }

            /* Für die Ostseite */
            if ((this.comboBox3.Text == "Längsseite") || (this.comboBox3.Text == "Breitseite"))
            {
                Berechne_LichtTiefe_im_Raum(this.tb_WindowHeightFromFloorNorth);
            }

            /* Für die Südseite */
            if ((this.comboBox4.Text == "Längsseite") || (this.comboBox4.Text == "Breitseite"))
            {
                Berechne_LichtTiefe_im_Raum(this.tb_WindowHeightFromFloorNorth);
            }            
            
            /* Für die Westseite */
            if ((this.comboBox5.Text == "Längsseite") || (this.comboBox5.Text == "Breitseite"))
            {
                Berechne_LichtTiefe_im_Raum(this.tb_WindowHeightFromFloorNorth);
            }
        }
    }
}
