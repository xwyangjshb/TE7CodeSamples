using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Threading;
using System.IO;
using TerraExplorerX;

namespace TE70CodeSamples
{
    public partial class MainForm : Form
    {
        #region Ctor

        public MainForm()
        {
            InitializeComponent();
        }

        #endregion


        public string SamplesDirectory { get { return Path.GetDirectoryName(Application.ExecutablePath); } }

        #region Project related code samples

        #region Project Open and OnLoadFinished event code sample
        private void OpenProjectButton_Click(object sender, EventArgs e)
        {
            string tMsg = String.Empty;

            // A. Set Project "Open" Method parameters
            string tAppRoot = Path.GetDirectoryName(Application.ExecutablePath);
            string tProjectUrl = Path.Combine(SamplesDirectory,@"Resources\FlyFiles\simplefly.fly");
            //tProjectUrl = @"D:\SKYLine\atlanta-ga-base.fly";
            bool bIsAsync = false;
            string tUser = String.Empty;
            string tPassword = String.Empty;

            // B. Instantiate Terra Explorer Globe and retrieve Project Interface
            try
            {
                SGWorld70 sgworld = new SGWorld70();
                // C. Register to OnLoadFinished globe event
                sgworld.OnLoadFinished += new _ISGWorld70Events_OnLoadFinishedEventHandler(OnProjectLoadFinished);
                // D. Open Project in synchronous mode
                sgworld.Project.Open(tProjectUrl, bIsAsync, tUser, tPassword);
                MessageBox.Show("Opening project " + tProjectUrl + " in async mode");
            }
            catch (Exception ex)
            {
                tMsg = String.Format("OpenProjectButton_Click Exception: {0}", ex.Message);
                MessageBox.Show(tMsg);
            }
        }

        void OnProjectLoadFinished(bool bSuccess)
        {
            string tMsg = String.Empty;

            try
            {
                // OnLoadFinished event Received 
                //MessageBox.Show("Received project loaded event");
            }
            catch (Exception ex)
            {
                tMsg = String.Format("OnProjectLoadFinished Exception: {0}", ex.Message);
                MessageBox.Show(tMsg);
            }
        }

        #endregion

        #endregion


        #region Creator related code samples

        #region Creator simple object code sample - CreatePositon, CreateColor, CreateCircle, Change circle properties

