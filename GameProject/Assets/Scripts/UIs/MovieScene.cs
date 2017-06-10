using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class MovieScene : MonoBehaviour {

	// Use this for initialization
	void Start () {
        StartCoroutine(SceneMove());
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    public IEnumerator SceneMove()
    {

            yield return new WaitForSeconds(19.5f);
            StopCoroutine(SceneMove());
            SceneManager.LoadScene("InGame");
    }
}
