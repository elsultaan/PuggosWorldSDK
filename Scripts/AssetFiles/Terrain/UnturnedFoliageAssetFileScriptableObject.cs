using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace LB3D.PuggosWorld.Unturned
{
    [CreateAssetMenu(fileName = "FoliageAsset", menuName = "PuggosWorld/Unturned/Foliage Asset File", order = 3)]
    public class UnturnedFoliageAssetFileScriptableObject : UnturnedAssetFileBaseScriptableObject
    {
        [Header("Asset Details")]
        public int id = 0; // Default ID value set to 0
        public int density = 12; // Default density value set to 12

        [Header("Normal Position Offset")]
        public float minNormalPositionOffset = 0.0f;
        public float maxNormalPositionOffset = 0.0f;

        [Header("Normal Rotation Offset")]
        public Vector3 normalRotationOffset = Vector3.zero; // Default to (0,0,0)

        [Header("Normal Rotation Alignment")]
        public int normalRotationAlignment = 1;

        [Header("Weight")]
        public float minWeight = 0.5f; // Default minWeight
        public float maxWeight = 1.0f; // Default maxWeight

        [Header("Angle")]
        public float minAngle = 0.0f; // Default minAngle
        public float maxAngle = 60.0f; // Default maxAngle

        [Header("Rotation")]
        public Vector3 minRotation = Vector3.zero; // Default to (0,0,0)
        public Vector3 maxRotation = new Vector3(0.0f, 360.0f, 0.0f); // Default maxRotation

        [Header("Scale")]
        public Vector3 minScale = new Vector3(0.8f, 0.8f, 0.8f); // Default minScale
        public Vector3 maxScale = new Vector3(1.2f, 1.2f, 1.2f); // Default maxScale

        [Header("Mesh Details")]
        public string meshAssetBundle = "core.masterbundle";
        public string meshPath = "Terrain/Foliage/Grass/Grass_00_Mesh.fbx";

        [Header("Material Details")]
        public string materialAssetBundle = "california.masterbundle";
        public string materialPath = "assets/landscapes/details/grass_00.mat";

        [Header("Christmas Redirect")]
        public bool isUsingChristmasRedirect = false;
        public string christmasRedirectGuid = "0";

        [Header("Halloween Redirect")]
        public bool isUsingHalloweenRedirect = false;
        public string halloweenRedirectGuid = "0";

        [Header("Additional Settings")]
        public bool castShadows = false; // Default castShadows
        public bool tileDither = true; // Default tileDither
        public int drawDistance = -1; // Default drawDistance

        // Constructor to set default assetType value
        public UnturnedFoliageAssetFileScriptableObject()
        {
            assetType = "SDG.Framework.Foliage.FoliageInstancedMeshInfoAsset, Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null";
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
            text += $"\t\"Mesh\"\n\t{{\n\t\t\"Name\" \"{meshAssetBundle}\"\n\t\t\"Path\" \"{meshPath}\"\n\t}}\n";
            text += $"\t\"Material\"\n\t{{\n\t\t\"Name\" \"{materialAssetBundle}\"\n\t\t\"Path\" \"{materialPath}\"\n\t}}\n";

            // Conditional Christmas Redirect
            if (isUsingChristmasRedirect)
            {
                text += $"\t\"Christmas_Redirect\"\n\t{{\n\t\t\"GUID\" \"{christmasRedirectGuid}\"\n\t}}\n";
            }

            // Conditional Halloween Redirect
            if (isUsingHalloweenRedirect)
            {
                text += $"\t\"Halloween_Redirect\"\n\t{{\n\t\t\"GUID\" \"{halloweenRedirectGuid}\"\n\t}}\n";
            }

            text += $"\t\"Cast_Shadows\" \"{castShadows.ToString().ToLower()}\"\n";
            text += $"\t\"Tile_Dither\" \"{tileDither.ToString().ToLower()}\"\n";
            text += $"\t\"Draw_Distance\" \"{drawDistance}\"\n";
            text += $"}}\n";
            return text;
        }
    }
}
