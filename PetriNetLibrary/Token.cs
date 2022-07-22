using System;
using System.Collections.Generic;
using System.Text;

namespace PetriNetLibrary
{
    public class Token
    {
        #region Fields
        object _value = null;
        #endregion
        #region Constructors
        public Token()
        { }

        public Token(object value)
        {
            _value = value;
        }

        #endregion
        #region Properties

        object Value
        {
            get
            {
                return (_value);
            }
            set
            {
                _value = value;
            }
        }

        #endregion
    }
}
