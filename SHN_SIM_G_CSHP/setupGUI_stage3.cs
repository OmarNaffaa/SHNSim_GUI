using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Diagnostics;
using System.IO;

namespace SHNSim_GUI
{
    public partial class setupGUI : Form
    {
        public void stageThreeInitialization()
        {
            numberOfNodes = nodeList.Count;
            this.Resize += stageThreeResize;

            display_Simulation_S3 = new PictureBox();
            display_Simulation_S3.Location = new Point(15, 15);
            display_Simulation_S3.Height = this.Size.Height - 70;
            display_Simulation_S3.Width = this.Size.Width - 440;
            display_Simulation_S3.BackColor = Color.White;
            display_Simulation_S3.BorderStyle = BorderStyle.FixedSingle;
            display_Simulation_S3.Paint += display_Simulation_S3_Paint;
            this.Controls.Add(display_Simulation_S3);

            display_objectProperties = new RichTextBox();
            display_objectProperties.Location = new Point(this.Size.Width - 410, 15);
            display_objectProperties.Height = this.Size.Height - 70;
            display_objectProperties.Width = 380;
            display_objectProperties.BorderStyle = BorderStyle.Fixed3D;
            display_objectProperties.BackColor = SystemColors.ControlLight;
            display_objectProperties.TabStop = false;
            display_objectProperties.Enabled = false;
            this.Controls.Add(display_objectProperties);


            int tab = 1;
            int height = 20;

            btn_goBack2 = new Button();
            btn_goBack2.Location = new Point(this.Size.Width - 405, height);
            btn_goBack2.Size = new Size(370, 45);
            btn_goBack2.TabIndex = tab++;
            btn_goBack2.Font = new Font(new FontFamily("Microsoft Sans Serif"), 16, FontStyle.Regular, GraphicsUnit.Pixel);
            btn_goBack2.Text = "Go back";
            btn_goBack2.BackColor = SystemColors.ControlDark;
            btn_goBack2.FlatAppearance.BorderColor = SystemColors.ControlDarkDark;
            btn_goBack2.FlatAppearance.BorderSize = 2;
            btn_goBack2.Click += btn_goBack2_Click;
            this.Controls.Add(btn_goBack2);
            btn_goBack2.BringToFront();

            height += 60;

            lbl_LengthOfSimulation = new Label();
            lbl_LengthOfSimulation.Location = new Point(this.Size.Width - 405, height + 3);
            lbl_LengthOfSimulation.Size = new Size(120, 13);
            lbl_LengthOfSimulation.Text = "Length of Simulation:";
            lbl_LengthOfSimulation.BackColor = lblColor;
            this.Controls.Add(lbl_LengthOfSimulation);
            lbl_LengthOfSimulation.BringToFront();

            height += 17;

            txtbx_LengthOfSimulation = new TextBox();
            txtbx_LengthOfSimulation.Location = new Point(this.Size.Width - 405, height);
            txtbx_LengthOfSimulation.Size = new Size(100, 20);
            txtbx_LengthOfSimulation.TabIndex = tab++;
            txtbx_LengthOfSimulation.Text = lengthOfSimulation.ToString();
            this.Controls.Add(txtbx_LengthOfSimulation);
            txtbx_LengthOfSimulation.BringToFront();


            height += 25;

            lbl_NumberOfDesiredSimulations = new Label();
            lbl_NumberOfDesiredSimulations.Location = new Point(this.Size.Width - 405, height + 3);
            lbl_NumberOfDesiredSimulations.Size = new Size(120, 13);
            lbl_NumberOfDesiredSimulations.Text = "Number of Simulations:";
            lbl_NumberOfDesiredSimulations.BackColor = lblColor;
            this.Controls.Add(lbl_NumberOfDesiredSimulations);
            lbl_NumberOfDesiredSimulations.BringToFront();

            height += 17;

            txtbx_NumberOfDesiredSimulations = new TextBox();
            txtbx_NumberOfDesiredSimulations.Location = new Point(this.Size.Width - 405, height);
            txtbx_NumberOfDesiredSimulations.Size = new Size(100, 20);
            txtbx_NumberOfDesiredSimulations.TabIndex = tab++;
            txtbx_NumberOfDesiredSimulations.Text = numberOfDesiredSimulations.ToString();
            this.Controls.Add(txtbx_NumberOfDesiredSimulations);
            txtbx_NumberOfDesiredSimulations.BringToFront();

            height += 25;

            lbl_FirstSimulationNumber = new Label();
            lbl_FirstSimulationNumber.Location = new Point(this.Size.Width - 405, height + 3);
            lbl_FirstSimulationNumber.Size = new Size(150, 13);
            lbl_FirstSimulationNumber.Text = "Simulation Starting Number:";
            lbl_FirstSimulationNumber.BackColor = lblColor;
            this.Controls.Add(lbl_FirstSimulationNumber);
            lbl_FirstSimulationNumber.BringToFront();

            height += 17;

            txtbx_FirstSimulationNumber = new TextBox();
            txtbx_FirstSimulationNumber.Location = new Point(this.Size.Width - 405, height);
            txtbx_FirstSimulationNumber.Size = new Size(100, 20);
            txtbx_FirstSimulationNumber.TabIndex = tab++;
            txtbx_FirstSimulationNumber.Text = firstSimulationNumber.ToString();
            this.Controls.Add(txtbx_FirstSimulationNumber);
            txtbx_FirstSimulationNumber.BringToFront();

            height += 25;

            lbl_SimulationSaveName = new Label();
            lbl_SimulationSaveName.Location = new Point(this.Size.Width - 405, height + 3);
            lbl_SimulationSaveName.Size = new Size(150, 13);
            lbl_SimulationSaveName.Text = "Simulation Save Name:";
            lbl_SimulationSaveName.BackColor = lblColor;
            this.Controls.Add(lbl_SimulationSaveName);
            lbl_SimulationSaveName.BringToFront();

            height += 17;

            txtbx_SimulationSaveName = new TextBox();
            txtbx_SimulationSaveName.Location = new Point(this.Size.Width - 405, height);
            txtbx_SimulationSaveName.Size = new Size(100, 20);
            txtbx_SimulationSaveName.TabIndex = tab++;
            txtbx_SimulationSaveName.Text = simulationSaveName;
            this.Controls.Add(txtbx_SimulationSaveName);
            txtbx_SimulationSaveName.BringToFront();

            height += 25;

            lbl_SHNSimPath = new Label();
            lbl_SHNSimPath.Location = new Point(this.Size.Width - 405, height + 3);
            lbl_SHNSimPath.Size = new Size(150, 13);
            lbl_SHNSimPath.Text = "SHNSim.exe path";
            lbl_SHNSimPath.BackColor = lblColor;
            this.Controls.Add(lbl_SHNSimPath);
            lbl_SHNSimPath.BringToFront();
            
            height += 17;

            txtbx_SHNSimPath = new RichTextBox();
            txtbx_SHNSimPath.Location = new Point(this.Size.Width - 405, height);
            txtbx_SHNSimPath.Size = new Size(370, 20);
            txtbx_SHNSimPath.TabIndex = tab++;
            txtbx_SHNSimPath.Text = SHNPathName;
            this.Controls.Add(txtbx_SHNSimPath);
            txtbx_SHNSimPath.BringToFront();




            btn_RunSimulation = new Button();
            btn_RunSimulation.Location = new Point(this.Size.Width - 405, this.Size.Height - 260);
            btn_RunSimulation.Size = new Size(370, 200);
            btn_RunSimulation.TabIndex = 0;
            btn_RunSimulation.Font = new Font(new FontFamily("Microsoft Sans Serif"), 16, FontStyle.Regular, GraphicsUnit.Pixel);
            btn_RunSimulation.Text = "Run Simulation";
            btn_RunSimulation.BackColor = SystemColors.ControlDark;
            btn_RunSimulation.FlatAppearance.BorderColor = SystemColors.ControlDarkDark;
            btn_RunSimulation.FlatAppearance.BorderSize = 2;
            btn_RunSimulation.Click += btn_RunSimulation_Click;
            btn_RunSimulation.Select();
            this.AcceptButton = btn_RunSimulation;
            this.Controls.Add(btn_RunSimulation);
            btn_RunSimulation.BringToFront();
            btn_RunSimulation.Select();
        }

