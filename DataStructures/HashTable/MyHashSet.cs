namespace DataStructures
{
    using System.Collections;
    using System.Collections.Generic;
    
    public class MyHashSet {
    public LinkedList<int>[] table;
    
    public MyHashSet() {
        this.table = new LinkedList<int>[100];
    }
    
    public void Add(int key) {
        if(!this.Contains(key))
            {
                var index = this.GetIndex(key);
                
                if(this.table[index] == null)
                    this.table[index] = new LinkedList<int>();
                
                this.table[index].AddLast(key);
            }
    }
    
    public void Remove(int key) {
        if(this.Contains(key))
            {
                var index = this.GetIndex(key);
                
                this.table[index].Remove(key);
            }
    }
    
    public bool Contains(int key) {
        var index = this.GetIndex(key);
            
            if(this.table[index] != null)
            {
                foreach(var val in this.table[index])
                {
                    if(val == key)
                    {
                        return true;
                    }
                }
            }            

            return false;
    }
    
    public int GetIndex(int key)
        {
            return key.GetHashCode() % 100;
        }
    }
}