
using System;
using System.Collections.Generic;

// KELAS INDUK
class Item
{
    public string Judul { get; set; }
    public int Tahun { get; set; }

    public Item(string judul, int tahun)
    {
        Judul = judul;   
        Tahun = tahun;
    }

    // Method yang dapat dioverride oleh subclass
    public virtual void Deskripsi()
    {
        Console.WriteLine($"Item: {Judul}, Tahun: {Tahun}");
    }

    // Menampilkan informasi dasar item
    public virtual void InfoItem()
    {
        Console.WriteLine($"Judul: {Judul}");
        Console.WriteLine($"Tahun: {Tahun}");
    }
}

// KELAS BUKU MEWARISI ITEM
class Buku : Item
{
    public string Penulis { get; set; }

    public Buku(string judul, int tahun, string penulis)
        : base(judul, tahun)
    {
        Penulis = penulis;
    }

    public void CekPenulis()
    {
        Console.WriteLine($"Penulis buku: {Penulis}");
    }

    public override void Deskripsi()
    {
        Console.WriteLine(
            $"Buku: {Judul}, Tahun: {Tahun}, Penulis: {Penulis}");
    }

    public override void InfoItem()
    {
        base.InfoItem();
        Console.WriteLine($"Penulis: {Penulis}");
    }
}

// KELAS MAJALAH MEWARISI ITEM
class Majalah : Item
{
    public int Edisi { get; set; }

    public Majalah(string judul, int tahun, int edisi)
        : base(judul, tahun)
    {
        Edisi = edisi;
    }

    public void InfoEdisi()
    {
        Console.WriteLine($"Edisi majalah: {Edisi}");
    }

    public override void Deskripsi()
    {
        Console.WriteLine(
            $"Majalah: {Judul}, Tahun: {Tahun}, Edisi: {Edisi}");
    }

    public override void InfoItem()
    {
        base.InfoItem();
        Console.WriteLine($"Edisi: {Edisi}");
    }
}

// KELAS NOVEL MEWARISI BUKU
class Novel : Buku
{
    public Novel(string judul, int tahun, string penulis)
        : base(judul, tahun, penulis)
    {
    }

    public void BacaSinopsis()
    {
        Console.WriteLine(
            $"Sinopsis novel {Judul}: Kisah petualangan dan kehidupan tokoh utama.");
    }

    public override void Deskripsi()
    {
        Console.WriteLine(
            $"Novel: {Judul}, Tahun: {Tahun}, Penulis: {Penulis}");
    }
}

// KELAS KOMIK MEWARISI BUKU
class Komik : Buku
{
    public Komik(string judul, int tahun, string penulis)
        : base(judul, tahun, penulis)
    {
    }

    public void TampilkanIlustrasi()
    {
        Console.WriteLine(
            $"Ilustrasi komik {Judul}: [Gambar ilustrasi komik]");
    }

    public override void Deskripsi()
    {
        Console.WriteLine(
            $"Komik: {Judul}, Tahun: {Tahun}, Penulis: {Penulis}");
    }
}

// KELAS MAJALAH ANAK MEWARISI MAJALAH
class MajalahAnak : Majalah
{
    public MajalahAnak(string judul, int tahun, int edisi)
        : base(judul, tahun, edisi)
    {
    }

    public void KategoriAnak()
    {
        Console.WriteLine(
            $"Kategori {Judul}: Pendidikan dan hiburan anak.");
    }

    public override void Deskripsi()
    {
        Console.WriteLine(
            $"Majalah Anak: {Judul}, Tahun: {Tahun}, Edisi: {Edisi}");
    }
}

// KELAS MAJALAH TEKNOLOGI MEWARISI MAJALAH
class MajalahTeknologi : Majalah
{
    public MajalahTeknologi(string judul, int tahun, int edisi)
        : base(judul, tahun, edisi)
    {
    }

    public void TopikTeknologi()
    {
        Console.WriteLine(
            $"Topik {Judul}: Komputer, AI, dan perkembangan teknologi.");
    }

    public override void Deskripsi()
    {
        Console.WriteLine(
            $"Majalah Teknologi: {Judul}, Tahun: {Tahun}, Edisi: {Edisi}");
    }
}

// KELAS PERPUSTAKAAN
class Perpustakaan
{
    private List<Item> koleksi = new List<Item>();

    public void TambahItem(Item item)
    {
        koleksi.Add(item);
        Console.WriteLine($"Item '{item.Judul}' berhasil ditambahkan.");
    }

    public void DaftarItem()
    {
        Console.WriteLine("\n=== DAFTAR KOLEKSI PERPUSTAKAAN ===");

        foreach (Item item in koleksi)
        {
            // Polymorphism: Deskripsi menyesuaikan tipe objek
            item.Deskripsi();
            Console.WriteLine("------------------------------");
        }
    }
}

// PROGRAM UTAMA
class Program
{
    static void Main(string[] args)
    {
        // 1. Membuat objek perpustakaan
        Perpustakaan perpustakaan = new Perpustakaan();

        // 2. Membuat beberapa objek item
        Novel novel = new Novel(
            "Laskar Pelangi", 2005, "Andrea Hirata");

        Komik komik = new Komik(
            "Petualangan Si Juki", 2017, "Faza Meonk");

        Majalah majalah = new Majalah(
            "Bintang Pustaka", 2024, 12);

        MajalahAnak majalahAnak = new MajalahAnak(
            "Anak Cerdas", 2025, 5);

        MajalahTeknologi majalahTeknologi =
            new MajalahTeknologi("Tekno Digital", 2026, 8);

        // 3. Menambahkan item ke perpustakaan
        perpustakaan.TambahItem(novel);
        perpustakaan.TambahItem(komik);
        perpustakaan.TambahItem(majalah);
        perpustakaan.TambahItem(majalahAnak);
        perpustakaan.TambahItem(majalahTeknologi);

        // 4. Menampilkan semua data
        perpustakaan.DaftarItem();

        // 5. Demonstrasi polymorphism
        Console.WriteLine("\n=== DEMONSTRASI POLYMORPHISM ===");

        Item item1 = novel;
        Item item2 = komik;
        Item item3 = majalah;

        item1.Deskripsi();
        item2.Deskripsi();
        item3.Deskripsi();

        // 6. Memanggil method khusus Novel
        Console.WriteLine("\n=== METHOD KHUSUS NOVEL ===");
        novel.BacaSinopsis();
        novel.CekPenulis();

        // 7. Memanggil method khusus Komik
        Console.WriteLine("\n=== METHOD KHUSUS KOMIK ===");
        komik.TampilkanIlustrasi();

        // 8. Memanggil method khusus Majalah
        Console.WriteLine("\n=== METHOD KHUSUS MAJALAH ===");
        majalah.InfoEdisi();

        // 9. Memanggil method khusus Majalah Anak
        Console.WriteLine("\n=== METHOD MAJALAH ANAK ===");
        majalahAnak.KategoriAnak();

        // 10. Memanggil method khusus Majalah Teknologi
        Console.WriteLine("\n=== METHOD MAJALAH TEKNOLOGI ===");
        majalahTeknologi.TopikTeknologi();

        // 11. Menampilkan informasi lengkap Novel
        Console.WriteLine("\n=== INFORMASI LENGKAP NOVEL ===");
        novel.InfoItem();

        Console.WriteLine("\nProgram selesai dijalankan.");
        Console.ReadKey();
    }
}
