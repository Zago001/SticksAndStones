﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneTransition : PlayerTransition
{
    public string sceneName;

    public override void Awake()
    {
        base.Awake();
        DontDestroyOnLoad(transform.parent.gameObject);
        DontDestroyOnLoad(canvasGroup.transform.parent.gameObject);
    }

    public override IEnumerator Blackout()
    {
        yield return StartCoroutine("DoFade");
        SceneManager.LoadScene(sceneName);
        yield return StartCoroutine("MovePlayer");
        yield return new WaitForSeconds(0.5f);
		yield return StartCoroutine("EndFade");
        //yield return new WaitForSeconds(1f);
        Destroy(transform.parent.gameObject);
		TimeProgression.Instance.dayNight.lamps = new List<GameObject>(); //List of lamps
		foreach(GameObject obj in GameObject.FindGameObjectsWithTag("Lamp")) { //Takes in all the lamps at start of scene
			TimeProgression.Instance.dayNight.lamps.Add(obj);
		}
    }

	public override void OnTriggerEnter2D(Collider2D other) // overridden so that transition occurs without needing key press
	{
		Debug.Log("switching locations");
		StartCoroutine(Blackout());
	}

	public override void Update() { // overridden so that transition occurs without needing key press
		
	}
}
