using Assets.Scripts.Utility;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Emit;
using UnityEditor;
using UnityEditorInternal;

namespace Assets.Scripts.Configs.Editor
{
    [CustomEditor(typeof(WritersSetting))]
    public class WritersSettingEditor : UnityEditor.Editor
    {
        private ReorderableList reorderableList;
        private string[] options;
        private List<AuthorDataWrapper> writersList = new List<AuthorDataWrapper>();


        public override void OnInspectorGUI()
        {
            //base.OnInspectorGUI();
            this.serializedObject.Update();

            ReloadOptions();
            if (options != null && options.Length > 0)
            {
                EditorGUILayout.LabelField("От имени пользователя:");
                ((WritersSetting) target).ChosenWriter =
                    EditorGUILayout.Popup(((WritersSetting) target).ChosenWriter, options);
            }
            else
            {
                EditorGUILayout.HelpBox("Список участников пуст!!!", MessageType.Error);
            }

            EditorGUILayout.Space();
            ReorderableListUtility.DoLayoutListWithFoldout(reorderableList);

            this.serializedObject.ApplyModifiedProperties();
        }

        private void OnEnable()
        {
            var writers = serializedObject.FindProperty("writers");
            writersList = ((WritersSetting) target).Writers;
            reorderableList = ReorderableListUtility.CreateAutoLayout(writers);
        }

        private void ReloadOptions()
        {
            options = writersList!=null && writersList.Count>0?  writersList?.Where(X=>X!=null && X.Data!=null).Select(I => I.Data.WriterName).ToArray():null;
        }
    }
}
