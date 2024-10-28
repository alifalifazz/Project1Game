using UnityEngine; // Biar bisa akses fitur-fitur Unity kayak GameObject dan lainnya

public class NewMonoBehaviourScript : MonoBehaviour // Kelas utama buat ngatur animasi dan gerakan objek
{
    private SpriteRenderer spriteRenderer; // Komponen buat ganti-ganti sprite di objek

    public Sprite[] sprites; // Array untuk menampung semua sprite buat animasi
    private int spriteIndex; // Indeks buat melacak sprite mana yang lagi dipakai
    private Vector3 moveDirection; // Arah gerakan objek
    public float gravity = -9.8f; // Nilai gravitasi biar objek "jatuh" ke bawah
    public float strength = 5f; // Kekuatan lompatan kalau tombol ditekan

    private void Awake() // Dipanggil sekali saat objek diinisialisasi
    {
        spriteRenderer = GetComponent<SpriteRenderer>(); // Ambil komponen SpriteRenderer dari objek
    }

    private void Start() // Dipanggil sekali waktu objek pertama kali aktif
    {
        InvokeRepeating(nameof(AnimateSprite), 0.15f, 0.15f); // Panggil AnimateSprite tiap 0.15 detik biar sprite-nya ganti-ganti
    }

    private void Update() // Dipanggil tiap frame buat ngatur input dan gerakan
    {
        if(Input.GetKeyDown(KeyCode.Space) || Input.GetMouseButtonDown(0)) // Cek kalau tombol Space atau mouse diklik
        {
            moveDirection = Vector3.up * strength; // Bikin objek lompat ke atas dengan kekuatan tertentu
        }

        if (Input.touchCount > 0) // Cek kalau ada sentuhan di layar (buat perangkat mobile)
        {
            Touch touch = Input.GetTouch(0); // Ambil data sentuhan pertama
            if (touch.phase == TouchPhase.Began) // Cek kalau sentuhan baru aja dimulai
            {
                moveDirection = Vector3.up * strength; // Bikin objek lompat ke atas
            }
        }

        moveDirection.y += gravity * Time.deltaTime; // Tambah efek gravitasi ke gerakan tiap frame
        transform.position += moveDirection * Time.deltaTime; // Update posisi objek berdasarkan moveDirection
    }

    private void AnimateSprite() // Ganti sprite buat animasi biar ada efek gerak
    {
        spriteIndex++; // Geser ke sprite berikutnya
        if (spriteIndex >= sprites.Length) // Kalau udah di akhir array, reset ke sprite pertama
        {
            spriteIndex = 0;
        }
        spriteRenderer.sprite = sprites[spriteIndex]; // Update sprite di objek jadi sprite yang sekarang
    }
}
