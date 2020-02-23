using System;
using System.Threading;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ObjMonitor
{
    class Program
    {

        static long Millis()
        {
            return DateTime.Now.Ticks / TimeSpan.TicksPerMillisecond;
        }

        static void Main(string[] args)
        {
            var reader = new BF2MemoryReader();
            reader.Open("BattlefrontII");

            var form = new ObjForm();
            Application.EnableVisualStyles();
            form.Show();

            int updates = -1;
            long updateMillis = -1;
            int ctr = 0;

            while (true)
            {
                if (++ctr % 5 == 0)
                {
                    form.UpdateObjList(reader.ReadObjTable());
                }

                if(++ctr %100 == 0)
                {
                    if (updates > 0)
                    {
                        float du = reader.GetClientUpdates() - updates;
                        long dt = Millis() - updateMillis;
                        du /= dt;
                        du *= 1000;

                        form.UpdateStats(du);
                    }
                    updates = reader.GetClientUpdates();
                    updateMillis = Millis();
                }
                Application.DoEvents();
                Thread.Sleep(20);

            }
        }
    }
}