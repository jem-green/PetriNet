using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Text;
using System.Threading;

namespace PetriNetLibrary
{
    public class Place
    {
        #region Fields

        string _id = "";
        List<Token> _initial;
        List<Token> _tokens;
        List<Node> _throw;
        List<Node> _catch;

        #endregion
        #region Constructors
        public Place(string id)
        {
            _id = id;
            _initial = new List<Token>();
            _tokens = new List<Token>();
            _throw = new List<Node>();
            _catch = new List<Node>();
        }

        public Place(string id, List<Token> initial)
        {
            _id = id;
            _initial = initial;
            _tokens = new List<Token>();
            _throw = new List<Node>();
            _catch = new List<Node>();
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

        #endregion
        #region Methods

        public bool AddThrow(Node node)
        {
            bool add = false;
            try
            {
                _throw.Add(node);
                add = true;
            }
            catch { }
            return (add);
        }

        public bool AddCatch(Node node)
        {
            bool add = false;
            try
            {
                _catch.Add(node);
                add = true;
            }
            catch { }
            return (add);
        }

        public bool AddToken(Token token)
        {
            bool add = false;
            try
            {
                _tokens.Add(token);
                add = true;
            }
            catch { }
            return (add);
        }

        public bool RemoveToken(Token token)
        {
            bool remove = false;
            try
            {
                _tokens.Remove(token);
                remove = true;
            }
            catch { }
            return (remove);
        }

        public void Start()
        {
            _tokens = new List<Token>(_initial);
            Debug.WriteLine(_id + " tokens=" + _tokens.Count);
            Process();
        }
        #endregion
        #region Private
        private void Process()
        {
            do
            {
                // Get all the tokens from the incoming arcs but only if it is at capacity
                // and store the tokens

                if (_catch.Count > 0)
                {
                    foreach (Node node in _catch)
                    {
                        if (node.Arc.Count == node.Arc.Weight)
                        {
                            Debug.WriteLine(_id + " Get from " + node.Arc.Id);

                            // Actually need to remove multiple tokens
                            // but only if the arc is at capacity

                            for (int i = 0; i < node.Arc.Weight; i++)
                            {
                                Token t = node.Arc.GetToken();
                                _tokens.Add(t);
                                Debug.WriteLine(_id + " Tokens=" + _tokens.Count);
                            }
                        }
                    }
                }

                // use the available tokens to fill the outgoing arcs to cpapcity

                if (_throw.Count > 0)
                {
                    foreach (Node node in _throw)
                    {
                        if (_tokens.Count > 0)
                        {
                            if (node.Arc.Count < node.Arc.Weight)
                            {
                                Debug.WriteLine(_id + " Put to " + node.Arc.Id);
                                for (int i = node.Arc.Count; i < node.Arc.Weight; i++)
                                {
                                    if (_tokens.Count > 0)
                                    {
                                        Token t = _tokens[_tokens.Count - 1];
                                        _tokens.RemoveAt(_tokens.Count - 1);
                                        node.Arc.PutToken(t);

                                        Debug.WriteLine(_id + " Tokens=" + _tokens.Count);
                                    }
                                }
                            }
                        }
                    }
                }
                Thread.Sleep(1000);
            }
            while (1 == 1);
        }

        #endregion
    }
}
