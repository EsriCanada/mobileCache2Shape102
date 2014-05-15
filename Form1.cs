using System;
using System.Collections.Generic;
using System.Data;
using System.Drawing;
using System.IO;
using System.Windows.Forms;
using System.Windows.Media.Imaging;
using ESRI.ArcGIS;
using ESRI.ArcGIS.DataSourcesFile;
using ESRI.ArcGIS.esriSystem;
using ESRI.ArcGIS.Geodatabase;
using ESRI.ArcGIS.Mobile;
using ESRI.ArcGIS.Mobile.Geometries;
using ESRI.ArcGIS.Mobile.WinForms;
using ESRI.ArcGIS.Mobile.FeatureCaching;

namespace mobileCache2Shape10
{
    public partial class Form1 : Form
    {
        [System.Runtime.InteropServices.DllImport("gdi32.dll")]
        internal static extern bool DeleteObject(IntPtr gdiobj);

        // to keep current mapaction
        ToolStripMenuItem currentActionMenuItem;
        ToolStripMenuItem currentLayerMenuItem;

        String selLayerName;
        FeatureSource selLayer;

        public Form1()
        {
            if (!RuntimeManager.Bind(ProductCode.Desktop))
                MessageBox.Show("Could not bind to Desktop");

            // Usual engine initialization code follows from here (AoInitialize).
            IAoInitialize init = new AoInitializeClass();
            esriLicenseStatus licStatus = init.IsProductCodeAvailable(esriLicenseProductCode.esriLicenseProductCodeAdvanced);

            if (licStatus == esriLicenseStatus.esriLicenseAvailable)
            {
                init.Initialize(esriLicenseProductCode.esriLicenseProductCodeAdvanced);
            }
            else
            {
                licStatus = init.IsProductCodeAvailable(esriLicenseProductCode.esriLicenseProductCodeStandard);
                if (licStatus == esriLicenseStatus.esriLicenseAvailable)
                {
                    init.Initialize(esriLicenseProductCode.esriLicenseProductCodeStandard);
                }
                else
                {
                    licStatus = init.IsProductCodeAvailable(esriLicenseProductCode.esriLicenseProductCodeBasic);
                    if (licStatus == esriLicenseStatus.esriLicenseAvailable)
                    {
                        init.Initialize(esriLicenseProductCode.esriLicenseProductCodeBasic);
                    }
                    else
                    {
                        MessageBox.Show("No license available for Basic/Standard/Advanced.");
                    }
                }
            }
            InitializeComponent();
            init.Shutdown();
        }


        private void Form1_Load(object sender, EventArgs e)
        {   
            //MapGraphicLayer selectlayer = new MapGraphicLayer("selLayers");
            //map1.MapGraphicLayers.Add(selectlayer);   
            map1.MapGraphicLayers.Add(selectionGraphicLayer1);
            selectionMapAction1.StatusChanged += new EventHandler<MapActionStatusChangedEventArgs>(selectionMapAction1_StatusChanged);
            selectionMapAction1.SelectionGraphicLayer = selectionGraphicLayer1;
        }

        public string SelectAFolder()
        {


            string SelectedPath = null;
            using (OpenFileDialog Ofd = new OpenFileDialog())
            {
                {
                    Ofd.RestoreDirectory = false;
                    Ofd.Title = "Select the MapSchema.bin file to open the map cache";

                    if (Ofd.ShowDialog() == DialogResult.OK)
                    {
                        //SelectedPath = Environment.CurrentDirectory;
                        SelectedPath = Ofd.FileName.ToString();
                        int pos = SelectedPath.LastIndexOf("\\");
                        string temp = SelectedPath.Substring(0, pos);
                        SelectedPath = temp;
                    }
                }
            }

            return SelectedPath;
        }


