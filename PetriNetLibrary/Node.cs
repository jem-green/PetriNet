using System;
using System.Collections.Generic;
using System.Text;

namespace PetriNetLibrary
{
    public class Node
    {
        #region Fields

        Arc _arc;

        #endregion
        #region Constructors

        public Node(Arc arc)
        {
            _arc = arc;
        }

        #endregion
        #region Properties

        public Arc Arc
        {
            get
            {
                return (_arc);
            }
            set
            {
                _arc = value;
            }
        }

        #endregion

    }
}
