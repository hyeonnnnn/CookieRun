
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RepeatFlower : MonoBehaviour
{
    [SerializeField] [Range(1f, 100f)] float speed = 0.0001f;
    [SerializeField] float posValue = 5;

    Vector2 startPos;
    float newPos;

    // Start is called before the first frame update
    void Start()
    {
        startPos = transform.position;
    }

    // Update is called once per frame
    void Update()
    {
        newPos = Mathf.Repeat(Time.time * speed, posValue);
        transform.position = startPos + Vector2.left * newPos;
    }
}
