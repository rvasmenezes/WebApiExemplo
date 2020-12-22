using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Lider.DPVAT.Administrativo.FaturamentoRCO.Helper.Util
{
    public static class StringUtil
    {
        public static string ConcatenaListaGlosas(List<string> listas)
        {
            StringBuilder glosa = new StringBuilder();

            foreach (var descricao in listas.Distinct())
            {
                glosa.AppendLine("- " + descricao);
            }

            return glosa.ToString();
        }
    }
}
