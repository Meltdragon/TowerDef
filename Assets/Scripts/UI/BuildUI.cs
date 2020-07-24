using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BuildUI : Singleton<BuildUI>
{
    private bool isReadyToBuild = false;

    [SerializeField] private List<TowerInformation> towers;
    [SerializeField] private GameObject towerPanel;
    [SerializeField] private float xOffSet;

    public static void CreateTowerBuildUI(Transform towerPlace)
    {
        float sizeX = Instance.towerPanel.GetComponent<RectTransform>().rect.width;
        Vector3 positionPanel = new Vector3(10, 0, 0);
        for(int i = 0;i< Instance.towers.Count;i++)
        {
            GameObject panel = Instantiate(Instance.towerPanel, Instance.transform.position, Quaternion.identity);
            panel.GetComponent<TowerPanel>().GetTheInformation(Instance.towers[i], towerPlace);
            panel.transform.SetParent(Instance.gameObject.transform, false);
            //panel.transform.parent = Instance.gameObject.transform;
            panel.transform.position = positionPanel;
            positionPanel = new Vector3(positionPanel.x + sizeX + Instance.xOffSet, 0 , 0);
        }
    }

    public static void DestroyUI()
    {
        foreach(Transform child in Instance.transform)
        {
            Destroy(child.gameObject);
        }
    }

    public static void ChangeBuildBool()
    {
        Instance.isReadyToBuild = !Instance.isReadyToBuild;
    }

    public static bool IsReadyToBuild()
    {
        return Instance.isReadyToBuild;
    }
}