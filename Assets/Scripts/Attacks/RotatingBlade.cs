using UnityEngine;

namespace Attacks
{
    public class RotatingBlade : MonoBehaviour
    {
        public Texture2D Icon;

        public float rotationSpeed = 10f;
        public float rotateAroundSpeed = 50f;
        public float damage = 50;

        public GameObject rotateAround;

        private void Start()
        {
            rotateAround = GameObject.FindGameObjectWithTag("RotatingBlade");
        }

        // Update is called once per frame
        private void FixedUpdate()
        {
            transform.Rotate(0, 0, rotationSpeed);
            transform.RotateAround(rotateAround.transform.position, Vector3.forward,
                rotateAroundSpeed * Time.deltaTime);
        }
    }
}