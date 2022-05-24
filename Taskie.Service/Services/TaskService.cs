using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Taskie.Domain.Dto.Task;
using Taskie.Domain.Entities;
using Taskie.Domain.Interfaces.Service;

namespace Taskie.Service.Services
{
    public class TaskService : ITaskService
    {
        public Task<bool> CompleteTask(int taskId, string idUser)
        {
            throw new NotImplementedException();
        }

        public Task<TaskEntity> CreateTask(TaskCreateDto taskCreate)
        {
            throw new NotImplementedException();
        }

        public Task<bool> DeleteTask(int idTask)
        {
            throw new NotImplementedException();
        }

        public Task<IEnumerable<TaskDto>> GetAllTasks(string idUser)
        {
            throw new NotImplementedException();
        }

        public Task<IEnumerable<TaskDto>> GetAllTasksFinished(string idUser)
        {
            throw new NotImplementedException();
        }

        public Task<IEnumerable<TaskDto>> GetAllTasksFinishedByPriority(string idUser, int priority)
        {
            throw new NotImplementedException();
        }

        public Task<IEnumerable<TaskDto>> GetAllTasksFinishedInTime(string idUser, bool inTime)
        {
            throw new NotImplementedException();
        }

        public Task<IEnumerable<TaskDto>> GetAllTasksPending(string idUser)
        {
            throw new NotImplementedException();
        }

        public Task<TaskEntity> GetTaskById(int taskId, string idUser)
        {
            throw new NotImplementedException();
        }

        public Task<TaskEntity> UpdateTask(TaskUpdateDto taskUpdate)
        {
            throw new NotImplementedException();
        }
    }
}
