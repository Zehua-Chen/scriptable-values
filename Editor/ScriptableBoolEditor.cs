using UnityEngine;
using UnityEditor;

namespace ScriptableValues.Editor
{
    [CustomEditor(typeof(ScriptableBool))]
    public class ScriptableBoolEditor : UnityEditor.Editor
    {
        public override void OnInspectorGUI()
        {
            base.OnInspectorGUI();

            ScriptableBool scriptableBool = (ScriptableBool)target;

            GUILayout.Label(string.Format("{0}", scriptableBool.Value));
        }
    }
}
