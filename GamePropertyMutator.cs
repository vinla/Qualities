using UnityEngine;

namespace VinlaTech.Unity
{
    public class GamePropertyMutator : MonoBehaviour
    {
        [SerializeField]
        private GamePropertyMutation _mutation;

        [SerializeField]
        private int _integerValue;

        [SerializeField]
        private bool _booleanValue;

        [SerializeField]
        private string _stringValue;

        [SerializeField]
        protected GameProperty _property;

        [SerializeField]
        private bool _activateOnTrigger;

        public void ApplyMutation()
        {
            if ( _property is BooleanGameProperty booleanProperty)
                booleanProperty.Mutate(_mutation, _booleanValue);
            else if( _property is IntegerGameProperty integerProperty)
                integerProperty.Mutate(_mutation, _integerValue);
            else if( _property is StringGameProperty stringProperty)
                stringProperty.Mutate(_mutation, _stringValue);
        }

        private void OnTriggerEnter2D(Collider2D collider)
        {
            if (_activateOnTrigger)
                ApplyMutation();
        }        
    }
}
