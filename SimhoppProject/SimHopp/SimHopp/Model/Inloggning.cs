using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SimHopp.Model
{
    class Inloggning
    {
        List<User> Valid_User;
        Db database = new Db();
        public Inloggning()
        {
            this.Valid_User = database.LoginDB();
        }

        public void Write()
        {
            foreach (User u in Valid_User)
            {
                Console.WriteLine(u.userID + " " + u.Username + " " + u.Password);
            }
        }

    }
}
