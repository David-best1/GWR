using UnityEngine;

public class ScaleOnHover : MonoBehaviour
{
    public float scaleFactor = 1.2f; // Коэффициент увеличения размера

    private Vector3 originalScale; // Исходный масштаб объекта

    private void Start()
    {
        originalScale = transform.localScale; // Сохранение текущего масштаба
    }

    private void OnMouseEnter()
    {
        transform.localScale *= scaleFactor; // Увеличение масштаба при входе мыши
    }

    private void OnMouseExit()
    {
        transform.localScale = originalScale; // Возвращаем первоначальный масштаб при выходе мыши
    }
}