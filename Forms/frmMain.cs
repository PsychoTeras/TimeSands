using System;
using System.Linq;
using System.Windows.Forms;
using TimeSands.Entities.Collections;
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
            //board.Name = "New board";
            //board.Save();

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

        private void InitializeControls()
        {
            cbCurrentSprint.SetDataSource(Sprints.Instance, "Name", () => Sprints.Instance.ActiveSprint);
            lvTasks.DataSource = Tasks.Instance;
        }

        private void btnSprints_Click(object sender, EventArgs e)
        {
            Tasks.Instance.First().Name = "12312312313";
            lvTasks.Refresh();
        }
    }
}
