using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NUnit.Framework;

namespace HashTable
{
    [TestFixture]
    class HashTableTests
    {
        [Test]
        public void ThreeElements()
        {
            var hashTable = new HashTable(3);
            var arr = new int[] { 1, 2, 3 };

            hashTable.PutPair(1, "message");
            hashTable.PutPair("key", 'c');
            hashTable.PutPair(228, arr);

            Assert.AreEqual("message", hashTable.GetValueByKey(1));
            Assert.AreEqual('c', hashTable.GetValueByKey("key"));
            Assert.AreEqual(arr, hashTable.GetValueByKey(228));
        }
        [Test]
        public void SameElements()
        {
            var hashTable = new HashTable(2);

            hashTable.PutPair("super key", "message");
            hashTable.PutPair("super key", "second message");

            Assert.AreEqual("second message", hashTable.GetValueByKey("super key"));
        }
        [Test]
        public void TenThousandsElements()
        {
            var hashTable = new HashTable(10000);
            var rnd = new Random();
            var randomValue = rnd.Next();

            for (int i = 0; i < 10000; i++)
            {
                if (i == 578) //взял случайное i
                    hashTable.PutPair("" + i, randomValue);
                else
                    hashTable.PutPair("" + i, rnd.Next());
            }

            Assert.AreEqual(randomValue, hashTable.GetValueByKey("578"));
        }
        [Test]
        public void TenThousandsElementsAndOtherKeys()
        {
            var hashTable = new HashTable(10000);
            var rnd = new Random();
            var randomValue = rnd.Next();

            for (int i = 0; i < 10000; i++)
            {
                hashTable.PutPair("" + i, rnd.Next());
            }

            for (int i = 0; i < 1000; i++)
                Assert.AreEqual(null, hashTable.GetValueByKey(i));
        }
    }
}
