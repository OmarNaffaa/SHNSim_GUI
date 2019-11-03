using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SHNSim_GUI
{
    public partial class setupGUI : Form
    {
        private void getTotalRegionOutliningRectangle(out PointF rectangle, out PointF upperLeftGridPointF)
        {
            rectangle = new PointF(70, 50);
            upperLeftGridPointF = new PointF(5, 5);

            if (displayItems.Count > 0)
            {
                if (displayItems[0].Length > 0)
                {
                    PointF smallest = displayItems[0][0];
                    PointF largest = displayItems[0][0];
                    foreach (PointF[] displayItem in displayItems)
                    {
                        for (int i = 0; i < displayItem.Length; i++)
                        {
                            if (displayItem[i].X < smallest.X)
                                smallest.X = displayItem[i].X;
                            if (displayItem[i].Y < smallest.Y)
                                smallest.Y = displayItem[i].Y;

                            if (displayItem[i].X > largest.X)
                                largest.X = displayItem[i].X;
                            if (displayItem[i].Y > largest.Y)
                                largest.Y = displayItem[i].Y;
                        }
                    }
                    float width = 1.1F * (largest.X - smallest.X);
                    float height = 1.1F * (largest.Y - smallest.Y);
                    rectangle = new PointF(width, height);
                    upperLeftGridPointF = new PointF((smallest.X - .05F * (largest.X - smallest.X)), (smallest.Y - .05F * (largest.Y - smallest.Y)));

                }
            }


        }

        private float getScalingFactor(PointF rectangle, PointF displayDim, out bool XisTheHighestProportionSide)
        {
            if ((float)rectangle.X / (float)displayDim.X > (float)rectangle.Y / (float)displayDim.Y)
            {
                XisTheHighestProportionSide = true;
                return (float)displayDim.X / (float)rectangle.X;
            }
            else
            {
                XisTheHighestProportionSide = false;
                return (float)displayDim.Y / (float)rectangle.Y;
            }
        }

        private PointF centerRectangle(float scalingFactor, bool XisTheHighestProportionalSide, PointF displayDim, PointF rectangle)
        {
            PointF rectangleDisplayOverlapPointF = new PointF();

            if (XisTheHighestProportionalSide)
            {
                rectangleDisplayOverlapPointF.X = 0;
                rectangleDisplayOverlapPointF.Y = (float)Math.Round((displayDim.Y / 2 - ((scalingFactor * rectangle.Y) / 2)), 0);
            }
            else
            {
                rectangleDisplayOverlapPointF.X = (float)Math.Round((displayDim.X / 2 - ((scalingFactor * rectangle.X) / 2)), 0);
                rectangleDisplayOverlapPointF.Y = 0;
            }

            return rectangleDisplayOverlapPointF;
        }

    }
}
