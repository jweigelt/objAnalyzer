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
            this.lbTeam1Name = new System.Windows.Forms.Label();
            this.lbTeam2Name = new System.Windows.Forms.Label();
            this.CommandPosts = new System.Windows.Forms.Label();
            this.lvCommandPosts = new ObjMonitor.DoubleBufferedListView();
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
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 30F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Pixel, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(217, 30);
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
            // lbTeam1Name
            // 
            this.lbTeam1Name.AutoSize = true;
            this.lbTeam1Name.Font = new System.Drawing.Font("Microsoft Sans Serif", 13F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbTeam1Name.Location = new System.Drawing.Point(530, 5);
            this.lbTeam1Name.Name = "lbTeam1Name";
            this.lbTeam1Name.Size = new System.Drawing.Size(71, 22);
            this.lbTeam1Name.TabIndex = 6;
            this.lbTeam1Name.Text = "Team1";
            // 
            // lbTeam2Name
            // 
            this.lbTeam2Name.AutoSize = true;
            this.lbTeam2Name.Font = new System.Drawing.Font("Microsoft Sans Serif", 13F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbTeam2Name.Location = new System.Drawing.Point(530, 244);
            this.lbTeam2Name.Name = "lbTeam2Name";
            this.lbTeam2Name.Size = new System.Drawing.Size(71, 22);
            this.lbTeam2Name.TabIndex = 7;
            this.lbTeam2Name.Text = "Team2";
            // 
            // CommandPosts
            // 
            this.CommandPosts.AutoSize = true;
            this.CommandPosts.Font = new System.Drawing.Font("Microsoft Sans Serif", 30F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Pixel, ((byte)(0)));
            this.CommandPosts.Location = new System.Drawing.Point(136, 221);
            this.CommandPosts.Name = "CommandPosts";
            this.CommandPosts.Size = new System.Drawing.Size(245, 36);
            this.CommandPosts.TabIndex = 9;
            this.CommandPosts.Text = "Command Posts";
            // 
            // lvCommandPosts
            // 
            this.lvCommandPosts.BackColor = System.Drawing.Color.Black;
            this.lvCommandPosts.Font = new System.Drawing.Font("Microsoft Sans Serif", 16F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lvCommandPosts.ForeColor = System.Drawing.Color.White;
            this.lvCommandPosts.HideSelection = false;
            this.lvCommandPosts.Location = new System.Drawing.Point(129, 269);
            this.lvCommandPosts.Name = "lvCommandPosts";
            this.lvCommandPosts.Size = new System.Drawing.Size(261, 98);
            this.lvCommandPosts.Sorting = System.Windows.Forms.SortOrder.Ascending;
            this.lvCommandPosts.TabIndex = 8;
            this.lvCommandPosts.UseCompatibleStateImageBehavior = false;
            this.lvCommandPosts.View = System.Windows.Forms.View.Details;
            // 
            // lvGameInfo
            // 
            this.lvGameInfo.BackColor = System.Drawing.Color.Black;
            this.lvGameInfo.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.chTeamName,
            this.chScore,
            this.chNumKills,
            this.chNumAlive});
            this.lvGameInfo.Font = new System.Drawing.Font("Microsoft Sans Serif", 16F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lvGameInfo.ForeColor = System.Drawing.Color.White;
            this.lvGameInfo.HideSelection = false;
            this.lvGameInfo.Location = new System.Drawing.Point(63, 73);
            this.lvGameInfo.Name = "lvGameInfo";
            this.lvGameInfo.Size = new System.Drawing.Size(349, 105);
            this.lvGameInfo.TabIndex = 5;
            this.lvGameInfo.UseCompatibleStateImageBehavior = false;
            this.lvGameInfo.View = System.Windows.Forms.View.Details;
            // 
            // chTeamName
            // 
            this.chTeamName.Text = "Name";
            this.chTeamName.Width = 100;
            // 
            // chScore
            // 
            this.chScore.Text = "Score";
            this.chScore.Width = 70;
            // 
            // chNumKills
            // 
            this.chNumKills.Text = "Kills";
            this.chNumKills.Width = 75;
            // 
            // chNumAlive
            // 
            this.chNumAlive.Text = "# Alive";
            this.chNumAlive.Width = 100;
            // 
            // lvTeam2Objects
            // 
            this.lvTeam2Objects.BackColor = System.Drawing.Color.Black;
            this.lvTeam2Objects.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.chTeam2ID,
            this.chTeam2Name,
            this.chTeam2Class,
            this.chTeam2Kills,
            this.chTeam2Health});
            this.lvTeam2Objects.Font = new System.Drawing.Font("Microsoft Sans Serif", 15F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lvTeam2Objects.ForeColor = System.Drawing.Color.Black;
            this.lvTeam2Objects.FullRowSelect = true;
            this.lvTeam2Objects.HideSelection = false;
            this.lvTeam2Objects.Location = new System.Drawing.Point(534, 269);
            this.lvTeam2Objects.Name = "lvTeam2Objects";
            this.lvTeam2Objects.Size = new System.Drawing.Size(518, 190);
            this.lvTeam2Objects.TabIndex = 3;
            this.lvTeam2Objects.UseCompatibleStateImageBehavior = false;
            this.lvTeam2Objects.View = System.Windows.Forms.View.Details;
            // 
            // chTeam2ID
            // 
            this.chTeam2ID.Text = "ID";
            this.chTeam2ID.Width = 35;
            // 
            // chTeam2Name
            // 
            this.chTeam2Name.Text = "Client Name";
            this.chTeam2Name.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.chTeam2Name.Width = 180;
            // 
            // chTeam2Class
            // 
            this.chTeam2Class.Text = "Class";
            this.chTeam2Class.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.chTeam2Class.Width = 150;
            // 
            // chTeam2Kills
            // 
            this.chTeam2Kills.Text = "Kills";
            this.chTeam2Kills.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.chTeam2Kills.Width = 51;
            // 
            // chTeam2Health
            // 
            this.chTeam2Health.Text = "Health";
            this.chTeam2Health.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.chTeam2Health.Width = 74;
            // 
            // lvTeam1Objects
            // 
            this.lvTeam1Objects.BackColor = System.Drawing.Color.Black;
            this.lvTeam1Objects.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.chId,
            this.chName,
            this.chClassName,
            this.chKills,
            this.chHealth});
            this.lvTeam1Objects.Font = new System.Drawing.Font("Microsoft Sans Serif", 15F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lvTeam1Objects.ForeColor = System.Drawing.Color.Black;
            this.lvTeam1Objects.FullRowSelect = true;
            this.lvTeam1Objects.HideSelection = false;
            this.lvTeam1Objects.Location = new System.Drawing.Point(534, 30);
            this.lvTeam1Objects.Name = "lvTeam1Objects";
            this.lvTeam1Objects.Size = new System.Drawing.Size(518, 190);
            this.lvTeam1Objects.TabIndex = 0;
            this.lvTeam1Objects.UseCompatibleStateImageBehavior = false;
            this.lvTeam1Objects.View = System.Windows.Forms.View.Details;
            // 
            // chId
            // 
            this.chId.Text = "ID";
            this.chId.Width = 35;
            // 
            // chName
            // 
            this.chName.Text = "Client Name";
            this.chName.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.chName.Width = 180;
            // 
            // chClassName
            // 
            this.chClassName.Text = "Class";
            this.chClassName.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.chClassName.Width = 150;
            // 
            // chKills
            // 
            this.chKills.Text = "Kills";
            this.chKills.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.chKills.Width = 51;
            // 
            // chHealth
            // 
            this.chHealth.Text = "Health";
            this.chHealth.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.chHealth.Width = 74;
            // 
            // ObjForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1064, 461);
            this.Controls.Add(this.CommandPosts);
            this.Controls.Add(this.lvCommandPosts);
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
        private DoubleBufferedListView lvCommandPosts;
        private Label CommandPosts;
    }
}