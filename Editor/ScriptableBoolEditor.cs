using UnityEditor;
using UnityEngine.UIElements;
using UnityEditor.UIElements;

namespace ScriptableValues.Editor
{
    [CustomEditor(typeof(ScriptableBool))]
    public class ScriptableBoolEditor : UnityEditor.Editor
    {
        Toggle _runtimeValue;

        private void OnEnable()
        {
            var boolTarget = (ScriptableBool)target;

            _runtimeValue = new Toggle("Value");
            _runtimeValue.RegisterCallback<ChangeEvent<bool>>(e =>
            {
                boolTarget.SetValueFromEditor(e.newValue);
            });

            
            boolTarget.Updated += OnUpdate;
        }

        private void OnDisable()
        {
            var boolTarget = (ScriptableBool)target;
            boolTarget.Updated -= OnUpdate;
        }

        public override VisualElement CreateInspectorGUI()
        {
            var boolTarget = (ScriptableBool)target;
            var serializedTarget = new SerializedObject(boolTarget);

            var root = new VisualElement();

            var defaultValue = new Toggle("Default Value");
            root.Add(defaultValue);

            defaultValue.BindProperty(serializedTarget.FindProperty("_defaultValue"));

            _runtimeValue.value = boolTarget.Value;
            root.Add(_runtimeValue);

            return root;
        }

        private void OnUpdate(object sender, ScriptableValue<bool>.UpdateEvent e)
        {
            _runtimeValue.value = e.NewValue;
        }
    }
}
