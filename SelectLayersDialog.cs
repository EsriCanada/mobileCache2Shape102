using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace mobileCache2Shape10
{
    public partial class SelectLayersDialog : Form
    {
        public List<string> list;
        public List<string> selList;
        public Boolean retVal = false;

        public SelectLayersDialog()
        {
            list = new List<string>();
            selList = new List<string>();
            InitializeComponent();
        }

        private void SelectLayersDialog_Load(object sender, EventArgs e)
        {
            foreach (string layername in list) // Loop through List with foreach
            {
                listBoxLayers.Items.Add(layername);
            }

        }

        private void buttonSelectAll_Click(object sender, EventArgs e)
        {
            for (int x = 0; x < this.listBoxLayers.Items.Count; x++)
            {
                listBoxLayers.SetItemChecked(x, true);
            }
        }


        private void buttonUnselectAll_Click(object sender, EventArgs e)
        {
            for (int x = 0; x < this.listBoxLayers.Items.Count; x++)
            {
                listBoxLayers.SetItemChecked(x, false);
            }
        }

        private void buttonExport_Click(object sender, EventArgs e)
        {
            for (int x = 0; x < this.listBoxLayers.CheckedItems.Count; x++)
            {
                //MessageBox.Show(listBoxLayers.CheckedItems[x].ToString());
                selList.Add(listBoxLayers.CheckedItems[x].ToString());
            }
            
            retVal = true;
            this.Hide();
        }

        private void buttonCancel_Click(object sender, EventArgs e)
        {
            retVal = false;
            this.Hide();
        }
    
    }

}
