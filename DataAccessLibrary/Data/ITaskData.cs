using DataAccessLibrary.Models;

namespace DataAccessLibrary.Data
{
    public interface ITaskData
    {
        Task DeleteTask(int id);
        Task<TaskModel?> GetTask(int id);
        Task<IEnumerable<TaskModel>> GetTasks();
        Task InsertTask(TaskModel task);
        Task UpdateTask(TaskModel task);
        Task MarkComplete(int id);  
    }
}