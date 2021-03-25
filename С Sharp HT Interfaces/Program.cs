using System;
using System.Collections.Generic;

namespace С_Sharp_HT_Interfaces
{
    class Program
    {
        static void Main(string[] args)
        {
            Worker worker = new();
            Team team = new();
            TeamLeader teamLeader = new();

            team.Worker = worker;
            Console.WriteLine("Building house:");
            team.buildHouse();
            teamLeader.WhatAlreadyDone(worker);
        }
    }
}