using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace controldepagos
{
    class utilities
    {
        public string iniciales(string pal)
        {
            try
            {
                if (pal.Contains(" "))
                {
                    string[] palabra = pal.Split(' ');
                    pal = "";
                    for (int i = 0; i < palabra.Length; i++)
                    {
                        palabra[i] = palabra[i].ToLower();
                        string inicial = palabra[i][0].ToString();
                        string mayus = inicial.ToUpper();
                        palabra[i] = palabra[i].Remove(0, 1);
                        palabra[i] = palabra[i].Insert(0, mayus);
                        pal += palabra[i] + " ";
                    }
                    pal = pal.Remove(pal.Length - 1);
                }
                else if (pal != "")
                {
                    pal = pal.ToLower();
                    string inicial = pal[0].ToString();
                    string mayus = inicial.ToUpper();
                    pal = pal.Remove(0, 1);
                    pal = pal.Insert(0, mayus);
                }
            }
            catch (IndexOutOfRangeException exc)
            {
                Console.WriteLine(exc.Message);
            }
            return pal;
        }

        public string iniciales(string pal, TextBox txt)
        {
            txt.SelectionStart = txt.TextLength;
            return iniciales(pal);
        }

        public string numToLet(string numero)
        {

            return "";
        }
    }
}
