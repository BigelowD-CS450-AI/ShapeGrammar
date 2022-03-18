using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public static class Short_Wall_Rules
{
    public static Dictionary<Side, bool> default_used_sides = new Dictionary<Side, bool>
    {
        {Side.north, true},
        {Side.east, false},
        {Side.south, true},
        {Side.west, false},
    };

    public static List<Rule> rules = new List<Rule>
    {
        new Rule(
                Resources.Load<Shape>("Small_Building") as Shape, //outputObj
                new List<Side> {Side.east, Side.west}, //possible sides
                new Vector3(0f, 0.0f, 21f), //posOffset
                .25f //probability
                ),
        new Rule(
                Resources.Load<Shape>("Medium_Building") as Shape, //outputObj
                new List<Side> { Side.east, Side.west}, //possible sides
                new Vector3(0.0f, 0.0f, 26f), //posOffset
                .25f //probability
                ),
        new Rule(
                Resources.Load<Shape>("Small_Building_Stacked") as Shape, //outputObj
                new List<Side> { Side.east, Side.west }, //possible sides
                new Vector3(0.0f, 0.0f, 21f), //posOffset
                .0625f //probability
                ),
        new Rule( //Thin_Tower Attached to small building
                //Resources.Load<Shape>("Small_Building") as Shape, //inputObj
                Resources.Load<Shape>("Thin_Tower") as Shape, //outputObj
                new List<Side> { Side.east, Side.west }, //possible sides
                new Vector3(14.5f, 0.0f, 0.0f), //posOffset
                .125f //probability
                ),
        new Rule(
                Resources.Load<Shape>("Thick_Tower") as Shape, //outputObj
                new List<Side> { Side.east, Side.west }, //possible sides
                new Vector3(20.5f, 0.0f, 0.0f), //posOffset
                .125f //probability
        )
    };
}
