using UnityEngine;
using UnityEditor;
using UnityEditor.SceneManagement;

public class LevelNeeds : Editor
{
    [MenuItem("Level/Needed")]
    private static void SetupLevel()
    {
        PrefabUtility.InstantiatePrefab(Resources.Load("Level/SpawnSystem"));
        PrefabUtility.InstantiatePrefab(Resources.Load("Level/WayPointSystem"));
        PrefabUtility.InstantiatePrefab(Resources.Load("Level/TowerPlaceingSystem"));
        PrefabUtility.InstantiatePrefab(Resources.Load("UI/BuildUI"));

        EditorSceneManager.MarkSceneDirty(EditorSceneManager.GetActiveScene());  
    }
}