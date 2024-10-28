using UnityEngine; // Mengimpor pustaka UnityEngine

public class Map : MonoBehaviour // Deklarasi kelas `Map` sebagai komponen peta
{
    private MeshRenderer meshRenderer; // Komponen `MeshRenderer` untuk mengatur material peta
    public float animationSpeed = 1f; // Kecepatan animasi scroll peta

    private void Awake() // Mengambil komponen `MeshRenderer` saat objek diinisialisasi
    {
        meshRenderer = GetComponent<MeshRenderer>();
    }

    private void Update() // Mengatur pergeseran tekstur peta untuk membuat efek animasi
    {
        meshRenderer.material.mainTextureOffset += new Vector2(animationSpeed * Time.deltaTime, 0);
    }
}
