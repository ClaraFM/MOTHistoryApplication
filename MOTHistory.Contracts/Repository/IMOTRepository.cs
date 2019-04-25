using MOTHistory.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace MOTHistory.Contracts.Repository
{
    public interface IMOTRepository
    {
        VehicleDto Find(string regNumber);
    }
}
