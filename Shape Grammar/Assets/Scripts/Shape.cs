using System;
using System.Collections.Generic;
using UnityEngine;

public class Shape : MonoBehaviour
{
    [SerializeField] public Dictionary<Side, bool> sidesUsed = new Dictionary<Side, bool>();
    public Shape_Type shape = Shape_Type.Great_Hall;
    public bool terminal = false;
    public void Awake()
    {
        //add each possible side to list and initialize top false
        switch (shape)
        {
            case Shape_Type.Small_Building:
                sidesUsed = Small_Building_Rules.default_used_sides;
                break;
            case Shape_Type.Medium_Building:
                sidesUsed = Medium_Building_Rules.default_used_sides;
                break;
            case Shape_Type.Small_Building_Stacked:
                sidesUsed = Small_Building_Rules.default_used_sides;
                break;
            case Shape_Type.Short_Wall:
                sidesUsed = Short_Wall_Rules.default_used_sides;
                break;
            case Shape_Type.Long_Wall:
                sidesUsed = Long_Wall_Rules.default_used_sides;
                break;
            case Shape_Type.Thin_Tower:
                sidesUsed = Tower_Rules.default_used_sides;
                terminal = true;
                break;
            case Shape_Type.Thick_Tower:
                sidesUsed = Tower_Rules.default_used_sides;
                terminal = true;
                break;
            //...
            default:
                sidesUsed = Small_Building_Rules.default_used_sides;
                break;
        }
        
    }

    //gets a random side from unused sides
    public Side GetRandomUnsedSide()
    {
        System.Random random = new System.Random();
        List<Side> unusedSides = new List<Side>();
        foreach (Side side in sidesUsed.Keys)
            if (sidesUsed[side] == false)
                unusedSides.Add(side);
        //if only one unused side it will become terminal once we use it this pass
        Side SelectedSide = unusedSides[random.Next(unusedSides.Count)];
        sidesUsed[SelectedSide] = true;
        CheckAllSidesUsed();
        return SelectedSide;
    }

    public bool CheckAllSidesUsed()
    {
        terminal = !sidesUsed.ContainsValue(false);
        return terminal;
    }
}

public enum Side { north, east, south, west};
public enum Shape_Type { Great_Hall, Long_Wall, Medium_Building, Short_Wall, Small_Building, Small_Building_Stacked, Thick_Tower, Thin_Tower }