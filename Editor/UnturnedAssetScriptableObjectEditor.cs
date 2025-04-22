using UnityEditor;
using UnityEngine;

namespace LB3D.PuggosWorld.Unturned
{
    [CustomEditor(typeof(UnturnedAssetFileBaseScriptableObject), true)]
    public class UnturnedAssetScriptableObjectEditor : Editor
    {
        public override void OnInspectorGUI()
        {
            DrawDefaultInspector();

            UnturnedAssetFileBaseScriptableObject myScriptableObject = (UnturnedAssetFileBaseScriptableObject)target;

            if (GUILayout.Button("Generate New GUID", GUILayout.Height(40)))
            {
                myScriptableObject.GenerateGuid(true);
                EditorUtility.SetDirty(myScriptableObject);
            }

            if (GUI.changed)
            {
                EditorUtility.SetDirty(target);
                Repaint();
            }
        }
    }
}
