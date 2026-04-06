# 📖 Penjelasan Project HelloDotNet

> Penjelasan lengkap semua file dalam project ini, termasuk fungsi per baris kodenya.

---

## 📁 Struktur Project

```
helloworld/
├── docs/                       ← Folder dokumentasi (kamu ada di sini)
│   ├── README.md               ← Index dokumentasi
│   ├── 00-penjelasan-project.md
│   ├── 01-pengenalan-dotnet.md
│   ├── 02-oop-csharp.md
│   ├── 03-best-practices.md
│   └── 04-cheatsheet.md
├── helloworld.sln              ← File Solution Visual Studio
├── .gitignore                  ← Daftar file yang diabaikan oleh Git
└── HelloDotNet/
    ├── HelloDotNet.csproj      ← File konfigurasi project C#
    └── Program.cs              ← File utama berisi kode program
```

---

## 📄 1. `Program.cs`
**Lokasi:** `HelloDotNet/Program.cs`  
**Fungsi:** File utama yang berisi kode C# yang dijalankan pertama kali saat program dieksekusi.

```csharp
// See https://aka.ms/new-console-template for more information
Console.WriteLine("Hello, World!");
```

### Penjelasan Per Baris:

| Baris | Kode | Penjelasan |
|-------|------|------------|
| 1 | `// See https://aka.ms/...` | **Komentar** — tidak dieksekusi. Berisi link ke dokumentasi Microsoft tentang template console app modern (.NET 6+). Komentar diawali `//`. |
| 2 | `Console.WriteLine("Hello, World!");` | Mencetak teks ke layar. `Console` = class I/O bawaan .NET. `WriteLine` = method cetak + otomatis pindah baris. `"Hello, World!"` = teks yang ditampilkan. |

> **Catatan:** Di .NET 6 ke atas, tidak perlu lagi menulis `class Program { static void Main() {...} }`. Cukup tulis kode langsung — fitur ini disebut **Top-level statements**.

---

## 📄 2. `HelloDotNet.csproj`
**Lokasi:** `HelloDotNet/HelloDotNet.csproj`  
**Fungsi:** File konfigurasi project berbasis XML. Memberitahu .NET tentang pengaturan compile, target framework, dan fitur yang aktif.

```xml
<Project Sdk="Microsoft.NET.Sdk">

  <PropertyGroup>
    <OutputType>Exe</OutputType>
    <TargetFramework>net8.0</TargetFramework>
    <ImplicitUsings>enable</ImplicitUsings>
    <Nullable>enable</Nullable>
  </PropertyGroup>

</Project>
```

### Penjelasan Per Baris:

| Baris | Kode | Penjelasan |
|-------|------|------------|
| 1 | `<Project Sdk="Microsoft.NET.Sdk">` | Tag pembuka. `Sdk="Microsoft.NET.Sdk"` = project .NET standar. |
| 3 | `<PropertyGroup>` | Pengelompok properti konfigurasi. |
| 4 | `<OutputType>Exe</OutputType>` | Output berupa executable (file yang bisa langsung dijalankan). |
| 5 | `<TargetFramework>net8.0</TargetFramework>` | Menggunakan .NET 8 (versi LTS). |
| 6 | `<ImplicitUsings>enable</ImplicitUsings>` | Namespace umum (`System`, `Collections`, dll.) auto-import. |
| 7 | `<Nullable>enable</Nullable>` | Aktifkan peringatan untuk potensi `NullReferenceException`. |
| 8 | `</PropertyGroup>` | Penutup grup properti. |
| 10 | `</Project>` | Penutup seluruh blok project. |

---

## 📄 3. `helloworld.sln`
**Lokasi:** `helloworld/helloworld.sln`  
**Fungsi:** File Solution Visual Studio — "wadah" yang mengorganisir satu atau banyak project .NET sekaligus.

### Penjelasan Per Baris:

| Baris | Kode | Penjelasan |
|-------|------|------------|
| 1 | `Microsoft Visual Studio Solution File, Format Version 12.00` | Header: ini file solution VS format 12. |
| 2 | `# Visual Studio Version 17` | Komentar: dibuat dengan VS 2022 (versi internal 17). |
| 3 | `VisualStudioVersion = 17.5.2.0` | Versi spesifik VS yang membuat file ini. |
| 4 | `MinimumVisualStudioVersion = 10.0.40219.1` | Versi minimum VS yang bisa membuka file ini (VS 2010). |
| 5 | `Project("{FAE04EC0-...}") = "HelloDotNet", "HelloDotNet\HelloDotNet.csproj", "{4F546A...}"` | Daftarkan project ke solution. Format: `tipe-GUID` = `nama`, `path-.csproj`, `project-GUID`. |
| 6 | `EndProject` | Penutup blok deklarasi project. |
| 7 | `Global` | Mulai blok konfigurasi global (berlaku seluruh solution). |
| 8–11 | `GlobalSection(SolutionConfigurationPlatforms)` | Konfigurasi build tersedia: `Debug` dan `Release`. |
| 12–16 | `GlobalSection(ProjectConfigurationPlatforms)` | Mapping konfigurasi solution ke masing-masing project. |
| 18–20 | `GlobalSection(SolutionProperties)` | `HideSolutionNode = FALSE` = tampilkan node solution di Solution Explorer. |
| 21–23 | `GlobalSection(ExtensibilityGlobals)` | `SolutionGuid` = ID unik solution untuk identifikasi internal. |
| 24 | `EndGlobal` | Penutup blok konfigurasi global. |

---

## 📄 4. `.gitignore`
**Lokasi:** `helloworld/.gitignore`  
**Fungsi:** Memberitahu Git file/folder mana yang **tidak** perlu di-track atau di-push ke repository.

### Kategori Yang Diabaikan:

| Kategori | Contoh Pattern | Penjelasan |
|----------|---------------|------------|
| **Environment** | `.env` | Berisi password/secret key — jangan pernah di-commit! |
| **File user VS** | `*.suo`, `*.user` | Preferensi pribadi, berbeda tiap developer |
| **Hasil build** | `[Bb]in/`, `[Oo]bj/` | File hasil compile — bisa di-generate ulang kapan saja |
| **Cache VS** | `.vs/` | Folder cache internal Visual Studio |
| **Hasil test** | `TestResult*/` | Laporan unit test |
| **NuGet packages** | `**/packages/*` | Library — bisa di-restore via `dotnet restore` |
| **File sensitif** | `*.pfx`, `*.publishsettings` | Sertifikat & credential deployment |
| **macOS** | `.DS_Store` | File metadata macOS yang tidak relevan |
| **Windows** | `Thumbs.db` | Cache thumbnail Windows |
| **VS Code** | `.vscode/*` | Pengaturan editor pribadi |
| **JetBrains** | `.idea/` | File konfigurasi Rider IDE |

---

## 🚀 Cara Menjalankan Project

```bash
# Masuk ke folder project
cd HelloDotNet

# Jalankan program
dotnet run
```

**Output:**
```
Hello, World!
```

---

## 🔑 Konsep Penting

| Konsep | Penjelasan |
|--------|------------|
| **.NET 8** | Platform runtime Microsoft untuk aplikasi C# lintas OS |
| **C#** | Bahasa pemrograman utama project ini |
| **Console App** | Aplikasi yang berjalan di terminal, bukan GUI |
| **Top-level statements** | Fitur .NET 6+: tulis kode tanpa wrapper class/method |
| **Solution (.sln)** | Wadah yang bisa menampung banyak project |
| **Project (.csproj)** | File konfigurasi untuk satu project C# |
