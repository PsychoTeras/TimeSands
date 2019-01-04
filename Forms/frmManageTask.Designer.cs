using TimeSands.Controls;

namespace IPCLogger.ConfigurationService.Forms
{
    partial class frmManageTask
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
            this.tlpMain = new TimeSands.Controls.BorderedTableLayoutPanel();
            this.btnCancel = new System.Windows.Forms.Button();
            this.tlpInner = new System.Windows.Forms.TableLayoutPanel();
            this.cbBoard = new TimeSands.Controls.BorderedButtonBox();
            this.label5 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.tbName = new System.Windows.Forms.TextBox();
            this.cbSprint = new TimeSands.Controls.BorderedButtonBox();
            this.cbMakeActive = new System.Windows.Forms.CheckBox();
            this.btnOk = new System.Windows.Forms.Button();
            this.tlpMain.SuspendLayout();
            this.tlpInner.SuspendLayout();
            this.SuspendLayout();
            // 
            // tlpMain
            // 
            this.tlpMain.ColumnCount = 2;
            this.tlpMain.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tlpMain.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
            this.tlpMain.Controls.Add(this.btnCancel, 0, 1);
            this.tlpMain.Controls.Add(this.tlpInner, 0, 0);
            this.tlpMain.Controls.Add(this.btnOk, 0, 1);
            this.tlpMain.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tlpMain.Location = new System.Drawing.Point(12, 14);
            this.tlpMain.Name = "tlpMain";
            this.tlpMain.RowCount = 2;
            this.tlpMain.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tlpMain.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 46F));
            this.tlpMain.Size = new System.Drawing.Size(540, 233);
            this.tlpMain.TabIndex = 10;
            // 
            // btnCancel
            // 
            this.btnCancel.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.btnCancel.Dock = System.Windows.Forms.DockStyle.Right;
            this.btnCancel.Location = new System.Drawing.Point(446, 195);
            this.btnCancel.Margin = new System.Windows.Forms.Padding(2, 8, 7, 8);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new System.Drawing.Size(87, 30);
            this.btnCancel.TabIndex = 15;
            this.btnCancel.Text = "Cancel";
            this.btnCancel.UseVisualStyleBackColor = true;
            // 
            // tlpInner
            // 
            this.tlpInner.ColumnCount = 2;
            this.tlpMain.SetColumnSpan(this.tlpInner, 2);
            this.tlpInner.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 110F));
            this.tlpInner.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tlpInner.Controls.Add(this.cbBoard, 1, 1);
            this.tlpInner.Controls.Add(this.label5, 0, 0);
            this.tlpInner.Controls.Add(this.label6, 0, 1);
            this.tlpInner.Controls.Add(this.label7, 0, 2);
            this.tlpInner.Controls.Add(this.tbName, 1, 0);
            this.tlpInner.Controls.Add(this.cbSprint, 1, 2);
            this.tlpInner.Controls.Add(this.cbMakeActive, 0, 3);
            this.tlpInner.Dock = System.Windows.Forms.DockStyle.Top;
            this.tlpInner.Location = new System.Drawing.Point(3, 3);
            this.tlpInner.Name = "tlpInner";
            this.tlpInner.Padding = new System.Windows.Forms.Padding(0, 3, 2, 0);
            this.tlpInner.RowCount = 5;
            this.tlpInner.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 31F));
            this.tlpInner.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 31F));
            this.tlpInner.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 31F));
            this.tlpInner.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 31F));
            this.tlpInner.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 31F));
            this.tlpInner.Size = new System.Drawing.Size(534, 129);
            this.tlpInner.TabIndex = 9;
            // 
            // cbBoard
            // 
            this.cbBoard.ButtonEnabled = false;
            this.cbBoard.ButtonFont = new System.Drawing.Font("Verdana", 6.75F);
            this.cbBoard.ButtonImage = null;
            this.cbBoard.ButtonPadding = new System.Windows.Forms.Padding(2, 0, 0, 0);
            this.cbBoard.ButtonText = "...";
            this.cbBoard.Dock = System.Windows.Forms.DockStyle.Fill;
            this.cbBoard.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbBoard.Location = new System.Drawing.Point(113, 37);
            this.cbBoard.MaxLength = 39;
            this.cbBoard.Name = "cbBoard";
            this.cbBoard.Size = new System.Drawing.Size(416, 23);
            this.cbBoard.TabIndex = 2;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Dock = System.Windows.Forms.DockStyle.Fill;
            this.label5.Location = new System.Drawing.Point(3, 3);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(104, 31);
            this.label5.TabIndex = 1;
            this.label5.Text = "Name:";
            this.label5.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Dock = System.Windows.Forms.DockStyle.Fill;
            this.label6.Location = new System.Drawing.Point(3, 34);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(104, 31);
            this.label6.TabIndex = 5;
            this.label6.Text = "Board:";
            this.label6.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Dock = System.Windows.Forms.DockStyle.Fill;
            this.label7.Location = new System.Drawing.Point(3, 65);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(104, 31);
            this.label7.TabIndex = 6;
            this.label7.Text = "Sprint:";
            this.label7.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // tbName
            // 
            this.tbName.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tbName.Location = new System.Drawing.Point(113, 6);
            this.tbName.MaxLength = 39;
            this.tbName.Name = "tbName";
            this.tbName.Size = new System.Drawing.Size(416, 23);
            this.tbName.TabIndex = 1;
            // 
            // cbSprint
            // 
            this.cbSprint.ButtonEnabled = false;
            this.cbSprint.ButtonFont = new System.Drawing.Font("Verdana", 6.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.cbSprint.ButtonImage = null;
            this.cbSprint.ButtonPadding = new System.Windows.Forms.Padding(2, 0, 0, 0);
            this.cbSprint.ButtonText = "...";
            this.cbSprint.Dock = System.Windows.Forms.DockStyle.Fill;
            this.cbSprint.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbSprint.Location = new System.Drawing.Point(113, 68);
            this.cbSprint.MaxLength = 100;
            this.cbSprint.Name = "cbSprint";
            this.cbSprint.Size = new System.Drawing.Size(416, 23);
            this.cbSprint.TabIndex = 3;
            // 
            // cbMakeActive
            // 
            this.cbMakeActive.AutoSize = true;
            this.tlpInner.SetColumnSpan(this.cbMakeActive, 2);
            this.cbMakeActive.Dock = System.Windows.Forms.DockStyle.Fill;
            this.cbMakeActive.Location = new System.Drawing.Point(3, 99);
            this.cbMakeActive.Name = "cbMakeActive";
            this.cbMakeActive.Padding = new System.Windows.Forms.Padding(3, 0, 0, 0);
            this.cbMakeActive.Size = new System.Drawing.Size(526, 25);
            this.cbMakeActive.TabIndex = 7;
            this.cbMakeActive.Text = "Make this task active";
            this.cbMakeActive.UseVisualStyleBackColor = true;
            // 
            // btnOk
            // 
            this.btnOk.Dock = System.Windows.Forms.DockStyle.Right;
            this.btnOk.Location = new System.Drawing.Point(354, 195);
            this.btnOk.Margin = new System.Windows.Forms.Padding(5, 8, 3, 8);
            this.btnOk.Name = "btnOk";
            this.btnOk.Size = new System.Drawing.Size(87, 30);
            this.btnOk.TabIndex = 14;
            this.btnOk.Text = "OK";
            this.btnOk.UseVisualStyleBackColor = true;
            this.btnOk.Click += new System.EventHandler(this.BtnOkClick);
            // 
            // frmManageTask
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(564, 261);
            this.Controls.Add(this.tlpMain);
            this.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.KeyPreview = true;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.MinimumSize = new System.Drawing.Size(580, 300);
            this.Name = "frmManageTask";
            this.Padding = new System.Windows.Forms.Padding(12, 14, 12, 14);
            this.ShowIcon = false;
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Add/Edit task";
            this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.FrmKeyDown);
            this.tlpMain.ResumeLayout(false);
            this.tlpInner.ResumeLayout(false);
            this.tlpInner.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private BorderedTableLayoutPanel tlpMain;
        private System.Windows.Forms.Button btnCancel;
        private System.Windows.Forms.TableLayoutPanel tlpInner;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.TextBox tbName;
        private BorderedButtonBox cbSprint;
        private System.Windows.Forms.Button btnOk;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label7;
        private TimeSands.Controls.BorderedButtonBox cbBoard;
        private System.Windows.Forms.CheckBox cbMakeActive;
    }
}