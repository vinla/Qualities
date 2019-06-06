using UnityEngine;

namespace CorvusRex.Unity
{
    public class AffectQuality : MonoBehaviour
    {
        [SerializeField]
        private QualityEffect _effect;

        [SerializeField]
        private int _integerValue;

        [SerializeField]
        private bool _booleanValue;

        [SerializeField]
        private string _stringValue;

        [SerializeField]
        protected Quality _quality;

        [SerializeField]
        private bool _activateOnTrigger;

        public void ApplyEffect()
        {
            if ( _quality is BooleanQuality boolQuality)
                boolQuality.ApplyEffect(_effect, _booleanValue);
            else if( _quality is IntegerQuality integerQuality)
                integerQuality.ApplyEffect(_effect, _integerValue);
            else if( _quality is StringQuality stringQuality)
                stringQuality.ApplyEffect(_effect, _stringValue);
        }

        private void OnTriggerEnter2D(Collider2D collider)
        {
            if (_activateOnTrigger)
                ApplyEffect();
        }        
    }
}
