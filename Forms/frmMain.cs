using IPCLogger.ConfigurationService.Forms;
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

            Boards boards = Boards.Instance;
            BoardModel board = boards.Create();
            board.Name = "Voice2Dox";
            board.Save();

            //Sprints sprints = Sprints.Instance;

            //SprintModel sprint = sprints.Create();
            //sprint.Name = "New sprint";
            //sprint.Save();

            //sprints.ActiveSprint = sprint;

            //Tasks tasks = Tasks.Instance;
            //TaskModel task = tasks.Create(board.Id, sprint.Id);
            //task.Name = "12345";

            //////TaskRecordModel taskRecord1 = new TaskRecordModel();
            //////taskRecord1.StartTime = DateTime.Now;
            //////taskRecord1.StopTime = taskRecord1.StartTime.AddHours(1);

            //////TaskRecordModel taskRecord2 = new TaskRecordModel();
            //////taskRecord2.StartTime = DateTime.Now.AddDays(1);
            //////taskRecord2.StopTime = taskRecord2.StartTime.AddHours(2).AddMinutes(35);

            //////task.Records.Add(taskRecord1);
            //////task.Records.Add(taskRecord2);

            //task.Save();

            InitializeControls();
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
            lvTasks.EndUpdate();

            timerRefreshTasks.Interval = 1000 * 60 * 1; //1 minute
            timerRefreshTasks.Enabled = true;
        }

        private void timerRefreshTasks_Tick(object sender, EventArgs e)
        {
            lvTasks.Refresh();
        }

        private void btnTaskAdd_Click(object sender, EventArgs e)
        {
            using (frmManageTask form = new frmManageTask())
            {
                if (form.Execute())
                {
                    RefreshDataSources();
                }
            }
        }

        private void btnSprints_Click(object sender, EventArgs e)
        {

        }

        private void lvTasks_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            if (lvTasks.SelectedItem is TaskModel task)
            {
                task.ToggleActive();
                lvTasks.Refresh();
            }
        }

        private void lvTasks_DrawItem(object sender, BetterListViewDrawItemEventArgs e)
        {
            int idxActivity = lvhActivity.Index;
            Rectangle rectInner = e.ItemBounds.SubItemBounds[idxActivity].BoundsInner;
            if (rectInner.Width <= 0 || rectInner.Height <= 0)
            {
                return;
            }

            TaskModel task = lvTasks.GetItem<TaskModel>(e.Item.Index);
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
            }
            subActivity.Image = image;
        }
    }
}
