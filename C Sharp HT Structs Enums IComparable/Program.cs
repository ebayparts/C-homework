using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;

namespace C_Sharp_HT_Structs_Enums_IComparable
{
    struct Article : ICloneable
    {
        int itemCode;
        public enum itemCategory
        {
            Table = 1,
            Chair,
            Sofa,
            PC,
            Tools,
            Software
        }
        public itemCategory Category { get; set; }
        string itemName;
        uint itemPrice;
        public Article(string itemName, uint itemPrice, int itemCode, itemCategory cat)
            : this()
        {
            ItemPrice = itemPrice;
            ItemName = itemName;
            ItemCode = itemCode;
            Category = cat;
        }
        public uint ItemPrice
        {
            get => itemPrice;
            set => itemPrice = value;
        }
        public string ItemName
        {
            get => itemName;
            set => itemName = value;
        }
        public int ItemCode
        {
            get => itemCode;
            set => itemCode = value;
        }
        public override string ToString()
        {
            return $"Name: {itemName,-15}\tPrice: {ItemPrice,-10}\tCode: {ItemCode,-10}\tCategory: {Category,-10}";
        }

        public object Clone()
        {
            Article article = new Article(this.ItemName, this.ItemPrice, this.ItemCode, this.Category);
            return article;
        }
    }
    struct RequestItem
    {
        public uint ItemQty { get; set; }
        public Article @Article { get; set; }
        public RequestItem(uint itemQty, Article article)
        {
            ItemQty = itemQty;
            @Article = article;
        }
        public override string ToString()
        {
            return $"Item: {@Article}\nQuantity: {ItemQty}";
        }
    }
    struct Request
    {
        public Request(uint orderCode, Client client, DateTime orderDate, List<RequestItem> orderedList)
        {
            OrderCode = orderCode;
            @Client = client;
            OrderDate = orderDate;
            OrderedList = orderedList;
            Client.OrdersQty++;
            Client.OrdersValue += OrderSum;
        }
        public uint OrderCode { get; set; }
        public Client @Client { get; set; }
        public DateTime OrderDate { get; set; }
        public List<RequestItem> OrderedList { get; set; }
        public readonly uint OrderSum
        {
            get
            {
                uint sum = 0;
                foreach (RequestItem p in OrderedList)
                    sum += (p.Article.ItemPrice * p.ItemQty);
                return sum;
            }
        }
        public override string ToString()
        {
            return $"\nOrder code: {OrderCode}\tOrder Date: {OrderDate}\n{@Client}\nOrder Sum: " +
                $"{OrderSum}\tOrders: \n{String.Join("\n", OrderedList)}";
        }
    }
    class Program
    {
        static void PrintClList(ref List<Client> clist)
        {
            Console.WriteLine("Client list:");
            foreach (Client c in clist)
            {
                Console.WriteLine(c);
            }
            Console.WriteLine();
        }
        static public List<Client> SortByName(ref List<Client> clList)
        {
            //clList.Sort((clA, clB) => clA.SurnameName.CompareTo(clB.SurnameName)); // <- this works good, but I wanted to do it by loop :
            for (int k = 0; k < clList.Count; k++)
            {
                for (int i = 1; i < clList.Count; i++)
                {
                    int j = 0;
                    if (clList[i - 1].SurnameName[j] > clList[i].SurnameName[j])
                    {
                        Client temp = clList[i - 1];
                        clList[i - 1] = clList[i];
                        clList[i] = temp;
                    }
                    else if (clList[i - 1].SurnameName[j] == clList[i].SurnameName[j])
                    {
                        int jMax = clList[i - 1].SurnameName.Length < clList[i].SurnameName.Length ? clList[i - 1].SurnameName.Length : clList[i].SurnameName.Length;
                        for (; j < jMax; j++)
                        {
                            if (clList[i - 1].SurnameName[j] == clList[i].SurnameName[j])
                                continue;
                            if (clList[i - 1].SurnameName[j] > clList[i].SurnameName[j])
                            {
                                Client temp = clList[i - 1];
                                clList[i - 1] = clList[i];
                                clList[i] = temp;
                            }
                            j = jMax;
                        }
                    }
                }
            }
            return clList;
        }
        static void Main(string[] args)
        {
            //Hometask 1: 
            Client clientA = new("Oleksandr Zinkovskyi", "12 Bronx Avenu, apt.84", "0998864467", 112, 0);
            List<RequestItem> AlexOrderedList1 = new List<RequestItem>();
            Article article1 = new Article("Big Sofa", 250, 1123, (Article.itemCategory)3);
            RequestItem requestIt1 = new RequestItem(2, article1);
            Article article2 = new Article("Nice Chair", 90, 1112, (Article.itemCategory)2);
            RequestItem requestIt2 = new RequestItem(4, article2);
            Article article3 = new Article("Makita SET", 200, 2225, (Article.itemCategory)5);
            RequestItem requestIt3 = new RequestItem(1, article3);
            AlexOrderedList1.Add(requestIt1);
            AlexOrderedList1.Add(requestIt2);
            AlexOrderedList1.Add(requestIt3);
            Request request1 = new Request(1, clientA, DateTime.Now, AlexOrderedList1);
            Console.WriteLine(request1);

            Client clientE = new("Olena Filakhtova", "11 Best street, apt.13", "0668862361", 113, 0);
            List<RequestItem> HelenOrderedList1 = new List<RequestItem>();
            Article article4 = new Article("Oak Table", 150, 1121, (Article.itemCategory)1);
            RequestItem requestIt4 = new RequestItem(1, article4);
            Article article5 = new Article("PC I7-64GB", 300, 1114, (Article.itemCategory)4);
            RequestItem requestIt5 = new RequestItem(1, article5);
            Article article6 = new Article("OS Windows 11", 80, 1126, (Article.itemCategory)6);
            RequestItem requestIt6 = new RequestItem(1, article6);
            Article article7 = new Article("Counter-Strike 1.6", 40, 1126, (Article.itemCategory)6);
            RequestItem requestIt7 = new RequestItem(1, article7);
            HelenOrderedList1.Add(requestIt4);
            HelenOrderedList1.Add(requestIt2);
            HelenOrderedList1.Add(requestIt5);
            HelenOrderedList1.Add(requestIt6);
            Request request2 = new Request(2, clientE, DateTime.Now, HelenOrderedList1);
            Console.WriteLine(request2);

            Article article8 = new Article("IntelI7 6700k 64GB RAM", 300, 1114, (Article.itemCategory)4);
            RequestItem requestIt8 = new RequestItem(1, article5);
            List<RequestItem> AlexOrderedList2 = new List<RequestItem>();
            AlexOrderedList2.Add(requestIt8);
            Request request3 = new Request(3, clientA, DateTime.Now, AlexOrderedList2);
            Console.WriteLine(request3);

            Console.WriteLine($"Comparing two clients by overall sum of items bought:");
            Console.WriteLine($"Client 1 {clientA.SurnameName,-15} bought more than Client 2 {clientE.SurnameName} ?" +
                $" -  {(clientA.CompareTo(clientE) == 1 ? "Yes" : "No")}");

            //Hometask 2:
            Client clientK = new("Kate Zinkovskaya", "12 Bronx Avenu, apt.84", "09910964312", 114, 0);
            List<Client> ClientsList = new List<Client>();
            ClientsList.Add(clientE);
            ClientsList.Add(clientA);
            ClientsList.Add(clientK);
            Console.WriteLine("\nSorting by Overall Sum:");
            ClientsList.Sort();
            PrintClList(ref ClientsList);

            Console.WriteLine("Sorting by Client Code:");
            ClientsList.Sort((clA, clB) => clA.ClientCode.CompareTo(clB.ClientCode));
            PrintClList(ref ClientsList);

            Console.WriteLine("Sorting by name:");
            SortByName(ref ClientsList);
            PrintClList(ref ClientsList);

            Console.WriteLine("Sorting by Phone:");
            CompareByPhone ByPhone = new();
            ClientsList.Sort(ByPhone);
            PrintClList(ref ClientsList);

            //Hometask 3:
            Console.WriteLine($"Cloning article 1 : {article1.ItemName}");
            Article article1Clone = (Article)article1.Clone();
            Console.WriteLine($"After cloning : {article1Clone}");

        }
    }
}