        void stageThreeResize(object sender, EventArgs e)
        {
            display_Simulation_S3.Height = this.Size.Height - 70;
            display_Simulation_S3.Width = this.Size.Width - 440;
            display_objectProperties.Height = this.Size.Height - 70;
            display_objectProperties.Width = 380;

            int height = 0;
            display_Simulation_S3.Location = new Point(15, 15);
            display_objectProperties.Location = new Point(this.Size.Width - 410, 15);
            height += 20;
            btn_goBack2.Location = new Point(this.Size.Width - 405, height);
            height += 60;
            lbl_LengthOfSimulation.Location = new Point(this.Size.Width - 405, height + 3);
            height += 17;
            txtbx_LengthOfSimulation.Location = new Point(this.Size.Width - 405, height);
            height += 25;
            lbl_NumberOfDesiredSimulations.Location = new Point(this.Size.Width - 405, height + 3);
            height += 17;
            txtbx_NumberOfDesiredSimulations.Location = new Point(this.Size.Width - 405, height);
            height += 25;
            lbl_FirstSimulationNumber.Location = new Point(this.Size.Width - 405, height + 3);
            height += 17;
            txtbx_FirstSimulationNumber.Location = new Point(this.Size.Width - 405, height);
            height += 25;
            lbl_SimulationSaveName.Location = new Point(this.Size.Width - 405, height + 3);
            height += 17;
            txtbx_SimulationSaveName.Location = new Point(this.Size.Width - 405, height);
            height += 25;
            lbl_SHNSimPath.Location = new Point(this.Size.Width - 405, height + 3);
            height += 17;
            txtbx_SHNSimPath.Location = new Point(this.Size.Width - 405, height);

            btn_RunSimulation.Location = new Point(this.Size.Width - 405, this.Size.Height - 260);

            display_Simulation_S3.Invalidate();

        }

