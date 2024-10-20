using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SceneAutoTrans : MonoBehaviour
{
    [SerializeField] float Wait = 1f;
    [SerializeField] string SceneName;

    void Start()
    {
        StartCoroutine(ChangeToMenuAfterTime());
    }

    IEnumerator ChangeToMenuAfterTime() 
    {
        yield return new WaitForSeconds(Wait);
        SceneLoader.loadScenebyName(SceneName);
    }



}
