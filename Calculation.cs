﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Studienarbeit
{
    public class Calculation
    {
        public Calculation()
        {
            /* Konstruktor */
        }

        public void Infeldleuchtdichte()
        {
            /* Infeldbereich (primär und sekundär) berechnen */
            //double d_ReflexionsstärkeInProzent = 0.4; 
            int i_Infeldleuchtdichte = 100; /* vorgegebene Infeldleuchtdichte für Bürobeleuchtung nach Erfahrung und Empfehlungen, cd/m² */
            const double d_Pi = 3.14159; /* Pi */
            double d_ReflexionsgradInProzent = 0.4; /* mittlerer Reflexionsgrad des Arbeitsgutes außerhalb eines Bildschirmes */
            int i_ErgebnisNennbeleuchtungsstärke = Convert.ToInt32((i_Infeldleuchtdichte * d_Pi) /d_ReflexionsgradInProzent);

            Console.WriteLine(i_ErgebnisNennbeleuchtungsstärke);

            /* Allgmeinbeleuchtung vorausgesetzt, Reflexionsgrad zwischen 0,4 und 0,85, Infeldleuchtdichtebereich berechnen */
            int i_ErgebnisInfeldleuchtdichte = Convert.ToInt32((i_ErgebnisNennbeleuchtungsstärke * d_ReflexionsgradInProzent) / d_Pi);

            Console.WriteLine(i_ErgebnisInfeldleuchtdichte);

            return;
        }

        public void Umfeldleuchtdichte()
        {
            /* Umgebungsfeldleuchtdichte aus Infeldleuchtdichte ermitteln */
            int i_Umfeldleuchtdichte = 30; //bis 70 cd/m²

            return;
        }

        public void Wandflächenleuchtdichte()
        {
            /* Leuchtdichte der Wandflächen bestimmen */
            int i_HorizontaleBeleuchtungsstärke = 780; // in Lux
            int i_VertikaleBeleuchtungsstärke = Convert.ToInt32(i_HorizontaleBeleuchtungsstärke / 2); // in Lux
            double d_ReflexionsgradInProzent = 0.5; // oder 0.6 /* mittlerer Reflexionsgrad sichtbarer Wandflächen */
            const double d_Pi = 3.14159; /* Pi */

            Console.WriteLine(i_VertikaleBeleuchtungsstärke);

            /* Berechne Nennbeleuchtungsstärke in cd/m² */
            int i_ErgebnisNennbeleuchtungsstärke = Convert.ToInt32((i_VertikaleBeleuchtungsstärke * d_ReflexionsgradInProzent) / d_Pi);

            Console.WriteLine(i_ErgebnisNennbeleuchtungsstärke);

            return;
        }

        public void Fussbodenflächenleuchtdichte()
        {
            /* Leuchtdichte des Fussbodens berechnen */
            double d_ReflexionsgradInProzent; /* Reflexionsgrad des Bodens */
            // d_Pi = 3.14159; /* Pi */
            int i_Infeldleuchtdichte = 35; // bis 65, Leuchtdichtewert
            int i_HorizontaleBeleuchtungsstärke = 400; //in Lux, Niedrigwert

            d_ReflexionsgradInProzent = (Math.PI * i_Infeldleuchtdichte) / i_HorizontaleBeleuchtungsstärke;
            
            Console.WriteLine(d_ReflexionsgradInProzent);
            
            return;
        }

        public void Fensterflächenleuchtdichte()
        {
            /* Berechnen der Leuchtdichte eines Raumes mit Fensterflächen */
            int i_Infeldleuchtdichte = 100; /* vorgegebene Infeldleuchtdichte für Bürobeleuchtung nach Erfahrung und Empfehlungen, cd/m² */
            int i_AnnahmeAussenleuchtdichte = 6000; // in Lux , bis 8.000, ergibt TQ = 3,5% bei Innenbeleuchtungsstärke von 200-300lx, Leuchtdichtewerte bedeckter Himmel ca. 6000cd/m², entspr. Beleuchtungsstärke = 10.000 lx bis max. 12.000cd/m²

            Console.WriteLine(i_AnnahmeAussenleuchtdichte);

            return;
        }

        public void LichtsystemeBeleuchtungsstärke()
        {
            /* Mittlere Beleuchtungsstärke mit zusätzlichen Lampen */
            int i_AnzahlLeuchten = 18;
            int i_LichtstromProLeuchte = 3450;
            double d_Raumwirkungsgrad = 0.60;

            int i_MittlereBeleuchtungsstärke = Convert.ToInt32((i_AnzahlLeuchten * i_LichtstromProLeuchte * d_Raumwirkungsgrad) / 64); // 64 als Reflexionsgrad von Hellgelb?

            Console.WriteLine(i_MittlereBeleuchtungsstärke);

            return;
        }

        public int LeuchtdichteBerechnen(double Reflexionswert, int Beleuchtungsstärke)
        {
            /* Berechne die mittlere Leuchtdichte im Bereich */
            int leuchtdichte = Convert.ToInt32((Reflexionswert * Beleuchtungsstärke) / Math.PI);
            Console.WriteLine(leuchtdichte)
;
            return leuchtdichte;
        }

        public int AnzahlLeuchtenBerechnen(string Lampentyp, int Leuchtdichte, int Lampenhelligkeit)
        {
            /* Berechne die Anzahl der Leuchten nach Lampentyp und geforderter Leuchtdichte */
            int anzahlLeuchten = 0;

            /* 120° Ausstrahlwinkel der Lampe => 3,14m² beleuchten, einfacher Raum ohne Rand: */

            switch (Lampentyp)
            {
                case "Glühlampe":
                    anzahlLeuchten = Leuchtdichte / Lampenhelligkeit; /* Zahl ist Lumen, das eine Lampe erzeugen kann, herstellerabhängig. */
                    break;
                case "Halogenglühlampe":
                    anzahlLeuchten = Leuchtdichte / Lampenhelligkeit; /* Zahl ist Lumen, das eine Lampe erzeugen kann, herstellerabhängig. */
                    break;
                case "LED":
                    anzahlLeuchten = Leuchtdichte / Lampenhelligkeit; /* Zahl ist Lumen, das eine Lampe erzeugen kann, herstellerabhängig. */
                    break;
                case "Leuchtstofflampe":
                    anzahlLeuchten = Leuchtdichte / Lampenhelligkeit; /* Zahl ist Lumen, das eine Lampe erzeugen kann, herstellerabhängig. */
                    break;
            }
            return anzahlLeuchten;
        }

        public int LeistungAllerLeuchtenBerechnen(string Lampentyp, int Lampenanzahl, int Lampenhelligkeit, int Lampenleistung, int Leuchtdichte)
        {
            /* Berechne die Leistung in Watt aller verwendeten Leuchten vom selben Leuchtentyp */
            int leistungInWatt = AnzahlLeuchtenBerechnen(Lampentyp, Leuchtdichte, Lampenhelligkeit) * Lampenleistung;

            return leistungInWatt;
        }

        public int LichtausbeuteProLeuchtentypBerechnen(string Lampentyp, int Lampenanzahl, int Lampenhelligkeit, int Lampenleistung)
        {
            /* Berechne die Lichtausbeute einer Lampe nach Lampentyp in lm/W */
            int lichtausbeute = 0;

            switch (Lampentyp)
            {
                case "Glühlampe":
                   lichtausbeute = Lampenhelligkeit / Lampenleistung;
                    break;
                case "Halogenglühlampe":
                    lichtausbeute = Lampenhelligkeit / Lampenleistung;
                    break;
                case "LED":
                    lichtausbeute = Lampenhelligkeit / Lampenleistung;
                    break;
                case "Leuchtstofflampe":
                    lichtausbeute = Lampenhelligkeit / Lampenleistung;
                    break;
            }

            lichtausbeute *= Lampenanzahl;
                

            return lichtausbeute;
        }
    }
}
