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

        private void button3_Click(object sender, EventArgs e)
        {
            Form mySubForm = new LampenWahl();
            mySubForm.ShowDialog();
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            Calculation myCalc = new Calculation();
            /* Default: Glühlampen verwenden, 12lm/W, Ra 90, 500lx, 0,6 Reflex., 800lm Leuchte, 60W */
            if(this.comboBox1.Text.Equals("Küche"))
            {
                /* Berechne die Leuchtdichte im Raum */
                int leuchtdichte = myCalc.LeuchtdichteBerechnen(0.6, 500);
                Console.WriteLine("Leuchtdichte + " + leuchtdichte);

                /* Rechne Lumen/m² in Lux um */
                int raumgroesseInm2 = Convert.ToInt32(this.tb_RoomLength.Text) * Convert.ToInt32(this.tb_RoomWidth.Text);
                int raumgroesseInm2MitRand = Convert.ToDouble(raumgroesseInm2) - (Convert.ToInt32(this.tb_RoomLength.Text) * 0.3 + Convert.ToInt32(this.tb_RoomWidth.Text) * 0, 3);
                int lux = 800 / raumgroesseInm2MitRand; /* NOTIZ: 250lm/W ergibt 312lx, ist zu wenig */
                Console.WriteLine(lux);

                /* Berechne die benötigte Anzahl der Leuchten */
                int anzahlLeuchten = myCalc.AnzahlLeuchtenBerechnen("Glühlampe", 500, lux);
                Console.WriteLine("anzahlLeuchten + " + anzahlLeuchten);
                this.tb_RoomCountLights.Text = anzahlLeuchten.ToString();
                /* Berechne die Lichtausbeute für die verwendeten Lampentypen */
                this.tb_RoomCountPower.Text = myCalc.LeistungAllerLeuchtenBerechnen("Glühlampe", anzahlLeuchten, 2500, 60, 500).ToString();
            }
        }
    }
}
