﻿using DataAccessLayer.Entities;

using System.Collections.Generic;

namespace Client.Interfaces
{
    public interface ITaskService
    {
        Task Get(int id);
        IEnumerable<Task> Get();

        IEnumerable<Task> GetTasksWithShortName(int userId);
        IEnumerable<Task> GetFinishedTasks(int userId);

        Task GetLongestTask(int userId);
        Task GetTaskWithLongestDescription(int projectId);
        Task GetTaskWithShortestName(int projectId);

        int CountTask(int userId, int projectId);
        int UnfinishedTaskAmount(int userId);

        bool DeleteTask(int id);
        bool CreateTask(Core.DataTransferObjects.Task.CreateTaskDTO createTaskDto);
    }
}
