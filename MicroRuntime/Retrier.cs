using System;
using System.Threading;
using System.Threading.Tasks;


namespace Microruntime
{
    public class Retrier
    {
        

        public V Try<T,V>(Func<T,V> a, T t, int retries = 3, int sleepInterval = 1000)
        {
            return ExecuteWithRetry(a,t, retries, sleepInterval);
        }

        
        public T Try<T>(Func<T> a, int retries = 3, int sleepInterval = 1000)
        {
            return ExecuteWithRetry(a, retries, sleepInterval);
        }
       
        
        public void Try(Action a, int retries = 3, int sleepInterval = 1000)
        {
            ExecuteWithRetry(a, retries, sleepInterval);
        }

        
      
        private T ExecuteWithRetry<T>(Func<T> a, int retries = 3, int sleepInterval = 1000)
        {
            for (int i = 0; i < retries; i++)
            {
                try
                {
                    return a();
                }
                catch (Exception)
                {
                    if (i + 1  == retries)
                    {
                        throw;
                    }

                    Thread.Sleep(sleepInterval);
                }
            }

            return default(T);
        }
        

        private V ExecuteWithRetry<T,V>(Func<T,V> a,T t, int retries = 3, int sleepInterval = 1000)
        {
            for (int i = 0; i < retries; i++)
            {
                try
                {
                    return a.Invoke(t);
                }
                catch (Exception)
                {
                    if (i + 1  == retries)
                    {
                        throw;
                    }

                    Thread.Sleep(sleepInterval);
                }
            }

            return default(V);
        }

        
        private  void ExecuteWithRetry(Action a, int retries, int sleepInterval)
        {
            for (int i = 0; i < retries; i++)
            {
                try
                {
                    a();
                }
                catch (Exception ex)
                {
                    if (i +1 == retries)
                    {
                        throw;
                    }

                    Thread.Sleep(sleepInterval);
                }
            }
        }



    }
}