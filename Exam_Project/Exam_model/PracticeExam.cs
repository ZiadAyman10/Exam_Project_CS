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
        public PracticeExam(int time, int numberOfQuestions, Question[] _questions,
                        Dictionary<Question, Answer> questionAnswerDictionary, Subject subject, ExamMode mode)
            : base(time, numberOfQuestions, _questions, questionAnswerDictionary, subject, mode)
        {

        }
        public PracticeExam(PracticeExam pe) : base(pe.Time, pe.NumberOfQuestions, pe.Questions, pe.QuestionAnswerDictionary, pe.Subject, pe.Mode)
        {

        }
        public override object Clone()
        {
            return new PracticeExam(this);
        }

        public override void ShowExam()
        {
            Console.WriteLine(" this is a subject Exam ");
            Console.WriteLine("========================");
            for (int i = 0; i < NumberOfQuestions; i++)
            {
                Console.WriteLine($"Q.{i + 1} " + Questions[i]);
                //for (int j = 0; j < this.Questions[i].Answers.Answers.Count; j++)
                //{
                //    Console.WriteLine($"{j + 1}. {Questions[i].Answers.Answers[j]}");
                //}
            }
        }
        public void Show_student_answers()
        {
            int counter = 1;
            foreach (var item in this.QuestionAnswerDictionary)
            {
                Console.WriteLine($"{counter}. {item.Value.Text}");
            }
        }
        public void Show_correct_answers()
        {
            for (int i = 0; i < this.Questions.Length; i++)
            {
                if (this.QuestionAnswerDictionary[Questions[i]].Equals(Questions[i].CorrectAnswer))
                {
                    Console.WriteLine($"Q.{Questions[i]} : {Questions[i].CorrectAnswer}");
                }

            }
        }
        public void Show_final_grade()
        {
            int total=0 , correct=0;
           
            for (int i = 0; i < this.Questions.Length; i++)
            {
                total += Questions[i].Marks;
                if (this.QuestionAnswerDictionary[Questions[i]].Equals(Questions[i].CorrectAnswer))
                {
                    correct += Questions[i].Marks;
                }

            }
            Console.WriteLine($"Grade ={correct/(float)total}");

        }
    }
}
