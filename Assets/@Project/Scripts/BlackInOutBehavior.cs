using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class BlackInOutBehavior : MonoBehaviour
{
    public Image image;
    bool isReady = false;
    [SerializeField] float alpha;

    void Start()
    {
        StartCoroutine(FadeIn());
    }

    void Update()
    {
        if (isReady && Input.anyKeyDown){
            StartCoroutine(FadeOut());
        }
    }

    IEnumerator FadeIn()
    {
        alpha = 1;

        while (alpha > 0)
        {
            //Debug.Log(Time.time);
            alpha -= Time.deltaTime;
            image.color = new Color(0, 0, 0, alpha);
            yield return null;
        }
        Debug.Log(Time.time);
        isReady = true;
    }

    IEnumerator FadeOut()
    {
        alpha = 0;
        // float t = Time.time;
        while (alpha < 1)
        {
            // Debug.Log(Time.deltaTime);
            alpha += Time.deltaTime * 0.8f;
            // Debug.Log(alpha);
            image.color = new Color(0, 0, 0, alpha);
            yield return null;
        }
        // Debug.Log(Time.time - t);
        SceneManager.LoadScene("Stage1");
        // SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
    }
}
