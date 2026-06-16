using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

public class titleScreen : MonoBehaviour
{
    public GameObject StartButtonGO;
    public Transform moveTarget;
    public TMP_Text StartText;
    public Transform MiddleTrans;
    public GameObject GamemodeButtonsPar;
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }

    public void StartButton()
    {
        StartCoroutine(StartButtonInum());
    }

    private IEnumerator StartButtonInum()
    {
        yield return new WaitForSeconds(0.1f);

        float t = 0f;
        Vector3 startPos = StartButtonGO.transform.position;
        Vector3 endPos = moveTarget.position;

        Vector3 startPos2 = GamemodeButtonsPar.transform.position;
        Vector3 endPos2 = MiddleTrans.position;

        while (t < 1f)
        {
            t += Time.deltaTime * 2;
            StartButtonGO.transform.position = Vector3.Lerp(startPos, endPos, t);

            GamemodeButtonsPar.transform.position = Vector3.Lerp(startPos2, endPos2, t);

            yield return null;
        }
        iTween.FadeTo(StartButtonGO, iTween.Hash("alpha", 0.1, "time", 1));
        StartButtonGO.SetActive(false);


    }

    public void NormalButton()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
    }

    public void QuitButton()
    {
        Application.Quit();
    }


    public void TitleScreenButton()
    {
        SceneManager.LoadScene("TitleScreen");
    }
  
}
