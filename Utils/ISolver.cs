using System;
using System.Collections.Generic;
using System.Text;

namespace Utils
{
    public interface ISolver
    {
        string PuzzleName
        {
            get;
        }

        string Solve( string input );
    }
}
