using System;
using System.Collections.Generic;
using System.Globalization;

namespace Runner.Components
{
    public class Collection<Type> : List<Type> where Type : class, new()
    {
        public string Name { get; set; }
        protected int current;

        public Collection()
        {
            current = -1;
        }

        public bool MoveNext()
        {
            if (current < this.Count - 1)
            {
                current += 1;
                if (this[current] != null)
                    return true;
            }
            return false;
        }

        public bool MovePrevious()
        {
            if (current <= 0)
            {
                return false;
            }
            current -= 1;
            if (CurrentItem != null)
                return true;
            return false;
        }

        /// <summary>
        /// Returns the current Item.
        /// Items:
        /// </summary>
        public Type CurrentItem
        {
            get
            {
                if (current < 0 || current > this.Count)
                {
                    return null;
                }
                return this[current];
            }
        }

        public void AddItem(Type item)
        {
            ++current;
            this.Add(item);
        }


        public void RemoveItem(Type item)
        {
            this.Remove(item);
            --current;
        }


        public bool Contains(string name)
        {
            foreach (Type type in this)
            {
                if (type.ToString().CompareTo(name) == 0)
                {
                    return true;
                }
            }
            return false;
        }
    }
}