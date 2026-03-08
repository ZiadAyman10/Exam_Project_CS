using Exam_Project.Answer_Model;
using Exam_Project.Exam_model;
using Exam_Project.Questions;

namespace Exam_Project
{
    
        internal class Program
        {
            static void Main(string[] args)
            {
               

                #region Create subject Math with students
                List<Student> students = new List<Student>()
            {
                new Student("Ziad",2),
                new Student("Ahmed",1),
                new Student("Ali",3)

            };
                Subject math = new Subject("Math", students);

                math.Enroll(new("khaled", 4));

            
                #endregion
                AnswerList ls = new AnswerList(
                 new List<Answer>(){
                            new(1, "1"),
                            new(2, "2"),
                            new(3, "3")
                             });

                Question[] questions =
                {
                new ChooseAllQuestion("Answer the following question", "1 + 1 =", 5, ls, new(2, "2")),
                new ChooseOneQuestion("Answer the following question", "2 + 1 =", 1, ls, new(3, "3")),
                new TrueFalseQuestion("Answer the following question", "3 - 2 ==1", 3, new(1, EAnswers.True.ToString()))
            };



                PracticeExam practiceExam = new PracticeExam(40, 3, questions, math);

                foreach (var student in practiceExam.Subject.EnrolledStudents)
                {
                    practiceExam.Notification += student.HandleExamStart;
                }

                practiceExam.Start();



                FinalExam final = new FinalExam(40, 3, questions, math);
                foreach (var student in final.Subject.EnrolledStudents)
                {
                    final.Notification += student.HandleExamStart;
                }
                final.Start();


    }

}
}
