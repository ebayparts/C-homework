using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace C_sharp_HT_Classes
{
    class Client
    {
        string name;
        string phone;
        public string Name
        {
            get => name;
            set => name = String.IsNullOrWhiteSpace(value) ? "NoName" : value;
        }
        public string Phone
        {
            get => phone;
            set
            {
                string phoneData = value;
                if (phoneData.Length == 12 && phoneData.All(c => Char.IsDigit(c)))
                {
                    this.phone = value;
                    return;
                }
                else
                    Console.WriteLine("Error. Phone number must be in 12 digit format!");
            }
        }
        public override string ToString() => $"Client name : {Name}\nClient phone : {Phone}";
        public Client(string name, string phone)
        {
            Name = name;
            Phone = phone;
        }
        public Client() : this("NoName", "NoPhone")
        { }
    }
}
