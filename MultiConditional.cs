using System;
using System.Linq;
using UnityEngine;
using UnityEngine.Events;

namespace CorvusRex.Unity
{
    public class MultiConditional : MonoBehaviour
    {
        [SerializeField]
        private MultiConditionalOperator _condition;

        [SerializeField]
        private IConditional[] _dependantConditions;

        [SerializeField]
        private UnityEvent _action;

        private bool _result;

        public void OnEnable()
        {
            foreach(var dependant in _dependantConditions)
                dependant.OnConditionChanged += DependantConditionChanged;
        }

        public void OnDisable()
        {
            foreach(var dependant in _dependantConditions)
                dependant.OnConditionChanged -= DependantConditionChanged;
        }

        public event EventHandler ConditionChanged;

        protected virtual void OnConditionChanged()
        {
            var handler = ConditionChanged;
            handler?.Invoke(this, EventArgs.Empty);
        }

        private void DependantConditionChanged(object sender, EventArgs e)
        {
            var incomingResult = Evaluate();
            if (incomingResult != _result)
            {
                _result = incomingResult;
                if (_result && _action != null)
                    _action.Invoke();                
            }
        }

        private bool Evaluate()
        {
            switch(_condition)
            {
                case MultiConditionalOperator.AllTrue:
                    return _dependantConditions.All(e => e.Result);
                case MultiConditionalOperator.AnyTrue:
                    return _dependantConditions.Any(e => e.Result);
                case MultiConditionalOperator.AllFalse:
                    return _dependantConditions.All(e => !e.Result);
                case MultiConditionalOperator.AnyFalse:
                    return _dependantConditions.Any(e => !e.Result);
                default:
                    throw new NotSupportedException("Unsupported condition");
            }
        }
    }
}
