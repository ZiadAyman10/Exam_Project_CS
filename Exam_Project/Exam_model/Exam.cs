using Exam_Project.Answer_Model;
using Exam_Project.Questions;
using System;
using System.Collections.Generic;
using System.Net.Http.Headers;
using System.Text;

namespace Exam_Project.Exam_model
{
    public enum ExamMode
    {
        Starting, Queued, Finished
    }
    public abstract class Exam :ICloneable , IComparable<Exam>
    {

        #region prop
        public int Time { get; set; }
        public int NumberOfQuestions { get; set; }

        Question[] questions;
        public Question[] Questions { get { return questions; } }

        public Dictionary<Question, Answer> QuestionAnswerDictionary { get; set; }

        public Subject Subject { get; set; }

        public ExamMode Mode { get; set; }
        #endregion

        #region ctor

        protected Exam(int time, int numberOfQuestions, Question[] _questions,
                        Dictionary<Question, Answer> questionAnswerDictionary, Subject subject, ExamMode mode)
        {
            Time = time;
            NumberOfQuestions = numberOfQuestions;
            questions = _questions;
            QuestionAnswerDictionary = questionAnswerDictionary;
            Subject = subject;
            Mode = mode;
            if (questions is  null || QuestionAnswerDictionary is  null) throw new Exception("Invalid arguments to initialize Exam");

            if (questions is not null && QuestionAnswerDictionary is not null)
            {
                if (questions.Length != questionAnswerDictionary.Count|| questions.Length!=numberOfQuestions) throw new Exception("Invalid arguments to initialize Exam");
                Answer test;
                try
                {
                    foreach (Question question in questions)
                    {
                        test = questionAnswerDictionary[question];

                    }
                }
                catch (Exception)
                {

                    throw new Exception("Invalid arguments to initialize Exam");
                }
            }
        }
        #endregion

        #region Implement Interfaces
        public abstract object Clone();


        public int CompareTo(Exam? other)
        {
            if (other is null) return 1;
            if (this is null) return -1;
            if (this.Time == other.Time)
                return this.Questions.Length.CompareTo(other.Questions.Length);
            else
                return this.Time.CompareTo(other.Time);
        }
        #endregion

        public abstract void ShowExam();
        public virtual void Start()
        {
            if(Mode==ExamMode.Starting)
            this.Mode = ExamMode.Queued;
        }
        public virtual void Finish()
        {
            if (Mode != ExamMode.Finished)
                this.Mode = ExamMode.Finished;
        }

        //public void CorrectExam()
        //{

        //}
        private bool EqualsQuestions(Question[] ls)
        {
            for(int i = 0; i < NumberOfQuestions; i++)
            {
                if (!this.questions[i].Equals(ls[i]))
                {
                    return false;
                }
            }
                return true;
        }
        public override bool Equals(object? obj)
        {
            if((obj is Exam right) &&(obj is not null) && (this.GetType() == obj.GetType()))
            {
                if (Object.ReferenceEquals(this, obj)) return true;
                return Time==right.Time&&
                    NumberOfQuestions==right.NumberOfQuestions &&
                    this.Mode==right.Mode&&
                    this.Subject.Equals(right) &&
                    EqualsQuestions(right.questions);
            }
            return false;
        }

    }
}
