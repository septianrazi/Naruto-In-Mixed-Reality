using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RasenganScale : MonoBehaviour
{

    [SerializeField] private bool stableRasengan = false;
    private bool prevStableRasengan = false;
    [SerializeField] private Vector3 stableRasenganScale = new Vector3(0.06f, 0.06f, 0.06f);

    [SerializeField] private float decrementBy = 0.1f;
    [SerializeField] private float incrementBy = 1.5f;

    [SerializeField] AudioSource stableRasenganNoise;

    public bool incRasengan = false;

    // Update is called once per frame
    void FixedUpdate()
    {

        if (incRasengan){
            IncreaseRasenganSize();
        }
        else if (!stableRasengan)
        {
            DecreaseRasenganSize();
            if (prevStableRasengan)
            {
                StartCoroutine(AudioEffects.AudioEffects.StartFade(stableRasenganNoise, 1, 0));
            }
        }

        if (stableRasengan){
            stableRasenganNoise.volume = 1;


        }

        
        prevStableRasengan = stableRasengan;
    }

    void DecreaseRasenganSize()
    {
        transform.localScale = Vector3.Lerp(transform.localScale, Vector3.zero, decrementBy * Time.deltaTime);
    }


    void IncreaseRasenganSize()
    {
        transform.localScale = Vector3.Lerp(transform.localScale, stableRasenganScale, incrementBy * Time.deltaTime);

        if (transform.localScale.x >= stableRasenganScale.x)
        {
            stableRasengan = true;
            incRasengan = false;
        }
    }

    public void ChangeToUnstableRasengan()
    {
        incRasengan = false;
        stableRasengan = false;
    }

    public void ChangeToIncRasengan()
    {
        incRasengan = true;
    }
}
