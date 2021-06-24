using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.VFX;

public class ChidoriEffectHandler : MonoBehaviour
{
    [SerializeField] VisualEffect vfx;
    [SerializeField] GameObject chidoriGlove;
    [SerializeField] AudioSource startSound;
    [SerializeField] AudioSource contSound;

    [SerializeField] float playRate = 2f;

    [ContextMenu("Enable Chidori")]
    public void EnableChidori()
    {
        Debug.Log("START CHIDORI");

        vfx.playRate = playRate;
        vfx.Play();

        chidoriGlove.SetActive(true);


        //StopCoroutine(startSoundFadeCoroutine);
        //StopCoroutine(soundFadeCoroutine);
        startSound.volume = 1f;
        contSound.volume = 1f;
        startSound.Play();
        contSound.Play();
    }

    [ContextMenu("Disable Chidori")]
    public void DisableChidori()
    {
        Debug.Log("STopping CHIDORI");

        vfx.Stop();

        chidoriGlove.SetActive(false);

        startSound.Stop();
        contSound.Stop();
        //Sta
    }

}
