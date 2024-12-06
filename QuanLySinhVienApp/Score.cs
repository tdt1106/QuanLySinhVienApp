using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QuanLySinhVienApp
{
    public class Score
    {
        public Subject Subject { get; set; }
        public double PointsAchieved { get; set; } // điểm đạt được
        public int NumberOfCredits { get; set; }

        public Score(Subject subject, double pointsAchieved, int numberOfCredits) {
            Subject = subject;
            PointsAchieved = pointsAchieved;
            NumberOfCredits = numberOfCredits;
        }
    }
}
