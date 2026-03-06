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
                        Dictionary<Question, Answer> questionAnswerDictionary, Subject subject, ExamMode mode)
            : base(time, numberOfQuestions, _questions, questionAnswerDictionary, subject, mode)
        {

        }
        public FinalExam(FinalExam pe) : base(pe.Time, pe.NumberOfQuestions, pe.Questions, pe.QuestionAnswerDictionary, pe.Subject, pe.Mode)
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
                //for (int j = 0; j < this.Questions[i].Answers.Answers.Count; j++)
                //{
                //    Console.WriteLine($"{j + 1}. {Questions[i].Answers.Answers[j]}");
                //}
            }
        }
        public void questions_studentAnswers()
        {
            int counter = 1;
            foreach (var item in this.QuestionAnswerDictionary)
            {
                Console.WriteLine($"{counter}. {item.Key.Body}  :{item.Value.Text}");
            }
        }
    }
}