        private void CreateCircleButton_Click(object sender, EventArgs e)
        {
            string tMsg = String.Empty;
            IPosition70 cPos = null;
            IColor70 cFillColor = null;
            ITerrainRegularPolygon70 cCircle = null;
            ITerraExplorerMessage70 cMessage = null;
            
            try
            {
                //
                // A. Instantiate Terra Explorer Globe
                //
                SGWorld70 sgworld = new SGWorld70();

                //
                // B.  Create position for circle
                //
                // B1. Set position input parameters (San Fransico shore)
                double dXCoord = -122.49460;
                double dYCoord = 37.78816;
                double dAltitude = 100.0;
                AltitudeTypeCode eAltitudeTypeCode = AltitudeTypeCode.ATC_TERRAIN_RELATIVE;
                double dYaw = 0.0;
                double dPitch = 0.0;
                double dRoll = 0.0;
                double dDistance = 5000;

                // B2. Create Position
                cPos = sgworld.Creator.CreatePosition(dXCoord, dYCoord, dAltitude, eAltitudeTypeCode, dYaw, dPitch, dRoll, dDistance);

                //
                // C. create FillColor for circle
                //
                {
                    // C1. Set fill color input params - RGB and Alpha
                    int nRed = 0;
                    int nGreen = 255;
                    int nBlue = 0;
                    int nAlpha = 0x7F; // 50% opacity

                    // C2. Create fill color
                    cFillColor = sgworld.Creator.CreateColor(nRed, nGreen, nBlue, nAlpha);
                }

                //
                // D. Create circle using created position and fill color (for line color use Abgr uint value)
                //
                {
                    // D1. Set circle input params
                    uint nLineColor = 0xFFFF0000;   // Abgr value - Solid blue
                    double dCircleRadius = 200;     // in meters

                    // C2. Create circle
                    cCircle = sgworld.Creator.CreateCircle(cPos, dCircleRadius, nLineColor, cFillColor, string.Empty, "Circle");
                }

                //
                // E. Get and change circle properties
                //
                {
                    // E1. Get & Set circle radius
                    double dNewCircleRadius = 300;
                    double dCurrentCircleRadius = cCircle.Radius; // Get circle radius
                    cCircle.Radius = dNewCircleRadius;            // Set new circle radius  

                    // E2. Get fill style and change its properties
                    uint nRGB_Red = 0xFF0000;  // uing Rgb - Red color
                    double dAlpha = 0.2;       // 80% transparent 
                    IFillStyle70 cFillStyle = cCircle.FillStyle;
                    cFillStyle.Color.FromRGBColor(nRGB_Red);
                    cFillStyle.Color.SetAlpha(dAlpha);
                }

                //
                // F. Add Message to created circle
                //
                {
                    // F1. Set message input parameters
                    MsgTargetPosition eMsgTarget = MsgTargetPosition.MTP_POPUP;
                    string tMessage = "Hello Circle";
                    MsgType eMsgType = MsgType.TYPE_TEXT;
                    bool bIsBringToFront = true;

                    // F2. Create message and add to circle
                    cMessage = sgworld.Creator.CreateMessage(eMsgTarget, tMessage, eMsgType, bIsBringToFront);
                    cCircle.Message.MessageID = cMessage.ID;
                }

                //
                // G. FlyTo created circle
                //
                {
                    IPosition70 cFlyToPos = cPos.Copy();
                    cFlyToPos.Pitch = -89.0; // Set camera to look downward on circle 
                    sgworld.Navigate.FlyTo(cFlyToPos, ActionCode.AC_FLYTO);
                }
            }
            catch (Exception ex)
            {
                tMsg = String.Format("CreateCircleButton_Click Exception: {0}", ex.Message);
                MessageBox.Show(tMsg);
            }
        }


        #endregion


        #region Creator label code sample - CreateLabelStyle, CreateTextLabel

        private void CreateLabelButton_Click(object sender, EventArgs e)
        {
            string tMsg = String.Empty;
            IPosition70 cPos = null;
            ILabelStyle70 cLabelStyle = null;
            ITerrainLabel70 cTextLabel = null;
            
            try
            {
                //
                // A. Instantiate Terra Explorer Globe
                //
                SGWorld70 sgworld = new SGWorld70();

                //
                // B.  Create position for label
                //
                {
                    // B1. Set position  input parameters (San Fransico shore)
                    double dXCoord = -122.49460;
                    double dYCoord = 37.78816;
                    double dAltitude = 100.0;
                    AltitudeTypeCode eAltitudeTypeCode = AltitudeTypeCode.ATC_TERRAIN_RELATIVE;
                    double dYaw = 0.0;
                    double dPitch = 0.0;
                    double dRoll = 0.0;
                    double dDistance = 500;

                    // B2. Create Position
                    cPos = sgworld.Creator.CreatePosition(dXCoord, dYCoord, dAltitude, eAltitudeTypeCode, dYaw, dPitch, dRoll, dDistance);
                }

                //
                // C.  Create label style for label
                //
                {
                    // C1. Set label style input parameters
                    SGLabelStyle eLabelStyle = SGLabelStyle.LS_DEFAULT;

                    // C2. Create label style
                    cLabelStyle = sgworld.Creator.CreateLabelStyle(eLabelStyle);

                    // C3. Change label style settings 
                    {
                        uint nBGRValue = 0xFF0000;  // Blue
                        double dAlpha = 0.5;        // 50% opacity 
                        IColor70 cBackgroundColor = cLabelStyle.BackgroundColor; // Get label style background color
                        cBackgroundColor.FromBGRColor(nBGRValue);               // Set background to blue
                        cBackgroundColor.SetAlpha(dAlpha);                      // Set transparency to 50%
                        cLabelStyle.BackgroundColor = cBackgroundColor;         // Set label style background color
                        cLabelStyle.FontName = "Arial";                         // Set font name to Arial
                        cLabelStyle.Italic = true;                              // Set label style font to italic
                        cLabelStyle.Scale = 3;                                  // Set label style scale
                    }
                }

                //
                // D. Create text label using label style
                //
                {
                    // D1. Set label style params
                    string tText = "Skyline";

                    // D2. Create label style
                    cTextLabel = sgworld.Creator.CreateTextLabel(cPos, tText, cLabelStyle, string.Empty, "TextLabel");
                }

                //
                // E. FlyTo text label
                //
                {
                    IPosition70 cFlyToPos = cPos.Copy();
                    cFlyToPos.Pitch = -89.0; // Set camera to look downward on text label 
                    sgworld.Navigate.FlyTo(cFlyToPos, ActionCode.AC_FLYTO);
                }
            }
            catch (Exception ex)
            {
                tMsg = String.Format("CreateLabelButton_Click Exception: {0}", ex.Message);
                MessageBox.Show(tMsg);
            }
        }

