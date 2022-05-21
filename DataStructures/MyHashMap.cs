using System.Collections.Generic;

namespace DataStructures
{
    /// <summary>
    /// A very basic implementation of hashmap.
    /// </summary>
    public class MyHashMap {
    
    public LinkedList<Entry>[] table; 
    public MyHashMap() {
        table = new LinkedList<Entry>[100];
    }
    
    public void Put(int key, int value) {
        var newEntry = new Entry(key, value);

        var index = this.GetIndex(key.GetHashCode());

        var entry = this.SeekEntry(index, key);

        if(entry == null)
        {
            if(this.table[index]==null)
            {
                this.table[index] = new LinkedList<Entry>();
            }
            this.table[index].AddLast(newEntry);
        }
        else
        {
            entry.Value = value;
        }
    }
    
    public int Get(int key) {
        var index = this.GetIndex(key.GetHashCode());

        var entry = this.SeekEntry(index, key);

        if(entry != null)
        {
            return entry.Value;
        }

        return -1;
    }
    
    public void Remove(int key) {
        var index = this.GetIndex(key.GetHashCode());
        
        var entry = this.SeekEntry(index, key);

        if(entry != null)
        {
            this.table[index].Remove(entry);
        }        
    }

    public int GetIndex(int hashKey)
    {
        return hashKey%100;
    }

    public Entry SeekEntry(int index, int key)
    {
        var bucket = this.table[index];

        if(bucket != null)
        {
            foreach(var entry in bucket)
            {
                if(entry.Key == key)
                {
                    return entry;
                }
            }
        }

        return null;
    }
}
    public class Entry{

        public Entry(int key, int value)
        {
            this.Key = key;
            this.Value = value;
            this.HashValue = this.Key.GetHashCode();
        }
        public int Key { get; set; }

        public int Value { get; set; }

        public int HashValue { get; set; }
    }
    
}