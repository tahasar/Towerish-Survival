using System;
using UnityEditor;
using UnityEngine;

namespace Source.Wraith_Karakteri.Vector_Parts.Spriter2UnityDX
{
    public class ScmlImportOptionsWindow : EditorWindow
    {
        public Action OnClose;

        private void OnEnable()
        {
            titleContent = new GUIContent("Import Options");
            if (ScmlImportOptions.options == null) ScmlImportOptions.options = new ScmlImportOptions();
        }

        private void OnDestroy()
        {
            OnClose();
        }

        private void OnGUI()
        {
            ScmlImportOptions.options.pixelsPerUnit =
                EditorGUILayout.FloatField(ScmlImportOptions.options.pixelsPerUnit);
            if (GUILayout.Button("Done")) Close();
        }
    }

    public class ScmlImportOptions
    {
        public static ScmlImportOptions options;

        public float pixelsPerUnit = 100f;
    }
}