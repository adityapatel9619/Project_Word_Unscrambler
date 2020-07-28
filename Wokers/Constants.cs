using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WordUnscrambler.Wokers
{
    class Constants
    {
        public const string OptionsOnHowToEnter = "Enter scrambled ord(s) manually Or as a file: F-file / M- manual";
        public const string OptionsOnContinuing = "Would you like to continue? Y/N";

        public const string EnterScrambledWordsViaFile = "Enter full path including the file name: ";
        public const string EnterScrambledWordsManually="Enter word(s) manually (separeted by commas if multiple): ";
        public const string EnterScrambledWordsOptionNotRecognized = "The option was not recognized";

        public const string ErrorScrambledWordsCantLoad = "Scrambled words cannot load";
        public const string ErrorProgramWillBeTerminated = "The program will be teminated";

        public const string MatchFound = "Match Found For {0}: {1}";
        public const string MatchNotFound = "No Match Found";

        public const string Yes = "Y";
        public const string No = "N";
        public const string File = "F";
        public const string Manual = "M";

        public const string wordListFileName = "wordlist.txt";

    }
}
