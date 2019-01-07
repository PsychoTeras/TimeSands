using System;
using System.Drawing;
using System.Windows.Forms;
using ComponentOwl.BetterListView;
using TimeSands.Entities.Collections;
using TimeSands.Entities.Enums;
using TimeSands.Entities.Models;

namespace TimeSands.Forms
{
    public partial class frmMain : Form
    {
        public frmMain()
        {
            InitializeComponent();

            //Boards boards = Boards.Instance;
            //BoardModel board = boards.Create();
            //board.Name = "Voice2Dox";
            //board.Save();

            InitializeControls();

            Tasks.Instance.ActiveTask?.Resume();
        }

        private void RefreshDataSources()
        {
            cbCurrentSprint.Refresh();
            lvTasks.Refresh();
        }

        private void InitializeControls()
        {
            cbCurrentSprint.BeginUpdate();
            cbCurrentSprint.SetDataSource(Sprints.Instance, "Name", () => Sprints.Instance.ActiveSprint);
            cbCurrentSprint.EndUpdate();

            lvTasks.BeginUpdate();
            lvTasks.DataSource = Tasks.Instance;
            lvTasks.SelectedItems.Clear();
            lvTasks.EndUpdate();

            timerRefreshTasks.Interval = 1000 * 60 * 1; //1 minute
            timerRefreshTasks.Enabled = true;
        }

        private void TimerRefreshTasksTick(object sender, EventArgs e)
        {
            lvTasks.Refresh();
        }

        private void AddTask()
        {
            using (frmManageTask form = new frmManageTask())
            {
                if (form.Execute())
                {
                    RefreshDataSources();
                }
            }
        }

        private void BtnTaskAddClick(object sender, EventArgs e)
        {
            AddTask();
        }

        private void StartTask()
        {
            if (lvTasks.SelectedItem is TaskModel task)
            {
                task.Start();
                UpdateTaskButtons();
            }
        }

        private void BtnTaskStartClick(object sender, EventArgs e)
        {
            StartTask();
        }

        private void SuspendTask()
        {
            if (lvTasks.SelectedItem is TaskModel task)
            {
                task.Suspend();
                UpdateTaskButtons();
            }
        }

        private void BtnTaskSuspendClick(object sender, EventArgs e)
        {
            SuspendTask();
        }

        private void StopTask()
        {
            if (lvTasks.SelectedItem is TaskModel task)
            {
                task.Stop();
                UpdateTaskButtons();
            }
        }

        private void BtnTaskStopClick(object sender, EventArgs e)
        {
            StopTask();
        }

        private void CloseTask()
        {
            if (lvTasks.SelectedItem is TaskModel task)
            {
                task.Close();
                UpdateTaskButtons();
            }
        }

        private void BtnTaskCloseClick(object sender, EventArgs e)
        {
            CloseTask();
        }

        private void ModifyTask()
        {
            using (frmManageTask form = new frmManageTask())
            {
                if (form.Execute(lvTasks.SelectedItem as TaskModel))
                {
                    RefreshDataSources();
                }
            }
        }

        private void BtnTaskModifyClick(object sender, EventArgs e)
        {
            ModifyTask();
        }

        private void DeleteTask()
        {
            UpdateTaskButtons();
        }

        private void BtnTaskDeleteClick(object sender, EventArgs e)
        {
            if (lvTasks.SelectedItem is TaskModel task)
            {
                task.Delete();
                lvTasks.Refresh();
                UpdateTaskButtons();
            }
        }

        private void BtnSprintsClick(object sender, EventArgs e)
        {
        }

        private void UpdateTaskButtons()
        {
            TaskModel task = lvTasks.SelectedValue as TaskModel;
            bool taskSelected = task != null;
            btnTaskStart.Enabled = taskSelected && task.CanStart;
            btnTaskSuspend.Enabled = taskSelected && task.CanSuspend;
            btnTaskStop.Enabled = taskSelected && task.CanStop;
            btnTaskClose.Enabled = taskSelected && task.CanClose;
            btnTaskDelete.Enabled = btnTaskModify.Enabled = taskSelected;
            lvTasks.Repaint();
        }

        private void LvTasksSelectedIndexChanged(object sender, EventArgs e)
        {
            UpdateTaskButtons();
        }

        private void LvTasksMouseDoubleClick(object sender, MouseEventArgs e)
        {
            BetterListViewItem lvItem = lvTasks.GetItemAt(e.Location);
            if (lvItem != null && lvTasks.GetItem<TaskModel>(lvItem.Address.Index) is TaskModel task)
            {
                task.ToggleActive();
                UpdateTaskButtons();
            }
        }

        private void LvTasksDrawItem(object sender, BetterListViewDrawItemEventArgs e)
        {
            int idxActivity = lvhActivity.Index;
            Rectangle rectInner = e.ItemBounds.SubItemBounds[idxActivity].BoundsInner;
            if (rectInner.Width <= 0 || rectInner.Height <= 0)
            {
                return;
            }

            TaskModel task = lvTasks.GetItem<TaskModel>(e.Item.Address.Index);
            if (task == null)
            {
                return;
            }

            BetterListViewSubItem subActivity = e.Item.SubItems[idxActivity];

            Image image = null;
            switch (task.State)
            {
                case TaskState.Idle:
                    image = Resources.Resources.GreyBall;
                    break;
                case TaskState.Active:
                    image = Resources.Resources.GreenBall;
                    break;
                case TaskState.Suspended:
                    image = Resources.Resources.YellowBall;
                    break;
                case TaskState.Deleted:
                    image = Resources.Resources.RedBall;
                    break;
                case TaskState.Closed:
                    image = Resources.Resources.BlueBall;
                    break;
            }
            subActivity.Image = image;
        }

        private void FrmMainLoad(object sender, EventArgs e)
        {
            UpdateTaskButtons();
        }

        private void FrmMainClosing(object sender, FormClosingEventArgs e)
        {
            Tasks.Instance.ActiveTask?.Suspend();
        }
    }
}
