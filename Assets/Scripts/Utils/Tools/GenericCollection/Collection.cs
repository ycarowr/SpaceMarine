using System;
using System.Collections.Generic;
using Random = UnityEngine.Random;

namespace Tools
{
    /// <summary>
    ///     Class that wraps some of the List and add some Linq functionality without garbage generation
    /// </summary>
    /// <typeparam name="T"></typeparam>
    public class Collection<T> where T : class
    {
        //public clean constructor
        public Collection()
        {
            Units = new List<T>();
        }

        /// <summary>
        ///     Consider change it to an Array of Objects
        /// </summary>
        /// <param name="units"></param>
        public Collection(List<T> units)
        {
            Units = new List<T>();
            Add(units);
        }

        //units of the collection
        public List<T> Units { get; }

        public int Size => Units.Count;

        public override string ToString()
        {
            var s = string.Empty;
            foreach (var c in Units)
                s += c + ", ";
            return s;
        }

        public class CollectionArgumentException : ArgumentException
        {
            public CollectionArgumentException(string message) : base(message)
            {
            }
        }

        #region Operations

        /// <summary>
        ///     Clear the list completely. You lose all the references, however
        ///     the elements are still in memory waiting for the Garbage Collector to clean
        /// </summary>
        public virtual void Restart()
        {
            Units.Clear();
        }

        /// <summary>
        ///     Add elements to the collection. Null and duplicated elements raises Exceptions.
        /// </summary>
        /// <param name="unit"></param>
        public void Add(T unit)
        {
            if (unit == null)
                throw new CollectionArgumentException("Null is not a valid type of unit inside the collection");

            if (!Has(unit))
                Units.Add(unit);
            else
                throw new CollectionArgumentException("Unit already inside the collection");
        }

        /// <summary>
        ///     Add a group of elements to the list. It falls back to Add(T unit) method. Null raises an Exception.
        /// </summary>
        /// <param name="units"></param>
        public void Add(List<T> units)
        {
            if (units == null)
                throw new CollectionArgumentException("Null is not a valid type of unit inside the collection");

            for (var i = 0; i < units.Count; i++)
                Add(units[i]);
        }

        /// <summary>
        ///     Check if the collection has an unit inside.
        /// </summary>
        /// <param name="unit"></param>
        /// <returns></returns>
        public bool Has(T unit)
        {
            return Units.Contains(unit);
        }

        /// <summary>
        ///     Remove element from the collection and returns whether the element has been successfully removed or not.
        /// </summary>
        /// <param name="unit"></param>
        /// <returns></returns>
        public bool Remove(T unit)
        {
            return Units.Remove(unit);
        }

        /// <summary>
        ///     Shuffles the collection using Fisher Yates algorithm: https://en.wikipedia.org/wiki/Fisher%E2%80%93Yates_shuffle.
        /// </summary>
        public void Shuffle()
        {
            var n = Size;
            for (var i = 0; i <= n - 2; i++)
            {
                //random index
                var rdn = Random.Range(0, n - i);

                //swap positions
                var curVal = Units[i];
                Units[i] = Units[i + rdn];
                Units[i + rdn] = curVal;
            }
        }

        /// <summary>
        ///     Get and Remove an element randomly from the collection.
        ///     If the collection is empty it returns Null. Falls back to Remove.
        /// </summary>
        /// <returns></returns>
        public T GetAndRemoveRandom()
        {
            if (Size <= 0)
                return null;

            var rdn = Random.Range(0, Units.Count);
            var unit = Units[rdn];
            Remove(unit);
            return unit;
        }

        /// <summary>
        ///     Get an element randomly from the collection.
        ///     If the collection is empty it returns Null.
        /// </summary>
        /// <returns></returns>
        public T GetRandom()
        {
            if (Size <= 0)
                return null;

            var rdn = Random.Range(0, Units.Count);
            var unit = Units[rdn];
            return unit;
        }

        /// <summary>
        ///     Get an element from an specific position.
        ///     Raises an exception if the index is negative or bigger than the
        ///     size of the collection. 
        /// </summary>
        /// <param name="index"></param>
        /// <returns></returns>
        public T Get(int index)
        {
            if (index >= Size || index < 0)
                throw new IndexOutOfRangeException();

            var unit = Units[index];
            return unit;
        }

        /// <summary>
        ///     Get and Remove an element from an specific position.
        ///     Raises an exception if the index is negative or bigger than the
        ///     size of the collection. Falls back to Remove.
        /// </summary>
        /// <param name="index"></param>
        /// <returns></returns>
        public T GetAndRemove(int index)
        {
            var unit = Get(index);
            Remove(unit);
            return unit;
        }

        /// <summary>
        ///     Get and Remove the last element from the collection.
        /// </summary>
        /// <returns></returns>
        public T GetLastAndRemove()
        {
            var lastIndex = Size - 1;
            return GetAndRemove(lastIndex);
        }

        /// <summary>
        ///     Clears the list.
        /// </summary>
        public void Clear()
        {
            Units.Clear();
        }

        #endregion
    }
}