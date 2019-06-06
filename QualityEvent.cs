using UnityEngine;
using UnityEngine.Events;

namespace CorvusRex.Unity
{
    public class QualityEvent : QualityMonitor
    {
        [SerializeField]
        protected UnityEvent _action;

        public override void OnQualityChanged()
        {
            _action.Invoke();
        }
    }
}
