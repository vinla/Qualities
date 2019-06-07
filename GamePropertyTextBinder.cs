using UnityEngine;
using UnityEngine.UI;

namespace VinlaTech.Unity
{
    public class GamePropertyTextBinder : GamePropertyMonitor
    {
        [SerializeField]
        private Text _boundText;

        [SerializeField]
        private string _format;

        public override void OnPropertyChanged()
        {
            var format = "{0}";
            if (string.IsNullOrEmpty(_format) == false)
                format = _format;
            _boundText.text = string.Format(format, GetPropertyValue());
        }

    }
}
