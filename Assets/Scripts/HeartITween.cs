using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HeartITween : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        iTween.PunchScale(gameObject, iTween.Hash("x", 0.6, "y", 0.6, "time", 1 ));

        
       
    }

    
    
}
