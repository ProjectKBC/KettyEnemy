//using UnityEngine;
//using UnityEditor;

//[CustomEditor(typeof(NoaCameraManager))]
//public sealed class NoaCameraManagerEditor : Editor
//{
//    private void OnEnable()
//    {

//    }

//    public override void OnInspectorGUI()
//    {
//        NoaCameraManager t = this.target as NoaCameraManager;

//        GUILayout.Space(5.0f);

//        NoaCameraManager.SettingParam[] param_ = t.serializedParams;

//        int count = EditorGUILayout.IntField("Count", t.transform.childCount);//param_.Length);
//        System.Array.Resize(ref param_, count);

//        for (int i = 0; i < count; ++i)
//        {
//            NoaCameraManager.SettingParam param = param_[0];

//            GUILayout.BeginHorizontal();
//            GUIContent content = new GUIContent(i.ToString("D3"), "Asset 指定");
//            param.isLive = EditorGUILayout.Toggle("SetActive", param.isLive);
//            param.obj = EditorGUILayout.ObjectField
//                               (
//                                   content,
//                                   param.obj,
//                                   typeof(Object),
//                                   false,
//                                   GUILayout.MinWidth(250.0f)
//                               ) as GameObject;
//            param.depth = EditorGUILayout.FloatField(param.depth, GUILayout.MaxWidth(75.0f));
//            EditorGUILayout.EnumPopup(param.cullingMask, GUILayout.MaxWidth(75.0f));
//            GUILayout.EndHorizontal();
//        }
//        t.serializedParams = param_;

//        if (GUI.changed || (count != param_.Length))
//        {
//            EditorUtility.SetDirty(t);
//        }
//    }
//}