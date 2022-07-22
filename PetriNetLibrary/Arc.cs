using System;
using System.Collections.Generic;
using System.Text;

namespace PetriNetLibrary
{
    public class Arc
    {
        #region Fields

        string _id = "";
        int _weight = 1;
        bool _colored = false;
        Queue<Token> _tokens;

        #endregion
        #region Constructors

        public Arc(string id)
        {
            _id = id;
            _tokens = new Queue<Token>();
        }

        public Arc(int weight)
        {
            _weight = weight;
            _tokens = new Queue<Token>();
        }

        public Arc(bool colored)
        {
            _colored = colored;
            _tokens = new Queue<Token>();
        }

        #endregion
        #region Properties

        public string Id
        {
            get
            {
                return (_id);
            }
            set
            {
                _id = value;
            }
        }

        public int Count
        {
            get
            {
                int count;
                lock (_tokens)
                {
                    count = _tokens.Count;
                }
                return (count);
            }
        }

        public bool Colored
        {
            get
            {
                return (_colored);
            }
            set
            {
                _colored = value;
            }
        }

        public int Weight
        {
            get
            {
                return (_weight);
            }
            set
            {
                _weight = value;
            }
        }

        #endregion
        #region Method

        public void PutToken(Token token)
        {
            lock (_tokens)
            {
                _tokens.Enqueue(token);
            }
        }

        public Token GetToken()
        {
            lock (_tokens)
            {
                // Fom jobs add in the concept of a wait
                return (_tokens.Dequeue());
            }
        }
        #endregion
    }
}
