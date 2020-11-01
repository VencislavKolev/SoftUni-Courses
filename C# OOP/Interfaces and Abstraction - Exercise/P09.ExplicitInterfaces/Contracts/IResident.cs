using System;
using System.Collections.Generic;
using System.Text;

namespace P09.ExplicitInterfaces.Contracts
{
    public interface IResident
    {
        string Name { get; }
        string Country { get; }
        string GetName();

    }
}
