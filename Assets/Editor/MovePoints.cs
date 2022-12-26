using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

[CustomEditor(typeof(MovePointsTool))]
public class MovePoints : Editor
{
    public override void OnInspectorGUI()
    {
       MovePointsTool points = (MovePointsTool)target;
       DrawDefaultInspector();

       
        if(GUILayout.Button("Add move point"))
        {   
            points.SpawnMovePoint();
        }

        if (GUILayout.Button("remove last made move point"))
        {
            points.RemoveLastMadePoint();
           
        }

        points.currentDirection = Vector3.ClampMagnitude(points.currentDirection,2);
    }
    
}
