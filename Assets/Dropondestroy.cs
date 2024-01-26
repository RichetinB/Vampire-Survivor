using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Dropondestroy : MonoBehaviour
{
    [SerializeField] GameObject Gempickup;
    [SerializeField][Range(0f, 1f)] float chance = 1f;

    private void OnDestroy()
    {
        if (Random.value < chance)
        {
            Transform t = Instantiate(Gempickup).transform;
            t.position = transform.position;
        }
    }
}
