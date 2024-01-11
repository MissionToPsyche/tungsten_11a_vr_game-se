using System;
using DevTools;
using UnityEngine;

namespace World.Entity.Camera
{
    /**
     * A camera that follows a set of points smoothly. Assign points in the inspector, and the script will create a smooth
     * path between them for the spaceship to follow.
     */
    public class RailCamera : MonoBehaviour
    {
        public bool DrawPath = true;
        public bool loop = false;
        public CameraNode[] Nodes;
        public int index;
        public float timer;

        public Transform spaceship;

        private void Start() { Update(); }

        private void Update()
        {
            MoveSpaceship();
        }

        /**
         * Gradually moves the spaceship to the next node and rotates it to the next node's rotation.
         */
        private void MoveSpaceship()
        {
            if (Nodes == null || Nodes.Length == 0) return;
            if (!DrawPath || (index >= Nodes.Length - 1 && !loop)) return;
            CameraNode currentNode = Nodes[index];
            CameraNode nextNode = Nodes[(index + 1) % Nodes.Length];
            Vector3 targetPosition = Vector3.Lerp(currentNode.Position, nextNode.Position, timer);
            Vector3 targetRotation = Vector3.Lerp(currentNode.Rotation, nextNode.Rotation, timer);
            spaceship.position = targetPosition;
            //spaceship.rotation = ...
            timer += Time.deltaTime * currentNode.TransitionSpeed;
            if (timer >= 1.0f)
            {
                timer = 0.0f;
                index = (index + 1) % Nodes.Length;
            }
        }

        private void OnDrawGizmos()
        {
            if (Nodes != null && Nodes.Length > 0 && DrawPath)
            {
                for (int i = 0; i < Nodes.Length - 1; ++i)
                {
                    if (Nodes[i] != null && Nodes[i + 1] != null)
                    {
                        Color color = (i == index || i == index - 1) ? Color.green : Color.blue;
                        DebugDrawUtil.DrawSphere(Nodes[i].Position, 0.15f, color);
                        DebugDrawUtil.DrawSphere(Nodes[i + 1].Position, 0.15f, color);
                        DebugDrawUtil.DrawSolidLine(Nodes[i].Position, Nodes[i + 1].Position, color);
                        DebugDrawUtil.DrawArrow(Nodes[i + 1].Position, (Nodes[i + 1].Position - Nodes[i].Position) * 0.1f, color);
                    }
                }
            }
        }
    }
}