        private void btn_RunSimulation_Click(object sender, EventArgs e)
        {

            bool canMoveFoward = true;

            if (!(int.TryParse(txtbx_LengthOfSimulation.Text, out lengthOfSimulation) && lengthOfSimulation < 1000000 && lengthOfSimulation > 0))
            {
                txtbx_LengthOfSimulation.BackColor = Color.Goldenrod;
                canMoveFoward = false;
            }
            else
                txtbx_LengthOfSimulation.BackColor = SystemColors.Window;

            if (!(int.TryParse(txtbx_NumberOfDesiredSimulations.Text, out numberOfDesiredSimulations) && numberOfDesiredSimulations < 1000 && numberOfDesiredSimulations > 0))
            {
                txtbx_NumberOfDesiredSimulations.BackColor = Color.Goldenrod;
                canMoveFoward = false;
            }
            else
                txtbx_NumberOfDesiredSimulations.BackColor = SystemColors.Window;

            if (!(int.TryParse(txtbx_FirstSimulationNumber.Text, out firstSimulationNumber) && firstSimulationNumber < 1000 && firstSimulationNumber >= 0))
            {
                txtbx_FirstSimulationNumber.BackColor = Color.Goldenrod;
                canMoveFoward = false;
            }
            else
                txtbx_FirstSimulationNumber.BackColor = SystemColors.Window;

            simulationSaveName = txtbx_SimulationSaveName.Text;
            if (simulationSaveName.Length < 3 || simulationSaveName.Contains('>') || simulationSaveName.Contains('<') || simulationSaveName.Contains(':') || simulationSaveName.Contains('"') || simulationSaveName.Contains('/') || simulationSaveName.Contains('\\') || simulationSaveName.Contains('|') || simulationSaveName.Contains('?') || simulationSaveName.Contains('*'))
            {
                txtbx_SimulationSaveName.BackColor = Color.Goldenrod;
                canMoveFoward = false;
            }
            else
                txtbx_SimulationSaveName.BackColor = SystemColors.Window;

            string temp_SHNPathName = txtbx_SHNSimPath.Text;
            if (temp_SHNPathName.LastIndexOf("SHNSim.exe") != -1 && File.Exists(temp_SHNPathName))
            {
                SHNPathName = temp_SHNPathName;
                txtbx_SHNSimPath.BackColor = SystemColors.Window;
            }
            else if (File.Exists(temp_SHNPathName + "\\SHNSim.exe"))
            {
                SHNPathName = temp_SHNPathName + "\\SHNSim.exe";
                txtbx_SHNSimPath.BackColor = SystemColors.Window;
            }
            else if (File.Exists("SHNSim.exe"))
            {
                SHNPathName = "SHNSim.exe";
                txtbx_SHNSimPath.BackColor = SystemColors.Window;
            }
            else
            {
                txtbx_SHNSimPath.BackColor = Color.Goldenrod;
                canMoveFoward = false;
            }



            if (canMoveFoward)
                callSHNSim();
        }

