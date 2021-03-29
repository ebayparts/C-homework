using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace C_Sharp_HT_Structs_Enums_IComparable
{
    class Client : IComparable
    {
        string phone = "Unussigned";
        public int ClientCode { get; set; } = 0;
        public string SurnameName { get; set; } = "Unussigned";
        public string Address { get; set; } = "Unussigned";
        public uint OrdersQty { get; set; } = 0;
        public uint OrdersValue { get; set; } = 0;

        public string Phone
        {
            get => phone;
            set
            {
                uint tempValue;
                if (value.Length < 12 && value.Length>9  || uint.TryParse(value, out tempValue) != true)
                    phone = value;
                else
                    throw new Exception("Not correct value");
            }
        }
        public Client (string nameSurname, string address, string phone, int clientCode, uint ordersQty)
        {
            SurnameName = nameSurname;
            Address = address;
            Phone = phone;
            ClientCode = clientCode;
            OrdersQty = ordersQty;
        }
        public Client ()
            :base()
        { }
        public override string ToString()
        {
            return $"Client: {SurnameName}\tAddress: {Address}\tPhone: {phone}\tCode: {ClientCode}\n" +
                $"All Orders q-ty: {OrdersQty}\tAll Orders Value: {OrdersValue}";
        }
        public int CompareTo(Client cl)
        {
            return this.OrdersValue.CompareTo(cl.OrdersValue);
        }
        public int CompareTo(Object cl)
        {
            return this.OrdersValue.CompareTo(((Client)cl).OrdersValue);
        }

    }
    class CompareByPhone : IComparer<Client>
    {
        public int Compare(Client x, Client y)
        {
            return x.Phone.CompareTo(y.Phone);
        }
    }
}