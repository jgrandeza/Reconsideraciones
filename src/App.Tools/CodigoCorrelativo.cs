using System;
using System.Collections.Generic;
using System.Text;

namespace App.Tools
{
    public class CodigoCorrelativo
    {
        public static string GenerarCodigo(string codigo, string letrCodigo)
        {
            string codigo_str = "";
            int codigo_int = Convert.ToInt32(codigo) + 1;
            string count_codigo = Convert.ToString(codigo_int);
            switch (count_codigo.Length)
            {
                case 1:
                    codigo_str = string.Concat(letrCodigo, "0000", codigo_int);
                    break;
                case 2:
                    codigo_str = string.Concat(letrCodigo, "000", codigo_int);
                    break;
                case 3:
                    codigo_str = string.Concat(letrCodigo, "00", codigo_int);
                    break;
                case 4:
                    codigo_str = string.Concat(letrCodigo, "0", codigo_int);
                    break;
                default:
                    codigo_str = Convert.ToString(codigo_int);
                    break;
            }
            return codigo_str.Trim();
        }
        
    }
}
