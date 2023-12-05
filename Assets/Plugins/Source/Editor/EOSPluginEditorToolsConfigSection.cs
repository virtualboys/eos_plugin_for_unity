/*
 * Copyright (c) 2021 PlayEveryWare
 *
 * Permission is hereby granted, free of charge, to any person obtaining a copy
 * of this software and associated documentation files (the "Software"), to deal
 * in the Software without restriction, including without limitation the rights
 * to use, copy, modify, merge, publish, distribute, sublicense, and/or sell
 * copies of the Software, and to permit persons to whom the Software is
 * furnished to do so, subject to the following conditions:
 *
 * The above copyright notice and this permission notice shall be included in all
 * copies or substantial portions of the Software.
 *
 * THE SOFTWARE IS PROVIDED "AS IS", WITHOUT WARRANTY OF ANY KIND, EXPRESS OR
 * IMPLIED, INCLUDING BUT NOT LIMITED TO THE WARRANTIES OF MERCHANTABILITY,
 * FITNESS FOR A PARTICULAR PURPOSE AND NONINFRINGEMENT. IN NO EVENT SHALL THE
 * AUTHORS OR COPYRIGHT HOLDERS BE LIABLE FOR ANY CLAIM, DAMAGES OR OTHER
 * LIABILITY, WHETHER IN AN ACTION OF CONTRACT, TORT OR OTHERWISE, ARISING FROM,
 * OUT OF OR IN CONNECTION WITH THE SOFTWARE OR THE USE OR OTHER DEALINGS IN THE
 * SOFTWARE.
 */

using System;
using System.IO;
using UnityEditor;
using UnityEngine;
using PlayEveryWare.EpicOnlineServices;
using System.Collections.Generic;

namespace PlayEveryWare.EpicOnlineServices
{

    //-------------------------------------------------------------------------
    public class EOSPluginEditorToolsConfigSection : IEOSPluginEditorConfigurationSection
    {
        private static string ConfigName = "eos_plugin_tools_config.json";
        private EOSConfigFile<EOSPluginEditorToolsConfig> configFile;

        [InitializeOnLoadMethod]
        static void Register()
        {
            EOSPluginEditorConfigEditorWindow.AddConfigurationSectionEditor(new EOSPluginEditorToolsConfigSection());
        }

        //-------------------------------------------------------------------------
        public string GetMenuName()
        {
            return "Tools";
        }

        //-------------------------------------------------------------------------
        public void Awake()
        {
            var configFilenamePath = EOSPluginEditorConfigEditorWindow.GetConfigPath(ConfigName);
            configFile = new EOSConfigFile<EOSPluginEditorToolsConfig>(configFilenamePath);
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

        public EOSPluginEditorToolsConfig GetCurrentConfig()
        {
            return configFile.currentEOSConfig;
        }

        //-------------------------------------------------------------------------
        void IEOSPluginEditorConfigurationSection.OnGUI()
        {

            string pathToIntegrityTool = EmptyPredicates.NewIfNull(configFile.currentEOSConfig.pathToEACIntegrityTool);
            string pathToIntegrityConfig = EmptyPredicates.NewIfNull(configFile.currentEOSConfig.pathToEACIntegrityConfig);
            string pathToEACCertificate = EmptyPredicates.NewIfNull(configFile.currentEOSConfig.pathToEACCertificate);
            string pathToEACPrivateKey = EmptyPredicates.NewIfNull(configFile.currentEOSConfig.pathToEACPrivateKey);
            string pathToEACSplashImage = EmptyPredicates.NewIfNull(configFile.currentEOSConfig.pathToEACSplashImage);
            string bootstrapOverideName = EmptyPredicates.NewIfNull(configFile.currentEOSConfig.bootstrapperNameOverride);
            bool useEAC = configFile.currentEOSConfig.useEAC;

            EpicOnlineServicesConfigEditorWindow.AssigningPath("Path to EAC Integrity Tool", ref pathToIntegrityTool, "Select EAC Integrity Tool",
                tooltip: "EOS SDK tool used to generate EAC certificate from file hashes");
            EpicOnlineServicesConfigEditorWindow.AssigningPath("Path to EAC Integrity Tool Config", ref pathToIntegrityConfig, "Select EAC Integrity Tool Config",
                tooltip: "Config file used by integry tool. Defaults to anticheat_integritytool.cfg in same directory.", extension: "cfg", labelWidth: 200);
            EpicOnlineServicesConfigEditorWindow.AssigningPath("Path to EAC private key", ref pathToEACPrivateKey, "Select EAC private key", extension: "key",
                tooltip: "EAC private key used in integrity tool cert generation. Exposing this to the public will comprimise anti-cheat functionality.");
            EpicOnlineServicesConfigEditorWindow.AssigningPath("Path to EAC Certificate", ref pathToEACCertificate, "Select EAC public key", extension: "cer",
                tooltip: "EAC public key used in integrity tool cert generation");
            EpicOnlineServicesConfigEditorWindow.AssigningPath("Path to EAC splash image", ref pathToEACSplashImage, "Select 800x450 EAC splash image PNG", extension: "png",
                tooltip: "EAC splash screen used by launcher. Must be a PNG of size 800x450.");

            EpicOnlineServicesConfigEditorWindow.AssigningBoolField("Use EAC", ref useEAC, tooltip: "If set to true, uses the EAC");
            EpicOnlineServicesConfigEditorWindow.AssigningTextField("Bootstrapper Name Override", ref bootstrapOverideName, labelWidth: 180, tooltip: "Name to use instead of 'Bootstrapper.exe'");

            configFile.currentEOSConfig.pathToEACIntegrityTool = pathToIntegrityTool;
            configFile.currentEOSConfig.pathToEACIntegrityConfig = pathToIntegrityConfig;
            configFile.currentEOSConfig.pathToEACPrivateKey = pathToEACPrivateKey;
            configFile.currentEOSConfig.pathToEACCertificate = pathToEACCertificate;
            configFile.currentEOSConfig.pathToEACSplashImage = pathToEACSplashImage;
            configFile.currentEOSConfig.useEAC = useEAC;
            configFile.currentEOSConfig.bootstrapperNameOverride = bootstrapOverideName;
        }

        //-------------------------------------------------------------------------
        public void Save(bool prettyPrint)
        {
            configFile.SaveToJSONConfig(prettyPrint);
        }
    }


}