        private void openMapCacheFolderToolStripMenuItem_Click(object sender, EventArgs e)
        {
            // use the choose file dialog, 
            selectionMapAction1.SelectionFeatureSources.Clear();

            string cachePath = SelectAFolder();
            if (cachePath == null)
                return;

            /*
            // use system folderbrowse dialog
            DialogResult dialogResult = folderBrowserDialog.ShowDialog();
            if (dialogResult == DialogResult.Cancel)
              return;

            string cachePath = folderBrowserDialog.SelectedPath;
            */

            // Close map cache is map is opened
            if (mobileCache1.IsOpen)
                mobileCache1.Close();

            try
            {
                mobileCache1.StoragePath = cachePath;
                //CacheFoldertoolStripStatusLabel.Text = cachePath + ",";

                // open existing cache, or create a new one 
                mobileCache1.Open();
                map1.MapLayers.Add(mobileCache1);
                //map1.Extent = map1.FullExtent;

                // populates the layer names to layers menu
                layersToolStripMenuItem.DropDownItems.Clear();
                //foreach (MapLayer alayer in map1.MapLayers)
                foreach (FeatureSource alayer in mobileCache1.FeatureSources)
                {
                     System.Windows.Forms.ToolStripMenuItem aLayerMenu = new ToolStripMenuItem();
                    aLayerMenu.Name = alayer.Name + "StripMenuItem";
                    aLayerMenu.Text = alayer.Name;
                    aLayerMenu.Click += new EventHandler(this.layersMenuHandler);

                    layersToolStripMenuItem.DropDownItems.Add(aLayerMenu);
                }

            }
            catch (Exception ex)
            {
                MessageBox.Show("Exception: " + ex.ToString());
            }
        }

        void layersMenuHandler(object sender, EventArgs e)
        {
            // unchecks the last selected layer
            if (currentLayerMenuItem != null)
                currentLayerMenuItem.CheckState = CheckState.Unchecked;

            // sets selected layer to the current one
            currentLayerMenuItem = sender as ToolStripMenuItem;
            currentLayerMenuItem.CheckState = CheckState.Checked;
            selLayerName = sender.ToString();
             selLayer = mobileCache1.FeatureSources[selLayerName] as FeatureSource;

            selectionMapAction1.SelectionFeatureSources.Clear();
            selectionMapAction1.SelectionFeatureSources.Add(selLayer);

			int originalcount = selLayer.GetFeatureCount(EditState.Original);
			int addedcount = selLayer.GetFeatureCount(EditState.Added);
			int modifiedcount = selLayer.GetFeatureCount(EditState.Modified);
			int deletedcount = selLayer.GetFeatureCount(EditState.Deleted);
			int currentcount = selLayer.GetFeatureCount(EditState.Current);			
			
            // message on the status bar
            layerToolStripStatusLabel.Text = selLayerName + " ["
                + originalcount.ToString() + " Original, "
                + addedcount.ToString() + " Added, "
                + modifiedcount.ToString() + " Modified, "
                + deletedcount.ToString() + " deleted,  "
                + currentcount.ToString() + " Current ]";
        }

        private void actionsMenuHandler(object sender, EventArgs e)
        {
            // checks status on the menuitem
            if (currentActionMenuItem != null)
                currentActionMenuItem.CheckState = CheckState.Unchecked;

            currentActionMenuItem = sender as ToolStripMenuItem;
            currentActionMenuItem.CheckState = CheckState.Checked;

            // status bar
            actionToolStripStatusLabel.Text = sender.ToString();
            layerToolStripStatusLabel.Text = "";

            switch (sender.ToString())
            {
                case "Zoom In":
                    map1.MapAction = zoomInMapAction1;
                    break;
                case "Zoom Out":
                    map1.MapAction = zoomOutMapAction1;
                    break;
                case "Pan":
                    map1.MapAction = panMapAction1;
                    break;
                case "Zoom to Full Extent":
                    map1.Extent = map1.FullExtent;
                    map1.Refresh();
                    break;
            }
        }

        private void selectionMenuHandler(object sender, EventArgs e)
        {
            selectionGraphicLayer1.Graphics.Clear();

            // to check if you have specified a layer for selction
            if (selectionMapAction1.SelectionFeatureSources.Count == 0)
            {
                MessageBox.Show("select a layer first", "Warning");
                layerToolStripStatusLabel.Text = "Select a layer first";
                return;
            }

            // takes care of the selectstas of the menuitem			
            if (currentActionMenuItem != null)
                currentActionMenuItem.CheckState = CheckState.Unchecked;
            currentActionMenuItem = sender as ToolStripMenuItem;

            // sets current mapaction to selection
            map1.MapAction = selectionMapAction1;

            // sets message on the status bar
            actionToolStripStatusLabel.Text = sender.ToString() + ", ";

            // how do you select, by rect, point or polygon /rubberband
            switch (sender.ToString())
            {
                case "Select by Point":
                    selectionMapAction1.SelectionType = SelectionType.Point;
                    break;

                case "Select by Rectangle":
                    selectionMapAction1.SelectionType = SelectionType.Envelope;
                    break;

                case "Select by Polygon":
                    selectionMapAction1.SelectionType = SelectionType.Polygon;
                    break;
            }
            // checks the selection
            currentActionMenuItem.CheckState = CheckState.Checked;
        }

