using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Mapping
{
    class State
    {
        public List<List<PointF>> Polygons { get; set; }
        public string Name { get; set; }

        public State(string name, List<List<PointF>> points)
        {
            Name = name;
            Polygons = points;
        }
    }
}
