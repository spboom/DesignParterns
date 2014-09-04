using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Kipschieten.Model
{
    class BlockingContainer<T>
    {
        T value;
        Semaphore block = new Semaphore(1, 1);
        Semaphore canGet = new Semaphore(0, 1);

        public BlockingContainer()
        {
            
        }

        public void set(T value)
        {
            block.WaitOne();
            if(this.value != null)
            {
                canGet.WaitOne();
            }
            this.value = value;
            block.Release();
            canGet.Release();
        }

        public T get()
        {
            canGet.WaitOne();
            block.WaitOne();
            T temp_value = value;
            value = default(T);
            block.Release();
            return temp_value;
        }
    }
}
