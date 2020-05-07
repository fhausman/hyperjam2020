using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Effects : MonoBehaviour
{
    [SerializeField]
    private Animator animator;

    public void Flash()
    {
        animator.Play("Flash");
    }
}