        private void callSHNSim()
        {
            string arguments = numberOfNodes.ToString() + ' ';

            foreach (environment.node n in nodeList)
            {
                arguments += n.condition.ToString() + ' ';
            }

            foreach (Point p in nodeAndSideSelect)
            {
                arguments += p.X.ToString() + ' ' + p.Y.ToString() + ' ';
            }

            arguments += shapeSideLength.ToString() + ' ';
            arguments += numberOfAntenna.ToString() + ' ';
            arguments += numberOfTranceivers.ToString() + ' ';
            arguments += distanceBetweenTranceivers.ToString() + ' ';
            arguments += UEmaxDataRate.ToString() + ' ';
            arguments += normalUEperAnt.ToString() + ' ';
            arguments += lengthOfSimulation.ToString() + ' ';
            arguments += numberOfDesiredSimulations.ToString() + ' ';
            arguments += firstSimulationNumber.ToString() + ' ';
            arguments += simulationSaveName + ' ';


            ProcessStartInfo shn = new ProcessStartInfo(SHNPathName);

            shn.Arguments = arguments;
            shn.WindowStyle = ProcessWindowStyle.Maximized;
            Process.Start(shn);
        }

        private void btn_goBack2_Click(object sender, EventArgs e)
        {
            int temp_lengthOfSimulation;
            if (int.TryParse(txtbx_LengthOfSimulation.Text, out temp_lengthOfSimulation) && temp_lengthOfSimulation < 1000000 && temp_lengthOfSimulation > 0)
            {
                lengthOfSimulation = temp_lengthOfSimulation;
            }

            int temp_numberOfDesiredSimulations;
            if (int.TryParse(txtbx_NumberOfDesiredSimulations.Text, out temp_numberOfDesiredSimulations) && temp_numberOfDesiredSimulations < 1000 && temp_numberOfDesiredSimulations > 0)
            {
                numberOfDesiredSimulations = temp_numberOfDesiredSimulations;
            }

            int temp_firstSimulationNumber;
            if (int.TryParse(txtbx_FirstSimulationNumber.Text, out temp_firstSimulationNumber) && temp_firstSimulationNumber < 1000 && temp_firstSimulationNumber >= 0)
            {
                firstSimulationNumber = temp_firstSimulationNumber;
            }

            string temp_simulationSaveName = txtbx_SimulationSaveName.Text;
            if (!(simulationSaveName.Length < 3 || simulationSaveName.Contains('>') || simulationSaveName.Contains('<') || simulationSaveName.Contains(':') || simulationSaveName.Contains('"') || simulationSaveName.Contains('/') || simulationSaveName.Contains('\\') || simulationSaveName.Contains('|') || simulationSaveName.Contains('?') || simulationSaveName.Contains('*')))
            {
                simulationSaveName = txtbx_SimulationSaveName.Text;
            }

            foreach (Control c in this.Controls)
                c.Hide();

            this.Resize -= stageThreeResize;
            stageTwoInitialization(true);
        }

