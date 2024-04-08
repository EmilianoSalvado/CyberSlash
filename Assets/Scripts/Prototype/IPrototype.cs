using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface IPrototype
{
    void Clone(Spawner spawner, Transform t, GameObject trigger);
}
