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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmMain));
            this.pTop = new System.Windows.Forms.Panel();
            this.tsTop = new System.Windows.Forms.ToolStrip();
            this.btnTaskAdd = new System.Windows.Forms.ToolStripButton();
            this.pMain = new TimeSands.Controls.BorderedPanel();
            this.panel2 = new System.Windows.Forms.Panel();
            this.lvTasks = new TimeSands.Controls.TaskListView();
            this.lvhTask = new ComponentOwl.BetterListView.BetterListViewColumnHeader();
            this.lvhState = new ComponentOwl.BetterListView.BetterListViewColumnHeader();
            this.lvhSprint = new ComponentOwl.BetterListView.BetterListViewColumnHeader();
            this.lvhCreated = new ComponentOwl.BetterListView.BetterListViewColumnHeader();
            this.lvhClosed = new ComponentOwl.BetterListView.BetterListViewColumnHeader();
            this.lvhTimeSpent = new ComponentOwl.BetterListView.BetterListViewColumnHeader();
            this.lvhActions = new ComponentOwl.BetterListView.BetterListViewColumnHeader();
            this.panel1 = new System.Windows.Forms.Panel();
            this.horizontalDivider1 = new TimeSands.Controls.HorizontalDivider();
            this.hrTop = new TimeSands.Controls.HorizontalDivider();
            this.pTop.SuspendLayout();
            this.tsTop.SuspendLayout();
            this.pMain.SuspendLayout();
            this.panel2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.lvTasks)).BeginInit();
            this.panel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // pTop
            // 
            this.pTop.Controls.Add(this.hrTop);
            this.pTop.Controls.Add(this.tsTop);
            this.pTop.Dock = System.Windows.Forms.DockStyle.Top;
            this.pTop.Location = new System.Drawing.Point(0, 0);
            this.pTop.Name = "pTop";
            this.pTop.Size = new System.Drawing.Size(1191, 49);
            this.pTop.TabIndex = 1;
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
            this.btnTaskAdd});
            this.tsTop.Location = new System.Drawing.Point(1, 0);
            this.tsTop.Name = "tsTop";
            this.tsTop.Padding = new System.Windows.Forms.Padding(1, 0, 1, 0);
            this.tsTop.Size = new System.Drawing.Size(1191, 48);
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
            // 
            // pMain
            // 
            this.pMain.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.pMain.Controls.Add(this.panel2);
            this.pMain.Controls.Add(this.panel1);
            this.pMain.Location = new System.Drawing.Point(12, 64);
            this.pMain.Name = "pMain";
            this.pMain.Padding = new System.Windows.Forms.Padding(1);
            this.pMain.Size = new System.Drawing.Size(1167, 657);
            this.pMain.TabIndex = 2;
            // 
            // panel2
            // 
            this.panel2.Controls.Add(this.lvTasks);
            this.panel2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel2.Location = new System.Drawing.Point(1, 46);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(1165, 610);
            this.panel2.TabIndex = 1;
            // 
            // lvTasks
            // 
            this.lvTasks.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.lvTasks.Columns.Add(this.lvhTask);
            this.lvTasks.Columns.Add(this.lvhState);
            this.lvTasks.Columns.Add(this.lvhSprint);
            this.lvTasks.Columns.Add(this.lvhCreated);
            this.lvTasks.Columns.Add(this.lvhClosed);
            this.lvTasks.Columns.Add(this.lvhTimeSpent);
            this.lvTasks.Columns.Add(this.lvhActions);
            this.lvTasks.DisplayMember = "Name";
            this.lvTasks.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lvTasks.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.lvTasks.Location = new System.Drawing.Point(0, 0);
            this.lvTasks.MultiSelect = false;
            this.lvTasks.Name = "lvTasks";
            this.lvTasks.Size = new System.Drawing.Size(1165, 610);
            this.lvTasks.TabIndex = 0;
            // 
            // lvhTask
            // 
            this.lvhTask.DisplayMember = "Name";
            this.lvhTask.Name = "lvhTask";
            this.lvhTask.Text = "Task";
            this.lvhTask.ValueMember = "Name";
            this.lvhTask.Width = 298;
            // 
            // lvhState
            // 
            this.lvhState.DisplayMember = "State";
            this.lvhState.Name = "lvhState";
            this.lvhState.Text = "State";
            this.lvhState.ValueMember = "State";
            // 
            // lvhSprint
            // 
            this.lvhSprint.DisplayMember = "SprintName";
            this.lvhSprint.Name = "lvhSprint";
            this.lvhSprint.Text = "Sprint";
            this.lvhSprint.ValueMember = "SprintName";
            // 
            // lvhCreated
            // 
            this.lvhCreated.DisplayMember = "CreatedAt";
            this.lvhCreated.Name = "lvhCreated";
            this.lvhCreated.Text = "Created at";
            this.lvhCreated.ValueMember = "CreatedAt";
            // 
            // lvhClosed
            // 
            this.lvhClosed.DisplayMember = "ClosedAt";
            this.lvhClosed.Name = "lvhClosed";
            this.lvhClosed.Text = "Closed at";
            this.lvhClosed.ValueMember = "ClosedAt";
            // 
            // lvhTimeSpent
            // 
            this.lvhTimeSpent.DisplayMember = "TimeSpent";
            this.lvhTimeSpent.Name = "lvhTimeSpent";
            this.lvhTimeSpent.Text = "Time spent";
            this.lvhTimeSpent.ValueMember = "TimeSpent";
            // 
            // lvhActions
            // 
            this.lvhActions.AlignHorizontal = ComponentOwl.BetterListView.TextAlignmentHorizontal.Right;
            this.lvhActions.Name = "lvhActions";
            this.lvhActions.Text = "Actions";
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.horizontalDivider1);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel1.Location = new System.Drawing.Point(1, 1);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(1165, 45);
            this.panel1.TabIndex = 0;
            // 
            // horizontalDivider1
            // 
            this.horizontalDivider1.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.horizontalDivider1.Location = new System.Drawing.Point(0, 44);
            this.horizontalDivider1.Name = "horizontalDivider1";
            this.horizontalDivider1.Size = new System.Drawing.Size(1165, 1);
            this.horizontalDivider1.TabIndex = 2;
            // 
            // hrTop
            // 
            this.hrTop.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.hrTop.Location = new System.Drawing.Point(0, 48);
            this.hrTop.Name = "hrTop";
            this.hrTop.Size = new System.Drawing.Size(1191, 1);
            this.hrTop.TabIndex = 1;
            // 
            // frmMain
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1191, 733);
            this.Controls.Add(this.pMain);
            this.Controls.Add(this.pTop);
            this.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "frmMain";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Time Sands, v0.1";
            this.pTop.ResumeLayout(false);
            this.tsTop.ResumeLayout(false);
            this.tsTop.PerformLayout();
            this.pMain.ResumeLayout(false);
            this.panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.lvTasks)).EndInit();
            this.panel1.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.Panel pTop;
        private System.Windows.Forms.ToolStrip tsTop;
        private System.Windows.Forms.ToolStripButton btnTaskAdd;
        private Controls.HorizontalDivider hrTop;
        private Controls.BorderedPanel pMain;
        private Controls.TaskListView lvTasks;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.Panel panel1;
        private Controls.HorizontalDivider horizontalDivider1;
        private ComponentOwl.BetterListView.BetterListViewColumnHeader lvhTask;
        private ComponentOwl.BetterListView.BetterListViewColumnHeader lvhState;
        private ComponentOwl.BetterListView.BetterListViewColumnHeader lvhSprint;
        private ComponentOwl.BetterListView.BetterListViewColumnHeader lvhCreated;
        private ComponentOwl.BetterListView.BetterListViewColumnHeader lvhClosed;
        private ComponentOwl.BetterListView.BetterListViewColumnHeader lvhTimeSpent;
        private ComponentOwl.BetterListView.BetterListViewColumnHeader lvhActions;
    }
}

