using MOTHistory.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace MOTHistory.Contracts.Services
{
    public interface IMOTService
    {
        VehicleDto Find(string regNumber);
    }
}
