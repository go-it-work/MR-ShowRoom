using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class Scales : MonoBehaviour
{
    // Fields and properties
    [SerializeField] private GameObject apartment;

    // Set scale to 1:10
    public void SetScaleToTen()
    {
        apartment.transform.localScale = new Vector3(1, 1, 1);
    }

    // Set scale to 1:100
    public void SetScaleToHundred()
    {
        apartment.transform.localScale = new Vector3(0.57f, 0.57f, 0.57f);
    }

    // Set scale to 1:1000
    public void SetScaleToThousand()
    {
        apartment.transform.localScale = new Vector3(0.057f, 0.057f, 0.057f);
    }
}
