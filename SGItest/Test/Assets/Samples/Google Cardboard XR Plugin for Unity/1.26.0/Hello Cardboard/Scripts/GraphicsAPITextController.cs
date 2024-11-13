//-----------------------------------------------------------------------
// <copyright file="GraphicsAPITextController.cs" company="Google LLC">
// Copyright 2022 Google LLC
//
// Licensed under the Apache License, Version 2.0 (the "License");
// you may not use this file except in compliance with the License.
// You may obtain a copy of the License at
//
//     http://www.apache.org/licenses/LICENSE-2.0
//
// Unless required by applicable law or agreed to in writing, software
// distributed under the License is distributed on an "AS IS" BASIS,
// WITHOUT WARRANTIES OR CONDITIONS OF ANY KIND, either express or implied.
// See the License for the specific language governing permissions and
// limitations under the License.
// </copyright>
//-----------------------------------------------------------------------

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Rendering;
using UnityEngine.InputSystem; // Add this line for the new Input System
using UnityEngine.SceneManagement;
using UnityEngine.InputSystem.Controls; // Add this line for the new Input System


/// <summary>
/// Initializes Graphics API Text Mesh according to the used graphics API.
/// </summary>
public class GraphicsAPITextController : MonoBehaviour
{
    private TextMesh tm;
    public Rigidbody rb;
    public Camera mainCamera;
    public float moveSpeed = 5f;
    public GameObject cub1;
    public GameObject cub2;
    public GameObject cub3;
    public GameObject cub4;
    public GameObject cub5;
    public GameObject cub6;
    public GameObject cub7;
    /// <summary>
    /// Start is called before the first frame update.
    /// </summary>
    void Start()
    {
        tm = gameObject.GetComponent<TextMesh>();
        UpdateGraphicsApiText(); // Initialize text on start
    }

    /// <summary>
    /// Update is called once per frame.
    /// </summary>
    void Update()
    {
        // Check for any key press using the new Input System
        if (Keyboard.current.anyKey.wasPressedThisFrame)
        {
            // Loop through all keys and check which one is pressed
            foreach (KeyControl key in Keyboard.current.allKeys)
            {
                if (key.isPressed)
                {
                    tm.text = "Pressed Key: " + key.name; // Update text with pressed key
                    break; // Exit loop after finding the pressed key
                }
            }
        }

        // Check for mouse button presses
        if (Mouse.current.leftButton.wasPressedThisFrame)
        {
            tm.text = "Mouse Button: Left Button Pressed"; // Update text for left mouse button
        }
        else if (Mouse.current.rightButton.wasPressedThisFrame)
        {
            tm.text = "Mouse Button: Right Button Pressed"; // Update text for right mouse button
        }
        else if (Mouse.current.middleButton.wasPressedThisFrame)
        {
            tm.text = "Mouse Button: Middle Button Pressed"; // Update text for middle mouse button
        }

        // Check for gamepad input
        if (Gamepad.current != null) // Check if a gamepad is connected
        {
            // Check button presses
            CheckGamepadButtons();
            // Check axis movements
            CheckGamepadAxes();
        }
    }

