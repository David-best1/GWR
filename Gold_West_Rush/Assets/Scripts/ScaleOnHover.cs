using UnityEngine;

public class ScaleOnHover : MonoBehaviour
{
    public float scaleFactor = 1.2f; // ����������� ���������� �������

    private Vector3 originalScale; // �������� ������� �������

    private void Start()
    {
        originalScale = transform.localScale; // ���������� �������� ��������
    }

    private void OnMouseEnter()
    {
        transform.localScale *= scaleFactor; // ���������� �������� ��� ����� ����
    }

    private void OnMouseExit()
    {
        transform.localScale = originalScale; // ���������� �������������� ������� ��� ������ ����
    }
}