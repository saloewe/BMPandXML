using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;

namespace WindowsFormsApp3
{
    public partial class Form1 : Form
    {
        int tamano;
        int ancho;
        int alto;
        int bits;
        int control1;
        int control2;
        string xml;
        public Form1()
        {
            InitializeComponent();
        }
        
        

        private void button1_Click_1(object sender, EventArgs e)
        {
            openFileDialog1.ShowDialog();
            BinaryReader br = new BinaryReader(File.Open(openFileDialog1.FileName, FileMode.Open));
            control1 = br.ReadByte();
            control2 = br.ReadByte();

            if (control1 == 66 && control2 == 77 || control1 == 77 && control2 == 66)
            {
                tamano = br.ReadInt32();
                br.ReadBytes(12);
                ancho = br.ReadInt32();
                alto = br.ReadInt32();
                br.ReadBytes(2);
                bits = br.ReadInt16();
                textBox1.Text = Convert.ToString(control1);
                textBox2.Text = Convert.ToString(control2);
                textBox3.Text = Convert.ToString(tamano);
                textBox4.Text = Convert.ToString(ancho);
                textBox5.Text = Convert.ToString(alto);
                textBox6.Text = Convert.ToString(bits);
            }
            else
            {
                textBox1.Text = "no es un archivo valido";
            }
            br.Close();
        }

        private void button2_Click_1(object sender, EventArgs e)
        {
            saveFileDialog1.ShowDialog();
            xml = "<boody> \n";
            xml += "<tamano>" + tamano + "</tamano> \n";
            xml += "<ancho>" + ancho + "</ancho> \n";
            xml += "<alto>" + alto + "</alto> \n";
            xml += "<bits>" + bits + "</bits> \n";
            xml += "</boody>";
            File.WriteAllText(saveFileDialog1.FileName, xml);

        }
    }
}
