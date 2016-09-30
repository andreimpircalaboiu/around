using UnityEngine;

public class SatellitePositioning : MonoBehaviour {

    public float orbitDistance = 2.0f;
    public float orbitDegreesPerSec = 12.0f;
    private GameObject obj;
    private Transform target;
    // Use this for initialization
    void Start()
    {
        obj = GameObject.Find("Planet");
        target = obj.transform;
        MakeOrbit();
    }

    public void MakeOrbit()
    {
        if (target != null)
        {
            var dir = transform.position;
            var angle = Mathf.Atan2(dir.y, dir.x) * Mathf.Rad2Deg - 245.0f;
            transform.rotation = Quaternion.AngleAxis(angle, Vector3.forward);
            transform.position = target.position + (transform.position - target.position).normalized * orbitDistance;
            transform.RotateAround(target.position, Vector3.back, orbitDegreesPerSec * Time.deltaTime);
        }
    }
    void Update()
    {
        MakeOrbit();
    }
}
