using UnityEditor;

namespace CorvusRex.Unity
{
    [CustomEditor(typeof(AffectQuality))]
    public class AffectQualityEditor : Editor
    {
        private SerializedProperty _qualityProperty;
        private SerializedProperty _effectProperty;
        private SerializedProperty _activateOnTriggerProperty;        
        private SerializedProperty _integerValueProperty;
        private SerializedProperty _booleanValueProperty;
        private SerializedProperty _stringValueProperty;

        public void OnEnable()
        {
            _qualityProperty = serializedObject.FindProperty("_quality");
            _effectProperty = serializedObject.FindProperty("_effect");
            _activateOnTriggerProperty = serializedObject.FindProperty("_activateOnTrigger");
            _integerValueProperty = serializedObject.FindProperty("_integerValue");
            _stringValueProperty = serializedObject.FindProperty("_stringValue");
            _booleanValueProperty = serializedObject.FindProperty("_booleanProperty");
        }

        public override void OnInspectorGUI()
        {
            EditorGUILayout.PropertyField(_qualityProperty);
            EditorGUILayout.PropertyField(_effectProperty);

            var quality = _qualityProperty.objectReferenceValue;

            if (quality is StringQuality)
                EditorGUILayout.PropertyField(_stringValueProperty);
            else if (quality is IntegerQuality)
                EditorGUILayout.PropertyField(_integerValueProperty);
            else if (quality is BooleanQuality)
                EditorGUILayout.PropertyField(_booleanValueProperty);

            EditorGUILayout.PropertyField(_activateOnTriggerProperty);
        }
    }
}
