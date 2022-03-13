using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BGGoundMove : MonoBehaviour
{
    [SerializeField] private Transform[] bgImags;

    private void Awake()
    {
        Initialize_BGImages();
    }

    private void OnEnable()
    {
        Setting_BGImage();
        Start_BGMove();
    }

    private void Initialize_BGImages()
    {
        bgImags = new Transform[transform.childCount];
        for (int i = 0; i < bgImags.Length; i++)
        {
            bgImags[i] = transform.GetChild(i);
        }
    }

    private void Setting_BGImage()
    {
        for (int i = 0; i < bgImags.Length; i++)
        {
            bgImags[i].gameObject.SetActive(true);
        }
    }

    public void Start_BGMove()
    {
        StartCoroutine("Move_BGImage");
    }

    IEnumerator Move_BGImage()
    {
        while (true)
        {
            for (int i = 0; i < bgImags.Length; i++)
            {
                bgImags[i].transform.Translate(Vector3.left * 0.1f /*Time.deltaTime*/);
                if (bgImags[i].localPosition.x <= -3820)
                {
                    bgImags[i].localPosition = new Vector3(3820, -1124, 0);
                }
            }
            yield return new WaitForSeconds(0.02f);
        }
    }
}
