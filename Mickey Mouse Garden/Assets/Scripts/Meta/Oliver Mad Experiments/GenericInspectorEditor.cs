using System.Reflection;
#if UNITY_EDITOR
using UnityEditor;

using UnityEngine;
[CustomEditor(typeof(MonoBehaviour),editorForChildClasses:true)]
public class GenericInspectorEditor : Editor{
    static string unityNameSpace = "Unity";
    static bool isUnityNameSpace;
    CustomComponentAttribute customComponentAttribute;
    static GUIStyle titleStyle;
    protected virtual void OnEnable(){
        string targetNamespace = target.GetType().Namespace;
        
        if (!string.IsNullOrEmpty(targetNamespace)){
            isUnityNameSpace = targetNamespace.StartsWith(unityNameSpace);
        }

        if (customComponentAttribute == null){
            customComponentAttribute = GetCustomComponentAttribute(target);
        }
    }

    public override void OnInspectorGUI(){
        if (customComponentAttribute != null){
            if (customComponentAttribute.State != default){
                StateGUI(customComponentAttribute);
            }
            if (!isUnityNameSpace){
                HeaderGUI(customComponentAttribute);
            }
        }
        base.OnInspectorGUI();
    }

    public static void StateGUI(CustomComponentAttribute componentAttribute){
        if (componentAttribute == null){
            return;
        }
       
        GUILayout.Space(5f);
        EditorGUILayout.BeginHorizontal();
        
        GUILayout.FlexibleSpace();
        var savedColor = GUI.contentColor;
        GUI.contentColor = Color.yellow;
        GUILayout.Label(componentAttribute.State);
        GUI.contentColor = savedColor;
        GUILayout.FlexibleSpace();
        
        EditorGUILayout.EndHorizontal();
    }

    public static void HeaderGUI(CustomComponentAttribute componentAttribute){
        if (componentAttribute == null){
            return;
        }

        if (titleStyle == null){
            titleStyle = new GUIStyle(GUI.skin.label);
            titleStyle.fontSize = 15;
            titleStyle.fontStyle = FontStyle.Bold;
            titleStyle.alignment = TextAnchor.MiddleCenter;
        }
        GUILayout.Space(5f);
        EditorGUILayout.BeginHorizontal();
        
        GUILayout.FlexibleSpace();
        GUILayout.Label(componentAttribute.Name);
        GUILayout.FlexibleSpace();
        
        EditorGUILayout.EndHorizontal();
        
        EditorGUILayout.BeginHorizontal();
        
        GUILayout.FlexibleSpace();
        GUILayout.Box(componentAttribute.Description, GUILayout.Width(Screen.width * 0.5f));
        GUILayout.FlexibleSpace();
        
        EditorGUILayout.EndHorizontal();
        
        GUILayout.Space(15f);
        
        
    }
    public static CustomComponentAttribute GetCustomComponentAttribute(UnityEngine.Object obj){
        return obj.GetType().GetCustomAttribute<CustomComponentAttribute>();
    }
}
#endif