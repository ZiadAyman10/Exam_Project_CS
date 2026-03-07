using Exam_Project.Answer_Model;
using Exam_Project.Exam_model;
using Exam_Project.Questions;

namespace Testing
{
    internal class Program
    {
        static void Main(string[] args)
        {
            #region old TEST
            //AnswerList ls = new AnswerList(new List<Answer>() { new(1, "maybe"), new(2, "ofc not"), new(3, "ofc yes") });
            //ChooseAllQuestion q1 = new("c++ ", "c++ is a good language ?",
            //    10, ls, new(-1, "All"));
            //Console.WriteLine(q1);
            ////foreach (var answer in q1.Answers) {
            ////    Console.WriteLine(answer);
            ////}
            ////Console.WriteLine(q1.CheckAnswer(new(-1, "s")));  
            #endregion

            //QuestionList ls = new("test");
            //ls.Add(new TrueFalseQuestion("c++","int is value type?",10,new Answer(1, EAnswers.True.ToString())));

            #region Create subject Math with students
            List<Student> students = new List<Student>()
            {
                new Student("Ziad",2),
                new Student("Ahmed",1),
                new Student("Ali",3)

            };
            Subject math = new Subject("Math", students);

            math.Enroll(new("khaled", 4));

            foreach (var st in math.EnrolledStudents)
            {
                Console.WriteLine(st);
            }
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

            Dictionary<Question, Answer> dictionary = new Dictionary<Question, Answer>();
            foreach (var question in questions)
            {
                dictionary[question] = null;
            }

            //PracticeExam practiceExam = new PracticeExam(40, 3, questions, dictionary, math);


            //practiceExam.Start();



            FinalExam final = new FinalExam(40, 3, questions, dictionary, math, ExamMode.Starting);
            final.Start();


        }
    }
}
