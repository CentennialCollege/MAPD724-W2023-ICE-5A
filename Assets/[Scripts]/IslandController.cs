using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class IslandController : MonoBehaviour
{
  public float verticalSpeed;
  public Boundary boundary;
    // Start is called before the first frame update
    void Start()
    {
      ResetObject();
    }

    // Update is called once per frame
    void FixedUpdate()
    {
      Move();
      CheckBounds();
    }

  void Move()
  {
    transform.position -= new Vector3(0.0f, verticalSpeed);
  }

  void CheckBounds()
  {
    if (transform.position.y <= boundary.bottom)
    {
      ResetObject();
    }
  }

  void ResetObject()
  {
    float randomXposition = Random.Range(boundary.left, boundary.right);
    transform.position = new Vector2(randomXposition, boundary.top);
  }
}
