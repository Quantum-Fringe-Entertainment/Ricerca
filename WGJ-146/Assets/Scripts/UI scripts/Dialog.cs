using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using Cinemachine;

public class Dialog : MonoBehaviour
{
    public TextMeshProUGUI textDisplay;
    public string[] sentences;
    public float typingSpeed;
    private int index;

    public GameObject netBtn;
    public GameObject panel;
    public GameObject cutsceneStand;
    public CinemachineVirtualCamera VirtualCamera;
    public PlayerState playerState;
    private void Start()
    {
        Cursor.visible = true;
        VirtualCamera.Priority = 100;
        StartCoroutine(Type());
        playerState.currentPlayerState = GetPlayerState.isStandingUp;
    }

    private void Update()
    {
        if(textDisplay.text == sentences[index])
        {
            netBtn.SetActive(true);
        }
    }

    IEnumerator Type()
    {
        foreach (char letter in sentences[index].ToCharArray())
        {
            textDisplay.text += letter;
            yield return new WaitForSeconds(typingSpeed);

        }
    }

    public void NextSentence()
    {
        netBtn.SetActive(false);
        if(index < sentences.Length - 1)
        {
            index++;
            textDisplay.text = "";
            StartCoroutine(Type());
        }
        else
        {
            VirtualCamera.Priority = 10;
            panel.SetActive(false);
            cutsceneStand.SetActive(true);
            print("Start Game");
            textDisplay.text = "";
        }
    }
}
