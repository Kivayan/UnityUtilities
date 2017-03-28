using UnityEngine;

public class DistanceTracker 
{
    private RaycastHit rayHit;
    private Ray ray;
    private Vector3 source;
    private Vector3 direction;

    private float distance;

    public float CalculateDist()
    {
        if (Physics.Raycast(source, direction, out rayHit))
        {
            distance = rayHit.distance;
        }
        return distance;
    }

    public void DebugRay()
    {
        Debug.DrawRay(source, direction);
        DebugPanel.Log("Distance", "Distance", distance);
    }

    public DistanceTracker(Vector3 source, Vector3 target)
    {
        this.source = source;
        direction = target;
    }

    
}