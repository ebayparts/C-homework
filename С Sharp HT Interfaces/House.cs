using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace С_Sharp_HT_Interfaces
{
    class House : IPart
    {
        private List<object> _houseParts = new List<object>();
        public void Add(string part)
        {
            this._houseParts.Add(part);
        }
        public string ListHouses()
        {
            string str = string.Empty;

            for (int i = 0; i < this._houseParts.Count; i++)
            {
                str += this._houseParts[i] + ", ";
            }
            if (str != string.Empty)
                str = str.Remove(str.Length - 2);
            return "\nAlready built: " + str + "\n";
        }
    }
}
