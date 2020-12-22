using System;
using System.Collections.Generic;
using System.Text;

namespace Lider.DPVAT.Administrativo.FaturamentoRCO.Helper.Util
{
    public static class DisplayWelcomeSchedule
    {
        #region "Welcome Message"
        public static void DisplayWelcome()
        {
            System.Console.ForegroundColor = ConsoleColor.Cyan;

            System.Console.WriteLine();
            System.Console.WriteLine(@"  ___                            _                _    __   _         ");
            System.Console.WriteLine(@" / __| ___ __ _ _  _ _ _ __ _ __| |___ _ _ __ _  | |  /_/__| |___ _ _ ");
            System.Console.WriteLine(@" \__ \/ -_) _` | || | '_/ _` / _` / _ \ '_/ _` | | |__| / _` / -_) '_|");
            System.Console.WriteLine(@" |___/\___\__, |\_,_|_| \__,_\__,_\___/_| \__,_| |____|_\__,_\___|_|  ");
            System.Console.WriteLine(@"          |___/                                                       ");
            System.Console.WriteLine();
            System.Console.WriteLine();

            System.Console.ResetColor();
        }
        #endregion "Welcome Message"

    }
}
