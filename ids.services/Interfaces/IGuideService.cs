﻿using ids.core.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ids.services.Interfaces
{
    public interface IGuideService
    {
        IEnumerable<Guide> GetAllGuides();
        Guide GetGuideById(int id);
        void AddGuide(Guide guides);
        void UpdateGuide(Guide guides);
        void DeleteGuide(int id);
    }
}
