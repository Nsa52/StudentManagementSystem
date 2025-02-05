﻿using StudentManagementSystem.Enums;
using StudentManagementSystem.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StudentManagementSystem
{
    class Student : User
    {
        
        private float gpa;
        private Department department;
        private int startingYear;
        private int graduateYear;
        private List<Lecture> lectures;
        private Dictionary<Lecture, LetterGrades> grades = new Dictionary<Lecture, LetterGrades>();

        public Student(string fullName, string ID, string password, string email, Department department, int startingYear, int graduateYear, List<Lecture> lectures, Dictionary<Lecture, LetterGrades> grades, Gender gender, string nationality, DateTime dateOfBirth)
            : base(fullName, ID, password, email, gender, nationality, dateOfBirth)
        {

            this.fullName = fullName;
            this.ID = ID;
            this.password = password;
            this.email = email;
            this.department = department;
            this.startingYear = startingYear;
            this.graduateYear = graduateYear;
            this.lectures = lectures;
            this.grades = grades;
            this.gender = gender;
            this.nationality = nationality;
            this.dateOfBirth = dateOfBirth;
            CalculateGPA();

        }

        public Department Department
        {
            get { return department; }
            set { department = value; }
        }

        public float Gpa
        {
            get { return gpa; }
            set { gpa = value; }
        }

        public int StartingYear
        {
            get { return startingYear; }
            set { startingYear = value; }
        }

        public int GraduateYear
        {
            get { return graduateYear; }
            set { graduateYear = value; }
        }

        public List<Lecture> Lectures
        {
            get { return lectures; }
            set { lectures = value; }
        }

        public Dictionary<Lecture, LetterGrades> Grades
        {
            get { return grades; }
            set { grades = value; }
        }

        public override void ShowMyAcademicInfo()
        {
            Console.WriteLine("Department: " + department.Name);
            Console.WriteLine("Starting Year: " + startingYear);
            Console.WriteLine("Graduate Year (Approximately): " + (startingYear+4));
            Console.WriteLine("GPA: " + Gpa.ToString("0.##"));
            Console.WriteLine("--------------------------------------");
            for (int i = 0; i < lectures.Count; i++)
            {
                Console.WriteLine("Lecture ID: " + lectures[i].id + "   " + "Grade: " + grades[lectures[i]]);
            }
        }

        public void CalculateGPA()
        {
            float sum=0.00f;
            for (int i = 0; i < lectures.Count; i++)
            {
                switch (grades[lectures[i]])
                {
                    case LetterGrades.AA:
                        sum += 4.00f;
                        break;
                    case LetterGrades.BA:
                        sum += 3.50f;
                        break;
                    case LetterGrades.BB:
                        sum += 3.00f;
                        break;
                    case LetterGrades.CB:
                        sum += 2.50f;
                        break;
                    case LetterGrades.CC:
                        sum += 2.00f;
                        break;
                    case LetterGrades.DC:
                        sum += 1.50f;
                        break;
                    case LetterGrades.DD:
                        sum += 1.00f;
                        break;
                    case LetterGrades.FF:
                        sum += 0.00f;
                        break;
                    default:
                        break;
                }
            }
            gpa = sum / lectures.Count;
        }
    }
}
