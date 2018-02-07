using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SqlClient;

namespace SimHopp
{
    static class Program
    {
        [STAThread]
        static void Main()
        {
            //Model.Db test = new Model.Db();
            //test.LoginDB();
            Model.Inloggning Inlogg = new Model.Inloggning();
            Inlogg.Write();
            //Application.EnableVisualStyles();
            //Application.SetCompatibleTextRenderingDefault(false);
            //Application.Run(new Form1());
            Console.ReadKey();
        }
    }
}
