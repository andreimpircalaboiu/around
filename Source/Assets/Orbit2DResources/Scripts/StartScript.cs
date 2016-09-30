
using UnityEngine;
using System.Collections;
public class StartScript : MonoBehaviour {
 
    public OrbitingObject script2;
    public SatelliteDestroyerScript script3;
    public SatelliteDestroyerScript script35;
    public Destroy script4;
    public SatelliteCreator script5;
    public ScoreMaker script6;
    public GameObject orbitContainer;
    public GameObject planetContainer;
    public Paused script7;
    public Canvas onAir;
    public Canvas pause;
    public Sprite orbitBlue, orbitPurple, orbitGreen, orbitYellow, orbitRed;
    public Sprite planetBlue, planetPurple, planetGreen, planetYellow, planetRed;
    

    void Start () {
        ScriptsEnabled();
        //RandomSpriteInit();
        StartCoroutine(Wait());
        Time.timeScale = 1;
        onAir.enabled = true;

	}
   
 private IEnumerator Wait()
    {
        yield return new WaitForSeconds(2.5f);
        RandomSpriteInit();
    }


    private void RandomSpriteInit()
    {
        System.Random rand = new System.Random();
        var option = rand.Next(5);
        switch (option)
        {
            case 0:
            {
                orbitContainer.GetComponent<SpriteRenderer>().sprite = orbitBlue;
                planetContainer.GetComponent<SpriteRenderer>().sprite = planetBlue;
                break;
            }
            case 1:
            {
                orbitContainer.GetComponent<SpriteRenderer>().sprite = orbitPurple;
                planetContainer.GetComponent<SpriteRenderer>().sprite = planetPurple;
                break;
            }
            case 2:
            {
                orbitContainer.GetComponent<SpriteRenderer>().sprite = orbitGreen;
                planetContainer.GetComponent<SpriteRenderer>().sprite = planetGreen;
                break;
            }
            case 3:
            {
                orbitContainer.GetComponent<SpriteRenderer>().sprite = orbitYellow;
                planetContainer.GetComponent<SpriteRenderer>().sprite = planetYellow;
                break;
            }
            case 4:
            {
                orbitContainer.GetComponent<SpriteRenderer>().sprite = orbitRed;
                planetContainer.GetComponent<SpriteRenderer>().sprite = planetRed;
                break;
            }
            default:
            {
                orbitContainer.GetComponent<SpriteRenderer>().sprite = orbitBlue;
                planetContainer.GetComponent<SpriteRenderer>().sprite = planetBlue;
                break;
            }
        }
    }


    private void ScriptsEnabled()
    {

        script2.enabled = true;
        script3.enabled = true;
        script35.enabled = true;
        script4.enabled = true;
        script5.enabled = true;
        script6.enabled = true;
        script7.enabled = true;

    }
}
