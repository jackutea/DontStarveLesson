using UnityEngine;

namespace DontStarve.Sample {

    public class SampleRoleEntity : MonoBehaviour {

        public Rigidbody rb;

        void Start() {

        }

        void FixedUpdate() {

            float fixedDT = Time.fixedDeltaTime;
            float x = Input.GetAxis("Horizontal");
            float y = Input.GetAxis("Vertical");

            float oldVeloY = rb.velocity.y;

            float moveSpeed = 5f;
            Vector3 dir = new Vector3(x, 0, y) * moveSpeed * fixedDT;
            dir.Normalize();

            dir.y = oldVeloY;
            rb.velocity = dir;

        }

        void Update() {

        }

    }

}