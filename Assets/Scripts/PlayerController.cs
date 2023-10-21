using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerController : MonoBehaviour
{
    public GameObject Player;
    [SerializeField] float Speed=83f;
    [SerializeField] float JumpSpeed =290f;
    [SerializeField] float ClimbSpeed = 8f;
    [SerializeField] Vector2 die = new Vector2(20f, 20f);

    
   
}
