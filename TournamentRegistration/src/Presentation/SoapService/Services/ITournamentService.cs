using System.Collections.Generic;
using System.ServiceModel;
using System.Threading.Tasks;
using Core.Entities;

namespace SoapService.Services
{
    [ServiceContract]
    public interface ITournamentService
    {
        [OperationContract]
        Task<List<Tournament>> GetTournaments();

        [OperationContract]
        Task<Tournament> GetTournament(int id);

        [OperationContract]
        Task AddTournament(Tournament tournament);
    }
}
