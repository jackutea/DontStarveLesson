using UnityEngine;

namespace DontStarve {

    public class PlantEntity : MonoBehaviour {

        // 自带 Transform, Transform 自带了 平移、旋转、缩放
        public int id;
        public int count; // 3

        public void SetDead() {
            GameObject.Destroy(gameObject);
        }

        public void SetAlive() {
            // 变成活的样子
        }

        public void Tick(float dt) {
            // 如果是枯萎的, 需要慢慢复活
            // 很像红绿灯的变化: 枯 -> 活
        }

    }

}