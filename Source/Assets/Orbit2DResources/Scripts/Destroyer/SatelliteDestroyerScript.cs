using UnityEngine;
using System.Collections;
public class SatelliteDestroyerScript : MonoBehaviour
{

    public float orbitDistance = 2.0f;
    private float orbitDegreesPerSec = 80.0f;
    public Transform target;
    public float angularDifference;
    public ScoreMaker scorer;
    private bool go;
    // Use this for initialization
    void Start()
    {
        StartCoroutine(Wait());
    }
    private IEnumerator Wait()
    {
        yield return new WaitForSeconds(2.5f);
        go = true;
    }
    public void MakeOrbit()
    {
        if (target != null)
        {
            var dir = transform.position;
            var angle = Mathf.Atan2(dir.y, dir.x) * Mathf.Rad2Deg - angularDifference;
            transform.rotation = Quaternion.AngleAxis(angle, Vector3.forward);
            // Keep us at orbitDistance from target
            transform.position = target.position + (transform.position - target.position).normalized * orbitDistance;
            transform.RotateAround(target.position, Vector3.back, orbitDegreesPerSec * Time.deltaTime);
        }
    }
    // Update is called once per frame
    void Update()
    {
        if (go)
        {
            MakeOrbit();
        }
    }
}
