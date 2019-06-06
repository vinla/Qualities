using System;

namespace CorvusRex.Unity
{
    public interface IConditional
    {
        bool Result { get; }
        event EventHandler OnConditionChanged;
    }
}
