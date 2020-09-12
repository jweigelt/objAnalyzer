using System.Windows.Forms;

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
            this.label1 = new System.Windows.Forms.Label();
            this.cbHost = new System.Windows.Forms.CheckBox();
            this.lvGameInfo = new ObjMonitor.DoubleBufferedListView();
            this.chTeamName = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.chScore = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.chNumKills = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.chNumAlive = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.lvTeam2Objects = new ObjMonitor.DoubleBufferedListView();
            this.chTeam2ID = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.chTeam2Name = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.chTeam2Class = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.chTeam2Kills = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.chTeam2Health = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.lvTeam1Objects = new ObjMonitor.DoubleBufferedListView();
            this.chId = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.chName = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.chClassName = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.chKills = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.chHealth = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.lbTeam1Name = new System.Windows.Forms.Label();
            this.lbTeam2Name = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 30F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Pixel, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(174, 73);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(69, 36);
            this.label1.TabIndex = 2;
            this.label1.Text = "Info";
            // 
            // cbHost
            // 
            this.cbHost.AutoSize = true;
            this.cbHost.Location = new System.Drawing.Point(13, 13);
            this.cbHost.Name = "cbHost";
            this.cbHost.Size = new System.Drawing.Size(52, 17);
            this.cbHost.TabIndex = 4;
            this.cbHost.Text = "host?";
            this.cbHost.UseVisualStyleBackColor = true;
            // 
            // lvGameInfo
            // 
            this.lvGameInfo.BackColor = System.Drawing.SystemColors.AppWorkspace;
            this.lvGameInfo.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.chTeamName,
            this.chScore,
            this.chNumKills,
            this.chNumAlive});
            this.lvGameInfo.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lvGameInfo.HideSelection = false;
            this.lvGameInfo.Location = new System.Drawing.Point(34, 156);
            this.lvGameInfo.Name = "lvGameInfo";
            this.lvGameInfo.Size = new System.Drawing.Size(324, 86);
            this.lvGameInfo.TabIndex = 5;
            this.lvGameInfo.UseCompatibleStateImageBehavior = false;
            this.lvGameInfo.View = System.Windows.Forms.View.Details;
            // 
            // chTeamName
            // 
            this.chTeamName.Text = "Name";
            // 
            // chScore
            // 
            this.chScore.Text = "Score";
            // 
            // chNumKills
            // 
            this.chNumKills.Text = "Team # Kills";
            this.chNumKills.Width = 97;
            // 
            // chNumAlive
            // 
            this.chNumAlive.Text = "Team # Alive";
            this.chNumAlive.Width = 103;
            // 
            // lvTeam2Objects
            // 
            this.lvTeam2Objects.BackColor = System.Drawing.SystemColors.AppWorkspace;
            this.lvTeam2Objects.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.chTeam2ID,
            this.chTeam2Name,
            this.chTeam2Class,
            this.chTeam2Kills,
            this.chTeam2Health});
            this.lvTeam2Objects.ForeColor = System.Drawing.Color.Black;
            this.lvTeam2Objects.FullRowSelect = true;
            this.lvTeam2Objects.GridLines = true;
            this.lvTeam2Objects.HideSelection = false;
            this.lvTeam2Objects.Location = new System.Drawing.Point(447, 236);
            this.lvTeam2Objects.Name = "lvTeam2Objects";
            this.lvTeam2Objects.Size = new System.Drawing.Size(341, 129);
            this.lvTeam2Objects.TabIndex = 3;
            this.lvTeam2Objects.UseCompatibleStateImageBehavior = false;
            this.lvTeam2Objects.View = System.Windows.Forms.View.Details;
            // 
            // chTeam2ID
            // 
            this.chTeam2ID.Text = "ID";
            this.chTeam2ID.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.chTeam2ID.Width = 30;
            // 
            // chTeam2Name
            // 
            this.chTeam2Name.Text = "Client Name";
            this.chTeam2Name.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.chTeam2Name.Width = 99;
            // 
            // chTeam2Class
            // 
            this.chTeam2Class.Text = "Class";
            this.chTeam2Class.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.chTeam2Class.Width = 121;
            // 
            // chTeam2Kills
            // 
            this.chTeam2Kills.Text = "Kills";
            this.chTeam2Kills.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.chTeam2Kills.Width = 40;
            // 
            // chTeam2Health
            // 
            this.chTeam2Health.Text = "Health";
            this.chTeam2Health.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.chTeam2Health.Width = 46;
            // 
            // lvTeam1Objects
            // 
            this.lvTeam1Objects.BackColor = System.Drawing.SystemColors.AppWorkspace;
            this.lvTeam1Objects.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.chId,
            this.chName,
            this.chClassName,
            this.chKills,
            this.chHealth});
            this.lvTeam1Objects.ForeColor = System.Drawing.Color.Black;
            this.lvTeam1Objects.FullRowSelect = true;
            this.lvTeam1Objects.GridLines = true;
            this.lvTeam1Objects.HideSelection = false;
            this.lvTeam1Objects.Location = new System.Drawing.Point(447, 30);
            this.lvTeam1Objects.Name = "lvTeam1Objects";
            this.lvTeam1Objects.Size = new System.Drawing.Size(341, 129);
            this.lvTeam1Objects.TabIndex = 0;
            this.lvTeam1Objects.UseCompatibleStateImageBehavior = false;
            this.lvTeam1Objects.View = System.Windows.Forms.View.Details;
            // 
            // chId
            // 
            this.chId.Text = "ID";
            this.chId.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.chId.Width = 30;
            // 
            // chName
            // 
            this.chName.Text = "Client Name";
            this.chName.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.chName.Width = 99;
            // 
            // chClassName
            // 
            this.chClassName.Text = "Class";
            this.chClassName.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.chClassName.Width = 125;
            // 
            // chKills
            // 
            this.chKills.Text = "Kills";
            this.chKills.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.chKills.Width = 37;
            // 
            // chHealth
            // 
            this.chHealth.Text = "Health";
            this.chHealth.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.chHealth.Width = 46;
            // 
            // lbTeam1Name
            // 
            this.lbTeam1Name.AutoSize = true;
            this.lbTeam1Name.Font = new System.Drawing.Font("Microsoft Sans Serif", 13F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbTeam1Name.Location = new System.Drawing.Point(604, 5);
            this.lbTeam1Name.Name = "lbTeam1Name";
            this.lbTeam1Name.Size = new System.Drawing.Size(71, 22);
            this.lbTeam1Name.TabIndex = 6;
            this.lbTeam1Name.Text = "Team1";
            // 
            // lbTeam2Name
            // 
            this.lbTeam2Name.AutoSize = true;
            this.lbTeam2Name.Font = new System.Drawing.Font("Microsoft Sans Serif", 13F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbTeam2Name.Location = new System.Drawing.Point(604, 211);
            this.lbTeam2Name.Name = "lbTeam2Name";
            this.lbTeam2Name.Size = new System.Drawing.Size(71, 22);
            this.lbTeam2Name.TabIndex = 7;
            this.lbTeam2Name.Text = "Team2";
            // 
            // ObjForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 411);
            this.Controls.Add(this.lbTeam2Name);
            this.Controls.Add(this.lbTeam1Name);
            this.Controls.Add(this.lvGameInfo);
            this.Controls.Add(this.cbHost);
            this.Controls.Add(this.lvTeam2Objects);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.lvTeam1Objects);
            this.ForeColor = System.Drawing.SystemColors.ControlText;
            this.Name = "ObjForm";
            this.Text = "Game Info";
            this.Load += new System.EventHandler(this.ObjForm_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.ColumnHeader chId;
        private System.Windows.Forms.ColumnHeader chName;
        private System.Windows.Forms.ColumnHeader chClassName;
        private System.Windows.Forms.ColumnHeader chHealth;
        private DoubleBufferedListView lvTeam1Objects;
        private ColumnHeader chKills;
        private Label label1;
        private DoubleBufferedListView lvTeam2Objects;
        private ColumnHeader chTeam2ID;
        private ColumnHeader chTeam2Name;
        private ColumnHeader chTeam2Class;
        private ColumnHeader chTeam2Kills;
        private ColumnHeader chTeam2Health;
        private CheckBox cbHost;
        private DoubleBufferedListView lvGameInfo;
        private ColumnHeader chTeamName;
        private ColumnHeader chScore;
        private ColumnHeader chNumKills;
        private ColumnHeader chNumAlive;
        private Label lbTeam1Name;
        private Label lbTeam2Name;
    }
}