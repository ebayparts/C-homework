using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace С_Sharp_HT_Interfaces
{
    interface IWorker : IPart
    {
        public void BuildBasement(BasementType basementType);
        public void BuildWalls(WallType wallType);
        public void BuildDoor(DoorType doorType);
        public void BuildWindows(WindowType windowType);
        public void BuildRoof(RoofType roofType);
    }
}
