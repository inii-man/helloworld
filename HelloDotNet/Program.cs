// ============================================================
//   C# SYNTAX PLAYGROUND — Tinggal dotnet run!
// ============================================================

Header("VARIABEL & TIPE DATA");
{
    int umur = 25;
    double tinggi = 175.5;
    bool aktif = true;
    string nama = "Budi";
    char inisial = 'B';
    decimal gaji = 5_000_000m;

    Console.WriteLine($"Nama    : {nama} ({inisial})");
    Console.WriteLine($"Umur    : {umur} tahun");
    Console.WriteLine($"Tinggi  : {tinggi} cm");
    Console.WriteLine($"Aktif   : {aktif}");
    Console.WriteLine($"Gaji    : Rp{gaji:N0}");

    // var — tipe ditebak otomatis oleh compiler
    var kota = "Jakarta";
    var tahun = 2024;
    Console.WriteLine($"Kota    : {kota}, Tahun: {tahun}");
}

// ─────────────────────────────────────────────
Header("IF - ELSE IF - ELSE");
{
    int nilai = 85;

    if (nilai >= 90)
        Console.WriteLine($"Nilai {nilai} → Grade A (Sangat Baik)");
    else if (nilai >= 80)
        Console.WriteLine($"Nilai {nilai} → Grade B (Baik)");
    else if (nilai >= 70)
        Console.WriteLine($"Nilai {nilai} → Grade C (Cukup)");
    else
        Console.WriteLine($"Nilai {nilai} → Grade D (Kurang)");

    // Ternary operator
    bool lulus = nilai >= 70;
    Console.WriteLine($"Status  : {(lulus ? "LULUS ✓" : "TIDAK LULUS ✗")}");
}

// ─────────────────────────────────────────────
Header("SWITCH STATEMENT");
{
    string hari = "Rabu";

    switch (hari)
    {
        case "Senin":
        case "Selasa":
        case "Rabu":
        case "Kamis":
        case "Jumat":
            Console.WriteLine($"{hari} → Hari kerja 💼");
            break;
        case "Sabtu":
        case "Minggu":
            Console.WriteLine($"{hari} → Akhir pekan 🎉");
            break;
        default:
            Console.WriteLine($"{hari} → Tidak dikenal");
            break;
    }
}

// ─────────────────────────────────────────────
Header("SWITCH EXPRESSION (Modern C#)");
{
    int bulan = 4;

    string namaBulan = bulan switch
    {
        1  => "Januari",
        2  => "Februari",
        3  => "Maret",
        4  => "April",
        5  => "Mei",
        6  => "Juni",
        7  => "Juli",
        8  => "Agustus",
        9  => "September",
        10 => "Oktober",
        11 => "November",
        12 => "Desember",
        _  => "Bulan tidak valid"
    };

    int musim = bulan switch
    {
        3 or 4 or 5  => 1,
        6 or 7 or 8  => 2,
        9 or 10 or 11 => 3,
        _             => 4
    };

    string namaMusim = musim switch { 1 => "Semi", 2 => "Panas", 3 => "Gugur", _ => "Dingin" };

    Console.WriteLine($"Bulan ke-{bulan} = {namaBulan}");
    Console.WriteLine($"Musim           = {namaMusim}");
}

// ─────────────────────────────────────────────
Header("FOR LOOP");
{
    Console.Write("Angka 1-5 : ");
    for (int i = 1; i <= 5; i++)
        Console.Write($"{i} ");
    Console.WriteLine();

    Console.Write("Genap     : ");
    for (int i = 2; i <= 10; i += 2)
        Console.Write($"{i} ");
    Console.WriteLine();

    Console.Write("Mundur    : ");
    for (int i = 5; i >= 1; i--)
        Console.Write($"{i} ");
    Console.WriteLine();
}

// ─────────────────────────────────────────────
Header("WHILE & DO-WHILE");
{
    // While — cek kondisi DULU
    int n = 1;
    Console.Write("While (1-5)   : ");
    while (n <= 5)
    {
        Console.Write($"{n} ");
        n++;
    }
    Console.WriteLine();

    // Do-While — jalan DULU baru cek kondisi (minimal 1x)
    int m = 1;
    Console.Write("Do-While (1-5): ");
    do
    {
        Console.Write($"{m} ");
        m++;
    } while (m <= 5);
    Console.WriteLine();
}

