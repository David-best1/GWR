using UnityEngine;

public class MusicVolumeController : MonoBehaviour
{
    public AudioSource audioSource;
    public float initialVolume;
    public int clickCount = 0;

    void Start()
    {
        if (!audioSource)
            Debug.LogError("Компонент AudioSource отсутствует!");

        initialVolume = audioSource.volume;
    }

    public void AdjustVolume()
    {
        if (clickCount == 0)
        {
            audioSource.volume -= initialVolume / 3f;
        }
        else if (clickCount == 1)
        {
            audioSource.volume -= audioSource.volume * 2f / 3f;
        }
        else if (clickCount == 2)
        {
            audioSource.Stop();
        }
        else
        {
            audioSource.Play();
            audioSource.volume = initialVolume;
            clickCount = -1;
        }
        clickCount++;
    }
}