using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

public class MovePointsTool : MonoBehaviour
{
   
    public List<Transform> pointsList;
    public float pointsRadius;
    public float NumberOfPoints;
    public float currentLenghtOfLastpoint;
    
    public Vector3 currentDirection;
    Vector3 rayEndPositionFromLastMovePoint;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }


    public void  SpawnMovePoint()
    {

        var pointClone = new GameObject("point" + NumberOfPoints++);
        if(pointsList.Count <= 0)
        {
            pointClone.transform.position = transform.position;
        }
        else
        {
            pointClone.transform.position = rayEndPositionFromLastMovePoint;
        }
        pointClone.transform.parent = transform;
        pointsList.Add(pointClone.transform);
        
    }

    public void RemoveLastMadePoint()
    {
        var temp = pointsList[pointsList.Count - 1];
        NumberOfPoints--;
        pointsList.Remove(temp);
        DestroyImmediate(temp.gameObject);
    }


    private void OnDrawGizmos()
    {
      DrawLenghtOfDirectionRayOfNextMovePoint();

        for(int i = 0; i < pointsList.Count; i++)
        {
            DrawAMeshForEachMovePointInList(i);
            DrawAlineConectingEachMovePointInList(i);
        }
    }

   
    void DrawLenghtOfDirectionRayOfNextMovePoint()
    {
        if (pointsList.Count > 0)
        {
            var lastMovePointPositionInlist = pointsList.Count < 1 ? pointsList[pointsList.Count].position : pointsList[pointsList.Count - 1].position;
            Gizmos.color = Color.cyan;
            Gizmos.DrawLine(lastMovePointPositionInlist, lastMovePointPositionInlist +(currentDirection * currentLenghtOfLastpoint));

            rayEndPositionFromLastMovePoint = lastMovePointPositionInlist+ (currentDirection * currentLenghtOfLastpoint);
        }

    }


    void DrawAMeshForEachMovePointInList(int index)
    {
        Gizmos.color = new Color(255,0,0,0.7f);
        Gizmos.DrawSphere(pointsList[index].position, pointsRadius);

        Gizmos.color = Color.black;
        Gizmos.DrawWireSphere(pointsList[index].position, pointsRadius);

        UnityEditor.Handles.color = Color.white;
        UnityEditor.Handles.Label(pointsList[index].position , "point" + NumberOfPoints);

       
    }

    void DrawAlineConectingEachMovePointInList(int index)
    {
        try
        {
            Gizmos.color = Color.green;
            Gizmos.DrawLine(pointsList[index].position, pointsList[index + 1].position);
        }
        catch
        {
            return;
        }
    }

    [ContextMenu(nameof(ResetDirectionFromlastMovePoint))]
    void ResetDirectionFromlastMovePoint()
    {
        currentDirection = Vector3.zero;
    }
}
