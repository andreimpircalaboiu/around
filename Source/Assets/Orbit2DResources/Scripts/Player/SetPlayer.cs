using UnityEngine;
using System.Collections;
public class SetPlayer : MonoBehaviour
{
    public Sprite arrow;
 
    void Start()
    {

        StartCoroutine(Wait());

    }
    private IEnumerator Wait()
    {
        yield return new WaitForSeconds(2.5f);
        this.gameObject.GetComponent<SpriteRenderer>().sprite = arrow;
    }

}
