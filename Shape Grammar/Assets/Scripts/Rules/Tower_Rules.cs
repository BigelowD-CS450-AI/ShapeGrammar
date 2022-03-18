using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Tower_Rules
{
    public static Dictionary<Side, bool> default_used_sides = new Dictionary<Side, bool>
    {
        {Side.north, true},
        {Side.east, true},
        {Side.south, true},
        {Side.west, true},
    };

    public static List<Rule> rules = new List<Rule>
    {
        /*new Rule(
                Resources.Load<Shape>("Short_Wall") as Shape, //outputObj
                new List<Side> { Side.north, Side.east, Side.south, Side.west}, //possible sides
                new Vector3(11f, 0.0f, 0.0f), //posOffset
                .50f //probability
                ),
        new Rule(
                Resources.Load<Shape>("Long_Wall") as Shape, //outputObj
                new List<Side> { Side.north, Side.east, Side.south, Side.west }, //possible sides
                new Vector3(22f, 0.0f, 0.0f), //posOffset
                .50f //probability
                )*/
    };
}
