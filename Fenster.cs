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
    public partial class Fenster : Form
    {
        public Fenster()
        {
            InitializeComponent();
            this.textBox1.Text = Storage.Fenster_Anzahl_Nord.ToString();
            this.textBox2.Text = Storage.Fenster_Anzahl_Ost.ToString();
            this.textBox3.Text = Storage.Fenster_Anzahl_Sued.ToString();
            this.textBox4.Text = Storage.Fenster_Anzahl_West.ToString();
            
            this.textBox5.Text = Storage.Fenster_Breite_Nord.ToString();
            this.textBox6.Text = Storage.Fenster_Breite_Ost.ToString();
            this.textBox7.Text = Storage.Fenster_Breite_Sued.ToString();
            this.textBox8.Text = Storage.Fenster_Breite_West.ToString();
            
            this.textBox9.Text = Storage.Fenster_Laenge_Nord.ToString();
            this.textBox10.Text = Storage.Fenster_Laenge_Ost.ToString();
            this.textBox11.Text = Storage.Fenster_Laenge_Sued.ToString();
            this.textBox12.Text = Storage.Fenster_Laenge_West.ToString();
        }

        private void btn_Übernehmen_Click(object sender, EventArgs e)
        {
            /* Speichere die Eingaben in Storage */
            Storage.Fenster_Anzahl_Nord = Convert.ToInt32(this.textBox1.Text);
            Storage.Fenster_Anzahl_Ost  = Convert.ToInt32(this.textBox2.Text);
            Storage.Fenster_Anzahl_Sued = Convert.ToInt32(this.textBox3.Text);
            Storage.Fenster_Anzahl_West = Convert.ToInt32(this.textBox4.Text);

            Storage.Fenster_Breite_Nord = Convert.ToDouble(this.textBox5.Text);
            Storage.Fenster_Breite_Ost  = Convert.ToDouble(this.textBox6.Text);
            Storage.Fenster_Breite_Sued = Convert.ToDouble(this.textBox7.Text);
            Storage.Fenster_Breite_West = Convert.ToDouble(this.textBox8.Text);

            Storage.Fenster_Laenge_Nord = Convert.ToDouble(this.textBox9.Text);
            Storage.Fenster_Laenge_Ost  = Convert.ToDouble(this.textBox10.Text);
            Storage.Fenster_Laenge_Sued = Convert.ToDouble(this.textBox11.Text);
            Storage.Fenster_Laenge_West = Convert.ToDouble(this.textBox12.Text);

            Storage.FensterSeiteNorden = this.comboBox2.Text;

            this.Close();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