    private void CheckGamepadButtons()
    {
        // Checking all gamepad buttons
        if (Gamepad.current.buttonSouth.wasPressedThisFrame) // A / Cross
        {
            tm.text = "Gamepad Button: South (A/Cross) Pressed";
            SceneManager.LoadScene(SceneManager.GetActiveScene().name);
        }
        else if (Gamepad.current.buttonEast.wasPressedThisFrame) // B / Circle
        {
            tm.text = "Gamepad Button: East (B/Circle) Pressed";
        }
        else if (Gamepad.current.buttonWest.wasPressedThisFrame) // X / Square
        {
            tm.text = "Gamepad Button: West (X/Square) Pressed";
        }
        else if (Gamepad.current.buttonNorth.wasPressedThisFrame) // Y / Triangle
        {
            tm.text = "Gamepad Button: North (Y/Triangle) Pressed";
        }
        else if (Gamepad.current.leftShoulder.wasPressedThisFrame) // Left Shoulder
        {
            tm.text = "Gamepad Button: Left Shoulder Pressed";
            cub1.transform.position = new Vector3(0, 1, 8);
            cub2.transform.position = new Vector3(0, 1, 12);
            cub3.transform.position = new Vector3(0, 1, 16);
            cub4.transform.position = new Vector3(3, 1, 8);
            cub5.transform.position = new Vector3(3, 2, 12);
            cub6.transform.position = new Vector3(3, 1, 16);
            cub7.transform.position = new Vector3(6, 1, 12);
        }
        else if (Gamepad.current.rightShoulder.wasPressedThisFrame) // Right Shoulder
        {
            tm.text = "Gamepad Button: Right Shoulder Pressed";
        }
        else if (Gamepad.current.leftStickButton.wasPressedThisFrame) // Left Stick
        {
            tm.text = "Gamepad Button: Left Stick Button Pressed";
        }
        else if (Gamepad.current.rightStickButton.wasPressedThisFrame) // Right Stick
        {
            tm.text = "Gamepad Button: Right Stick Button Pressed";
        }
        else if (Gamepad.current.dpad.up.wasPressedThisFrame) // DPad Up
        {
            tm.text = "Gamepad Button: DPad Up Pressed";
        }
        else if (Gamepad.current.dpad.down.wasPressedThisFrame) // DPad Down
        {
            tm.text = "Gamepad Button: DPad Down Pressed";
        }
        else if (Gamepad.current.dpad.left.wasPressedThisFrame) // DPad Left
        {
            tm.text = "Gamepad Button: DPad Left Pressed";
        }
        else if (Gamepad.current.dpad.right.wasPressedThisFrame) // DPad Right
        {
            tm.text = "Gamepad Button: DPad Right Pressed";
        }
    }

    private void CheckGamepadAxes()
    {
        // Checking the axes
        Vector2 leftStick = Gamepad.current.leftStick.ReadValue();
        Vector2 rightStick = Gamepad.current.rightStick.ReadValue();
        float leftTrigger = Gamepad.current.leftTrigger.ReadValue();
        float rightTrigger = Gamepad.current.rightTrigger.ReadValue();

        if (leftStick.magnitude > 0.1f)
        {
            tm.text = "Gamepad Axis: Left Stick (X: " + leftStick.x + ", Y: " + leftStick.y + ")";
            Vector3 cameraForward = mainCamera.transform.forward;
            Vector3 cameraRight = mainCamera.transform.right;

            cameraForward.y = 0;
            cameraRight.y = 0;

            cameraForward.Normalize();
            cameraRight.Normalize();

            Vector3 moveDirection = (cameraForward * leftStick.y + cameraRight * leftStick.x).normalized;

            Vector3 movement = moveDirection * moveSpeed * Time.deltaTime;
            rb.MovePosition(rb.position + movement);
        }
        else if (rightStick.magnitude > 0.1f)
        {
            tm.text = "Gamepad Axis: Right Stick (X: " + rightStick.x + ", Y: " + rightStick.y + ")";
        }
        else if (leftTrigger > 0.1f)
        {
            tm.text = "Gamepad Axis: Left Trigger Value: " + leftTrigger;
        }
        else if (rightTrigger > 0.1f)
        {
            tm.text = "Gamepad Axis: Right Trigger Value: " + rightTrigger;
        }
    }

    private void UpdateGraphicsApiText()
    {
//        switch (SystemInfo.graphicsDeviceType)
//        {
//#if !UNITY_2023_1_OR_NEWER
//            case GraphicsDeviceType.OpenGLES2:
//                tm.text = "OpenGL ES 2";
//                break;
//#endif
//            case GraphicsDeviceType.OpenGLES3:
//                tm.text = "OpenGL ES 3";
//                break;
//#if UNITY_IOS
//            case GraphicsDeviceType.Metal:
//                tm.text = "Metal";
//                break;
//#endif
//#if UNITY_ANDROID
//            case GraphicsDeviceType.Vulkan:
//                tm.text = "Vulkan";
//                break;
//#endif
//            default:
//                tm.text = "Unrecognized Graphics API";
//                break;
//        }
    }
}
