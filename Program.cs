using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Studienarbeit
{
    static class Program
    {
        /// <summary>
        /// Der Haupteinstiegspunkt für die Anwendung.
        /// </summary>
        [STAThread]
        static void Main()
        {
            Calculation myCalc = new Calculation();
            int Beleuchtung_Nutzung_Allgemein_Raum_Lux = 300;
            int Beleuchtung_Nutzung_Allgemein_Arbeitsbereich_Lux = 550;
            int Beleuchtung_Nutzung_Küche_Arbeitsbereich_Lux = 500;
            double Reflexion_Allgemein_Schreibtisch = 0.8;
            double Relexion_Allgemein_Raum = 0.6;
            double Reflexion_Küche_Küchenplatte = 0.5; // ?

            myCalc.LeuchtdichteBerechnen(Relexion_Allgemein_Raum, Beleuchtung_Nutzung_Allgemein_Raum_Lux);
            myCalc.LeuchtdichteBerechnen(Reflexion_Küche_Küchenplatte, Beleuchtung_Nutzung_Küche_Arbeitsbereich_Lux);

            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(new Form1());
        }
    }
}
