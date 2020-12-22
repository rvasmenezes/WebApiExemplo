using ClosedXML.Excel;
using System.Collections.Generic;
using System.Text;

namespace Lider.DPVAT.Administrativo.FaturamentoRCO.Helper.Util
{
    public static class PlanilhaExcel
    {
        public static StringBuilder RetornarCondicaoLote(string sinistro)
        {
            //Abrir excel
            var wb = new XLWorkbook(sinistro);
            var planilha = wb.Worksheet(1);
            var linha = 2;
            StringBuilder builder = new StringBuilder();
            builder.Append(" sinNumSinistro in (");
            while (true)
            {
                var sin = planilha.Cell("A" + linha.ToString()).Value.ToString();

                if (string.IsNullOrEmpty(sin))
                {
                    builder.Remove(builder.Length - 1, 1);
                    builder.Append(")");
                    break;
                }
                else
                {
                    builder.Append("'" + sin + "',");
                    linha++;
                }
            }

            return builder;
        }

        public static List<string> RetornaListaSinistros(string sinistro)
        {
            //Abrir excel
            var wb = new XLWorkbook(sinistro);
            var planilha = wb.Worksheet(1);
            var linha = 2;
            List<string> listaSinistro = new List<string>();           
            while (true)
            {
                var sin = planilha.Cell("A" + linha.ToString()).Value.ToString();

                if (string.IsNullOrEmpty(sin))
                {                    
                    break;
                }
                else
                {
                    listaSinistro.Add(sin);
                    linha++;
                }
            }

            return listaSinistro;
        }

    }
}
