using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WordUnscrambler.Data;
using WordUnscrambler.Wokers;

namespace WordUnscrambler
{
    class Program 
    {
        private static readonly FileReader _fileReader = new FileReader(); //This will read the file provided by user
        private static readonly WordMatcher _wordMatcher = new WordMatcher();

        static void Main(string[] args)
        {
            Console.Title = "Word Unscrambler";
            
            try
            {
                bool continueWordUnscramble = true;
                do
                {
                    Console.WriteLine(Constants.OptionsOnHowToEnter);
                    var option = Console.ReadLine() ?? string.Empty;

                    switch (option.ToUpper())
                    {
                        case Constants.File:
                            Console.Write(Constants.EnterScrambledWordsViaFile);
                            ExecuteScrambledWordsInFileScenario();
                            break;
                        case Constants.Manual:
                            Console.Write(Constants.EnterScrambledWordsManually);
                            ExecuteScrambledWordsManualScenario();
                            break;

                        default:
                            Console.Write(Constants.EnterScrambledWordsOptionNotRecognized);
                            break;
                    } 

                    //This is for re-execution of program
                    var continueDecision = string.Empty;
                    do
                    {
                        Console.WriteLine(Constants.OptionsOnContinuing);
                        continueDecision = (Console.ReadLine() ?? string.Empty);

                    } while (!continueDecision.Equals(Constants.Yes, StringComparison.OrdinalIgnoreCase) &&
                              !continueDecision.Equals(Constants.No, StringComparison.OrdinalIgnoreCase));

                    continueWordUnscramble = continueDecision.Equals(Constants.Yes, StringComparison.OrdinalIgnoreCase);
                } while (continueWordUnscramble);




            }
            catch (Exception ex)
            {

                Console.WriteLine(Constants.ErrorProgramWillBeTerminated + ex.Message);
            }


        }



        private static void ExecuteScrambledWordsManualScenario()
        {
            var manualInput = Console.ReadLine().ToLower()??string.Empty;
            string[] scrambleWords = manualInput.Split(',');   //Seprating the words in manual scenario by ','or comma
            DisplayMatchedUnscrambledWords(scrambleWords);
        }


        private static void ExecuteScrambledWordsInFileScenario()
        {
            try
            {
            var fileName = Console.ReadLine() ?? string.Empty;
            string[] scrambleWords = _fileReader.Read(fileName);
            DisplayMatchedUnscrambledWords(scrambleWords);
            }
            catch (Exception ex)
            {

                Console.WriteLine(Constants.ErrorScrambledWordsCantLoad + ex.Message);
            }

        }


        //Display of the matched unscrambled words
        private static void DisplayMatchedUnscrambledWords(string[] scrambleWords)
        {
            string[] wordList= _fileReader.Read(Constants.wordListFileName);

            List<MatchedWord> matchedWords = _wordMatcher.Match(scrambleWords, wordList);

            if (matchedWords.Any())
            {
                foreach (var matchedWord in matchedWords)
                {
                    Console.WriteLine(Constants.MatchFound, matchedWord.ScrambleWords,matchedWord.Word);
                }
            }
            else
            {
                Console.WriteLine(Constants.MatchNotFound);
            }
        }
    }
}
