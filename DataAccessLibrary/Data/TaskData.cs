using DataAccessLibrary.DbAccess;
using DataAccessLibrary.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessLibrary.Data;

public class TaskData : ITaskData
{
    private readonly ISqlDataAccess _db;
    public TaskData(ISqlDataAccess db)
    {
        _db = db;
    }

    public Task<IEnumerable<TaskModel>> GetTasks() => _db.LoadData<TaskModel, dynamic>("dbo.spTask_GetAll", new { });

    public async Task<TaskModel?> GetTask(int id)
    {
        var results = await _db.LoadData<TaskModel, dynamic>("dbo.spTask_Get", new { Id = id });

        return results.FirstOrDefault();
    }

    public Task InsertTask(TaskModel task) => _db.SaveData("dbo.spTask_Insert", new { task.Title, task.IsComplete });

    public Task UpdateTask(TaskModel task) => _db.SaveData("dbo.spTask_Update", new
    {
        task.Id,
        task.Title,
        task.IsComplete
    });

    public Task DeleteTask(int id) => _db.SaveData("dbo.spTask_Delete", new { Id = id });
}
