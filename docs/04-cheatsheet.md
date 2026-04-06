# ⚡ C# & .NET Cheatsheet

> Referensi cepat sintaks C# yang paling sering dipakai. Simpan halaman ini!

---

## 🔤 Tipe Data

```csharp
// Bilangan bulat
byte   b = 255;            // 0 – 255
int    i = 2_147_483_647;  // -2 miliar – 2 miliar
long   l = 9_999_999L;     // Sangat besar

// Bilangan desimal
float   f = 3.14f;         // ~7 digit presisi
double  d = 3.14159265;    // ~15 digit presisi
decimal m = 99.99m;        // Presisi tinggi (uang)

// Lain-lain
bool    benar  = true;
char    huruf  = 'A';
string  teks   = "Hello";
object  apasaja = 42;

// Nullable
int?    mungkinNull = null;
string? bolehNull   = null;

// Tipe inferensi (compiler tentukan tipe)
var angka = 10;        // int
var nama  = "Budi";    // string
var list  = new List<int>();
```

---

## 📦 Koleksi

```csharp
// Array — ukuran tetap
int[]    arr  = { 1, 2, 3 };
string[] nama = new string[3];

// List — ukuran dinamis
var list = new List<string> { "A", "B" };
list.Add("C");
list.Remove("A");
list.AddRange(new[] { "D", "E" });
int idx = list.IndexOf("B");
bool ada = list.Contains("C");
list.Sort();
list.Clear();

// Dictionary — key => value
var dict = new Dictionary<string, int>
{
    ["Apel"]   = 5,
    ["Mangga"] = 3
};
dict["Jeruk"] = 10;
bool hasKey = dict.ContainsKey("Apel");
dict.TryGetValue("Apel", out int val);

// HashSet — unik, tidak terurut
var set = new HashSet<int> { 1, 2, 3, 2, 1 };
// Hasilnya: { 1, 2, 3 }

// Queue — FIFO
var q = new Queue<string>();
q.Enqueue("Pertama");
q.Enqueue("Kedua");
string depan = q.Dequeue(); // Ambil dari depan

// Stack — LIFO
var stack = new Stack<int>();
stack.Push(1);
stack.Push(2);
int atas = stack.Pop(); // Ambil dari atas
```

---

## 💬 String

```csharp
string s = "Hello, World!";

// Panjang
int len = s.Length;                  // 13

// Casing
string upper = s.ToUpper();          // "HELLO, WORLD!"
string lower = s.ToLower();          // "hello, world!"

// Cari
bool ada = s.Contains("World");      // true
int idx  = s.IndexOf("World");       // 7
bool awal = s.StartsWith("Hello");   // true
bool akhir = s.EndsWith("!");        // true

// Potong & ubah
string trim   = "  spasi  ".Trim();          // "spasi"
string ganti  = s.Replace("World", "C#");    // "Hello, C#!"
string sub    = s.Substring(7, 5);           // "World"
string[] bagian = s.Split(", ");             // ["Hello", "World!"]

// Gabung
string join = string.Join(" - ", bagian);    // "Hello - World!"

// Format
string f1 = $"Nama: {nama}, Umur: {umur}";  // String interpolation
string f2 = string.Format("Nilai: {0:F2}", 3.14159); // "Nilai: 3.14"

// Multiline
string multiline = """
    Baris pertama
    Baris kedua
    """;  // Raw string literal (C# 11+)

// StringBuilder (efisien untuk banyak concatenation)
var sb = new System.Text.StringBuilder();
sb.Append("Hello");
sb.Append(", ");
sb.AppendLine("World!");
string result = sb.ToString();
```

---

## 🔀 Kontrol Alur

```csharp
// If-else
if (x > 0)      { /* ... */ }
else if (x < 0) { /* ... */ }
else             { /* ... */ }

// Ternary
string status = x > 0 ? "Positif" : "Non-positif";

// Switch statement
switch (hari)
{
    case "Senin":
    case "Selasa":
        Console.WriteLine("Awal minggu");
        break;
    case "Jumat":
        Console.WriteLine("TGIF!");
        break;
    default:
        Console.WriteLine("Hari lain");
        break;
}

// Switch expression (modern)
string kategori = nilai switch
{
    >= 90        => "A",
    >= 80        => "B",
    >= 70        => "C",
    _            => "D"   // default
};

// Pattern matching
object obj = "Hello";
if (obj is string s && s.Length > 3)
    Console.WriteLine(s);

// Null check
string? nama = GetNama();
if (nama is null)       { /* ... */ }
if (nama is not null)   { /* ... */ }
```

---

## 🔁 Perulangan (Loop)

