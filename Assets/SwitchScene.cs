using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SwitchScene : MonoBehaviour
{
    public string sceneName;
    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(EnableAfterSpawn());
    }
    public void switchScene()
    {
        StartCoroutine(LoadYourAsyncScene());
    }
    // Update is called once per frame
    void Update()
    {
        
    }
    IEnumerator LoadYourAsyncScene()
    {

        AsyncOperation asyncLoad = UnityEngine.SceneManagement.SceneManager.LoadSceneAsync(sceneName);
        asyncLoad.allowSceneActivation = true;


        // yield to other processes until the scene is loaded
        while (!asyncLoad.isDone)
        {
            yield return null;
        }

        // Do something here like enabling the play button or closing the splash/loading screen
    }
    IEnumerator EnableAfterSpawn()
    {
        GetComponent<SphereCollider>().enabled = false;
        yield return new WaitForSeconds(.1f);
        GetComponent<SphereCollider>().enabled = true;

        // Do something here like enabling the play button or closing the splash/loading screen
    }
}
