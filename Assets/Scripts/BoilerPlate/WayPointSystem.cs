using NaughtyAttributes;
using System;
using System.Collections.Generic;
using System.Reflection;
using UnityEditor;
using UnityEngine;

public class WayPointSystem : Singleton<WayPointSystem>
{
    [SerializeField] private int numberOfWayPoints;
    [SerializeField] private List<GameObject> wayPoints;

    public static List<GameObject> GetWayPoints()
    {
        return Instance.wayPoints;
    }

    public static Transform GetStartPoint()
    {
        return Instance.wayPoints[0].transform;
    }

    [Button]
    private void CreateWayPoints()
    {
        ClearAllWayPoints();
        for (int i = 0; i < numberOfWayPoints; i++)
        {
            GameObject wP = new GameObject();
            if (i == 0)
            {
                wP.name = "Start";
                DrawIcon(wP, 3);
            }
            else if (i > 0 && i < numberOfWayPoints - 1)
            {
                wP.name = "WayPoint" + (i);
                DrawIcon(wP, 5);
            }
            else
            {
                wP.name = "End";
                DrawIcon(wP, 6);
            }
            wP.transform.parent = this.gameObject.transform;

            wayPoints.Add(wP);
        }
        UnityEditorInternal.ComponentUtility.CopyComponent(this);
        UnityEditorInternal.ComponentUtility.PasteComponentValues(this);
    }

    [Button]
    private void ClearAllWayPoints()
    {
        foreach (GameObject wP in wayPoints)
        {
            DestroyImmediate(wP.gameObject);
        }
        wayPoints.Clear();
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