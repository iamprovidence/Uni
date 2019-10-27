﻿using System.Threading.Tasks;

namespace BusinessLayer.Interfaces
{
    public interface ICommandProcessor
    {
        Task<TResponse> ProcessAsync<THandler, TCommand, TResponse>(TCommand command)
               where THandler : ICommandHandler<TCommand, TResponse>, IUnitOfWorkSettable, new()
               where TCommand : ICommand<TResponse>;
    }
}
