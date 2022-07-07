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
            System.Windows.Forms.DataVisualization.Charting.ChartArea chartArea1 = new System.Windows.Forms.DataVisualization.Charting.ChartArea();
            System.Windows.Forms.DataVisualization.Charting.Legend legend1 = new System.Windows.Forms.DataVisualization.Charting.Legend();
            System.Windows.Forms.DataVisualization.Charting.Series series1 = new System.Windows.Forms.DataVisualization.Charting.Series();
            System.Windows.Forms.DataVisualization.Charting.Series series2 = new System.Windows.Forms.DataVisualization.Charting.Series();
            this.label1 = new System.Windows.Forms.Label();
            this.cbHost = new System.Windows.Forms.CheckBox();
            this.lbTeam1Name = new System.Windows.Forms.Label();
            this.lbTeam2Name = new System.Windows.Forms.Label();
            this.CommandPosts = new System.Windows.Forms.Label();
            this.ipAddress = new System.Windows.Forms.TextBox();
            this.port = new System.Windows.Forms.TextBox();
            this.username = new System.Windows.Forms.TextBox();
            this.password = new System.Windows.Forms.TextBox();
            this.waCB = new System.Windows.Forms.CheckBox();
            this.label2 = new System.Windows.Forms.Label();
            this.cbHideCPS = new System.Windows.Forms.CheckBox();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.bnSwapTeamViews = new System.Windows.Forms.Button();
            this.cbTrackStats = new System.Windows.Forms.CheckBox();
            this.chart_map = new System.Windows.Forms.DataVisualization.Charting.Chart();
            this.label7 = new System.Windows.Forms.Label();
            this.comboBox_map = new System.Windows.Forms.ComboBox();
            this.text_map_dropdown_label = new System.Windows.Forms.Label();
            this.lvCommandPosts = new ObjMonitor.DoubleBufferedListView();
            this.lvGameInfo = new ObjMonitor.DoubleBufferedListView();
            this.chTeamName = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.chScore = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.chNumKills = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.chNumAlive = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.lvTeam2Objects = new ObjMonitor.DoubleBufferedListView();
            this.chTeam2ID = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.chTeam2Name = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.chTeam2Points = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.chTeam2Kills = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.chTeam2Deaths = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.chTeam2Health = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.lvTeam1Objects = new ObjMonitor.DoubleBufferedListView();
            this.chId = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.chName = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.chPoints = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.chKills = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.chDeaths = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.chHealth = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            ((System.ComponentModel.ISupportInitialize)(this.chart_map)).BeginInit();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 30F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Pixel, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(139, 78);
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
            this.lbTeam1Name.Location = new System.Drawing.Point(372, 13);
            this.lbTeam1Name.Name = "lbTeam1Name";
            this.lbTeam1Name.Size = new System.Drawing.Size(71, 22);
            this.lbTeam1Name.TabIndex = 6;
            this.lbTeam1Name.Text = "Team1";
            // 
            // lbTeam2Name
            // 
            this.lbTeam2Name.AutoSize = true;
            this.lbTeam2Name.Font = new System.Drawing.Font("Microsoft Sans Serif", 13F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbTeam2Name.Location = new System.Drawing.Point(372, 284);
            this.lbTeam2Name.Name = "lbTeam2Name";
            this.lbTeam2Name.Size = new System.Drawing.Size(71, 22);
            this.lbTeam2Name.TabIndex = 7;
            this.lbTeam2Name.Text = "Team2";
            // 
            // CommandPosts
            // 
            this.CommandPosts.AutoSize = true;
            this.CommandPosts.Font = new System.Drawing.Font("Microsoft Sans Serif", 30F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Pixel, ((byte)(0)));
            this.CommandPosts.Location = new System.Drawing.Point(7, 292);
            this.CommandPosts.Name = "CommandPosts";
            this.CommandPosts.Size = new System.Drawing.Size(245, 36);
            this.CommandPosts.TabIndex = 9;
            this.CommandPosts.Text = "Command Posts";
            // 
            // ipAddress
            // 
            this.ipAddress.AcceptsReturn = true;
            this.ipAddress.Location = new System.Drawing.Point(63, 516);
            this.ipAddress.Name = "ipAddress";
            this.ipAddress.Size = new System.Drawing.Size(154, 20);
            this.ipAddress.TabIndex = 10;
            // 
            // port
            // 
            this.port.AcceptsReturn = true;
            this.port.Location = new System.Drawing.Point(63, 542);
            this.port.Name = "port";
            this.port.Size = new System.Drawing.Size(154, 20);
            this.port.TabIndex = 11;
            // 
            // username
            // 
            this.username.AcceptsReturn = true;
            this.username.Location = new System.Drawing.Point(63, 568);
            this.username.Name = "username";
            this.username.Size = new System.Drawing.Size(154, 20);
            this.username.TabIndex = 12;
            // 
            // password
            // 
            this.password.AcceptsReturn = true;
            this.password.Location = new System.Drawing.Point(63, 594);
            this.password.Name = "password";
            this.password.Size = new System.Drawing.Size(154, 20);
            this.password.TabIndex = 13;
            // 
            // waCB
            // 
            this.waCB.AutoSize = true;
            this.waCB.Location = new System.Drawing.Point(63, 493);
            this.waCB.Name = "waCB";
            this.waCB.Size = new System.Drawing.Size(106, 17);
            this.waCB.TabIndex = 15;
            this.waCB.Text = "Use WebAdmin?";
            this.waCB.UseVisualStyleBackColor = true;
            this.waCB.CheckedChanged += new System.EventHandler(this.waCB_CheckedChanged);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.ForeColor = System.Drawing.Color.OrangeRed;
            this.label2.Location = new System.Drawing.Point(3, 617);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(283, 13);
            this.label2.TabIndex = 16;
            this.label2.Text = "Avoid updating info while the checkbox is active";
            // 
            // cbHideCPS
            // 
            this.cbHideCPS.AutoSize = true;
            this.cbHideCPS.Location = new System.Drawing.Point(259, 310);
            this.cbHideCPS.Name = "cbHideCPS";
            this.cbHideCPS.Size = new System.Drawing.Size(72, 17);
            this.cbHideCPS.TabIndex = 17;
            this.cbHideCPS.Text = "Hide CPS";
            this.cbHideCPS.UseVisualStyleBackColor = true;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(223, 519);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(17, 13);
            this.label3.TabIndex = 18;
            this.label3.Text = "IP";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(223, 545);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(37, 13);
            this.label4.TabIndex = 19;
            this.label4.Text = "PORT";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(223, 571);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(68, 13);
            this.label5.TabIndex = 20;
            this.label5.Text = "USERNAME";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(223, 597);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(70, 13);
            this.label6.TabIndex = 21;
            this.label6.Text = "PASSWORD";
            // 
            // bnSwapTeamViews
            // 
            this.bnSwapTeamViews.Location = new System.Drawing.Point(1097, 283);
            this.bnSwapTeamViews.Name = "bnSwapTeamViews";
            this.bnSwapTeamViews.Size = new System.Drawing.Size(75, 23);
            this.bnSwapTeamViews.TabIndex = 22;
            this.bnSwapTeamViews.Text = "SWAP";
            this.bnSwapTeamViews.UseVisualStyleBackColor = true;
            this.bnSwapTeamViews.Click += new System.EventHandler(this.bnSwapTeamViews_Click);
            // 
            // cbTrackStats
            // 
            this.cbTrackStats.AutoSize = true;
            this.cbTrackStats.Checked = true;
            this.cbTrackStats.CheckState = System.Windows.Forms.CheckState.Checked;
            this.cbTrackStats.Location = new System.Drawing.Point(13, 37);
            this.cbTrackStats.Name = "cbTrackStats";
            this.cbTrackStats.Size = new System.Drawing.Size(81, 17);
            this.cbTrackStats.TabIndex = 23;
            this.cbTrackStats.Text = "Track Stats";
            this.cbTrackStats.UseVisualStyleBackColor = true;
            // 
            // chart_map
            // 
            chartArea1.AxisX.MajorGrid.Enabled = false;
            chartArea1.AxisY.MajorGrid.Enabled = false;
            chartArea1.BackColor = System.Drawing.Color.Transparent;
            chartArea1.Name = "chartarea_minimap";
            this.chart_map.ChartAreas.Add(chartArea1);
            legend1.Name = "Legend1";
            this.chart_map.Legends.Add(legend1);
            this.chart_map.Location = new System.Drawing.Point(931, 53);
            this.chart_map.Name = "chart_map";
            series1.ChartArea = "chartarea_minimap";
            series1.ChartType = System.Windows.Forms.DataVisualization.Charting.SeriesChartType.FastPoint;
            series1.Legend = "Legend1";
            series1.MarkerColor = System.Drawing.Color.Red;
            series1.MarkerSize = 6;
            series1.MarkerStyle = System.Windows.Forms.DataVisualization.Charting.MarkerStyle.Circle;
            series1.Name = "Team1";
            series2.ChartArea = "chartarea_minimap";
            series2.ChartType = System.Windows.Forms.DataVisualization.Charting.SeriesChartType.FastPoint;
            series2.Legend = "Legend1";
            series2.MarkerColor = System.Drawing.Color.Blue;
            series2.MarkerStyle = System.Windows.Forms.DataVisualization.Charting.MarkerStyle.Square;
            series2.Name = "Team2";
            this.chart_map.Series.Add(series1);
            this.chart_map.Series.Add(series2);
            this.chart_map.Size = new System.Drawing.Size(621, 457);
            this.chart_map.TabIndex = 24;
            this.chart_map.Text = "chart1";
            this.chart_map.Click += new System.EventHandler(this.chart1_Click);
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Font = new System.Drawing.Font("Microsoft Sans Serif", 13F, System.Drawing.FontStyle.Bold);
            this.label7.Location = new System.Drawing.Point(1158, 13);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(90, 22);
            this.label7.TabIndex = 25;
            this.label7.Text = "Mini-Map";
            this.label7.Click += new System.EventHandler(this.label7_Click);
            // 
            // comboBox_map
            // 
            this.comboBox_map.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboBox_map.FormattingEnabled = true;
            this.comboBox_map.Items.AddRange(new object[] {
            "C0R",
            "DG2",
            "ed9",
            "KEK",
            "mus1",
            "RVN",
            "Rhn2",
            "tat2",
            "tat3",
            "TI2",
            "uta1"});
            this.comboBox_map.Location = new System.Drawing.Point(1007, 562);
            this.comboBox_map.Name = "comboBox_map";
            this.comboBox_map.Size = new System.Drawing.Size(179, 21);
            this.comboBox_map.TabIndex = 26;
            // 
            // text_map_dropdown_label
            // 
            this.text_map_dropdown_label.AutoSize = true;
            this.text_map_dropdown_label.Font = new System.Drawing.Font("Microsoft Sans Serif", 13F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.text_map_dropdown_label.Location = new System.Drawing.Point(944, 560);
            this.text_map_dropdown_label.Name = "text_map_dropdown_label";
            this.text_map_dropdown_label.Size = new System.Drawing.Size(47, 22);
            this.text_map_dropdown_label.TabIndex = 27;
            this.text_map_dropdown_label.Text = "map";
            // 
            // lvCommandPosts
            // 
            this.lvCommandPosts.AutoArrange = false;
            this.lvCommandPosts.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(33)))), ((int)(((byte)(37)))), ((int)(((byte)(41)))));
            this.lvCommandPosts.Font = new System.Drawing.Font("Microsoft Sans Serif", 16F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lvCommandPosts.ForeColor = System.Drawing.Color.White;
            this.lvCommandPosts.HeaderStyle = System.Windows.Forms.ColumnHeaderStyle.None;
            this.lvCommandPosts.HideSelection = false;
            this.lvCommandPosts.Location = new System.Drawing.Point(13, 348);
            this.lvCommandPosts.Name = "lvCommandPosts";
            this.lvCommandPosts.Size = new System.Drawing.Size(349, 101);
            this.lvCommandPosts.Sorting = System.Windows.Forms.SortOrder.Ascending;
            this.lvCommandPosts.TabIndex = 8;
            this.lvCommandPosts.UseCompatibleStateImageBehavior = false;
            this.lvCommandPosts.View = System.Windows.Forms.View.Details;
            // 
            // lvGameInfo
            // 
            this.lvGameInfo.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(33)))), ((int)(((byte)(37)))), ((int)(((byte)(41)))));
            this.lvGameInfo.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.chTeamName,
            this.chScore,
            this.chNumKills,
            this.chNumAlive});
            this.lvGameInfo.Font = new System.Drawing.Font("Microsoft Sans Serif", 16F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lvGameInfo.ForeColor = System.Drawing.Color.White;
            this.lvGameInfo.HeaderStyle = System.Windows.Forms.ColumnHeaderStyle.Nonclickable;
            this.lvGameInfo.HideSelection = false;
            this.lvGameInfo.Location = new System.Drawing.Point(13, 138);
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
            this.lvTeam2Objects.AutoArrange = false;
            this.lvTeam2Objects.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(33)))), ((int)(((byte)(37)))), ((int)(((byte)(41)))));
            this.lvTeam2Objects.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.chTeam2ID,
            this.chTeam2Name,
            this.chTeam2Points,
            this.chTeam2Kills,
            this.chTeam2Deaths,
            this.chTeam2Health});
            this.lvTeam2Objects.Font = new System.Drawing.Font("Microsoft Sans Serif", 15F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lvTeam2Objects.ForeColor = System.Drawing.Color.White;
            this.lvTeam2Objects.FullRowSelect = true;
            this.lvTeam2Objects.HeaderStyle = System.Windows.Forms.ColumnHeaderStyle.Nonclickable;
            this.lvTeam2Objects.HideSelection = false;
            this.lvTeam2Objects.Location = new System.Drawing.Point(376, 320);
            this.lvTeam2Objects.Name = "lvTeam2Objects";
            this.lvTeam2Objects.Size = new System.Drawing.Size(549, 190);
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
            this.chTeam2Name.Text = "Player";
            this.chTeam2Name.Width = 320;
            // 
            // chTeam2Points
            // 
            this.chTeam2Points.Text = "P";
            this.chTeam2Points.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.chTeam2Points.Width = 45;
            // 
            // chTeam2Kills
            // 
            this.chTeam2Kills.Text = "K";
            this.chTeam2Kills.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.chTeam2Kills.Width = 35;
            // 
            // chTeam2Deaths
            // 
            this.chTeam2Deaths.Text = "D";
            this.chTeam2Deaths.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.chTeam2Deaths.Width = 35;
            // 
            // chTeam2Health
            // 
            this.chTeam2Health.Text = "H";
            this.chTeam2Health.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.chTeam2Health.Width = 45;
            // 
            // lvTeam1Objects
            // 
            this.lvTeam1Objects.AutoArrange = false;
            this.lvTeam1Objects.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(33)))), ((int)(((byte)(37)))), ((int)(((byte)(41)))));
            this.lvTeam1Objects.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.chId,
            this.chName,
            this.chPoints,
            this.chKills,
            this.chDeaths,
            this.chHealth});
            this.lvTeam1Objects.Font = new System.Drawing.Font("Microsoft Sans Serif", 15F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lvTeam1Objects.ForeColor = System.Drawing.Color.White;
            this.lvTeam1Objects.FullRowSelect = true;
            this.lvTeam1Objects.HeaderStyle = System.Windows.Forms.ColumnHeaderStyle.Nonclickable;
            this.lvTeam1Objects.HideSelection = false;
            this.lvTeam1Objects.Location = new System.Drawing.Point(376, 53);
            this.lvTeam1Objects.Name = "lvTeam1Objects";
            this.lvTeam1Objects.Size = new System.Drawing.Size(549, 190);
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
            this.chName.Text = "Player";
            this.chName.Width = 320;
            // 
            // chPoints
            // 
            this.chPoints.Text = "P";
            this.chPoints.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.chPoints.Width = 45;
            // 
            // chKills
            // 
            this.chKills.Text = "K";
            this.chKills.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.chKills.Width = 35;
            // 
            // chDeaths
            // 
            this.chDeaths.Text = "D";
            this.chDeaths.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.chDeaths.Width = 35;
            // 
            // chHealth
            // 
            this.chHealth.Text = "H";
            this.chHealth.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.chHealth.Width = 45;
            // 
            // ObjForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1584, 711);
            this.Controls.Add(this.text_map_dropdown_label);
            this.Controls.Add(this.comboBox_map);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.chart_map);
            this.Controls.Add(this.cbTrackStats);
            this.Controls.Add(this.bnSwapTeamViews);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.cbHideCPS);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.waCB);
            this.Controls.Add(this.password);
            this.Controls.Add(this.username);
            this.Controls.Add(this.port);
            this.Controls.Add(this.ipAddress);
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
            ((System.ComponentModel.ISupportInitialize)(this.chart_map)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.ColumnHeader chId;
        private System.Windows.Forms.ColumnHeader chName;
        private System.Windows.Forms.ColumnHeader chPoints;
        private System.Windows.Forms.ColumnHeader chDeaths;
        private DoubleBufferedListView lvTeam1Objects;
        private ColumnHeader chKills;
        private Label label1;
        private DoubleBufferedListView lvTeam2Objects;
        private ColumnHeader chTeam2ID;
        private ColumnHeader chTeam2Name;
        private ColumnHeader chTeam2Points;
        private ColumnHeader chTeam2Kills;
        private ColumnHeader chTeam2Deaths;
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
        private TextBox ipAddress;
        private TextBox port;
        private TextBox username;
        private TextBox password;
        private CheckBox waCB;
        private Label label2;
        private ColumnHeader chTeam2Health;
        private ColumnHeader chHealth;
        public CheckBox cbHideCPS;
        private Label label3;
        private Label label4;
        private Label label5;
        private Label label6;
        private Button bnSwapTeamViews;
        public CheckBox cbTrackStats;
        private System.Windows.Forms.DataVisualization.Charting.Chart chart_map;
        private Label label7;
        private ComboBox comboBox_map;
        private Label text_map_dropdown_label;
    }
}