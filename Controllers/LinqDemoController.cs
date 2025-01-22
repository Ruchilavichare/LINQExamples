using LinqDemoApp.Data;
using LinqDemoApp.Models;
using Microsoft.AspNetCore.Mvc;
using System.Linq;

namespace LinqDemoApp.Controllers
{
    public class LinqDemoController : Controller
    {
        private readonly ApplicationDbContext _context;

        public LinqDemoController(ApplicationDbContext context)
        {
            _context = context;
        }

        public IActionResult Index()
        {
            // Sample data (In-memory LINQ operations)
            var students = _context.Students.ToList();

            // Filtering Methods
            var filteredByAge = students.Where(s => s.Age > 20).ToList();
            var firstStudent = students.FirstOrDefault();
            var singleStudent = students.SingleOrDefault(s => s.Name == "John Doe");
            var lastStudent = students.LastOrDefault();

            // Sorting Methods
            var sortedByNameAsc = students.OrderBy(s => s.Name).ToList();
            var sortedByNameDesc = students.OrderByDescending(s => s.Name).ToList();
            var thenByGrade = students.OrderBy(s => s.Age).ThenBy(s => s.Grade).ToList();

            // Projection Methods
            var selectNames = students.Select(s => new { s.Name, s.Age }).ToList();
            var selectAnonymousType = students.Select(s => new { StudentName = s.Name, StudentAge = s.Age }).ToList();

            // Aggregation Methods
            var totalStudents = students.Count();
            var averageGrade = students.Average(s => s.Grade);
            var maxGrade = students.Max(s => s.Grade);
            var minGrade = students.Min(s => s.Grade);
            var sumOfAges = students.Sum(s => s.Age);

            // Set Operations
            var distinctCourses = students.Select(s => s.Course).Distinct().ToList();
            var uniqueAges = students.Select(s => s.Age).Distinct().ToList();

            // Grouping
            var groupedByCourse = students.GroupBy(s => s.Course)
                                          .Select(g => new { Course = g.Key, Count = g.Count() })
                                          .ToList();

            // Joining (assuming another model for Courses exists)
            var studentCourseJoin = from student in _context.Students
                                    join course in _context.Students // Example, use proper course model
                                    on student.Course equals course.Course
                                    select new { student.Name, student.Course };

            // Partitioning Methods
            var skipTwo = students.Skip(2).ToList();
            var takeTwo = students.Take(2).ToList();
            var skipWhileYoung = students.SkipWhile(s => s.Age < 21).ToList();
            var takeWhileOld = students.TakeWhile(s => s.Age > 21).ToList();

            // Quantifier Methods
            var anyAbove20 = students.Any(s => s.Age > 20);
            var allPassing = students.All(s => s.Grade >= 50);
            var containsStudent = students.Contains(firstStudent);

            // Conversion Methods
            var studentDictionary = students.ToDictionary(s => s.Id);
            var studentList = students.ToList();
            var studentArray = students.ToArray();
            var studentLookup = students.ToLookup(s => s.Course);

            // Element Methods
            var firstWithCondition = students.FirstOrDefault(s => s.Age > 20);
            var elementAtIndex = students.ElementAtOrDefault(1);

            var linqResults = new
            {
                FilteredByAge = filteredByAge,
                FirstStudent = firstStudent,
                SingleStudent = singleStudent,
                LastStudent = lastStudent,
                SortedAsc = sortedByNameAsc,
                SortedDesc = sortedByNameDesc,
                ThenByGrade = thenByGrade,
                SelectNames = selectNames,
                SelectAnonymous = selectAnonymousType,
                TotalStudents = totalStudents,
                AverageGrade = averageGrade,
                MaxGrade = maxGrade,
                MinGrade = minGrade,
                SumOfAges = sumOfAges,
                DistinctCourses = distinctCourses,
                UniqueAges = uniqueAges,
                GroupedByCourse = groupedByCourse,
                SkipTwo = skipTwo,
                TakeTwo = takeTwo,
                SkipWhileYoung = skipWhileYoung,
                TakeWhileOld = takeWhileOld,
                AnyAbove20 = anyAbove20,
                AllPassing = allPassing,
                ContainsStudent = containsStudent,
                StudentDictionary = studentDictionary,
                StudentList = studentList,
                StudentArray = studentArray,
                StudentLookup = studentLookup,
                FirstWithCondition = firstWithCondition,
                ElementAtIndex = elementAtIndex
            };

            return View(linqResults);
        }
    }
}