        //private void selectionMapAction1_StatusChanged(object sender, MapActionStatusChangedEventArgs e)
        //{
        //    //Checked if selection is completed and something is selected 
        //    if (e.StatusId != MapAction.Completed)
        //        return;

        //    if (selectionMapAction1.SelectedFeatures.Count == 0)
        //        return;

        //    //foreach (FeatureDataTable fdtable in selectionMapAction1.SelectedFeatures)
        //    //{
        //    //    //Use the featurelayer name for the tab name
        //    //    tabControlGrid.TabPages.Add(fdtable.FeatureSource.Name);
        //    //}

        //    ////The tab opens on the first layer and uses that to populate the grid
        //    //dataGridSelect.Parent = tabControlGrid.TabPages[0];
        //    //dataGridSelect.DataSource = selectionMapAction1.SelectedFeatures[0];
        //}
        void selectionMapAction1_StatusChanged(object sender, ESRI.ArcGIS.Mobile.WinForms.MapActionStatusChangedEventArgs e) 
        {
            //Checked if selection is completed and something is selected 
            if (e.StatusId != MapAction.Completed)
                return;

            if (selectionMapAction1.SelectedFeatures.Count == 0)
                return;
            
            // cleans the previous results
            dataGridView1.DataSource = null;
            
            // gets the result
            IList<FeatureDataTable> selectedDataTables = selectionMapAction1.SelectedFeatures;
            if (selectedDataTables == null || selectedDataTables.Count == 0)
                return;

            // populates the result in the datagrid
            FeatureDataTable ftable = selectionMapAction1.SelectedFeatures[0];
            dataGridView1.DataSource = ftable;
            selectionStripStatusLabel1.Text = ftable.Rows.Count.ToString() + " features selected.";
        }

        // export selected featuers to shapefile
        private void exportSelectedFeaturesToAShapefileToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (dataGridView1.Rows.Count == 0)
            {
                MessageBox.Show("no feature selected");
                return;
            }

            String shapefilePath = mobileCache1.StoragePath + "\\shapefiles" + "\\" + selLayer.Name;

            // create a empty feature class under shapefiles folder
            IFeatureClass fc = CreateShapefile(shapefilePath, selLayer, selLayer.Name);

            if (fc == null)
                return;

            //insert the selected features one by one
            FeatureDataTable ftable = selectionMapAction1.SelectedFeatures[0];

            WriteFeatureDataTable2shp(selLayer.GeometryType, ftable, fc, shapefilePath);
        }

