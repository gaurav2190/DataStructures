namespace DataStructures
{
    public class Trie
    {
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

        public TrieNode Root;

        public void Insert(string key)
        {
            var traverse = Root;

            foreach (var item in key)
            {
                var index = item - 'a';

                if(traverse.Children[index] == null)
                    traverse.Children[index] = new TrieNode();
                
                traverse = traverse.Children[index];
            }

            traverse.IsEndOfWord = true;
        }

        public bool Search(string key)
        {
            var traverse = Root;

            foreach (var item in key)
            {
                var index = item - 'a';

                if(traverse.Children[index]== null)
                    return false;
                traverse = traverse.Children[index];
            }

            return traverse.IsEndOfWord;
        }
    }
}