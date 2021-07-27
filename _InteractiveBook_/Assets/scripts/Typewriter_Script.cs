using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class Typewriter_Script : MonoBehaviour
{
    private static Typewriter_Script instance;
    List <TyperwriterSingle> typerwriterSingleList;
    private AudioSource audioSource;
    public AudioClip backkround;

    private void Awake()
    {
        typerwriterSingleList = new List<TyperwriterSingle>();
        instance = this;
    }

    private void Start()
    {
        audioSource.clip = backkround;
        audioSource.Play();
    }

    public static void StartWriter_Static(Text uiText, string textToWrite, float timePerLetter, bool invisibleLetters)
    {
        instance.StartWriter(uiText, textToWrite, timePerLetter, invisibleLetters);
    }

    private void StartWriter(Text uiText, string textToWrite, float timePerLetter, bool invisibleLetters)
    {
        typerwriterSingleList.Add(new TyperwriterSingle(uiText, textToWrite, timePerLetter, invisibleLetters));
    }

    private void Update()
    {
        for(int i = 0; i < typerwriterSingleList.Count; i++)
        {
           bool removeIntance = typerwriterSingleList[i].Update();
            if (removeIntance)
            {
                typerwriterSingleList.RemoveAt(i);
                i--;
            }
        }
    }

    private class TyperwriterSingle
    {
        private Text uiText;
        private string textToWrite;
        private int letterIndex;
        private float timePerLetter;
        private float timer;
        private bool invisibleLetters;

        public TyperwriterSingle(Text uiText, string textToWrite, float timePerLetter, bool invisibleLetters)
        {
            this.uiText = uiText;
            this.textToWrite = textToWrite;
            this.timePerLetter = timePerLetter;
            this.invisibleLetters = invisibleLetters;
            letterIndex = 0;
        }
        public bool Update()
        {
            timer -= Time.deltaTime;
            if (timer <= 0f)
            {
                timer -= timePerLetter;
                letterIndex++;
                string text = textToWrite.Substring(0, letterIndex);
                if (invisibleLetters)
                {
                    text += "<color=#00000000>" + textToWrite.Substring(letterIndex) + "</color>";
                }
                uiText.text = text;

                if (letterIndex >= textToWrite.Length)
                {
                    uiText = null;
                    return true;
                }
            }
            return false;
        }
    }
    
}
