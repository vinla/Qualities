using System.Collections.Generic;
using UnityEngine;

namespace CorvusRex.Unity
{
    public abstract class Quality : ScriptableObject
    {
        private List<QualityMonitor> _monitors = new List<QualityMonitor>();

        protected void NotifyChange()
        {
            foreach(var monitor in _monitors)
                monitor.OnQualityChanged();
        }

        public void AddListener(QualityMonitor monitor)
        {
            _monitors.Add(monitor);
        }

        public void RemoveListener(QualityMonitor monitor)
        {
            _monitors.Remove(monitor);
        }
    }    
}
