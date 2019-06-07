using UnityEngine;

namespace VinlaTech.Unity
{
    public class ImplicitMutatorGroup : MonoBehaviour
    {
        public void ApplyAll()
        {
            var mutators = gameObject.GetComponents<GamePropertyMutator>();
            foreach(var mutator in mutators)
                mutator.ApplyMutation();
        }
    }
}
