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
    /// <summary>
    /// Creates the view for showing the eos plugin editor config values.
    ///
    /// </summary>
    public class EOSPluginEditorConfigEditorWindow : EOSAbstractEditorWindow
    {
        private static string ConfigDirectory = "etc/EOSPluginEditorConfiguration";

        static List<IConfigSection> configurationSectionEditors;

        bool prettyPrint = false;

        [SettingsProvider]
        public static SettingsProvider CreateSettingsProvider()
        {
            var eosPluginEditorConfigEditor = ScriptableObject.CreateInstance<EOSPluginEditorConfigEditorWindow>();
            var provider = new SettingsProvider("Preferences/EOS Plugin", SettingsScope.User)
            {
                label = "EOS Plugin",
                guiHandler = (searchContext) =>
                {
                    EditorGUI.BeginChangeCheck();

                    eosPluginEditorConfigEditor.OnGUI();
                    if(EditorGUI.EndChangeCheck())
                    {
                        // save settings
                    }
                }
            };

            return provider;
        }

        //-------------------------------------------------------------------------
        [MenuItem("Tools/EOS Plugin/Configuration")]
        public static void ShowWindow()
        {
            GetWindow(typeof(EOSPluginEditorConfigEditorWindow));
        }

        //-------------------------------------------------------------------------
        public static void AddConfigurationSectionEditor(IConfigSection section)
        {
            if (configurationSectionEditors == null)
            {
                configurationSectionEditors = new List<IConfigSection>();
            }

            configurationSectionEditors.Add(section);
        }

        //-------------------------------------------------------------------------
        public static T GetConfigurationSectionEditor<T>() where T : IConfigSection, new()
        {
            if (configurationSectionEditors != null)
            {
                foreach (var configurationSectionEditor in configurationSectionEditors)
                {
                    if (configurationSectionEditor.GetType() == typeof(T))
                    {
                        return (T)configurationSectionEditor;
                    }
                }
            }
            return default;
        }


        //-------------------------------------------------------------------------
        private static string GetConfigDirectory()
        {
            return System.IO.Path.Combine(Application.dataPath, "..", ConfigDirectory);
        }

        //-------------------------------------------------------------------------
        public static string GetConfigPath(string configFilename)
        {
            return System.IO.Path.Combine(GetConfigDirectory(), configFilename);
        }

        //-------------------------------------------------------------------------
        public static bool IsAsset(string configFilepath)
        {
            var assetDir = new DirectoryInfo(Application.dataPath);
            var fileDir = new DirectoryInfo(configFilepath);
            bool isParent = false;
            while (fileDir.Parent != null)
            {
                if (fileDir.Parent.FullName == assetDir.FullName)
                {
                    isParent = true;
                    break;
                }
                else fileDir = fileDir.Parent;
            }
            return isParent;
        }

        //-------------------------------------------------------------------------
        private void LoadConfigFromDisk()
        {

            if (!Directory.Exists(GetConfigDirectory()))
            {
                Directory.CreateDirectory(GetConfigDirectory());
            }

            foreach(var configurationSectionEditor in configurationSectionEditors)
            {
                configurationSectionEditor.Read();
            }
        }

        //-------------------------------------------------------------------------
        private void Awake()
        {
            if (configurationSectionEditors == null)
            {
                configurationSectionEditors = new List<IConfigSection>();
            }

            foreach (var configurationSectionEditor in configurationSectionEditors)
            {
                configurationSectionEditor.Awake();
            }

            LoadConfigFromDisk();
        }

        //-------------------------------------------------------------------------
        private void OnGUI()
        {

            GUILayout.BeginScrollView(new Vector2(), GUIStyle.none);
            if (configurationSectionEditors.Count > 0)
            {
                foreach (var configurationSectionEditor in configurationSectionEditors)
                {

                    GUILayout.Label(configurationSectionEditor.GetSectionName(), EditorStyles.boldLabel);
                    EpicOnlineServicesConfigEditorWindow.HorizontalLine(Color.white);
                    configurationSectionEditor.OnGUI();
                    EditorGUILayout.Space();
                }
            }

            GUILayout.EndScrollView();
            EpicOnlineServicesConfigEditorWindow.AssigningBoolField("Save JSON in 'Pretty' Format", ref prettyPrint, 190);
            GUI.SetNextControlName("Save");
            if (GUILayout.Button("Save All Changes"))
            {
                GUI.FocusControl("Save");
                SaveToJSONConfig(prettyPrint);
            }
        }

        //-------------------------------------------------------------------------
        private void SaveToJSONConfig(bool prettyPrint)
        {

            foreach (var configurationSectionEditor in configurationSectionEditors)
            {
                configurationSectionEditor.Save(prettyPrint);
            }

            AssetDatabase.SaveAssets();
            AssetDatabase.Refresh();
        }

        //-------------------------------------------------------------------------
        private bool DoesHaveUnsavedChanges()
        {
            foreach (var configurationSectionEditor in configurationSectionEditors)
            {
                if (configurationSectionEditor.HasUnsavedChanges())
                {
                    return true;
                }
            }

            return false;
        }

        //-------------------------------------------------------------------------
        private void OnGUIForUnsavedChanges(int idx)
        {
            if (GUI.Button(new Rect(10, 20, 100, 20), "Save"))
            {
                SaveToJSONConfig(prettyPrint);
            }

            if (GUI.Button(new Rect(10, 20, 100, 20), "Cancel"))
            {
            }
        }

        //-------------------------------------------------------------------------
        private void OnDestroy()
        {
            if (DoesHaveUnsavedChanges())
            {
                GUI.ModalWindow(0, new Rect(20, 20, 120, 50), OnGUIForUnsavedChanges, "Unsaved Changes");
            }
        }
    }


    
}
