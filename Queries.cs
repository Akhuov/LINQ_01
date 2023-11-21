using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LINQ_003
{
    public class Queries
    {//ism familiya kontract
        public static void Run()
        {

            //var result = allStudent.OrderBy(x=>x.Id).ThenBy(x=>x.Contract);

            //foreach (var student in result)
            //{
            //    Console.WriteLine(student.Id + " " + student.FirstName+" "+student.LastName+student.Course + " " + student.Contract);
            //}


            //Console.WriteLine("\n\n\n");

            //var queryResult = from x in allStudent
            //                  orderby x.Id, x.Contract
            //                  select x;

            //foreach (var student in queryResult)
            //{
            //    Console.WriteLine(student.Id + " " + student.FirstName + " " + student.LastName + student.Course + " " + student.Contract);
            //}


            //var result = allStudent.OrderBy(x => x.FirstName)
            //                            .ThenByDescending(x=>x.Course)
            //                            .ThenBy(x=>x.Contract)
            //                            .ThenByDescending(x=>x.Age);

            //foreach (var student in result)
            //{
            //    Console.WriteLine(student.Id + " " + student.FirstName + " " + student.LastName + student.Course + " " + student.Contract);
            //}

            //Console.WriteLine("\n\n\n");

            //var queryResult = from x in allStudent
            //                  orderby x.FirstName
            //                    ,x.Course descending
            //                    ,x.Contract
            //                    ,x.Age descending
            //                  select x;

            //foreach (var student in queryResult)
            //{
            //    Console.WriteLine(student.Id + " " + student.FirstName + " " + student.LastName + student.Course + " " + student.Contract);
            //}

            //Console.WriteLine("\n\n\n");

            //var mixResult = (from x in allStudent
            //                orderby x.FirstName
            //                    ,x.Course descending
            //                select x)
            //                    .ThenBy(x=>x.Contract)
            //                    .ThenByDescending(x=>x.Age);

            //foreach (var student in mixResult)
            //{
            //    Console.WriteLine(student.Id + " " + student.FirstName + " " + student.LastName + student.Course + " " + student.Contract);
            //}

            //var result = allStudent.Average(x=>x.Contract);
            //Console.WriteLine($" Urtacha Contract {result}");

            //var list = new List<string>() { "asd","asd","asd","dsa","dsa"};
            //var result = list.Distinct();

            //foreach (var student in result)
            //{
            //    Console.WriteLine(student);
            //}

            var allStudents = Student.GetAllStudents();
            var allTeachers = Teacher.GetAllTeachers();


            //var result = allTeachers.GroupJoin(allStudents,
            //                            teacher => teacher.StudyType,//Tuple
            //                            student => student.StudyType,//Tuple
            //                            (teacher, students) => new
            //                            {
            //                                TeacherName = teacher.FirstName,
            //                                Students = students,
            //                                StudyType = teacher.StudyType
            //                            });

            //foreach (var teacher in result)
            //{
            //    Console.WriteLine($"{teacher.TeacherName} Talim shakli: {teacher.StudyType} =>");
            //    foreach (var student in teacher.Students)
            //    {
            //        Console.WriteLine($"{student.FirstName} {student.LastName} ({student.StudyType})");
            //    }
            //    Console.WriteLine();
            //}

            var result = from m in allStudents
                         join c in allTeachers
                         on new { Id = m.Id, SomeVal = m.Course }
                         equals new { Id = c.Id, SomeVal = c.TechCourse }
                         select new
                         {
                             Id = c.Id
                                    ,
                             TeacherName = c.TechCourse
                                    ,
                             StudentName = m.FirstName
                                    ,
                             Course = m.Course
                         };

            var result_2 = allStudents.Aggregate<Student,string,string>(
                                                        String.Empty,
                                                        (str, s) => str += s.FirstName + ",",
                                                        str => str.Substring(0, str.Length - 1));
            Console.WriteLine(result_2);

        }
    }
}