        // FeatureDataTablet to shapefile
        private void WriteFeatureDataTable2shp(GeometryType gtype, FeatureDataTable ftable, IFeatureClass fc, String shapefilePath)
        {
            int rowCount = ftable.Rows.Count;
            int colCount = ftable.Columns.Count;
            int geometryColIndex = ftable.GeometryColumnIndex;
            //GeometryType gtype = selLayer.GeometryType;
            toolStripProgressBar1.Maximum = rowCount;
            toolStripProgressBar1.Value = 0;
            toolStripProgressBar1.Visible = true;
           
            // for each selected features
            for (int i = 0; i < rowCount; i++)
            {
                toolStripProgressBar1.Value = i + 1;
                selectionStripStatusLabel1.Text = toolStripProgressBar1.Value.ToString() + "/" + rowCount.ToString() + " features exported .";
                toolStripStatusLabel2.Text = shapefilePath;
                Application.DoEvents();

                // create a new feature 
                IFeature feature = fc.CreateFeature();
                DataRow arow = ftable.Rows[i];
                string globalid;
                if (arow.Table.Columns.Contains("GlobalID"))
                {
                    globalid = arow["GlobalID"].ToString();
                }
                else
                {
                    globalid = arow["OBJECTID"].ToString();
                }

                // geometry
                ESRI.ArcGIS.Mobile.Geometries.Geometry mobileGeometry = arow[geometryColIndex] as ESRI.ArcGIS.Mobile.Geometries.Geometry;
                byte[] mobileGeometryByteArray = mobileGeometry.ExportToEsriShape();
                int len = mobileGeometryByteArray.Length;
                switch (gtype)
                {
                    case GeometryType.Point:
                        ESRI.ArcGIS.Geometry.IPoint aoShape = new ESRI.ArcGIS.Geometry.PointClass();
                        ((ESRI.ArcGIS.Geometry.IESRIShape)aoShape).ImportFromESRIShape(ref len, ref mobileGeometryByteArray[0]);
                        feature.Shape = aoShape;
                        break;

                    case GeometryType.Multipoint:
                        ESRI.ArcGIS.Geometry.IMultipoint aoShape2 = new ESRI.ArcGIS.Geometry.MultipointClass();
                        ((ESRI.ArcGIS.Geometry.IESRIShape)aoShape2).ImportFromESRIShape(ref len, ref mobileGeometryByteArray[0]);
                        feature.Shape = aoShape2;
                        break;

                    case GeometryType.Polyline:
                        ESRI.ArcGIS.Geometry.IPolyline aoShape3 = new ESRI.ArcGIS.Geometry.PolylineClass();
                        ((ESRI.ArcGIS.Geometry.IESRIShape)aoShape3).ImportFromESRIShape(ref len, ref mobileGeometryByteArray[0]);
                        feature.Shape = aoShape3;
                        break;

                    case GeometryType.Polygon:
                        ESRI.ArcGIS.Geometry.IPolygon aoShape4 = new ESRI.ArcGIS.Geometry.PolygonClass();
                        ((ESRI.ArcGIS.Geometry.IESRIShape)aoShape4).ImportFromESRIShape(ref len, ref mobileGeometryByteArray[0]);
                        feature.Shape = aoShape4;
                        break;
                }

                // insert other attributes
                // in mobile cache, the last col is for geometry
                // in shapefile, fid and shape fields are first two, for other fields index = +2
                for (int col = 0; col < colCount - 1; col++)
                {
                    // type
                    DataColumn dc = ftable.Columns[col];
                    Type dt = dc.DataType;

                    // guid or globalid, change to string
                    if (dt == typeof(Guid) || (dt == typeof(ESRI.ArcGIS.Mobile.GlobalId)))
                    {
                        feature.set_Value(col + 2, arow[col].ToString());
                        //feature.Store();
                        continue;
                    }

                    // if blob field, write to file
                    if (dt == typeof(Byte[]))
                    {
                        continue;
                    }
                    // raster field, write to jpg files
                    if (dt == typeof(Bitmap))
                    {
                        string photofoldername = shapefilePath + "\\" + dc.ColumnName;
                        if (!Directory.Exists(photofoldername))
                            continue;

                        // get bitmap from a raster field, save to ImageSource
                        System.Windows.Media.ImageSource imgsrc = null;
                        Bitmap bitmap = arow[col] as Bitmap;
                        if (bitmap == null)
                            continue;

                        System.Windows.Int32Rect rect = new System.Windows.Int32Rect(0, 0, bitmap.Width, bitmap.Height);
                        IntPtr hBitmap = IntPtr.Zero;
                        try
                        {
                            hBitmap = bitmap.GetHbitmap();
                            imgsrc = System.Windows.Interop.Imaging.CreateBitmapSourceFromHBitmap(
                                     hBitmap, IntPtr.Zero, rect, BitmapSizeOptions.FromEmptyOptions());

                            // write the ImageSource to jpg
                            if (imgsrc == null)
                                continue;
                            JpegBitmapEncoder encoder = new JpegBitmapEncoder();
                            encoder.Frames.Add(BitmapFrame.Create(imgsrc as BitmapSource));
                            string fileName = photofoldername + "\\" + globalid + ".jpg";
                            using (System.IO.FileStream file = File.OpenWrite(fileName))
                            {
                                encoder.Save(file);
                            }

                            continue;

                        }
                        finally
                        {
                            if (hBitmap != IntPtr.Zero)
                                DeleteObject(hBitmap);
                        }
                    }  // end of bitmap


                    // other data types, just set the value
                    if (arow[col].ToString() != "")
                        feature.set_Value(col + 2, arow[col]);
                    else
                        feature.set_Value(col + 2, 0);

                }

                feature.Store();
            }

            //MessageBox.Show(rowCount.ToString() + " features saved into a shapefile at: " + shapefilePath);
            toolStripProgressBar1.Value = 0;
            selectionStripStatusLabel1.Text = "";
            toolStripProgressBar1.Visible = false;

            return;
        }

