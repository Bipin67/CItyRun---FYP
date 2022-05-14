using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Animations : MonoBehaviour
{
    private bool _show = true;
    private Animator _animator;
    
    public void ShowHide()
    {
        if (_animator == null) _animator = GetComponent<Animator>();

        if (_animator == null) return;

        _animator.Play(_show ? "open" : "close");
        _show = !_show;
    }
}