using System;
using System.Windows.Forms;
using TimeSands.Entities.Enums;
using TimeSands.Entities.Models;

namespace TimeSands.Forms
{
    public partial class frmMain : Form
    {
        public frmMain()
        {
            InitializeComponent();

            Sprints sprints = Sprints.Instance;

            SprintModel sprint = sprints.Create();
            sprint.Name = "New sprint";
            sprint.Save();

            int id = sprint.Id;
            sprint = sprints.Get(id);

            sprints.Delete(sprint);

            Tasks tasks = Tasks.Instance;
            TaskModel task = new TaskModel();
            task.Name = "12345";
            task.CreateTime = DateTime.Now;
            task.State = TaskState.Active;
            task.Sprint = sprint;

            TaskRecordModel taskRecord1 = new TaskRecordModel();
            taskRecord1.StartTime = DateTime.Now;
            taskRecord1.EndTime = taskRecord1.StartTime.AddHours(1);

            TaskRecordModel taskRecord2 = new TaskRecordModel();
            taskRecord2.StartTime = DateTime.Now.AddDays(1);
            taskRecord2.EndTime = taskRecord2.StartTime.AddHours(2).AddMinutes(35);

            task.Records.Add(taskRecord1);
            task.Records.Add(taskRecord2);

            tasks.Append(task);
            lvTasks.DataSource = tasks;
        }
    }
}
