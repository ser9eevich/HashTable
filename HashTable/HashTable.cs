using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HashTable
{
    class HashItem
    {
        public int HashCode;
        public object Value;
        public HashItem(int hash, object value)
        {
            HashCode = hash;
            Value = value;
        }
    }
    class HashTable
    {
        private List<HashItem>[] HashInfo;

        public HashTable(int size)
        {
            HashInfo = new List<HashItem>[size];
        }

        public void PutPair(object key, object value)
        {
            var hashCode = key.GetHashCode();
            int index;

            if (hashCode < 0)
                index = (-hashCode) % HashInfo.Length;
            else
                index = hashCode % HashInfo.Length;

            if (HashInfo[index] == null)
                HashInfo[index] = new List<HashItem> { new HashItem(hashCode, value) };
            else
            {
                var element = HashInfo[index];
                if (element.FirstOrDefault(e => e.HashCode == hashCode) == null)
                    HashInfo[index].Add(new HashItem(hashCode, value));
                else
                    element.FirstOrDefault(e => e.HashCode == hashCode).Value = value;
            }
        }

        public object GetValueByKey(object key)
        {
            var hashCode = key.GetHashCode();
            int index;

            if (hashCode < 0)
                index = (-hashCode) % HashInfo.Length;
            else
                index = hashCode % HashInfo.Length;

            if (HashInfo[index] == null)
                return null;

            foreach (var list in HashInfo[index])
            {
                if (list.HashCode == hashCode)
                    return list.Value;
            }
            return null;
        }
    }
}