        /////////////////////////////////////////////////////////////////////////////////////////////
        // create a shapefile
        public IFeatureClass CreateShapefile(string strShapeFolder, FeatureSource selLayer, string shpFileName)
        {
            Console.WriteLine(shpFileName);

            // prepared the shapefile fodler
            try
            {
                if (!System.IO.Directory.Exists(strShapeFolder))
                    System.IO.Directory.CreateDirectory(strShapeFolder);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }

            // if shapefile already exists, overwrite?
            string shpfileName = strShapeFolder + "\\" + shpFileName + ".shp";
            string dbffileName = strShapeFolder + "\\" + shpFileName + ".dbf";
            string shxfileName = strShapeFolder + "\\" + shpFileName + ".shx";
            if (File.Exists(shpfileName) || File.Exists(dbffileName) || File.Exists(shxfileName))
            {
                if (MessageBox.Show("shape file: " + strShapeFolder + "\\" + selLayer.Name + " already exists", "overwrite?", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.No)
                    return null;
                else
                {
                    File.Delete(shpfileName);
                    File.Delete(dbffileName);
                    File.Delete(shxfileName);
                }
            }

            // create workspace
            IWorkspaceFactory pWSF = new ShapefileWorkspaceFactoryClass();
            IFeatureWorkspace pWS = (IFeatureWorkspace)pWSF.OpenFromFile(strShapeFolder, 0);

            // get the feature table
            FeatureDataTable ftable = selLayer.GetDataTable();
            int rowCount = ftable.Rows.Count;
            int colCount = ftable.Columns.Count;
            int geometryColIndex = ftable.GeometryColumnIndex;

            // create fields
            //fields
            ESRI.ArcGIS.Geodatabase.IFields pFields = new FieldsClass();
            IFieldsEdit pFieldsEdit = (IFieldsEdit)pFields;
            pFieldsEdit.FieldCount_2 = colCount;
            Console.WriteLine("Colume Counts = " + colCount.ToString());

            //field
            IField pField;
            IFieldEdit pFieldEdit;
            string shpFldName = "";

            for (int col = 0; col < colCount; col++)
            {
                DataColumn dc = ftable.Columns[col];
                pField = new FieldClass();
                pFieldEdit = (IFieldEdit)pField;

                String colname = dc.ColumnName;
                if (colname.Length > 10)
                {
                    colname = colname.Substring(0, 8) + col.ToString();
                }

                pFieldEdit.AliasName_2 = colname;
                pFieldEdit.Name_2 = colname;
                pFieldEdit.IsNullable_2 = true;
                pFieldEdit.Editable_2 = true;

                Type dt = dc.DataType;
                Console.WriteLine(dc.ColumnName + "\t\t" + colname + "\t\t" + dt.ToString());

                if (dt == typeof(String))
                    pFieldEdit.Type_2 = esriFieldType.esriFieldTypeString;

                else if ((dt == typeof(Boolean)))
                    pFieldEdit.Type_2 = esriFieldType.esriFieldTypeSmallInteger;
                else if ((dt == typeof(Int16)) || (dt == typeof(Int32)) || (dt == typeof(Int64)))
                    pFieldEdit.Type_2 = esriFieldType.esriFieldTypeInteger;
                else if (dt == typeof(Double))
                    pFieldEdit.Type_2 = esriFieldType.esriFieldTypeDouble;
                else if (dt == typeof(Single))
                    pFieldEdit.Type_2 = esriFieldType.esriFieldTypeSingle;
                else if (dt == typeof(DateTime))
                    pFieldEdit.Type_2 = esriFieldType.esriFieldTypeDate;
                else if (dt == typeof(Guid))
                    //pFieldEdit.Type_2 = esriFieldType.esriFieldTypeGUID;    // not supported by shapefile
                    pFieldEdit.Type_2 = esriFieldType.esriFieldTypeString;
                else if (dt == typeof(ESRI.ArcGIS.Mobile.GlobalId))
                    pFieldEdit.Type_2 = esriFieldType.esriFieldTypeString;
                //pFieldEdit.Type_2 = esriFieldType.esriFieldTypeGlobalID;  // not supported by shapefile

                else if (dt == typeof(Bitmap))   // raster or blob, not supported by shapefile, 
                {
                    Console.WriteLine(dc.ColumnName + ": raster field found\n");
                    string folder = strShapeFolder + "\\" + dc.ColumnName;
                    try
                    {
                        if (!Directory.Exists(folder))
                            Directory.CreateDirectory(folder);
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show(ex.ToString());
                        return null;
                    }
                    pFieldEdit.Type_2 = esriFieldType.esriFieldTypeString;
                }
                else if (dt == typeof(System.Byte[]))   // raster or blob, not supported by shapefile, 
                {
                    Console.WriteLine(dc.ColumnName + ": blob field found\n");
                    pFieldEdit.Type_2 = esriFieldType.esriFieldTypeString;
                }
                else if (dt == typeof(Bitmap))   // raster or blob, not supported by shapefile, 
                {
                    Console.WriteLine(dc.ColumnName + ": raster field found\n");
                    string folder = strShapeFolder + "\\" + dc.ColumnName;
                    try
                    {
                        if (!Directory.Exists(folder))
                            Directory.CreateDirectory(folder);
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show(ex.ToString());
                        return null;
                    }

                    pFieldEdit.Type_2 = esriFieldType.esriFieldTypeString;
                }
                else if (dt == typeof(System.Byte[]))   // raster or blob, not supported by shapefile, 
                {
                    Console.WriteLine(dc.ColumnName + ": blob field found\n");
                    pFieldEdit.Type_2 = esriFieldType.esriFieldTypeString;
                }
                else if (dt == typeof(ESRI.ArcGIS.Mobile.Geometries.Geometry))
                {
                    Console.WriteLine("geometry field found\n");
                    shpFldName = dc.ColumnName;
                    pFieldEdit.Type_2 = esriFieldType.esriFieldTypeGeometry;
                    IGeometryDef pGeoDef = new GeometryDefClass();
                    IGeometryDefEdit pGeoDefEdit = (IGeometryDefEdit)pGeoDef;
                    pGeoDefEdit.GeometryType_2 = (ESRI.ArcGIS.Geometry.esriGeometryType)selLayer.GeometryType;
                    pGeoDefEdit.SpatialReference_2 = new ESRI.ArcGIS.Geometry.UnknownCoordinateSystemClass();
                    pFieldEdit.GeometryDef_2 = pGeoDef;
                }

                else
                {
                    throw (new Exception("different data type found, modify the code"));
                }

                // add the field to fields
                pFieldsEdit.set_Field(col, pFieldEdit);
            }


            for (int ii = 0; ii < pFields.FieldCount; ii++)
            {
                Console.WriteLine(pFields.get_Field(ii).Name + "\t\t" + pFields.get_Field(ii).Type.ToString());
            }


            //create shapefile
            IFeatureClass fc = null;
            try
            {
                fc = pWS.CreateFeatureClass(shpFileName, pFields, null, null, esriFeatureType.esriFTSimple, shpFldName, "");
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }

            if (fc != null)
                return fc;
            else
                return null;
        }
        //////////////////////////////////////////////////////////////////////////////////        


        ////////////////////////////////////////////////////////////////////////////////// 
        //export by status
        /***************************************************************************
         -From “Export Selected layer to a shapefile” menu, you can
  .     Export all original features, save to    …\shapefiles\layername_O.shp
  .     Export all Added features, save to    …\shapefiles\layername_A.shp
  .     Export all Deleted features, save to    …\shapefiles\layername_D.shp
                these deleted features still in the cache, just flagged as deleted)
  .     Export all Modified features,   save to    …\shapefiles\layername_M.shp
  .     Export all Current features,  save to    …\shapefiles\layername_C.shp
               (current = original + added – deleted) 
         */
        private void ExportByStatus(object sender, EventArgs e)
        {
            // to check if you have specified a layer for selction
            if (selectionMapAction1.SelectionFeatureSources.Count == 0)
            {
                MessageBox.Show("select a layer first", "Warning");
                layerToolStripStatusLabel.Text = "Select a layer first";
                return;
            }

            string menutitle = sender.ToString();
            string shpFileName = "";
            FeatureDataTable fdt = null;

            if (menutitle.Contains("Modified"))
            {
                fdt = selLayer.GetDataTable(null, EditState.Modified, null);
                shpFileName = selLayer.Name + "_M";
            }
            else if (menutitle.Contains("Added"))
            {
                fdt = selLayer.GetDataTable(null, EditState.Added, null);
                shpFileName = selLayer.Name + "_A";
            }
            else if (menutitle.Contains("Original"))
            {
                fdt = selLayer.GetDataTable(null, EditState.Original, null);
                shpFileName = selLayer.Name + "_O";
            }
            else if (menutitle.Contains("Deleted"))
            {
                fdt = selLayer.GetDataTable(null, EditState.Deleted, null);
                shpFileName = selLayer.Name + "_D";
            }
            else if (menutitle.Contains("Current"))
            {
                fdt = selLayer.GetDataTable(null, EditState.Current, null);
                shpFileName = selLayer.Name + "_C";
            }
            else
            {

            }
            ///////////////////////////////////

            //String shapefilePath = mobileCache1.StoragePath + "\\shapefiles";
            String shapefilePath = mobileCache1.StoragePath + "\\shapefiles" + "\\" + shpFileName;
            // create a empty feature class under shapefiles folder
            IFeatureClass fc = CreateShapefile(shapefilePath, selLayer, shpFileName);
            if (fc == null)
                return;
            
            //populate date to shape file
            if(fdt != null)
                WriteFeatureDataTable2shp(selLayer.GeometryType, fdt, fc, shapefilePath);
        }

        private void helpToolStripMenuItem_Click(object sender, EventArgs e)
        {
            AboutBox1 a = new AboutBox1();
            a.Show();
        }

        private void exitToolStripMenuItem_Click(object sender, EventArgs e)
        {
            System.Windows.Forms.Application.Exit();
        }

        private void testToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (map1.MapLayers.Count == 0)
            {
                MessageBox.Show("open a mobile cache first");
                return;
            }

            List<string> list = new List<string>();
            string strLayersName = "";

            //foreach (MapLayer alayer in map1.MapLayers)
            foreach (FeatureSource alayer in mobileCache1.FeatureSources)
            {
                list.Add(alayer.Name);
            }

            SelectLayersDialog sld = new SelectLayersDialog();
            sld.list = list;
            sld.ShowDialog(this);

            if (sld.retVal == false)
                return;

            // if export, get the list of layers here
            List<string> sellist = sld.selList;
            
            // loop each layer
            foreach (string ly in sellist)
            {
                Console.WriteLine("exporting " + ly + "...");
                strLayersName += ly + "\r\n";

                String shpFileName = ly + "_C";
                String shapefilePath = mobileCache1.StoragePath + "\\shapefiles" + "\\" + shpFileName; ;
                
                // get the layer
                FeatureSource aLayer = mobileCache1.FeatureSources[ly] as FeatureSource;

                // create a empty feature class under shapefiles folder
                IFeatureClass fc = CreateShapefile(shapefilePath, aLayer, shpFileName);
                if (fc == null)
                    return;

                //populate date to shape file
                FeatureDataTable fdt = aLayer.GetDataTable(null, EditState.Current, null);
                if (fdt != null)
                    WriteFeatureDataTable2shp(aLayer.GeometryType, fdt, fc, shapefilePath);
            }
            toolStripStatusLabel2.Text = "";
            MessageBox.Show("layers exported: \r\n---------------\r\n" + strLayersName);
        }

        private SelectionMapAction selectionMapAction1 = new SelectionMapAction();
        AddVertexSketchTool addVertexSketchTool1 = new AddVertexSketchTool();
        DeleteVertexSketchTool deleteVertexSketchTool1 = new DeleteVertexSketchTool();
        DragRectangleMapAction dragRectangleMapAction1 = new DragRectangleMapAction();
        InsertVertexSketchTool insertVertexSketchTool1 = new InsertVertexSketchTool();
        MoveVertexSketchTool moveVertexSketchTool1 = new MoveVertexSketchTool();
        SketchGraphicLayer sketchGraphicLayer1 = new SketchGraphicLayer();
        PanMapAction panMapAction1 = new PanMapAction();
        ZoomInMapAction zoomInMapAction1 = new ZoomInMapAction();
        ZoomOutMapAction zoomOutMapAction1 = new ZoomOutMapAction();

        private void mobileCacheToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }

        private void layersToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }

        private void clearSelectionToolStripMenuItem_Click(object sender, EventArgs e)
        {
            selectionGraphicLayer1.Graphics.Clear();
            selectionGraphicLayer1.Refresh();
        }

 
    }

}
