using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Text;
using System.Threading;

namespace PetriNetLibrary
{
    public class Transition
    {
        #region Fields

        string _id = "";
        protected List<Node> _throw;
        protected List<Node> _catch;

        #endregion
        #region Constructors

        public Transition(string id)
        {
            _id = id;
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

        public void Start()
        {
            Process();
        }
        #endregion
        #region Private
        private void Process()
        {
            do
            {
                if (_catch.Count > 0)
                {
                    // check all of the arcs to confirm that they are at capacity
                    // and only then trigger and remove 

                    bool trigger = true;
                    foreach (Node node in _catch)
                    {
                        if (node.Arc.Count < node.Arc.Weight)
                        {
                            trigger &= false;
                        }
                    }

                    // if the transition is triggered empty the incoming arcs

                    if (trigger == true)
                    {
                        foreach (Node node in _catch)
                        {
                            Debug.WriteLine(_id + " Get from " + node.Arc.Id);
                            for (int i = 0; i < node.Arc.Weight; i++)
                            {
                                node.Arc.GetToken();
                            }
                        }
                    }

                    // if the transition is triggered fill the outgoing arcs to capacity

                    if (trigger == true)
                    {
                        if (_throw.Count > 0)
                        {
                            foreach (Node node in _throw)
                            {
                                Debug.WriteLine(_id + " Put to " + node.Arc.Id);
                                for (int i = 0; i < node.Arc.Weight; i++)
                                {
                                    Token t = new Token();
                                    node.Arc.PutToken(t);
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
