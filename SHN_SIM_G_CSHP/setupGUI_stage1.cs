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

        public setupGUI()
        {
            InitializeComponent();
            stageOneInitialization(false);
        }

        public void stageOneInitialization(bool comingBack)
        {
            if (!comingBack)
            {
                nodeList = new List<environment.node>();
                nodeAndSideSelect = new List<Point>();
                displayItems = new List<PointF[]>();
                scaledDisplayItems = new List<PointF[]>();
            }

            this.Size = new Size(Screen.PrimaryScreen.WorkingArea.Width - 100, Screen.PrimaryScreen.WorkingArea.Height - 30);

            display_Simulation_S1 = new PictureBox();
            display_Simulation_S1.Location = new Point(15, 15);

            display_Simulation_S1.Size = new Size(this.Width-45, this.Height - 100);
            display_Simulation_S1.BackColor = Color.White;
            display_Simulation_S1.BorderStyle = BorderStyle.FixedSingle;
            display_Simulation_S1.Paint += display_Simulation_S1_Paint;
            display_Simulation_S1.MouseEnter += pict_bx_createEnvironmentLayout_mouseEnter;
            display_Simulation_S1.MouseLeave += pict_bx_createEnvironmentLayout_mouseLeave;
            display_Simulation_S1.MouseMove += pict_bx_createEnvironmentLayout_mouseMove;
            display_Simulation_S1.MouseClick += genAdjNode_click;
            this.Controls.Add(display_Simulation_S1);

            btn_prevNode = new Button();
            btn_prevNode.TabIndex = 3;
            btn_prevNode.Location = new Point(15, this.Height - 80);
            btn_prevNode.Text = "Prev Node";
            btn_prevNode.Click += btn_prevNode_press;
            this.Controls.Add(btn_prevNode);


            btn_nextNode = new Button();
            btn_nextNode.TabIndex = 4;
            btn_nextNode.Location = new Point(105, this.Height - 80);
            btn_nextNode.Text = "Next Node";
            btn_nextNode.Click += btn_nextNode_press;
            this.Controls.Add(btn_nextNode);

            btn_finishEnvCreate = new Button();
            btn_finishEnvCreate.TabIndex = 0;
            btn_finishEnvCreate.Location = new Point(this.Width - 105, this.Height - 80);
            btn_finishEnvCreate.Text = "Finish";
            btn_finishEnvCreate.Click += stageOneFinished;
            this.AcceptButton = btn_finishEnvCreate;
            this.Controls.Add(btn_finishEnvCreate);
            btn_finishEnvCreate.Select();


            lbl_updateCondition = new Label();
            lbl_updateCondition.Location = new Point(195, this.Height - 80);
            lbl_updateCondition.Text = "Condition:";
            lbl_updateCondition.Width = 55;
            lbl_updateCondition.Height = 23;
            lbl_updateCondition.TextAlign = ContentAlignment.MiddleRight;
            this.Controls.Add(lbl_updateCondition);

            txtbx_nodeCondition = new TextBox();
            txtbx_nodeCondition.TabIndex = 5;
            txtbx_nodeCondition.Location = new Point(250, this.Height - 78);
            this.Controls.Add(txtbx_nodeCondition);

            btn_updateCondition = new Button();
            btn_updateCondition.TabIndex = 6;
            btn_updateCondition.Location = new Point(355, this.Height - 80);
            btn_updateCondition.Width = 100;
            btn_updateCondition.Text = "Update Condition";
            btn_updateCondition.Click += btn_updateCondition_press;
            this.Controls.Add(btn_updateCondition);

            if (!comingBack)
                createFirstNode();
            else
            {
                selectedNode = 0;
                selectedSide = 0;
                updateDisplay();
            }
        }

        private void createFirstNode()
        {

            environment.node firstNode = new environment.node(0, 0);
            environment.region hex = new environment.region();
            hex.vertices = new PointF[6];

            for (int i = 0; i < 6; i++)
            {
                hex.vertices[i] = new PointF(0 + sideLength * (float)Math.Cos(i * (Math.PI / 3) - ((2 * Math.PI) / 3)), 0 + sideLength * (float)Math.Sin(i * (Math.PI / 3) - ((2 * Math.PI) / 3)));
            }

            firstNode.regions.Add(hex);
            nodeList.Add(firstNode);

            txtbx_nodeCondition.Text = nodeList[selectedNode].condition.ToString();

            displayItems = new List<PointF[]>();
            foreach (environment.node n in nodeList)
            {
                //PointF[] loc = { n.Location };
                //displayItems.Add(loc);
                foreach (environment.region r in n.regions)
                {
                    displayItems.Add(r.vertices);
                }
            }

            updateDisplay();
        }

        private void btn_updateCondition_press(object sender, EventArgs e)
        {
            int newCondition;
            if (int.TryParse(txtbx_nodeCondition.Text, out newCondition) && newCondition >= 0 && newCondition < 3)
            {
                nodeList[selectedNode].condition = newCondition;
            }
            else
                txtbx_nodeCondition.Text = "";

            updateDisplay();
        }

        private void btn_prevNode_press(object sender, EventArgs e)
        {
            if (selectedNode < nodeList.Count && selectedNode > 0)
                selectedNode--;
            else if (selectedNode < nodeList.Count && selectedNode == 0)
                selectedNode = nodeList.Count - 1;
            else if (nodeList.Count > 0)
                selectedNode = 0;

            updateDisplay();

        }

        private void btn_nextNode_press(object sender, EventArgs e)
        {
            if (selectedNode < nodeList.Count && selectedNode < nodeList.Count - 1)
                selectedNode++;
            else if (nodeList.Count > 0 && selectedNode == nodeList.Count - 1)
                selectedNode = 0;
            else if (nodeList.Count > 0)
                selectedNode = 0;

            updateDisplay();
        }

        private void genAdjNode_click(object sender, EventArgs e)
        {

            Point newNodeSidePair = new Point(selectedNode, selectedSide);
            nodeAndSideSelect.Add(newNodeSidePair);

            float distBtwnTwoHex = (float)(Math.Sqrt(3) * sideLength);


            environment.node nextNode = new environment.node((float)(nodeList[selectedNode].Location.X + distBtwnTwoHex * Math.Cos(-1 * (Math.PI / 2) + (selectedSide * (Math.PI / 3)))), (float)(nodeList[selectedNode].Location.Y + distBtwnTwoHex * Math.Sin(-1 * (Math.PI / 2) + (selectedSide * (Math.PI / 3)))));

            foreach (environment.node n in nodeList)
            {
                if (Math.Sqrt((Math.Pow(nextNode.Location.X - n.Location.X, 2)) + (Math.Pow(nextNode.Location.Y - n.Location.Y, 2))) < sideLength)
                    return;
            }

            environment.region hex = new environment.region();
            hex.vertices = new PointF[6];

            for (int i = 0; i < 6; i++)
            {
                hex.vertices[i] = new PointF(nextNode.Location.X + sideLength * (float)Math.Cos(i * (Math.PI / 3) - ((2 * Math.PI) / 3)), nextNode.Location.Y + sideLength * (float)Math.Sin(i * (Math.PI / 3) - ((2 * Math.PI) / 3)));
            }

            foreach (environment.node n in nodeList)
            {
                foreach (environment.region r in n.regions)
                {
                    foreach (PointF r_p in r.vertices)
                    {
                        for (int i = 0; i < 6; i++)
                        {

                            if ((hex.vertices[i].X - r_p.X) < (.1) * sideLength && hex.vertices[i].X - r_p.X > -(.1) * sideLength && (hex.vertices[i].Y - r_p.Y) < (.1) * sideLength && (hex.vertices[i].Y - r_p.Y) > -(.1) * sideLength)
                            {
                                hex.vertices[i].X = r_p.X;
                                hex.vertices[i].Y = r_p.Y;
                            }
                        }
                    }
                }
            }

            nextNode.regions.Add(hex);
            nodeList.Add(nextNode);
            selectedNode = nodeList.Count - 1;

            displayItems = new List<PointF[]>();
            foreach (environment.node n in nodeList)
            {
                //PointF[] loc = { n.Location };
                //displayItems.Add(loc);
                foreach (environment.region r in n.regions)
                {
                    displayItems.Add(r.vertices);
                }
            }

            updateDisplay();
        }

        private void pict_bx_createEnvironmentLayout_mouseEnter(object sender, EventArgs e)
        {
            updateDisplay();
        }

        private void pict_bx_createEnvironmentLayout_mouseLeave(object sender, EventArgs e)
        {
            updateDisplay();
        }

        private void pict_bx_createEnvironmentLayout_mouseMove(object sender, EventArgs e)
        {
            updateDisplay();
        }

        public void updateDisplay()
        {
            display_Simulation_S1.Invalidate();
            txtbx_nodeCondition.Text = nodeList[selectedNode].condition.ToString();
        }

        private void display_Simulation_S1_Paint(object sender, PaintEventArgs e)
        {

            scaledDisplayItems = new List<PointF[]>();
            PointF displayDim = new PointF(display_Simulation_S1.Width - 3, display_Simulation_S1.Height - 3);
            PointF upperLeft_GridRectangleOverlapPointF;
            PointF rectangle;
            getTotalRegionOutliningRectangle(out rectangle, out upperLeft_GridRectangleOverlapPointF);
            bool XisTheHighestProportionalSide;
            float scalingFactor = getScalingFactor(rectangle, displayDim, out XisTheHighestProportionalSide);
            PointF upperLeft_RectangleDisplayOverlapPointF = centerRectangle(scalingFactor, XisTheHighestProportionalSide, displayDim, rectangle);

            PointF[] rectanglePointFs =
                {
                    upperLeft_RectangleDisplayOverlapPointF,
                    new PointF((upperLeft_RectangleDisplayOverlapPointF.X + scalingFactor*rectangle.X), upperLeft_RectangleDisplayOverlapPointF.Y),
                    new PointF((upperLeft_RectangleDisplayOverlapPointF.X + scalingFactor*rectangle.X), (upperLeft_RectangleDisplayOverlapPointF.Y + scalingFactor*rectangle.Y)),
                    new PointF(upperLeft_RectangleDisplayOverlapPointF.X, (upperLeft_RectangleDisplayOverlapPointF.Y + scalingFactor*rectangle.Y))
                };
            

            foreach (PointF[] displayItem in displayItems)
            {
                PointF[] scaledDisplayItem = new PointF[displayItem.Length];
                for (int i = 0; i < displayItem.Length; i++)
                {
                    scaledDisplayItem[i].X = (scalingFactor * (displayItem[i].X - upperLeft_GridRectangleOverlapPointF.X) + upperLeft_RectangleDisplayOverlapPointF.X);
                    scaledDisplayItem[i].Y = (scalingFactor * (displayItem[i].Y - upperLeft_GridRectangleOverlapPointF.Y) + upperLeft_RectangleDisplayOverlapPointF.Y);
                }
                scaledDisplayItems.Add(scaledDisplayItem);
            }

            List<PointF> scaledNodeLocations = new List<PointF>();
            foreach(environment.node n in nodeList)
            {
                PointF scaledN = new PointF (
                                                scalingFactor * (n.Location.X - upperLeft_GridRectangleOverlapPointF.X) + upperLeft_RectangleDisplayOverlapPointF.X,
                                                scalingFactor * (n.Location.Y - upperLeft_GridRectangleOverlapPointF.Y) + upperLeft_RectangleDisplayOverlapPointF.Y
                                            );
                scaledNodeLocations.Add(scaledN);
            }
            
            Pen blackPen = new Pen(Color.Black, 3);

            //e.Graphics.DrawPolygon(blackPen, rectanglePointFs);

            for (int i = 0; i < scaledDisplayItems.Count; i++)
            {
                if (i == selectedNode)
                {
                    if (nodeList[i].condition == 0)
                        e.Graphics.FillPolygon(new SolidBrush(Color.Green), scaledDisplayItems[i]);
                    else if (nodeList[i].condition == 1)
                        e.Graphics.FillPolygon(new SolidBrush(Color.Gray), scaledDisplayItems[i]);
                    else if (nodeList[i].condition == 2)
                        e.Graphics.FillPolygon(new SolidBrush(Color.Red), scaledDisplayItems[i]);
                }
                else
                {
                    if (nodeList[i].condition == 0)
                        e.Graphics.FillPolygon(new SolidBrush(Color.LightGreen), scaledDisplayItems[i]);
                    else if (nodeList[i].condition == 1)
                        e.Graphics.FillPolygon(new SolidBrush(Color.LightGray), scaledDisplayItems[i]);
                    else if (nodeList[i].condition == 2)
                        e.Graphics.FillPolygon(new SolidBrush(Color.LightSalmon), scaledDisplayItems[i]);
                }

                e.Graphics.DrawPolygon(blackPen, scaledDisplayItems[i]);

            }

            int node = 0;
            Font nodeFont = new Font("Arial", 14);
            Brush nodeBrush = new SolidBrush(Color.DarkBlue);
            Image fakeImage = new Bitmap(1, 1); //As we cannot use CreateGraphics() in a class library, so the fake image is used to load the Graphics.
            Graphics graphics = Graphics.FromImage(fakeImage);
            SizeF size = graphics.MeasureString("0", nodeFont);
            foreach (PointF p in scaledNodeLocations)
            {
                e.Graphics.DrawString(node.ToString(), nodeFont, nodeBrush, p.X - size.Width / 2, p.Y - size.Height / 2);
                node++;
            }

            if (scaledDisplayItems.Count > selectedNode)
            {

                if (scaledDisplayItems[selectedNode].Length == 6)
                {
                    Point displayBox_ScreenCoordLoc = display_Simulation_S1.PointToScreen(display_Simulation_S1.Location);
                    Point convertedMouseCoords = new Point(MousePosition.X - displayBox_ScreenCoordLoc.X + 15, MousePosition.Y - displayBox_ScreenCoordLoc.Y + 15);
                    PointF mouseVector = new PointF(convertedMouseCoords.X - scaledNodeLocations[selectedNode].X, convertedMouseCoords.Y - scaledNodeLocations[selectedNode].Y);
                    PointF axisVector = new PointF(1, 0);
                    double dotProduct = mouseVector.X * axisVector.X + mouseVector.Y * axisVector.Y;
                    double magMouseCoords = Math.Sqrt(Math.Pow(mouseVector.X, 2) + Math.Pow(mouseVector.Y, 2));
                    double theta = Math.Acos(dotProduct / magMouseCoords);
                    
                    if (convertedMouseCoords.Y > scaledNodeLocations[selectedNode].Y)
                        theta = 2*Math.PI - theta;
                    theta *= 3 / Math.PI;
                    //e.Graphics.DrawLine(blackPen, convertedMouseCoords.X, convertedMouseCoords.Y, scaledNodeLocations[selectedNode].X, scaledNodeLocations[selectedNode].Y);
                    //e.Graphics.DrawLine(blackPen, scaledNodeLocations[selectedNode].X, scaledNodeLocations[selectedNode].Y, scaledNodeLocations[selectedNode].X + 30, scaledNodeLocations[selectedNode].Y);
                    //e.Graphics.DrawString(theta.ToString(), nodeFont, nodeBrush, 15, 15);
                    //e.Graphics.DrawString(scaledNodeLocations[selectedNode].ToString(), nodeFont, nodeBrush, 15, 35);
                    //e.Graphics.DrawString(MousePosition.ToString(), nodeFont, nodeBrush, 15, 55);
                    //e.Graphics.DrawString(convertedMouseCoords.ToString(), nodeFont, nodeBrush, 15, 55);
                    //e.Graphics.DrawString(mouseVector.ToString(), nodeFont, nodeBrush, 15, 75);

                    PointF pOne, pTwo;
                    
                    if (theta <= 1 && theta > 0)
                    {
                        pOne = scaledDisplayItems[selectedNode][1];
                        pTwo = scaledDisplayItems[selectedNode][2];
                        selectedSide = 1;
                        //e.Graphics.DrawString("Side 0", nodeFont, nodeBrush, 15, 95);
                    }
                    else if (theta <= 2 && theta > 1)
                    {
                        pOne = scaledDisplayItems[selectedNode][0];
                        pTwo = scaledDisplayItems[selectedNode][1];
                        selectedSide = 0;
                        //e.Graphics.DrawString("Side 1", nodeFont, nodeBrush, 15, 95);
                    }
                    else if (theta <= 3 && theta > 2)
                    {
                        pOne = scaledDisplayItems[selectedNode][5];
                        pTwo = scaledDisplayItems[selectedNode][0];
                        selectedSide = 5;
                        //e.Graphics.DrawString("Side 2", nodeFont, nodeBrush, 15, 95);
                    }
                    else if (theta <= 4 && theta > 3)
                    {
                        pOne = scaledDisplayItems[selectedNode][4];
                        pTwo = scaledDisplayItems[selectedNode][5];
                        selectedSide = 4;
                        //e.Graphics.DrawString("Side 3", nodeFont, nodeBrush, 15, 95);
                    }
                    else if (theta <= 5 && theta > 4)
                    {
                        pOne = scaledDisplayItems[selectedNode][3];
                        pTwo = scaledDisplayItems[selectedNode][4];
                        selectedSide = 3;
                        //e.Graphics.DrawString("Side 4", nodeFont, nodeBrush, 15, 95);
                    }
                    else if (theta <= 6 && theta > 5)
                    {
                        pOne = scaledDisplayItems[selectedNode][2];
                        pTwo = scaledDisplayItems[selectedNode][3];
                        selectedSide = 2;
                        //e.Graphics.DrawString("Side 5", nodeFont, nodeBrush, 15, 95);
                    }
                    else
                    {
                        pOne = scaledDisplayItems[selectedNode][0];
                        pTwo = scaledDisplayItems[selectedNode][1];
                        selectedSide = 1;
                        //e.Graphics.DrawString("Side Error", nodeFont, nodeBrush, 15, 95);
                    }

                    e.Graphics.DrawLine(new Pen(Color.Red, 6), pOne.X, pOne.Y, pTwo.X, pTwo.Y);

                }
            }
            
        }

        private void stageOneFinished(object sender, EventArgs e)
        {
            foreach (Control c in this.Controls)
                c.Hide();
                
            stageTwoInitialization(false);
        }
    }
}
