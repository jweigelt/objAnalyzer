using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ObjMonitor
{
    public partial class ObjForm : Form
    {
        public ObjForm()
        {
            InitializeComponent();
        }

        private void ObjForm_Load(object sender, EventArgs e)
        {

        }
        public void UpdateObjList(List<BF2IngameObject> objList)
        {
            lvObjects.BeginUpdate();
            lvObjects.Items.Clear();
            foreach(var obj in objList)
            {
                var li = new ListViewItem();
                li.Text = obj.Hash.ToString();
                li.SubItems.Add(obj.Index.ToString());
                li.SubItems.Add(obj.LastUpdate.ToString());
                li.SubItems.Add(obj.ClientLag.ToString());
                li.SubItems.Add(obj.Name);
                li.SubItems.Add(obj.ClassName);

                if (obj.Exists) { 
                    if (obj.ClientLag == 0)
                        li.BackColor = Color.PaleGreen;
                    else if (obj.ClientLag < 5)
                        li.BackColor = Color.Wheat;
                    else
                        li.BackColor = Color.Coral;
                }

                lvObjects.Items.Add(li);
            }
            lvObjects.EndUpdate();
        }

        public void UpdateStats(float ups)
        {
            Text = string.Format("Object Update Analyzer - {0} updates/s", ups.ToString("n2"));
        }
    }
}
