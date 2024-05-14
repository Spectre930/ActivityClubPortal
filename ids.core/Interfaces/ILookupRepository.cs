using ids.core.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ids.core.Interfaces
{
    public interface ILookupRepository
    {
        IEnumerable<Lookup> GetAllLookups();
        Lookup GetLookupById(int id);
        void AddLookup(Lookup lookup);
        void UpdateLookup(Lookup lookup);
        void DeleteLookup(int id);
    }
}