        #endregion


        #region Creator simple geometry object code sample - CreateLinearRing, CreatePolygonGeometry, CreatePolygon

        private void GeometryPolygon_Click(object sender, EventArgs e)
        {
            string tMsg = String.Empty;
            double[] cVerticesArray = null;
            ILinearRing cRing = null;
            IGeometry cPolygonGeometry = null;
            ITerrainPolygon70 cPolygon = null;
            
            try
            {
                //
                // A. Instantiate Terra Explorer Globe
                //
                SGWorld70 sgworld = new SGWorld70();

                //
                // B.  Create linear ring
                //
                {
                    //B1. Create vertices double array, each point in format x,z,y
                    cVerticesArray = new double[] {
                        -122.415025,  37.76059,   10,
                        -122.415868,  37.760546,  11, 
                        -122.415922,  37.761244,  12,
                        -122.415592,  37.761254,  13, 
                        -122.415557,  37.760973,  14,
                        -122.415081,  37.76099,   15,
                    };


                    // B2. Create linear ring using vertices
                    {
                        cRing = sgworld.Creator.GeometryCreator.CreateLinearRingGeometry(cVerticesArray);
                    }
                }

                //
                // C. Create polygon geometry using linear ring
                //
                {
                    cPolygonGeometry = sgworld.Creator.GeometryCreator.CreatePolygonGeometry(cRing, null);
                }

                //
                // D. Create polygon using polygon geometry
                //
                {
                    // D1. Set polygon input params
                    uint nLineColor = 0xFF00FF00; // Abgr value -> solid green
                    uint nFillColor = 0x7FFF0000; // Abgr value -> 50% transparent blue
                    AltitudeTypeCode eAltitudeTypeCode = AltitudeTypeCode.ATC_TERRAIN_RELATIVE;

                    // D2. Create polygon
                    cPolygon = sgworld.Creator.CreatePolygon(cPolygonGeometry, nLineColor, nFillColor, eAltitudeTypeCode, string.Empty, "Polygon");

                }

                //
                // E. FlyTo polygon
                //
                {
                    //IPosition70 cFlyToPos = cPolygon.Position.Copy();
                    //cFlyToPos.Pitch = -89.0; // Set camera to look downward on polygon 
                    sgworld.Navigate.FlyTo(cPolygon, ActionCode.AC_FLYTO);
                }
            }
            catch (Exception ex)
            {
                tMsg = String.Format("GeometryPolygon_Click Exception: {0}", ex.Message);
                MessageBox.Show(tMsg);
            }
        }

        #endregion

        #endregion


        #region Feature layer code sample

        #region Point shape layer code sample

