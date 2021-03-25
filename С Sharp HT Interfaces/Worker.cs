using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static С_Sharp_HT_Interfaces.IPart;

namespace С_Sharp_HT_Interfaces
{
    class Worker : IWorker
    {
        private House _house = new House();
        public House _House { get =>_house; }

        public House GetProduct()
        {
            House result = this._house;
            return result;
        }
        public void BuildBasement(BasementType basementType)
        {
            Console.WriteLine($"Building basement. Basement type: {basementType}");
            this._house.Add("Basement");
        }
        public void BuildWalls(WallType wallType)
        {
            Console.WriteLine($"Building wall. Wall type: {wallType}");
            this._house.Add("Wall");
        }
        public void BuildDoor(DoorType doorType)
        {
            Console.WriteLine($"Building door. Door type: {doorType}");
            this._house.Add("Door");
        }
        public void BuildWindows(WindowType windowType)
        {
            Console.WriteLine($"Building window. Window type: {windowType}");
            this._house.Add("window");
        }
        public void BuildRoof(RoofType roofType)
        {
            Console.WriteLine($"Building roof. Roof type: {roofType}");
            this._house.Add("Roof");
        }
    }
}