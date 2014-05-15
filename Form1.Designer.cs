using ESRI.ArcGIS.Mobile.WinForms;
namespace mobileCache2Shape10
{
    partial class Form1
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
            this.components = new System.ComponentModel.Container();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle3 = new System.Windows.Forms.DataGridViewCellStyle();
            this.splitContainer1 = new System.Windows.Forms.SplitContainer();
            this.map1 = new ESRI.ArcGIS.Mobile.WinForms.Map();
            this.statusStrip1 = new System.Windows.Forms.StatusStrip();
            this.toolStripStatusLabel1 = new System.Windows.Forms.ToolStripStatusLabel();
            this.actionToolStripStatusLabel = new System.Windows.Forms.ToolStripStatusLabel();
            this.layerToolStripStatusLabel = new System.Windows.Forms.ToolStripStatusLabel();
            this.toolStripProgressBar1 = new System.Windows.Forms.ToolStripProgressBar();
            this.CacheFoldertoolStripStatusLabel = new System.Windows.Forms.ToolStripStatusLabel();
            this.selectionStripStatusLabel1 = new System.Windows.Forms.ToolStripStatusLabel();
            this.toolStripStatusLabel2 = new System.Windows.Forms.ToolStripStatusLabel();
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
            this.mobileCache1 = new ESRI.ArcGIS.Mobile.FeatureCaching.MobileCache(this.components);
            this.folderBrowserDialog = new System.Windows.Forms.FolderBrowserDialog();
            this.openFileDialog = new System.Windows.Forms.OpenFileDialog();
            this.mobileCacheToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.openMapCacheFolderToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripMenuItem1 = new System.Windows.Forms.ToolStripSeparator();
            this.exitToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.mapActionsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.zoomInToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.zoomOutToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.zoomToFullExtentToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.panToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripMenuItem2 = new System.Windows.Forms.ToolStripSeparator();
            this.selectByPointToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.selectByRectangleToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.selectByPolygonToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.clearSelectionToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.layersToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.exportSelectedFeaturesToAShapefileToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.exportFeaturesToShapefilesToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.exportOriginalFeaturesToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.exporToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.exportAddedFeaturesToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.exportDeletedFeaturesToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.exportAllCurrentFeaturesToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.exportLayersToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.helpToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.splitContainer1.Panel1.SuspendLayout();
            this.splitContainer1.Panel2.SuspendLayout();
            this.splitContainer1.SuspendLayout();
            this.statusStrip1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            this.menuStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // splitContainer1
            // 
            this.splitContainer1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splitContainer1.Location = new System.Drawing.Point(0, 24);
            this.splitContainer1.Name = "splitContainer1";
            this.splitContainer1.Orientation = System.Windows.Forms.Orientation.Horizontal;
            // 
            // splitContainer1.Panel1
            // 
            this.splitContainer1.Panel1.Controls.Add(this.map1);
            // 
            // splitContainer1.Panel2
            // 
            this.splitContainer1.Panel2.Controls.Add(this.statusStrip1);
            this.splitContainer1.Panel2.Controls.Add(this.dataGridView1);
            this.splitContainer1.Size = new System.Drawing.Size(875, 364);
            this.splitContainer1.SplitterDistance = 182;
            this.splitContainer1.TabIndex = 1;
            // 
            // map1
            // 
            this.map1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.map1.Location = new System.Drawing.Point(0, 0);
            this.map1.Name = "map1";
            this.map1.Size = new System.Drawing.Size(875, 182);
            this.map1.TabIndex = 0;
            this.map1.Text = "Open a MobileCache first";
            // 
            // statusStrip1
            // 
            this.statusStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripStatusLabel1,
            this.actionToolStripStatusLabel,
            this.layerToolStripStatusLabel,
            this.toolStripProgressBar1,
            this.CacheFoldertoolStripStatusLabel,
            this.selectionStripStatusLabel1,
            this.toolStripStatusLabel2});
            this.statusStrip1.Location = new System.Drawing.Point(0, 156);
            this.statusStrip1.Name = "statusStrip1";
            this.statusStrip1.Size = new System.Drawing.Size(875, 22);
            this.statusStrip1.TabIndex = 1;
            this.statusStrip1.Text = "statusStrip1";
            // 
            // toolStripStatusLabel1
            // 
            this.toolStripStatusLabel1.Name = "toolStripStatusLabel1";
            this.toolStripStatusLabel1.Size = new System.Drawing.Size(25, 17);
            this.toolStripStatusLabel1.Text = "      ";
            // 
            // actionToolStripStatusLabel
            // 
            this.actionToolStripStatusLabel.Name = "actionToolStripStatusLabel";
            this.actionToolStripStatusLabel.Size = new System.Drawing.Size(19, 17);
            this.actionToolStripStatusLabel.Text = "    ";
            this.actionToolStripStatusLabel.ToolTipText = "     ";
            // 
            // layerToolStripStatusLabel
            // 
            this.layerToolStripStatusLabel.Name = "layerToolStripStatusLabel";
            this.layerToolStripStatusLabel.Size = new System.Drawing.Size(19, 17);
            this.layerToolStripStatusLabel.Text = "    ";
            // 
            // toolStripProgressBar1
            // 
            this.toolStripProgressBar1.Name = "toolStripProgressBar1";
            this.toolStripProgressBar1.Size = new System.Drawing.Size(100, 16);
            this.toolStripProgressBar1.Visible = false;
            // 
            // CacheFoldertoolStripStatusLabel
            // 
            this.CacheFoldertoolStripStatusLabel.Name = "CacheFoldertoolStripStatusLabel";
            this.CacheFoldertoolStripStatusLabel.Size = new System.Drawing.Size(0, 17);
            // 
            // selectionStripStatusLabel1
            // 
            this.selectionStripStatusLabel1.Name = "selectionStripStatusLabel1";
            this.selectionStripStatusLabel1.Size = new System.Drawing.Size(19, 17);
            this.selectionStripStatusLabel1.Text = "    ";
            // 
            // toolStripStatusLabel2
            // 
            this.toolStripStatusLabel2.Name = "toolStripStatusLabel2";
            this.toolStripStatusLabel2.Size = new System.Drawing.Size(70, 17);
            this.toolStripStatusLabel2.Text = "                     ";
            // 
            // dataGridView1
            // 
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle1.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle1.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle1.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle1.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle1.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dataGridView1.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle1;
            this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle2.BackColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle2.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle2.ForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle2.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle2.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.dataGridView1.DefaultCellStyle = dataGridViewCellStyle2;
            this.dataGridView1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dataGridView1.Location = new System.Drawing.Point(0, 0);
            this.dataGridView1.Name = "dataGridView1";
            dataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle3.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle3.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle3.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle3.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle3.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle3.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dataGridView1.RowHeadersDefaultCellStyle = dataGridViewCellStyle3;
            this.dataGridView1.Size = new System.Drawing.Size(875, 178);
            this.dataGridView1.TabIndex = 0;
            // 
            // openFileDialog
            // 
            this.openFileDialog.FileName = "openFileDialog1";
            // 
            // mobileCacheToolStripMenuItem
            // 
            this.mobileCacheToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.openMapCacheFolderToolStripMenuItem,
            this.toolStripMenuItem1,
            this.exitToolStripMenuItem});
            this.mobileCacheToolStripMenuItem.Name = "mobileCacheToolStripMenuItem";
            this.mobileCacheToolStripMenuItem.Size = new System.Drawing.Size(92, 20);
            this.mobileCacheToolStripMenuItem.Text = "Mobile Cache";
            this.mobileCacheToolStripMenuItem.Click += new System.EventHandler(this.mobileCacheToolStripMenuItem_Click);
            // 
            // openMapCacheFolderToolStripMenuItem
            // 
            this.openMapCacheFolderToolStripMenuItem.Name = "openMapCacheFolderToolStripMenuItem";
            this.openMapCacheFolderToolStripMenuItem.Size = new System.Drawing.Size(103, 22);
            this.openMapCacheFolderToolStripMenuItem.Text = "Open";
            this.openMapCacheFolderToolStripMenuItem.Click += new System.EventHandler(this.openMapCacheFolderToolStripMenuItem_Click);
            // 
            // toolStripMenuItem1
            // 
            this.toolStripMenuItem1.Name = "toolStripMenuItem1";
            this.toolStripMenuItem1.Size = new System.Drawing.Size(100, 6);
            // 
            // exitToolStripMenuItem
            // 
            this.exitToolStripMenuItem.Name = "exitToolStripMenuItem";
            this.exitToolStripMenuItem.Size = new System.Drawing.Size(103, 22);
            this.exitToolStripMenuItem.Text = "Exit";
            this.exitToolStripMenuItem.Click += new System.EventHandler(this.exitToolStripMenuItem_Click);
            // 
            // mapActionsToolStripMenuItem
            // 
            this.mapActionsToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.zoomInToolStripMenuItem,
            this.zoomOutToolStripMenuItem,
            this.zoomToFullExtentToolStripMenuItem,
            this.panToolStripMenuItem,
            this.toolStripMenuItem2,
            this.selectByPointToolStripMenuItem,
            this.selectByRectangleToolStripMenuItem,
            this.selectByPolygonToolStripMenuItem,
            this.clearSelectionToolStripMenuItem});
            this.mapActionsToolStripMenuItem.Name = "mapActionsToolStripMenuItem";
            this.mapActionsToolStripMenuItem.Size = new System.Drawing.Size(86, 20);
            this.mapActionsToolStripMenuItem.Text = "Map Actions";
            // 
            // zoomInToolStripMenuItem
            // 
            this.zoomInToolStripMenuItem.Name = "zoomInToolStripMenuItem";
            this.zoomInToolStripMenuItem.Size = new System.Drawing.Size(177, 22);
            this.zoomInToolStripMenuItem.Text = "Zoom In";
            this.zoomInToolStripMenuItem.Click += new System.EventHandler(this.actionsMenuHandler);
            // 
            // zoomOutToolStripMenuItem
            // 
            this.zoomOutToolStripMenuItem.Name = "zoomOutToolStripMenuItem";
            this.zoomOutToolStripMenuItem.Size = new System.Drawing.Size(177, 22);
            this.zoomOutToolStripMenuItem.Text = "Zoom Out";
            this.zoomOutToolStripMenuItem.Click += new System.EventHandler(this.actionsMenuHandler);
            // 
            // zoomToFullExtentToolStripMenuItem
            // 
            this.zoomToFullExtentToolStripMenuItem.Name = "zoomToFullExtentToolStripMenuItem";
            this.zoomToFullExtentToolStripMenuItem.Size = new System.Drawing.Size(177, 22);
            this.zoomToFullExtentToolStripMenuItem.Text = "Zoom to Full Extent";
            this.zoomToFullExtentToolStripMenuItem.Click += new System.EventHandler(this.actionsMenuHandler);
            // 
            // panToolStripMenuItem
            // 
            this.panToolStripMenuItem.Name = "panToolStripMenuItem";
            this.panToolStripMenuItem.Size = new System.Drawing.Size(177, 22);
            this.panToolStripMenuItem.Text = "Pan";
            this.panToolStripMenuItem.Click += new System.EventHandler(this.actionsMenuHandler);
            // 
            // toolStripMenuItem2
            // 
            this.toolStripMenuItem2.Name = "toolStripMenuItem2";
            this.toolStripMenuItem2.Size = new System.Drawing.Size(174, 6);
            // 
            // selectByPointToolStripMenuItem
            // 
            this.selectByPointToolStripMenuItem.Name = "selectByPointToolStripMenuItem";
            this.selectByPointToolStripMenuItem.Size = new System.Drawing.Size(177, 22);
            this.selectByPointToolStripMenuItem.Text = "Select by Point";
            this.selectByPointToolStripMenuItem.Click += new System.EventHandler(this.selectionMenuHandler);
            // 
            // selectByRectangleToolStripMenuItem
            // 
            this.selectByRectangleToolStripMenuItem.Name = "selectByRectangleToolStripMenuItem";
            this.selectByRectangleToolStripMenuItem.Size = new System.Drawing.Size(177, 22);
            this.selectByRectangleToolStripMenuItem.Text = "Select by Rectangle";
            this.selectByRectangleToolStripMenuItem.Click += new System.EventHandler(this.selectionMenuHandler);
            // 
            // selectByPolygonToolStripMenuItem
            // 
            this.selectByPolygonToolStripMenuItem.Name = "selectByPolygonToolStripMenuItem";
            this.selectByPolygonToolStripMenuItem.Size = new System.Drawing.Size(177, 22);
            this.selectByPolygonToolStripMenuItem.Text = "Select by Polygon";
            this.selectByPolygonToolStripMenuItem.Click += new System.EventHandler(this.selectionMenuHandler);
            // 
            // clearSelectionToolStripMenuItem
            // 
            this.clearSelectionToolStripMenuItem.Name = "clearSelectionToolStripMenuItem";
            this.clearSelectionToolStripMenuItem.Size = new System.Drawing.Size(177, 22);
            this.clearSelectionToolStripMenuItem.Text = "Clear Selection";
            this.clearSelectionToolStripMenuItem.Click += new System.EventHandler(this.clearSelectionToolStripMenuItem_Click);
            // 
            // layersToolStripMenuItem
            // 
            this.layersToolStripMenuItem.Name = "layersToolStripMenuItem";
            this.layersToolStripMenuItem.Size = new System.Drawing.Size(49, 20);
            this.layersToolStripMenuItem.Text = "layers";
            this.layersToolStripMenuItem.Click += new System.EventHandler(this.layersToolStripMenuItem_Click);
            // 
            // exportSelectedFeaturesToAShapefileToolStripMenuItem
            // 
            this.exportSelectedFeaturesToAShapefileToolStripMenuItem.Name = "exportSelectedFeaturesToAShapefileToolStripMenuItem";
            this.exportSelectedFeaturesToAShapefileToolStripMenuItem.Size = new System.Drawing.Size(146, 20);
            this.exportSelectedFeaturesToAShapefileToolStripMenuItem.Text = "Export Selected Features";
            this.exportSelectedFeaturesToAShapefileToolStripMenuItem.Click += new System.EventHandler(this.exportSelectedFeaturesToAShapefileToolStripMenuItem_Click);
            // 
            // exportFeaturesToShapefilesToolStripMenuItem
            // 
            this.exportFeaturesToShapefilesToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.exportOriginalFeaturesToolStripMenuItem,
            this.exporToolStripMenuItem,
            this.exportAddedFeaturesToolStripMenuItem,
            this.exportDeletedFeaturesToolStripMenuItem,
            this.exportAllCurrentFeaturesToolStripMenuItem});
            this.exportFeaturesToShapefilesToolStripMenuItem.Name = "exportFeaturesToShapefilesToolStripMenuItem";
            this.exportFeaturesToShapefilesToolStripMenuItem.Size = new System.Drawing.Size(129, 20);
            this.exportFeaturesToShapefilesToolStripMenuItem.Text = "Export Current Layer ";
            // 
            // exportOriginalFeaturesToolStripMenuItem
            // 
            this.exportOriginalFeaturesToolStripMenuItem.Name = "exportOriginalFeaturesToolStripMenuItem";
            this.exportOriginalFeaturesToolStripMenuItem.Size = new System.Drawing.Size(222, 22);
            this.exportOriginalFeaturesToolStripMenuItem.Text = "Export All Original Features";
            this.exportOriginalFeaturesToolStripMenuItem.Click += new System.EventHandler(this.ExportByStatus);
            // 
            // exporToolStripMenuItem
            // 
            this.exporToolStripMenuItem.Name = "exporToolStripMenuItem";
            this.exporToolStripMenuItem.Size = new System.Drawing.Size(222, 22);
            this.exporToolStripMenuItem.Text = "Export All Modified Features";
            this.exporToolStripMenuItem.Click += new System.EventHandler(this.ExportByStatus);
            // 
            // exportAddedFeaturesToolStripMenuItem
            // 
            this.exportAddedFeaturesToolStripMenuItem.Name = "exportAddedFeaturesToolStripMenuItem";
            this.exportAddedFeaturesToolStripMenuItem.Size = new System.Drawing.Size(222, 22);
            this.exportAddedFeaturesToolStripMenuItem.Text = "Export All Added Features";
            this.exportAddedFeaturesToolStripMenuItem.Click += new System.EventHandler(this.ExportByStatus);
            // 
            // exportDeletedFeaturesToolStripMenuItem
            // 
            this.exportDeletedFeaturesToolStripMenuItem.Name = "exportDeletedFeaturesToolStripMenuItem";
            this.exportDeletedFeaturesToolStripMenuItem.Size = new System.Drawing.Size(222, 22);
            this.exportDeletedFeaturesToolStripMenuItem.Text = "Export All Deleted Features";
            this.exportDeletedFeaturesToolStripMenuItem.Click += new System.EventHandler(this.ExportByStatus);
            // 
            // exportAllCurrentFeaturesToolStripMenuItem
            // 
            this.exportAllCurrentFeaturesToolStripMenuItem.Name = "exportAllCurrentFeaturesToolStripMenuItem";
            this.exportAllCurrentFeaturesToolStripMenuItem.Size = new System.Drawing.Size(222, 22);
            this.exportAllCurrentFeaturesToolStripMenuItem.Text = "Export All Current Features";
            this.exportAllCurrentFeaturesToolStripMenuItem.Click += new System.EventHandler(this.ExportByStatus);
            // 
            // menuStrip1
            // 
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.mobileCacheToolStripMenuItem,
            this.mapActionsToolStripMenuItem,
            this.layersToolStripMenuItem,
            this.exportSelectedFeaturesToAShapefileToolStripMenuItem,
            this.exportFeaturesToShapefilesToolStripMenuItem,
            this.exportLayersToolStripMenuItem,
            this.helpToolStripMenuItem});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(875, 24);
            this.menuStrip1.TabIndex = 0;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // exportLayersToolStripMenuItem
            // 
            this.exportLayersToolStripMenuItem.Name = "exportLayersToolStripMenuItem";
            this.exportLayersToolStripMenuItem.Size = new System.Drawing.Size(88, 20);
            this.exportLayersToolStripMenuItem.Text = "Export Layers";
            this.exportLayersToolStripMenuItem.Click += new System.EventHandler(this.testToolStripMenuItem_Click);
            // 
            // helpToolStripMenuItem
            // 
            this.helpToolStripMenuItem.Name = "helpToolStripMenuItem";
            this.helpToolStripMenuItem.Size = new System.Drawing.Size(44, 20);
            this.helpToolStripMenuItem.Text = "Help";
            this.helpToolStripMenuItem.Click += new System.EventHandler(this.helpToolStripMenuItem_Click);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(875, 388);
            this.Controls.Add(this.splitContainer1);
            this.Controls.Add(this.menuStrip1);
            this.MainMenuStrip = this.menuStrip1;
            this.Name = "Form1";
            this.Text = "MobileCache2ShapeFile Tool 10.2";
            this.Load += new System.EventHandler(this.Form1_Load);
            this.splitContainer1.Panel1.ResumeLayout(false);
            this.splitContainer1.Panel2.ResumeLayout(false);
            this.splitContainer1.Panel2.PerformLayout();
            this.splitContainer1.ResumeLayout(false);
            this.statusStrip1.ResumeLayout(false);
            this.statusStrip1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.SplitContainer splitContainer1;
        private ESRI.ArcGIS.Mobile.WinForms.Map map1;
        private ESRI.ArcGIS.Mobile.FeatureCaching.MobileCache mobileCache1;
        private System.Windows.Forms.DataGridView dataGridView1;
        //private ESRI.ArcGIS.Mobile.WinForms.PanMapAction panMapAction1;
        //private ESRI.ArcGIS.Mobile.WinForms.ZoomInMapAction zoomInMapAction1;
        //private ESRI.ArcGIS.Mobile.WinForms.ZoomOutMapAction zoomOutMapAction1;
        //private ESRI.ArcGIS.Mobile.WinForms.SelectionMapAction selectionMapAction1;
        private ESRI.ArcGIS.Mobile.WinForms.MapGraphicLayer selectionGraphicLayer1 = new MapGraphicLayer("selecLayers");
        private System.Windows.Forms.FolderBrowserDialog folderBrowserDialog;
        private System.Windows.Forms.OpenFileDialog openFileDialog;
        private System.Windows.Forms.StatusStrip statusStrip1;
        private System.Windows.Forms.ToolStripProgressBar toolStripProgressBar1;
        private System.Windows.Forms.ToolStripStatusLabel toolStripStatusLabel1;
        private System.Windows.Forms.ToolStripStatusLabel CacheFoldertoolStripStatusLabel;
        private System.Windows.Forms.ToolStripStatusLabel actionToolStripStatusLabel;
        private System.Windows.Forms.ToolStripStatusLabel layerToolStripStatusLabel;
        private System.Windows.Forms.ToolStripStatusLabel selectionStripStatusLabel1;
        private System.Windows.Forms.ToolStripMenuItem mobileCacheToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem openMapCacheFolderToolStripMenuItem;
        private System.Windows.Forms.ToolStripSeparator toolStripMenuItem1;
        private System.Windows.Forms.ToolStripMenuItem exitToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem mapActionsToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem zoomInToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem zoomOutToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem zoomToFullExtentToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem panToolStripMenuItem;
        private System.Windows.Forms.ToolStripSeparator toolStripMenuItem2;
        private System.Windows.Forms.ToolStripMenuItem selectByPointToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem selectByRectangleToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem selectByPolygonToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem layersToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem exportSelectedFeaturesToAShapefileToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem exportFeaturesToShapefilesToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem exportOriginalFeaturesToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem exporToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem exportAddedFeaturesToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem exportDeletedFeaturesToolStripMenuItem;
        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem helpToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem exportAllCurrentFeaturesToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem exportLayersToolStripMenuItem;
        private System.Windows.Forms.ToolStripStatusLabel toolStripStatusLabel2;
        private System.Windows.Forms.ToolStripMenuItem clearSelectionToolStripMenuItem;
        
    }
}

