using UnityEngine;

public abstract class FormationManager : MonoBehaviour {

    protected GameObject Quad;
    protected Transform TQuad;
    public Quaternion angle;

    public abstract void GenerateSatellites();
}
