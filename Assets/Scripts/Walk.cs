using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Walk : MonoBehaviour
{

    public AudioClip WalkSound;
    public bool WalkFlag;

    private void Start()
    {
        StartCoroutine(WalkTerm());
    }

    private void OnTriggerEnter(Collider col)
    {
        if (col.gameObject.layer == LayerMask.NameToLayer("Ground") && WalkFlag==true)
        {
            AudioSource.PlayClipAtPoint(WalkSound, transform.position);
            Debug.Log("Walked");
        }
    }

    private void OnTriggerExit(Collider colex)
    {
        WalkFlag = false;
    }

    IEnumerator WalkTerm()
    {
        while (true)
        {
            WalkFlag = true;
            yield return new WaitForSeconds(0.5f);
        }
    }
}
