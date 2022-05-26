using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Xml;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace XML
{
    public partial class Form1 : Form
    {
        OpenFileDialog openFileDialog1 = new OpenFileDialog();
        public Form1()
        {
            InitializeComponent();
        }
      
    

        private void button1_Click(object sender, EventArgs e)
        {

            XmlTextReader xmlTextReader = new XmlTextReader(@"C:\Users\DIEGO\source\repos\XML\XML\bin\Debug\doc\settings.xml");
            string ultimaEtiqueta = "";
            while (xmlTextReader.Read())
            {
                if (xmlTextReader.NodeType == XmlNodeType.Element)
                {
                    richTextBox1.Text += (new string(' ', xmlTextReader.Depth * 3) + "<" + xmlTextReader.Name + ">");
                    ultimaEtiqueta = xmlTextReader.Name;
                    continue;
                }
                if (xmlTextReader.NodeType == XmlNodeType.Text)
                {
                    richTextBox1.Text += xmlTextReader.ReadContentAsString() + "</" + ultimaEtiqueta + ">";
                }
                else

                    richTextBox1.Text += "\r";

            }
            //Se podría mejorar poniendo para seleccionar la ruta y no tener una especifica
        }
    }
}
