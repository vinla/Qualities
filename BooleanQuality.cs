using System;
using System.Linq;
using UnityEngine;

namespace CorvusRex.Unity
{
    public class BooleanQuality : Quality
    {
        [SerializeField]
        private bool _value;

        private bool _currentValue;

        public bool CurrentValue => _currentValue;
        
         public void ApplyEffect(QualityEffect effect, bool value)
        {
            switch (effect)
            {
                case QualityEffect.Reset:
                    SetValue(_value);
                    break;
                case QualityEffect.Set:
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
