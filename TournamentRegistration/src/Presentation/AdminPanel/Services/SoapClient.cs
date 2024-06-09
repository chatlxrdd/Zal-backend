using Core.Entities;
using System;
using System.Collections.Generic;
using System.ServiceModel; // Dodaj to
using System.Threading.Tasks;

namespace AdminPanel.Services
{
    public class SoapClient
    {
        private readonly ITournamentService _client;

        public SoapClient()
        {
            var binding = new BasicHttpBinding();
            var endpoint = new EndpointAddress("http://localhost:5258/TournamentService.svc");
            _client = new ChannelFactory<ITournamentService>(binding, endpoint).CreateChannel();
        }

        public Task<List<Tournament>> GetTournaments()
        {
            return _client.GetTournaments();
        }

        public Task<Tournament> GetTournament(int id)
        {
            return _client.GetTournament(id);
        }

        public Task AddTournament(Tournament tournament)
        {
            return _client.AddTournament(tournament);
        }
    }

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
