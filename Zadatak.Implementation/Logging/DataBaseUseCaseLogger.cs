using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Zadatak.Application;
using Zadatak.EFDataAccess;

namespace Zadatak.Implementation.Logging
{
    public class DataBaseUseCaseLogger : IUseCaseLogger
    {
        private readonly ZadatakContext _context;

        public DataBaseUseCaseLogger(ZadatakContext context)
        {
            _context = context;
        }

        public void Log(IUseCase userCase, IApplicationActor actor, object useCaseData)
        {
            _context.UseCaseLogs.Add( new Domain.UseCaseLog
            {
                Actor = actor.Identity,
                Data = JsonConvert.SerializeObject(useCaseData),
                Date = DateTime.UtcNow,
                UseCaseName = userCase.Name
            });
            _context.SaveChanges();
        }
    }
}
