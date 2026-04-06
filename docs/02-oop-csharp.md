# 🧱 OOP (Object-Oriented Programming) di C#

> Panduan lengkap memahami konsep OOP dari dasar hingga lanjutan dengan contoh kode C#.

---

## 🤔 Apa Itu OOP?

**Object-Oriented Programming (OOP)** adalah paradigma pemrograman yang mengorganisir kode berdasarkan **objek** — representasi benda nyata yang punya **data** (atribut) dan **perilaku** (method).

### Analogi Dunia Nyata:
```
Mobil (sebagai "Class" / Cetakan):
├── Atribut: merk, warna, kecepatan
└── Perilaku: nyalakan(), gas(), rem()

Mobil Budi (Object dari class Mobil):     Mobil Ani (Object lain):
├── merk = "Toyota"                        ├── merk = "Honda"
└── warna = "Merah"                        └── warna = "Putih"
```

---

## 4 Pilar OOP

| Pilar | Pengertian Singkat |
|-------|--------------------|
| **Enkapsulasi** | Menyembunyikan data internal, hanya expose yang perlu |
| **Abstraksi** | Menyembunyikan kompleksitas, tampilkan interface sederhana |
| **Inheritance** | Class anak mewarisi properti/method dari class induk |
| **Polimorfisme** | Satu interface bisa berperilaku berbeda-beda |

---

## 🏗️ 1. Class dan Object

```csharp
// Mendefinisikan CLASS
public class Mahasiswa
{
    // FIELDS (data internal, hindari akses langsung)
    private string _nim;
    private string _nama;

    // CONSTRUCTOR (dipanggil saat object dibuat dengan 'new')
    public Mahasiswa(string nim, string nama)
    {
        _nim  = nim;
        _nama = nama;
    }

    // PROPERTIES (akses terkontrol ke fields)
    public string Nim  => _nim;           // Read-only
    public string Nama
    {
        get => _nama;
        set => _nama = value;             // Read-write
    }

    // METHOD (perilaku/fungsi)
    public void Perkenalan()
    {
        Console.WriteLine($"Halo! Saya {_nama}, NIM {_nim}.");
    }
}

// Membuat OBJECT
var mhs1 = new Mahasiswa("12345", "Budi Santoso");
var mhs2 = new Mahasiswa("67890", "Ani Rahayu");

mhs1.Perkenalan();   // Halo! Saya Budi Santoso, NIM 12345.
mhs2.Perkenalan();   // Halo! Saya Ani Rahayu, NIM 67890.
```

---

## 🔒 2. Enkapsulasi

**Enkapsulasi** = lindungi data internal, kendalikan akses dari luar.

### Access Modifiers:

| Modifier | Bisa Diakses Dari |
|----------|------------------|
| `public` | Mana saja |
| `private` | Hanya dalam class yang sama |
| `protected` | Class yang sama dan turunannya |
| `internal` | Dalam satu project/assembly |

```csharp
public class BankAccount
{
    private decimal _saldo;    // Tidak bisa diakses langsung dari luar!

    public BankAccount(decimal saldoAwal) => _saldo = saldoAwal;

    public decimal Saldo => _saldo;   // Hanya bisa lihat, tidak bisa ubah

    public void Setor(decimal jumlah)
    {
        if (jumlah <= 0) throw new ArgumentException("Harus positif!");
        _saldo += jumlah;
    }

    public void Tarik(decimal jumlah)
    {
        if (jumlah > _saldo) throw new InvalidOperationException("Saldo kurang!");
        _saldo -= jumlah;
    }
}

var akun = new BankAccount(1_000_000);
akun.Setor(500_000);          // ✅ OK
// akun._saldo = 0;           // ❌ Error! Private
Console.WriteLine(akun.Saldo); // ✅ Read-only OK
```

---

## 🧬 3. Inheritance (Pewarisan)

**Inheritance** = class anak mewarisi dari class induk (hubungan "adalah sebuah" / is-a).

```csharp
// CLASS INDUK
public class Hewan
{
    public string Nama { get; set; }

    public Hewan(string nama) => Nama = nama;

    public virtual void BerSuara()    // virtual = bisa di-override
    {
        Console.WriteLine($"{Nama} mengeluarkan suara.");
    }

    public void Makan() => Console.WriteLine($"{Nama} sedang makan.");
}

// CLASS ANAK
public class Kucing : Hewan           // Kucing "adalah" Hewan
{
    public string Ras { get; set; }

    public Kucing(string nama, string ras) : base(nama)   // panggil constructor induk
        => Ras = ras;

    public override void BerSuara()   // override method induk
        => Console.WriteLine($"{Nama} berkata: Meow!");
}

public class Anjing : Hewan
{
    public Anjing(string nama) : base(nama) { }

    public override void BerSuara()
        => Console.WriteLine($"{Nama} berkata: Guk guk!");
}

// Penggunaan
var kucing = new Kucing("Mimi", "Persia");
kucing.BerSuara();    // Mimi berkata: Meow!
kucing.Makan();       // Mimi sedang makan. (warisan dari Hewan)
```

---

## 🎭 4. Polimorfisme

