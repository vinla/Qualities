using UnityEngine;
using UnityEngine.Events;

namespace VinlaTech.Unity
{
    public class GamePropertyConditionalActivator : GamePropertyCondition
    {
        [SerializeField]
        private GameObject _target;        

        protected override void OnConditionChanged()
        {
            base.OnConditionChanged();
            _target.SetActive(Result);
        }
    }
}
