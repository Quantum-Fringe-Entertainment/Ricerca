using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SFXManager : MonoBehaviour
{
    public AudioSource bgmSFX;
    public AudioClip[] bgmClips;
    public float initTimeForStanfUp = 60f;
    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(playBGM());
    }


    IEnumerator playBGM()
    {
        yield return new WaitForSeconds(initTimeForStanfUp);
        bgmSFX.clip = bgmClips[0];
        bgmSFX.Play();
    }

    private void Update()
    {
        if (!bgmSFX.isPlaying)
        {
            if (Time.time > bgmClips[0].length + initTimeForStanfUp + 20f)
            { bgmSFX.clip = bgmClips[1]; bgmSFX.Play(); }
            else if (Time.time > bgmClips[0].length + 50f + bgmClips[1].length + 30f)
            { bgmSFX.clip = bgmClips[2]; bgmSFX.Play(); }
            else if (Time.time > bgmClips[0].length + 50f + bgmClips[1].length + 30f + bgmClips[2].length)
            { bgmSFX.Stop(); }
        }
    }
}
