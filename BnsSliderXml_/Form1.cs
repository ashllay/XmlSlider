using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Xml;
using System.Xml.Linq;

namespace BnsSliderXml_
{
    public partial class Form1 : Form
    {
        string Race, Sex;
        string sMin = "-1.00";
        string sMax = "1.00";

        XmlDocument document;
        XmlNode node;
        XmlElement element;
        string str2;
        FileStream stream;
        StreamReader reader;
        string str3;
        FileStream stream2;
        StreamWriter writer;
        
        public Form1()
        {
            InitializeComponent();
        }
        
        void txBoxSet()
        {
            //max
            TextBox[] MaxTarray = {
                txbPelvisWidMax, txbNekThicMax, txbNeckLenMax, txbShoulderHeiMax, txbShoulderWidMax,
                txbShoulderSizMax, txbArmThicMax, txbArmLenMax, txbHandSizMax, txbHandLenMax,
                txbFootSizMax, txbPelvisThickMax, txbBuildMax, txbHeigthMax, txbHeadSizMax,
                txbChestHeiMax, txbChestWidMax, txbChestSizMax, txbHeadWidMax, txbWaisThicMax,
                txbWaisLenMax, txbThigthWidMax, txbCalfWidMax, txbThighLenMax, txbCalfLenMax,
                txbTorsoSizMax
            };
            foreach (TextBox t in MaxTarray)
            {
                
                t.Text = sMax;
            }
            //min
            TextBox[] MinTarray = {
            txbPelvisWidMin ,txbNeckLenMin ,txbNekThicMin ,txbShoulderHeiMin ,txbShoulderWidMin ,
            txbShoulderSizMin ,txbArmThicMin ,txbArmLenMin ,txbHandSizMin ,txbHandLenMin ,
            txbFootSizMin ,txbPelvisThickMin ,txbBuildMin ,txbHeigthMin ,txbHeadSizMin ,
            txbChestHeiMin ,txbChestWidMin ,txbChestSizMin ,txbHeadWidMin ,txbWaisThicMin ,
            txbWaisLenMin ,txbThigthWidMin ,txbCalfWidMin ,txbThighLenMin ,txbCalfLenMin ,
            txbTorsoSizMin
            };

            foreach (TextBox t in MinTarray)
            {

                t.Text = sMin;
            }
        }

