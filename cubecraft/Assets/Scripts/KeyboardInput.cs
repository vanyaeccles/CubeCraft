﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Cube;

namespace KeyInput
{
    /*KeyboardInput.cs
     * This class handles input signals from the keyboard.
     */
    public class KeyboardInput : MonoBehaviour
    {
        private Movement movement;

        void Awake()
        {
            movement = GameObject.Find("Player Controlled Cube").GetComponent<Movement>();
        }

        void Update()
        {
            if (Input.GetKeyDown(KeyCode.W)||Input.GetKeyDown(KeyCode.UpArrow))
            {
                movement.MoveUp();
            }
            if (Input.GetKeyDown(KeyCode.S) || Input.GetKeyDown(KeyCode.DownArrow))
            {
                movement.MoveDown();
            }
            if (Input.GetKeyDown(KeyCode.A) || Input.GetKeyDown(KeyCode.LeftArrow))
            {
                movement.MoveLeft();
            }
            if (Input.GetKeyDown(KeyCode.D) || Input.GetKeyDown(KeyCode.RightArrow))
            {
                movement.MoveRight();
            }
        }
    }
}