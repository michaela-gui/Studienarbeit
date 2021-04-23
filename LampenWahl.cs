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
    public partial class LampenWahl : Form
    {
        public LampenWahl()
        {
            InitializeComponent();
        }

        private void cb_Waehle_Leuchte_SelectedIndexChanged(object sender, EventArgs e)
        {
            if(comboBox1.Text == "Glühlampe E27")
            {
                /* Zeige Parameter auf Gui2 */
                this.richTextBox1.Text = "Glühlampe Tropfen E27";
                this.richTextBox2.Text = "2.300 Kelvin";
                this.richTextBox3.Text = "extra warm weiß";
                this.richTextBox4.Text = "8 Watt";
                this.richTextBox5.Text = "Ja";
                this.richTextBox6.Text = "100 Ra";
                this.richTextBox7.Text = "Paulmann Licht GmbH";
                this.richTextBox8.Text = "40 Lumen";
                this.richTextBox9.Text = "https://de.paulmann.com/";
                this.richTextBox10.Text = "128.08";

                this.pictureBox1.Image = Image.FromFile("..\\..\\Bilder\\KeinBildVorhanden.png");
                this.pictureBox2.Image = Image.FromFile("..\\..\\Bilder\\Gluehlampe_Paulmann_E27.jpg");
            }

            if (comboBox1.Text == "LED Einbaustrahler")
            {
                /* Zeige Parameter auf Gui2 */
                this.richTextBox1.Text = "LED Einbau-Deckenleuchte";
                this.richTextBox2.Text = "3.000 Kelvin";
                this.richTextBox3.Text = "weiß";
                this.richTextBox4.Text = "6 Watt";
                this.richTextBox5.Text = "Keine Angabe";
                this.richTextBox6.Text = "80 Ra";
                this.richTextBox7.Text = "Brumberg";
                this.richTextBox8.Text = "640 Lumen";
                this.richTextBox9.Text = "https://www.brumberg.com/";
                this.richTextBox10.Text = "38363023";

                this.pictureBox1.Image = Image.FromFile("..\\..\\Bilder\\Brumberg_Einbau-LED_Strahlweite.png");
                this.pictureBox2.Image = Image.FromFile("..\\..\\Bilder\\Einbau-LED_Brumberg_VG.jpg");
            }
        }

        private void btn_Uebernehmen_Click(object sender, EventArgs e)
        {
            /* Kopiere Parameter für Gui1 */
            if (comboBox1.Text == "Glühlampe E27")
            {
                Storage.Leuchtmittel_Typ = "Glühlampe";
                Storage.Leuchtmittel_Farbwiedergabe = 100;
                Storage.Leuchtmittel_Watt = 8;
                Storage.Leuchtmittel_Nutzlichtstrom = 40;
                Storage.Leuchtmittel_Abstrahlwinkel = 120;
            }

            if (comboBox1.Text == "LED Einbaustrahler")
            {
                Storage.Leuchtmittel_Typ = "LED";
                Storage.Leuchtmittel_Farbwiedergabe = 80;
                Storage.Leuchtmittel_Watt = 6;
                Storage.Leuchtmittel_Nutzlichtstrom = 640;
                Storage.Leuchtmittel_Abstrahlwinkel = 38;
            }
        }

        private void btn_Abbrechen_Click(object sender, EventArgs e)
        {
            /* Zurück zu Gui1 ohne Änderungen zu speichern */
            this.Close();
        }
    }
}
