using System;
using System.Collections.Generic;
using System.Linq;

public class Student : IComparable<Student>, ICloneable
{
    private string lastName;
    private string firstName;
    private string middleName;
    private DateTime birthDate;
    private string homeAddress;
    private string phoneNumber;

    private List<int> homeworkGrades;
    private List<int> courseGrades;
    private List<int> examGrades;

    public Student(string lastName, string firstName, string middleName, DateTime birthDate, string homeAddress, string phoneNumber)
    {
        this.lastName = lastName;
        this.firstName = firstName;
        this.middleName = middleName;
        this.birthDate = birthDate;
        this.homeAddress = homeAddress;
        this.phoneNumber = phoneNumber;
        this.homeworkGrades = new List<int>();
        this.courseGrades = new List<int>();
        this.examGrades = new List<int>();
    }

    public List<int> HomeworkGrades => homeworkGrades;
    public List<int> CourseGrades => courseGrades;
    public List<int> ExamGrades => examGrades;

    public int CompareTo(Student other)
    {
        if (other == null) return 1;
        return this.GetAverageGrade().CompareTo(other.GetAverageGrade());
    }
    public object Clone()
    {
        return new Student(lastName, firstName, middleName, birthDate, homeAddress, phoneNumber)
        {
            homeworkGrades = new List<int>(this.homeworkGrades),
            courseGrades = new List<int>(this.courseGrades),
            examGrades = new List<int>(this.examGrades)
        };
    }

    public double GetAverageGrade()
    {
        var allGrades = homeworkGrades.Concat(courseGrades).Concat(examGrades).ToList();
        return allGrades.Count > 0 ? allGrades.Average() : 0;
    }

    public void DisplayStudentInfo()
    {
        Console.WriteLine($"Фамилия: {lastName}, Имя: {firstName}, Отчество: {middleName}");
        Console.WriteLine($"Средний балл: {GetAverageGrade()}");
    }
}
public class Group : IComparable<Group>, ICloneable
{
    private List<Student> students;

    public Group(List<Student> students)
    {
        this.students = students;
    }
    public int CompareTo(Group other)
    {
        if (other == null) return 1;
        return this.students.Count.CompareTo(other.students.Count);
    }
    public object Clone()
    {
        return new Group(new List<Student>(this.students.Select(s => (Student)s.Clone())));
    }
}
public class Program
{
    public static void Main(string[] args)
    {
        Console.ForegroundColor = ConsoleColor.DarkRed;
        Console.WriteLine("|♥♥♥♥♥♥♥♥♥♥♥♥♥♥♥♥♥♥♥♥♥♥♥♥♥♥♥♥♥♥♥♥♥♥♥♥♥♥♥♥♥♥♥♥♥♥♥♥♥♥♥♥♥♥♥♥♥♥♥|");
        Student student1 = new Student("Демидов", "Артур", "Иванович", new DateTime(2004, 3, 15), "ул Преображенская 4", "380-97-39-55-211");
        Student student2 = new Student("Черенков", "Петр", "Архипович", new DateTime(1999, 4, 11), "ул Гвардейская 11а", "380-66-53-22-423");
        Student student3 = new Student("Джульпаев", "Равшан", "Суренович", new DateTime(2001, 3, 3), "ул Генеузька 12/2", "380-63-11-55-123");
        student1.HomeworkGrades.Add(5);
        student1.CourseGrades.Add(4);
        student1.ExamGrades.Add(5);

        student2.HomeworkGrades.Add(3);
        student2.CourseGrades.Add(3);
        student2.ExamGrades.Add(4);

        student3.HomeworkGrades.Add(4);
        student3.CourseGrades.Add(4);
        student3.ExamGrades.Add(3);

        Student[] students = { student1, student2, student3 };

        Array.Sort(students);
        foreach (var student in students)
        {
            student.DisplayStudentInfo();
        }
        Console.WriteLine("|♥♥♥♥♥♥♥♥♥♥♥♥♥♥♥♥♥♥♥♥♥♥♥♥♥♥♥♥♥♥♥♥♥♥♥♥♥♥♥♥♥♥♥♥♥♥♥♥♥♥♥♥♥♥♥♥♥♥♥|");
        Console.ForegroundColor = ConsoleColor.DarkGray;
    }
}
