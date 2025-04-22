using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace LB3D.PuggosWorld.Unturned
{
    [CreateAssetMenu(fileName = "MaterialAsset", menuName = "PuggosWorld/Unturned/Material Asset File", order = 3)]
    public class UnturnedMaterialAssetFileScriptableObject : UnturnedAssetFileBaseScriptableObject
    {

        [Header("Asset Details")]
        public int id;

        [Header("Texture")]
        public string textureAssetBundle;
        public string texturePath;

        [Header("Mask")]
        public string maskAssetBundle;
        public string maskPath;

        [Header("Physics Material")]
        public string physicsMaterial = "FOLIAGE_STATIC";

        [Header("Resource Details")]
        public UnturnedCollectionAssetScriptableObject collection;

        [Header("Christmas Redirect")]
        public bool isUsingChristmasRedirect;
        public string christmasRedirectGuid;

        // Method to get the GUID from the assigned Dat file
        public string GetCollectionGuid()
        {
            if (collection != null)
            {
                return collection.guid; // Accessing the GUID from the selected UnturnedDatFileScriptableObject
            }
            else
            {
                Debug.LogWarning("No UnturnedDatFileScriptableObject assigned.");
                return string.Empty;
            }
        }

        // Constructor to set default assetType value
        public UnturnedMaterialAssetFileScriptableObject()
        {
            assetType = "SDG.Unturned.LandscapeMaterialAsset, Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null";
        }

        public override string GetText()
        {
            string text = $"\"Metadata\"\n{{\n\t\"GUID\" \"{guid}\"\n\t\"Type\" \"{assetType}\"\n}}\n";
            text += $"\"Asset\"\n{{\n";
            text += $"\t\"ID\" \"{id}\"\n";
            text += $"\t\"Texture\"\n\t{{\n";
            text += $"\t\t\"Name\" \"{textureAssetBundle}\"\n";
            text += $"\t\t\"Path\" \"{texturePath}\"\n\t}}\n";
            text += $"\t\"Mask\"\n\t{{\n";
            text += $"\t\t\"Name\" \"{maskAssetBundle}\"\n";
            text += $"\t\t\"Path\" \"{maskPath}\"\n\t}}\n";
            text += $"\t\"Physics_Material\" \"FOLIAGE_STATIC\"\n";
            text += $"\t\"Foliage\"\n\t{{\n";
            text += $"\t\t\"GUID\" \"{GetCollectionGuid()}\"\n\t}}\n";

            // Add Christmas Redirect if applicable
            if (isUsingChristmasRedirect)
            {
                text += $"\t\"Christmas_Redirect\"\n\t{{\n";
                text += $"\t\t\"GUID\" \"{christmasRedirectGuid}\"\n\t}}\n";
            }

            if (isUsingChristmasRedirect)
            {
                text += $"\t\"Christmas_Redirect\"\n\t{{\n\t\t\"GUID\" \"{christmasRedirectGuid}\"\n\t}}\n";
            }

            text += $"}}\n";
            return text;
        }

    }
}
