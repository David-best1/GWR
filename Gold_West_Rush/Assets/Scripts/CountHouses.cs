using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class CountHouses : MonoBehaviour
{
    public int activeHousesCount;
    void Update()
    {
        activeHousesCount = GameObject.FindGameObjectsWithTag("House")
            .Where(house => house.activeInHierarchy)
            .ToArray().Length;

        Debug.Log($"Количество активных домов: {activeHousesCount}");
    }
}
