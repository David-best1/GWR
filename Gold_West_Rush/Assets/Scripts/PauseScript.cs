using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PauseScript : MonoBehaviour
{
    bool isPaused = false;

    void Update()
    {
        // Нажатие клавиши ESC ставит игру на паузу/возобновление
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            TogglePause();
        }
    }

    // Метод переключения состояния паузы
    void TogglePause()
    {
        isPaused = !isPaused;
        SetPauseState(isPaused);
    }

    // Установка состояния паузы
    void SetPauseState(bool paused)
    {
        if (paused)
        {
            Time.timeScale = 0f;     // Замораживаем игровое время
            Debug.Log("Игра поставлена на паузу");
        }
        else
        {
            Time.timeScale = 1f;     // Возвращаемся к обычному ходу времени
            Debug.Log("Возобновлено!");
        }
    }

    // Дополнительная возможность вызова паузы извне
    public void Pause()
    {
        SetPauseState(true);
    }

    // Возможность снять паузу извне
    public void Resume()
    {
        SetPauseState(false);
    }

    public void P_and_R()
    {
        TogglePause();
    }
}