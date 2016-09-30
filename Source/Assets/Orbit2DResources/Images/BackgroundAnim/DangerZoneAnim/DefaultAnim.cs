using UnityEngine;

public class DefaultAnim : MonoBehaviour {

    private Animator anim;
	// Use this for initialization
	void Start () {
       
	anim = GetComponent<Animator>();
	anim.Play("Normal",-1,float.NegativeInfinity);
	}
	
	// Update is called once per frame
	void Update () {
	
	}
}
