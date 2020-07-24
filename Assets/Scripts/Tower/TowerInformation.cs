using UnityEngine;
using UnityEngine.UI;

[CreateAssetMenu(fileName = "TowerInformation", menuName = "Tower Information", order = 1)]
public class TowerInformation : ScriptableObject
{
    [SerializeField] private string towerName;
    [SerializeField] private GameObject tower;
    [SerializeField] private Image towerImage;
    [SerializeField] private int buildCost;
    [TextArea][SerializeField] private string towerInformation;

    public string GetTowerName()
    {
        return towerName;
    }

    public GameObject GetTowerPrefab()
    {
        return tower;
    }

    public Image GetImage()
    {
        return towerImage;
    }

    public int GetTowerCost()
    {
        return buildCost;
    }

    public string GetTowerInformation()
    {
        return towerInformation;
    }
}