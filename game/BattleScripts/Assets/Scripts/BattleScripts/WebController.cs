using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;

namespace BattleScripts
{
    public static class WebController
    {
        [DllImport("__Internal")]
        private static extern void Error();

        public static void Alert()
        {
            Error();
        }
    }
}