// ─────────────────────────────────────────────
Header("FOREACH");
{
    string[] buah = { "Apel", "Mangga", "Jeruk", "Anggur", "Durian" };

    Console.WriteLine("Daftar buah:");
    foreach (string b in buah)
        Console.WriteLine($"  → {b}");

    // Foreach dengan index (pakai LINQ)
    Console.WriteLine("Dengan nomor urut:");
    foreach (var (item, idx) in buah.Select((x, i) => (x, i + 1)))
        Console.WriteLine($"  {idx}. {item}");
}

// ─────────────────────────────────────────────
Header("BREAK & CONTINUE");
{
    Console.Write("Break (berhenti di 4)  : ");
    for (int i = 1; i <= 10; i++)
    {
        if (i == 5) break;          // Keluar loop saat i == 5
        Console.Write($"{i} ");
    }
    Console.WriteLine();

    Console.Write("Continue (skip ganjil) : ");
    for (int i = 1; i <= 10; i++)
    {
        if (i % 2 != 0) continue;  // Lewati angka ganjil
        Console.Write($"{i} ");
    }
    Console.WriteLine();
}

// ─────────────────────────────────────────────
Header("ARRAY");
{
    int[] angka = { 10, 30, 50, 20, 40 };

    Console.WriteLine($"Array asli : [{string.Join(", ", angka)}]");
    Console.WriteLine($"Panjang    : {angka.Length}");
    Console.WriteLine($"Elemen [2] : {angka[2]}");

    Array.Sort(angka);
    Console.WriteLine($"Setelah sort : [{string.Join(", ", angka)}]");

    Array.Reverse(angka);
    Console.WriteLine($"Setelah reverse : [{string.Join(", ", angka)}]");

    // 2D Array
    int[,] matriks = { { 1, 2, 3 }, { 4, 5, 6 } };
    Console.WriteLine($"Matriks [1,2] = {matriks[1, 2]}");
}

// ─────────────────────────────────────────────
Header("LIST");
{
    var kota = new List<string> { "Jakarta", "Bandung", "Surabaya" };

    kota.Add("Yogyakarta");
    kota.Insert(1, "Medan");       // Sisipkan di index 1

    Console.WriteLine($"Jumlah kota : {kota.Count}");
    Console.WriteLine($"Isi list    : {string.Join(", ", kota)}");

    kota.Remove("Medan");
    Console.WriteLine($"Setelah remove Medan : {string.Join(", ", kota)}");

    bool ada = kota.Contains("Bandung");
    Console.WriteLine($"Ada Bandung? : {ada}");

    kota.Sort();
    Console.WriteLine($"Setelah sort : {string.Join(", ", kota)}");
}

// ─────────────────────────────────────────────
Header("DICTIONARY");
{
    var nilai = new Dictionary<string, int>
    {
        ["Budi"]  = 85,
        ["Ani"]   = 92,
        ["Citra"] = 78
    };

    nilai["Deni"] = 88;   // Tambah entry baru

    Console.WriteLine("Daftar nilai:");
    foreach (var entry in nilai)
        Console.WriteLine($"  {entry.Key,-8}: {entry.Value}");

    Console.WriteLine($"Nilai Ani : {nilai["Ani"]}");
    Console.WriteLine($"Ada 'Budi'? : {nilai.ContainsKey("Budi")}");

    if (nilai.TryGetValue("Eko", out int nilaiEko))
        Console.WriteLine($"Nilai Eko: {nilaiEko}");
    else
        Console.WriteLine("Eko tidak ada di dictionary");
}

// ─────────────────────────────────────────────
Header("STRING OPERATIONS");
{
    string kalimat = "  Halo, Selamat Datang di C#!  ";

    Console.WriteLine($"Original    : '{kalimat}'");
    Console.WriteLine($"Trim        : '{kalimat.Trim()}'");
    Console.WriteLine($"Upper       : '{kalimat.Trim().ToUpper()}'");
    Console.WriteLine($"Lower       : '{kalimat.Trim().ToLower()}'");
    Console.WriteLine($"Length      : {kalimat.Trim().Length}");
    Console.WriteLine($"Contains '#': {kalimat.Contains('#')}");
    Console.WriteLine($"Replace     : '{kalimat.Trim().Replace("Halo", "Hi")}'");

    string[] kata = kalimat.Trim().Split(' ');
    Console.WriteLine($"Split count : {kata.Length} kata");
    Console.WriteLine($"Join back   : '{string.Join("-", kata)}'");

    // String interpolation & format
    double pi = Math.PI;
    Console.WriteLine($"PI            : {pi}");
    Console.WriteLine($"PI (2 desimal): {pi:F2}");
    Console.WriteLine($"Uang          : {5_750_000:C0}");   // Format mata uang
}

