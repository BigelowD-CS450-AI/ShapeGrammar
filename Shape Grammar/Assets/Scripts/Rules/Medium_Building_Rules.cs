using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public static class Medium_Building_Rules
{
    public static Dictionary<Side, bool> default_used_sides = new Dictionary<Side, bool>
    {
        {Side.north, false},
        {Side.east, false},
        {Side.south, false},
        {Side.west, false},
    };

    public static List<Rule> rules = new List<Rule>
    {
        new Rule(
                Resources.Load<Shape>("Small_Building") as Shape, //outputObj
                new List<Side> { Side.north, Side.east, Side.south, Side.west}, //possible sides
                new Vector3(0.0f, 0.0f, 25f), //posOffset
                .0625f //probability
                ),
        new Rule(
                Resources.Load<Shape>("Medium_Building") as Shape, //outputObj
                new List<Side> { Side.north, Side.east, Side.south, Side.west }, //possible sides
                new Vector3(0.0f, 0.0f, 30f), //posOffset
                .0625f //probability
                ),
        new Rule(
                Resources.Load<Shape>("Short_Wall") as Shape, //outputObj
                new List<Side> { Side.north, Side.east, Side.south, Side.west}, //possible sides
                new Vector3(26f, 0.0f, 0.0f), //posOffset
                .25f //probability
                ),
        new Rule(
                Resources.Load<Shape>("Long_Wall") as Shape, //outputObj
                new List<Side> { Side.north, Side.east, Side.south, Side.west }, //possible sides
                new Vector3(37f, 0.0f, 0.0f), //posOffset
                .25f //probability
                ),
        new Rule(
                Resources.Load<Shape>("Thin_Tower") as Shape, //outputObj
                new List<Side> { Side.north, Side.east, Side.south, Side.west }, //possible sides
                new Vector3(18.5f, 0.0f, 0.0f), //posOffset
                .125f //probability
                ),
        new Rule(
                Resources.Load<Shape>("Thick_Tower") as Shape, //outputObj
                new List<Side> { Side.north, Side.east, Side.south, Side.west }, //possible sides
                new Vector3(24.0f, 0.0f, 0.0f), //posOffset
                .25f //probability
                )
    };
}
