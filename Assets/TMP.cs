using UnityEngine;

public class TMP : MonoBehaviour
{
    public Transform[] waypoints;

    private void PopulateArray()
    {
        waypoints = new Transform[transform.childCount];
        int i = 0;

        foreach (Transform t in transform)
        {
            waypoints[i++] = t;
        }
    }
}
