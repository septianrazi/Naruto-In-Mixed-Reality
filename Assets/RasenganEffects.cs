using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.VFX;
using AudioEffects;

public class RasenganEffects : MonoBehaviour
{
    [SerializeField] VisualEffect vfx;
    [SerializeField] AudioSource startSound;
    [SerializeField] AudioSource contSound;

    [SerializeField] RasenganScale rasenganScaleComp;

    [SerializeField] float incPlayRate = 2f;
    [SerializeField] float decPlayRate = 3f;

    [SerializeField] RasenShurikenBehaviour RasenShurikenComp;

    private IEnumerator startSoundFadeCoroutine;
    private IEnumerator soundFadeCoroutine;

    private void Awake()
    {
        startSoundFadeCoroutine = AudioEffects.AudioEffects.StartFade(startSound, 2f, 0f);
        soundFadeCoroutine = AudioEffects.AudioEffects.StartFade(contSound, 2f, 0f);
    }


    [ContextMenu("Enable Rasengan")]
    public void EnableRasengan()
    {
        Debug.Log("START RASENGAN");

        rasenganScaleComp.ChangeToIncRasengan();

        vfx.playRate = incPlayRate;
        vfx.Play();


        //StopCoroutine(startSoundFadeCoroutine);
        //StopCoroutine(soundFadeCoroutine);
        startSound.volume = 1f;
        contSound.volume = 1f;
        startSound.Play();
        contSound.Play();

    }

    [ContextMenu("Disable Rasengan")]
    public void DisableRasengan()
    {
        Debug.Log("STopping RASENGAN");

        vfx.Stop();

        vfx.playRate = decPlayRate;

        rasenganScaleComp.ChangeToUnstableRasengan();

        StartCoroutine(startSoundFadeCoroutine);
        //StartCoroutine(AudioEffects.AudioEffects.StartFade(contSound, 2f, 0f));
    }


    [ContextMenu("Enable RasenShuriken")]
    public void EnableRasenShuriken()
    {
        Debug.Log("ADDING RASENSHURIKEN");

        EnableRasengan();
        RasenShurikenComp.EnableRasenShuriken();



        //StartCoroutine(startSoundFadeCoroutine);
        //StartCoroutine(AudioEffects.AudioEffects.StartFade(contSound, 2f, 0f));
    }

    [ContextMenu("Disable RasenShuriken")]
    public void DisableRasenShuriken()
    {


        RasenShurikenComp.DisableRasenShuriken();
        Debug.Log("KILLING RASENSHURIKEN");

        DisableRasengan();

        //StartCoroutine(startSoundFadeCoroutine);
        //StartCoroutine(AudioEffects.AudioEffects.StartFade(contSound, 2f, 0f));
    }

}

namespace AudioEffects
{
    public class AudioEffects : MonoBehaviour
    {
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

}

