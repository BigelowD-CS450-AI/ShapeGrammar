using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShapeManager : MonoBehaviour
{
    List<Shape> nonterminalShapes = new List<Shape>();
    Dictionary<Shape_Type, List<Rule>> rules;
    //max distance object will generate as non-terminal
    //any objects that generate outside of bounds are marked terminal
    public float generationDistance = 150.0f;
    public int maxIterations = 2;
    private int curIterations = 0;

    public void Start()
    {
        rules = new Dictionary<Shape_Type, List<Rule>>()
        {
            { Shape_Type.Small_Building, Small_Building_Rules.rules},
            { Shape_Type.Medium_Building, Medium_Building_Rules.rules},
            { Shape_Type.Small_Building_Stacked, Small_Building_Rules.rules},
            { Shape_Type.Short_Wall, Short_Wall_Rules.rules},
            { Shape_Type.Long_Wall, Long_Wall_Rules.rules},
            { Shape_Type.Thin_Tower, Tower_Rules.rules},
            { Shape_Type.Thick_Tower, Tower_Rules.rules}
        };
        //small_building_rules sbr = new small_building_rules();
        nonterminalShapes = new List<Shape>();
        //on startup find initial object in scene
        Shape rootShape = FindObjectOfType<Shape>();
        if (!rootShape.terminal)
            nonterminalShapes.Add(rootShape);
    }

    public void FixedUpdate()
    {
        System.Random random = new System.Random();
        //exits rest of update loop if all shapes are terminal
        if (curIterations >= maxIterations || nonterminalShapes.Count <= 0)
            return;
        curIterations++;
        nonterminalShapes.TrueForAll(IsFilled);
        nonterminalShapes.RemoveAll(IsTerminal);
        Shape shape = nonterminalShapes[random.Next(nonterminalShapes.Count)];
        Propagate(shape);
        //if (shapes[random.Next(shapes.Count)])
        //Shape shape = shapes[random.Next(shapes.Count)];
    }

    public bool IsFilled(Shape shape)
    {
        return shape.CheckAllSidesUsed();
    }

    public bool IsTerminal(Shape shape)
    {
        return shape.terminal;
    }

    private void Propagate(Shape shape)
    {
        Side side = shape.GetRandomUnsedSide();
        Rule rule = GetRandomRule(shape.shape, side);
        Shape newShape = RuleEnacter.Enact(rule, side, shape);
        //if not in generation bounds new shape is terminal
        if (!CheckInGenerationbounds(newShape))
            newShape.terminal = true;
        else if (!newShape.terminal)
            nonterminalShapes.Add(newShape);
        //if since the propagation the shape has become terminal remove it from list
        if (shape.terminal)
        {
            nonterminalShapes.Remove(shape);
            Debug.Log("Removed due to all sides");
        }
        //return newShape;
    }

    private bool CheckInGenerationbounds(Shape shape)
    {
        return (shape.transform.position.x < generationDistance &&
                shape.transform.position.x > -generationDistance &&
                shape.transform.position.z < generationDistance &&
                shape.transform.position.z > -generationDistance);
    }
    
    private Rule GetRandomRule(Shape_Type shape, Side side)
    {
        System.Random random = new System.Random();
        float probabilityMax = 0;
        foreach (Rule rule in rules[shape])
            if (rule.side.Contains(side))
                probabilityMax += rule.probability;
        float randomFloat = (float)random.NextDouble() * probabilityMax;
        float sum = 0;
        foreach (Rule rule in rules[shape])
            if (rule.side.Contains(side))
                if (randomFloat <= (sum = sum + rule.probability))
                        return rule;
        //should never get here
        return null;
    }
    /*
    //fake to test small_building rules logic
    private Rule GetRandomRule(Shape_Type shape, Side side)
    {
        return rules[shape][0];
    }*/
}
