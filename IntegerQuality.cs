using UnityEngine;

namespace CorvusRex.Unity
{
    public class IntegerQuality : Quality
    {
        [SerializeField]
        private int _value;

        private int _currentValue;

        public int CurrentValue => _currentValue;

        public void ApplyEffect(QualityEffect effect, int value)
        {
            switch(effect)
            {
                case QualityEffect.Reset:
                    SetValue(_value);
                    break;
                case QualityEffect.Set:
                    SetValue(value);
                    break;
                case QualityEffect.Increment:
                    SetValue(_currentValue + value);
                    break;
                case QualityEffect.Decrement:
                    SetValue(_currentValue - value);
                    break;
            }
        }

        private void SetValue(int value)
        {
            if(_currentValue != value)
            {
                _currentValue = value;
                NotifyChange();
            }
        }
    }
}
