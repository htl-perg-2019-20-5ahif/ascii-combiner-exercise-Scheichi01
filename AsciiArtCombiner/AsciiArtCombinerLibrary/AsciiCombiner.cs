using System;
using System.Collections.Generic;

namespace AsciiArtCombinerLibrary
{
    public class AsciiCombiner
    {
        string result = "";

        public string combineTexts(IEnumerable<string> texts)
        {
            checkTextCompatability(texts);

            foreach (string text in texts)
            {
                addLayer(text);
            }
            return result;
        }

        public bool checkTextCompatability(IEnumerable<string> texts)
        {
            int columns = -1;
            int rows = -1;

            foreach(string text in texts)
            {
                string[] lines = text.Replace("\r", "").Split('\n');
                if (rows > -1 && lines.Length != rows) return false;
                else if (rows == -1) rows = lines.Length;

                foreach(string line in lines)
                {
                    if (columns > -1 && line.Length != columns) return false;
                    else if (columns == -1) columns = line.Length;
                }
            }

            return true;
        }

        private void addLayer(string text)
        {
            if (result.Equals(""))
            {
                result = text;
                return;
            }

            string[] newLines = text.Replace("\r", "").Split('\n');
            string[] prevResultLines = result.Replace("\r", "").Split('\n');

            string[] newResult = (string[])prevResultLines.Clone();

            for (int i = 0; i<newLines.Length; i++)
            {
                newResult[i] = "";
                for(int j = 0; j<newLines[i].Length; j++)
                {
                    if (newLines[i][j] != ' ') newResult[i] += newLines[i][j];
                    else newResult[i] += prevResultLines[i][j];
                }
            }
            string newCombinedResult = String.Join("\n", newResult);
            string[] temp = { result, newCombinedResult };
            if (!checkTextCompatability(temp)){
                Console.WriteLine("ERROR: Result is not compatible with new Result!");
            }
            else
            {
                result = newCombinedResult;
            }
        }
    }
}
