using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bust : MonoBehaviour
{

    public Animator animator;
    public float originalSpeed;
    public float speedMultiplier;
    public float speedUpDuration;
    public float lastBoostTime = 0f;    // ����� ���������� ������� ������
    public int boostCount = 0;          // ������� �������

    void Start()
    {
        // ��������� �������� �������� ��������
        originalSpeed = animator.speed;
    }


    void Update()
    {

    }

    public void Bust_Click()
    {
        // ��������� ����� ���������� �������
        lastBoostTime = Time.time;

        // ����������� ������� �������
        boostCount++;

        // ���� ��������� ��� �� ���� ���������, ��������� ���
        if (animator.speed == originalSpeed)
        {
            ApplyBoost();
        }
    }

    private void ApplyBoost()
    {
        // ����������� �������� ��������
        animator.speed *= speedMultiplier;

        // �������� �������� ��������� ������� ���������
        StartCoroutine(CheckBoostExpiration());
    }

    private IEnumerator CheckBoostExpiration()
    {
        // ����, ���� �� ������� ������������� ����� � ������� ���������� �������
        while (Time.time < lastBoostTime + speedUpDuration)
        {
            yield return null;
        }

        // ��������� ������� �������
        boostCount--;

        // ���� ������ ��� �������� �������, ���������� ���������
        if (boostCount <= 0)
        {
            ResetBoost();
        }
        else
        {
            // ����� ���������� ����� ���������� ��������� �������
            StartCoroutine(CheckBoostExpiration());
        }
    }

    private void ResetBoost()
    {
        // ���������� �������� �������� ��������
        animator.speed = originalSpeed;
        lastBoostTime = 0;
    }
}
