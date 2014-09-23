using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Kipschieten.Model
{
    public class BlockingContainer<T>
    {
        T value;
        Semaphore block = new Semaphore(1, 1);

        public BlockingContainer()
        {

        }

        public void set(T value)
        {
            block.WaitOne();
            this.value = value;
            block.Release();
        }

        public T get()
        {
            block.WaitOne();
            T temp_value = value;
            value = default(T);
            block.Release();
            return temp_value;
        }

        public T peek()
        {
            return value;
        }
    }
}
