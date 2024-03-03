using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataStructures.Retry_Pattern
{
    public class Policy<TException> where TException : Exception
    {
        private readonly Func<Action, Action> policy;

        private Policy(Func<Action, Action> policy)
        {
            this.policy = policy;
        }

        public static Policy<TException> Handle<T>()
            where T : TException
        {
            return new Policy<TException>(action => () =>
            {
                try
                {
                    action();
                }
                catch (T exception)
                {
                    Console.WriteLine($"Handling {typeof(T).Name} exception");
                    throw;
                }
            });
        }

        public Policy<TException> Retry(int retryCount)
        {
            return new Policy<TException>(action => () =>
            {
                int retries = 0;
                while (true)
                {
                    try
                    {
                        action();
                        return;
                    }
                    catch (TException exception)
                    {
                        retries++;
                        if (retries > retryCount)
                        {
                            Console.WriteLine($"Reached maximum retry count. Rethrowing {typeof(TException).Name} exception");
                            throw;
                        }

                        Console.WriteLine($"Retrying... Retry Count: {retries}");
                    }
                }
            });
        }

        public void Execute(Action action)
        {
            policy(action)();
        }
    }

    //public static class Program
    //{
    //    public static void FirstSimulationMethod()
    //    {
    //        // Simulate some operation
    //        throw new ArgumentException("Invalid argument");
    //    }

    //    public static void Main()
    //    {
    //        var policy = Policy<ArgumentException>
    //            .Handle<ArgumentException>()
    //            .Retry(3);

    //        policy.Execute(FirstSimulationMethod);
    //    }
    //}

}
