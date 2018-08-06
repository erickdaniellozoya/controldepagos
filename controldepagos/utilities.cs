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
        char[] numeros = { '5', '9', '1', '6', '2', '8', '3', '0', '4', '7' };
        char[] mayusculas = {'M', 'N', 'B', 'Y', 'K', 'P', 'D',
            'X', 'G', 'J', 'V', 'I', 'Ñ', 'T', 'F', 'O', 'C', 'U', 'Z', 'L', 'S', 'Q', 'W', 'E', 'H', 'A', 'R'};
        char[] minusculas = {'i', 'r',
            'f', 'n', 'g', 'c', 'k', 'ñ', 'x', 'h', 'd',  'j', 'q', 'a', 'e', 'p', 'b', 'm', 'l', 't', 'z', 'u', 'o',
            'w', 'y', 'v', 's'};
        char[] signos = {'.', '/', '*', '_', '+', ';', '^', '~', ':', '<', '>', '@', '$', '#',
            '%', '&', '(', ')', '[', ']', '{', '}', '=', '¡', '!', ',', '¿', '?', '|', '-', '°', '¨', ' '};


        public bool contra(string pass)
        {
            bool estado = false;
            for (int i = 0; i < mayusculas.Length && !estado; i++)
            {
                if (pass.Contains(mayusculas[i]))
                {
                    estado = true;
                }
                else
                {
                    estado = false;
                }

            }
            bool estado2 = false;
            for (int i = 0; i < numeros.Length && !estado2; i++)
            {
                if (pass.Contains(numeros[i]))
                {
                    estado2 = true;
                }
                else
                {
                    estado2 = false;
                }

            }

            bool estado3 = false;
            for (int i = 0; i < signos.Length && !estado3; i++)
            {
                if (pass.Contains(signos[i]))
                {
                    estado3 = true;
                }
                else
                {
                    estado3 = false;
                }
            }
            bool estado4 = false;
            for (int i = 0; i < minusculas.Length && !estado4; i++)
            {
                if (pass.Contains(minusculas[i]))
                {
                    estado4 = true;
                }
                else
                {
                    estado4 = false;
                }
            
            }
            if (estado && estado2 && estado3 && estado4) 
            {
                return true;
            }else
            {
                return false;
            }
        }
          
              
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
            Stack<string> numeros = new Stack<string>();
            for (int i = numero.Length - 1; i >=0 ; i-=3)
            {
                numeros.Push((numero[i] + numero[i-1] + numero[i-2]).ToString());
            }
            return "";
        }

        public string encriptar(string texto)
        {
            int posicionAnt = texto.Length;
            string encriptado = "";
            int contador = 0;
            while (contador < texto.Length)
            {
                #region Primer digito
                try
                {
                    encriptado += numeros[posicionAnt].ToString();
                }
                catch (IndexOutOfRangeException exc)
                {
                    Console.WriteLine(exc.Message);
                    posicionAnt -= numeros.Length;
                    try
                    {
                        encriptado += mayusculas[posicionAnt];
                    }
                    catch (IndexOutOfRangeException exc2)
                    {
                        Console.WriteLine(exc2.Message);
                        posicionAnt -= mayusculas.Length;
                        try
                        {
                            encriptado += minusculas[posicionAnt];
                        }
                        catch (IndexOutOfRangeException exc3)
                        {
                            Console.WriteLine(exc3.Message);
                            posicionAnt -= minusculas.Length;
                            encriptado += signos[posicionAnt];
                        }
                    }
                }
                #endregion


                if (numeros.Contains(texto[contador]))
                {
                    int posicion = 0;
                    while (numeros[posicion] != texto[contador]) posicion++;
                    encriptado += mayusculas[posicion];
                    try
                    {
                        posicion -= posicionAnt;
                        encriptado += mayusculas[posicion];
                    }
                    catch (IndexOutOfRangeException exc)
                    {
                        Console.WriteLine(exc.Message);
                        posicion += posicionAnt;
                        posicion = mayusculas.Length + (posicion - posicionAnt);
                        encriptado += mayusculas[posicion];
                    }
                    finally
                    {
                        posicionAnt = posicion;
                    }
                }
                else if (mayusculas.Contains(texto[contador]))
                {
                    int posicion = 0;
                    while (mayusculas[posicion] != texto[contador]) posicion++;
                    encriptado += signos[posicion];
                    try
                    {
                        posicion -= posicionAnt;
                        encriptado += signos[posicion];
                    }
                    catch (IndexOutOfRangeException exc)
                    {
                        Console.WriteLine(exc.Message);
                        posicion += posicionAnt;
                        posicion = signos.Length + (posicion - posicionAnt);
                        encriptado += signos[posicion];
                    }
                    finally
                    {
                        posicionAnt = posicion;
                    }
                }
                else if (signos.Contains(texto[contador]))
                {
                    int posicion = 0;
                    while (signos[posicion] != texto[contador]) posicion++;
                    bool estado = false;
                    int vueltas = -1;
                    while (!estado)
                    {
                        try
                        {
                            encriptado += minusculas[posicion];
                            estado = true;
                        }
                        catch (IndexOutOfRangeException exc)
                        {
                            Console.WriteLine(exc.Message);
                            posicion -= minusculas.Length;
                            vueltas++;
                        }
                    }
                    if (vueltas > -1)
                    {
                        encriptado += "¬" + numeros[vueltas];
                    }
                    try
                    {
                        posicion -= posicionAnt;
                        encriptado += minusculas[posicion];
                    }
                    catch (IndexOutOfRangeException exc)
                    {
                        Console.WriteLine(exc.Message);
                        posicion += posicionAnt;
                        posicion = minusculas.Length + (posicion - posicionAnt);
                        encriptado += minusculas[posicion];
                    }
                    finally
                    {
                        posicionAnt = posicion;
                    }
                }
                else if (minusculas.Contains(texto[contador]))
                {
                    int posicion = 0;
                    while (minusculas[posicion] != texto[contador]) posicion++;
                    bool estado = false;
                    int vueltas = -1;
                    while (!estado)
                    {
                        try
                        {
                            encriptado += numeros[posicion];
                            estado = true;
                        }
                        catch (IndexOutOfRangeException exc)
                        {
                            Console.WriteLine(exc.Message);
                            posicion -= numeros.Length;
                            vueltas++;
                        }
                    }
                    if (vueltas > -1)
                    {
                        encriptado += "¬" + numeros[vueltas].ToString();
                    }
                    try
                    {
                        posicion -= posicionAnt;
                        encriptado += numeros[posicion];
                    }
                    catch (IndexOutOfRangeException exc)
                    {
                        Console.WriteLine(exc.Message);
                        posicion += posicionAnt;
                        posicion = numeros.Length + (posicion - posicionAnt);
                        while (posicion < 0)
                        {
                            posicion += numeros.Length;
                        }
                        encriptado += numeros[posicion];
                    }
                    finally
                    {
                        posicionAnt = posicion;
                    }
                }
                contador++;
            }
            return encriptado;
        }

        public string Desencriptar(string encriptado)
        {
            string mensaje = "";
            int cont = 3;
            for (int i = 0; i < encriptado.Length; i += cont)
            {
                string cadena = encriptado.Substring(i, 3);

                if (cadena[2].Equals('¬'))
                {
                    cadena = encriptado.Substring(i, 5);
                    int posicion1 = 0;
                    if (numeros.Contains(cadena[0]))
                    {
                        while (numeros[posicion1] != cadena[0]) posicion1++;
                    }
                    else if (mayusculas.Contains(cadena[0]))
                    {
                        while (mayusculas[posicion1] != cadena[0]) posicion1++;
                    }
                    else if (minusculas.Contains(cadena[0]))
                    {
                        while (minusculas[posicion1] != cadena[0]) posicion1++;
                    }
                    else if (signos.Contains(cadena[0]))
                    {
                        while (signos[posicion1] != cadena[0]) posicion1++;
                    }

                    int posicion2 = 0;
                    if (numeros.Contains(cadena[1]))
                    {
                        while (numeros[posicion2] != cadena[1]) posicion2++;
                    }
                    else if (mayusculas.Contains(cadena[1]))
                    {
                        while (mayusculas[posicion2] != cadena[1]) posicion2++;
                    }
                    else if (minusculas.Contains(cadena[1]))
                    {
                        while (minusculas[posicion2] != cadena[1]) posicion2++;
                    }
                    else if (signos.Contains(cadena[1]))
                    {
                        while (signos[posicion2] != cadena[1]) posicion2++;
                    }

                    int posicion3 = 0;
                    if (numeros.Contains(cadena[4]))
                    {
                        while (numeros[posicion3] != cadena[4]) posicion3++;
                    }
                    else if (mayusculas.Contains(cadena[4]))
                    {
                        while (mayusculas[posicion3] != cadena[4]) posicion3++;
                    }
                    else if (minusculas.Contains(cadena[4]))
                    {
                        while (minusculas[posicion3] != cadena[4]) posicion3++;
                    }
                    else if (signos.Contains(cadena[4]))
                    {
                        while (signos[posicion3] != cadena[4]) posicion3++;
                    }

                    int posVuel = 0;
                    while (numeros[posVuel] != cadena[3]) posVuel++;

                    int sumPos = posicion1 + posicion3;
                    if (numeros.Contains(cadena[1]))
                    {
                        while (sumPos >= numeros.Length)
                        {
                            sumPos -= numeros.Length;
                        }
                        if (sumPos == posicion2)
                        {
                            mensaje += minusculas[sumPos + ((posVuel + 1) * numeros.Length)];
                        }
                        else
                        {
                            mensaje += "Error";
                        }
                    }

                    else if (mayusculas.Contains(cadena[1]))
                    {
                        while (sumPos >= mayusculas.Length)
                        {
                            sumPos -= mayusculas.Length;
                        }
                        if (sumPos == posicion2)
                        {
                            mensaje += numeros[sumPos + ((posVuel + 1) * mayusculas.Length)];
                        }
                        else
                        {
                            mensaje += "Error";
                        }
                    }
                    else if (minusculas.Contains(cadena[1]))
                    {

                        while (sumPos >= minusculas.Length)
                        {
                            sumPos -= minusculas.Length;
                        }
                        if (sumPos == posicion2)
                        {
                            mensaje += signos[sumPos + ((posVuel + 1) * minusculas.Length)];
                        }
                        else
                        {
                            mensaje += "Error";
                        }
                    }
                    else if (signos.Contains(cadena[1]))
                    {
                        while (sumPos >= signos.Length)
                        {
                            sumPos -= signos.Length;
                        }
                        if (sumPos == posicion2)
                        {
                            mensaje += mayusculas[sumPos + ((posVuel + 1) * signos.Length)];
                        }
                        else
                        {
                            mensaje += "Error";
                        }
                    }
                    cont = 5;
                }
                else
                {
                    int posicion1 = 0;
                    if (numeros.Contains(cadena[0]))
                    {
                        while (numeros[posicion1] != cadena[0]) posicion1++;
                    }
                    else if (mayusculas.Contains(cadena[0]))
                    {
                        while (mayusculas[posicion1] != cadena[0]) posicion1++;
                    }
                    else if (minusculas.Contains(cadena[0]))
                    {
                        while (minusculas[posicion1] != cadena[0]) posicion1++;
                    }
                    else if (signos.Contains(cadena[0]))
                    {
                        while (signos[posicion1] != cadena[0]) posicion1++;
                    }

                    int posicion2 = 0;
                    if (numeros.Contains(cadena[1]))
                    {
                        while (numeros[posicion2] != cadena[1]) posicion2++;
                    }
                    else if (mayusculas.Contains(cadena[1]))
                    {
                        while (mayusculas[posicion2] != cadena[1]) posicion2++;
                    }
                    else if (minusculas.Contains(cadena[1]))
                    {
                        while (minusculas[posicion2] != cadena[1]) posicion2++;
                    }
                    else if (signos.Contains(cadena[1]))
                    {
                        while (signos[posicion2] != cadena[1]) posicion2++;
                    }

                    int posicion3 = 0;
                    if (numeros.Contains(cadena[2]))
                    {
                        while (numeros[posicion3] != cadena[2]) posicion3++;
                    }
                    else if (mayusculas.Contains(cadena[2]))
                    {
                        while (mayusculas[posicion3] != cadena[2]) posicion3++;
                    }
                    else if (minusculas.Contains(cadena[2]))
                    {
                        while (minusculas[posicion3] != cadena[2]) posicion3++;
                    }
                    else if (signos.Contains(cadena[2]))
                    {
                        while (signos[posicion3] != cadena[2]) posicion3++;
                    }

                    int sumPos = posicion1 + posicion3;
                    if (numeros.Contains(cadena[1]))
                    {
                        while (sumPos >= numeros.Length)
                        {
                            sumPos -= numeros.Length;
                        }
                        if (sumPos == posicion2)
                        {
                            mensaje += minusculas[sumPos];
                        }
                        else
                        {
                            mensaje += "Error";
                        }
                    }

                    else if (mayusculas.Contains(cadena[1]))
                    {
                        while (sumPos >= mayusculas.Length)
                        {
                            sumPos -= mayusculas.Length;
                        }
                        if (sumPos == posicion2)
                        {
                            mensaje += numeros[sumPos];
                        }
                        else
                        {
                            mensaje += "Error";
                        }
                    }
                    else if (minusculas.Contains(cadena[1]))
                    {
                        while (sumPos >= minusculas.Length)
                        {
                            sumPos -= minusculas.Length;
                        }
                        if (sumPos == posicion2)
                        {
                            mensaje += signos[sumPos];
                        }
                        else
                        {
                            mensaje += "Error";
                        }
                    }
                    else if (signos.Contains(cadena[1]))
                    {
                        while (sumPos >= signos.Length)
                        {
                            sumPos -= signos.Length;
                        }
                        if (sumPos == posicion2)
                        {
                            mensaje += mayusculas[sumPos];
                        }
                        else
                        {
                            mensaje += "Error";
                        }
                    }
                    cont = 3;
                }
            }
            return mensaje;
        }
    }
}
