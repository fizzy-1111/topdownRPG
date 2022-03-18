using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Portal : Collidable
{
    public List<string> sceneNames;
    protected override void OnCollide(Collider2D coll)
    {
        if (coll.name == "Player")
        {
            GameManager.Instance.saveState();
            string sceneName = sceneNames[Random.Range(0, sceneNames.Count)];
            SceneManager.LoadScene(sceneName);

        }
    }
}
