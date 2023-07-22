﻿//This project is open source. Anyone can use any part of this code however they wish
//Feel free to use this code in your own projects, or expand on this code
//If you have any improvements to the code itself, please visit
//https://github.com/Dharengo/Spriter2UnityDX and share your suggestions by creating a fork
//-Dengar/Dharengo

using System;
using System.Collections.Generic;
using System.IO;
using System.Xml.Serialization;
using UnityEditor;
using UnityEditor.Animations;
using UnityEngine;

//Detects when a .scml file has been imported, then begins the process to create the prefab
public class ScmlPostProcessor : AssetPostprocessor
{
    private static readonly IList<string> cachedPaths = new List<string>();


    //Called after an import, detects if imported files end in .scml
    [Obsolete("Obsolete")]
    private static void OnPostprocessAllAssets(string[] importedAssets, string[] deletedAssets,
        string[] movedAssets, string[] movedFromAssetPaths)
    {
        var filesToProcess = new List<string>();
        var optionsNeedUpdated = false;

        //Called after an import, detects if imported files end in .scml
        static void OnPostprocessAllAssets(string[] importedAssets, string[] deletedAssets,
            string[] movedAssets, string[] movedFromAssetPaths)
        {
            var filesToProcess = new List<string>();
            var optionsNeedUpdated = false;

            foreach (var path in importedAssets)
                if (path.EndsWith(".scml") && !path.Contains("autosave"))
                {
                    filesToProcess.Add(path);
                    if (!cachedPaths.Contains(path)) optionsNeedUpdated = true;
                }

            foreach (var path in cachedPaths) //Are there any incomplete processes from the last import cycle?
                if (!filesToProcess.Contains(path))
                    filesToProcess.Add(path);
            cachedPaths.Clear();
            if (filesToProcess.Count > 0)
            {
                if (optionsNeedUpdated || ScmlImportOptions.options == null)
                {
                    var optionsWindow = EditorWindow.GetWindow<ScmlImportOptionsWindow>();
                    ScmlImportOptions.options = new ScmlImportOptions();
                    optionsWindow.OnClose += () => ProcessFiles(filesToProcess);
                }
                else
                {
                    ProcessFiles(filesToProcess);
                }
            }
        }

        static void ProcessFiles(IList<string> paths)
        {
            var info = new ScmlProcessingInfo();
            var builder = new PrefabBuilder(info);
            foreach (var path in paths)
                if (!builder.Build(Deserialize(path),
                        path)) //Process will fail if texture import settings need to be updated
                    cachedPaths.Add(
                        path); //Failed processes will be saved and re-attempted during the next import cycle
            AssetDatabase.Refresh();
            AssetDatabase.SaveAssets();
            PostProcess(info);
        }

        static ScmlObject Deserialize(string path)
        {
            var serializer = new XmlSerializer(typeof(ScmlObject));
            using (var reader = new StreamReader(path))
            {
                return (ScmlObject)serializer.Deserialize(reader);
            }
        }

        static void PostProcess(ScmlProcessingInfo info)
        {
            //You can put your own code or references to your own code here
            //If you want to do any work on these assets
        }
    }

    public class ScmlProcessingInfo
    {
        public ScmlProcessingInfo()
        {
            NewPrefabs = new List<GameObject>();
            ModifiedPrefabs = new List<GameObject>();
            NewAnims = new List<AnimationClip>();
            ModifiedAnims = new List<AnimationClip>();
            NewControllers = new List<AnimatorController>();
            ModifiedControllers = new List<AnimatorController>();
        }

        public List<GameObject> NewPrefabs { get; set; }
        public List<GameObject> ModifiedPrefabs { get; set; }
        public List<AnimationClip> NewAnims { get; set; }
        public List<AnimationClip> ModifiedAnims { get; set; }
        public List<AnimatorController> NewControllers { get; set; }
        public List<AnimatorController> ModifiedControllers { get; set; }
    }
}