```csharp
// For
for (int i = 0; i < 10; i++)
    Console.WriteLine(i);

// While
int i = 0;
while (i < 10) { Console.WriteLine(i); i++; }

// Do-while (minimal 1x jalan)
int i = 0;
do { Console.WriteLine(i); i++; } while (i < 10);

// Foreach
foreach (var item in koleksi)
    Console.WriteLine(item);

// Loop kontrol
break;      // Keluar dari loop
continue;   // Skip ke iterasi berikutnya

// For dengan index di foreach (C# 7.2+)
foreach (var (item, index) in koleksi.Select((x, i) => (x, i)))
    Console.WriteLine($"[{index}] {item}");
```

---

## 🧮 LINQ (Language Integrated Query)

```csharp
var angka = new List<int> { 1, 2, 3, 4, 5, 6, 7, 8, 9, 10 };

// Filter
var genap = angka.Where(x => x % 2 == 0);              // 2,4,6,8,10

// Transformasi
var kuadrat = angka.Select(x => x * x);                 // 1,4,9,16,...

// Filter + Transformasi
var hasil = angka
    .Where(x => x > 5)
    .Select(x => x * 2)
    .ToList();                                           // 12,14,16,18,20

// Agregasi
int total = angka.Sum();                                 // 55
int maks  = angka.Max();                                 // 10
int min   = angka.Min();                                 // 1
double avg = angka.Average();                            // 5.5
int count = angka.Count();                               // 10
int filteredCount = angka.Count(x => x > 5);            // 5

// Cari satu element
int pertama = angka.First();                             // 1
int? pertamaOrNull = angka.FirstOrDefault(x => x > 99); // null
bool ada = angka.Any(x => x > 9);                       // true
bool semua = angka.All(x => x > 0);                     // true

// Urutkan
var urut    = angka.OrderBy(x => x);
var urutDes = angka.OrderByDescending(x => x);

// Kelompokkan
var grup = angka
    .GroupBy(x => x % 2 == 0 ? "Genap" : "Ganjil")
    .Select(g => new { Tipe = g.Key, Items = g.ToList() });

// Gabung dua list (join)
var orang = new[] { new { Id = 1, Nama = "Budi" } };
var nilai = new[] { new { OrangId = 1, Skor = 90 } };
var join = orang.Join(nilai,
    o => o.Id, n => n.OrangId,
    (o, n) => new { o.Nama, n.Skor });

// Distinct, Take, Skip
var unik = angka.Distinct();
var tiga = angka.Take(3);           // 3 pertama: 1,2,3
var sisanya = angka.Skip(3);        // Lewati 3 pertama
```

---

## ⚡ Async/Await

```csharp
// Method async
public async Task DoSomethingAsync()
{
    await Task.Delay(1000);
    Console.WriteLine("Selesai setelah 1 detik");
}

// Method async dengan return value
public async Task<string> GetDataAsync()
{
    await Task.Delay(500);
    return "Data berhasil";
}

// Memanggil method async
await DoSomethingAsync();
string data = await GetDataAsync();

// Jalankan banyak task SERENTAK
var t1 = GetDataAsync();
var t2 = GetDataAsync();
await Task.WhenAll(t1, t2);

// Jalankan banyak task, ambil yang selesai pertama
var selesaiPertama = await Task.WhenAny(t1, t2);

// CancellationToken
public async Task LongTaskAsync(CancellationToken ct)
{
    for (int i = 0; i < 100; i++)
    {
        ct.ThrowIfCancellationRequested();
        await Task.Delay(100, ct);
    }
}
```

---

## 🏗️ OOP Cepat

```csharp
// Class lengkap
public class Produk
{
    // Auto-property
    public int Id { get; set; }
    public string Nama { get; set; } = string.Empty;
    public decimal Harga { get; private set; }

    // Constructor
    public Produk(int id, string nama, decimal harga)
        => (Id, Nama, Harga) = (id, nama, harga);

    // Method
    public override string ToString() => $"[{Id}] {Nama} - Rp{Harga:N0}";
}

// Record (immutable, value equality)
public record Titik(double X, double Y);
var t = new Titik(1, 2);
var t2 = t with { X = 10 };   // Copy dengan X baru

// Interface
public interface IRepository<T>
{
    Task<T?> GetByIdAsync(int id);
    Task<IEnumerable<T>> GetAllAsync();
    Task SaveAsync(T entity);
    Task DeleteAsync(int id);
}

// Generics
public class Result<T>
{
    public bool IsSuccess { get; }
    public T? Value { get; }
    public string? Error { get; }

    private Result(T value) { IsSuccess = true; Value = value; }
    private Result(string error) { IsSuccess = false; Error = error; }

    public static Result<T> Ok(T value)    => new(value);
    public static Result<T> Fail(string e) => new(e);
}
```

---

## 🛡️ Null Safety

