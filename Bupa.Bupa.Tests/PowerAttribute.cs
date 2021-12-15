using System;

namespace Bupa.Bupa.Tests
{
    [AttributeUsage(AttributeTargets.Field)]
    public class PowerAttribute : Attribute
    {
        public int Value { get; set; }

        public PowerAttribute(int value, int life)
        {
            Value = value;
        }
    }
}
