using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Vector2 = System.Numerics.Vector2;

public class FollowPlayer : MonoBehaviour
{
    public Player Player;
    
    void FixedUpdate()
    {
        this.transform.position = new Vector3(this.transform.position.x, Player.transform.position.y, this.transform.position.z);
    }
}