```csharp
string? nama = GetNama();            // Nullable string

string a = nama ?? "Default";        // Null-coalescing
int?   b = nama?.Length;             // Null-conditional → null jika null
nama ??= "Default";                  // Assign hanya kalau null
string c = nama!;                    // Null-forgiving (hati-hati!)

// ArgumentNullException
ArgumentNullException.ThrowIfNull(nama);
ArgumentException.ThrowIfNullOrEmpty(nama);
ArgumentException.ThrowIfNullOrWhiteSpace(nama);
```

---

## ⚠️ Exception

```csharp
// Throw
throw new ArgumentException("Pesan error", nameof(paramName));
throw new ArgumentNullException(nameof(param));
throw new InvalidOperationException("Operasi tidak valid");
throw new NotImplementedException();

// Try-catch-finally
try
{
    int hasil = 10 / 0;
}
catch (DivideByZeroException ex)
{
    Console.WriteLine($"Dibagi nol: {ex.Message}");
}
catch (Exception ex) when (ex.Message.Contains("khusus"))
{
    // when = exception filter
}
finally
{
    // Selalu jalan, meski ada exception
    Console.WriteLine("Finally always runs");
}

// Custom exception
public class DomainException : Exception
{
    public string Code { get; }
    public DomainException(string code, string message)
        : base(message) => Code = code;
}
```

---

## 🔧 .NET CLI — Perintah Wajib

```bash
# Project management
dotnet new console -n NamaApp     # Buat console app baru
dotnet new webapi  -n NamaApi     # Buat Web API baru
dotnet new classlib -n NamaLib    # Buat class library

# Build & Run
dotnet run                         # Compile + jalankan
dotnet build                       # Compile saja
dotnet watch run                   # Hot reload (auto-restart saat save)

# Testing
dotnet test                        # Jalankan semua test
dotnet test --filter "NamaTest"    # Jalankan test spesifik

# Package (NuGet)
dotnet add package NamaPaket       # Install package
dotnet remove package NamaPaket    # Hapus package
dotnet list package                # Lihat daftar package
dotnet restore                     # Restore semua dependencies

# Publish
dotnet publish -c Release          # Build untuk produksi
dotnet publish -r win-x64 --self-contained  # Termasuk runtime
```

---

## 📐 Pola yang Sering Dipakai

```csharp
// ── REPOSITORY PATTERN ──────────────────────────
public interface IUserRepository
{
    Task<User?> GetByIdAsync(int id);
    Task SaveAsync(User user);
}

// ── DEPENDENCY INJECTION ────────────────────────
// Di Program.cs / Startup:
builder.Services.AddScoped<IUserRepository, UserRepository>();
builder.Services.AddSingleton<ICacheService, MemoryCacheService>();

// ── BUILDER PATTERN ─────────────────────────────
var options = new QueryOptions.Builder()
    .WithPage(1)
    .WithPageSize(10)
    .WithSort("Nama")
    .Build();

// ── FACTORY PATTERN ─────────────────────────────
public static class ShapeFactory
{
    public static Bentuk Create(string tipe) => tipe switch
    {
        "lingkaran" => new Lingkaran(),
        "persegi"   => new Persegi(),
        _           => throw new ArgumentException($"Tipe {tipe} tidak dikenal")
    };
}
```

---

## 🔑 Fitur Modern C# (8–12)

```csharp
// C# 8: Switch expression
string hasil = x switch { > 0 => "Positif", < 0 => "Negatif", _ => "Nol" };

// C# 8: Using declaration
using var stream = File.OpenRead("file.txt"); // Dispose otomatis di akhir scope

// C# 9: Record
public record Person(string Nama, int Umur);

// C# 9: Target-typed new
List<string> list = new();  // Tidak perlu tulis new List<string>()

// C# 10: Global using
global using System.Collections.Generic; // Di satu file, berlaku di seluruh project

// C# 11: Raw string literals
string json = """
    {
        "nama": "Budi",
        "umur": 25
    }
    """;

// C# 12: Primary constructor
public class Service(ILogger<Service> logger, IRepository repo)
{
    // logger dan repo langsung bisa dipakai sebagai field
    public void Do() => logger.LogInformation("Doing...");
}
```

---

## 📋 Keyboard Shortcut VS Code (C#)

| Shortcut | Aksi |
|----------|------|
| `F5` | Run & Debug |
| `Ctrl+F5` | Run tanpa debug |
| `F9` | Toggle breakpoint |
| `F12` atau `Ctrl+click` | Go to definition |
| `Shift+F12` | Find all references |
| `Ctrl+.` | Quick fix / suggestions |
| `Ctrl+Shift+P` | Command palette |
| `Ctrl+Space` | IntelliSense |
| `Alt+Shift+F` | Format document |
| `Ctrl+/` | Toggle komentar |
