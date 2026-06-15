using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Delete : MonoBehaviour

{
    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(KillthisGO());
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        GameObject.Destroy(this.gameObject);
    }

    private IEnumerator KillthisGO()
    {
        yield return new WaitForSeconds(1.5f);
        GameObject.Destroy(this.gameObject);

    }
}
