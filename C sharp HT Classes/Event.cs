using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace C_sharp_HT_Classes
{
    class Event
    {
        public readonly string name;
        public readonly uint visitors;
        public readonly string place;
        public DateTime eventTime = new DateTime(2021, 03, 14);
        public uint ID;
        private static uint counter = 0;
        private Client client;
        public DateTime EventTime
        {
            get => eventTime;
            set => eventTime = DateTime.Today > value ? DateTime.Today.AddDays(3) : value;
        }
        public Event(Client client, string eventName, uint visitors, DateTime eventTime, string place = "NewPlace")
        {
            this.name = eventName;
            this.visitors = visitors;
            this.place = place;
            this.eventTime = eventTime;
            ID = ++counter;
            this.Client = client;
        }
        public Client Client
        {
            get => client;
            set
            {
                if (value != null)
                {
                    this.client = value;
                    return;
                }
                Console.WriteLine("Client is not created");
            }
        }
        public void ForwardEventDays(int daysWorward) { eventTime = eventTime.AddDays(daysWorward); }
        public void ForwardEventWeeks(int weeksWorward) => ForwardEventDays(weeksWorward * 7);
        public override string ToString() => $"\nID:{ID}\tUpcoming Event!! -->>>>  \"{name}\"\n Quantity of visitors: {visitors}\t Place: {place}\t Special time: {eventTime}" +
            $"\nClient(owner) : {Client.Name}\t phone : {Client.Phone}";
        public static void NextWeekEvents(Event[] events)
        {
            if (events == null)
            {
                Console.WriteLine("Array is empty");
                return;
            }
            Console.WriteLine("Next week events:");
            for (int i = 0; i < events.Length; i++)
            {
                if (DateTime.Now.AddDays(6) <= events[i].eventTime && events[i].eventTime <= DateTime.Now.AddDays(14))
                {
                    Console.WriteLine($"{events[i]}");
                }
            }
        }
        public static void MaxAndMinVisitorsEvents(Event[] events)
        {
            if (events == null)
            {
                Console.WriteLine("Array is empty");
                return;
            }
            foreach (var item in events)
            {
                if (item.visitors == events.Max(e => e.visitors))
                    Console.WriteLine($"\nMax visitors event: {item}");
                if (item.visitors == events.Min(e => e.visitors))
                    Console.WriteLine($"\nMin visitors event: {item}");
            }
        }
    }
}
