using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEngine;
using UnityEditor;

namespace LB3D.PuggosWorld.Unturned
{
    [CreateAssetMenu(fileName = "ModSettings", menuName = "PuggosWorld/Unturned/ModSettings", order = 1)]
    public class UnturnedModScriptableObject : ScriptableObject
    {
        public enum Asset_Bundle_Version
        {
            Asset_Bundle_Version_5,
            Asset_Bundle_Version_4,
            Asset_Bundle_Version_3,
            Asset_Bundle_Version_2,
            Asset_Bundle_Version_1
        }

        [Header("Mod Name (no spaces)")]
        [Tooltip("If the modname is ExampleMod then make sure the masterbundle is called examplemod.masterbundle.")]
        public string modName;

        [Header("Steam Workshop Description")]
        public TextAsset steamDescription;

        public bool includeIdList = true;

        [Header("Items / Folders Included")]
        [Tooltip("These are the dat file scriptable objects that you include in every folder that contains the item assets.")]
        public UnturnedDatFileScriptableObject[] datFiles;

        [Header("Asset Files Included")]
        [Tooltip("These are the asset file scriptable objects that you include in every folder that contains asset files.")]
        public UnturnedAssetFileBaseScriptableObject[] assetFiles;

        [Header("Master Bundle Attributes")]
        public Asset_Bundle_Version assetBundleVersion;

        public void GenerateMod()
        {
            string modFolder = GenerateModFolder();
            foreach (UnturnedDatFileScriptableObject datFile in datFiles)
            {
                GenerateDataFolder(datFile);
            }

            foreach (UnturnedAssetFileBaseScriptableObject assetFile in assetFiles)
            {
                GenerateAssetFileFolder(assetFile);
            }
        }

        public string GetModFolder(string modPath)
        {
            string modFolder = modPath.Replace("Assets/UnturnedMods/", "").Replace(Path.GetFileName(modPath), "");
            return modFolder;
        }

        public void GenerateDataFolder(UnturnedDatFileScriptableObject datFile)
        {
#if UNITY_EDITOR
            string text = datFile.GetText();
            string nameEnglish = datFile.GetNameEnglish();
            string descriptionEnglish = datFile.GetDescriptionEnglish(); // Added the option to add a description
            string folderName = datFile.GetFolderName();

            string unturnedSandBox = Path.Combine(UnturnedModsGlobalSettingsObject.Instance.unturnedInstallationPath, "Sandbox", "Bundles");

            string destinationFolder = Path.Combine(unturnedSandBox, GetModFolder(AssetDatabase.GetAssetPath(datFile)));
            if (!Directory.Exists(destinationFolder))
            {
                Directory.CreateDirectory(destinationFolder);
            }
            File.WriteAllText(Path.Combine(destinationFolder, folderName + ".dat"), text);
            if (descriptionEnglish != "")
                File.WriteAllText(Path.Combine(destinationFolder, "English.dat"), "Name " + nameEnglish + "\nDescription " + descriptionEnglish);
            else
                File.WriteAllText(Path.Combine(destinationFolder, "English.dat"), "Name " + nameEnglish); // Conditionally write description to English.dat
#endif
        }

        public void GenerateAssetFileFolder(UnturnedAssetFileBaseScriptableObject assetFile)
        {
#if UNITY_EDITOR
            string text = assetFile.GetText();
            string folderName = assetFile.name;

            string unturnedSandBox = Path.Combine(UnturnedModsGlobalSettingsObject.Instance.unturnedInstallationPath, "Sandbox", "Bundles");

            string destinationFolder = Path.Combine(unturnedSandBox, GetModFolder(AssetDatabase.GetAssetPath(assetFile)));
            if (!Directory.Exists(destinationFolder))
            {
                Directory.CreateDirectory(destinationFolder);
            }
            File.WriteAllText(Path.Combine(destinationFolder, folderName + ".asset"), text); // Assuming .asset as the extension
#endif
        }

        public string GenerateModFolder()
        {
            string modDirectory = GetModDirectory();
            if (Directory.Exists(modDirectory))
            {
                return modDirectory;
            }
            else
            {
                Directory.CreateDirectory(modDirectory);
            }
            return modDirectory;
        }

        public string GetSandboxDirectory()
        {
            return Path.Combine(GetUnturnedInstallationDirectory(), "Sandbox");
        }

        public string GetModDirectory()
        {
            string modDirectory = Path.Combine(GetSandboxDirectory(), "Bundles", modName.Trim());
            return modDirectory;
        }

        public void GenerateMasterBundleEntry()
        {
            string modDirectory = GetModDirectory();
            Debug.Log(modDirectory);
            string assetBundleName = "Asset_Bundle_Name " + GetMasterBundleName();
            string assetPrefix = "Asset_Prefix " + Path.Combine("Assets", "UnturnedMods", modName.Trim()).Replace("\\", "/");
            string assetBundleVersion = "Asset_Bundle_Version " + GetAssetBundleVersion().ToString();
            string data = assetBundleName + "\n" + assetPrefix + "\n" + assetBundleVersion;
            File.WriteAllText(Path.Combine(modDirectory, "MasterBundle.dat"), data);
            GenerateReadMe();
        }

        public void GenerateReadMe()
        {
            string text = "";

            if (steamDescription != null && !string.IsNullOrEmpty(steamDescription.text))
            {
                text += steamDescription.text.Trim();
                text += "\n\n";
            }

            if (!includeIdList) return;

            text += "ID List:\n\n";
            string modDirectory = GetModDirectory();
            foreach (UnturnedDatFileScriptableObject datFile in datFiles)
            {
                string modRecord = datFile.id + " - " + datFile.GetNameEnglish().Trim() + "\n";
                text += modRecord;
            }
            foreach (UnturnedAssetFileBaseScriptableObject assetFile in assetFiles)
            {
                string modRecord = "Asset ID: " + assetFile.name.Trim() + "\n"; // Adjust as needed
                text += modRecord;
            }
            text += "\n\nMod generated using PuggosWorldSDK:  https://github.com/LeoBlanchette/PuggosWorldSDK";
            File.WriteAllText(Path.Combine(modDirectory, "README.txt"), text);
        }

        public int GetAssetBundleVersion()
        {
            switch (assetBundleVersion)
            {
                case Asset_Bundle_Version.Asset_Bundle_Version_5: // Added for Unity 2021 LTS
                    return 5;
                case Asset_Bundle_Version.Asset_Bundle_Version_4:
                    return 4;
                case Asset_Bundle_Version.Asset_Bundle_Version_3:
                    return 3;
                case Asset_Bundle_Version.Asset_Bundle_Version_2:
                    return 2;
                case Asset_Bundle_Version.Asset_Bundle_Version_1:
                    return 1;
                default:
                    return 4;
            }
        }

        public string GetUnturnedInstallationDirectory()
        {
            return UnturnedModsGlobalSettingsObject.Instance.unturnedInstallationPath;
        }

        public string GetMasterBundleName()
        {
            return modName.ToLower() + ".masterbundle";
        }
    }
}
