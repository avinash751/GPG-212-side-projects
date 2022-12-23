using UnityEngine;

public class Obstacke_Avoidance : MonoBehaviour
{
    [SerializeField] float raylenght;
    [SerializeField] float Repelpeed;
    Rigidbody rb;
    LayerMask groundMask;
 
   
    //bool rayhitt;


    private void Start()
    {
        rb = GetComponent<Rigidbody>();

        groundMask = LayerMask.GetMask("Ground");
        
    }
    // Update is called once per frame
    void Update()
    {
        RepelObjectToOppositeDirection(Vector3.forward,Vector3.back);
        RepelObjectToOppositeDirection(Vector3.back,Vector3.forward);
        RepelObjectToOppositeDirection(Vector3.right,Vector3.left);
        RepelObjectToOppositeDirection(Vector3.left,Vector3.right);
    }

   

    void RepelObjectToOppositeDirection(Vector3 rayDirection, Vector3 repelDirection)
    {
        Ray DirectionRay = new Ray(transform.position, rayDirection);

        if (Physics.Raycast(DirectionRay, out RaycastHit hit, raylenght, groundMask) && hit.collider != null)
        {
            rb.velocity += (transform.position - hit.point).normalized + repelDirection * Repelpeed;
            Debug.Log("adding addiotional velocity");
            Debug.Log(hit.collider);
        }
    }

    void DrawGizmoRayWithColor(Vector3 direction, Color color)
    {
        Gizmos.color = color;
        Gizmos.DrawRay(transform.localPosition, direction * raylenght);
    }

  private void OnDrawGizmos()
  {
        DrawGizmoRayWithColor(Vector3.forward, Color.blue);
        DrawGizmoRayWithColor(Vector3.back, Color.cyan);
        DrawGizmoRayWithColor(Vector3.right, Color.red);
        DrawGizmoRayWithColor(Vector3.left, Color.black);
  }


}
