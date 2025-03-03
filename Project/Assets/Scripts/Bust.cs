using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bust : MonoBehaviour
{

    public Animator animator;
    public float originalSpeed;
    public float speedMultiplier;
    public float speedUpDuration;
    public float lastBoostTime = 0f;    // Время последнего нажатия кнопки
    public int boostCount = 0;          // Счетчик нажатий

    void Start()
    {
        // Сохраняем исходную скорость анимации
        originalSpeed = animator.speed;
    }


    void Update()
    {

    }

    public void Bust_Click()
    {
        // Обновляем время последнего нажатия
        lastBoostTime = Time.time;

        // Увеличиваем счетчик нажатий
        boostCount++;

        // Если ускорение ещё не было применено, применяем его
        if (animator.speed == originalSpeed)
        {
            ApplyBoost();
        }
    }

    private void ApplyBoost()
    {
        // Увеличиваем скорость анимации
        animator.speed *= speedMultiplier;

        // Начинаем проверку истечения времени ускорения
        StartCoroutine(CheckBoostExpiration());
    }

    private IEnumerator CheckBoostExpiration()
    {
        // Ждем, пока не пройдет установленное время с момента последнего нажатия
        while (Time.time < lastBoostTime + speedUpDuration)
        {
            yield return null;
        }

        // Уменьшаем счетчик нажатий
        boostCount--;

        // Если больше нет активных нажатий, сбрасываем ускорение
        if (boostCount <= 0)
        {
            ResetBoost();
        }
        else
        {
            // Иначе продолжаем ждать следующего истечения времени
            StartCoroutine(CheckBoostExpiration());
        }
    }

    private void ResetBoost()
    {
        // Возвращаем исходную скорость анимации
        animator.speed = originalSpeed;
        lastBoostTime = 0;
    }
}
