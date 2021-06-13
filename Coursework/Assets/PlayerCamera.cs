using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerCamera : MonoBehaviour
{
    public void SetPosition(Vector2 position) => transform.position = new Vector3(position.x, position.y, -10);
}
