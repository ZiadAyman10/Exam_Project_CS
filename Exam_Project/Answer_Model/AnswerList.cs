using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Text;

namespace Exam_Project.Answer_Model
{
    public class AnswerList
    {
        #region prop
        protected List<Answer> answers;
        public List<Answer> Answers
        {
            get
            {
                List<Answer> answersLs = new List<Answer>();
                if (answers != null)
                    foreach (var item in answers)
                    {
                        answersLs.Add(new(item));
                    }
                return answersLs;
            }
        }
        #endregion

        #region Ctor
        public AnswerList(List<Answer> _answers)
        {
            answers = new List<Answer>();
            if (_answers is null) throw new Exception("trying to assign null to the Answer List");
            else
                foreach (Answer answer in _answers)
                {
                    answers.Add(answer);
                }
        }
        public AnswerList(AnswerList ls)
        {
            answers = new List<Answer>();
            if (ls is null) throw new Exception("trying to assign null to the Answer List");
            else
                foreach (Answer answer in ls.Answers)
                {
                    answers.Add(answer);
                }
        } 
        #endregion

        public Answer? GetById(int id)
        {
            foreach(var answer in answers)
            {
                if (id==answer.Id)
                    return answer;
            }
            return null;
        }
        public Answer this[int index]
        {
            get
            {
                if(index<0 || index > answers.Count ) throw new IndexOutOfRangeException();
                return new Answer(answers[index]);
            }
            set
            {
                if (index < 0 || index > answers.Count) throw new IndexOutOfRangeException();
                answers[index]=new Answer(value);
            }
        }

        public override bool Equals(object? obj)
        {
            if(obj is not AnswerList) return false;
            if(obj is AnswerList ls)
            {
                if (answers.Count != ls.answers.Count) return false;
                else
                    for (int i = 0; i < this.answers.Count; i++)
                    {
                        if (answers[i] != ls.answers[i])
                            return false;
                    }
            }
            return true;
        }

        //public AnswerList Add(Answer answer)
        //{
        //    this.answers.Add(new(answer));
        //    return this;
        //}
        public void Add(Answer answer)
        {
            this.answers.Add(new(answer));
        }
    }
}
