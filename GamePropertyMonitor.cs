using System.Reflection;
using UnityEngine;

namespace VinlaTech.Unity
{
    public class GamePropertyMonitor : MonoBehaviour
    {
        [SerializeField]
        protected GameProperty _property;

        private PropertyInfo _propertyAccessor;

        private void OnEnable()
        {
            _property.AddListener(this);
            _propertyAccessor = _property.GetType().GetProperty("CurrentValue");
        }

        private void OnDisable()
        {
            _property.RemoveListener(this);
        }

        public virtual void OnPropertyChanged()
        {
            
        }

        public object GetPropertyValue()
        {
            return _propertyAccessor.GetValue(_property);
        }
    }
}
