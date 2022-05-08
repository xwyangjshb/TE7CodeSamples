namespace TE70CodeSamples
{
    partial class MainForm
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(MainForm));
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.axTE3DWindow2 = new AxTerraExplorerX.AxTE3DWindow();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.m_cOperationsTabControl = new System.Windows.Forms.TabControl();
            this.m_cMainTabPage = new System.Windows.Forms.TabPage();
            this.groupBox4 = new System.Windows.Forms.GroupBox();
            this.btnScanTree = new System.Windows.Forms.Button();
            this.btnClientData = new System.Windows.Forms.Button();
            this.btnCreateHierarchy = new System.Windows.Forms.Button();
            this.m_cFeatureLayerGroupBox = new System.Windows.Forms.GroupBox();
            this.m_cPointLayerButton = new System.Windows.Forms.Button();
            this.m_cNavigateGroupBox = new System.Windows.Forms.GroupBox();
            this.btnJumpTo = new System.Windows.Forms.Button();
            this.btnGetPosition = new System.Windows.Forms.Button();
            this.btnFlyTo = new System.Windows.Forms.Button();
            this.m_cCreatorGroupBox = new System.Windows.Forms.GroupBox();
            this.btnEdit = new System.Windows.Forms.Button();
            this.btnComplex3DPolygon = new System.Windows.Forms.Button();
            this.m_cGeometryPolygon = new System.Windows.Forms.Button();
            this.m_cCreateLabelButton = new System.Windows.Forms.Button();
            this.m_cCreateCircleButton = new System.Windows.Forms.Button();
            this.m_cProjectGroupBox = new System.Windows.Forms.GroupBox();
            this.m_cOpenProjectButton = new System.Windows.Forms.Button();
            this.groupBox3 = new System.Windows.Forms.GroupBox();
            this.axTEInformationWindow2 = new AxTerraExplorerX.AxTEInformationWindow();
            this.groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.axTE3DWindow2)).BeginInit();
            this.groupBox2.SuspendLayout();
            this.m_cOperationsTabControl.SuspendLayout();
            this.m_cMainTabPage.SuspendLayout();
            this.groupBox4.SuspendLayout();
            this.m_cFeatureLayerGroupBox.SuspendLayout();
            this.m_cNavigateGroupBox.SuspendLayout();
            this.m_cCreatorGroupBox.SuspendLayout();
            this.m_cProjectGroupBox.SuspendLayout();
            this.groupBox3.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.axTEInformationWindow2)).BeginInit();
            this.SuspendLayout();
            // 
            // groupBox1
            // 
            resources.ApplyResources(this.groupBox1, "groupBox1");
            this.groupBox1.Controls.Add(this.axTE3DWindow2);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.TabStop = false;
            // 
            // axTE3DWindow2
            // 
            resources.ApplyResources(this.axTE3DWindow2, "axTE3DWindow2");
            this.axTE3DWindow2.Name = "axTE3DWindow2";
            this.axTE3DWindow2.OcxState = ((System.Windows.Forms.AxHost.State)(resources.GetObject("axTE3DWindow2.OcxState")));
            this.axTE3DWindow2.OnKeyboardMessage += new AxTerraExplorerX._ITE3DWindowEvents_OnKeyboardMessageEventHandler(this.axTE3DWindow2_OnKeyboardMessage);
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.m_cOperationsTabControl);
            resources.ApplyResources(this.groupBox2, "groupBox2");
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.TabStop = false;
            // 
            // m_cOperationsTabControl
            // 
            this.m_cOperationsTabControl.Controls.Add(this.m_cMainTabPage);
            resources.ApplyResources(this.m_cOperationsTabControl, "m_cOperationsTabControl");
            this.m_cOperationsTabControl.Name = "m_cOperationsTabControl";
            this.m_cOperationsTabControl.SelectedIndex = 0;
            // 
            // m_cMainTabPage
            // 
            this.m_cMainTabPage.Controls.Add(this.groupBox4);
            this.m_cMainTabPage.Controls.Add(this.m_cFeatureLayerGroupBox);
            this.m_cMainTabPage.Controls.Add(this.m_cNavigateGroupBox);
            this.m_cMainTabPage.Controls.Add(this.m_cCreatorGroupBox);
            this.m_cMainTabPage.Controls.Add(this.m_cProjectGroupBox);
            resources.ApplyResources(this.m_cMainTabPage, "m_cMainTabPage");
            this.m_cMainTabPage.Name = "m_cMainTabPage";
            this.m_cMainTabPage.UseVisualStyleBackColor = true;
            // 
            // groupBox4
            // 
            this.groupBox4.Controls.Add(this.btnScanTree);
            this.groupBox4.Controls.Add(this.btnClientData);
            this.groupBox4.Controls.Add(this.btnCreateHierarchy);
            resources.ApplyResources(this.groupBox4, "groupBox4");
            this.groupBox4.Name = "groupBox4";
            this.groupBox4.TabStop = false;
            // 
            // btnScanTree
            // 
            resources.ApplyResources(this.btnScanTree, "btnScanTree");
            this.btnScanTree.Name = "btnScanTree";
            this.btnScanTree.UseVisualStyleBackColor = true;
            this.btnScanTree.Click += new System.EventHandler(this.btnScanTree_Click);
            // 
            // btnClientData
            // 
            resources.ApplyResources(this.btnClientData, "btnClientData");
            this.btnClientData.Name = "btnClientData";
            this.btnClientData.UseVisualStyleBackColor = true;
            this.btnClientData.Click += new System.EventHandler(this.btnClientData_Click);
            // 
            // btnCreateHierarchy
            // 
            resources.ApplyResources(this.btnCreateHierarchy, "btnCreateHierarchy");
            this.btnCreateHierarchy.Name = "btnCreateHierarchy";
            this.btnCreateHierarchy.UseVisualStyleBackColor = true;
            this.btnCreateHierarchy.Click += new System.EventHandler(this.btnCreateHierarchy_Click);
            // 
            // m_cFeatureLayerGroupBox
            // 
            this.m_cFeatureLayerGroupBox.Controls.Add(this.m_cPointLayerButton);
            resources.ApplyResources(this.m_cFeatureLayerGroupBox, "m_cFeatureLayerGroupBox");
            this.m_cFeatureLayerGroupBox.Name = "m_cFeatureLayerGroupBox";
            this.m_cFeatureLayerGroupBox.TabStop = false;
            // 
            // m_cPointLayerButton
            // 
            resources.ApplyResources(this.m_cPointLayerButton, "m_cPointLayerButton");
            this.m_cPointLayerButton.Name = "m_cPointLayerButton";
            this.m_cPointLayerButton.UseVisualStyleBackColor = true;
            this.m_cPointLayerButton.Click += new System.EventHandler(this.PointLayerButton_Click);
            // 
            // m_cNavigateGroupBox
            // 
            this.m_cNavigateGroupBox.Controls.Add(this.btnJumpTo);
            this.m_cNavigateGroupBox.Controls.Add(this.btnGetPosition);
            this.m_cNavigateGroupBox.Controls.Add(this.btnFlyTo);
            resources.ApplyResources(this.m_cNavigateGroupBox, "m_cNavigateGroupBox");
            this.m_cNavigateGroupBox.Name = "m_cNavigateGroupBox";
            this.m_cNavigateGroupBox.TabStop = false;
            // 
            // btnJumpTo
            // 
            resources.ApplyResources(this.btnJumpTo, "btnJumpTo");
            this.btnJumpTo.Name = "btnJumpTo";
            this.btnJumpTo.UseVisualStyleBackColor = true;
            this.btnJumpTo.Click += new System.EventHandler(this.btnJumpTo_Click);
            // 
            // btnGetPosition
            // 
            resources.ApplyResources(this.btnGetPosition, "btnGetPosition");
            this.btnGetPosition.Name = "btnGetPosition";
            this.btnGetPosition.UseVisualStyleBackColor = true;
            this.btnGetPosition.Click += new System.EventHandler(this.m_cNavigateButton_Click);
            // 
            // btnFlyTo
            // 
            resources.ApplyResources(this.btnFlyTo, "btnFlyTo");
            this.btnFlyTo.Name = "btnFlyTo";
            this.btnFlyTo.UseVisualStyleBackColor = true;
            this.btnFlyTo.Click += new System.EventHandler(this.btnFlyTo_Click);
            // 
            // m_cCreatorGroupBox
            // 
            this.m_cCreatorGroupBox.Controls.Add(this.btnEdit);
            this.m_cCreatorGroupBox.Controls.Add(this.btnComplex3DPolygon);
            this.m_cCreatorGroupBox.Controls.Add(this.m_cGeometryPolygon);
            this.m_cCreatorGroupBox.Controls.Add(this.m_cCreateLabelButton);
            this.m_cCreatorGroupBox.Controls.Add(this.m_cCreateCircleButton);
            resources.ApplyResources(this.m_cCreatorGroupBox, "m_cCreatorGroupBox");
            this.m_cCreatorGroupBox.Name = "m_cCreatorGroupBox";
            this.m_cCreatorGroupBox.TabStop = false;
            // 
            // btnEdit
            // 
            resources.ApplyResources(this.btnEdit, "btnEdit");
            this.btnEdit.Name = "btnEdit";
            this.btnEdit.UseVisualStyleBackColor = true;
            this.btnEdit.Click += new System.EventHandler(this.btnEdit_Click);
            // 
            // btnComplex3DPolygon
            // 
            resources.ApplyResources(this.btnComplex3DPolygon, "btnComplex3DPolygon");
            this.btnComplex3DPolygon.Name = "btnComplex3DPolygon";
            this.btnComplex3DPolygon.UseVisualStyleBackColor = true;
            this.btnComplex3DPolygon.Click += new System.EventHandler(this.btnComplex3DPolygon_Click);
            // 
            // m_cGeometryPolygon
            // 
            resources.ApplyResources(this.m_cGeometryPolygon, "m_cGeometryPolygon");
            this.m_cGeometryPolygon.Name = "m_cGeometryPolygon";
            this.m_cGeometryPolygon.UseVisualStyleBackColor = true;
            this.m_cGeometryPolygon.Click += new System.EventHandler(this.GeometryPolygon_Click);
            // 
            // m_cCreateLabelButton
            // 
            resources.ApplyResources(this.m_cCreateLabelButton, "m_cCreateLabelButton");
            this.m_cCreateLabelButton.Name = "m_cCreateLabelButton";
            this.m_cCreateLabelButton.UseVisualStyleBackColor = true;
            this.m_cCreateLabelButton.Click += new System.EventHandler(this.CreateLabelButton_Click);
            // 
            // m_cCreateCircleButton
            // 
            resources.ApplyResources(this.m_cCreateCircleButton, "m_cCreateCircleButton");
            this.m_cCreateCircleButton.Name = "m_cCreateCircleButton";
            this.m_cCreateCircleButton.UseVisualStyleBackColor = true;
            this.m_cCreateCircleButton.Click += new System.EventHandler(this.CreateCircleButton_Click);
            // 
            // m_cProjectGroupBox
            // 
            this.m_cProjectGroupBox.Controls.Add(this.m_cOpenProjectButton);
            resources.ApplyResources(this.m_cProjectGroupBox, "m_cProjectGroupBox");
            this.m_cProjectGroupBox.Name = "m_cProjectGroupBox";
            this.m_cProjectGroupBox.TabStop = false;
            // 
            // m_cOpenProjectButton
            // 
            resources.ApplyResources(this.m_cOpenProjectButton, "m_cOpenProjectButton");
            this.m_cOpenProjectButton.Name = "m_cOpenProjectButton";
            this.m_cOpenProjectButton.UseVisualStyleBackColor = true;
            this.m_cOpenProjectButton.Click += new System.EventHandler(this.OpenProjectButton_Click);
            // 
            // groupBox3
            // 
            resources.ApplyResources(this.groupBox3, "groupBox3");
            this.groupBox3.Controls.Add(this.axTEInformationWindow2);
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.TabStop = false;
            // 
            // axTEInformationWindow2
            // 
            resources.ApplyResources(this.axTEInformationWindow2, "axTEInformationWindow2");
            this.axTEInformationWindow2.Name = "axTEInformationWindow2";
            this.axTEInformationWindow2.OcxState = ((System.Windows.Forms.AxHost.State)(resources.GetObject("axTEInformationWindow2.OcxState")));
            // 
            // MainForm
            // 
            resources.ApplyResources(this, "$this");
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.groupBox3);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.groupBox1);
            this.Name = "MainForm";
            this.groupBox1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.axTE3DWindow2)).EndInit();
            this.groupBox2.ResumeLayout(false);
            this.m_cOperationsTabControl.ResumeLayout(false);
            this.m_cMainTabPage.ResumeLayout(false);
            this.groupBox4.ResumeLayout(false);
            this.m_cFeatureLayerGroupBox.ResumeLayout(false);
            this.m_cNavigateGroupBox.ResumeLayout(false);
            this.m_cCreatorGroupBox.ResumeLayout(false);
            this.m_cProjectGroupBox.ResumeLayout(false);
            this.groupBox3.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.axTEInformationWindow2)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.GroupBox groupBox3;
        private AxTerraExplorerX.AxTE3DWindow axTE3DWindow1;
        private AxTerraExplorerX.AxTEInformationWindow axTEInformationWindow1;
        private System.Windows.Forms.TabControl m_cOperationsTabControl;
        private System.Windows.Forms.TabPage m_cMainTabPage;
        private System.Windows.Forms.GroupBox m_cProjectGroupBox;
        private System.Windows.Forms.Button m_cOpenProjectButton;
        private System.Windows.Forms.GroupBox m_cCreatorGroupBox;
        private System.Windows.Forms.Button m_cCreateCircleButton;
        private System.Windows.Forms.Button m_cCreateLabelButton;
        private System.Windows.Forms.Button m_cGeometryPolygon;
        private System.Windows.Forms.GroupBox m_cNavigateGroupBox;
        private System.Windows.Forms.Button btnGetPosition;
        private System.Windows.Forms.GroupBox m_cFeatureLayerGroupBox;
        private System.Windows.Forms.Button m_cPointLayerButton;
        private System.Windows.Forms.Button btnComplex3DPolygon;
        private System.Windows.Forms.Button btnFlyTo;
        private System.Windows.Forms.Button btnJumpTo;
        private System.Windows.Forms.GroupBox groupBox4;
        private System.Windows.Forms.Button btnScanTree;
        private System.Windows.Forms.Button btnClientData;
        private System.Windows.Forms.Button btnCreateHierarchy;
        private System.Windows.Forms.Button btnEdit;
   
        private AxTerraExplorerX.AxTE3DWindow axTE3DWindow2;
        private AxTerraExplorerX.AxTEInformationWindow axTEInformationWindow2;
    }
}

