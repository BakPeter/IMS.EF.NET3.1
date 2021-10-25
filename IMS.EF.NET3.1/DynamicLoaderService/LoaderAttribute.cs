using System;
using System.Collections.Generic;
using System.Text;

namespace DynamicLoaderService
{
    public enum Policy
    {
        Transient,
        Scoped,
        Singelton
    }

    public class LoaderAttribute : Attribute
    {
        public Type InterfaceType { get; private set; }
        public Type ImplementationType { get; private set; }
        public Policy Policy { get; set; }
    }
}
