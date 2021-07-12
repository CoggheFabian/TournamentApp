using System.Collections.Generic;
using System.Linq;
using TournamentApp.Model;
using TournamentApp.Repositories.Interfaces;
using TournamentApp.Shared.Dtos;

namespace TournamentApp.Repositories.Implementation.RoundRepo
{
    public class MockRoundRepository : IRoundRepository
    {
        private readonly List<Round> _rounds;

        public MockRoundRepository()
        {
            _rounds = new List<Round>();
        }

        public IQueryable<Round> Get(int id)
        {
            return _rounds.Where(x => x.Id == id).AsQueryable();
        }

        public IQueryable<Round> Add(Round entity)
        {
            _rounds.Add(entity);
            return Get(entity.Id);
        }

        public IQueryable<Round> Delete(int id)
        {
            var round = Get(id);
            _rounds.Remove(Get(id).First());
            return round;
        }

        public IQueryable<Round> Update(int id, Round entity)
        {
            throw new System.NotImplementedException();
        }

        public IQueryable<Round> GetAll()
        {
            return _rounds.AsQueryable();
        }

        public void Save()
        {
            throw new System.NotImplementedException();
        }

        public IQueryable<Round> MakeMainRoundForTournament(CreatedTournamentDto createdTournamentDto)
        {
            return Add(new Round
            {
                TournamentId = createdTournamentDto.Id
            });
        }

        public IQueryable<Round> GetAllRoundFromATournament(int tournamentId)
        {
            throw new System.NotImplementedException();
        }
    }
}