using Exam_Project.Answer_Model;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Text;

namespace Exam_Project.Questions
{
    public abstract class Question
    {
        #region prop
        string header;

        string body;

        int marks;

        //List<Answer> answers;
        AnswerList answers;
        Answer correctAnswer;


        public string Header { get => header; set => header = value; }
        public string Body { get => body; set => body = value; }
        public int Marks { get => marks; set => marks = value; }
        public AnswerList Answers
        {
            get { 
                return new AnswerList(answers);
            }
        }

        public Answer CorrectAnswer { get => correctAnswer; set => correctAnswer = value; }
        #endregion

        protected Question(string _header, string _body, int _marks, AnswerList _answers, Answer _correctAnswer)
        {
            header = (_header is null) ? "NA" : _header;
            body = (_body is null) ? "NA" : _body;

            if (_marks > 0)
                this.marks = _marks;
            else this.marks = 0; //not valid 

            answers =new( _answers);

            if (_correctAnswer is not null)
            {
                correctAnswer = new(_correctAnswer);
            }
            else
            {
                throw new NullReferenceException("you are trying to assign null to correct answer");
            }
        }

        public abstract void Display();

        public abstract bool CheckAnswer(Answer studentAnswer);

        public override string ToString() // without answer
        {
                int counter = 1;
            StringBuilder stringBuilder = new StringBuilder();
            stringBuilder.AppendLine();
            stringBuilder.AppendLine( this.body);
            if (answers is not null)
                foreach (var answer in answers.Answers)
                {
                    stringBuilder.AppendLine($"{counter++}. {answer.Text}");
                }
            return $" Header : {this.header} , Marks: {this.marks} points  {stringBuilder}";
        }
        public override bool Equals(object? obj)
        {

            if (obj is Question q2)
            {
                if (object.ReferenceEquals(this, q2)) return true;

                return this.header.Equals(q2.header) &&
                    this.body.Equals(q2.body) &&
                    this.correctAnswer.Equals(q2.correctAnswer) &&
                    this.marks.Equals(q2.marks) &&
                    this.answers.Equals(q2.answers);

            }
            return false;
        }

        public override int GetHashCode()
        {
            return HashCode.Combine(header,this.marks,this.answers,this.Marks,this.body,this.correctAnswer);
        }

        public void AddAnswer(Answer answer)
        {
            answers.Add(answer);   // now works because Add is void
        }
    }
}
