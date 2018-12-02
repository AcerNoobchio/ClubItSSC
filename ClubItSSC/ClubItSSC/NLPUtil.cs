﻿using System;
using System.Collections.Generic;
using System.Text;

namespace ClubItSSC
{
    /// <summary>
    /// I'm writing my own NLP Library with blackjack and hookers
    /// </summary>
    public static class NLPUtil
    {
        #region stop words
        static List<String> StopWords = new List<String> {
                "a","able","about","above","abroad","according",
                "accordingl",
                "across",
                "actually",
                "adj",
                "after",
                "afterwards",
                "again",
                "against",
                "ago",
                "ahead",
                "ain't",
                "all",
                "allow",
                "allows",
                "almost",
                "alone",
                "along",
                "alongside",
                "already",
                "also",
                "although",
                "always",
                "am",
                "amid",
                "amidst",
                "among",
                "amongst",
                "an",
                "and",
                "another",
                "any",
                "anybody",
                "anyhow",
                "anyone",
                "anything",
                "anyway",
                "anyways",
                "anywhere",
                "apart",
                "appear",
                "appreciate",
                "appropriate",
                "are",
                "aren't",
                "around",
                "as",
                "a's",
                "aside",
                "ask",
                "asking",
                "associated",
                "at",
                "available",
                "away",
                "awfully",
                "b",
                "back",
                "backward",
                "backwards",
                "be",
                "became",
                "because",
                "become",
                "becomes",
                "becoming",
                "been",
                "before",
                "beforehand",
                "begin",
                "behind",
                "being",
                "believe",
                "below",
                "beside",
                "besides",
                "best",
                "better",
                "between",
                "beyond",
                "both",
                "brief",
                "but",
                "by",
                "c",
                "came",
                "can",
                "cannot",
                "cant",
                "can't",
                "caption",
                "cause",
                "causes",
                "certain",
                "certainly",
                "changes",
                "clearly",
                "c'mon",
                "co",
                "co.",
                "com",
                "come",
                "comes",
                "concerning",
                "consequently",
                "consider",
                "considering",
                "contain",
                "containing",
                "contains",
                "corresponding",
                "could",
                "couldn't",
                "course",
                "c's",
                "currently",
                "d",
                "dare",
                "daren't",
                "definitely",
                "described",
                "despite",
                "did",
                "didn't",
                "different",
                "directly",
                "do",
                "does",
                "doesn't",
                "doing",
                "done",
                "don't",
                "down",
                "downwards",
                "during",
                "e",
                "each",
                "edu",
                "eg",
                "eight",
                "eighty",
                "either",
                "else",
                "elsewhere",
                "end",
                "ending",
                "enough",
                "entirely",
                "especially",
                "et",
                "etc",
                "even",
                "ever",
                "evermore",
                "every",
                "everybody",
                "everyone",
                "everything",
                "everywhere",
                "ex",
                "exactly",
                "example",
                "except",
                "f",
                "fairly",
                "far",
                "farther",
                "few",
                "fewer",
                "fifth",
                "first",
                "five",
                "followed",
                "follows",
                "for",
                "forever",
                "former",
                "formerly",
                "forth",
                "forward",
                "found",
                "four",
                "from",
                "further",
                "furthermore",
                "g",
                "get",
                "gets",
                "getting",
                "given",
                "gives",
                "go",
                "goes",
                "going",
                "gone",
                "got",
                "gotten",
                "greetings",
                "h",
                "had",
                "hadn't",
                "half",
                "happens",
                "hardly",
                "has",
                "hasn't",
                "have",
                "haven't",
                "having",
                "he",
                "he'd",
                "he'll",
                "hello",
                "help",
                "hence",
                "her",
                "here",
                "hereafter",
                "hereby",
                "herein",
                "here's",
                "hereupon",
                "hers",
                "herself",
                "he's",
                "hi",
                "him",
                "himself",
                "his",
                "hither",
                "hopefully",
                "how",
                "howbeit",
                "however",
                "hundred",
                "i",
                "i'd",
                "ie",
                "if",
                "ignored",
                "i'll",
                "i'm",
                "immediate",
                "in",
                "inasmuch",
                "inc",
                "inc.",
                "indeed",
                "indicate",
                "indicated",
                "indicates",
                "inner",
                "inside",
                "insofar",
                "instead",
                "into",
                "inward",
                "is",
                "isn't",
                "it",
                "it'd",
                "it'll",
                "its",
                "it's",
                "itself",
                "i've",
                "j",
                "just",
                "k",
                "keep",
                "keeps",
                "kept",
                "know",
                "known",
                "knows",
                "l",
                "last",
                "lately",
                "later",
                "latter",
                "latterly",
                "least",
                "less",
                "lest",
                "let",
                "let's",
                "like",
                "likes",
                "liked",
                "likely",
                "likewise",
                "little",
                "look",
                "looking",
                "looks",
                "low",
                "lower",
                "ltd",
                "m",
                "made",
                "mainly",
                "make",
                "makes",
                "many",
                "may",
                "maybe",
                "mayn't",
                "me",
                "mean",
                "meantime",
                "meanwhile",
                "merely",
                "might",
                "mightn't",
                "mine",
                "minus",
                "miss",
                "more",
                "moreover",
                "most",
                "mostly",
                "mr",
                "mrs",
                "much",
                "must",
                "mustn't",
                "my",
                "myself",
                "n",
                "name",
                "namely",
                "nd",
                "near",
                "nearly",
                "necessary",
                "need",
                "needn't",
                "needs",
                "neither",
                "never",
                "neverf",
                "neverless",
                "nevertheless",
                "new",
                "next",
                "nine",
                "ninety",
                "no",
                "nobody",
                "non",
                "none",
                "nonetheless",
                "noone",
                "no-one",
                "nor",
                "normally",
                "not",
                "nothing",
                "notwithstanding",
                "novel",
                "now",
                "nowhere",
                "o",
                "obviously",
                "of",
                "off",
                "often",
                "oh",
                "ok",
                "okay",
                "old",
                "on",
                "once",
                "one",
                "ones",
                "one's",
                "only",
                "onto",
                "opposite",
                "or",
                "other",
                "others",
                "otherwise",
                "ought",
                "oughtn't",
                "our",
                "ours",
                "ourselves",
                "out",
                "outside",
                "over",
                "overall",
                "own",
                "p",
                "particular",
                "particularly",
                "past",
                "per",
                "perhaps",
                "placed",
                "please",
                "plus",
                "possible",
                "presumably",
                "probably",
                "provided",
                "provides",
                "q",
                "que",
                "quite",
                "qv",
                "r",
                "rather",
                "rd",
                "re",
                "really",
                "reasonably",
                "recent",
                "recently",
                "regarding",
                "regardless",
                "regards",
                "relatively",
                "respectively",
                "right",
                "round",
                "s",
                "said",
                "same",
                "saw",
                "say",
                "saying",
                "says",
                "second",
                "secondly",
                "see",
                "seeing",
                "seem",
                "seemed",
                "seeming",
                "seems",
                "seen",
                "self",
                "selves",
                "sensible",
                "sent",
                "serious",
                "seriously",
                "seven",
                "several",
                "shall",
                "shan't",
                "she",
                "she'd",
                "she'll",
                "she's",
                "should",
                "shouldn't",
                "since",
                "six",
                "so",
                "some",
                "somebody",
                "someday",
                "somehow",
                "someone",
                "something",
                "sometime",
                "sometimes",
                "somewhat",
                "somewhere",
                "soon",
                "sorry",
                "specified",
                "specify",
                "specifying",
                "still",
                "sub",
                "such",
                "sup",
                "sure",
                "t",
                "take",
                "taken",
                "taking",
                "tell",
                "tends",
                "th",
                "than",
                "thank",
                "thanks",
                "thanx",
                "that",
                "that'll",
                "thats",
                "that's",
                "that've",
                "the",
                "their",
                "theirs",
                "them",
                "themselves",
                "then",
                "thence",
                "there",
                "thereafter",
                "thereby",
                "there'd",
                "therefore",
                "therein",
                "there'll",
                "there're",
                "theres",
                "there's",
                "thereupon",
                "there've",
                "these",
                "they",
                "they'd",
                "they'll",
                "they're",
                "they've",
                "thing",
                "things",
                "think",
                "third",
                "thirty",
                "this",
                "thorough",
                "thoroughly",
                "those",
                "though",
                "three",
                "through",
                "throughout",
                "thru",
                "thus",
                "till",
                "to",
                "together",
                "too",
                "took",
                "toward",
                "towards",
                "tried",
                "tries",
                "truly",
                "try",
                "trying",
                "t's",
                "twice",
                "two",
                "u",
                "un",
                "under",
                "underneath",
                "undoing",
                "unfortunately",
                "unless",
                "unlike",
                "unlikely",
                "until",
                "unto",
                "up",
                "upon",
                "upwards",
                "us",
                "use",
                "used",
                "useful",
                "uses",
                "using",
                "usually",
                "v",
                "value",
                "various",
                "versus",
                "very",
                "via",
                "viz",
                "vs",
                "w",
                "want",
                "wants",
                "was",
                "wasn't",
                "way",
                "we",
                "we'd",
                "welcome",
                "well",
                "we'll",
                "went",
                "were",
                "we're",
                "weren't",
                "we've",
                "what",
                "whatever",
                "what'll",
                "what's",
                "what've",
                "when",
                "whence",
                "whenever",
                "where",
                "whereafter",
                "whereas",
                "whereby",
                "wherein",
                "where's",
                "whereupon",
                "wherever",
                "whether",
                "which",
                "whichever",
                "while",
                "whilst",
                "whither",
                "who",
                "who'd",
                "whoever",
                "whole",
                "who'll",
                "whom",
                "whomever",
                "who's",
                "whose",
                "why",
                "will",
                "willing",
                "wish",
                "with",
                "within",
                "without",
                "wonder",
                "won't",
                "would",
                "wouldn't",
                "x",
                "y",
                "yes",
                "yet",
                "you",
                "you'd",
                "you'll",
                "your",
                "you're",
                "yours",
                "yourself",
                "yourselves",
                "you've",
                "z",
                "zero",
        };
        #endregion

