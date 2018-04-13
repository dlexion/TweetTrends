using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Mapping
{
    class StatesReader
    {
        public static List<State> Read(string path)
        {
            List<State> states = new List<State>();

            using (StreamReader sr = new StreamReader(path))
            {
                string line;
                int i = 0;
                string name = String.Empty;
                List<List<PointF>> polygons = new List<List<PointF>>();
                List<PointF> points = new List<PointF>();

                while ((line = sr.ReadLine()) != null)
                {
                    try
                    {
                        if ((line = line.Trim(new char[] { ' ', ',' })).StartsWith("\""))
                        {
                            if (polygons.Count > 0)
                            {
                                i = 0;
                                states.Add(new State(name, polygons));
                                polygons = new List<List<PointF>>();
                                points = new List<PointF>();

                            }
                            name = line.Trim(new char[] { '\\', '"', '[', ' ', ':' });
                        }
                        else
                        {
                            float temp = Convert.ToSingle(line.Replace('.', ','));
                            points.Add(new PointF(temp * 10 + 1800, Convert.ToSingle(line = sr.ReadLine().Trim().Replace('.', ',')) * -10 + 750));

                            if (points[0] == points[points.Count - 1] && points.Count > 1)
                            {
                                polygons.Add(points);
                                points = new List<PointF>();
                            }
                        }

                    }
                    catch (Exception e)
                    {

                    }
                }
                states.Add(new State(name, polygons));
                return states;
            }
        }
    }
}
