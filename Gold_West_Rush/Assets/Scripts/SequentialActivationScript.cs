using System;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class AutoResourceObjectActivator : MonoBehaviour
{
    // ������ ��������, ������� ������������ ����������
    public List<GameObject> objectsToActivate;

    // �������� ������ �������� ��� ��������� ���������� �������
    public float thresholdInterval = 30f;

    // ������� ���������� ��������
    public TMP_Text Resourses;

    // ��������� �������� ������ ��������
    private int currentLevel = 0;
    void Update()
    {
        int currentResources = Int32.Parse(Resourses.text);
        // ���� �������� ������ ������ ��������, ��������� �� ��������� �������
        if (currentResources >= (currentLevel + 1) * thresholdInterval)
        {
            currentLevel++; // ������� �� ��������� �������

            // ���������, ���� �� ��� ������� ��� ���������
            if (currentLevel < objectsToActivate.Count)
            {
                objectsToActivate[currentLevel].SetActive(true); // �������� ��������� ������
            }
        }
        else
        {
            if (currentResources < (currentLevel) * thresholdInterval) {
                currentLevel--; // ������� �� ��������� �������
                ResetObject();
            }
        }
    }

    // ������� ���������� ���������� ���� ��������
    private void ResetObject()
    {
        objectsToActivate[currentLevel].SetActive(false);
    }
}