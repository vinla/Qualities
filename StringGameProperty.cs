using System;
using UnityEngine;

namespace VinlaTech.Unity
{
    public class StringGameProperty : GameProperty
    {
        [SerializeField]
        private string _value;

        private string _currentValue;

        public string CurrentValue => _currentValue;
        
        public void Mutate(GamePropertyMutation mutation, string value)
        {
            switch (mutation)
            {
                case GamePropertyMutation.Reset:
                    SetValue(_value);
                    break;
                case GamePropertyMutation.Set:
                    SetValue(value);
                    break;
                default:
                    throw new NotSupportedException("effect cannot be applied to boolean quality");
            }
        }

        public void SetValue(string value)
        {
            if (_currentValue != value)
            {
                _currentValue = value;
                NotifyChange();
            }
        }        
    }
}
