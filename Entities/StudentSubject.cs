using System;
namespace JambRegistrationMVC.Entities
{
    public class StudentSubject
    {
        public int ID{get; set;}
        public int StudentID{get; set;}
        public Student Student{get; set;}
        public int SubjectID{get; set;}
        public Subject Subject{get; set;}
    }
}