using System;
using System.Collections.Generic;
using System.Linq;

namespace MOTHistory.Models
{
    public class VehicleDto
    {
        public string Registration { get; set; }
        public string Make { get; set; }
        public string Model { get; set; }
        public string FirstUsedDate { get; set; }
        public string FuelType { get; set; }
        public string PrimaryColour { get; set; }
        public IEnumerable<MOTTestDto> MotTests { get; set; }

        public override string ToString()
        {
            var currentTest = this.MotTests?.OrderByDescending(t => t.CompletedDate).FirstOrDefault();
            var motDetails = currentTest?.ToString() ?? $"No MOT data found.";
            return
                "\nVehicle Details \n" +
                "Registration: " + this.Registration + "\n" +
                "Make: " + this.Make + "\n" +
                "Model: " + this.Model + "\n" +
                "Colour: " + this.PrimaryColour + "\n" +
                "\nCurrent MOT Details \n" +
                motDetails;
        }
    }
}
