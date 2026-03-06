using System;
using System.Collections.Generic;
using System.Text;

namespace Exam_Project.Exam_model
{
    public class Subject
    {
        public string Name { get; set; }

        List <Student>  enrolledStudents;

        public Subject(string name, List<Student> enrolledStudents)
        {
            Name = name;
            this.enrolledStudents = enrolledStudents;
        }

        public List<Student> EnrolledStudents { get { return enrolledStudents; }  }

        public void Enroll(Student student)
        {
            enrolledStudents.Add(student);
        }
        public override bool Equals(object? obj)
        {
            if((obj is Subject sub)&& (obj is not null)&& (obj.GetType() == this.GetType()))
            {
                if (object.ReferenceEquals(this, obj) )return true;
                if(sub.Name==this.Name && checkEnrolledStudents(sub.enrolledStudents)) return true;
            }
            return false;
        }

        private bool checkEnrolledStudents(List<Student> _enrolledStudents)
        {
            if(_enrolledStudents is not null && this.enrolledStudents is not null && this.enrolledStudents.Count== _enrolledStudents.Count)
            {
                for (int i = 0; i < enrolledStudents.Count; i++)
                {
                    if(!enrolledStudents[i].Equals(_enrolledStudents[i]))
                        return false;
                }
                return true;
            }
            return false;
        }
        
    }
}
