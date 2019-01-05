using TimeSands.Controls;

namespace TimeSands.Forms
{
    partial class frmMain
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmMain));
            this.pTop = new System.Windows.Forms.Panel();
            this.hrTop = new TimeSands.Controls.HorizontalDivider();
            this.tsTop = new System.Windows.Forms.ToolStrip();
            this.btnTaskAdd = new System.Windows.Forms.ToolStripButton();
            this.cbCurrentSprint = new TimeSands.Controls.BorderedToolStripComboBox();
            this.lblCurrentSprint = new System.Windows.Forms.ToolStripLabel();
            this.toolStripSeparator1 = new System.Windows.Forms.ToolStripSeparator();
            this.btnSprints = new System.Windows.Forms.ToolStripButton();
            this.pMain = new TimeSands.Controls.BorderedPanel();
            this.pMainCenter = new System.Windows.Forms.Panel();
            this.lvTasks = new TimeSands.Controls.TaskListView();
            this.lvhActivity = new ComponentOwl.BetterListView.BetterListViewColumnHeader();
            this.lvhTask = new ComponentOwl.BetterListView.BetterListViewColumnHeader();
            this.lvhState = new ComponentOwl.BetterListView.BetterListViewColumnHeader();
            this.lvhSprint = new ComponentOwl.BetterListView.BetterListViewColumnHeader();
            this.lvhStarted = new ComponentOwl.BetterListView.BetterListViewColumnHeader();
            this.lvhClosed = new ComponentOwl.BetterListView.BetterListViewColumnHeader();
            this.lvhTimeSpent = new ComponentOwl.BetterListView.BetterListViewColumnHeader();
            this.pMainTop = new System.Windows.Forms.Panel();
            this.tsTasks = new System.Windows.Forms.ToolStrip();
            this.toolStripButton4 = new System.Windows.Forms.ToolStripButton();
            this.toolStripButton5 = new System.Windows.Forms.ToolStripButton();
            this.toolStripButton6 = new System.Windows.Forms.ToolStripButton();
            this.toolStripButton3 = new System.Windows.Forms.ToolStripButton();
            this.toolStripSeparator2 = new System.Windows.Forms.ToolStripSeparator();
            this.toolStripButton1 = new System.Windows.Forms.ToolStripButton();
            this.toolStripButton2 = new System.Windows.Forms.ToolStripButton();
            this.toolStripSeparator3 = new System.Windows.Forms.ToolStripSeparator();
            this.toolStripLabel1 = new System.Windows.Forms.ToolStripLabel();
            this.hrMainTop = new TimeSands.Controls.HorizontalDivider();
            this.timerRefreshTasks = new System.Windows.Forms.Timer(this.components);
            this.pTop.SuspendLayout();
            this.tsTop.SuspendLayout();
            this.pMain.SuspendLayout();
            this.pMainCenter.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.lvTasks)).BeginInit();
            this.pMainTop.SuspendLayout();
            this.tsTasks.SuspendLayout();
            this.SuspendLayout();
            // 
            // pTop
            // 
            this.pTop.Controls.Add(this.hrTop);
            this.pTop.Controls.Add(this.tsTop);
            this.pTop.Dock = System.Windows.Forms.DockStyle.Top;
            this.pTop.Location = new System.Drawing.Point(0, 0);
            this.pTop.Name = "pTop";
            this.pTop.Size = new System.Drawing.Size(1211, 49);
            this.pTop.TabIndex = 1;
            // 
            // hrTop
            // 
            this.hrTop.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.hrTop.Location = new System.Drawing.Point(0, 48);
            this.hrTop.Name = "hrTop";
            this.hrTop.Size = new System.Drawing.Size(1211, 1);
            this.hrTop.TabIndex = 1;
            // 
            // tsTop
            // 
            this.tsTop.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.tsTop.AutoSize = false;
            this.tsTop.Dock = System.Windows.Forms.DockStyle.None;
            this.tsTop.GripStyle = System.Windows.Forms.ToolStripGripStyle.Hidden;
            this.tsTop.ImageScalingSize = new System.Drawing.Size(24, 24);
            this.tsTop.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.btnTaskAdd,
            this.cbCurrentSprint,
            this.lblCurrentSprint,
            this.toolStripSeparator1,
            this.btnSprints});
            this.tsTop.Location = new System.Drawing.Point(1, 0);
            this.tsTop.Name = "tsTop";
            this.tsTop.Padding = new System.Windows.Forms.Padding(1, 0, 10, 0);
            this.tsTop.Size = new System.Drawing.Size(1211, 48);
            this.tsTop.TabIndex = 0;
            // 
            // btnTaskAdd
            // 
            this.btnTaskAdd.AutoSize = false;
            this.btnTaskAdd.Image = ((System.Drawing.Image)(resources.GetObject("btnTaskAdd.Image")));
            this.btnTaskAdd.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.btnTaskAdd.Name = "btnTaskAdd";
            this.btnTaskAdd.Size = new System.Drawing.Size(69, 45);
            this.btnTaskAdd.Text = "Add task";
            this.btnTaskAdd.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
            this.btnTaskAdd.Click += new System.EventHandler(this.btnTaskAdd_Click);
            // 
            // cbCurrentSprint
            // 
            this.cbCurrentSprint.Alignment = System.Windows.Forms.ToolStripItemAlignment.Right;
            this.cbCurrentSprint.AutoSize = false;
            this.cbCurrentSprint.DataSource = null;
            this.cbCurrentSprint.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbCurrentSprint.Name = "cbCurrentSprint";
            this.cbCurrentSprint.Size = new System.Drawing.Size(200, 23);
            // 
            // lblCurrentSprint
            // 
            this.lblCurrentSprint.Alignment = System.Windows.Forms.ToolStripItemAlignment.Right;
            this.lblCurrentSprint.Margin = new System.Windows.Forms.Padding(0, 1, 1, 1);
            this.lblCurrentSprint.Name = "lblCurrentSprint";
            this.lblCurrentSprint.Size = new System.Drawing.Size(80, 46);
            this.lblCurrentSprint.Text = "Current sprint";
            // 
            // toolStripSeparator1
            // 
            this.toolStripSeparator1.Name = "toolStripSeparator1";
            this.toolStripSeparator1.Size = new System.Drawing.Size(6, 48);
            // 
            // btnSprints
            // 
            this.btnSprints.AutoSize = false;
            this.btnSprints.Image = ((System.Drawing.Image)(resources.GetObject("btnSprints.Image")));
            this.btnSprints.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.btnSprints.Name = "btnSprints";
            this.btnSprints.Size = new System.Drawing.Size(69, 45);
            this.btnSprints.Text = "Sprints";
            this.btnSprints.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
            this.btnSprints.Click += new System.EventHandler(this.btnSprints_Click);
            // 
            // pMain
            // 
            this.pMain.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.pMain.Controls.Add(this.pMainCenter);
            this.pMain.Controls.Add(this.pMainTop);
            this.pMain.Location = new System.Drawing.Point(12, 61);
            this.pMain.Name = "pMain";
            this.pMain.Padding = new System.Windows.Forms.Padding(1);
            this.pMain.Size = new System.Drawing.Size(1187, 695);
            this.pMain.TabIndex = 2;
            // 
            // pMainCenter
            // 
            this.pMainCenter.Controls.Add(this.lvTasks);
            this.pMainCenter.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pMainCenter.Location = new System.Drawing.Point(1, 44);
            this.pMainCenter.Name = "pMainCenter";
            this.pMainCenter.Size = new System.Drawing.Size(1185, 650);
            this.pMainCenter.TabIndex = 1;
            // 
            // lvTasks
            // 
            this.lvTasks.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.lvTasks.Columns.Add(this.lvhActivity);
            this.lvTasks.Columns.Add(this.lvhTask);
            this.lvTasks.Columns.Add(this.lvhState);
            this.lvTasks.Columns.Add(this.lvhSprint);
            this.lvTasks.Columns.Add(this.lvhStarted);
            this.lvTasks.Columns.Add(this.lvhClosed);
            this.lvTasks.Columns.Add(this.lvhTimeSpent);
            this.lvTasks.DisplayMember = "Name";
            this.lvTasks.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lvTasks.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.lvTasks.Location = new System.Drawing.Point(0, 0);
            this.lvTasks.MultiSelect = false;
            this.lvTasks.Name = "lvTasks";
            this.lvTasks.Size = new System.Drawing.Size(1185, 650);
            this.lvTasks.SortedColumnsRowsHighlight = ComponentOwl.BetterListView.BetterListViewSortedColumnsRowsHighlight.ShowAlways;
            this.lvTasks.TabIndex = 0;
            this.lvTasks.DrawItem += new ComponentOwl.BetterListView.BetterListViewDrawItemEventHandler(this.lvTasks_DrawItem);
            this.lvTasks.MouseDoubleClick += new System.Windows.Forms.MouseEventHandler(this.lvTasks_MouseDoubleClick);
            // 
            // lvhActivity
            // 
            this.lvhActivity.AllowResize = false;
            this.lvhActivity.Name = "lvhActivity";
            this.lvhActivity.Style = ComponentOwl.BetterListView.BetterListViewColumnHeaderStyle.Nonclickable;
            this.lvhActivity.Width = 38;
            // 
            // lvhTask
            // 
            this.lvhTask.DisplayMember = "Name";
            this.lvhTask.Name = "lvhTask";
            this.lvhTask.Text = "Task";
            this.lvhTask.ValueMember = "Name";
            this.lvhTask.Width = 428;
            // 
            // lvhState
            // 
            this.lvhState.DisplayMember = "State";
            this.lvhState.Name = "lvhState";
            this.lvhState.Text = "State";
            this.lvhState.ValueMember = "State";
            this.lvhState.Width = 112;
            // 
            // lvhSprint
            // 
            this.lvhSprint.DisplayMember = "SprintName";
            this.lvhSprint.Name = "lvhSprint";
            this.lvhSprint.Text = "Sprint";
            this.lvhSprint.ValueMember = "SprintName";
            this.lvhSprint.Width = 187;
            // 
            // lvhStarted
            // 
            this.lvhStarted.DisplayMember = "StartedAt";
            this.lvhStarted.Name = "lvhStarted";
            this.lvhStarted.Text = "Started at";
            this.lvhStarted.ValueMember = "StartTime";
            // 
            // lvhClosed
            // 
            this.lvhClosed.DisplayMember = "ClosedAt";
            this.lvhClosed.Name = "lvhClosed";
            this.lvhClosed.Text = "Completed at";
            this.lvhClosed.ValueMember = "CloseTime";
            // 
            // lvhTimeSpent
            // 
            this.lvhTimeSpent.DisplayMember = "TimeSpent";
            this.lvhTimeSpent.Name = "lvhTimeSpent";
            this.lvhTimeSpent.Text = "Time spent";
            this.lvhTimeSpent.ValueMember = "TimeSpent";
            // 
            // pMainTop
            // 
            this.pMainTop.Controls.Add(this.tsTasks);
            this.pMainTop.Controls.Add(this.hrMainTop);
            this.pMainTop.Dock = System.Windows.Forms.DockStyle.Top;
            this.pMainTop.Location = new System.Drawing.Point(1, 1);
            this.pMainTop.Name = "pMainTop";
            this.pMainTop.Size = new System.Drawing.Size(1185, 43);
            this.pMainTop.TabIndex = 0;
            // 
            // tsTasks
            // 
            this.tsTasks.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.tsTasks.AutoSize = false;
            this.tsTasks.Dock = System.Windows.Forms.DockStyle.None;
            this.tsTasks.GripStyle = System.Windows.Forms.ToolStripGripStyle.Hidden;
            this.tsTasks.ImageScalingSize = new System.Drawing.Size(20, 20);
            this.tsTasks.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripButton4,
            this.toolStripButton5,
            this.toolStripButton6,
            this.toolStripButton3,
            this.toolStripSeparator2,
            this.toolStripButton1,
            this.toolStripButton2,
            this.toolStripSeparator3,
            this.toolStripLabel1});
            this.tsTasks.Location = new System.Drawing.Point(-1, -1);
            this.tsTasks.Name = "tsTasks";
            this.tsTasks.Padding = new System.Windows.Forms.Padding(2, 2, 10, 0);
            this.tsTasks.RenderMode = System.Windows.Forms.ToolStripRenderMode.Professional;
            this.tsTasks.Size = new System.Drawing.Size(1211, 43);
            this.tsTasks.TabIndex = 4;
            // 
            // toolStripButton4
            // 
            this.toolStripButton4.AutoSize = false;
            this.toolStripButton4.Image = ((System.Drawing.Image)(resources.GetObject("toolStripButton4.Image")));
            this.toolStripButton4.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolStripButton4.Name = "toolStripButton4";
            this.toolStripButton4.Size = new System.Drawing.Size(60, 40);
            this.toolStripButton4.Text = "Start";
            this.toolStripButton4.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
            // 
            // toolStripButton5
            // 
            this.toolStripButton5.AutoSize = false;
            this.toolStripButton5.Image = ((System.Drawing.Image)(resources.GetObject("toolStripButton5.Image")));
            this.toolStripButton5.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolStripButton5.Name = "toolStripButton5";
            this.toolStripButton5.Size = new System.Drawing.Size(60, 40);
            this.toolStripButton5.Text = "Suspend";
            this.toolStripButton5.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
            // 
            // toolStripButton6
            // 
            this.toolStripButton6.AutoSize = false;
            this.toolStripButton6.Image = ((System.Drawing.Image)(resources.GetObject("toolStripButton6.Image")));
            this.toolStripButton6.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolStripButton6.Name = "toolStripButton6";
            this.toolStripButton6.Size = new System.Drawing.Size(60, 40);
            this.toolStripButton6.Text = "Stop";
            this.toolStripButton6.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
            // 
            // toolStripButton3
            // 
            this.toolStripButton3.AutoSize = false;
            this.toolStripButton3.Image = ((System.Drawing.Image)(resources.GetObject("toolStripButton3.Image")));
            this.toolStripButton3.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolStripButton3.Name = "toolStripButton3";
            this.toolStripButton3.Size = new System.Drawing.Size(63, 40);
            this.toolStripButton3.Text = "Complete";
            this.toolStripButton3.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
            // 
            // toolStripSeparator2
            // 
            this.toolStripSeparator2.Name = "toolStripSeparator2";
            this.toolStripSeparator2.Size = new System.Drawing.Size(6, 41);
            // 
            // toolStripButton1
            // 
            this.toolStripButton1.AutoSize = false;
            this.toolStripButton1.Image = ((System.Drawing.Image)(resources.GetObject("toolStripButton1.Image")));
            this.toolStripButton1.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolStripButton1.Name = "toolStripButton1";
            this.toolStripButton1.Size = new System.Drawing.Size(60, 40);
            this.toolStripButton1.Text = "Modify";
            this.toolStripButton1.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
            // 
            // toolStripButton2
            // 
            this.toolStripButton2.AutoSize = false;
            this.toolStripButton2.Image = ((System.Drawing.Image)(resources.GetObject("toolStripButton2.Image")));
            this.toolStripButton2.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolStripButton2.Name = "toolStripButton2";
            this.toolStripButton2.Size = new System.Drawing.Size(60, 40);
            this.toolStripButton2.Text = "Delete";
            this.toolStripButton2.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
            // 
            // toolStripSeparator3
            // 
            this.toolStripSeparator3.Name = "toolStripSeparator3";
            this.toolStripSeparator3.Size = new System.Drawing.Size(6, 41);
            // 
            // toolStripLabel1
            // 
            this.toolStripLabel1.Margin = new System.Windows.Forms.Padding(5, 1, 0, 2);
            this.toolStripLabel1.Name = "toolStripLabel1";
            this.toolStripLabel1.Size = new System.Drawing.Size(50, 38);
            this.toolStripLabel1.Text = "Filtering";
            // 
            // hrMainTop
            // 
            this.hrMainTop.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.hrMainTop.Location = new System.Drawing.Point(0, 42);
            this.hrMainTop.Name = "hrMainTop";
            this.hrMainTop.Size = new System.Drawing.Size(1185, 1);
            this.hrMainTop.TabIndex = 2;
            // 
            // timerRefreshTasks
            // 
            this.timerRefreshTasks.Tick += new System.EventHandler(this.timerRefreshTasks_Tick);
            // 
            // frmMain
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1211, 768);
            this.Controls.Add(this.pMain);
            this.Controls.Add(this.pTop);
            this.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "frmMain";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Time Sands v0.1";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.frmMain_FormClosing);
            this.pTop.ResumeLayout(false);
            this.tsTop.ResumeLayout(false);
            this.tsTop.PerformLayout();
            this.pMain.ResumeLayout(false);
            this.pMainCenter.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.lvTasks)).EndInit();
            this.pMainTop.ResumeLayout(false);
            this.tsTasks.ResumeLayout(false);
            this.tsTasks.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.Panel pTop;
        private System.Windows.Forms.ToolStrip tsTop;
        private System.Windows.Forms.ToolStripButton btnTaskAdd;
        private Controls.HorizontalDivider hrTop;
        private Controls.BorderedPanel pMain;
        private Controls.TaskListView lvTasks;
        private System.Windows.Forms.Panel pMainCenter;
        private System.Windows.Forms.Panel pMainTop;
        private Controls.HorizontalDivider hrMainTop;
        private ComponentOwl.BetterListView.BetterListViewColumnHeader lvhTask;
        private ComponentOwl.BetterListView.BetterListViewColumnHeader lvhState;
        private ComponentOwl.BetterListView.BetterListViewColumnHeader lvhSprint;
        private ComponentOwl.BetterListView.BetterListViewColumnHeader lvhStarted;
        private ComponentOwl.BetterListView.BetterListViewColumnHeader lvhClosed;
        private ComponentOwl.BetterListView.BetterListViewColumnHeader lvhTimeSpent;
        private BorderedToolStripComboBox cbCurrentSprint;
        private System.Windows.Forms.ToolStripLabel lblCurrentSprint;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator1;
        private System.Windows.Forms.ToolStripButton btnSprints;
        private System.Windows.Forms.Timer timerRefreshTasks;
        private ComponentOwl.BetterListView.BetterListViewColumnHeader lvhActivity;
        private System.Windows.Forms.ToolStrip tsTasks;
        private System.Windows.Forms.ToolStripButton toolStripButton1;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator2;
        private System.Windows.Forms.ToolStripButton toolStripButton2;
        private System.Windows.Forms.ToolStripButton toolStripButton3;
        private System.Windows.Forms.ToolStripButton toolStripButton4;
        private System.Windows.Forms.ToolStripButton toolStripButton5;
        private System.Windows.Forms.ToolStripButton toolStripButton6;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator3;
        private System.Windows.Forms.ToolStripLabel toolStripLabel1;
    }
}

