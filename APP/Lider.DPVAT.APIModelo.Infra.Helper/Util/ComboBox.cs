using Microsoft.AspNetCore.Mvc.Rendering;
using System.Collections.Generic;
using System.Linq;

namespace Lider.DPVAT.Administrativo.FaturamentoRCO.Helper.Util
{
    public static class ComboBox
    {
        /// <summary>
        /// AdicionaItem - Adiciona item com index 0 na lista
        /// </summary>
        /// <typeparam name="T">Tipo do objeto</typeparam>
        /// <param name="itens">Lista com todos os item de objeto</param>
        /// <returns>Retorna uma lista com todos os item adicionado com mais um index.</returns>
        public static List<SelectListItem> GetCarregaCombo<T>(List<T> itens, bool adicionaLinha, string texto, int posValor, int posTexto)
        {

            List<SelectListItem> items = null;

            if (itens.Count() > 0)
            {
                items = new SelectList(itens,
                                       itens.ElementAt(0).GetType().GetProperties()[posValor].Name,
                                       itens.ElementAt(0).GetType().GetProperties()[posTexto].Name).ToList();
            }
            else
            {
                items = new List<SelectListItem>();
            }

            if (adicionaLinha)
            {
                items.Insert(0, (new SelectListItem { Text = texto, Value = "0" }));
            }

            return items;

        }
    }
}
