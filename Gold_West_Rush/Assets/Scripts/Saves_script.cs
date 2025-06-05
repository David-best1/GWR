using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class Saves_script : MonoBehaviour
{
    public List<TMP_Text> textMeshProsList;
    public List<GameObject> gameObjectsList;

    void Start()
    {
        LoadFromPlayerPrefs(); // �������� ��������� � �������� �� PlayerPrefs
    }

    void OnApplicationQuit()
    {
        SaveAllElements(); // ��������� ������ ��� ������ �� ����
    }

    /// <summary>
    /// ��������� ��������� �������� � ������ �� PlayerPrefs
    /// </summary>
    private void LoadFromPlayerPrefs()
    {
        foreach (var go in gameObjectsList)
        {
            if (!string.IsNullOrEmpty(go.name) && PlayerPrefs.HasKey(go.name))
            {
                bool activeState = PlayerPrefs.GetInt(go.name) == 1 ? true : false;
                go.SetActive(activeState); // ���������� ��� ������������ ������
            }
        }

        foreach (var tmp in textMeshProsList)
        {
            if (!string.IsNullOrEmpty(tmp.text) && PlayerPrefs.HasKey(tmp.text))
            {
                string savedValue = PlayerPrefs.GetString(tmp.text);
                tmp.text = savedValue; // ������������� �������� ������
            }
        }
    }

    /// <summary>
    /// ��������� � ��������� ����� ������ � PlayerPrefs ��� ������ �������
    /// </summary>
    private void SaveAllElements()
    {
        foreach (var go in gameObjectsList)
        {
            if (!string.IsNullOrEmpty(go.name))
            {
                EnsureKeyExistsForGO(go.name, go.activeSelf);
            }
        }

        foreach (var tmp in textMeshProsList)
        {
            if (!string.IsNullOrEmpty(tmp.text))
            {
                EnsureKeyExistsForTMP(tmp.text, tmp.text);
            }
        }
    }

    /// <summary>
    /// ������� ������ � PlayerPrefs ��� �������� �������
    /// </summary>
    private void EnsureKeyExistsForGO(string name, bool state)
    {
        if (!PlayerPrefs.HasKey(name))
        {
            int value = state ? 1 : 0;
            PlayerPrefs.SetInt(name, value);
            Debug.Log($"Added key '{name}' with state {state}.");
        }
    }

    /// <summary>
    /// ������� ������ � PlayerPrefs ��� ���������� TextMeshPro
    /// </summary>
    private void EnsureKeyExistsForTMP(string name, string content)
    {
        if (!PlayerPrefs.HasKey(name))
        {
            PlayerPrefs.SetString(name, content);
            Debug.Log($"Added key '{name}' with content '{content}'.");
        }
    }
}