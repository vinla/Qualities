using System;
using System.Linq;
using UnityEngine;

namespace VinlaTech.Unity
{
    public class BooleanGameProperty : GameProperty
    {
        [SerializeField]
        private bool _value;

        private bool _currentValue;

        public bool CurrentValue => _currentValue;
        
         public void Mutate(GamePropertyMutation mutation, bool value)
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

        public void SetValue(bool value)
        {
            if (_currentValue != value)
            {
                _currentValue = value;
                NotifyChange();
            }
        }
    }    
}
