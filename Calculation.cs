using System;
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
        public int LeuchtdichteBerechnen(double Reflexionswert, int Beleuchtungsstärke)
        {
            /* Berechne die mittlere Leuchtdichte im Bereich */
            int leuchtdichte = Convert.ToInt32((Reflexionswert * Beleuchtungsstärke) / Math.PI);

            return leuchtdichte;
        }

        public int LeistungAllerLeuchtenBerechnen(int Lampenleistung, int AnzahlLeuchten)
        {
            /* Berechne die Leistung in Watt aller verwendeten Leuchten vom selben Leuchtentyp */
            int leistungInWatt = AnzahlLeuchten * Lampenleistung;

            return leistungInWatt;
        }
    }

    class Storage
    {
        /* Global verwendete Parameter speichern */
        public Storage()
        {
            /* Konstruktor */
        }

        public static string Leuchtmittel_Typ = "";
        public static int Leuchtmittel_Farbwiedergabe = 0; // in Ra
        public static int Leuchtmittel_Watt = 0; // in Watt
        public static int Leuchtmittel_Nutzlichtstrom = 0; // in Lumen
        public static int Leuchtmittel_Abstrahlwinkel = 0; // in Grad

        public static int Raum_Küche_Lichtmenge = 300; // in Lux
        public static int Raum_Arbeitsplatz_Lichtmenge = 500; // in Lux
        public static int Raum_Arbeitsplatz_direktesLichtmenge = 300; // in Lux
        public static int Raum_Arbeitsplatz_weiteresUmfeld_Lichtmenge = 150; // in Lux

        public static int Fenster_Anzahl_Nord = 0;
        public static int Fenster_Anzahl_Ost = 0;
        public static int Fenster_Anzahl_Sued = 0;
        public static int Fenster_Anzahl_West = 0;
        public static double Fenster_Breite_Nord = 0;
        public static double Fenster_Laenge_Nord = 0;
        public static double Fenster_Breite_Ost = 0;
        public static double Fenster_Laenge_Ost = 0;
        public static double Fenster_Breite_Sued = 0;
        public static double Fenster_Laenge_Sued = 0;
        public static double Fenster_Breite_West = 0;
        public static double Fenster_Laenge_West = 0;

        public static string FensterSeiteNorden = "";

        public static double NeuerDunklerRaum = 0;
    }
}
