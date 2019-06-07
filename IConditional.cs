using System;

namespace VinlaTech.Unity
{
    public interface IConditional
    {
        bool Result { get; }
        event EventHandler OnConditionChanged;
    }
}
