using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TowerPanel : MonoBehaviour
{
    private TowerInformation tower;
    private Transform towerPlace;

    public void Down()
    {
        GameObject tower = Instantiate(this.tower.GetTowerPrefab(),towerPlace.position,Quaternion.identity) ;
        tower.transform.parent = towerPlace;
        towerPlace.gameObject.GetComponent<TowerPlace>().TowerIsBuild();
        BuildUI.ChangeBuildBool();
        BuildUI.DestroyUI();
    }

    public void GetTheInformation(TowerInformation tower, Transform towerPlace)
    {
        this.tower = tower;
        this.towerPlace = towerPlace;
    }
}