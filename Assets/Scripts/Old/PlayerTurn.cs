﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerTurn : MonoBehaviour
{
    int index = 0;
    int totalOptions = 4;
    public float xOffset = 239.93f;
    public float yOffset = 130.59f;
    Vector2 position;
    Button hurt;
    Button consume;
    Button protect;
    Button run;
    Button Continue;
    public bool playerTurn = true;
    Image playerNav;
    bool switched = false;

    //DialogueManager dialogueManager;

    void Awake()
    {

        hurt = GameObject.Find("Hurt").GetComponent<Button>();
        consume = GameObject.Find("Consume").GetComponent<Button>();
        protect = GameObject.Find("Protect").GetComponent<Button>();
        run = GameObject.Find("Run").GetComponent<Button>();
        //dialogueManager = GameObject.Find("DialogueManager").GetComponent<DialogueManager>();
        Continue = GameObject.Find("Continue").GetComponent<Button>();
        playerNav = GameObject.Find("PlayerNav").GetComponent<Image>();
    }

    // Update is called once per frame
    void Update()
    {
        if(playerTurn)
        {
            ScrollThroughOptions();
            CheckForKeyInput();
        }
        /*else if(Input.GetKeyDown(KeyCode.Z))
        {
            Continue.onClick.Invoke();
            //dialogueManager.DisplayNextSentence();
        }*/

    }

    private void CheckForKeyInput()
    {
        if (!switched)
        {
            switch (index)
            {
                case 0:
                    if (Input.GetKeyDown(KeyCode.Z))
                    {
                        hurt.onClick.Invoke();
                        switched = true;
                    }
                    break;
                case 1:
                    if (Input.GetKeyDown(KeyCode.Z))
                    {
                        consume.onClick.Invoke();
                        switched = true;
                    }
                    break;
                case 2:
                    if (Input.GetKeyDown(KeyCode.Z))
                    {
                        consume.onClick.Invoke();
                        switched = true;
                    }
                    break;
                case 3:
                    if (Input.GetKeyDown(KeyCode.Z))
                    {
                        run.onClick.Invoke();
                        switched = true;
                    }
                    break;
                default:
                    break;
            }
        } else
        {
            switch (index)
            {
                case 0:
                    if (Input.GetKeyDown(KeyCode.Z))
                    {
                        hurt.onClick.Invoke(); //figure out a way to check which panel is up
                        //implement this fuckingn state machine already
                    }
                    break;
                case 1:
                    if (Input.GetKeyDown(KeyCode.Z))
                    {
                        consume.onClick.Invoke();
                    }
                    break;
                case 2:
                    if (Input.GetKeyDown(KeyCode.Z))
                    {
                        consume.onClick.Invoke();
                    }
                    break;
                case 3:
                    if (Input.GetKeyDown(KeyCode.Z))
                    {
                        run.onClick.Invoke();
                    }
                    break;
                default:
                    break;
            }
        }
    }

    private void ScrollThroughOptions()
    {
        if (Input.GetKeyDown(KeyCode.DownArrow))
        {
            if (index < totalOptions / 2)
            {
                index = index + 2;
                position = transform.position;
                position.y -= yOffset;
                transform.position = position;
            }
        }

        if (Input.GetKeyDown(KeyCode.UpArrow))
        {
            if (index > (totalOptions - 1) / 2)
            {
                index = index - 2;
                position = transform.position;
                position.y += yOffset;
                transform.position = position;
            }
        }

        if (Input.GetKeyDown(KeyCode.RightArrow))
        {
            if (index % 2 == 0)
            {
                index = index + 1;
                position = transform.position;
                position.x += xOffset;
                transform.position = position;
            }
        }

        if (Input.GetKeyDown(KeyCode.LeftArrow))
        {
            if (index % 2 != 0)
            {
                {
                    index = index - 1;
                    position = transform.position;
                    position.x -= xOffset;
                    transform.position = position;
                }
            }
        }
    }
}
