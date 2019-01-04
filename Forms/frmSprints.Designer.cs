namespace TimeSands.Forms
{
    partial class frmSprints
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmSprints));
            this.pTop = new System.Windows.Forms.Panel();
            this.hrTop = new TimeSands.Controls.HorizontalDivider();
            this.tsTop = new System.Windows.Forms.ToolStrip();
            this.btnTaskAdd = new System.Windows.Forms.ToolStripButton();
            this.btnSprints = new System.Windows.Forms.ToolStripButton();
            this.pTop.SuspendLayout();
            this.tsTop.SuspendLayout();
            this.SuspendLayout();
            // 
            // pTop
            // 
            this.pTop.Controls.Add(this.hrTop);
            this.pTop.Controls.Add(this.tsTop);
            this.pTop.Dock = System.Windows.Forms.DockStyle.Top;
            this.pTop.Location = new System.Drawing.Point(0, 0);
            this.pTop.Name = "pTop";
            this.pTop.Size = new System.Drawing.Size(875, 49);
            this.pTop.TabIndex = 2;
            // 
            // hrTop
            // 
            this.hrTop.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.hrTop.Location = new System.Drawing.Point(0, 48);
            this.hrTop.Name = "hrTop";
            this.hrTop.Size = new System.Drawing.Size(875, 1);
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
            this.btnSprints});
            this.tsTop.Location = new System.Drawing.Point(1, 0);
            this.tsTop.Name = "tsTop";
            this.tsTop.Padding = new System.Windows.Forms.Padding(1, 0, 10, 0);
            this.tsTop.Size = new System.Drawing.Size(875, 48);
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
            // btnSprints
            // 
            this.btnSprints.AutoSize = false;
            this.btnSprints.Image = ((System.Drawing.Image)(resources.GetObject("btnSprints.Image")));
            this.btnSprints.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.btnSprints.Name = "btnSprints";
            this.btnSprints.Size = new System.Drawing.Size(69, 45);
            this.btnSprints.Text = "Sprints";
            this.btnSprints.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
            // 
            // frmSprints
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(875, 629);
            this.Controls.Add(this.pTop);
            this.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.Name = "frmSprints";
            this.ShowIcon = false;
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Sprints";
            this.pTop.ResumeLayout(false);
            this.tsTop.ResumeLayout(false);
            this.tsTop.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel pTop;
        private Controls.HorizontalDivider hrTop;
        private System.Windows.Forms.ToolStrip tsTop;
        private System.Windows.Forms.ToolStripButton btnTaskAdd;
        private System.Windows.Forms.ToolStripButton btnSprints;
    }
}