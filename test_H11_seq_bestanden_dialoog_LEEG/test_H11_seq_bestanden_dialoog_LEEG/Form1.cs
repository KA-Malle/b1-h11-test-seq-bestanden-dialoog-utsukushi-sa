using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace test_H11_seq_bestanden_dialoog_LEEG
{
    public partial class Form1 : Form
    {

        //globale variabelen _steden en random
        static string[] _steden = new string[8] {"lille", "Schilde", "turnhout", "geel", "mol", "deurne", "wilrijk", "herentals"};
        private static Random _rnd = new Random();

        public Form1()
        {
            InitializeComponent();
        }


        
        private void btnGenereer_Click(object sender, EventArgs e)
        {
 


            // Gegevens wegscrijven
            StreamWriter schrijver = new StreamWriter("verwerkt.txt");
            foreach (var item in _steden)
            {

                Random _rnd = new Random();
                int temp = _rnd.Next(14, 26);
                schrijver.WriteLine(_steden + " " + temp);
            }

           



                schrijver.Close();




        }

        private void btnVerwerken_Click(object sender, EventArgs e)
        {
            string outputArray;
            string[] lijnGesplit;

            for (int i = 1; i <= 8; i++)
            {
                using (StreamReader streamlees = new StreamReader("zonnedagen_voorbeeld.txt"))
                {
                    txtResultaat.Text = _rnd.ToString();
                
                    while (streamlees.Peek() != -1)
                    {
                        //declareren
                        int temp1, temp2, temp3, temp4, temp5, gemTemp;
                        string stad;
                
                        // lezen 1 record
                        outputArray = streamlees.ReadLine();
                        lijnGesplit = outputArray.Split(',');
                
                
                        //Gegevns juist zetten
                        stad = lijnGesplit[0];
                        temp1 = Convert.ToInt16( lijnGesplit[1]);
                        temp2 = Convert.ToInt16(lijnGesplit[2]);
                        temp3 = Convert.ToInt16(lijnGesplit[3]);
                        temp4 = Convert.ToInt16(lijnGesplit[4]); 
                        temp5 = Convert.ToInt16(lijnGesplit[5]);
                
                        txtResultaat.Text = stad + "," + temp1 + "," + temp2 + "," + temp3 + "," + temp4 + "," + temp5;

                        gemTemp = (temp1 + temp2 + temp3 + temp4 + temp5) / 5;

                    }
                    streamlees.Close();
                }
            }
        }

        private void btnSluiten_Click(object sender, EventArgs e)
        {
            Close();
        }
    }
}