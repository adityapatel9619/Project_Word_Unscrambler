using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WordUnscrambler.Data;

namespace WordUnscrambler.Wokers
{
   public class WordMatcher
    {
        public List<MatchedWord> Match(string[] scrambleWords, string[] wordList)
        {
            var matchedWords = new List<MatchedWord>();

            foreach (var scrambleWord in scrambleWords)
            {
                foreach (var word in wordList)
                {
                    if (scrambleWord.Equals(word,StringComparison.OrdinalIgnoreCase))
                    {
                        matchedWords.Add(BuildMatchedWord(scrambleWord, word));
                    }
                    else
                    {
                        //If words are not matched we try once again by breaking them into characters and sorting and then compare
                        //This method breaks String to Characters 
                        var ScrambleWordArray = scrambleWord.ToCharArray();
                        var WordArray = word.ToCharArray();

                        //Sort the character array
                        Array.Sort(ScrambleWordArray);
                        Array.Sort(WordArray);

                        //Creating strings from the character array  or
                        //Converting or Gluing sorted character to string
                        var SortedScrambleWord = new string(ScrambleWordArray);
                        var SortedWord = new string(WordArray);

                        //Comparing the sorted string 
                        if (SortedScrambleWord.Equals(SortedWord,StringComparison.OrdinalIgnoreCase))
                        {
                            matchedWords.Add(BuildMatchedWord(scrambleWord, word));
                        }

                    }
                }
            }

            return matchedWords;
        }

        private MatchedWord BuildMatchedWord(string scrambleWord,string word)
        {
            MatchedWord matchWord = new MatchedWord();
            matchWord.ScrambleWords = scrambleWord;
            matchWord.Word = word;
            return matchWord;
        }
    }
}
