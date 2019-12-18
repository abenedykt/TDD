using System;

namespace LegacyExcercise
{
    public interface IPerson
    {
        DateTime Hired { get; set; }
        bool IsManager { get; set; }
        string Name { get; set; }
        string Surname { get; set; }
    }
}