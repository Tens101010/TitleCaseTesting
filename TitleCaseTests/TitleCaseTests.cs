//Please note: This application is purely for my own education, to run through coding 
//examples by following tutorials, and to just tinker around with coding.  
//I know it’s bad practice to heavily comment code (code smell), but comments in all of my 
//exercises will largely be left intact as this serves me 2 purposes:
//    I want to retain what my original thought process was at the time
//    I want to be able to look back in 1..5..10 years to see how far I’ve come
//    And I enjoy commenting on things, however redundant this may be . . . 

using System.Collections.Generic;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace TitleCaseTests
{
    [TestClass]
    public class TitleCaseTests
    {
        [TestMethod]
        public void Example1()
        {
            var result = TitleCase("i love solving problems and it is fun");
            Assert.AreEqual("I Love Solving Problems and It Is Fun", result);
        }

        [TestMethod]
        public void Example2()
        {
            var result = TitleCase("wHy DoeS A biRd Fly?");
            Assert.AreEqual("Why Does a Bird Fly?", result);
        }

        [TestMethod]
        public void Corner1()
        {
            var result = TitleCase("aT");
            Assert.AreEqual("At", result);
        }

        [TestMethod]
        public void Corner2()
        {
            var result = TitleCase("");
            Assert.AreEqual("", result);
        }

        [TestMethod]
        public void Corner3()
        {
            var result = TitleCase("22 juMp strEEt");
            Assert.AreEqual("22 Jump Street", result);
        }

        //Stings that will always be lowercase
        private List<string> lowerList = new List<string>
        {
            "a",
            "the",
            "to",
            "at",
            "in",
            "with",
            "and",
            "but",
            "or"
        };

        public string TitleCase(string title)
        {
            if (string.IsNullOrEmpty(title))
                return string.Empty;

            title = title.ToLower();

            //Split words with a space into seperate strings
            var words = title.Split(' ');

            for (int i = 0; i < words.Length; i++)
            {
                if (i == 0 || i == words.Length - 1 || !lowerList.Contains(words[i]))
                    words[i] = Capitalize(words[i]);
            }
            return string.Join(" ", words);
        }

        public string Capitalize(string word)
        {
            word = char.ToUpper(word[0]) + word.Substring(1);
            return word;
        }
    }
}
