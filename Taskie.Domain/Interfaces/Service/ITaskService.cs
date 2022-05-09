using System.Collections.Generic;
using System.Threading.Tasks;
using Taskie.Domain.Dto.Task;
using Taskie.Domain.Entities;

namespace Taskie.Domain.Interfaces.Service
{
    public interface ITaskService
    {
        Task<IEnumerable<TaskDto>> GetAllTasksByUser(string idUser);
        Task<IEnumerable<TaskDto>> GetAllTasksFinishedByUser(string idUser);
        Task<IEnumerable<TaskDto>> GetAllTasksPendingByUser(string idUser);
        Task<TaskEntity> GetTaskById(int taskId, string idUser);
        Task<TaskEntity> CreateTask(TaskCreateDto taskCreate);
        Task<TaskEntity> UpdateTask(TaskUpdateDto taskUpdate);
        Task<bool> CompleteTask(int taskId, string idUser);
    }
}
