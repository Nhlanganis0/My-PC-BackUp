using System.Collections;
using System.Collections.Generic;
using UnityEngine.SceneManagement;
using UnityEngine;

public class Menu : MonoBehaviour
{
    public GameObject IntroVideo;
    private AudioSource audioSource;
    public AudioClip intro;

    private void Start()
    {
        audioSource = GetComponent<AudioSource>();
    }
    public void Update()
    {
        if (Input.GetKey(KeyCode.Escape))
        {
            Application.Quit();
        }
    }

    IEnumerator Intro()
    {
        IntroVideo.SetActive(true);
        yield return new WaitForSeconds(15);
        SceneManager.LoadScene(1);
    }
    public void StartRead()
    {
        StartCoroutine(Intro());
    }

    public void go2_menu()
    {
        SceneManager.LoadScene(0);
    }
}
