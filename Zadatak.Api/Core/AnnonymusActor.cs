using Zadatak.Application;

namespace Zadatak.Api.Core
{
    public class AnnonymusActor : IApplicationActor
    {
        public int Id => 0; //id 0 nemamo ga u bazi

        public string Identity => "Anonymus";

        public IEnumerable<int> AllowedUseCases => new List<int> { 4}; //onaj koji nije autorizvoan preko JWT sme da izvrsi samo registraciju
    }
}
