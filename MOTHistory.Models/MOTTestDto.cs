using System;
using System.Collections.Generic;
using System.Text;

namespace MOTHistory.Models
{
    public class MOTTestDto
    {
        public string CompletedDate { get; set; }
        public string TestResult { get; set; }
        public string ExpiryDate { get; set; }
        public int OdometerValue { get; set; }
        public string OdometerUnit { get; set; }
        public string MotTestNumber { get; set; }
        public IEnumerable<RFRAndCommentsDto> RFRAndComments { get; set; }

        public override string ToString()
        {
            return                
                "Expiry/Renewal Date: " + Convert.ToDateTime(this.ExpiryDate).ToShortDateString() + "\n" +
                "Mileage: " + this.OdometerValue + " " + this.OdometerUnit + "\n" +
                "Days until Renewal: " + (Convert.ToDateTime(this.ExpiryDate) - DateTime.Now).Days.ToString() + " days \n";
        }
    }
}
