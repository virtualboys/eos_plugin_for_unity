using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;


namespace PlayEveryWare.EpicOnlineServices
{
    //-------------------------------------------------------------------------
    public class EOSPluginEditorAndroidBuildConfigSection : IEOSPluginEditorConfigurationSection
    {
        private static string ConfigName = "eos_plugin_android_build_config.json";
        private EOSConfigFile<EOSPluginEditorAndroidBuildConfig> configFile;

        [InitializeOnLoadMethod]
        static void Register()
        {
            EOSPluginEditorConfigEditorWindow.AddConfigurationSectionEditor(new EOSPluginEditorAndroidBuildConfigSection());
        }

        //-------------------------------------------------------------------------
        public string GetSectionName()
        {
            return "Android Build Settings";
        }

        //-------------------------------------------------------------------------
        public void Awake()
        {
            var configFilenamePath = EOSPluginEditorConfigEditorWindow.GetConfigPath(ConfigName);
            configFile = new EOSConfigFile<EOSPluginEditorAndroidBuildConfig>(configFilenamePath);
        }

        //-------------------------------------------------------------------------
        public bool HasUnsavedChanges()
        {
            return false;
        }

        //-------------------------------------------------------------------------
        public void Read()
        {
            configFile.LoadConfigFromDisk();
        }

        public EOSPluginEditorAndroidBuildConfig GetCurrentConfig()
        {
            return configFile.currentEOSConfig;
        }

        //-------------------------------------------------------------------------
        void IEOSPluginEditorConfigurationSection.OnGUI()
        {
            EpicOnlineServicesConfigEditorWindow.AssigningBoolField("Link EOS Library Dynamically", ref configFile.currentEOSConfig.DynamicallyLinkEOSLibrary);
        }

        //-------------------------------------------------------------------------
        public void Save(bool prettyPrint)
        {
            configFile.SaveToJSONConfig(prettyPrint);
        }
    }

    public class EOSPluginEditorAndroidBuildConfig : ICloneableGeneric<EOSPluginEditorAndroidBuildConfig>, IEmpty
    {

        public bool DynamicallyLinkEOSLibrary;

        public EOSPluginEditorAndroidBuildConfig Clone()
        {
            return (EOSPluginEditorAndroidBuildConfig)this.MemberwiseClone();
        }

        public bool IsEmpty()
        {
            return false;
        }
    }
}