using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Web.Http;
using KnockoutJSSPA.Models;
using KnockoutJSSPA.Repositories;

namespace KnockoutJSSPA.Controllers
{
    /// <summary>
    /// Task WebAPI,提供数据服务
    /// </summary>
    public class TasksController : ApiController
    {
        private readonly TaskRepository _taskRepository = TaskRepository.Current;

        public IEnumerable<Task> GetAll()
        {
            return _taskRepository.GetAll().OrderBy(a => a.Id);
        }

        public Task Get(int id)
        {
            var item = _taskRepository.Get(id);
            if (item == null)
            {
                throw new HttpResponseException(HttpStatusCode.NotFound);
            }

            return item;
        }

        [Route("api/tasks/GetByState")]
        public IEnumerable<Task> GetByState(string state)
        {
            IEnumerable<Task> results = new List<Task>();
            switch (state.ToLower())
            {
                case "":
                case "all":
                    results = _taskRepository.GetAll();
                    break;
                case "active":
                    results = _taskRepository.GetAll().Where(t => t.State == TaskState.Active);
                    break;
                case "completed":
                    results = _taskRepository.GetAll().Where(t => t.State == TaskState.Completed);
                    break;
            }

            results = results.OrderBy(t => t.Id);
            return results;
        }

        [HttpPost]
        public Task Create(Task item)
        {
           return _taskRepository.Add(item);
        }

        [HttpPut]
        public void Put(Task item)
        {
            if (!_taskRepository.Update(item))
            {
                throw new HttpResponseException(HttpStatusCode.NotFound);
            }
        }

        public void Delete(int id)
        {
            _taskRepository.Remove(id);
        }
    }
}