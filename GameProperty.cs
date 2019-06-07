using System.Collections.Generic;
using UnityEngine;

namespace VinlaTech.Unity
{
    public abstract class GameProperty : ScriptableObject
    {
        private List<GamePropertyMonitor> _monitors = new List<GamePropertyMonitor>();

        protected void NotifyChange()
        {
            foreach(var monitor in _monitors)
                monitor.OnPropertyChanged();
        }

        public void AddListener(GamePropertyMonitor monitor)
        {
            _monitors.Add(monitor);
        }

        public void RemoveListener(GamePropertyMonitor monitor)
        {
            _monitors.Remove(monitor);
        }
    }    
}
