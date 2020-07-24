using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TowerPlace : MonoBehaviour
{
    private Color startColor;
    private Renderer renderer;
    private bool isClicked = false;
    private bool isFree = true;

    private void Start()
    {
        renderer = gameObject.GetComponent<Renderer>();
        startColor = renderer.material.color;
    }

    private void OnMouseEnter()
    {
        if (!BuildUI.IsReadyToBuild())
        {
            renderer.material.color = Color.yellow;
        }
    }

    private void OnMouseExit()
    {
        if (!BuildUI.IsReadyToBuild())
        {
            renderer.material.color = startColor;
        }
    }

    private void OnMouseDown()
    {
        if (!BuildUI.IsReadyToBuild() && !isClicked && isFree)
        {
            BuildUI.CreateTowerBuildUI(this.transform);
            isClicked = true;
            BuildUI.ChangeBuildBool();
        }
        else if (BuildUI.IsReadyToBuild() && isClicked && isFree)
        {
            BuildUI.DestroyUI();
            isClicked = false;
            BuildUI.ChangeBuildBool();
        }
    }

    public void TowerIsBuild()
    {
        isFree = false;
        renderer.material.color = startColor;
    }
}