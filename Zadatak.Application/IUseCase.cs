﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Zadatak.Application
{
    public interface IUseCase
    {
        int Id { get; }
        string Name { get; }
    }

    public interface ICommand<TRequest> : IUseCase
    {
        void Execute(TRequest request);
    }

    public interface IQuery<TSearch, TResult> : IUseCase
    {
        TResult Execute(TSearch search);
    }

}
