using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Drawing;
using System.Threading.Tasks;
using System.Windows;

namespace SHNSim_GUI
{
    public class environment : EntryPoint
    {

        public class region
        {
            public PointF[] vertices;
        }

        public class node
        {
            public List<region> regions;
            public PointF Location;
            public int condition;

            public node()
            {
                Location = new PointF();
                regions = new List<region>();
                condition = 0;

            }

            public node(float X, float Y)
            {
                Location = new PointF(X,Y);
                regions = new List<region>();
                condition = 0;
            }
            
        }
    }
}
