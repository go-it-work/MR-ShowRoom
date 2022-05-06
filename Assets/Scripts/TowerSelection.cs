using System;
using System.Collections;
using System.Collections.Generic;
using Microsoft.MixedReality.Toolkit;
using UnityEngine;

public class TowerSelection : MonoBehaviour
{
    // The parent where all towers are going to be instantiated
    [SerializeField] private GameObject towersParent;
    [SerializeField] private GameObject handMenu;
    private GameObject activeTower;

    // Fixed positions to instantiate prefabs
    private Vector3 position = new Vector3(0, -0.15f, 0.6f);
    private Quaternion rotation = new Quaternion(0, -45, 0, 0);

    // Parameter to instantiate unit after
    private static string towerName = null;

    public static string TowerName
    {
        get => towerName;
    }

    // Setting up scene
    void Start()
    {
        DestroyAllTowers();
        handMenu.SetActive(false);
    }

    // Instantiating the object inside the scene
    // Assign the parameter via Inspector inside Unity
    public void InstantiateTower(GameObject tower)
    {
        DestroyAllTowers();

        // Disabling the menu when the tower is instantiate
        this.gameObject.transform.parent.gameObject.SetActive(false);
        handMenu.SetActive(true);

        // Creating the object inside a parent to make easier to deal with it later on
        activeTower = Instantiate(tower, position, rotation, towersParent.transform) as GameObject;

        // Saving the tower name
        towerName = tower.name;
    }

    // Destroy all and any other tower inside scene to clean it
    private void DestroyAllTowers()
    {
        // Cleaning up the old name
        towerName = null;

        try
        {
            foreach (Transform child in towersParent.transform)
            {
                Destroy(child);
            }
        }
        catch (Exception e)
        {
            Debug.Log(e.Message);
        }

    }

    // Set new scales and different views to the tower - helping the user to see it clearer
    public void SetTowerScales(int scale)
    {
        // Those parameters are going to be set inside the inspector
        activeTower.transform.localScale = scale switch
        {
            1 => new Vector3(1, 1, 1),
            10 => new Vector3(0.1f, 0.1f, 0.1f),
            100 => new Vector3(0.01f, 0.01f, 0.01f),
            1000 => new Vector3(0.001f, 0.001f, 0.001f),
            _ => activeTower.transform.localScale
        };
    }

    // Set the point of view for the user
    public void SetTowerView(int positionCode)
    {
        activeTower.transform.eulerAngles = positionCode switch
        {
            // Right lateral
            1 => new Vector3(0f, 90f, 0f),
            // Back
            2 => new Vector3(0f, 0f, 0f),
            // Left lateral
            3 => new Vector3(0f, 270f, 0f),
            // Front
            4 => new Vector3(0f, 180f, 0f),
            _ => activeTower.transform.eulerAngles
        };
    }
}
