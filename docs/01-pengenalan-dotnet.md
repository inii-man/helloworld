# 🚀 Pengenalan .NET — Dari Awal

> Panduan lengkap untuk memahami ekosistem .NET, dari sejarah hingga cara menulis program pertamamu.

---

## 📌 Apa Itu .NET?

**.NET** (dibaca "dot net") adalah **platform pengembangan software gratis dan open-source** buatan Microsoft. Dengan .NET, kamu bisa membuat:

- 🖥️ **Aplikasi Desktop** (Windows, Mac, Linux)
- 🌐 **Aplikasi Web** (ASP.NET Core)
- 📱 **Aplikasi Mobile** (.NET MAUI)
- ☁️ **Layanan Cloud & API** (Web API, gRPC)
- 🎮 **Game** (Unity menggunakan C#)
- 🤖 **Aplikasi IoT & AI/ML** (ML.NET)

---

## 📜 Sejarah Singkat .NET

```
2002  → .NET Framework 1.0 dirilis (hanya Windows)
2016  → .NET Core 1.0 dirilis (lintas platform: Win/Mac/Linux)
2019  → .NET Core 3.x (sudah sangat stabil)
2020  → .NET 5 (Framework + Core digabung, nama baru: ".NET")
2021  → .NET 6 (LTS - Long Term Support)
2022  → .NET 7
2023  → .NET 8 (LTS) ← yang kita pakai sekarang
2024  → .NET 9
```

> **LTS (Long Term Support)** = versi yang didukung selama 3 tahun. Disarankan untuk project production.

---

## 🌐 Ekosistem .NET

```
┌─────────────────────────────────────────────────────┐
│                   EKOSISTEM .NET                    │
├─────────────────┬──────────────┬───────────────────┤
│   Bahasa        │   Framework  │   Tools           │
├─────────────────┼──────────────┼───────────────────┤
│ C# (utama)      │ ASP.NET Core │ Visual Studio     │
│ F#              │ .NET MAUI    │ VS Code           │
│ VB.NET          │ Blazor       │ dotnet CLI        │
│                 │ Entity Frmwk │ NuGet             │
└─────────────────┴──────────────┴───────────────────┘
```

---

## 🔤 Bahasa Pemrograman: C#

**C#** (dibaca "C Sharp") adalah bahasa pemrograman utama di ekosistem .NET. Diciptakan oleh **Anders Hejlsberg** di Microsoft pada tahun 2000.

### Karakteristik C#:
- ✅ **Strongly typed** — setiap variabel punya tipe data yang jelas
- ✅ **Object-Oriented** — mendukung class, inheritance, polymorphism
- ✅ **Modern** — terus berkembang (C# 12 di .NET 8)
- ✅ **Cross-platform** — jalan di Windows, Mac, Linux
- ✅ **Managed** — memory dikelola otomatis oleh Garbage Collector

---

## ⚙️ Bagaimana .NET Bekerja?

```
Kode C# (.cs)
     ↓  [Kompilasi oleh Roslyn Compiler]
IL Code / Bytecode (.dll)
     ↓  [Dijalankan oleh CLR / Runtime]
Kode Mesin (berjalan di CPU)
```

| Komponen | Penjelasan |
|----------|------------|
| **Roslyn** | Compiler C# yang mengubah kode menjadi IL (Intermediate Language) |
| **CLR** | Common Language Runtime — mesin virtual yang menjalankan IL |
| **GC** | Garbage Collector — membersihkan memori otomatis |
| **BCL** | Base Class Library — kumpulan class bawaan .NET (String, List, dll.) |

---

## 🛠️ Cara Install .NET

### 1. Download .NET SDK
Kunjungi: **https://dotnet.microsoft.com/download**

Pilih .NET 8 (LTS) → pilih OS kamu (Windows/macOS/Linux)

### 2. Verifikasi Instalasi
```bash
dotnet --version
# Output: 8.x.x

dotnet --info
# Melihat semua versi .NET yang terinstall
```

### 3. Install VS Code + Extension
- Download VS Code: **https://code.visualstudio.com**
- Install extension: **C# Dev Kit** (by Microsoft)

---

## 📁 Tipe-Tipe Project .NET

### Buat Project Baru via CLI:
```bash
# Console Application
dotnet new console -n NamaProject

# Web API
dotnet new webapi -n NamaProject

# Class Library (untuk kode yang dibagi-pakai)
dotnet new classlib -n NamaProject

# Melihat semua template yang tersedia
dotnet new list
```

---

## 🏗️ Anatomi Program C# (Lengkap)

### Cara Modern (Top-level statements, .NET 6+):
```csharp
// Program.cs - cukup ini saja!
Console.WriteLine("Hello, World!");
```

### Cara Klasik (sebelum .NET 6):
```csharp
using System;                    // Import namespace

namespace HelloDotNet             // Namespace = pengelompok kode
{
    class Program                 // Class = blueprint/cetakan
    {
        static void Main(string[] args)  // Method utama, dijalankan pertama
        {
            Console.WriteLine("Hello, World!");
        }
    }
}
```

---

## 📝 Sintaks Dasar C#

### Variabel dan Tipe Data
```csharp
// Tipe data primitif
int angka = 10;           // Bilangan bulat (-2 miliar s/d 2 miliar)
long angkaBesar = 9999999999L; // Bilangan bulat lebih besar
double desimal = 3.14;    // Bilangan desimal (presisi ganda)
float desimal2 = 3.14f;   // Bilangan desimal (presisi tunggal)
decimal uang = 99.99m;    // Bilangan desimal (presisi tinggi, untuk uang)
bool benar = true;        // true atau false
char huruf = 'A';         // Satu karakter
string teks = "Hello";    // Teks (kumpulan karakter)

// Inferensi tipe (compiler tebak sendiri)
var nama = "Budi";        // C# tahu ini string
var umur = 25;            // C# tahu ini int
```

### Input & Output
```csharp
// Output ke layar
Console.WriteLine("Ini menampilkan teks + pindah baris");
Console.Write("Ini tidak pindah baris");

// Format string (string interpolation)
string nama = "Budi";
int umur = 25;
Console.WriteLine($"Nama: {nama}, Umur: {umur}");
// Output: Nama: Budi, Umur: 25

// Input dari user
Console.Write("Masukkan nama: ");
string input = Console.ReadLine()!; // Tanda ! = tidak akan null
Console.WriteLine($"Halo, {input}!");
```

### Kondisi (If-Else)
```csharp
int nilai = 85;

if (nilai >= 90)
{
    Console.WriteLine("A - Sangat Baik");
}
else if (nilai >= 80)
{
    Console.WriteLine("B - Baik");
}
else if (nilai >= 70)
{
    Console.WriteLine("C - Cukup");
}
else
{
    Console.WriteLine("D - Kurang");
}

// Switch Expression (cara modern)
string grade = nilai switch
{
    >= 90 => "A",
    >= 80 => "B",
    >= 70 => "C",
    _     => "D"   // _ = default (else)
};
```

### Perulangan (Loop)
```csharp
// For loop
for (int i = 0; i < 5; i++)
{
    Console.WriteLine($"Iterasi ke-{i}");
}

// While loop
int x = 0;
while (x < 5)
{
    Console.WriteLine(x);
    x++;
}

// Foreach (untuk koleksi)
string[] buah = { "Apel", "Mangga", "Jeruk" };
foreach (string b in buah)
{
    Console.WriteLine(b);
}
```

### Array & List
```csharp
// Array (ukuran tetap)
int[] angka = { 1, 2, 3, 4, 5 };
int[] angka2 = new int[5];     // Array kosong isi 5
Console.WriteLine(angka[0]);   // Akses index 0 → output: 1

// List (ukuran dinamis)
List<string> nama = new List<string>();
nama.Add("Budi");
nama.Add("Ani");
nama.Remove("Budi");
Console.WriteLine(nama.Count); // Jumlah elemen

// Dictionary (key-value)
Dictionary<string, int> nilai = new Dictionary<string, int>();
nilai["Budi"] = 85;
nilai["Ani"] = 90;
Console.WriteLine(nilai["Budi"]); // Output: 85
```

### Method / Fungsi
```csharp
// Mendefinisikan method
static int Tambah(int a, int b)
{
    return a + b;
}

// Memanggil method
int hasil = Tambah(3, 4);
Console.WriteLine(hasil); // Output: 7

// Method tanpa return value
static void Sapa(string nama)
{
    Console.WriteLine($"Halo, {nama}!");
}
```

---

## 🔧 Perintah .NET CLI yang Sering Dipakai

```bash
dotnet new console -n NamaApp   # Buat project baru
dotnet run                       # Jalankan program
dotnet build                     # Compile saja (tidak menjalankan)
dotnet test                      # Jalankan unit test
dotnet add package NamaPaket     # Install library dari NuGet
dotnet restore                   # Restore/install semua dependencies
dotnet publish                   # Build untuk produksi/deployment
dotnet --version                 # Cek versi .NET
```

---

## 📦 NuGet — Package Manager .NET

**NuGet** adalah toko library/package untuk .NET, seperti npm untuk JavaScript.

```bash
# Cari package
dotnet add package Newtonsoft.Json

# Lihat package yang terinstall
dotnet list package
```

Contoh paket populer:
| Package | Kegunaan |
|---------|---------|
| `Newtonsoft.Json` | Parse/serialize JSON |
| `Dapper` | ORM ringan untuk database |
| `Entity Framework Core` | ORM lengkap dengan migration |
| `Serilog` | Logging yang fleksibel |
| `AutoMapper` | Mapping antar object |
| `FluentValidation` | Validasi data |

---

## 🆚 .NET vs Bahasa Lain

| Fitur | C# / .NET | Java | Python | JavaScript |
|-------|-----------|------|--------|------------|
| Tipe data | Statik | Statik | Dinamik | Dinamik |
| Performa | ⚡ Sangat cepat | ⚡ Cepat | 🐌 Lambat | 🔄 Sedang |
| Cross-platform | ✅ | ✅ | ✅ | ✅ |
| OOP | ✅ Full | ✅ Full | ✅ Partial | ✅ Partial |
| GUI Desktop | ✅ WPF/MAUI | ✅ Swing | ✅ Tkinter | ❌ |

---

## 🎯 Mulai Dari Mana?

1. **Install .NET 8 SDK** dan VS Code
2. **Buat project pertama:** `dotnet new console -n BelajarDotNet`
3. **Edit `Program.cs`** dan eksplorasi sintaks dasar
4. **Pelajari OOP** → lihat [02-oop-csharp.md](./02-oop-csharp.md)
5. **Terapkan best practice** → lihat [03-best-practices.md](./03-best-practices.md)
6. **Gunakan cheatsheet** → lihat [04-cheatsheet.md](./04-cheatsheet.md)
