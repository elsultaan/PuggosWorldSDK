using UnityEditor;
using UnityEngine;

[CustomPropertyDrawer(typeof(AssetBundleDropdownAttribute))]
public class AssetBundleDropdownDrawer : PropertyDrawer
{
    public override void OnGUI(Rect position, SerializedProperty property, GUIContent label)
    {
        // Get the asset bundles
        string[] assetBundles = AssetDatabase.GetAllAssetBundleNames();
        
        // Create a dropdown list for asset bundles
        int selectedIndex = System.Array.IndexOf(assetBundles, property.stringValue);
        if (selectedIndex == -1) selectedIndex = 0;

        selectedIndex = EditorGUI.Popup(position, label.text, selectedIndex, assetBundles);
        property.stringValue = assetBundles[selectedIndex];
    }
}
