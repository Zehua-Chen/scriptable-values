using UnityEngine;
using UnityEditor;

namespace ScriptableValues
{
    [CustomEditor(typeof(ScriptableBool))]
    public class ScriptableBoolEditor : Editor
    {
        public override void OnInspectorGUI()
        {
            base.OnInspectorGUI();

            ScriptableBool scriptableBool = (ScriptableBool)target;

            GUILayout.Label(string.Format("{0}", scriptableBool.RuntimeValue));
        }
    }
}
