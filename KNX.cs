using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Collections;

namespace Studienarbeit
{
    class KNX
    {
        public KNX()
        {
            /**/
        }

        public void TestMethod()
        {
            int[] knxByteArrayTelegramm = new int[72]; /* 1byte+2bytes+2bytes+1bit+3bit+4bit+2-16bytes+1byte */
            knxByteArrayTelegramm[47] = 2; /* Schreib-Befehl */
        }
    }
}
