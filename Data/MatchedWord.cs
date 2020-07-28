using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WordUnscrambler.Data
{
    public struct MatchedWord
    {
        public string ScrambleWords { get; set; }
        public string Word { get; set; }
    }
}
