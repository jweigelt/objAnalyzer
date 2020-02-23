namespace ObjMonitor
{
    partial class ObjForm
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
            this.lvObjects = new ObjMonitor.DoubleBufferedListView();
            this.chHash = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.chId = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.chLupdate = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.chName = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.chClientLag = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.chClassName = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.SuspendLayout();
            // 
            // lvObjects
            // 
            this.lvObjects.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.chHash,
            this.chId,
            this.chLupdate,
            this.chClientLag,
            this.chName,
            this.chClassName});
            this.lvObjects.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lvObjects.FullRowSelect = true;
            this.lvObjects.GridLines = true;
            this.lvObjects.HideSelection = false;
            this.lvObjects.Location = new System.Drawing.Point(0, 0);
            this.lvObjects.Name = "lvObjects";
            this.lvObjects.Size = new System.Drawing.Size(800, 450);
            this.lvObjects.TabIndex = 0;
            this.lvObjects.UseCompatibleStateImageBehavior = false;
            this.lvObjects.View = System.Windows.Forms.View.Details;
            // 
            // chHash
            // 
            this.chHash.Text = "pbl hash";
            this.chHash.Width = 89;
            // 
            // chId
            // 
            this.chId.Text = "id";
            this.chId.Width = 54;
            // 
            // chLupdate
            // 
            this.chLupdate.Text = "last updated";
            this.chLupdate.Width = 107;
            // 
            // chName
            // 
            this.chName.Text = "client name";
            this.chName.Width = 87;
            // 
            // chClientLag
            // 
            this.chClientLag.Text = "ticks behind client";
            this.chClientLag.Width = 110;
            // 
            // chClassName
            // 
            this.chClassName.Text = "class name";
            this.chClassName.Width = 104;
            // 
            // ObjForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.lvObjects);
            this.Name = "ObjForm";
            this.Text = "Object Update Analyzer";
            this.Load += new System.EventHandler(this.ObjForm_Load);
            this.ResumeLayout(false);

        }

        #endregion

        private DoubleBufferedListView lvObjects;
        private System.Windows.Forms.ColumnHeader chHash;
        private System.Windows.Forms.ColumnHeader chId;
        private System.Windows.Forms.ColumnHeader chLupdate;
        private System.Windows.Forms.ColumnHeader chName;
        private System.Windows.Forms.ColumnHeader chClientLag;
        private System.Windows.Forms.ColumnHeader chClassName;
    }
}