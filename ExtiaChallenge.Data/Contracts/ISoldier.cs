using ExtiaChallenge.Data.Models;
using System.Collections.Generic;

namespace ExtiaChallenge.Data.Contracts
{
    public interface ISoldierService
    {
        List<TSoldier> GetAllSoldiersAsync();
        //TSoldier GetSoldierByIdAsync(int id);
    }
}
