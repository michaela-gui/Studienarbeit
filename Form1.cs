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
            /* Default: Glühlampen verwenden, 12lm/W, Ra 90, 500lx, 0.6 Reflex., 800lm Leuchte, 60W, Lichtfarbe 827 (weiß) */
            if(this.comboBox1.Text.Equals("Küche"))
            {
                /* Setze static Parameter */
                string lampentyp = "Glühlampe";
                int gewüschteLichtmengeImRaum = 500; //lx
                double reflexionOberflächen = 0.6;
                int leuchtvermögenProLeuchte = 800; //lm
                int leistungProLeuchte_Glühlampe = 60; //W

                /* Berechne die Leuchtdichte im Raum */
                int leuchtdichte = myCalc.LeuchtdichteBerechnen(reflexionOberflächen, gewüschteLichtmengeImRaum);

                /* Rechne Lumen/m² in Lux um */
                double raumgroesseInm2 = Convert.ToDouble(this.tb_RoomLength.Text) * Convert.ToInt32(this.tb_RoomWidth.Text);

                /* Ertelle 2 temp Variablen, um die nachfolgende Berechnung vereinfacht darzustellen */
                double tempRoomLength = Convert.ToDouble(this.tb_RoomLength.Text); 
                double tempRoomWidth = Convert.ToDouble(this.tb_RoomWidth.Text);

                double raumgroesseInm2MitRand = raumgroesseInm2 - (tempRoomLength * 0.3) + (tempRoomWidth * 0.3); // 0.3m Abstand zu allen Rändern
                int lux = leuchtvermögenProLeuchte / Convert.ToInt32(raumgroesseInm2MitRand);

                /* Berechne die benötigte Anzahl der Leuchten */
                int anzahlLeuchten = myCalc.AnzahlLeuchtenBerechnen(lampentyp, gewüschteLichtmengeImRaum, lux);
                this.tb_RoomCountLights.Text = anzahlLeuchten.ToString();

                /* Berechne die Lichtausbeute für die verwendeten Lampentypen */
                this.tb_RoomCountPower.Text = myCalc.LeistungAllerLeuchtenBerechnen(leistungProLeuchte_Glühlampe, anzahlLeuchten).ToString();

                /* Setze die "gewünschte Lichtmenge" in der UI */
                this.tb_RoomLux.Text = leuchtvermögenProLeuchte.ToString();
            }

            /* Default: Glühlampen verwenden, 12lm/W, Ra 80, 500lx, 0.6 Reflex., 800lm Leuchte, 60W, Lichtfarbe 827 (weiß) */
            if (this.comboBox1.Text.Equals("Arbeitszimmer"))
            {
                /* Setze static Parameter */
                string lampentyp = "Glühlampe";
                int gewüschteLichtmengeImRaum = 500; //lx
                double reflexionOberflächen = 0.6;
                int leuchtvermögenProLeuchte = 800; //lm
                int leistungProLeuchte_Glühlampe = 60; //W

                /* Berechne die Leuchtdichte im Raum */
                int leuchtdichte = myCalc.LeuchtdichteBerechnen(reflexionOberflächen, gewüschteLichtmengeImRaum);

                /* Rechne Lumen/m² in Lux um */
                double raumgroesseInm2 = Convert.ToDouble(this.tb_RoomLength.Text) * Convert.ToInt32(this.tb_RoomWidth.Text);

                /* Ertelle 2 temp Variablen, um die nachfolgende Berechnung vereinfacht darzustellen */
                double tempRoomLength = Convert.ToDouble(this.tb_RoomLength.Text);
                double tempRoomWidth = Convert.ToDouble(this.tb_RoomWidth.Text);

                double raumgroesseInm2MitRand = raumgroesseInm2 - (tempRoomLength * 0.3) + (tempRoomWidth * 0.3); // 0.3m Abstand zu allen Rändern
                int lux = leuchtvermögenProLeuchte / Convert.ToInt32(raumgroesseInm2MitRand);

                /* Berechne die benötigte Anzahl der Leuchten */
                int anzahlLeuchten = myCalc.AnzahlLeuchtenBerechnen(lampentyp, gewüschteLichtmengeImRaum, lux);
                this.tb_RoomCountLights.Text = anzahlLeuchten.ToString();

                /* Berechne die Lichtausbeute für die verwendeten Lampentypen */
                this.tb_RoomCountPower.Text = myCalc.LeistungAllerLeuchtenBerechnen(leistungProLeuchte_Glühlampe, anzahlLeuchten).ToString();

                /* Setze die "gewünschte Lichtmenge" in der UI */
                this.tb_RoomLux.Text = leuchtvermögenProLeuchte.ToString();
            }
        }
    }
}
