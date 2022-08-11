﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Zadatak.Application
{
    public interface IApplicationActor
    {
        int Id { get; }
        string Identity { get; }
        IEnumerable<int> AllowedUseCases { get; }
    }
}
