// This is the text editor interface. 
// Anything you type or change here will be seen by the other person in real time.
/* 
Given a function that returns the next page from a book:
1. Print an index of all the words in the book and the pages they appear in.
2. Print the index once again this time in descending order of word popularity. The popularity of a word is measured by the total number of occurences of the word in the book, not by the number of pages it appears in.

Given:

using Word = std::string;
using Page = std::vector<Word>;
using PageNumber = int;

std::pair<Page, bool> nextPage() {

    auto parsePage = [](const std::string& text) {
        Page result; std::string s; std::istringstream sin(text);
        while(std::getline(sin, s, ' ')) {
            result.push_back(s);
        }
        return result;
    };

    static int index = 0;
    std::vector<std::string> book {
        "this is a sample page ",
        "from a sample book with more than a page ",
        "as a sample input"
    };
    auto p = std::make_pair(parsePage(book[index]), index == book.size() - 1);
    ++index;
    return p;
}

//Roberto's solution run

Book:
        <"this is a sample page ">, 0,
        <"from a sample book with more than a page ">, 1,
        <"as a sample input">, 2

        map:
        <this, bookInfo<occurrences:1, pages<0>>
        <is, bookInfo<occurrences:1, pages<0>>
        <a, bookInfo<occurrences:1, pages<0>>
        <sample, bookInfo<occurrences:1, pages<0>>
        <page, bookInfo<occurrences:2, pages<0, 1>>
*/

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApplication4
{
    class Program
    {
        public class Book
        {
            public List<Tuple<string, int>> Contents;
            public Book()
            {
                Contents = new List<Tuple<string, int>>();
            }
        }

        public class BookInfo
        {
            public HashSet<int> pages { get; set; }
            public int ocurrences { get; set; }
            public string word;
            public BookInfo()
            {
                pages = new HashSet<int>();
            }
        }

        public static Dictionary<string, BookInfo> GetBookInfo(Book book)
        {
            if (book == null) throw new ArgumentException("some message...");
            var map = new Dictionary<string, BookInfo>();
            for (var i = 0; i < book.Contents.Count; ++i)
            {
                var tokens = book.Contents[i].Item1.Split(' ');
                foreach (var s in tokens)
                {
                    BookInfo pagesList;
                    if (!map.TryGetValue(s, out pagesList))
                    {
                        var bookInfo = new BookInfo();
                        bookInfo.pages.Add(book.Contents[i].Item2);
                        bookInfo.ocurrences = 1;
                        bookInfo.word = s;
                        map.Add(s, bookInfo);
                    }
                    else
                    {
                        map[s].pages.Add(book.Contents[i].Item2);
                        map[s].ocurrences++;
                    }
                }
            }

            return map;
        }

        public static void ExerciseSolution(Book book)
        {
            var bookHistogram = GetBookInfo(book);

            //Solution 1
            foreach (var t in bookHistogram)
            {
                string pages = string.Empty;
                foreach (var i in t.Value.pages)
                {
                    pages += " " + i;
                }
                Console.WriteLine("word: " + t.Key + " pages:" + pages);
            }


            //Solution 2
            var bookInfoList = bookHistogram.Values.ToList();
            bookInfoList.Sort(WordPopularity);
            foreach (var b in bookInfoList)
            {
                Console.WriteLine("Word: " + b.word + " Popularity: " + b.ocurrences);
            }
        }

        public static int WordPopularity(BookInfo b1, BookInfo b2)
        {
            return b2.ocurrences.CompareTo(b1.ocurrences);
        }

        static void Main(string[] args)
        {
            var book = new Book();
            book.Contents.Add(new Tuple<string, int>("this is a sample page", 0));
            book.Contents.Add(new Tuple<string, int>("from a sample book with more than a page", 1));
            book.Contents.Add(new Tuple<string, int>("as a sample input", 2));

            ExerciseSolution(book);
        }

    }
}


/* 
Test cases:

1. 
2.

*/
