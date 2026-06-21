using System;
using System.Collections.Generic;

namespace StudentManagementSystem
{
    class Program
    {
        static void Main(string[] args)
        {
            StudentManager manager = new StudentManager();
            manager.Run();
        }
    }

    class StudentManager
    {
        private List<string> studentNames;
        private List<int[]> studentGrades;

        public StudentManager()
        {
            studentNames = new List<string>();
            studentGrades = new List<int[]>();
        }

        public void Run()
        {
            bool running = true;

            while (running)
            {
                Console.WriteLine("===== STUDENT SYSTEM =====");
                Console.WriteLine("1. Add Student");
                Console.WriteLine("2. View All Students");
                Console.WriteLine("3. Compute Class Average");
                Console.WriteLine("4. Find Highest Grade");
                Console.WriteLine("5. Exit");
                Console.Write("Choose an option: ");

                string choice = Console.ReadLine();

                switch (choice)
                {
                    case "1":
                        AddStudent();
                        break;

                    case "2":
                        ViewStudents();
                        break;

                    case "3":
                        ComputeClassAverage();
                        break;

                    case "4":
                        FindHighestGrade();
                        break;

                    case "5":
                        Console.WriteLine("Goodbye!");
                        running = false;
                        break;

                    default:
                        Console.WriteLine("Invalid option.");
                        break;
                }

                Console.WriteLine();
            }
        }

        public void AddStudent()
        {
            Console.Write("Enter student name: ");
            string name = Console.ReadLine();

            Console.Write("Enter grade 1: ");
            int grade1 = int.Parse(Console.ReadLine());

            Console.Write("Enter grade 2: ");
            int grade2 = int.Parse(Console.ReadLine());

            Console.Write("Enter grade 3: ");
            int grade3 = int.Parse(Console.ReadLine());

            studentNames.Add(name);
            studentGrades.Add(new int[] { grade1, grade2, grade3 });

            Console.WriteLine("Student added successfully!");
        }

        public void ViewStudents()
        {
            if (studentNames.Count == 0)
            {
                Console.WriteLine("No students found.");
                return;
            }

            for (int i = 0; i < studentNames.Count; i++)
            {
                int[] grades = studentGrades[i];
                double average = (grades[0] + grades[1] + grades[2]) / 3.0;

                Console.WriteLine("Name: " + studentNames[i]);
                Console.WriteLine("Grades: " + grades[0] + ", " + grades[1] + ", " + grades[2]);
                Console.WriteLine("Average: " + average.ToString("F2"));
                Console.WriteLine();
            }
        }

        public void ComputeClassAverage()
        {
            if (studentNames.Count == 0)
            {
                Console.WriteLine("No students found.");
                return;
            }

            double totalAverage = 0;

            for (int i = 0; i < studentGrades.Count; i++)
            {
                int[] grades = studentGrades[i];
                totalAverage += (grades[0] + grades[1] + grades[2]) / 3.0;
            }

            double classAverage = totalAverage / studentNames.Count;

            Console.WriteLine("Overall Average Grade: " + classAverage.ToString("F2"));
        }

        public void FindHighestGrade()
        {
            if (studentNames.Count == 0)
            {
                Console.WriteLine("No students found.");
                return;
            }

            int highestGrade = -1;
            string topStudent = "";

            for (int i = 0; i < studentGrades.Count; i++)
            {
                foreach (int grade in studentGrades[i])
                {
                    if (grade > highestGrade)
                    {
                        highestGrade = grade;
                        topStudent = studentNames[i];
                    }
                }
            }

            Console.WriteLine("Top Student: " + topStudent);
            Console.WriteLine("Highest Grade: " + highestGrade);
        }
    }
}