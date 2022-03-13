using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.SceneManagement;
public class StartText : MonoBehaviour,IPointerDownHandler
{
    [SerializeField] private Vector3 startPos;
    [SerializeField] private Vector3 upPos;
    [SerializeField] private Vector3 downPos;

    private void Awake()
    {
        Initialize_PosValue();
    }

    private void OnEnable()
    {
        Setting_PosValue();
        Start_Move();
    }

    private void Initialize_PosValue()
    {
        startPos = transform.localPosition;
        upPos = new Vector3(startPos.x, startPos.y+20, startPos.z);
        downPos = new Vector3(startPos.x, startPos.y-20, startPos.z);
    }

    private void Setting_PosValue()
    {
        transform.localPosition = startPos;
    }

    private void Start_Move()
    {
        StartCoroutine("Move_StartText");
    }

    IEnumerator Move_StartText()
    {
        Vector3 targetPos = upPos;
        int targetY = -754;
        while (true)
        {
            transform.localPosition = Vector3.Lerp(transform.localPosition, targetPos, 0.1f);
            if (transform.localPosition.y >= targetY)
            {
                targetPos = downPos;
                targetY = -792;
            }
            else if (transform.localPosition.y <= targetY)
            {
                targetPos = upPos;
                targetY = -754;
            }

            yield return new WaitForSeconds(0.02f);
        }
    }

    public void OnPointerDown(PointerEventData eventData)
    {
        SceneManager.LoadScene("Tutorial", LoadSceneMode.Additive);
    }
}
