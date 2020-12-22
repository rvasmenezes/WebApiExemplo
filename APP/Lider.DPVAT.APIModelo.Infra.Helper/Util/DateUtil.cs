using System;

namespace Lider.DPVAT.Administrativo.FaturamentoRCO.Helper.Util
{
    public static class DateUtil
    {
        /// <summary>
        /// Método que faz o calculo de Dias
        /// </summary>
        /// <param name="charInterval"> d para Dias - m para Mês - y para Ano</param>
        /// <param name="dttFromDate">Data Inicio</param>
        /// <param name="dttToDate">Data Fim</param>
        /// <returns></returns>
        public static int DateDiff(DateTime initialDate, DateTime finalDate)
        {
            var days = initialDate.Subtract(finalDate).Days;
            if (days < 0)
                days = days * -1;

            return days;

        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="initialDate"></param>
        /// <param name="finalDate"></param>
        /// <returns></returns>
        public static int DateDiffNoWekeend(DateTime initialDate, DateTime finalDate)
        {
            var days = 0;
            var daysCount = 0;
            days = initialDate.Subtract(finalDate).Days;

            if (days < 0)
                days = days * -1;

            for (int i = 1; i <= days; i++)
            {
                initialDate = initialDate.AddDays(1);

                if (initialDate.DayOfWeek != DayOfWeek.Sunday &&
                    initialDate.DayOfWeek != DayOfWeek.Saturday)
                    daysCount++;
            }
            return daysCount;
        }


    }
}
