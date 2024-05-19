using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ParentToTank : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(WaitToParent());
    }

    IEnumerator WaitToParent()
    {
        yield return new WaitForSeconds(3f);
        GameObject tank = GameObject.FindWithTag("Player1");
        transform.SetParent(tank.transform, false);
        transform.localPosition = Vector3.up * 0.8f;
    }
}
