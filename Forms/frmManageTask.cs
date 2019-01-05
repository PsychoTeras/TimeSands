using System;
using System.ComponentModel.DataAnnotations;
using System.Windows.Forms;
using TimeSands.Entities.Collections;
using TimeSands.Entities.Models;

namespace TimeSands.Forms
{
    internal partial class frmManageTask : Form
    {
        private bool _editing;
        private TaskModel _taskModel;
        private static int _lastBoardId;

        public TaskModel Result { get; private set; }

        public frmManageTask()
        {
            InitializeComponent();
        }

        private void BtnOkClick(object sender, EventArgs e)
        {
            Ok();
        }

        private void FrmKeyDown(object sender, KeyEventArgs e)
        {
            switch (e.KeyCode)
            {
                case Keys.Escape:
                    DialogResult = DialogResult.Cancel;
                    break;
                case Keys.Enter:
                    Ok();
                    break;
            }
        }

        private void LockWindow()
        {
            Cursor = Cursors.WaitCursor;
            Enabled = false;
            Application.DoEvents();
        }

        private void UnlockWindow()
        {
            Cursor = Cursors.Default;
            Enabled = true;
            Application.DoEvents();
        }

        private void Ok()
        {
            try
            {
                AssertChanges();
                CreateResultModel();
                try
                {
                    LockWindow();
                    SaveChanges();
                }
                finally
                {
                    UnlockWindow();
                }
                Result = _taskModel;
                DialogResult = DialogResult.OK;
            }
            catch (ValidationException vex)
            {
                MessageBox.Show(vex.Message, "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                ((Control)vex.Value).Focus();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        public bool Execute()
        {
            return Execute(null);
        }

        public bool Execute(TaskModel existingModel)
        {
            _editing = existingModel != null;
            _taskModel = existingModel ?? new TaskModel();
            BindModels();
            return ShowDialog() == DialogResult.OK;
        }

        private void BindModels()
        {
            Text = !_editing ? "Add task" : "Edit task";
            tbName.Text = _taskModel.Name;
            cbBoard.SetDataSource(Boards.Instance, null, 
                () => Boards.Instance.Get(_editing ? _taskModel.BoardId : _lastBoardId));
            cbSprint.SetDataSource(Sprints.Instance, null, 
                () => _editing ? Sprints.Instance.Get(_taskModel.SprintId) : Sprints.Instance.ActiveSprint);
            cbMakeActive.Visible = !_editing;
        }

        private void AssertChanges()
        {
            if (string.IsNullOrWhiteSpace(tbName.Text))
            {
                throw new ValidationException("Task name cannot be empty", null, tbName);
            }
            if (cbBoard.SelectedItem == null)
            {
                throw new ValidationException("Board cannot be empty", null, cbBoard);
            }
            if (cbSprint.SelectedItem == null)
            {
                throw new ValidationException("Sprint cannot be empty", null, cbSprint);
            }
        }

        private void CreateResultModel()
        {
            if (!_editing)
            {
                Tasks.Instance.Append(_taskModel);
            }
            _taskModel.Name = tbName.Text.Trim();
            _taskModel.BoardId = ((BoardModel)cbBoard.SelectedItem).Id;
            _taskModel.SprintId = ((SprintModel)cbSprint.SelectedItem).Id;
            _lastBoardId = _taskModel.BoardId;
        }

        private void SaveChanges()
        {
            _taskModel.Save();
            if (cbMakeActive.Checked)
            {
                _taskModel.SetActive();
            }
        }
    }
}
