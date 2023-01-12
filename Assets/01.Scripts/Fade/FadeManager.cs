using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class FadeManager : MonoBehaviour
{
    public List<UIFade> menuFadeUI = new List<UIFade> ();
    public List<UIFade> topFadeUI = new List<UIFade> ();
    public void MenuFadeIn()
    {
        
        for (int i = 0; i < menuFadeUI.Count; i++)
        {
            
                if (menuFadeUI[i].gameObject.transform.parent.GetComponent<Slider>() != null)
            {
                menuFadeUI[i].gameObject.transform.parent.gameObject.SetActive(true);
            }
            Debug.Log("º!" + i);
            menuFadeUI[i].gameObject.SetActive(true);

            if (menuFadeUI[i].gameObject.name.Contains("Text"))
            {
                menuFadeUI[i].GetComponent<TextMeshProUGUI>().color = new Color
                    (menuFadeUI[i].GetComponent<TextMeshProUGUI>().color.r, menuFadeUI[i].GetComponent<TextMeshProUGUI>().color.g,
                    menuFadeUI[i].GetComponent<TextMeshProUGUI>().color.b, 0);
            }
            else
            {
                menuFadeUI[i].GetComponent<Image>().color = new Color
                    (menuFadeUI[i].GetComponent<Image>().color.r, menuFadeUI[i].GetComponent<Image>().color.g,
                    menuFadeUI[i].GetComponent<Image>().color.b, 0);
            }
        }

        for (int i = 0; i < menuFadeUI.Count; i++)
        {
            menuFadeUI[i].FadeIn();
        }
    }
    public void MenuFadeOut()
    {
        StopCoroutine(MenuFadeOutCoroutine());
        StartCoroutine(MenuFadeOutCoroutine());
    }
    IEnumerator MenuFadeOutCoroutine()
    {
        for(int i = 0; i < menuFadeUI.Count; i++)
        {
            menuFadeUI[i].FadeOut();
        } 

        yield return new WaitForSeconds(menuFadeUI[0].FadeTime);
            for (int j = 0; j < topFadeUI.Count; j++)
            {
                if (topFadeUI[j].transform.parent.GetComponent<Button>() != null)
                {
                    topFadeUI[j].transform.parent.GetComponent<Button>().enabled = true;
                }
            }
        for (int i = 0; i < menuFadeUI.Count; i++)
        {
            if (menuFadeUI[i].gameObject.transform.parent.GetComponent<Slider>() != null)
            {
                menuFadeUI[i].gameObject.transform.parent.gameObject.SetActive(false);
            }

            menuFadeUI[i].gameObject.SetActive (false);
        }
    }

    public void TopFadeIn()
    {
        for (int i = 0; i < topFadeUI.Count; i++)
        {
            
            if (topFadeUI[i].gameObject.transform.GetComponent<Button>() != null)
            {
                topFadeUI[i].gameObject.transform.gameObject.SetActive(true);
            }
        }
        for (int i = 0; i < topFadeUI.Count; i++)
        {
            topFadeUI[i].FadeIn();
        }
    }
    public void TopFadeOut()
    {
        StopCoroutine(TopFadeOutCoroutine());
        StartCoroutine(TopFadeOutCoroutine());
        //for (int i = 0; i < topFadeUI.Count; i++)
        //{
        //    topFadeUI[i].FadeOut();
        //}
    }
    IEnumerator TopFadeOutCoroutine()
    {
        for (int i = 0; i < topFadeUI.Count; i++)
        {
            if (topFadeUI[i].transform.parent.GetComponent<Button>() != null)
            {
                topFadeUI[i].transform.parent.GetComponent<Button>().enabled = false;
            }
            topFadeUI[i].FadeOut();
        }

        yield return new WaitForSeconds(topFadeUI[0].FadeTime);

        for (int i = 0; i < topFadeUI.Count; i++)
        {
            if (topFadeUI[i].gameObject.transform.GetComponent<Button>() != null)
            {
                topFadeUI[i].gameObject.transform.gameObject.SetActive(false);
            }
        }
    }
}
