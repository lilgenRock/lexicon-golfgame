using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Golf
{
    class User
    {
        string _name;

        public void GetNameFromConsole(User u)
        {
            string input = "";
            while (u.Name == null)
            {
                input = Console.ReadLine();
                this.Name = input;
            }
        }

        public string Name      //public string Name { get; private set; }        
        {
            get {return _name;}
            set {
                if(value.Length< 11 && value.Length > 2)
                    _name = value;
                else
                {
                    Console.WriteLine("Invalid name length. 3-10 characters allowed.");
                }
            }
        }
    }
}
