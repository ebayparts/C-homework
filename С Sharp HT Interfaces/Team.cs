using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace С_Sharp_HT_Interfaces
{
    class Team
    {
        private IWorker _worker;
        public IWorker Worker
        {
            set { _worker = value; }
            get => _worker;
        }
        public void buildHouse()
        {
            this._worker.BuildBasement((IPart.BasementType)1);
            this._worker.BuildWalls((IPart.WallType)1);
            this._worker.BuildWalls((IPart.WallType)1);
            this._worker.BuildWalls((IPart.WallType)1);
            this._worker.BuildWalls((IPart.WallType)1);
            this._worker.BuildDoor((IPart.DoorType)2);
            this._worker.BuildWindows((IPart.WindowType)3);
            this._worker.BuildWindows((IPart.WindowType)3);
            this._worker.BuildWindows((IPart.WindowType)3);
            this._worker.BuildWindows((IPart.WindowType)3);
            this._worker.BuildRoof((IPart.RoofType)2);
        }
    }
}