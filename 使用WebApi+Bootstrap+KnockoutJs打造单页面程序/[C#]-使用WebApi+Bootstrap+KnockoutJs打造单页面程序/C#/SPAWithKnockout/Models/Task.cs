using System;

namespace KnockoutJSSPA.Models
{
    public enum TaskState
    {
        Active = 1,
        Completed =2
    }

    /// <summary>
    /// 任务实体
    /// </summary>
    public class Task
    {
        public int Id { get; set; }

        public string Name { get; set; }
        public string Description { get; set; }

        public DateTime CreationTime { get; set; }

        public DateTime FinishTime { get; set; }

        public string Owner { get; set; }
        public TaskState State { get; set; }

        public Task()
        {
            CreationTime = DateTime.Parse(DateTime.Now.ToLongDateString());
            State = TaskState.Active;
        }
    }
}