using System;
using UnityEngine;

namespace VinlaTech.Unity
{
    public class GamePropertyCondition : GamePropertyMonitor
    {
        [SerializeField]
        private ConditionalOperator _operator;

        [SerializeField]
        private int _integerValue;

        [SerializeField]
        private string _stringValue;

        [SerializeField]
        private bool _booleanValue;

        private bool? _result;

        public event EventHandler ConditionChanged;

        public bool Result => _result.GetValueOrDefault();

        public void OnEnable()
        {
            OnPropertyChanged();
        }

        public override void OnPropertyChanged()
        {            
            var incomingResult = Evaluate();
            if (incomingResult != _result)
            {
                _result = incomingResult;
                OnConditionChanged();
            }            
        }

        protected virtual void OnConditionChanged()
        {
            var handler = ConditionChanged;
            handler?.Invoke(this, EventArgs.Empty);
        }

        private bool Evaluate()
        {
            if ( _property is BooleanGameProperty booleanProperty)
                return EvaluateBoolean(booleanProperty, _operator, _booleanValue);
            else if( _property is IntegerGameProperty integerGameProperty)
                return EvaluateInteger(integerGameProperty, _operator, _integerValue);
            else if( _property is StringGameProperty stringProperty)
                return EvaluateString(stringProperty, _operator, _stringValue);

            throw new NotSupportedException("Unsupported quality type");
        }

        private bool EvaluateString(StringGameProperty quality, ConditionalOperator @operator, string value)        
        {
            switch(_operator)
            {
                case ConditionalOperator.NotEqualTo:
                    return quality.CurrentValue != value;
                case ConditionalOperator.EqualTo:
                    return quality.CurrentValue == value;                
                default:
                    throw new NotSupportedException("Opertor not supported");
            }
        }

        private bool EvaluateInteger(IntegerGameProperty quality, ConditionalOperator @operator, int value)
        {
            switch(_operator)
            {
                case ConditionalOperator.NotEqualTo:
                    return quality.CurrentValue != value;
                case ConditionalOperator.EqualTo:
                    return quality.CurrentValue == value;
                case ConditionalOperator.GreaterThan:
                    return quality.CurrentValue > value;
                case ConditionalOperator.LessThan:
                    return quality.CurrentValue < value;
                default:
                    throw new NotSupportedException("Opertor not supported");
            }
        }

        private bool EvaluateBoolean(BooleanGameProperty quality, ConditionalOperator @operator, bool value)
        {
            switch(_operator)
            {
                case ConditionalOperator.NotEqualTo:
                    return quality.CurrentValue != value;
                case ConditionalOperator.EqualTo:
                    return quality.CurrentValue == value;                
                default:
                    throw new NotSupportedException("Opertor not supported");
            }
        }
    }
}
