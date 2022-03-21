using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RuleEnacter : MonoBehaviour
{
    public static Shape Enact(Rule rule, Side side, Shape inputObj)
    {
        GameObject newObj = Instantiate(rule.outputObj.gameObject);
        Shape newObjShape = newObj.GetComponent<Shape>();
        float rotation;
        switch (side)
        {
            case Side.north:
                rotation = 0.0f;
                newObjShape.sidesUsed[Side.south] = true;
                break;
            case Side.east:
                rotation = 90.0f;
                newObjShape.sidesUsed[Side.west] = true;
                break;
            //if south or west reverse offset to negative
            case Side.south:
                rotation = 180.0f;
                //rule.posOffset *= -1;
                newObjShape.sidesUsed[Side.north] = true;
                break;
            case Side.west:
                rotation = 270.0f;
                //rule.posOffset *= -1;
                newObjShape.sidesUsed[Side.east] = true;
                break;
            default:
                rotation = 0.0f;
                newObjShape.sidesUsed[Side.south] = true;
                break;
        }
        newObj.transform.rotation = Quaternion.Euler(newObj.transform.eulerAngles.x, newObj.transform.eulerAngles.y + rotation, newObj.transform.eulerAngles.x);
        newObj.transform.position = new Vector3(inputObj.transform.position.x, newObj.transform.position.y, inputObj.transform.position.z);
        newObj.transform.position += newObj.transform.forward * rule.posOffset.z  + newObj.transform.right * rule.posOffset.x;
        //if it comes in with all sides terminated, set to terminal
        newObjShape.terminal = newObjShape.CheckAllSidesUsed();
        return newObj.GetComponent<Shape>();
    }
}
