using UnityEngine;

public class GameQuitter : MonoBehaviour
{
    // Метод для вызова при выходе из игры
    public void QuitGame()
    {
#if UNITY_EDITOR
        UnityEditor.EditorApplication.isPlaying = false;
#else
        Application.Quit();
#endif
    }
}