// ─────────────────────────────────────────────
Header("METHOD / FUNGSI");
{
    // Panggil berbagai jenis method
    Console.WriteLine($"Luas lingkaran (r=7)  : {HitungLuasLingkaran(7):F2}");
    Console.WriteLine($"Faktorial (5)         : {Faktorial(5)}");
    Console.WriteLine($"Genap? (8)            : {AdaElah(8)}");
    Console.WriteLine($"Max dari 3 angka      : {Maks(10, 35, 22)}");

    string hasil = Sapa("Budi", gelarPenting: true);
    Console.WriteLine(hasil);
}

// ─────────────────────────────────────────────
Header("NULL SAFETY");
{
    string? nama = null;

    // Null-coalescing: gunakan default jika null
    string tampil = nama ?? "Anonymous";
    Console.WriteLine($"Nama : {tampil}");

    // Null-conditional: tidak crash meski null
    int? panjang = nama?.Length;
    Console.WriteLine($"Panjang nama : {panjang?.ToString() ?? "null"}");

    // Null-coalescing assignment
    nama ??= "Default User";
    Console.WriteLine($"Setelah ??=  : {nama}");
}

// ─────────────────────────────────────────────
Header("TRY - CATCH - FINALLY");
{
    // Contoh: pembagian nol
    try
    {
        int a = 10;
        int b = 0;
        Console.WriteLine($"10 / 2 = {10 / 2}");   // OK
        Console.WriteLine($"10 / 0 = {a / b}");     // Exception!
    }
    catch (DivideByZeroException ex)
    {
        Console.WriteLine($"[ERROR] Dibagi nol! {ex.Message}");
    }
    finally
    {
        Console.WriteLine("[FINALLY] Blok ini SELALU jalan.");
    }

    // Contoh: parsing
    try
    {
        int angka = int.Parse("bukan angka");
    }
    catch (FormatException)
    {
        Console.WriteLine("[ERROR] Format angka tidak valid!");
    }

    // Cara aman parsing (tanpa exception)
    bool berhasil = int.TryParse("42", out int hasil);
    Console.WriteLine($"TryParse '42'     : {berhasil} → {hasil}");

    berhasil = int.TryParse("abc", out int gagal);
    Console.WriteLine($"TryParse 'abc'    : {berhasil} → {gagal}");
}

// ─────────────────────────────────────────────
Header("LINQ DASAR");
{
    var angka = new List<int> { 3, 7, 1, 9, 4, 6, 2, 8, 5, 10 };

    var genap   = angka.Where(x => x % 2 == 0).OrderBy(x => x).ToList();
    var kuadrat = angka.Select(x => x * x).ToList();
    var besar   = angka.Where(x => x > 5).ToList();

    Console.WriteLine($"Semua    : [{string.Join(", ", angka)}]");
    Console.WriteLine($"Genap    : [{string.Join(", ", genap)}]");
    Console.WriteLine($"> 5      : [{string.Join(", ", besar)}]");
    Console.WriteLine($"Kuadrat  : [{string.Join(", ", kuadrat)}]");
    Console.WriteLine($"Sum      : {angka.Sum()}");
    Console.WriteLine($"Max/Min  : {angka.Max()} / {angka.Min()}");
    Console.WriteLine($"Average  : {angka.Average()}");
    Console.WriteLine($"Ada > 9? : {angka.Any(x => x > 9)}");
    Console.WriteLine($"Semua>0? : {angka.All(x => x > 0)}");
}

// ─────────────────────────────────────────────
Console.WriteLine();
Console.WriteLine("════════════════════════════════════════════");
Console.WriteLine("  🎉 Selesai! Semua syntax berhasil dijalankan.");
Console.WriteLine("════════════════════════════════════════════");
Console.WriteLine();

// ============================================================
//   DEFINISI METHOD (dipakai di atas)
// ============================================================

static double HitungLuasLingkaran(double r)
    => Math.PI * r * r;

static long Faktorial(int n)
    => n <= 1 ? 1 : n * Faktorial(n - 1);

static bool AdaElah(int angka)
    => angka % 2 == 0;

static int Maks(int a, int b, int c)
{
    int tempMax = a > b ? a : b;
    return tempMax > c ? tempMax : c;
}

static string Sapa(string nama, bool gelarPenting = false)
{
    string gelar = gelarPenting ? "Yang Terhormat " : "";
    return $"Selamat datang, {gelar}{nama}!";
}

// Helper: cetak header section
static void Header(string judul)
{
    Console.WriteLine();
    Console.WriteLine($"┌─ {judul} {'─' + new string('─', Math.Max(0, 44 - judul.Length))}");
}