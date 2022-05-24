using System.Collections.Generic;
using System.Threading.Tasks;
using Taskie.Domain.Dto.Task;
using Taskie.Domain.Entities;

namespace Taskie.Domain.Interfaces.Service
{
    public interface ITaskService
    {
        Task<TaskEntity> GetTaskById(int taskId, string idUser);
        Task<IEnumerable<TaskDto>> GetAllTasks(string idUser);
        Task<IEnumerable<TaskDto>> GetAllTasksFinished(string idUser);
        Task<IEnumerable<TaskDto>> GetAllTasksPending(string idUser);
        Task<IEnumerable<TaskDto>> GetAllTasksFinishedInTime(string idUser, bool inTime);
        Task<IEnumerable<TaskDto>> GetAllTasksFinishedByPriority(string idUser, int priority);
        Task<TaskEntity> CreateTask(TaskCreateDto taskCreate);
        Task<TaskEntity> UpdateTask(TaskUpdateDto taskUpdate);
        Task<bool> CompleteTask(int taskId, string idUser);
        Task<bool> DeleteTask(int idTask);
    }
}
