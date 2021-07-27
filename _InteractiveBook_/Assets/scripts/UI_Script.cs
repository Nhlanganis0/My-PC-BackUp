using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.PlayerLoop;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class UI_Script : MonoBehaviour
{
    private Text messageText;
 
    private AudioSource audioSource;

    [Header("Story Audio")]
    public AudioClip intro;
    public AudioClip para_1;
    public AudioClip para_2;
    public AudioClip para_3;
    public AudioClip para_4;
    public AudioClip para_5;
    public AudioClip para_6;
    public AudioClip para_7;

    public int directionCount;
    public Button next;
    public Button prev;
    
    public GameObject End;
    public GameObject Quiz;
    public GameObject outro;
    public GameObject text_1;
    public GameObject text_2;
    public GameObject text_3;
    public GameObject text_4;
    public GameObject text_5;
    public GameObject text_6;
    public GameObject text_7;

    private void Start()
    {
        Button nextButton = next.GetComponent<Button>();
        Button prevButton = prev.GetComponent<Button>();
        nextButton.onClick.AddListener(Script_nextBtn);
        
        audioSource = GetComponent<AudioSource>();
    }
    private void Update()
    {
        if (Input.GetKey(KeyCode.Escape))
        {
            Application.Quit();
        }
    }

    public void Script_nextBtn()
    {
        directionCount = directionCount + 1;

        next = transform.Find("Next").GetComponent<Button>();
        StartCoroutine(DelayText());
    
        print(directionCount);
    } 

    IEnumerator DelayText()
    {
        yield return new WaitForSeconds(2);
        if (directionCount == 1) //first paje
        {
            text_1.SetActive(true);

            audioSource.clip = para_1;
            audioSource.Play(0);
        }
        else if (directionCount == 2)
        {
            text_1.SetActive(false);
            text_2.SetActive(true);

            audioSource.clip = para_2;
            audioSource.Play(0);
        }
        else if (directionCount == 3)
        {
            text_2.SetActive(false);
            text_3.SetActive(true);

            audioSource.clip = para_3;
            audioSource.Play(0);
        }
        else if (directionCount == 4)
        {
            text_3.SetActive(false);
            text_4.SetActive(true);

            audioSource.clip = para_4;
            audioSource.Play(0);
        }
        else if (directionCount == 5)
        {
            text_4.SetActive(false);
            text_5.SetActive(true);

            audioSource.clip = para_5;
            audioSource.Play(0);
        }
        else if (directionCount == 6)
        {
            text_5.SetActive(false);
            text_6.SetActive(true);

            audioSource.clip = para_6;
            audioSource.Play(0);
            next.enabled = false;
            yield return new WaitForSeconds(18);
            End.SetActive(true);
        }
    }

    public void QuizTime()
    {
        SceneManager.LoadScene(2);
    }

    public void Outro()
    {
        outro.SetActive(true);
        Quiz.SetActive(true);
    }
}