        private void PointLayerButton_Click(object sender, EventArgs e)
        {
            string tMsg = String.Empty;
            IFeatureLayer70 cFeatureLayer = null;
            IFeatureGroups70 cFeatureLayerGroups = null;
            IFeatureGroup70 cFeatureGroupPoint = null;

            try
            {
                //
                // A. Instantiate Terra Explorer Globe
                //
                SGWorld70 sgworld = new SGWorld70();

                //
                // B.  Create shape file layer
                //
                {

                    // B1. Generate shape file connection string
                    string tShapeFileName = Path.Combine(SamplesDirectory, @"Resources\ShapeFiles\PointLayers\Captials\World_Capital.shp");
                    string tConnectionString = String.Format("FileName={0};TEPlugName=OGR;", tShapeFileName);

                    // B2. Create point feature layer
                    cFeatureLayer = sgworld.Creator.CreateFeatureLayer("Capitals", tConnectionString);
                }

                //
                // C. Display points as text label & set label text property to one of the shape text type attribute 
                //
                {
                    // C1. Set Point FeatureGroup DisplayAs property to label
                    cFeatureLayerGroups = cFeatureLayer.FeatureGroups;
                    cFeatureGroupPoint = cFeatureLayerGroups.Point;
                    cFeatureGroupPoint.DisplayAs = ObjectTypeCode.OT_LABEL;

                    // C2. Set label "Scale" property for visualization from high altitude
                    {
                        double dScale = 10000.0;
                        cFeatureGroupPoint.SetProperty("Scale", dScale);
                    }


                    // C3. Set label "Text" property to the first found text attribute "Name" property
                    {
                        // Get layer data source attributes
                        IDataSourceInfo70 cFeatureLayerDataSource = cFeatureLayer.DataSourceInfo;
                        IAttributes70 cAttributes = cFeatureLayerDataSource.Attributes;
                        // Import all data source attributes
                        cFeatureLayerDataSource.Attributes.ImportAll = true;

                        // Iterate attributes, find first attribute of type text and set its name to label text
                        foreach (IAttribute70 cAttribute in cFeatureLayerDataSource.Attributes)
                        {
                            if (cAttribute.Type == AttributeTypeCode.AT_TEXT)
                            {
                                cFeatureGroupPoint.SetProperty("Text", String.Format("[{0}]", cAttribute.Name));
                                break;
                            }
                        }
                    }
                }

                //
                // D. Perform spatial query
                //
                {
                    // D1. Generate polygon geometry (Part of Europe)
                    List<double> cSQVerticesArrayDbl = new List<double>() { -10.0,50.0,0.0,
                                                                            -10.0,30.0,0.0,
                                                                             30.0,30.0,0.0,
                                                                             30.0,50.0,0.0 };

                    // D2. Create polygon geometry from linear ring and call spatial query
                    IFeatures70 cSQResFeatures = null;
                    IGeometry cSQPlgGeometry = null;
                    ILinearRing cSQRing = sgworld.Creator.GeometryCreator.CreateLinearRingGeometry(cSQVerticesArrayDbl.ToArray());
                    cSQPlgGeometry = sgworld.Creator.GeometryCreator.CreatePolygonGeometry(cSQRing, null);
                    cSQResFeatures = cFeatureLayer.ExecuteSpatialQuery(cSQPlgGeometry, IntersectionType.IT_INTERSECT);
                }

                //
                // E. Load Feature layer in "Entire" mode
                //
                {
                    cFeatureLayer.Streaming = false;
                    cFeatureLayer.Load();
                }


                //
                // F. FlyTo feature layer view point
                //
                {
                    IPosition70 cFlyToPos = cFeatureLayer.Position.Copy();
                    cFlyToPos.Pitch = -89.0; // Set camera to look downward on polygon 
                    cFlyToPos.X = 10.50;
                    cFlyToPos.Y = 47.50;
                    cFlyToPos.Distance = 3500000;
                    sgworld.Navigate.FlyTo(cFlyToPos, ActionCode.AC_FLYTO);
                }
            }
            catch (Exception ex)
            {
                tMsg = String.Format("PointLayerButton_Click Exception: {0}", ex.Message);
                MessageBox.Show(tMsg);
            }
        }

