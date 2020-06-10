using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CreditsManager : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(endGame());
    }

    IEnumerator endGame()
    {
        yield return new WaitForSeconds(5f);
        Application.Quit();
    }
}
