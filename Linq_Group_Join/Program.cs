using System;
using System.Collections.Generic;
using System.Linq;

class Student
{
    public int StudentId { get; set; }
    public string StudentName { get; set; }
    public int ClassId { get; set; }
}

class Class
{
    public int ClassId { get; set; }
    public string ClassName { get; set; }
}

class Program
{
    static void Main()
    {
        // Öğrenciler için örnek veriler
        List<Student> students = new List<Student>
        {
            new Student { StudentId = 1, StudentName = "Ahmet", ClassId = 1 },
            new Student { StudentId = 2, StudentName = "Mehmet", ClassId = 2 },
            new Student { StudentId = 3, StudentName = "Ayşe", ClassId = 1 },
            new Student { StudentId = 4, StudentName = "Zeynep", ClassId = 3 },
            new Student { StudentId = 5, StudentName = "Ali", ClassId = 2 },
            new Student { StudentId = 6, StudentName = "Fatma", ClassId = 3 }
        };

        // Sınıflar için örnek veriler
        List<Class> classes = new List<Class>
        {
            new Class { ClassId = 1, ClassName = "Matematik" },
            new Class { ClassId = 2, ClassName = "Fizik" },
            new Class { ClassId = 3, ClassName = "Kimya" }
        };

        // Group Join işlemi ile öğrencileri sınıflara göre grupluyoruz
        var classStudentQuery = from classInfo in classes
                                join student in students on classInfo.ClassId equals student.ClassId into studentGroup
                                select new
                                {
                                    ClassName = classInfo.ClassName,
                                    Students = studentGroup.Select(s => s.StudentName)
                                };

        // Sonuçları yazdırıyoruz
        Console.WriteLine("Sınıflar ve Öğrenciler:");
        foreach (var item in classStudentQuery)
        {
            Console.WriteLine($"Sınıf: {item.ClassName}");
            foreach (var studentName in item.Students)
            {
                Console.WriteLine($"  - {studentName}");
            }
            Console.WriteLine();
        }

        // Programın sonlandırılması
        Console.WriteLine("Program sonlandırılıyor...");
    }
}

