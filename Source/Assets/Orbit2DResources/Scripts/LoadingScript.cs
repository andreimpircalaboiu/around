using UnityEngine;
using System.Collections;
using UnityEngine.UI;


public class LoadingScript : MonoBehaviour
{
    public Canvas OnAir;
    public Canvas Loading;
    private bool loadingOff = true;
    private int nr = 0;

    void Awake()
    {
        OnAir.enabled = false;
    }

    void Start()
    {
        StartCoroutine(CanvasBlocker());
        StartCoroutine(Wait());

    }

    IEnumerator CanvasBlocker()
    {
        yield return new WaitForSeconds(2f);
        OnAir.enabled = true;
    }

    IEnumerator Wait()
    {
        yield return new WaitForSeconds(.5f);
        gameObject.GetComponent<Text>().text = "loading";
        yield return new WaitForSeconds(.5f);
        gameObject.GetComponent<Text>().text = "loading.";
        yield return new WaitForSeconds(.5f);
        gameObject.GetComponent<Text>().text = "loading..";
        yield return new WaitForSeconds(.5f);
        gameObject.GetComponent<Text>().text = "loading...";
        yield return new WaitForSeconds(.5f);
        Loading.enabled = false;
    }
    
}
