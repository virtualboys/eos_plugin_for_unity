﻿/*
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
using System.Text;
using UnityEditor;
using UnityEngine;

namespace PlayEveryWare.EpicOnlineServices
{
    [Serializable]
    public class DeploymentChecker : EOSEditorWindow
    {
        private const string PackageDirectory = "etc/PackageTemplate";
        private const string ChangelogFile = "CHANGELOG.md";
        private const string PackageJsonFile = "package.json";

        private const string WindowsPluginDirectory = "Assets/Plugins/Windows";
        private const string EOSWindows64DllFile = "x64/EOSSDK-Win64-Shipping.dll";
        private const string EOSWindows32DllFile = "x86/EOSSDK-Win32-Shipping.dll";

        private string content;
        private string currentPath;
        Vector2 scrollPosition;

        [MenuItem("Tools/EOS Plugin/Check Deployment")]
        public static void ShowWindow()
        {
            GetWindow<DeploymentChecker>("Deployment Checker");
        }

        public string GetRepositoryRoot()
        {
            return Path.Combine(Application.dataPath, "..");
        }

        protected override void Setup()
        {
            // We set auto-resize to false here because this window has a text area, and it doesn't play
            // nicely with the AdjustWindowSize method. Instead of figuring out how to implement an edge
            // case for it right now, this particular window disables the ability, as no other editor
            // windows currently implemented contain text areas.
            SetAutoResize(false);
        }

        protected override void RenderWindow()
        {
            if (GUILayout.Button(ChangelogFile))
            {
                LoadTextFile(Path.Combine(GetRepositoryRoot(), PackageDirectory, ChangelogFile));
            }

            if (GUILayout.Button(PackageJsonFile))
            {
                LoadTextFile(Path.Combine(GetRepositoryRoot(), PackageDirectory, PackageJsonFile));
            }

            if (GUILayout.Button(EOSWindows32DllFile))
            {
                LoadDLLFile(Path.Combine(GetRepositoryRoot(), WindowsPluginDirectory, EOSWindows32DllFile));
            }

            if (GUILayout.Button(EOSWindows64DllFile))
            {
                LoadDLLFile(Path.Combine(GetRepositoryRoot(), WindowsPluginDirectory, EOSWindows64DllFile));
            }

            if (!string.IsNullOrWhiteSpace(currentPath))
            {
                scrollPosition = GUILayout.BeginScrollView(scrollPosition, GUILayout.MaxHeight(Screen.height));
                GUI.enabled = false;
                GUILayout.TextArea(content);
                GUI.enabled = true;
                GUILayout.EndScrollView();

                if (GUILayout.Button("Show file in Explorer"))
                {
                    EditorUtility.RevealInFinder(currentPath);
                }
            }
        }

        private void LoadTextFile(string filepath)
        {
            content = File.ReadAllText(filepath);
            currentPath = filepath;
        }

        private void LoadDLLFile(string filepath)
        {
            currentPath = filepath;
            EditorUtility.DisplayProgressBar("Deployment Checker", "Loading file...", 0f);

            StringBuilder builder = new StringBuilder();
            long progress = 0;
            using (FileStream fs = File.OpenRead(filepath))
            {
                byte[] b = new byte[1024];
                UTF8Encoding temp = new UTF8Encoding(true);
                while (fs.Read(b, 0, b.Length) > 0)
                {
                    progress += 1024;
                    builder.Append(temp.GetString(b));
                    EditorUtility.DisplayProgressBar("Deploment Checker", "Loading file...",
                        progress / (float)fs.Length);
                }
            }

            string fileContent = builder.ToString();
            if (fileContent.Contains("<<<<<<<"))
            {
                content = fileContent;
            }
            else
            {
                content = "Library file appears okay.";
            }

            EditorUtility.ClearProgressBar();
        }
    }
}
