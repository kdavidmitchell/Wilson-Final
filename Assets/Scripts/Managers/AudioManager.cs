using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class AudioManager : MonoBehaviour
{

    [SerializeField] private float delay = 2f;

    private void Start()
    {
        StartCoroutine(StartReset());   
    }

    //function to be called on button click
    public void LoadNextLevel(string name)
    {
        StartCoroutine(LevelLoad(name));
    }

    public void DestroyAudioSource()
    {
        GameObject source = GameObject.Find("Audio Source");
        Destroy(source);
    }

    //load level after one sceond delay
    IEnumerator LevelLoad(string name)
    {

        float elapsedTime = 0;
        float currentVolume = AudioListener.volume;

        while (elapsedTime < delay)
        {
            elapsedTime += Time.deltaTime;
            AudioListener.volume = Mathf.Lerp(currentVolume, 0, elapsedTime / delay);
            yield return null;
        }

        SceneManager.LoadScene(name);
    }

    IEnumerator StartReset()
    {
        float elapsedTime = 0;

        while (elapsedTime < delay)
        {
            elapsedTime += Time.deltaTime;
            AudioListener.volume = Mathf.Lerp(0, 1, elapsedTime / delay);
            yield return null;
        }
    }
}