**Polimorfisme** = satu kode yang sama bisa berperilaku berbeda tergantung tipe object-nya.

```csharp
// List bertipe Hewan, isinya campur-campur
List<Hewan> daftarHewan = new()
{
    new Kucing("Mimi", "Persia"),
    new Anjing("Rex"),
    new Kucing("Luna", "Anggora")
};

// Satu baris kode, tapi tiap hewan bersuara berbeda!
foreach (var h in daftarHewan)
{
    h.BerSuara();
}
// Output:
// Mimi berkata: Meow!
// Rex berkata: Guk guk!
// Luna berkata: Meow!
```

---

## 🎨 5. Abstraksi

**Abstraksi** = sembunyikan kompleksitas, tampilkan interface yang sederhana.

### Abstract Class:
```csharp
public abstract class Bentuk          // Tidak bisa di-new langsung
{
    public abstract double HitungLuas();      // Harus diimplementasikan anak
    public abstract double HitungKeliling();  // Harus diimplementasikan anak

    public void Tampilkan()                   // Bisa dipakai langsung
        => Console.WriteLine($"Luas: {HitungLuas():F2}, Keliling: {HitungKeliling():F2}");
}

public class Lingkaran : Bentuk
{
    public double R { get; }
    public Lingkaran(double r) => R = r;

    public override double HitungLuas()      => Math.PI * R * R;
    public override double HitungKeliling()  => 2 * Math.PI * R;
}

public class Persegi : Bentuk
{
    public double Sisi { get; }
    public Persegi(double sisi) => Sisi = sisi;

    public override double HitungLuas()      => Sisi * Sisi;
    public override double HitungKeliling()  => 4 * Sisi;
}

// Penggunaan
new Lingkaran(7).Tampilkan();   // Luas: 153.94, Keliling: 43.98
new Persegi(5).Tampilkan();     // Luas: 25.00, Keliling: 20.00
```

---

## 🤝 Interface

**Interface** = kontrak "bisa apa" — mendefinisikan kemampuan yang harus dimiliki.

```csharp
public interface IBerenang  { void Berenang(); }
public interface ITerbang   { void Terbang(); }

// Class bisa implement BANYAK interface (berbeda dengan inheritance!)
public class Bebek : Hewan, IBerenang, ITerbang
{
    public Bebek(string nama) : base(nama) { }

    public override void BerSuara() => Console.WriteLine($"{Nama}: Kwak kwak!");
    public void Berenang() => Console.WriteLine($"{Nama} berenang");
    public void Terbang()  => Console.WriteLine($"{Nama} terbang");
}
```

### Abstract Class vs Interface:

| | Abstract Class | Interface |
|-|----------------|-----------|
| Dapat diinstansiasi | ❌ | ❌ |
| Punya implementasi | ✅ | ✅ (C# 8+) |
| Punya fields | ✅ | ❌ |
| Bisa warisi berapa | 1 saja | Banyak |
| Untuk hubungan | "adalah" | "bisa/mampu" |

---

## 🎁 Konsep Lanjutan

### Constructor Overloading
```csharp
public class Produk
{
    public string Nama  { get; }
    public decimal Harga { get; }
    public int Stok     { get; }

    public Produk(string nama) : this(nama, 0, 0) { }
    public Produk(string nama, decimal harga) : this(nama, harga, 0) { }
    public Produk(string nama, decimal harga, int stok)
    {
        Nama = nama; Harga = harga; Stok = stok;
    }
}
```

### Static Members
```csharp
public class Counter
{
    private static int _total = 0;   // Shared oleh semua object!
    public int Id { get; }

    public Counter() { _total++; Id = _total; }

    public static int GetTotal() => _total;  // Dipanggil dari class, bukan object
}

var c1 = new Counter();
var c2 = new Counter();
Console.WriteLine(Counter.GetTotal()); // 2
```

### Generics
```csharp
// Generic class — bisa dipakai untuk tipe apapun
public class Kotak<T>
{
    private T _isi;
    public Kotak(T isi) => _isi = isi;
    public T Buka() => _isi;
}

var kotakAngka  = new Kotak<int>(42);
var kotakString = new Kotak<string>("Hello");
```

### Record (C# 9+) — Data immutable
```csharp
public record Titik(double X, double Y);

var t1 = new Titik(3, 4);
var t2 = new Titik(3, 4);
Console.WriteLine(t1 == t2);     // True! (value equality)
var t3 = t1 with { X = 10 };    // Buat copy dengan X baru
```

---

## 📊 Ringkasan

| Konsep | Kata Kunci C# | Kegunaan |
|--------|--------------|---------|
| **Class** | `class` | Blueprint/cetakan object |
| **Object** | `new` | Instansi nyata dari class |
| **Enkapsulasi** | `private`, `public` | Lindungi data internal |
| **Inheritance** | `: BaseClass` | Warisi properti & method |
| **Polimorfisme** | `virtual`, `override` | Satu interface banyak perilaku |
| **Abstraksi** | `abstract` | Kontrak tanpa implementasi |
| **Interface** | `interface` | Kontrak kemampuan |
| **Generics** | `<T>` | Kode reusable untuk berbagai tipe |
