using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface IInputPlayer
{
    Vector3 getMovmentAxis();
    bool getDashInput();
}
