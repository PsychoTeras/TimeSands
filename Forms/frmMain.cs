using System;
using System.Drawing;
using System.Windows.Forms;
using ComponentOwl.BetterListView;
using TimeSands.Controls;
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
            if (Tasks.Instance.ActiveTask?.Resume() ?? false)
            {
                lvTasks.RefreshItems();
            }
        }

        private void RebindDataSources()
        {
            cbCurrentSprint.Rebind();
            lvTasks.Rebind();
        }

        private void InitializeControls()
        {
            cbCurrentSprint.Bind(Sprints.Instance, "Name", () => Sprints.Instance.ActiveSprint);

            lvTasks.BindGroups(Boards.Instance, b => b, b => b.Name);
            lvTasks.BindItems(Tasks.Instance, i => Boards.Instance.Get(i.BoardId));
            lvTasks.SelectedItems.Clear();

            timerRefreshTasks.Interval = 1000 * 60 * 1; //1 minute
            timerRefreshTasks.Enabled = true;
        }

        private void TimerRefreshTasksTick(object sender, EventArgs e)
        {
            lvTasks.RefreshItems();
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
        }

        private void AddTask()
        {
            using (frmManageTask form = new frmManageTask())
            {
                if (form.Execute())
                {
                    RebindDataSources();
                }
            }
        }

        private void BtnTaskAddClick(object sender, EventArgs e)
        {
            AddTask();
        }

        private void StartSelectedTask()
        {
            if (lvTasks.SelectedValue is TaskModel task)
            {
                task.Start();
                UpdateTaskButtons();
                lvTasks.RefreshItems();
            }
        }

        private void BtnTaskStartClick(object sender, EventArgs e)
        {
            StartSelectedTask();
        }

        private void SuspendSelectedTask()
        {
            if (lvTasks.SelectedValue is TaskModel task)
            {
                task.Suspend();
                UpdateTaskButtons();
                lvTasks.RefreshSelectedItem();
            }
        }

        private void BtnTaskSuspendClick(object sender, EventArgs e)
        {
            SuspendSelectedTask();
        }

        private void StopSelectedTask()
        {
            if (lvTasks.SelectedValue is TaskModel task)
            {
                task.Stop();
                UpdateTaskButtons();
                lvTasks.RefreshSelectedItem();
            }
        }

        private void BtnTaskStopClick(object sender, EventArgs e)
        {
            StopSelectedTask();
        }

        private void CloseSelectedTask()
        {
            if (lvTasks.SelectedValue is TaskModel task)
            {
                task.Close();
                UpdateTaskButtons();
                lvTasks.RefreshSelectedItem();
            }
        }

        private void BtnTaskCloseClick(object sender, EventArgs e)
        {
            CloseSelectedTask();
        }

        private void ModifySelectedTask()
        {
            using (frmManageTask form = new frmManageTask())
            {
                if (form.Execute(lvTasks.SelectedValue as TaskModel))
                {
                    RebindDataSources();
                }
            }
        }

        private void BtnTaskModifyClick(object sender, EventArgs e)
        {
            ModifySelectedTask();
        }

        private void DeleteSelectedTask()
        {
            if (lvTasks.SelectedValue is TaskModel task)
            {
                task.Delete();
                UpdateTaskButtons();
                lvTasks.RebindItems();
            }
        }

        private void BtnTaskDeleteClick(object sender, EventArgs e)
        {
            DeleteSelectedTask();
        }

        private void BtnSprintsClick(object sender, EventArgs e)
        {
            lvTasks.RefreshItems();
        }

        private void LvTasksSelectedIndexChanged(object sender, EventArgs e)
        {
            UpdateTaskButtons();
        }

        private void LvTasksMouseDoubleClick(object sender, MouseEventArgs e)
        {
            BetterListViewItem lvItem = lvTasks.GetItemAt(e.Location);
            if (lvItem != null && lvTasks.SelectedValue is TaskModel task)
            {
                task.ToggleActive();
                UpdateTaskButtons();
                lvTasks.RefreshItems();
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

            TaskModel task = e.Item.DataObject<TaskModel>();
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

            if (subActivity.Image != image)
            {
                subActivity.Image = image;
            }
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
