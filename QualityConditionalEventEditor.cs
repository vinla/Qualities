using UnityEditor;

namespace CorvusRex.Unity
{
    [CustomEditor(typeof(QualityConditionalEvent))]
    public class QualityConditionalEventEditor : Editor
    {
        private SerializedProperty _targetProperty;
        private SerializedProperty _operatorProperty;
        private SerializedProperty _actionProperty;
        private SerializedProperty _integerValueProperty;
        private SerializedProperty _booleanValueProperty;
        private SerializedProperty _stringValueProperty;

        public void OnEnable()
        {
            _targetProperty = serializedObject.FindProperty("_target");
            _operatorProperty = serializedObject.FindProperty("_operator");
            _actionProperty = serializedObject.FindProperty("_action");
            _integerValueProperty = serializedObject.FindProperty("_integerValue");
            _stringValueProperty = serializedObject.FindProperty("_stringValue");
            _booleanValueProperty = serializedObject.FindProperty("_booleanProperty");
        }

        public override void OnInspectorGUI()
        {
            EditorGUILayout.PropertyField(_targetProperty);
            EditorGUILayout.PropertyField(_operatorProperty);

            var quality = _targetProperty.objectReferenceValue;

            if (quality is StringQuality)
                EditorGUILayout.PropertyField(_stringValueProperty);
            else if (quality is IntegerQuality)
                EditorGUILayout.PropertyField(_integerValueProperty);
            else if (quality is BooleanQuality)
                EditorGUILayout.PropertyField(_booleanValueProperty);

            EditorGUILayout.PropertyField(_actionProperty);
        }
    }
}
