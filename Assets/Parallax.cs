using UnityEngine;

public class Parallax : MonoBehaviour // `Parallax` untuk bikin efek gerakan latar belakang
{
    private MeshRenderer meshRenderer; // `MeshRenderer` buat ngatur tampilan material di background
    public float animationSpeed = 1f; // Kecepatan animasi buat efek paralaks

    private void Awake() // Dipanggil sekali pas objek baru diinisialisasi, ambil `MeshRenderer`
    {
        meshRenderer = GetComponent<MeshRenderer>();
    }

    private void Update() // Dipanggil tiap frame, update posisi tekstur biar ada efek gerak
    {
        meshRenderer.material.mainTextureOffset += new Vector2(animationSpeed * Time.deltaTime, 0); // Bikin tekstur background ky bergerak terus
    }
}
