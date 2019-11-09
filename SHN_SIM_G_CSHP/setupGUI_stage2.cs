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
        public void stageTwoInitialization(bool comingBack)
        {

            Color lblColor = Color.FromArgb(0xf0, 0xf0, 0xf0);
            /*****************************************************************************************/
            this.Size = new Size(Screen.PrimaryScreen.WorkingArea.Width - 100, Screen.PrimaryScreen.WorkingArea.Height - 30);

            display_Simulation_S2 = new PictureBox();
            display_Simulation_S2.Location = new Point(15, 15);
            display_Simulation_S2.Height = this.Size.Height - 70;
            display_Simulation_S2.Width = this.Size.Width - 240;
            display_Simulation_S2.BackColor = Color.White;
            display_Simulation_S2.BorderStyle = BorderStyle.FixedSingle;
            display_Simulation_S2.Paint += display_Simulation_S2_Paint;
            this.Controls.Add(display_Simulation_S2);

            display_objectProperties = new RichTextBox();
            display_objectProperties.Location = new Point(this.Size.Width - 200, 15);
            display_objectProperties.Height = this.Size.Height - 70;
            display_objectProperties.Width = 170;
            display_objectProperties.BorderStyle = BorderStyle.Fixed3D;
            display_objectProperties.BackColor = SystemColors.ControlLight;
            display_objectProperties.TabStop = false;
            display_objectProperties.Enabled = false;
            this.Controls.Add(display_objectProperties);


            /*****************************************************************************************/


            int tab = 1;
            int height = 20;

            btn_goBack = new Button();
            btn_goBack.Location = new Point(this.Size.Width - 195, height);
            btn_goBack.Size = new Size(160, 45);
            btn_goBack.TabIndex = tab++;
            btn_goBack.Font = new Font(new FontFamily("Microsoft Sans Serif"), 16, FontStyle.Regular, GraphicsUnit.Pixel);
            btn_goBack.Text = "Go back";
            btn_goBack.BackColor = SystemColors.ControlDark;
            btn_goBack.FlatAppearance.BorderColor = SystemColors.ControlDarkDark;
            btn_goBack.FlatAppearance.BorderSize = 2;
            btn_goBack.Click += btn_goBack_Click;
            this.Controls.Add(btn_goBack);
            btn_goBack.BringToFront();
            btn_goBack.Select();

            height += 60;

            lbl_BSRegionSide = new Label();
            lbl_BSRegionSide.Location = new Point(this.Size.Width - 195, height);
            lbl_BSRegionSide.Size = new Size(99, 13);
            lbl_BSRegionSide.Text = "BS Side Length";
            lbl_BSRegionSide.BackColor = lblColor;
            this.Controls.Add(lbl_BSRegionSide);
            lbl_BSRegionSide.BringToFront();

            height += 15;

            lbl_BSRegionSideConstraints = new Label();
            lbl_BSRegionSideConstraints.Location = new Point(this.Size.Width - 195, height);
            lbl_BSRegionSideConstraints.Size = new Size(99, 13);
            lbl_BSRegionSideConstraints.Text = "5 < n < 20";
            lbl_BSRegionSideConstraints.BackColor = lblColor;
            this.Controls.Add(lbl_BSRegionSideConstraints);
            lbl_BSRegionSideConstraints.BringToFront();

            height += 17;

            txtbx_BSRegionSide = new TextBox();
            txtbx_BSRegionSide.Location = new Point(this.Size.Width - 195, height);
            txtbx_BSRegionSide.Size = new Size(100, 20);
            txtbx_BSRegionSide.TabIndex = tab++;
            txtbx_BSRegionSide.Text = shapeSideLength.ToString();
            this.Controls.Add(txtbx_BSRegionSide);
            txtbx_BSRegionSide.BringToFront();


            /*****************************************************************************************/


            height += 25;

            lbl_numAntenna = new Label();
            lbl_numAntenna.Location = new Point(this.Size.Width - 195, height);
            lbl_numAntenna.Size = new Size(99, 13);
            lbl_numAntenna.Text = "Number of Antenna";
            lbl_numAntenna.BackColor = lblColor;
            this.Controls.Add(lbl_numAntenna);
            lbl_numAntenna.BringToFront();

            height += 15;

            lbl_numAntennaConstraints = new Label();
            lbl_numAntennaConstraints.Location = new Point(this.Size.Width - 195, height);
            lbl_numAntennaConstraints.Size = new Size(99, 13);
            lbl_numAntennaConstraints.Text = "1 < n < 6";
            lbl_numAntennaConstraints.BackColor = lblColor;
            this.Controls.Add(lbl_numAntennaConstraints);
            lbl_numAntennaConstraints.BringToFront();

            height += 17;

            txtbx_numAntenna = new TextBox();
            txtbx_numAntenna.Location = new Point(this.Size.Width - 195, height);
            txtbx_numAntenna.Size = new Size(100, 20);
            txtbx_numAntenna.TabIndex = tab++;
            txtbx_numAntenna.Text = numberOfAntenna.ToString();
            this.Controls.Add(txtbx_numAntenna);
            txtbx_numAntenna.BringToFront();


            /*****************************************************************************************/


            height += 25;

            lbl_numTranceivers = new Label();
            lbl_numTranceivers.Location = new Point(this.Size.Width - 195, height);
            lbl_numTranceivers.Size = new Size(115, 13);
            lbl_numTranceivers.Text = "Number of Tranceivers";
            lbl_numTranceivers.BackColor = lblColor;
            this.Controls.Add(lbl_numTranceivers);
            lbl_numTranceivers.BringToFront();

            height += 15;

            lbl_numTranceiversConstraints = new Label();
            lbl_numTranceiversConstraints.Location = new Point(this.Size.Width - 195, height);
            lbl_numTranceiversConstraints.Size = new Size(115, 13);
            lbl_numTranceiversConstraints.Text = "80 < n < 200";
            lbl_numTranceiversConstraints.BackColor = lblColor;
            this.Controls.Add(lbl_numTranceiversConstraints);
            lbl_numTranceiversConstraints.BringToFront();

            height += 17;

            txtbx_numTranceivers = new TextBox();
            txtbx_numTranceivers.Location = new Point(this.Size.Width - 195, height);
            txtbx_numTranceivers.Size = new Size(100, 20);
            txtbx_numTranceivers.TabIndex = tab++;
            txtbx_numTranceivers.Text = numberOfTranceivers.ToString();
            this.Controls.Add(txtbx_numTranceivers);
            txtbx_numTranceivers.BringToFront();


            /*****************************************************************************************/


            height += 25;

            lbl_distanceTranceivers = new Label();
            lbl_distanceTranceivers.Location = new Point(this.Size.Width - 195, height);
            lbl_distanceTranceivers.Size = new Size(153, 13);
            lbl_distanceTranceivers.Text = "Distance Between Tranceivers";
            lbl_distanceTranceivers.BackColor = lblColor;
            this.Controls.Add(lbl_distanceTranceivers);
            lbl_distanceTranceivers.BringToFront();

            height += 15;

            lbl_distanceTranceiversConstraints = new Label();
            lbl_distanceTranceiversConstraints.Location = new Point(this.Size.Width - 195, height);
            lbl_distanceTranceiversConstraints.Size = new Size(153, 13);
            lbl_distanceTranceiversConstraints.Text = "0.001 < n < 0.00865";
            lbl_distanceTranceiversConstraints.BackColor = lblColor;
            this.Controls.Add(lbl_distanceTranceiversConstraints);
            lbl_distanceTranceiversConstraints.BringToFront();

            height += 17;

            txtbx_distanceTranceivers = new TextBox();
            txtbx_distanceTranceivers.Location = new Point(this.Size.Width - 195, height);
            txtbx_distanceTranceivers.Size = new Size(100, 20);
            txtbx_distanceTranceivers.TabIndex = tab++;
            txtbx_distanceTranceivers.Text = distanceBetweenTranceivers.ToString();
            this.Controls.Add(txtbx_distanceTranceivers);
            txtbx_distanceTranceivers.BringToFront();


            /*****************************************************************************************/


            height += 25;

            lbl_maxUEDataRate = new Label();
            lbl_maxUEDataRate.Location = new Point(this.Size.Width - 195, height);
            lbl_maxUEDataRate.Size = new Size(153, 13);
            lbl_maxUEDataRate.Text = "Enter Max Data Rate for UE";
            lbl_maxUEDataRate.BackColor = lblColor;
            this.Controls.Add(lbl_maxUEDataRate);
            lbl_maxUEDataRate.BringToFront();

            height += 15;

            lbl_maxUEDataRateConstraints = new Label();
            lbl_maxUEDataRateConstraints.Location = new Point(this.Size.Width - 195, height);
            lbl_maxUEDataRateConstraints.Size = new Size(153, 13);
            lbl_maxUEDataRateConstraints.Text = "5 < n < 20";
            lbl_maxUEDataRateConstraints.BackColor = lblColor;
            this.Controls.Add(lbl_maxUEDataRateConstraints);
            lbl_maxUEDataRateConstraints.BringToFront();

            height += 17;

            txtbx_maxUEDataRate = new TextBox();
            txtbx_maxUEDataRate.Location = new Point(this.Size.Width - 195, height);
            txtbx_maxUEDataRate.Size = new Size(100, 20);
            txtbx_maxUEDataRate.TabIndex = tab++;
            txtbx_maxUEDataRate.Text = UEmaxDataRate.ToString();
            this.Controls.Add(txtbx_maxUEDataRate);
            txtbx_maxUEDataRate.BringToFront();


            /*****************************************************************************************/


            height += 25;

            lbl_UEperAntenna = new Label();
            lbl_UEperAntenna.Location = new Point(this.Size.Width - 195, height);
            lbl_UEperAntenna.Size = new Size(153, 13);
            lbl_UEperAntenna.Text = "Enter UEs per Antenna";
            lbl_UEperAntenna.BackColor = lblColor;
            this.Controls.Add(lbl_UEperAntenna);
            lbl_UEperAntenna.BringToFront();

            height += 15;

            lbl_UEperAntennaCont = new Label();
            lbl_UEperAntennaCont.Location = new Point(this.Size.Width - 195, height);
            lbl_UEperAntennaCont.Size = new Size(153, 13);
            lbl_UEperAntennaCont.Text = "(normal BS)";
            lbl_UEperAntennaCont.BackColor = lblColor;
            this.Controls.Add(lbl_UEperAntennaCont);
            lbl_UEperAntennaCont.BringToFront();

            height += 15;

            lbl_UEperAntennaConstraints = new Label();
            lbl_UEperAntennaConstraints.Location = new Point(this.Size.Width - 195, height);
            lbl_UEperAntennaConstraints.Size = new Size(153, 13);
            lbl_UEperAntennaConstraints.Text = "1 < n < 40";
            lbl_UEperAntennaConstraints.BackColor = lblColor;
            this.Controls.Add(lbl_UEperAntennaConstraints);
            lbl_UEperAntennaConstraints.BringToFront();

            height += 17;

            txtbx_UEperAntenna = new TextBox();
            txtbx_UEperAntenna.Location = new Point(this.Size.Width - 195, height);
            txtbx_UEperAntenna.Size = new Size(100, 20);
            txtbx_UEperAntenna.TabIndex = tab++;
            txtbx_UEperAntenna.Text = normalUEperAnt.ToString();
            this.Controls.Add(txtbx_UEperAntenna);
            txtbx_UEperAntenna.BringToFront();


            /*****************************************************************************************/


            height += 145;

            btn_finished = new Button();
            btn_finished.Location = new Point(this.Size.Width - 195, this.Size.Height - 105);
            btn_finished.Size = new Size(160, 45);
            btn_finished.TabIndex = 0;
            btn_finished.Font = new Font(new FontFamily("Microsoft Sans Serif"), 16, FontStyle.Regular, GraphicsUnit.Pixel);
            btn_finished.Text = "Finished";
            btn_finished.BackColor = SystemColors.ControlDark;
            btn_finished.FlatAppearance.BorderColor = SystemColors.ControlDarkDark;
            btn_finished.FlatAppearance.BorderSize = 2;
            btn_finished.Click += btn_finished_Click;
            this.AcceptButton = btn_finished;
            this.Controls.Add(btn_finished);
            btn_finished.BringToFront();
            btn_finished.Select();
        }
        
        private void display_Simulation_S2_Paint(object sender, PaintEventArgs e)
        {
            scaledDisplayItems = new List<PointF[]>();
            PointF displayDim = new PointF(display_Simulation_S2.Width - 3, display_Simulation_S2.Height - 3);
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

        private void btn_finished_Click(object sender, EventArgs e)
        {
            bool canMoveFoward = true;
            if (!(int.TryParse(txtbx_BSRegionSide.Text, out shapeSideLength) && shapeSideLength < 20 && shapeSideLength > 5))
            {
                txtbx_BSRegionSide.BackColor = Color.Goldenrod;
                canMoveFoward = false;
            }
            else
                txtbx_BSRegionSide.BackColor = SystemColors.Window;

            if (!(int.TryParse(txtbx_numAntenna.Text, out numberOfAntenna) && numberOfAntenna < 6 && numberOfAntenna > 1))
            {
                txtbx_numAntenna.BackColor = Color.Goldenrod;
                canMoveFoward = false;
            }
            else
                txtbx_numAntenna.BackColor = SystemColors.Window;

            if (!(int.TryParse(txtbx_numTranceivers.Text, out numberOfTranceivers) && numberOfTranceivers < 200 && numberOfTranceivers > 80))
            {
                txtbx_numTranceivers.BackColor = Color.Goldenrod;
                canMoveFoward = false;
            }
            else
                txtbx_numTranceivers.BackColor = SystemColors.Window;

            if (!(float.TryParse(txtbx_distanceTranceivers.Text, out distanceBetweenTranceivers) && distanceBetweenTranceivers < 0.00865F && distanceBetweenTranceivers > 0.001F))
            {
                txtbx_distanceTranceivers.BackColor = Color.Goldenrod;
                canMoveFoward = false;
            }
            else
                txtbx_distanceTranceivers.BackColor = SystemColors.Window;

            if (!(int.TryParse(txtbx_maxUEDataRate.Text, out UEmaxDataRate) && UEmaxDataRate < 20 && UEmaxDataRate > 5))
            {
                txtbx_maxUEDataRate.BackColor = Color.Goldenrod;
                canMoveFoward = false;
            }
            else
                txtbx_maxUEDataRate.BackColor = SystemColors.Window;

            if (!(int.TryParse(txtbx_UEperAntenna.Text, out normalUEperAnt) && normalUEperAnt < 40 && normalUEperAnt > 1))
            {
                txtbx_UEperAntenna.BackColor = Color.Goldenrod;
                canMoveFoward = false;
            }
            else
                txtbx_UEperAntenna.BackColor = SystemColors.Window;

            if (canMoveFoward)
                stageTwoFinished(sender, e);
        }

        private void btn_goBack_Click(object sender, EventArgs e)
        {
            int temp_shapeSideLength;
            if (int.TryParse(txtbx_BSRegionSide.Text, out temp_shapeSideLength) && temp_shapeSideLength < 20 && temp_shapeSideLength > 5)
            {
                shapeSideLength = temp_shapeSideLength;
            }

            int temp_numberOfAntenna;
            if (int.TryParse(txtbx_numAntenna.Text, out temp_numberOfAntenna) && temp_numberOfAntenna < 6 && temp_numberOfAntenna > 1)
            {
                numberOfAntenna = temp_numberOfAntenna;
            }

            int temp_numberOfTranceivers;
            if (int.TryParse(txtbx_numTranceivers.Text, out temp_numberOfTranceivers) && temp_numberOfTranceivers < 200 && temp_numberOfTranceivers > 80)
            {
                numberOfTranceivers = temp_numberOfTranceivers;
            }

            float temp_distanceBetweenTranceivers;
            if (float.TryParse(txtbx_distanceTranceivers.Text, out temp_distanceBetweenTranceivers) && temp_distanceBetweenTranceivers < 0.00865F && temp_distanceBetweenTranceivers > 0.001F)
            {
                distanceBetweenTranceivers = temp_distanceBetweenTranceivers;
            }

            int temp_UEmaxDataRate;
            if (int.TryParse(txtbx_maxUEDataRate.Text, out temp_UEmaxDataRate) && temp_UEmaxDataRate < 20 && temp_UEmaxDataRate > 5)
            {
                UEmaxDataRate = temp_UEmaxDataRate;
            }

            int temp_normalUEperAnt;
            if (int.TryParse(txtbx_UEperAntenna.Text, out temp_normalUEperAnt) && temp_normalUEperAnt < 40 && temp_normalUEperAnt > 1)
            {
                normalUEperAnt = temp_normalUEperAnt;
            }

            foreach (Control c in this.Controls)
                c.Hide();
                
            stageOneInitialization(true);
        }

        private void stageTwoFinished(object sender, EventArgs e)
        {
            foreach (Control c in this.Controls)
                c.Hide();
                
            stageThreeInitialization();
        }
    }
}
