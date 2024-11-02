using System;
using System.Collections.Generic;
using System.Windows.Forms;

namespace MSO_Opdracht_3
{
    public class TranslatorContext
    {
        private object _translator;

        // Set a translator dynamically for any type of result
        public void SetTranslator<T>(ITranslator<T> translator)
        {
            _translator = translator;
        }

        // Execute translation and cast the result to the expected type
        public T ExecuteTranslation<T>()
        {
            if (_translator is ITranslator<T> typedTranslator)
            {
                return typedTranslator.Translate();
            }
            throw new InvalidOperationException("Translator not set or type mismatch.");
        }
    }
}

