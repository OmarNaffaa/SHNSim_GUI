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
        /****************__ENVIRONMENT SETUP__****************/

        public List<environment.node> nodeList;
        public List<Point> nodeAndSideSelect;
        public int shapeSideLength = 15;
        public int numberOfAntenna = 3;
        public int numberOfTranceivers = 100;
        public float distanceBetweenTranceivers = 0.0086F;
        public int UEmaxDataRate = 15;
        public int normalUEperAnt = 20;
        public int numberOfNodes = 0;
        public int lengthOfSimulation = 28800;
        public int numberOfDesiredSimulations = 30;
        public int firstSimulationNumber = 0;
        public string simulationSaveName = "Test";
        public string SHNPathName = "(default = GUI path)";

        /****************______STAGE ONE______****************/

        public const float sideLength = 15;
        public List<PointF[]> displayItems;                 //SHARED BETWEEN
        public List<PointF[]> scaledDisplayItems;           //STAGE 1 AND 2

        public int selectedNode = 0;
        public int selectedSide = 0;

        public PictureBox display_Simulation_S1;
        public Button btn_finishEnvCreate;
        public Button btn_prevNode;
        public Button btn_nextNode;
        public TextBox txtbx_nodeCondition;
        public Label lbl_updateCondition;
        public Button btn_updateCondition;

        /****************______STAGE TWO______****************/

        Color lblColor = Color.FromArgb(0xf0, 0xf0, 0xf0);

        public PictureBox display_Simulation_S2;
        public RichTextBox display_objectProperties;

        public Button btn_goBack;

        public Label lbl_BSRegionSide;
        public Label lbl_BSRegionSideConstraints;
        public TextBox txtbx_BSRegionSide;

        public Label lbl_numAntenna;
        public Label lbl_numAntennaConstraints;
        public TextBox txtbx_numAntenna;

        public Label lbl_numTranceivers;
        public Label lbl_numTranceiversConstraints;
        public TextBox txtbx_numTranceivers;

        public Label lbl_distanceTranceivers;
        public Label lbl_distanceTranceiversConstraints;
        public TextBox txtbx_distanceTranceivers;

        public Label lbl_maxUEDataRate;
        public Label lbl_maxUEDataRateConstraints;
        public TextBox txtbx_maxUEDataRate;

        public Label lbl_UEperAntenna;
        public Label lbl_UEperAntennaCont;
        public Label lbl_UEperAntennaConstraints;
        public TextBox txtbx_UEperAntenna;

        public Button btn_finished;

        /****************_____STAGE THREE_____****************/

        public PictureBox display_Simulation_S3;

        public Label lbl_LengthOfSimulation;
        public TextBox txtbx_LengthOfSimulation;

        public Label lbl_NumberOfDesiredSimulations;
        public TextBox txtbx_NumberOfDesiredSimulations;

        public Label lbl_FirstSimulationNumber;
        public TextBox txtbx_FirstSimulationNumber;

        public Label lbl_SimulationSaveName;
        public TextBox txtbx_SimulationSaveName;

        public Label lbl_SHNSimPath;
        public RichTextBox txtbx_SHNSimPath;

        public Button btn_RunSimulation;

        public Button btn_goBack2;

        /*****************************************************/
    }
}
