using ids.core.Interfaces;
using ids.core.Models;
using ids.services.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ids.services
{
    public class LookupService : ILookupService
    {
        private readonly ILookupRepository _lookupRepository;

        public LookupService(ILookupRepository lookupRepository)
        {
            _lookupRepository = lookupRepository;
        }

        public IEnumerable<Lookup> GetAllLookups()
        {
            return _lookupRepository.GetAllLookups();
        }

        public Lookup GetLookupById(int id)
        {
            return _lookupRepository.GetLookupById(id);
        }

        public void AddLookup(Lookup lookup)
        {
            if (ValidateProduct(lookup))
            {
                _lookupRepository.AddLookup(lookup);
            }
            else
            {
                throw new ArgumentException("Invalid lookup data");
            }
        }

        public void UpdateLookup(Lookup lookup)
        {
            if (ValidateProduct(lookup))
            {
                _lookupRepository.UpdateLookup(lookup);
            }
            else
            {
                throw new ArgumentException("Invalid lookup data");
            }
        }

        public void DeleteLookup(int id)
        {
            _lookupRepository.DeleteLookup(id);
        }
        private bool ValidateProduct(Lookup lookup)
        {
            // Perform validation logic here
            // For example, check if required fields are set and if the price is valid

            if (string.IsNullOrWhiteSpace(lookup.Name))
            {
                return false;
            }

            return true;
        }
    }
}