        #region prepositions
        static List<String> Prepositions = new List<String>
        {
            "above",
            "aboveground",
            "abroad",
            "across",
            "across from",
            "adjacent",
            "afore",
            "afront",
            "against",
            "ahead",
            "ahead of",
            "along",
            "amid",
            "amidst",
            "among",
            "amongst",
            "apart",
            "apposite",
            "around",
            "aside",
            "astern",
            "at",
            "atop",
            "away",
            "ayond",
            "ayont",
            "back",
            "before",
            "below",
            "belowground",
            "beneath",
            "beside",
            "beyond",
            "cater-corner",
            "close",
            "close by",
            "close to",
            "distant",
            "down",
            "downstage",
            "downstream",
            "east",
            "here",
            "home",
            "in between",
            "in front",
            "in front of",
            "in town",
            "inbetwixt",
            "inside",
            "near",
            "nearby",
            "next door",
            "next to",
            "off",
            "off base",
            "off board",
            "offstage",
            "on",
            "on base",
            "on board",
            "on deck",
            "of",
            "on top of",
            "opposite",
            "out",
            "out of town",
            "outside",
            "outside of",
            "over",
            "over here",
            "over there",
            "overseas",
            "to",
            "there",
            "through",
            "under",
            "underground",
            "underneath",
            "up",
            "upstage",
            "upstream",
            "west",
            "within",
            "without",
            "yon",
            "yonder",
        };
        #endregion

