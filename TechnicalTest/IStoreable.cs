using System;

namespace Interview
{
    public interface IStoreable
    {
        IComparable Id { get; set; }
        String Name { get; set; }
    }
    
}