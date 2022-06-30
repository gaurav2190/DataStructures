namespace DataStructures
{
    using System.Text;
    using System.Collections.Generic;

    public class Trie
    {
        public string ReplaceWords(IList<string> dictionary, string sentence) {
            foreach(var str in dictionary)
            {
                Insert(str);
            }
            var result = new StringBuilder();
            var sentenceArray = sentence.Split(' ');
            int i = 0;
            
            for(i = 0; i< sentenceArray.Length-1; i++)
            {
                var wordResult = GetRoot(sentenceArray[i]);
                
                if(string.IsNullOrEmpty(wordResult))
                {
                    result.Append(sentenceArray[i]);
                    result.Append(" ");
                }
                else
                {
                    result.Append(wordResult);
                    result.Append(" ");
                }
            }
            
            var wordResult1 = GetRoot(sentenceArray[i]);
            if(string.IsNullOrEmpty(wordResult1))
            {
                result.Append(sentenceArray[i]);
            }
            else
            {
                result.Append(wordResult1);
            }
            
            return result.ToString();
        }

        /// <summary>
        /// This is the max size of the array and each char is an index
        /// </summary>
        private const int AlPHABET_SIZE = 26;

        public class TrieNode
        {
            public TrieNode[] Children = new TrieNode[AlPHABET_SIZE];

            public bool IsEndOfWord { get; set; }

            public TrieNode()
            {
                IsEndOfWord = false;
            } 
        }

        public TrieNode Root = new TrieNode();

        public void Insert(string key)
        {
            var traverse = Root;

            // for each char in the key
            foreach (var item in key)
            {
                var index = item - 'a';
                
                // check if the corresponding index value is null, if yes...initialize it.
                if(traverse.Children[index] == null)
                    traverse.Children[index] = new TrieNode();
                
                // else move ahead to the next pointer.
                traverse = traverse.Children[index];
            }

            // at the end set the node as end of word.
            traverse.IsEndOfWord = true;
        }

        public string GetRoot(string key)
        {
            var traverse = Root;
            var str = new StringBuilder();

            foreach (var item in key)
            {
                var index = item - 'a';

                if(traverse.Children[index]== null)
                    break;
                str.Append(item);
                
                traverse = traverse.Children[index];
                if(traverse.IsEndOfWord)
                {
                    return str.ToString();
                }
            }
            
            if(traverse.IsEndOfWord)
            {
                return str.ToString();
            }
            else
            {
                return "";
            }
        }

        public bool Search(string key)
        {
            var traverse = Root;

            // similarly for each char in the string
            foreach (var item in key)
            {
                var index = item - 'a';

                // we check corresponding index in the Children array if null or not.
                // if null return false, as it does not have corresponding char in the sequence.
                if(traverse.Children[index]== null)
                    return false;
                
                // else move forward.
                traverse = traverse.Children[index];
            }

            // return the flag to indicate if it is end of word or not.
            return traverse.IsEndOfWord;
        }
    }
}