        #endregion

        #region Create complex 3D polygons example
        private void btnComplex3DPolygon_Click(object sender, EventArgs e)
        {
            try
            {
                // create TE API object
                var sgworld = new SGWorld70();

                // Create polygon with hole geometry from well-known-text
                var complexGeometry1 = sgworld.Creator.GeometryCreator.CreateGeometryFromWKT(@"POLYGON(
                                (-80.900091 26.739261,-80.906338 26.840896,-80.591731 26.951601,-80.809248 26.716679,-80.900091 26.739261),
                                (-80.873569 26.819371,-80.81616 26.772908,-80.811242 26.846308,-80.873569 26.819371)
                                )");

                // Create polygon
                // Create line color using creator by specifying red,green,blue,alpha values
                var lineColor1 = sgworld.Creator.CreateColor(255, 0, 0, 0);
                var fillColor1 = "#00ff00"; // we can also specify color using HTML notation
                var polygon1 = sgworld.Creator.CreatePolygon(complexGeometry1, lineColor1, fillColor1, AltitudeTypeCode.ATC_ON_TERRAIN, string.Empty, "Polygon with hole");


                // create multipolygon from array of x,z,y points

                // Polygon geometry consists of LinearRing that specifies exterior ring and array of LinearRing geometries that specify interior rings
                // create exterior ring using array of coordinates
                var exteriorRing = sgworld.Creator.GeometryCreator.CreateLinearRingGeometry(new double[] { -80.593456, 26.692189, 1000, -80.569379, 26.654723, 2000, -80.482195, 26.724591, 1000, -80.55208, 26.771137, 1000 });
                var interiorRing1 = sgworld.Creator.GeometryCreator.CreateLinearRingGeometry(new double[] { -80.577327, 26.713192, 1000, -80.567401, 26.726351, 1000, -80.569138, 26.705869, 1000 });
                var interiorRing2 = sgworld.Creator.GeometryCreator.CreateLinearRingGeometry(new double[] { -80.55315, 26.691784, 2000, -80.555867, 26.673088, 2000, -80.5252610, 26.688447, 2000 });

                var complexGeometry2 = sgworld.Creator.GeometryCreator.CreatePolygonGeometry(exteriorRing, new ILinearRing[] { interiorRing1,interiorRing2 } );

                // Specify fill color using .Net Color class
                var fillColor2 = Color.Teal;

                var lineColor2 = "#00ff00";
                // Create 3D polygon
                var polygon2 = sgworld.Creator.CreatePolygon(complexGeometry2, lineColor2, fillColor2.ToArgb(), AltitudeTypeCode.ATC_TERRAIN_ABSOLUTE, string.Empty, "Polygon with 2 holes");
                polygon2.Position.Distance = 80000;
                //polygon2.Position.Pitch = -45;
                sgworld.Navigate.FlyTo(polygon2, ActionCode.AC_FLYTO);
            }
            catch(Exception ex)
            {
                MessageBox.Show("Unexpected error:" + ex.Message);
            }
        }
        #endregion

