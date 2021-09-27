using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace GradeBook.GradeBooks
{
    public class RankedGradeBook : BaseGradeBook
    {
        public RankedGradeBook(string name) : base(name)
        {
            Type = Enums.GradeBookType.Ranked;
        }
        public override char GetLetterGrade(double averageGrade)
        {
            if (Students.Count < 5)
            {
                throw new InvalidOperationException();
            }

            var gradedStudent = Students
                .Where(x => x.AverageGrade <= averageGrade)
                .OrderByDescending(x => x.AverageGrade)
                .FirstOrDefault();

            var indexOfGradedStudent = Students
                .OrderByDescending(x => x.AverageGrade)
                .ToList()
                .IndexOf(gradedStudent);

            var countOfStudents = Students.Count();

            decimal gradePercentage = ((indexOfGradedStudent + 1) / (decimal)countOfStudents) * 100;

            if (gradePercentage <= 20)
            {
                return 'A';
            }
            else if (gradePercentage <= 40 && gradePercentage > 20)
            {
                return 'B';
            }
            else if (gradePercentage <= 60 && gradePercentage > 40)
            {
                return 'C';
            }
            else if (gradePercentage <= 80 && gradePercentage > 60)
            {
                return 'D';
            }

            return 'F';
        }
    }
}
