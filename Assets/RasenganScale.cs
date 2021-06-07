using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RasenganScale : MonoBehaviour
{

    [SerializeField] private bool stableRasengan = false;
    [SerializeField] private Vector3 stableRasenganScale = new Vector3(0.07f, 0.07f, 0.07f);

    [SerializeField] private Vector3 decrementBy = Vector3.one * 0.00005f;
    [SerializeField] private Vector3 incrementBy = Vector3.one * 0.001f;

    public bool incRasengan = false;

    // Update is called once per frame
    void FixedUpdate()
    {
        if (incRasengan){
            IncreaseRasenganSize();
        }
        else if (!stableRasengan)
        {
            DecreaseRasenganSize(decrementBy);
        }
    }

    void DecreaseRasenganSize(Vector3 decrement)
    {
        transform.localScale = Vector3.Lerp(transform.localScale, Vector3.zero, 3f * Time.deltaTime);


        //if (currentScale.x <= 0.001)
        //    transform.localScale = Vector3.zero;
    }


    void IncreaseRasenganSize()
    {
        transform.localScale = Vector3.Lerp(transform.localScale, stableRasenganScale, 1.5f * Time.deltaTime);

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
