using Exam_Project.Answer_Model;
using Exam_Project.Questions;
using System;
using System.Collections.Generic;
using System.Text;
using System.Timers;

namespace Exam_Project.Exam_model
{
    public class PracticeExam : Exam
    {
        public PracticeExam(int time, int numberOfQuestions, Question[] _questions
                        , Subject subject, ExamMode mode = ExamMode.Queued)
            : base(time, numberOfQuestions, _questions, subject, mode)
        {
           
        }
        public PracticeExam(PracticeExam pe) : base(pe.Time, pe.NumberOfQuestions, pe.Questions, pe.Subject, pe.Mode)
        {

        }
        public override object Clone()
        {
            return new PracticeExam(this);
        }

        public override void ShowExam()
        {
            if (this.Mode == ExamMode.Queued)
            {
                Console.WriteLine("You didn't start the exam yet");
                return;
            }
            Console.WriteLine(" this is a subject Exam ");
            Console.WriteLine("========================");
            for (int i = 0; i < NumberOfQuestions; i++)
            {
                Console.WriteLine($"Q.{i + 1} " + Questions[i]);

            }
        }
        public void Show_student_answers()
        {
            if (this.Mode == ExamMode.Queued)
            {
                Console.WriteLine("You didn't start the exam yet");
                return;
            }

            int counter = 1;
            foreach (var item in this.QuestionAnswerDictionary)
            {
                if (item.Value is null) Console.WriteLine($"{counter}. NA ");
                else
                    Console.WriteLine($"{counter}. {item.Value.Text}");
                counter++;
            }
        }
        public void Show_correct_answers()
        {
            if (this.Mode != ExamMode.Finished)
            {
                Console.WriteLine("You didn't finish the exam yet");
                return;
            }
            int counter = 1;
            foreach (var item in this.QuestionAnswerDictionary)
            {
                Console.WriteLine($"Q.{counter}: {item.Key.CorrectAnswer}");
                counter++;
            }

        }
        public void Show_final_grade()
        {
            if (this.Mode != ExamMode.Finished)
            {
                Console.WriteLine("You didn't finish the exam yet");
                return;
            }
            int total = 0, correct = 0;

            for (int i = 0; i < this.Questions.Length; i++)
            {
                total += Questions[i].Marks;
                if (this.QuestionAnswerDictionary[Questions[i]]?.Equals(Questions[i].CorrectAnswer) ?? false)
                {
                    correct += Questions[i].Marks;
                }

            }
            Console.WriteLine($"Grade ={(correct / (float)total) * 100} %");

        }

        public override void Start()
        {
            base.Start();
            TriggerEvent();
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
            int choice;
            base.Finish();


            bool flag = true;
            do
            {
                Console.WriteLine("");
                Console.WriteLine("--------------------------");
                Console.WriteLine("1. Show Correct Answers ");
                Console.WriteLine("2. Show Final Grade ");
                Console.WriteLine("3. Show My Answers ");
                Console.WriteLine("4. Exit ");
                Console.WriteLine("--------------------------");
                do
                {
                    Console.Write("Enter a number :");
                } while (!int.TryParse(Console.ReadLine(), out choice));

                switch (choice)
                {

                    case 1:
                        Show_correct_answers();
                        break;
                    case 2:
                        Show_final_grade();
                        break;
                    case 3:
                        Show_student_answers();
                        break;
                    case 4:
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
