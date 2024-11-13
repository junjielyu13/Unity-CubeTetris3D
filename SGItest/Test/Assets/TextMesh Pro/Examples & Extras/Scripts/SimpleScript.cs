using UnityEngine;
using System.Collections;
using UnityEngine.XR.Interaction.Toolkit;
using UnityEngine.InputSystem; // For the new Input System

namespace TMPro.Examples
{
    public class SimpleScript : MonoBehaviour
    {
        //public XRGrabInteractable grabInteractable;
        //private GameObject grabbedObject;
        //private string name;

        //void Start()
        //{
        //    // 获取 XR Grab Interactable 组件
        //    grabInteractable = GetComponent<XRGrabInteractable>();
    

        //    // 注册抓取和释放事件
        //    grabInteractable.selectEntered.AddListener(OnGrab);
        //    grabInteractable.selectExited.AddListener(OnRelease);
        //}

        //void Update()
        //{
        //    // 确保抓取时允许旋转
        //    if (grabbedObject != null && this.grabbedObject.name == this.name)
        //    {
        //        if (Gamepad.current.buttonEast.wasPressedThisFrame) // B / Circle
        //        {
        //            grabbedObject.transform.Rotate(0, 0, 90); // 对 Z 轴进行 90 度旋转
        //        }
        //        else if (Gamepad.current.buttonWest.wasPressedThisFrame) // X / Square
        //        {
        //            grabbedObject.transform.Rotate(90, 0, 0); // 对 X 轴进行 90 度旋转
        //        }
        //        else if (Gamepad.current.buttonNorth.wasPressedThisFrame) // Y / Triangle
        //        {
        //            grabbedObject.transform.Rotate(0, 90, 0); // 对 Y 轴进行 90 度旋转
        //        }
        //    }
        //}

        //private void OnGrab(SelectEnterEventArgs args)
        //{

        //    if (grabbedObject != null)
        //    {
        //        grabbedObject = null;  // 清空当前抓取的物体
        //    }


        //    grabbedObject = args.interactableObject.transform.gameObject;
        //    name = grabbedObject.name;
        //    Debug.Log("Item Name: " + grabbedObject.name);

        //    // Optional: Here you can disable grab interaction during rotation if needed
        //    // For example, disable grabInteractable temporarily:
        //    grabInteractable.interactionLayerMask = ~0; // Temporarily disable interaction
        //}

        //private void OnRelease(SelectExitEventArgs args)
        //{
        //    Debug.Log("Item Released");
        //    // Re-enable interaction after release
        //    // grabInteractable.interactionLayerMask = ~0; // Re-enable interaction
        //}

        //private void OnDestroy()
        //{
        //    // 注销事件，防止内存泄漏
        //    grabInteractable.selectEntered.RemoveListener(OnGrab);
        //    grabInteractable.selectExited.RemoveListener(OnRelease);
        //}
    }
}
