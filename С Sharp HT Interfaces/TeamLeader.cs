using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static С_Sharp_HT_Interfaces.IPart;


namespace С_Sharp_HT_Interfaces
{
    class TeamLeader : Team
    {
        public Worker _worker = new Worker();
        public void WhatAlreadyDone(Worker worker)
        {
            Console.WriteLine(worker.GetProduct().ListHouses());
        }
        public House GetProduct()
        {
            House result = _worker._House;
            return result;
        }
    }
}