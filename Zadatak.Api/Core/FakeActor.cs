using Zadatak.Application;

namespace Zadatak.Api.Core
{
    public class FakeActor : IApplicationActor
    {       
            public int Id => 1;

            public string Identity => "Test Api User";

            public IEnumerable<int> AllowedUseCases => new List<int> { 1 }; 
    }

        public class AdminFakeActor : IApplicationActor
        {
            public int Id => 2;

            public string Identity => "Fake Admin";

            public IEnumerable<int> AllowedUseCases => Enumerable.Range(1, 1000);
        }
    
}
