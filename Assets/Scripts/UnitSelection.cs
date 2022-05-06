using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class UnitSelection : MonoBehaviour
{
    // Property to receive the selected floor
    private string FloorNumber { get; set; }

    public void SetFloor(TextMeshPro tmp)
    {
        // Composed string that returns the tower and floor number
        FloorNumber = TowerSelection.TowerName + "A" + tmp.text;

        // Getting the tower through parent relation
        var iconAndText = tmp.transform.parent.gameObject;
        var button = iconAndText.transform.parent.gameObject;
        var floors = button.transform.parent.gameObject;
        var tower = floors.transform.parent.gameObject;

        tower.SetActive(false);
    }

    public void SetUnit(string unitName)
    {
        // Composed (and final) string to instantiate the unit fbx
        var unit = FloorNumber + unitName;

        // Finding and instantiating the unit
        var activeUnit = Resources.Load("Assets/Uploads/Units/" + unit) as GameObject;
        var position = new Vector3(0f, -0.15f, 0.5f);
        Instantiate(activeUnit, position, activeUnit.transform.rotation);
    }
}
