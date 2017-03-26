using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface IMovement
{
    void Move();
    Vector3 GetCurrentRotation();
    void SetCurrentRotation(Vector3 startingRotation);

}
