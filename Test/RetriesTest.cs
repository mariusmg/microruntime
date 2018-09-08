using System;
using Microruntime;
using Xunit;

namespace Tests
{
    public class RetriesTest
    {
        
        [Fact]
        public void RetryWithGeneneric()
        {
            Assert.Throws<DivideByZeroException>(() =>
            {

                Func<int> gg = () =>
                {
                    int k = 3;
                    int j = 0;
                    int f = k / j;


                    return f;
                };
                                
                new Retrier().Try(gg);
            });
        }
        
        

        [Fact]
        public void RetrySimpleAction()
        {
            Assert.Throws<DivideByZeroException>(() =>
            {
                new Retrier().Try(() =>
                {
                    int k = 3;
                    int j=0;
                    int f =k / j;
                });
            });
            
            
        }
    }
}