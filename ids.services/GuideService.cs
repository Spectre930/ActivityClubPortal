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
    public class GuideService : IGuideService
    {
        private readonly IGuideRepository _guideRepository;

        public GuideService(IGuideRepository guideRepository)
        {
            _guideRepository = guideRepository;
        }

        public IEnumerable<Guide> GetAllGuides()
        {
            return _guideRepository.GetAllGuides();
        }

        public Guide GetGuideById(int id)
        {
            return _guideRepository.GetGuideById(id);
        }

        public void AddGuide(Guide guides)
        {
            if (ValidateProduct(guides))
            {
                _guideRepository.AddGuide(guides);
            }
            else
            {
                throw new ArgumentException("Invalid guide data");
            }
        }

        public void UpdateGuide(Guide guides)
        {
            if (ValidateProduct(guides))
            {
                _guideRepository.UpdateGuide(guides);
            }
            else
            {
                throw new ArgumentException("Invalid guide data");
            }
        }

        public void DeleteGuide(int id)
        {
            _guideRepository.DeleteGuide(id);
        }
        private bool ValidateProduct(Guide guides)
        {
            // Perform validation logic here
            // For example, check if required fields are set and if the price is valid

            if (string.IsNullOrWhiteSpace(guides.FullName))
            {
                return false;
            }

            return true;
        }
    }
}
