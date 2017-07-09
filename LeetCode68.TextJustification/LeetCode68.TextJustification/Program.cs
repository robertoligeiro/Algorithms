using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeetCode68.TextJustification
{
    class Program
    {
        //https://leetcode.com/problems/text-justification/#/description
        static void Main(string[] args)
        {
            var s = new Solution();
            var r = s.FullJustify(new string[] { "This", "is", "an", "example", "of", "text", "justification." }, 16);
            r = s.FullJustify(new string[] { "When", "I", "was", "just", "a", "little", "girl", "I", "asked", "my", "mother", "what", "will", "I", "be", "Will", "I", "be", "pretty", "Will", "I", "be", "rich" }, 60);
            r = s.FullJustify(new string[] { "What", "must", "be", "shall", "be." }, 12);
            r = s.FullJustify(new string[] { "This", "is", "an", "example", "of", "text", "" }, 16);
            r = s.FullJustify(new string[] { "a" }, 1);
            r = s.FullJustify(new string[] { "" }, 2);
            r = s.FullJustify(new string[] { "a", "b", "c", "d", "e"}, 3);
        }
        public class Solution
        {
            public IList<string> FullJustify(string[] words, int maxWidth)
            {
                var resp = new List<string>();
                if (maxWidth == 0)
                {
                    resp.Add(string.Empty);
                    return resp;
                }

                var line = new List<string>();
                var count = 0;
                var index = 0;
                while (true)
                {
                    count += words[index].Length;
                    if (count <= maxWidth)
                    {
                        if (!string.IsNullOrEmpty(words[index]))
                        {
                            line.Add(words[index]);
                            count++;
                        }
                        if (++index >= words.Length)
                        {
                            resp.Add(GetJustifiedLine(line, maxWidth, count));
                            break;
                        }
                    }
                    else
                    {
                        count -= words[index].Length;
                        resp.Add(GetJustifiedLine(line, maxWidth, count));
                        line.Clear();
                        count = 0;
                    }
                }
                resp[resp.Count - 1] = FixLastLine(resp.Last());
                return resp;
            }

            public static string FixLastLine(string line)
            {
                if (line[0] == ' ') return line;
                var newline = new StringBuilder();
                var hasAddedBlank = false;
                var countBlanks = 0;
                foreach (var c in line)
                {
                    if (c != ' ')
                    {
                        hasAddedBlank = false;
                        newline.Append(c);
                    }
                    else
                    {
                        if (!hasAddedBlank)
                        {
                            newline.Append(c);
                            hasAddedBlank = true;
                        }
                        else
                        {
                            countBlanks++;
                        }
                    }
                }
                var blanks = new string(Enumerable.Repeat(' ', countBlanks).ToArray());
                return newline + blanks;
            }
            public static string GetJustifiedLine(List<string> line, int maxWidth, int count)
            {
                var wordCountLen = count - line.Count;
                var extraSpacesNeeded = maxWidth - wordCountLen;
                var spacesNeededPerWord = maxWidth;
                var totalExtraSpaces = maxWidth;
                if (line.Count > 0)
                {
                    if (line.Count > 1)
                    {
                        spacesNeededPerWord = extraSpacesNeeded / (line.Count - 1);
                        totalExtraSpaces = spacesNeededPerWord * (line.Count - 1);
                    }
                    else
                    {
                        spacesNeededPerWord = maxWidth - wordCountLen;
                        totalExtraSpaces = spacesNeededPerWord;
                    }
                }
                var missingExtraSpaces = maxWidth - (wordCountLen + totalExtraSpaces);
                var spaces  = new string(Enumerable.Repeat(' ', spacesNeededPerWord).ToArray());

                //line is empty string only
                if (line.Count == 0) return spaces;

                var resp = new StringBuilder();
                for(int i = 0; i < line.Count; ++i)
                {
                    var addedSpace = new StringBuilder(spaces);
                    if (missingExtraSpaces-- > 0) addedSpace.Append(' ');
                    if (i != line.Count -1)
                    {
                        resp.Append(line[i] + addedSpace);
                    }
                    else
                    {
                        resp.Append(line[i]);
                    }
                }

                if (resp.Length < maxWidth)
                {
                    resp.Append(spaces);
                }
                return resp.ToString();
            }
        }
    }
}
