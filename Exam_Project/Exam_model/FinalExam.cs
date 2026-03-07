using Exam_Project.Answer_Model;
using Exam_Project.Questions;
using System;
using System.Collections.Generic;
using System.Text;

namespace Exam_Project.Exam_model
{
    public class FinalExam : Exam
    {
        public FinalExam(int time, int numberOfQuestions, Question[] _questions,
                        Dictionary<Question, Answer> questionAnswerDictionary, Subject subject, ExamMode mode = ExamMode.Queued)
            : base(time, numberOfQuestions, _questions, subject, mode)
        {

        }
        public FinalExam(FinalExam pe) : base(pe.Time, pe.NumberOfQuestions, pe.Questions, pe.Subject, pe.Mode)
        {

        }
        public override object Clone()
        {
            return new FinalExam(this);
        }
        public override void ShowExam()
        {
            Console.WriteLine(" this is a Final Exam ");
            Console.WriteLine("========================");
            for (int i = 0; i < NumberOfQuestions; i++)
            {
                Console.WriteLine($"Q.{i + 1} " + Questions[i]);

            }
        }
        public void Questions_studentAnswers()
        {
            int counter = 1;
            foreach (var item in this.QuestionAnswerDictionary)
            {
                if (item.Value is null) Console.WriteLine($"Q.{counter}. {item.Key.Body}  : NA");
                else Console.WriteLine($"Q.{counter}. {item.Key.Body}  :{item.Value.Text}");
                counter++;
            }
        }
        public override void Start()
        {
            base.Start();
            ShowExam();
            string answer;
            bool flag = false;
            for (int i = 0; i < Questions.Length; i++)
            {
                Console.Write($"Enter your answer for Q{i + 1}. ");
                do
                {
                    answer = Console.ReadLine();

                } while (answer is null);
                Console.WriteLine("");
                foreach (var item in Questions[i].Answers.Answers)
                {
                    if (answer == item.Text)
                    {
                        QuestionAnswerDictionary[Questions[i]] = item;
                        flag = true;
                    }

                }
                if (!flag)
                {
                    Console.WriteLine("invalid answer not included the choices ");
                    i--;
                }
                flag = false;
            }
            Console.WriteLine("Did you finish Y/N :");
            if (Console.ReadLine().ToUpper() == "Y")
            {
                Finish();
            }
            else Start();


        }
        public override void Finish()
        {
            base.Finish();
            int choice;
            base.Finish();


            bool flag = true;
            do
            {
                Console.WriteLine("");
                Console.WriteLine("--------------------------");
                Console.WriteLine("1. Show Exam Again with your answers");
                Console.WriteLine("2. Exit ");
                Console.WriteLine("--------------------------");
                do
                {
                    Console.Write("Enter a number :");
                } while (!int.TryParse(Console.ReadLine(), out choice));

                switch (choice)
                {

                    case 1:
                        Questions_studentAnswers();
                        break;
                    case 2:
                        flag = false;
                        break;
                    default:
                        Console.WriteLine("Invalid input");
                        break;
                }
            } while (flag);
        
    }
    }
}
