using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class VRRotationStabilizer : MonoBehaviour
{
    public Transform buggy; // Assign the vehicle transform in the inspector
    public float xzDamping = 0.2f; // Lower values reduce X/Z tilt more

    void LateUpdate()
    {
        if (buggy == null) return;

        // Get the vehicle's world rotation
        Quaternion buggyRotation = buggy.rotation;

        // Extract only the unwanted rotation components
        Vector3 buggyEuler = buggyRotation.eulerAngles;

        // Reduce X and Z tilt while keeping Y rotation
        float correctedX = Mathf.LerpAngle(buggyEuler.x, 0, xzDamping);
        float correctedZ = Mathf.LerpAngle(buggyEuler.z, 0, xzDamping);
        float yRotation = buggyEuler.y; // Keep full Y-axis rotation

        // Apply only the corrected rotation to this anchor (NOT the VR player itself)
        transform.rotation = Quaternion.Euler(correctedX, yRotation, correctedZ);
    }
}
