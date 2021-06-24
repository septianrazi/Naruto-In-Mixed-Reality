using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RasenShurikenBehaviour : MonoBehaviour
{
    // Start is called before the first frame update

    [SerializeField] private bool enabling = true;
    [SerializeField] private bool disabling = false;

    [SerializeField] private float fadeInSpeed = 1f;
    [SerializeField] private float fadeOutSpeed = 1f;

    [SerializeField] private Renderer[] bladeRenderers;

    [SerializeField] private float materialAlpha = 0.5f;

    

    // Update is called once per frame
    void Update()
    {
        //if (enabling)
        //{
        //    foreach (Renderer r in bladeRenderers)
        //    {
        //        StartCoroutine(FadeInMaterial(fadeInSpeed, r));
        //    }

        //}

        //if (disabling)
        //{
        //    foreach (Renderer r in bladeRenderers)
        //    {
        //        StartCoroutine(FadeOutMaterial(fadeInSpeed, r));
        //    }

        //}
    }

    public void EnableRasenShuriken()
    {
        Debug.Log("ENABLING RASENSHURIKEN");
        enabling = true;
        disabling = false;

        foreach (Renderer rend in bladeRenderers)
        {
            rend.gameObject.SetActive(true);

            Color matColor = rend.material.color;
            rend.material.color = new Color(matColor.r, matColor.g, matColor.b, 0f);

            StartCoroutine(FadeInMaterial(fadeInSpeed, rend));
        }
    }

    public void DisableRasenShuriken()
    {

        Debug.Log("DISABLING RASENSHURIKEN");

        enabling = false;
        disabling = true;

        foreach (Renderer rend in bladeRenderers)
        {
            StartCoroutine(FadeOutMaterialAndDisable(fadeInSpeed, rend));

        }
    }

    IEnumerator FadeOutMaterialAndDisable(float fadeSpeed, Renderer rendToFade)
    {

        Debug.Log("FADING OUT");
        Color matColor = rendToFade.material.color;
        float alphaValue = rendToFade.material.color.a;

        while (rendToFade.material.color.a > 0f)
        {
            alphaValue -= Time.deltaTime / fadeSpeed;
            rendToFade.material.color = new Color(matColor.r, matColor.g, matColor.b, alphaValue);
            yield return null;
        }
        rendToFade.material.color = new Color(matColor.r, matColor.g, matColor.b, 0f);

        rendToFade.gameObject.SetActive(false);
    }

    IEnumerator FadeInMaterial(float fadeSpeed, Renderer rendToFade)
    {
        Debug.Log("FADING IN");

        Color matColor = rendToFade.material.color;
        float alphaValue = rendToFade.material.color.a;

        while (rendToFade.material.color.a < materialAlpha)
        {
            alphaValue += Time.deltaTime / fadeSpeed;
            rendToFade.material.color = new Color(matColor.r, matColor.g, matColor.b, alphaValue);
            yield return null;
        }
        rendToFade.material.color = new Color(matColor.r, matColor.g, matColor.b, materialAlpha);
    }
}