        static List<String> Endings = new List<String>
        {
            "ed",
            "es",
            "ing",
            "ly",
            "s",
        };

        /// <summary>
        /// A static method that deletes all delimiters and turns a string into a list of characters
        /// </summary>
        /// <param name="Input"> The string that will have all of its (except for spaces) tokens extracted from it </param>
        /// <param name="Delimiter"> Any specific substring that you want to be removed from the list, it is suggested that a space be passed here. </param>
        /// <returns> A list of strings holds all characters in the string except for those chosen by the caller to leave out </returns>
        public static List<String> Tokenize(String Input, String Delimiter)
        {
            Char[] chrDelimiter = new char[1];
            Char[] chrExtract;
            String[] Tokens;
            String[] Delimiters = { ".", ",", "!", "?" };
            List<Int32> lstIndex = new List<Int32>();

            chrExtract = Input.ToCharArray();                           //Turn the input string into a character array so we can put spaces in front of the necessary delimiters

            for (int iCount = 0; iCount < chrExtract.Length; iCount++)
            {
                if ((chrExtract[iCount] == '.' || chrExtract[iCount] == ',' || chrExtract[iCount] == '!' || chrExtract[iCount] == '?' || chrExtract[iCount] == '\n' || chrExtract[iCount] == '\r') && ((iCount - 1) != -1))
                {
                    lstIndex.Add(iCount);                               //Grab the indexes of all of the delimiters
                }
            }

            for (int iCount = 0; iCount < lstIndex.Count; iCount++)
            {
                Input = Input.Insert((lstIndex[iCount] + iCount), " ");  //Add a space before each of the symbols we wish to grab
            }

            chrDelimiter = Delimiter.ToCharArray();                     //Make the passed delimiter compatable with the Split method
            Tokens = Input.Split(chrDelimiter, 99999);                  //Tokens takes all of the strings split up from the original input based on spaces

            //strNoDelimiter = Input.Replace(Delimiter, String.Empty);  //Removes all spaces and returns the string into strNoDelimiter

            List<String> lstTokens = new List<String>(Tokens.Length);   //Holds all of the tokens from an imported string, initialized with the num elements in the char array

            for (int iCount = 0; iCount < Tokens.Length; iCount++)
            {
                lstTokens.Add(Tokens[iCount]);                          //Add each element of the token array into the list
            }


            return lstTokens;
        }//end Tokenize(String, String)

