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

            SprintModel sprint = new SprintModel();
            sprint.Name = "*";

            Tasks tasks = new Tasks();
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

            tasks.Add(task);
            lvTasks.DataSource = tasks;
        }
    }
}
