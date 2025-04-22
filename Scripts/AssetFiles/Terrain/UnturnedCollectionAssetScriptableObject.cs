using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace LB3D.PuggosWorld.Unturned
{
    [CreateAssetMenu(fileName = "CollectionAssetFile", menuName = "PuggosWorld/Unturned/Collection Asset File", order = 3)]
    public class UnturnedCollectionAssetScriptableObject : UnturnedAssetFileBaseScriptableObject
    {
        [System.Serializable]
        public class FoliageEntry
        {
            public UnturnedAssetFileBaseScriptableObject asset;
            public float weight = 1;
        }

        public UnturnedCollectionAssetScriptableObject()
        {
            assetType = "SDG.Framework.Foliage.FoliageInfoCollectionAsset, Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null";
        }

        [Header("Assets")]
        public int id;
        public List<FoliageEntry> foliageAssets = new List<FoliageEntry>();

        // Method to get the resource GUID from the asset
        public string GetResourceGuid(UnturnedAssetFileBaseScriptableObject asset)
        {
            if (asset != null)
            {
                return asset.guid; // Accessing the GUID from the selected asset
            }
            else
            {
                Debug.LogWarning("No UnturnedAssetFileBaseScriptableObject assigned.");
                return string.Empty;
            }
        }

        public override string GetText()
        {
            string text = $"\"Metadata\"\n{{\n\t\"GUID\" \"{guid}\"\n\t\"Type\" \"{assetType}\"\n}}\n";

            text += $"\"Asset\"\n{{\n";
            text += $"\t\"ID\" \"{id}\"\n";

            text += $"\t\"Foliage\"\n\t[\n";

            foreach (var foliage in foliageAssets)
            {
                text += "\t\t{\n";
                text += "\t\t\t\"Asset\"\n";
                text += "\t\t\t{\n";
                text += $"\t\t\t\t\"GUID\" \"{GetResourceGuid(foliage.asset)}\"\n";
                text += "\t\t\t}\n";
                text += $"\t\t\t\"Weight\" \"{foliage.weight}\"\n";
                text += "\t\t}\n";
            }

            text += "\t]\n";
            text += $"}}\n";

            return text;
        }
    }
}
