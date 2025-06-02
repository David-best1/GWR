using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PauseScript : MonoBehaviour
{
    bool isPaused = false;

    void Update()
    {
        // ������� ������� ESC ������ ���� �� �����/�������������
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            TogglePause();
        }
    }

    // ����� ������������ ��������� �����
    void TogglePause()
    {
        isPaused = !isPaused;
        SetPauseState(isPaused);
    }

    // ��������� ��������� �����
    void SetPauseState(bool paused)
    {
        if (paused)
        {
            Time.timeScale = 0f;     // ������������ ������� �����
            Debug.Log("���� ���������� �� �����");
        }
        else
        {
            Time.timeScale = 1f;     // ������������ � �������� ���� �������
            Debug.Log("������������!");
        }
    }

    // �������������� ����������� ������ ����� �����
    public void Pause()
    {
        SetPauseState(true);
    }

    // ����������� ����� ����� �����
    public void Resume()
    {
        SetPauseState(false);
    }

    public void P_and_R()
    {
        TogglePause();
    }
}