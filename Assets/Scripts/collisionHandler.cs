using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface collisionHandler
{
    void CollisionEnter(string colliderName, GameObject other);

    void killedTrigger(string colliderName, GameObject other);
}