        private void m_cNavigateButton_Click(object sender, EventArgs e)
        {
            try
            {
                var sgworld = new SGWorld70();
                // get our current position
                var currentPos = sgworld.Navigate.GetPosition(AltitudeTypeCode.ATC_TERRAIN_ABSOLUTE);
                // show details of current position
                MessageBox.Show(string.Format(
@"Current position in the world:
Altitude = {0}
AltitudeType = {1}
Distance = {2}
Yaw = {3}
Pitch = {4}
Roll = {5}
X = {6}
Y = {7}
", currentPos.Altitude,currentPos.AltitudeType,currentPos.Distance,currentPos.Yaw,currentPos.Pitch,currentPos.Roll, currentPos.X, currentPos.Y));
            }
            catch (Exception ex)
            {
                MessageBox.Show("Unexpected error: " + ex.Message);
            }
        }
        #endregion

        private bool _evenCall = false;
        private void btnFlyTo_Click(object sender, EventArgs e)
        {
            try
            {
                var sgworld = new SGWorld70();
               
                // x,y,height, height type, yaw, pitch, roll, distance
                var newYork = sgworld.Creator.CreatePosition(-74,40.716667,1000,AltitudeTypeCode.ATC_TERRAIN_RELATIVE,0,-45,0,0);
                // x,y,height, height type, yaw, pitch, roll, distance
                var losAngeles = sgworld.Creator.CreatePosition(-118.25,34.05,1000,AltitudeTypeCode.ATC_TERRAIN_RELATIVE,0,-45,0,0);
                if (_evenCall)
                {
                    MessageBox.Show("Click ok to fly to New York city");
                    sgworld.Navigate.FlyTo(newYork, ActionCode.AC_FLYTO);
                }
                else
                {
                    MessageBox.Show("Click ok to fly to Los Angeles");
                    sgworld.Navigate.FlyTo(losAngeles, ActionCode.AC_FLYTO);
                }
                _evenCall = !_evenCall;
            }
            catch (Exception ex)
            {
                MessageBox.Show("Unexpected error: " + ex.Message);
            }
        }

        private void btnJumpTo_Click(object sender, EventArgs e)
        {
            try
            {
                var sgworld = new SGWorld70();
                // x,y,height, height type, yaw, pitch, roll, distance
                var newYork = sgworld.Creator.CreatePosition(-74,40.716667,1000,AltitudeTypeCode.ATC_TERRAIN_RELATIVE,0,-45,0,0);
                // x,y,height, height type, yaw, pitch, roll, distance
                var losAngeles = sgworld.Creator.CreatePosition(-118.25,34.05,1000,AltitudeTypeCode.ATC_TERRAIN_RELATIVE,0,-45,0,0);
                if (_evenCall)
                {
                    MessageBox.Show("Click ok to jump to New York city");
                    sgworld.Navigate.JumpTo(newYork);
                }
                else
                {
                    MessageBox.Show("Click ok to jump to Los Angeles");
                    sgworld.Navigate.JumpTo(losAngeles);
                }
                _evenCall = !_evenCall;
            }
            catch (Exception ex)
            {
                MessageBox.Show("Unexpected error: " + ex.Message);
            }
        }

        private void btnCreateHierarchy_Click(object sender, EventArgs e)
        {
            try
            {
                var sgworld = new SGWorld70();
                // create group
                var newEngland = sgworld.ProjectTree.CreateGroup("New England");
                var states = sgworld.ProjectTree.CreateGroup("States", newEngland);
                // create 5 labels inside group
                var stateLabelStyle = sgworld.Creator.CreateLabelStyle(SGLabelStyle.LS_DEFAULT);
                stateLabelStyle.LineToGroundType = LineType.LINE_TYPE_TO_GROUND;
                stateLabelStyle.TextColor.FromARGBColor((uint)Color.Beige.ToArgb());
                var Vermont = sgworld.Creator.CreateTextLabel(sgworld.Creator.CreatePosition(-72.75206, 43.91127, 80000.0, 0, 0.0, 0, -85, 800000.0), "Vermont", stateLabelStyle, states, "Vermont");
                var Maine = sgworld.Creator.CreateTextLabel(sgworld.Creator.CreatePosition(-69.40414, 45.12594, 80000.0, 0, 0.0, 0, -85, 800000.0), "Maine", stateLabelStyle, states, "Maine");
                var Massachusetts = sgworld.Creator.CreateTextLabel(sgworld.Creator.CreatePosition(-71.88455, 42.34216, 80000.0, 0, 0.0, 0, -85, 800000.0), "Massachusetts", stateLabelStyle, states, "Massachusetts");
                var RhodeIsland = sgworld.Creator.CreateTextLabel(sgworld.Creator.CreatePosition(-71.57073, 41.62953, 80000.0, 0, 0.0, 0, -85, 800000.0), "Rhode Island", stateLabelStyle, states, "Rhode Island");
                var Connecticut = sgworld.Creator.CreateTextLabel(sgworld.Creator.CreatePosition(-72.64295, 41.57912, 80000.0, 0, 0.0, 0, -85, 800000.0), "Connecticut", stateLabelStyle, states, "Connecticut");
                // expand the group
                sgworld.ProjectTree.ExpandGroup(newEngland, true);
                // fly to first label
                sgworld.Navigate.FlyTo(Vermont, ActionCode.AC_FLYTO);
                MessageBox.Show("Created group and 5 labels in it. Click Ok to continue");
                var places = sgworld.ProjectTree.CreateLockedGroup("Places", newEngland);
                var placeLabelStyle = sgworld.Creator.CreateLabelStyle(SGLabelStyle.LS_DEFAULT);
                placeLabelStyle.LineToGroundType = LineType.LINE_TYPE_TO_GROUND;
                placeLabelStyle.TextColor.FromARGBColor((uint)Color.Cyan.ToArgb());
                var LakeChamplain = sgworld.Creator.CreateTextLabel(sgworld.Creator.CreatePosition(-73.333333, 44.533333, 160000.0, 0, 0.0, 0, -85, 800000.0), "Lake Champlain", placeLabelStyle, places, "Lake Champlain");
                var Windsor = sgworld.Creator.CreateTextLabel(sgworld.Creator.CreatePosition(-72.401111, 43.476667, 160000.0, 0, 0.0, 0, -85, 800000.0), "Windsor, Vermont", placeLabelStyle, places, "Windsor, Vermont");
                var NewHaven = sgworld.Creator.CreateTextLabel(sgworld.Creator.CreatePosition(-72.923611, 41.31, 160000.0, 0, 0.0, 0, -85, 800000.0), "New Haven, Connecticut", placeLabelStyle, places, "New Haven, Connecticut");
                var Hartford = sgworld.Creator.CreateTextLabel(sgworld.Creator.CreatePosition(-72.677, 41.767, 160000.0, 0, 0.0, 0, -85, 800000.0), "Hartford, Connecticut", placeLabelStyle, places, "Hartford, Connecticut");
                MessageBox.Show("Created locked group 'Places' and 4 labels in it. You may use right click menu of the group to unlock it and edit its content");
            }
            catch (Exception ex)
            {
                MessageBox.Show("Unexpected error: " + ex.Message);
            }
        }

        private void btnScanTree_Click(object sender, EventArgs e)
        {
            try
            {
                var sgworld = new SGWorld70();
                MessageBox.Show("Click ok to find Vermont item by its path in the tree");
                var id = sgworld.ProjectTree.FindItem("New England\\States\\Vermont");
                if (!string.IsNullOrEmpty(id))
                    MessageBox.Show("Found Vermont with id=" + id);
                else
                    MessageBox.Show("New England\\States\\Vermont does not exist in tree");
                // root is the first visible item in tree.
                var root = sgworld.ProjectTree.GetNextItem(string.Empty, ItemCode.ROOT);
                // if the tree has hidden group, skip it.
                // find hidden group by its name. We could also check by HiddenGroupID , which is actually its parent id.
                if(sgworld.ProjectTree.GetItemName(root) == sgworld.ProjectTree.HiddenGroupName)
                    root = sgworld.ProjectTree.GetNextItem(root, ItemCode.NEXT);
                var tree = BuildTreeRecursive(root, 1);
                MessageBox.Show(tree);
            }
            catch (Exception ex)
            {
                MessageBox.Show("Unexpected error: " + ex.Message);
            }
        }

        private string BuildTreeRecursive(string current, int indent)
        {
            var sgworld = new SGWorld70();
            // build padding
            var padding = new string('-', indent * 3);
            var result = string.Empty;
            // iterate over all siblings of current node
            while (string.IsNullOrEmpty(current) == false)
            {
                // append node name to the tree string
                var currentName = sgworld.ProjectTree.GetItemName(current);
                result += padding + currentName + Environment.NewLine;
                // if current node is group, recursively build tree from its first child;
                if (sgworld.ProjectTree.IsGroup(current))
                {
                    var child = sgworld.ProjectTree.GetNextItem(current, ItemCode.CHILD);
                    result += BuildTreeRecursive(child, indent + 1);
                }
                // move to next sibling
                current = sgworld.ProjectTree.GetNextItem(current, ItemCode.NEXT);
            }
            return result;
        }

        private void btnClientData_Click(object sender, EventArgs e)
        {
            try
            {
                var sgworld = new SGWorld70();
                // create hole on terrain
                var hole = sgworld.Creator.CreateHoleOnTerrain(sgworld.Creator.GeometryCreator.CreateGeometryFromWKT("POLYGON((6 6,11 6,11 11,6 11,6 6))"), string.Empty, "Hole on terrain");
                hole.Position.Distance = 8000000;
                // store client data with key "My Data" in the hole
                hole.set_ClientData("MyData", "Big hole");
                // fly to the hole
                sgworld.Navigate.FlyTo(hole, ActionCode.AC_FLYTO);
                MessageBox.Show("Created hole on terrain and saved client data(Big Hole) in it. Click ok to read client data from it");
                // read client data with key "My Data" from the hole
                var data = hole.get_ClientData("MyData");
                MessageBox.Show("Client data in the hole is:" + data);
            }
            catch (Exception ex)
            {
                MessageBox.Show("Unexpected error: " + ex.Message);
            }
        }

        private void btnEdit_Click(object sender, EventArgs e)
        {
            try
            {
                var sgworld = new SGWorld70();
                var geometry = sgworld.Creator.GeometryCreator.CreateGeometryFromWKT(@"POLYGON(
                                (-82.900091 26.739261,-82.906338 26.840896,-82.591731 26.951601,-82.809248 26.716679,-82.900091 26.739261),
                                (-82.873569 26.819371,-82.81616 26.772908,-82.811242 26.846308,-82.873569 26.819371)
                                )");
                var polygon = sgworld.Creator.CreatePolygon(geometry, Color.AliceBlue.ToArgb(), Color.Bisque.ToArgb(), AltitudeTypeCode.ATC_TERRAIN_RELATIVE, string.Empty, "Polygon");
                polygon.Position.Distance = 80000;
                polygon.Position.Pitch = -45;
                sgworld.Navigate.JumpTo(polygon);
                MessageBox.Show("Polygon created. Click Ok to move all its points 0.001 to the right on x axis and add z value");
                // convert polygon geometry to its type
                var polygonGeometry = polygon.Geometry as IPolygon;
                // call start edit on the polygon
                polygonGeometry.StartEdit();
                // iterate over all of its rings. First one is exterior ring. All after it, are interior rings
                foreach (ILinearRing ring in polygonGeometry.Rings)
                {
                    foreach (IPoint point in ring.Points)
                    {
                        point.X += 0.001;
                        point.Z += point.X + point.Y;
                    }
                }
                // call EndEdit at the end. EndEdit returns new IGeometry. It does so, because IPolygon could have turned to IMultiPolygon 
                var editedGeometry = polygonGeometry.EndEdit();
                // set the new geometry to the object
                polygon.Geometry = editedGeometry;
            }
            catch (Exception ex)
            {
                MessageBox.Show("Unexpected error: " + ex.Message);
            }
        }

        private void axTE3DWindow2_OnKeyboardMessage(object sender, AxTerraExplorerX._ITE3DWindowEvents_OnKeyboardMessageEvent e)
        {

        }
    }
}
