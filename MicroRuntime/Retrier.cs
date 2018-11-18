using System;
using System.Threading;


namespace Microruntime
{
    public class Retrier
    {
        public V Try<T, V>(Func<T, V> a, T t, int retries = 3, int sleepInterval = 1000,
            bool increaseTimeoutOnEachRetry = false)
        {
            return ExecuteWithRetry(a, t, retries, sleepInterval, increaseTimeoutOnEachRetry);
        }


        public T Try<T>(Func<T> a, int retries = 3, int sleepInterval = 1000, bool increaseTimeoutOnEachRetry = false)
        {
            return ExecuteWithRetry(a, retries, sleepInterval, increaseTimeoutOnEachRetry);
        }


        public void Try(Action a, int retries = 3, int sleepInterval = 1000, bool increaseTimeoutOnEachRetry = false)
        {
            ExecuteWithRetry(a, retries, sleepInterval, increaseTimeoutOnEachRetry);
        }


        public void Try<T>(Action a, T exception, int retries = 3, int sleepInterval = 1000,
            bool increaseTimeoutOnEachRetry = false) where T : Exception
        {
            ExecuteWithRetry(a, exception, retries, sleepInterval, increaseTimeoutOnEachRetry);
        }


        private T ExecuteWithRetry<T>(Func<T> a, int retries = 3, int sleepInterval = 1000,
            bool increaseTimeoutOnEachRetry = false)
        {
            for (int i = 0; i < retries; i++)
            {
                try
                {
                    return a();
                }
                catch (Exception)
                {
                    if (i + 1 == retries)
                    {
                        throw;
                    }

                    Thread.Sleep(GetWaitingTime(i, sleepInterval, increaseTimeoutOnEachRetry));
                }
            }

            return default(T);
        }


        private V ExecuteWithRetry<T, V>(Func<T, V> a, T t, int retries = 3, int sleepInterval = 1000,
            bool increaseTimeoutOnEachRetry = false)
        {
            for (int i = 0; i < retries; i++)
            {
                try
                {
                    return a.Invoke(t);
                }
                catch (Exception)
                {
                    if (i + 1 == retries)
                    {
                        throw;
                    }

                    Thread.Sleep(GetWaitingTime(i, sleepInterval, increaseTimeoutOnEachRetry));
                }
            }

            return default(V);
        }


        private void ExecuteWithRetry<T>(Action a, T t, int retries, int sleepInterval,
            bool increaseTimeoutOnEachRetry = false) where T : Exception
        {
            for (int i = 0; i < retries; i++)
            {
                try
                {
                    a();
                }
                catch (Exception ex)
                {
                    if (ex.GetType() == typeof(T))
                    {
                        if (i + 1 == retries)
                        {
                            throw;
                        }

                        Thread.Sleep(GetWaitingTime(i, sleepInterval, increaseTimeoutOnEachRetry));
                    }
                    else
                    {
                        throw;
                    }
                }
            }
        }


        private void ExecuteWithRetry(Action a, int retries, int sleepInterval, bool increaseTimeoutOnEachRetry = false)
        {
            for (int i = 0; i < retries; i++)
            {
                try
                {
                    a();
                }
                catch (Exception ex)
                {
                    if (i + 1 == retries)
                    {
                        throw;
                    }

                    Thread.Sleep(GetWaitingTime(i, sleepInterval, increaseTimeoutOnEachRetry));
                }
            }
        }


        private int GetWaitingTime(int retry, int timeout, bool isIncreasedOnEachRetry)
        {
            if (isIncreasedOnEachRetry)
            {
                if (retry > 0 && timeout > 0)
                {
                    return retry * timeout;
                }

                return timeout;
            }

            return timeout;
        }
    }
}