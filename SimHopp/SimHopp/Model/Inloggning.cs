
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace SimHopp
{
    class Inloggning
    {
        public struct User
        {
            public string Valid_Username;
            public string Valid_Password;
            public User(string s1, string s2)
            {
                Valid_Username = s1;
                Valid_Password = s2;
            }
        }
        List<User> Valid_Users = new List<User>();
        private string Username { get; set; }
        private string Password { get; set; }
        public void Get_Valid_Users()
        {
            string[] Lines = File.ReadAllLines(Path.Combine(Environment.CurrentDirectory, "Login.txt"));
            foreach (string line in Lines)
            {
                string[] splitted = line.Split(new[] {" "}, StringSplitOptions.None);
                Valid_Users.Add(new User(splitted[0], splitted[1]));

            }
            foreach (User u in Valid_Users)
            {
                Console.WriteLine(u.Valid_Username);
                Console.WriteLine(u.Valid_Password);
            }
            bool running = true;
            bool match = false;
            int tries = 2;
            while (running)
            {
                if (tries == 0)
                {
                    running = false;
                }
                Console.WriteLine("Please enter your username: ");
                string In_User = Console.ReadLine();
                Console.WriteLine("Please enter your password: ");
                string In_Pass = Console.ReadLine();
                User new_User = new User(In_User, In_Pass);
                foreach (User u in Valid_Users)
                {
                    if (new_User.Valid_Username == u.Valid_Username && new_User.Valid_Password == u.Valid_Password)
                    {
                        match = true;
                        running = false;
                    }
                }
                tries = tries - 1;
            }
            if (match)
            {
                Console.WriteLine("Logged in");
            }
            else if (!match)
            {
                Console.WriteLine("You have failed.");
            }
        }
    }
}

