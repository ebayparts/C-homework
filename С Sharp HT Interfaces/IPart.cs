using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace С_Sharp_HT_Interfaces
{
    interface IPart
    {
        enum BasementType
        {
            Tape,
            Modular,
            Columnar,
            Solid,
            Welded
        }
        enum WallType
        {
            Brick,
            Wood,
            Concrete
        }
        enum RoofType
        {
            Slate,
            Metal,
            Rubber,
            Ceramic
        }
        enum WindowType : int
        {
            Wood,
            uPVC,
            Aluminum,
            Composite,
            Steel,
            Fiberglass
        }
        enum DoorType
        {
            Wood,
            uPVC,
            Aluminum,
            Composite,
            Steel,
            Fiberglass
        }
    }
}
