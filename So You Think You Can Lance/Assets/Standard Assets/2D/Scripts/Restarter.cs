using UnityEngine;

namespace UnitySampleAssets._2D
{
    public class Restarter : MonoBehaviour
    {
        private PlayerDataKeeper data; 

        void Start()
        {
            data = GameObject.Find("LevelManager").GetComponent<PlayerDataKeeper>();
        }

        private void OnTriggerEnter2D(Collider2D other)
        {
            if (other.tag == "Player")
                data.resetCoins();
                Application.LoadLevel(Application.loadedLevelName);
        }
    }
}