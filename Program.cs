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
            myCalc.Infeldleuchtdichte();
            myCalc.Wandflächenleuchtdichte();
            myCalc.Fussbodenflächenleuchtdichte();
            myCalc.Fensterflächenleuchtdichte();
            myCalc.LichtsystemeBeleuchtungsstärke();

            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(new Form1());
        }
    }
}
