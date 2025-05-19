using System;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class AutoResourceObjectActivator : MonoBehaviour
{
    // Массив объектов, которые активируются поочередно
    public List<GameObject> objectsToActivate;

    // Интервал порога ресурсов для активации следующего объекта
    public float thresholdInterval = 30f;

    // Текущее количество ресурсов
    public TMP_Text Resourses;

    // Индикатор текущего уровня ресурсов
    private int currentLevel = 0;
    void Update()
    {
        int currentResources = Int32.Parse(Resourses.text);
        // Если достигли нового порога ресурсов, переходим на следующий уровень
        if (currentResources >= (currentLevel + 1) * thresholdInterval)
        {
            currentLevel++; // Переход на следующий уровень

            // Проверяем, есть ли ещё объекты для активации
            if (currentLevel < objectsToActivate.Count)
            {
                objectsToActivate[currentLevel].SetActive(true); // Включаем следующий объект
            }
        }
        else
        {
            if (currentResources < (currentLevel) * thresholdInterval) {
                currentLevel--; // Переход на следующий уровень
                ResetObject();
            }
        }
    }

    // Функция сбрасывает активность всех объектов
    private void ResetObject()
    {
        objectsToActivate[currentLevel].SetActive(false);
    }
}