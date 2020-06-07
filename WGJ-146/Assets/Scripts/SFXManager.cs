using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SFXManager : MonoBehaviour
{
    public GameObject bgmSFX;
    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(playBGM());
    }


    IEnumerator playBGM()
    {
        yield return new WaitForSeconds(30f);
        bgmSFX.SetActive(true);
    }
   
}
