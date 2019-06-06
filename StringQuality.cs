using System;
using UnityEngine;

namespace CorvusRex.Unity
{
    public class StringQuality : Quality
    {
        [SerializeField]
        private string _value;

        private string _currentValue;

        public string CurrentValue => _currentValue;
        
        public void ApplyEffect(QualityEffect effect, string value)
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
