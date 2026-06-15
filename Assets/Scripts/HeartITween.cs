using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HeartITween : MonoBehaviour
{
    public float minScale = 0.9f;
    public float maxScale = 1.1f;
    public float speed = 2f;

    Vector3 _baseScale;

    void Start()
    {
        _baseScale = transform.localScale;
    }

    void Update()
    {
        float t = (Mathf.Sin(Time.time * speed) + 1f) * 0.5f;
        float factor = Mathf.Lerp(minScale, maxScale, t);
        transform.localScale = _baseScale * factor;
    }

}
