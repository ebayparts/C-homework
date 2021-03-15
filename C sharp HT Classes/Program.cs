using System;

namespace C_sharp_HT_Classes
{
    class Program
    {
        static void Main(string[] args)
        {
            Client client1 = new Client("Alex", "380998234567");
            Client client2 = new Client("Igor", "380968334882");

            Console.WriteLine(client1);
            Event event1 = new Event(client1,"Hotel ***** 5+ Opening!", 1000,new DateTime(2021,03,25,19,0,0),"San-Francisco, CA");
            Console.WriteLine(event1);
            
            Event[] events = new Event[1];
            events[0] = event1;
            event1.ForwardEventDays(4);
            Console.WriteLine(event1);
            Event event2 = new Event(client2, "Car Auto Show", 150, new DateTime(2021, 03, 25, 19, 0, 0), "Lansing, MI");
            Event event3 = new Event(client1, "Car Races", 250, new DateTime(2021, 03, 29, 19, 0, 0), "Vancouver, WA");

            events[0] = event2;
            Array.Resize(ref events, events.Length + 1);
            events[1] = event1;
            Array.Resize(ref events, events.Length + 1);
            events[2] = event3;
            event3.ForwardEventWeeks(1);
            Console.WriteLine(event3);

            Event.NextWeekEvents(events);
            Event.MaxAndMinVisitorsEvents(events);



        }
    }
}