        private void LoadSliders(XElement xelem)
        {

        }
        private void Form1_Load(object sender, EventArgs e)
        {
            //txBoxSet();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            try
            {

                string xmlFile = File.ReadAllText(Environment.CurrentDirectory + @".\characterdefvaluedata.xml");
                xmlFile = xmlFile.Replace(
                    //max
                   " body-custom-max-1=\"1.00\"" + " body-custom-max-10=\"1.00\"" + " body-custom-max-11=\"1.00\"" + 
                   " body-custom-max-12=\"1.00\"" + " body-custom-max-13=\"1.00\"" + " body-custom-max-14=\"1.00\"" + 
                   " body-custom-max-15=\"1.00\"" +  " body-custom-max-16=\"1.00\"" + " body-custom-max-17=\"1.00\"" + 
                   " body-custom-max-18=\"1.00\"" + " body-custom-max-19=\"1.00\"" + " body-custom-max-2=\"1.00\"" + 
                   " body-custom-max-20=\"1.00\"" + " body-custom-max-21=\"1.00\"" + " body-custom-max-22=\"1.00\"" + 
                   " body-custom-max-23=\"1.00\"" +  " body-custom-max-24=\"1.00\"" + " body-custom-max-25=\"1.00\"" + 
                   " body-custom-max-26=\"1.00\"" + " body-custom-max-3=\"1.00\"" + " body-custom-max-4=\"1.00\"" + 
                   " body-custom-max-5=\"1.00\"" + " body-custom-max-6=\"1.00\"" + " body-custom-max-7=\"1.00\"" + 
                   " body-custom-max-8=\"1.00\"" +  " body-custom-max-9=\"1.00\"" + 
                   //min
                   " body-custom-min-1=\"-1.00\"" + " body-custom-min-10=\"-1.00\"" +
                   " body-custom-min-11=\"-1.00\"" + " body-custom-min-12=\"-1.00\"" + " body-custom-min-13=\"-1.00\"" +
                   " body-custom-min-14=\"-1.00\"" + " body-custom-min-15=\"-1.00\"" + " body-custom-min-16=\"-1.00\"" +
                   " body-custom-min-17=\"-1.00\"" + " body-custom-min-18=\"-1.00\"" + " body-custom-min-19=\"-1.00\"" +
                   " body-custom-min-2=\"-1.00\"" + " body-custom-min-20=\"-1.00\"" + " body-custom-min-21=\"-1.00\"" +
                   " body-custom-min-22=\"-1.00\"" + " body-custom-min-23=\"-1.00\"" + " body-custom-min-24=\"-1.00\"" +
                   " body-custom-min-25=\"-1.00\"" + " body-custom-min-26=\"-1.00\"" + " body-custom-min-3=\"-1.00\"" +
                   " body-custom-min-4=\"-1.00\"" + " body-custom-min-5=\"-1.00\"" + " body-custom-min-6=\"-1.00\"" +
                   " body-custom-min-7=\"-1.00\"" + " body-custom-min-8=\"-1.00\"" + " body-custom-min-9=\"-1.00\"" +
                   " race=\"" + Race + "\"" + " sex=\"" + Sex + "\"",
                   //max
                   " body-custom-max-1=\"" + txbPelvisWidMax.Text + "\"" +
                   " body-custom-max-10=\"" + txbNekThicMax.Text + "\"" +
                   " body-custom-max-11=\"" + txbNeckLenMax.Text + "\"" +
                   " body-custom-max-12=\"" + txbShoulderHeiMax.Text + "\"" +
                   " body-custom-max-13=\"" + txbShoulderWidMax.Text + "\"" +
                   " body-custom-max-14=\"" + txbShoulderSizMax.Text + "\"" +
                   " body-custom-max-15=\"" + txbArmThicMax.Text + "\"" +
                   " body-custom-max-16=\"" + txbArmLenMax.Text + "\"" +
                   " body-custom-max-17=\"" + txbHandSizMax.Text + "\"" +
                   " body-custom-max-18=\"" + txbHandLenMax.Text + "\"" +
                   " body-custom-max-19=\"" + txbFootSizMax.Text + "\"" +
                   " body-custom-max-2=\"" + txbPelvisThickMax.Text + "\"" +
                   " body-custom-max-20=\"" + txbBuildMax.Text + "\"" +
                   " body-custom-max-21=\"" + txbHeigthMax.Text + "\"" +
                   " body-custom-max-22=\"" + txbHeadSizMax.Text + "\"" +
                   " body-custom-max-23=\"" + txbChestHeiMax.Text + "\"" +
                   " body-custom-max-24=\"" + txbChestWidMax.Text + "\"" +
                   " body-custom-max-25=\"" + txbChestSizMax.Text + "\"" +
                   " body-custom-max-26=\"" + txbHeadWidMax.Text + "\"" +
                   " body-custom-max-3=\"" + txbWaisThicMax.Text + "\"" +
                   " body-custom-max-4=\"" + txbWaisLenMax.Text + "\"" +
                   " body-custom-max-5=\"" + txbThigthWidMax.Text + "\"" +
                   " body-custom-max-6=\"" + txbCalfWidMax.Text + "\"" +
                   " body-custom-max-7=\"" + txbThighLenMax.Text + "\"" +
                   " body-custom-max-8=\"" + txbCalfLenMax.Text + "\"" +
                   " body-custom-max-9=\"" + txbTorsoSizMax.Text + "\"" +
                   //min
                   " body-custom-min-1=\"" + txbPelvisWidMin.Text + "\"" +
                   " body-custom-min-10=\"" + txbNekThicMin.Text + "\"" +
                   " body-custom-min-11=\"" + txbNeckLenMin.Text + "\"" +
                   " body-custom-min-12=\"" + txbShoulderHeiMin.Text + "\"" +
                   " body-custom-min-13=\"" + txbShoulderWidMin.Text + "\"" +
                   " body-custom-min-14=\"" + txbShoulderSizMin.Text + "\"" +
                   " body-custom-min-15=\"" + txbArmThicMin.Text + "\"" +
                   " body-custom-min-16=\"" + txbArmLenMin.Text + "\"" +
                   " body-custom-min-17=\"" + txbHandSizMin.Text + "\"" +
                   " body-custom-min-18=\"" + txbHandLenMin.Text + "\"" +
                   " body-custom-min-19=\"" + txbFootSizMin.Text + "\"" +
                   " body-custom-min-2=\"" + txbPelvisThickMin.Text + "\"" +
                   " body-custom-min-20=\"" + txbBuildMin.Text + "\"" +
                   " body-custom-min-21=\"" + txbHeigthMin.Text + "\"" +
                   " body-custom-min-22=\"" + txbHeadSizMin.Text + "\"" +
                   " body-custom-min-23=\"" + txbChestHeiMin.Text + "\"" +
                   " body-custom-min-24=\"" + txbChestWidMin.Text + "\"" +
                   " body-custom-min-25=\"" + txbChestSizMin.Text + "\"" +
                   " body-custom-min-26=\"" + txbHeadWidMin.Text + "\"" +
                   " body-custom-min-3=\"" + txbWaisThicMin.Text + "\"" +
                   " body-custom-min-4=\"" + txbWaisLenMin.Text + "\"" +
                   " body-custom-min-5=\"" + txbThigthWidMin.Text + "\"" +
                   " body-custom-min-6=\"" + txbCalfWidMin.Text + "\"" +
                   " body-custom-min-7=\"" + txbThighLenMin.Text + "\"" +
                   " body-custom-min-8=\"" + txbCalfLenMin.Text + "\"" +
                   " body-custom-min-9=\"" + txbTorsoSizMin.Text + "\"" +
                   " race=\"" + Race + "\"" + " sex=\"" + Sex + "\"");
                File.WriteAllText(Environment.CurrentDirectory + @".\characterdefvaluedata.xml", xmlFile);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
                return;
            }
        }
        private void btnReset_Click(object sender, EventArgs e)
        {
            txBoxSet();
        }
        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            //"Yun",
            //"Gon Female",
            //"Lyn Female",
            //"Jin Female",
            //"Gon Male",
            //"Lyn Male",
            //"Jin Male"
            //Yun - race = "건" sex = "여"
            //GonF - race = "곤" sex = "여"
            //JinF - race = "진" sex = "여"
            //LynF - race = "린" sex = "여"
            //GonM - race = "곤" sex = "남"
            //JinM - race = "진" sex = "남"
            //LynM - race = "린" sex = "남
            switch (comboBox1.SelectedItem.ToString())
            {
                //female
                case "Yun":
                    Race = "건";
                    Sex = "여";
                    txBoxSet();
                    break;
                case "Gon Female":
                    Race = "곤";
                    Sex = "여";
                    break;
                case "Lyn Female":
                    Race = "린";
                    Sex = "여";
                    break;
                case "Jin Female":
                    Race = "진";
                    Sex = "여";
                    break;
                //male
                case "Gon Male":
                    Race = "곤";
                    Sex = "남";
                    break;
                case "Lyn Male":
                    Race = "린";
                    Sex = "남";
                    break;
                case "Jin Male":
                    Race = "진";
                    Sex = "남";
                    break;
                default:
                    break;
            }
            label36.Text = Race + Sex;
        }
    }
}
