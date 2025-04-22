using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace LB3D.PuggosWorld.Unturned
{
    [CreateAssetMenu(fileName = "ResourceAsset", menuName = "PuggosWorld/Unturned/Resource Asset File", order = 4)]
    public class UnturnedResourceAssetFileScriptableObject : UnturnedAssetFileBaseScriptableObject
    {
        [Header("Asset Details")]
        public int id;
        public int density;

        [Header("Position Offset")]
        public float minNormalPositionOffset;
        public float maxNormalPositionOffset;

        [Header("Normal Rotation Offset")]
        public Vector3 normalRotationOffset;

        [Header("Rotation Alignment")]
        public float normalRotationAlignment;

        [Header("Weight")]
        public float minWeight;
        public float maxWeight;

        [Header("Angle")]
        public float minAngle;
        public float maxAngle;

        [Header("Rotation")]
        public Vector3 minRotation;
        public Vector3 maxRotation = new Vector3(0.0f, 0.0f, 0.0f);

        [Header("Scale")]
        public Vector3 minScale = new Vector3(1.0f, 1.0f, 1.0f);
        public Vector3 maxScale = new Vector3(1.0f, 1.0f, 1.0f);

        [Header("Resource Details")]
        public UnturnedDatFileScriptableObject resource;

        // Method to get the GUID from the assigned Dat file
        public string GetResourceGuid()
        {
            if (resource != null)
            {
                return resource.guid; // Accessing the GUID from the selected UnturnedDatFileScriptableObject
            }
            else
            {
                Debug.LogWarning("No UnturnedDatFileScriptableObject assigned.");
                return string.Empty;
            }
        }

        [Header("Obstruction")]
        public float obstructionRadius;

        // Constructor to set default assetType value
        public UnturnedResourceAssetFileScriptableObject()
        {
            assetType = "SDG.Framework.Foliage.FoliageResourceInfoAsset, Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null";
        }

        public override string GetText()
        {
            string text = $"\"Metadata\"\n{{\n\t\"GUID\" \"{guid}\"\n\t\"Type\" \"{assetType}\"\n}}\n";
            text += $"\"Asset\"\n{{\n";
            text += $"\t\"ID\" \"{id}\"\n";
            text += $"\t\"Density\" \"{density}\"\n";
            text += $"\t\"Min_Normal_Position_Offset\" \"{minNormalPositionOffset}\"\n";
            text += $"\t\"Max_Normal_Position_Offset\" \"{maxNormalPositionOffset}\"\n";
            text += $"\t\"Normal_Rotation_Offset\"\n\t{{\n\t\t\"X\" \"{normalRotationOffset.x}\"\n\t\t\"Y\" \"{normalRotationOffset.y}\"\n\t\t\"Z\" \"{normalRotationOffset.z}\"\n\t}}\n";
            text += $"\t\"Normal_Rotation_Alignment\" \"{normalRotationAlignment}\"\n";
            text += $"\t\"Min_Weight\" \"{minWeight}\"\n";
            text += $"\t\"Max_Weight\" \"{maxWeight}\"\n";
            text += $"\t\"Min_Angle\" \"{minAngle}\"\n";
            text += $"\t\"Max_Angle\" \"{maxAngle}\"\n";
            text += $"\t\"Min_Rotation\"\n\t{{\n\t\t\"X\" \"{minRotation.x}\"\n\t\t\"Y\" \"{minRotation.y}\"\n\t\t\"Z\" \"{minRotation.z}\"\n\t}}\n";
            text += $"\t\"Max_Rotation\"\n\t{{\n\t\t\"X\" \"{maxRotation.x}\"\n\t\t\"Y\" \"{maxRotation.y}\"\n\t\t\"Z\" \"{maxRotation.z}\"\n\t}}\n";
            text += $"\t\"Min_Scale\"\n\t{{\n\t\t\"X\" \"{minScale.x}\"\n\t\t\"Y\" \"{minScale.y}\"\n\t\t\"Z\" \"{minScale.z}\"\n\t}}\n";
            text += $"\t\"Max_Scale\"\n\t{{\n\t\t\"X\" \"{maxScale.x}\"\n\t\t\"Y\" \"{maxScale.y}\"\n\t\t\"Z\" \"{maxScale.z}\"\n\t}}\n";
            text += $"\t\"Resource\"\n\t{{\n\t\t\"GUID\" \"{GetResourceGuid()}\"\n\t}}\n";
            text += $"\t\"Obstruction_Radius\" \"{obstructionRadius}\"\n";
            text += $"}}\n";
            return text;
        }
    }
}
