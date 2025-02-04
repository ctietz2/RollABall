using UnityEngine;
using System.Collections;

namespace Valve.VR.InteractionSystem
{
    public class MovePlayer : MonoBehaviour
    {
        public Transform teleportPoint;  // The TeleportPoint the player should follow
        public float followSpeed = 1.0f; // Speed of movement (set to 0 for instant move)
        private Vector3 lastTeleportPosition;
        private Quaternion lastTeleportRotation;

        void Start()
        {
            if (teleportPoint != null)
            {
                lastTeleportPosition = teleportPoint.position;
                lastTeleportRotation = teleportPoint.rotation;
            }
        }

        void Update()
        {
            if (teleportPoint == null)
            {
                Debug.LogWarning("MovePlayer: No TeleportPoint assigned.");
                return;
            }

            // Check if the TeleportPoint moved
            if (teleportPoint.position != lastTeleportPosition || teleportPoint.rotation != lastTeleportRotation)
            {
                Vector3 positionOffset = teleportPoint.position - lastTeleportPosition;
                Quaternion rotationOffset = teleportPoint.rotation * Quaternion.Inverse(lastTeleportRotation);

                // Move the player smoothly or instantly
                if (followSpeed > 0)
                {
                    StartCoroutine(SmoothMovePlayer(transform.position + positionOffset, rotationOffset * transform.rotation));
                }
                else
                {
                    transform.position += positionOffset;
                    transform.rotation = rotationOffset * transform.rotation;
                }

                // Update stored position and rotation
                lastTeleportPosition = teleportPoint.position;
                lastTeleportRotation = teleportPoint.rotation;
            }
        }

        private IEnumerator SmoothMovePlayer(Vector3 targetPosition, Quaternion targetRotation)
        {
            float duration = 0.5f / followSpeed; // Adjust speed
            float elapsedTime = 0f;
            Vector3 startPosition = transform.position;
            Quaternion startRotation = transform.rotation;

            while (elapsedTime < duration)
            {
                transform.position = Vector3.Lerp(startPosition, targetPosition, elapsedTime / duration);
                transform.rotation = Quaternion.Slerp(startRotation, targetRotation, elapsedTime / duration);
                elapsedTime += Time.deltaTime;
                yield return null;
            }

            transform.position = targetPosition;
            transform.rotation = targetRotation;
        }

        public void SetTeleportPoint(Transform newTeleportPoint)
        {
            teleportPoint = newTeleportPoint;
            lastTeleportPosition = newTeleportPoint.position;
            lastTeleportRotation = newTeleportPoint.rotation;
        }
    }
}
