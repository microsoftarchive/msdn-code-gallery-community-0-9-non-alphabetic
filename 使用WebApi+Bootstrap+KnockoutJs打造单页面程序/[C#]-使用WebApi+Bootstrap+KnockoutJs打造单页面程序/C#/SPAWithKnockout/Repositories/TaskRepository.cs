using System;
using System.Collections.Generic;
using System.Globalization;
using KnockoutJSSPA.Models;

namespace KnockoutJSSPA.Repositories
{
    /// <summary>
    /// 这里仓储直接使用示例数据作为演示，真实项目中需要从数据库中动态加载
    /// </summary>
    public class TaskRepository
    {
        #region Static Filed
        private static Lazy<TaskRepository> _taskRepository = new Lazy<TaskRepository>(() => new TaskRepository());

        public static TaskRepository Current
        {
            get { return _taskRepository.Value; }
        }

        #endregion 

        #region Fields
        private readonly List<Task> _tasks = new List<Task>()
        {
            new Task
            {
                Id =1,
                Name = "创建一个SPA程序",
                Description = "SPA(single page web application),SPA的优势就是少量带宽，平滑体验",
                Owner = "Learning hard",
                FinishTime = DateTime.Parse(DateTime.Now.AddDays(1).ToString(CultureInfo.InvariantCulture))
            },
            new Task
            {
                Id =2,
                Name = "学习KnockoutJs",
                Description = "KnockoutJs是一个MVVM类库,支持双向绑定",
                Owner = "Tommy Li",
                FinishTime = DateTime.Parse(DateTime.Now.AddDays(2).ToString(CultureInfo.InvariantCulture))
            },
            new Task
            {
                Id =3,
                Name = "学习AngularJS",
                Description = "AngularJs是MVVM框架，集MVVM和MVC与一体。",
                Owner = "李志",
                FinishTime = DateTime.Parse(DateTime.Now.AddDays(3).ToString(CultureInfo.InvariantCulture))
            },
            new Task
            {
                Id =4,
                Name = "学习ASP.NET MVC网站",
                Description = "Glimpse是一款.NET下的性能测试工具，支持asp.net 、asp.net mvc, EF等等，优势在于，不需要修改原项目任何代码，且能输出代码执行各个环节的执行时间",
                Owner = "Tonny Li",
                FinishTime = DateTime.Parse(DateTime.Now.AddDays(4).ToString(CultureInfo.InvariantCulture))
            },
        };

        #endregion 

        #region Public Methods
        public IEnumerable<Task> GetAll()
        {
            return _tasks;
        }

        public Task Get(int id)
        {
            return _tasks.Find(p => p.Id == id);
        }

        public Task Add(Task item)
        {
            if (item == null)
            {
                throw new ArgumentNullException("item");
            }

            item.Id = _tasks.Count + 1;
            _tasks.Add(item);
            return item;
        }

        public void Remove(int id)
        {
            _tasks.RemoveAll(p => p.Id == id);
        }

        public bool Update(Task item)
        {
            if (item == null)
            {
                throw new ArgumentNullException("item");
            }

            var taskItem = Get(item.Id);
            if (taskItem == null)
            {
                return false;
            }

            _tasks.Remove(taskItem);
            _tasks.Add(item);
            return true;
        }
        #endregion 
    }
}