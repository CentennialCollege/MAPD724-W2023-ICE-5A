using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
  public Boundary boundary;
  public Camera camera;

    // Start is called before the first frame update
    void Start()
    {
      camera = FindObjectOfType<Camera>();
    }

    // Update is called once per frame
    void Update()
    {
      Move();
      CheckBounds();
    }

  void Move()
  {
    foreach(var touch in Input.touches)
    {
      transform.position = new Vector2(camera.ScreenToWorldPoint(touch.position).x, -4.0f);
    }
  }

  void CheckBounds()
  {
    // right bounds
    if(transform.position.x > boundary.right)
    {
      transform.position = new Vector2(boundary.right, -4.0f);
    }

    // left bounds
    if (transform.position.x < boundary.left)
    {
      transform.position = new Vector2(boundary.left, -4.0f);
    }
  }

  public void OnTriggerEnter2D(Collider2D other)
  {
    if(other.gameObject.CompareTag("Cloud"))
    {
      other.gameObject.GetComponent<AudioSource>().Play();
    }

    if(other.gameObject.CompareTag("Island"))
    {
      other.gameObject.GetComponent<AudioSource>().Play();
    }
  }
}
