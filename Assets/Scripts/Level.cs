using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Level : MonoBehaviour {
    // Cached references
    SceneLoader sceneLoader;

    // States
    [SerializeField] int blockCount = 0;

    public void CountBreakableBlocks()
    {
        blockCount++;
    }

    public void BreakABlock()
    {
        blockCount--;
        if(blockCount <= 0)
        {
            sceneLoader.LoadNextScene();
        }
    }

	// Use this for initialization
	void Start () {
        sceneLoader = FindObjectOfType<SceneLoader>();
	}
	
}
