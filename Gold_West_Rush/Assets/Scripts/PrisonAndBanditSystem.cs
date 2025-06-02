using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class PrisonAndBanditSystem : MonoBehaviour
{
    public Transform startingPoint;                 // Исходная позиция бандитов
    public Transform endPoint;                      // Конечная позиция бандитов
    public float moveDuration = 10f;                // Продолжительность путешествия бандитов
    public float attackCooldown = 10f;              // Интервал между атаками
    public int initialTotalBandits = 10;            // Начальное количество бандитов
    public int stolenResources = 100;               // Максимальное количество украденных ресурсов
    public float prisonReleaseTime = 60f;           // Время содержания бандита в тюрьме (секунды)
    public GameObject banditPrefab;                 // Префаб бандита
    public GameObject prisonCellPrefab;             // Префаб камеры в тюрьме
    public TMP_Text resourceText;                   // Текстовое поле для хранения текущего количества ресурсов
    public TMP_Text upgradeCostText;                // Текстовое поле стоимости улучшения тюрьмы

    List<GameObject> activeBandits = new List<GameObject>();   // Список активных бандитов
    List<GameObject> imprisonedBandits = new List<GameObject>();// Заключённые бандиты
    List<float> releaseTimes = new List<float>();              // Времена освобождения заключённых
    int maxPrisonCells = 5;                                   // Максимальное количество камер в тюрьме
    int upgradeCost = 50;                                     // Первоначальная цена улучшения тюрьмы
    int currentResources;                                      // Переменная для хранения текущего количества ресурсов

    void Start()
    {
        currentResources = int.Parse(resourceText.text); // Читаем текущее количество ресурсов
        SpawnBandits(initialTotalBandits);
    }

    void Update()
    {
        CheckBanditMovement();
        HandlePlayerClicks();
        HandleUpgrade();
        CheckReleaseFromPrison();
    }

    void SpawnBandits(int count)
    {
        for (int i = 0; i < count; i++)
        {
            var newBandit = Instantiate(banditPrefab, startingPoint.position, Quaternion.identity);
            newBandit.name = "Bandit_" + i.ToString();
            activeBandits.Add(newBandit);
        }
    }

    void CheckBanditMovement()
    {
        foreach (var bandit in activeBandits)
        {
            if ((bandit.transform.position - endPoint.position).sqrMagnitude < 0.1f)
            {
                StealResources();
            }
        }
    }

    void StealResources()
    {
        int lostAmount = Random.Range(stolenResources - 10, stolenResources + 10);
        currentResources -= lostAmount;
        resourceText.text = currentResources.ToString(); // Сохраняем обновленное количество ресурсов
        Debug.Log($"Бандиты похитили ${lostAmount} ресурсов.");
    }

    void HandlePlayerClicks()
    {
        if (Input.GetMouseButtonDown(0)) // Щелчок левой кнопкой мыши
        {
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
            RaycastHit hitInfo;
            if (Physics.Raycast(ray, out hitInfo))
            {
                GameObject clickedObj = hitInfo.collider.gameObject;
                if (activeBandits.Contains(clickedObj))
                {
                    ImprisonBandit(clickedObj);
                }
            }
        }
    }

    void ImprisonBandit(GameObject bandit)
    {
        if (imprisonedBandits.Count < maxPrisonCells)
        {
            imprisonedBandits.Add(bandit);
            activeBandits.Remove(bandit);
            releaseTimes.Add(Time.time + prisonReleaseTime);
            Debug.Log($"{bandit.name} отправлен в тюрьму на {prisonReleaseTime} сек.");
        }
        else
        {
            Debug.Log("Невозможно захватить бандита: нет свободных мест в тюрьме!");
        }
    }

    void CheckReleaseFromPrison()
    {
        for (int i = 0; i < imprisonedBandits.Count; i++)
        {
            if (releaseTimes[i] <= Time.time)
            {
                GameObject releasedBandit = imprisonedBandits[i];
                imprisonedBandits.RemoveAt(i);
                releaseTimes.RemoveAt(i);
                Debug.Log($"{releasedBandit.name} выпущен из тюрьмы.");
                break;
            }
        }
    }

    void HandleUpgrade()
    {
        if (Input.GetKeyDown(KeyCode.U)) // 'U' для апгрейда тюрьмы
        {
            UpgradePrison();
        }
    }

    void UpgradePrison()
    {
        if (currentResources >= upgradeCost)
        {
            maxPrisonCells++;                         // Увеличение количества мест в тюрьме
            currentResources -= upgradeCost;          // Затраты ресурсов
            upgradeCost *= 2;                         // Удвоение цены следующего улучшения
            resourceText.text = currentResources.ToString(); // Обновляем текст ресурсов
            upgradeCostText.text = upgradeCost.ToString();   // Обновляем стоимость улучшения
            Debug.Log("Тюрьма улучшена! Доступно новых мест.");
        }
        else
        {
            Debug.Log("Недостаточно ресурсов для улучшения тюрьмы.");
        }
    }
}