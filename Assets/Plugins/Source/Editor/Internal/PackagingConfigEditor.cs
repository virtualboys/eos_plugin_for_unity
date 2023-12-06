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

using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

namespace PlayEveryWare.EpicOnlineServices
{
    public class EOSPluginEditorPackagingConfigSection : AbstractConfigSection<EOSPluginEditorPackagingConfig>
    {
        public EOSPluginEditorPackagingConfigSection() : base("Plugin Packaging") { }

        [InitializeOnLoadMethod]
        static void Register()
        {
            EOSPluginEditorConfigEditorWindow.AddConfigurationSectionEditor(new EOSPluginEditorPackagingConfigSection());
        }

        public EOSPluginEditorPackagingConfig GetCurrentConfig()
        {
            return ConfigFile.currentEOSConfig;
        }

        public override void OnGUI()
        {
            string pathToJSONPackageDescription = EmptyPredicates.NewIfNull(ConfigFile.currentEOSConfig.pathToJSONPackageDescription);
            string customBuildDirectoryPath = EmptyPredicates.NewIfNull(ConfigFile.currentEOSConfig.customBuildDirectoryPath);
            string pathToOutput = EmptyPredicates.NewIfNull(ConfigFile.currentEOSConfig.pathToOutput);
            EpicOnlineServicesConfigEditorWindow.AssigningPath("JSON Description Path", ref pathToJSONPackageDescription, "Pick JSON Package Description", extension: "json", labelWidth: 170);
            EpicOnlineServicesConfigEditorWindow.AssigningPath("Custom Build Directory Path", ref customBuildDirectoryPath, "Pick Custom Build Directory", selectFolder: true, labelWidth: 170);
            EpicOnlineServicesConfigEditorWindow.AssigningPath("Output Path", ref pathToOutput, "Pick Output Directory", selectFolder: true, labelWidth: 170);

            ConfigFile.currentEOSConfig.pathToJSONPackageDescription = pathToJSONPackageDescription;
            ConfigFile.currentEOSConfig.customBuildDirectoryPath = customBuildDirectoryPath;
            ConfigFile.currentEOSConfig.pathToOutput = pathToOutput;
        }
    }
}
