﻿using UnityEngine;

public class OOOX : FormationManager
{

    public override void GenerateSatellites()
    {
        Quad = GameObject.Find("Creator");
        TQuad = Quad.transform;
        angle = new Quaternion(0, 0, 0, 0);
        Instantiate((GameObject)Resources.Load("Prefabs/SatelliteModel1", typeof(GameObject)), TQuad.position, angle);
        Instantiate((GameObject)Resources.Load("Prefabs/SatelliteModel2", typeof(GameObject)), TQuad.position, angle);
        Instantiate((GameObject)Resources.Load("Prefabs/SatelliteModel3", typeof(GameObject)), TQuad.position, angle);
    }
}
