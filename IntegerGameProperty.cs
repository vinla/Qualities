using UnityEngine;

namespace VinlaTech.Unity
{
    public class IntegerGameProperty : GameProperty
    {
        [SerializeField]
        private int _value;

        private int _currentValue;

        public int CurrentValue => _currentValue;

        public void Mutate(GamePropertyMutation mutation, int value)
        {
            switch(mutation)
            {
                case GamePropertyMutation.Reset:
                    SetValue(_value);
                    break;
                case GamePropertyMutation.Set:
                    SetValue(value);
                    break;
                case GamePropertyMutation.Add:
                    SetValue(_currentValue + value);
                    break;
                case GamePropertyMutation.Subtract:
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
