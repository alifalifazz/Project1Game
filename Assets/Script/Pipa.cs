using UnityEngine;

public class Pipa : MonoBehaviour // Class "Pipa" untuk nge-spawn pipa-pipa baru di lokasi tertentu
{
   public GameObject prepipa; // Prefab pipa yang akan di-spawn (bisa diisi dari Unity Editor)
   public float spawnRate = 1f; // Waktu jeda tiap pipa baru muncul
   public float minHeight = -1f; // Batas minimum posisi pipa pas spawn
   public float maxHeight = 1f;  // Batas maksimum posisi pipa pas spawn

   private void OnEnable()
   {
     // Mulai proses spawn pipa berulang kali tiap "spawnRate" detik
     InvokeRepeating(nameof(Spawn), spawnRate, spawnRate);
   }

   private void OnDisable()
   {
     // Stop proses spawn kalau objeknya nggak aktif
     CancelInvoke(nameof(Spawn));
   }

   private void Spawn()
   {
     // Spawn buat objek pipa baru dari prefab di posisi objek ini
     GameObject pipa = Instantiate(prepipa, transform.position, Quaternion.identity);
     
     // Geser pipa ke atas atau ke bawah secara random di antara minHeight dan maxHeight
     pipa.transform.position += Vector3.up * Random.Range(minHeight, maxHeight);
   }
}
