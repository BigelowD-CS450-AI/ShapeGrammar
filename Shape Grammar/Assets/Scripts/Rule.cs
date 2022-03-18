using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Rule
{
    //public Shape inputObj;
    public Shape outputObj;
    public List<Side> side;
    public Vector3 posOffset;
    //public Vector3 rotOffset;
    public float probability;
    public Rule(/*Shape inputObj, */Shape outputObj, List<Side> face, Vector3 posOffset, float probability)
    {
        //this.inputObj = inputObj;
        this.outputObj = outputObj;
        this.side = face;
        this.posOffset = posOffset;
        //this.rotOffset = rotOffset;
        this.probability = probability;
    }
}
