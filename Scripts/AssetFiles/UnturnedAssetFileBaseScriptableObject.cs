using UnityEngine;

namespace LB3D.PuggosWorld.Unturned
{
    public abstract class UnturnedAssetFileBaseScriptableObject : ScriptableObject
    {
        [Header("Metadata")]
        public string guid;
        public string assetType;

        private void Awake()
        {
            GenerateGuid();
        }

        public void GenerateGuid(bool regenerate = false)
        {
            if (string.IsNullOrEmpty(guid) || regenerate)
            {
                guid = System.Guid.NewGuid().ToString("N");
            }
            if (regenerate)
            {
                Debug.Log("Guid Regenerated. Now: " + guid);
            }
        }

        public virtual string GetText()
        {
            return "";
        }

    }
}
