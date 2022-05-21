using System.Collections.Generic;

namespace DataStructures
{
    public class Entry<K, V>
    {
        public K Key;

        public V Value;

        public int HashValue;
        public Entry(K key, V value)
        {
            this.Key = key;
            this.Value = value;
            this.HashValue = this.Key.GetHashCode();
        }

        public bool IsEqualTo(Entry<K, V> other)
        {
            if(this.HashValue == other.HashValue)
                return true;
            return this.Key.Equals(other.Key);
        }
    }

    public class HashMapSeparateChaining<K,V> {
        private int Capacity;
        private int Size;

        private LinkedList<Entry<K, V>>[] table;
        public HashMapSeparateChaining()
        {
            this.Capacity = 10;
            this.Size = 0;
            this.table = new LinkedList<Entry<K, V>>[this.Capacity];
        }

        public int NormalizeIndex(int keyHash)
        {
            return (keyHash & 0x7FFFFFFF)%this.Capacity;
        } 

        public bool HasKey(K key)
        {
            var hash = this.NormalizeIndex(key.GetHashCode());
            var entry = this.SeekEntry(hash, key);
            if(entry!=null)
                return true;
            return false;
        }

        public Entry<K,V> SeekEntry(int index, K key)
        {
            var bucket = this.table[index];

            if(bucket == null) return null;

            foreach(var entry in bucket)
            {
                if(entry.Key.Equals(entry.Key))
                    return entry;
            }

            return null;
        }

        public V Insert(Entry<K, V> entry)
        {
            var index = this.NormalizeIndex(entry.HashValue);
            var bucket = this.table[index];

            if(bucket == null)
            {
                bucket = new LinkedList<Entry<K, V>>();
            }

            var existingEntry = this.SeekEntry(index, entry.Key);

            if(existingEntry == null)
            {
                bucket.AddLast(entry);
                this.Size++;
                return default(V);
            }
            else
            {
                V oldValue = existingEntry.Value;
                existingEntry.Value = entry.Value;

                return oldValue;
            }
        }

        public V Remove(K key)
        {
            var index = this.NormalizeIndex(key.GetHashCode());

            var entry = this.SeekEntry(index, key);

            if(entry != null)
            {
                this.table[index].Remove(entry);
                this.Size--;
                return entry.Value;
            }

            return default(V);
        }

        public V Get(K key)
        {
            var index = this.NormalizeIndex(key.GetHashCode());

            var entry = this.SeekEntry(index, key);

            if(entry != null)
            {
                return entry.Value;
            }

            return default(V);
        }
    }
}