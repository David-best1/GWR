using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class PrisonAndBanditSystem : MonoBehaviour
{
    public Transform startingPoint;                 // �������� ������� ��������
    public Transform endPoint;                      // �������� ������� ��������
    public float moveDuration = 10f;                // ����������������� ����������� ��������
    public float attackCooldown = 10f;              // �������� ����� �������
    public int initialTotalBandits = 10;            // ��������� ���������� ��������
    public int stolenResources = 100;               // ������������ ���������� ���������� ��������
    public float prisonReleaseTime = 60f;           // ����� ���������� ������� � ������ (�������)
    public GameObject banditPrefab;                 // ������ �������
    public GameObject prisonCellPrefab;             // ������ ������ � ������
    public TMP_Text resourceText;                   // ��������� ���� ��� �������� �������� ���������� ��������
    public TMP_Text upgradeCostText;                // ��������� ���� ��������� ��������� ������

    List<GameObject> activeBandits = new List<GameObject>();   // ������ �������� ��������
    List<GameObject> imprisonedBandits = new List<GameObject>();// ����������� �������
    List<float> releaseTimes = new List<float>();              // ������� ������������ �����������
    int maxPrisonCells = 5;                                   // ������������ ���������� ����� � ������
    int upgradeCost = 50;                                     // �������������� ���� ��������� ������
    int currentResources;                                      // ���������� ��� �������� �������� ���������� ��������

    void Start()
    {
        currentResources = int.Parse(resourceText.text); // ������ ������� ���������� ��������
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
        resourceText.text = currentResources.ToString(); // ��������� ����������� ���������� ��������
        Debug.Log($"������� �������� ${lostAmount} ��������.");
    }

    void HandlePlayerClicks()
    {
        if (Input.GetMouseButtonDown(0)) // ������ ����� ������� ����
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
            Debug.Log($"{bandit.name} ��������� � ������ �� {prisonReleaseTime} ���.");
        }
        else
        {
            Debug.Log("���������� ��������� �������: ��� ��������� ���� � ������!");
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
                Debug.Log($"{releasedBandit.name} ������� �� ������.");
                break;
            }
        }
    }

    void HandleUpgrade()
    {
        if (Input.GetKeyDown(KeyCode.U)) // 'U' ��� �������� ������
        {
            UpgradePrison();
        }
    }

    void UpgradePrison()
    {
        if (currentResources >= upgradeCost)
        {
            maxPrisonCells++;                         // ���������� ���������� ���� � ������
            currentResources -= upgradeCost;          // ������� ��������
            upgradeCost *= 2;                         // �������� ���� ���������� ���������
            resourceText.text = currentResources.ToString(); // ��������� ����� ��������
            upgradeCostText.text = upgradeCost.ToString();   // ��������� ��������� ���������
            Debug.Log("������ ��������! �������� ����� ����.");
        }
        else
        {
            Debug.Log("������������ �������� ��� ��������� ������.");
        }
    }
}