using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class typewritereffect : MonoBehaviour
{

    public float delay = 0.1f;
    public string fullText;
    public string fullText2;
    public string fullText3;
    public string fullText4;
    public string fullText5;
    private string currentText = "";

    IEnumerator Start()
    {
        yield return new WaitForSeconds(7.0f);
        yield return StartCoroutine("ShowText");
        yield return new WaitForSeconds(4.0f);
        yield return StartCoroutine("ShowText2");
        yield return new WaitForSeconds(4.0f);
        yield return StartCoroutine("ShowText3");
        yield return new WaitForSeconds(2.0f);
        yield return StartCoroutine("ShowText4");
        yield return new WaitForSeconds(4.0f);
        yield return StartCoroutine("ShowText5");
    }
    IEnumerator ShowText()
    {
        for (int i = 0; i < fullText.Length; i++)
        {
            currentText = fullText.Substring(0, i);
            this.GetComponent<Text>().text = currentText;
            yield return new WaitForSeconds(delay);


        }
    }

    IEnumerator ShowText2()
    {
        for (int i = 0; i < fullText2.Length; i++)
        {
                currentText = fullText2.Substring(0, i);
                this.GetComponent<Text>().text = currentText;
                yield return new WaitForSeconds(delay);

        }
    }

    IEnumerator ShowText3()
    {
        for (int i = 0; i < fullText3.Length; i++)
        {
            currentText = fullText3.Substring(0, i);
            this.GetComponent<Text>().text = currentText;
            yield return new WaitForSeconds(delay);

        }
    }

    IEnumerator ShowText4()
    {
        for (int i = 0; i < fullText4.Length; i++)
        {
            currentText = fullText4.Substring(0, i);
            this.GetComponent<Text>().text = currentText;
            yield return new WaitForSeconds(delay);

        }
    }

    IEnumerator ShowText5()
    {
        for (int i = 0; i < fullText5.Length; i++)
        {
            currentText = fullText5.Substring(0, i);
            this.GetComponent<Text>().text = currentText;
            yield return new WaitForSeconds(delay);

        }
    }
}