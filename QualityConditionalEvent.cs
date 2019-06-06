using System;
using UnityEngine;

namespace CorvusRex.Unity
{
    public class QualityConditionalEvent : QualityEvent
    {
        [SerializeField]
        private ConditionalOperator _operator;

        [SerializeField]
        private int _integerValue;

        [SerializeField]
        private string _stringValue;

        [SerializeField]
        private bool _booleanValue;

        private bool _result;

        public event EventHandler ConditionChanged;

        public bool Result => _result;

        public override void OnQualityChanged()
        {            
            var incomingResult = Evaluate();
            if (incomingResult != _result)
            {
                _result = incomingResult;
                if (_result && _action != null)
                    _action.Invoke();
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
            if ( _target is BooleanQuality boolQuality)
                return EvaluateBoolQuality(boolQuality, _operator, _booleanValue);
            else if( _target is IntegerQuality integerQuality)
                return EvaluateIntegerQuality(integerQuality, _operator, _integerValue);
            else if( _target is StringQuality stringQuality)
                return EvaluateStringQuality(stringQuality, _operator, _stringValue);

            throw new NotSupportedException("Unsupported quality type");
        }

        private bool EvaluateStringQuality(StringQuality quality, ConditionalOperator @operator, string value)        
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

        private bool EvaluateIntegerQuality(IntegerQuality quality, ConditionalOperator @operator, int value)
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

        private bool EvaluateBoolQuality(BooleanQuality quality, ConditionalOperator @operator, bool value)
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
