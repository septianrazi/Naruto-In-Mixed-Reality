using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.VFX;

public class RasenganEffects : MonoBehaviour
{
    [SerializeField] VisualEffect vfx;
    [SerializeField] AudioSource startSound;
    [SerializeField] AudioSource contSound;

    [SerializeField] Vector3 desiredScale = new Vector3(0.07f, 0.07f, 0.07f);

    [SerializeField] RasenganScale rasenganScaleComp;


    public void EnableRasengan()
    {
        Debug.Log("START RASENGAN");
        vfx.Play();

        rasenganScaleComp.ChangeToIncRasengan();
        startSound.volume = 1f;
        startSound.Play();
        contSound.volume = 1f;
        contSound.Play();
    }

    public void DisableRasengan()
    {
        Debug.Log("STopping RASENGAN");

        vfx.Stop();

        rasenganScaleComp.ChangeToUnstableRasengan();
        StartCoroutine(StartFade(startSound, 2f, 0f));
        StartCoroutine(StartFade(contSound, 2f, 0f));
    }

    public static IEnumerator StartFade(AudioSource audioSource, float duration, float targetVolume)
    {
        float currentTime = 0;
        float start = audioSource.volume;

        while (currentTime < duration)
        {
            currentTime += Time.deltaTime;
            audioSource.volume = Mathf.Lerp(start, targetVolume, currentTime / duration);
            yield return null;
        }
        yield break;
    }

}
