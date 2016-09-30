using UnityEngine;

public class XOXX : FormationManager {

    public override void GenerateSatellites()
    {
        Quad = GameObject.Find("Creator");
        TQuad = Quad.transform;
        angle = new Quaternion(0, 0, 0, 0);
        Instantiate((GameObject)Resources.Load("Prefabs/SatelliteModel2", typeof(GameObject)), TQuad.position, angle);
    }
}
