using System;
using System.Collections.Generic;
using System.Windows.Forms;

namespace MSO_Opdracht_3
{
    public interface ITranslator<T>
    {
        public T Translate();
    }
}