        /// <summary>
        /// A static method that deletes all delimiters and turns a string into a list of characters
        /// </summary>
        /// <param name="Input"> The string that will have all of its (except for spaces) tokens extracted from it </param>
        /// <param name="Delimiter"> Any specific substring that you want to be removed from the list, it is suggested that a space be passed here. </param>
        /// <param name="iIndex"> An index that specifies where to stop tokenizing </param>
        /// <returns> A list of strings holds all characters in the string except for those chosen by the caller to leave out </returns>
        public static List<String> Tokenize(String Input, String Delimiter, int iIndex)
        {
            Char[] chrDelimiter = new char[1];
            Char[] chrExtract;
            String[] Tokens;
            String[] Delimiters = { ".", ",", "!", "?" };
            List<Int32> lstIndex = new List<Int32>();

            chrExtract = Input.ToCharArray();                           //Turn the input string into a character array so we can put spaces in front of the necessary delimiters

            for (int iCount = 0; iCount < chrExtract.Length; iCount++)
            {
                if ((chrExtract[iCount] == '.' || chrExtract[iCount] == ',' || chrExtract[iCount] == '!' || chrExtract[iCount] == '?' || chrExtract[iCount] == '\n' || chrExtract[iCount] == '\r') && ((iCount - 1) != -1))
                {
                    lstIndex.Add(iCount);                               //Grab the indexes of all of the delimiters
                }
            }

            for (int iCount = 0; iCount < lstIndex.Count; iCount++)
            {
                Input = Input.Insert((lstIndex[iCount] + iCount), " ");  //Add a space before each of the symbols we wish to grab
            }

            chrDelimiter = Delimiter.ToCharArray();                     //Make the passed delimiter compatable with the Split method
            Tokens = Input.Split(chrDelimiter, 99999);                  //Tokens takes all of the strings split up from the original input based on spaces

            //strNoDelimiter = Input.Replace(Delimiter, String.Empty);  //Removes all spaces and returns the string into strNoDelimiter

            List<String> lstTokens = new List<String>(Tokens.Length);   //Holds all of the tokens from an imported string, initialized with the num elements in the char array

            for (int iCount = 0; iCount < iIndex; iCount++)
            {
                lstTokens.Add(Tokens[iCount]);                          //Add each element of the token array into the list
            }


            return lstTokens;
        }//end List(String, String, int)

        public static void Stem(UserInterest InterestIn)
        {
            int iIndex = 0;
            for(int i = 0; i < Endings.Count; i++)
            {
                for(int j = 0; j< InterestIn.GetWordList().Count; j++)
                {
                    iIndex = Endings.BinarySearch(InterestIn.GetWordList()[j].GetEnding(Endings[i].Length));        //Collect ending based on the ending being examined
                    if(iIndex > 0)                                                                                  //If found
                    {
                        InterestIn.GetWordList()[j].strWord = (InterestIn.GetWordList()[j].strWord.Substring(0, InterestIn.GetWordList()[j].strWord.Length - Endings[i].Length));   //Remove ending
                    }
                }
            }
            InterestIn.Combine();

        }//end Stem(InterestIn)

        public static void RemoveStopWords(UserInterest InterestIn)
        {
            int iIndex = 0;
            for(int i = 0; i < InterestIn.GetWordList().Count; i++) //Look for an occurance of a stop word
            {
                iIndex = StopWords.BinarySearch(InterestIn.GetWordList()[i].strWord);
                if (iIndex > 0)
                {
                    InterestIn.GetWordList().RemoveAt(i);      //and remove it, if found
                    i--;                                       //account for the element being removed
                }
            }
            InterestIn.Combine();
            
        }//end RemoveStopWords(InterestIn)

        public static void RemovePrepositions(UserInterest InterestIn)
        {
            int iIndex = 0;
            for (int i = 0; i < InterestIn.GetWordList().Count; i++) //Look for an occurance of a preposition
            {
                iIndex = Prepositions.BinarySearch(InterestIn.GetWordList()[i].strWord);
                if (iIndex > 0)
                {
                    InterestIn.GetWordList().RemoveAt(i);      //and remove it, if found
                    i--;
                }
            }
            InterestIn.Combine();

        }//end RemovePrepositions(InterestIn)



    }
}