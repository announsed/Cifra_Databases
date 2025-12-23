using System;
using System.Runtime.InteropServices.Marshalling;

namespace WebApplicationWether
{
    public interface IRandomService<T>
    {
        public T GetRandom<T>();
    }

}
