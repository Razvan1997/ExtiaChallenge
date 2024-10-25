using ExtiaChallenge.Data.Contracts;
using ExtiaChallenge.Data.Models;
using System;
using System.Collections.Generic;
using System.Linq;

namespace ExtiaChallenge.Data.Services
{
    public class SoldierService : ISoldierService
    {
        private readonly ExtiaChallengeContext _context;

        public SoldierService(ExtiaChallengeContext context)
        {
            _context = context ?? throw new ArgumentNullException(nameof(context));
        }

        public List<TSoldier> GetAllSoldiersAsync()
        {
            return _context.TSoldiers.ToList();
        }
    }
}
