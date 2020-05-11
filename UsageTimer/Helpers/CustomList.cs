using System.Collections.Generic;
using System.Linq;

namespace Doghouse.Tools
{
    public class CustomList<T> : List<T>
    {
        private int _currentIndex = -1;

        public int CurrentIndex
        {

            get
            {
                if (_currentIndex == Count)
                {
                    _currentIndex = 0;
                }
                else if (_currentIndex > Count - 1)
                {
                    _currentIndex = Count - 1;
                }
                else if (_currentIndex < 0)
                {
                    _currentIndex = 0;
                }

                return _currentIndex;
            }

            set { _currentIndex = value; }
        }

        public T GetIndex(int index)
        {
            return this.ElementAtOrDefault(index);
        }

        public T MoveNext
        {
            get { _currentIndex++; return this[CurrentIndex]; }
        }

        public T Current
        {
            get { return this[CurrentIndex]; }
        }

        public T MovePrevious
        {
            get
            {
                if (_currentIndex == 0)
                {
                    _currentIndex = Count - 1;
                }
                else
                {
                    _currentIndex--;
                }
                return this[CurrentIndex];
            }
        }
    }
}
