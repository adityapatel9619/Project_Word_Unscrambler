using System;
using System.IO;
namespace WordUnscrambler.Wokers
{
    class FileReader
    {
        public string[] Read(string wordListFileName)
        {
            string[] fileContent;
            try
            {

            fileContent = File.ReadAllLines(wordListFileName);
            }
            catch (Exception ex)
            {
                //throw new Exception
                throw new Exception(ex.Message);
                //ex.Message-> wraps new exception into existing exception
            }
            return fileContent;
        }
    }
}