        private void display_Simulation_S3_Paint(object sender, PaintEventArgs e)
        {
            scaledDisplayItems = new List<PointF[]>();
            PointF displayDim = new PointF(display_Simulation_S3.Width - 3, display_Simulation_S3.Height - 3);
            PointF upperLeft_GridRectangleOverlapPointF;
            PointF rectangle;
            getTotalRegionOutliningRectangle(out rectangle, out upperLeft_GridRectangleOverlapPointF);
            bool XisTheHighestProportionalSide;
            float scalingFactor = getScalingFactor(rectangle, displayDim, out XisTheHighestProportionalSide);
            PointF upperLeft_RectangleDisplayOverlapPointF = centerRectangle(scalingFactor, XisTheHighestProportionalSide, displayDim, rectangle);

            PointF[] rectanglePointFs =
                {
                    upperLeft_RectangleDisplayOverlapPointF,
                    new PointF((int)(upperLeft_RectangleDisplayOverlapPointF.X + scalingFactor*rectangle.X), upperLeft_RectangleDisplayOverlapPointF.Y),
                    new PointF((int)(upperLeft_RectangleDisplayOverlapPointF.X + scalingFactor*rectangle.X), (int)(upperLeft_RectangleDisplayOverlapPointF.Y + scalingFactor*rectangle.Y)),
                    new PointF(upperLeft_RectangleDisplayOverlapPointF.X, (int)(upperLeft_RectangleDisplayOverlapPointF.Y + scalingFactor*rectangle.Y))
                };

            foreach (PointF[] displayItem in displayItems)
            {
                PointF[] scaledDisplayItem = new PointF[displayItem.Length];
                for (int i = 0; i < displayItem.Length; i++)
                {
                    scaledDisplayItem[i].X = (int)(scalingFactor * (displayItem[i].X - upperLeft_GridRectangleOverlapPointF.X) + upperLeft_RectangleDisplayOverlapPointF.X);
                    scaledDisplayItem[i].Y = (int)(scalingFactor * (displayItem[i].Y - upperLeft_GridRectangleOverlapPointF.Y) + upperLeft_RectangleDisplayOverlapPointF.Y);
                }
                scaledDisplayItems.Add(scaledDisplayItem);
            }


            List<PointF> scaledNodeLocations = new List<PointF>();
            foreach (environment.node n in nodeList)
            {
                PointF scaledN = new PointF(
                                                scalingFactor * (n.Location.X - upperLeft_GridRectangleOverlapPointF.X) + upperLeft_RectangleDisplayOverlapPointF.X,
                                                scalingFactor * (n.Location.Y - upperLeft_GridRectangleOverlapPointF.Y) + upperLeft_RectangleDisplayOverlapPointF.Y
                                            );
                scaledNodeLocations.Add(scaledN);
            }

            // Create pen.
            Pen blackPen = new Pen(Color.Black, 4);
            // Draw polygon to screen.
            //e.Graphics.DrawPolygon(blackPen, rectanglePointFs);

            for (int i = 0; i < scaledDisplayItems.Count; i++)
            {
                e.Graphics.DrawPolygon(blackPen, scaledDisplayItems[i]);
                if (nodeList[i].condition == 0)
                    e.Graphics.FillPolygon(new SolidBrush(Color.LightGreen), scaledDisplayItems[i]);
                else if (nodeList[i].condition == 1)
                    e.Graphics.FillPolygon(new SolidBrush(Color.LightGray), scaledDisplayItems[i]);
                else if (nodeList[i].condition == 2)
                    e.Graphics.FillPolygon(new SolidBrush(Color.LightSalmon), scaledDisplayItems[i]);
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

        }
    }
}
