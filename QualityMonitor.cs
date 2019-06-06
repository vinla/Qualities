using UnityEngine;

namespace CorvusRex.Unity
{
    public class QualityMonitor : MonoBehaviour
    {
        [SerializeField]
        protected Quality _target;

        private void OnEnable()
        {
            _target.AddListener(this);
        }

        private void OnDisable()
        {
            _target.RemoveListener(this);
        }

        public virtual void OnQualityChanged()
        {
            
        }
    }
}
