using MOTHistory.Contracts.Repository;
using MOTHistory.Contracts.Services;
using MOTHistory.Models;
using System;

namespace MOTHistory.Services
{
    public class MOTService: IMOTService
    {
        private IMOTRepository _motRepository;
        public MOTService(IMOTRepository motRepository)
        {
            _motRepository = motRepository;
        }

        public VehicleDto Find(string regNumber)
        {
            return _motRepository.Find(regNumber);
        }
    }
}
