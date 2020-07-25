using NaughtyAttributes;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Reflection;
using UnityEditor;
using UnityEditor.SceneManagement;
using UnityEngine;

public class TowerPlacingSystem : Singleton<TowerPlacingSystem>
{
    [SerializeField] private GameObject towerPlace;

    private List<GameObject> towerPlaces;

    private int index = 1;


    [Button]
    private void AddTowerPlace()
    {
        int childs = transform.childCount;

        if (index <= childs)
        {
            index = childs + 1;
        }

        GameObject tower = Instantiate(towerPlace, transform.position, Quaternion.identity);
        tower.name = "TowerPlace" + index;
        tower.transform.parent = this.gameObject.transform;
        DrawIcon(tower, 1);
        index++;

        EditorSceneManager.MarkSceneDirty(EditorSceneManager.GetActiveScene());
    }

    [Button]
    private void RemoveTowerPlace()
    {
        int childs = transform.childCount;

        if(index <= childs + 1 && index != 1)
        {
            index = childs + 1;
        }

        for (int i = 0; i < childs; i++)
        {
            if (i == childs -1)
            {
                DestroyImmediate(transform.GetChild(i).gameObject);
                index--;
            }
        }
        EditorSceneManager.MarkSceneDirty(EditorSceneManager.GetActiveScene());
    }

    private void DrawIcon(GameObject gameObject, int idx)
    {
        GUIContent[] icons = GetTextures("sv_label_", string.Empty, 0, 8);
        GUIContent icon = icons[idx];
        Type eGU = typeof(EditorGUIUtility);
        BindingFlags flags = BindingFlags.InvokeMethod | BindingFlags.Static | BindingFlags.NonPublic;
        object[] iconBind = new object[] { gameObject, icon.image };
        MethodInfo setIcon = eGU.GetMethod("SetIconForObject", flags, null, new Type[] { typeof(UnityEngine.Object), typeof(Texture2D) }, null);
        setIcon.Invoke(null, iconBind);
    }

    private GUIContent[] GetTextures(string baseName, string postFix, int startIndex, int count)
    {
        GUIContent[] Iconarray = new GUIContent[count];
        for (int i = 0; i < count; i++)
        {
            Iconarray[i] = EditorGUIUtility.IconContent(baseName + (startIndex + i) + postFix);
        }
        return Iconarray;
    }
}