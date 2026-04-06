# ✅ Best Practices C# dan .NET

> Panduan konvensi, prinsip, dan kebiasaan profesional saat menulis kode C#.

---

## 📝 1. Konvensi Penamaan (Naming Conventions)

Ini adalah standar penamaan resmi dari Microsoft yang diikuti oleh seluruh komunitas .NET.

### Aturan Dasar:

| Tipe | Konvensi | Contoh |
|------|----------|--------|
| **Class** | PascalCase | `BankAccount`, `OrderService` |
| **Interface** | IPascalCase | `IRepository`, `ILogger` |
| **Method** | PascalCase | `GetById()`, `SaveChanges()` |
| **Property** | PascalCase | `FirstName`, `TotalPrice` |
| **Public Field** | PascalCase | `MaxRetries` |
| **Private Field** | _camelCase | `_connectionString`, `_userId` |
| **Parameter** | camelCase | `firstName`, `orderId` |
| **Local Variable** | camelCase | `totalAmount`, `isValid` |
| **Constant** | PascalCase | `MaxPageSize`, `DefaultTimeout` |
| **Enum** | PascalCase | `OrderStatus`, `UserRole` |
| **Enum Value** | PascalCase | `OrderStatus.Pending` |

```csharp
// ❌ BAD — tidak mengikuti konvensi
public class bank_account
{
    public string FIRSTNAME;
    private string LastName;

    public void get_balance() { }
}

// ✅ GOOD — mengikuti konvensi Microsoft
public class BankAccount
{
    private string _firstName;
    private string _lastName;

    public string FirstName => _firstName;

    public decimal GetBalance() { return 0; }
}
```

---

## 🧱 2. Prinsip SOLID

**SOLID** adalah 5 prinsip desain OOP untuk kode yang mudah dipelihara dan dikembangkan.

### S — Single Responsibility Principle (SRP)
> Setiap class hanya punya **satu alasan untuk berubah**.

```csharp
// ❌ BAD — class ini melakukan terlalu banyak hal
public class UserService
{
    public void CreateUser(User user) { /* ... */ }
    public void SendEmail(string email) { /* ... */ }    // Bukan tugasnya!
    public void SaveToDatabase(User user) { /* ... */ }  // Bukan tugasnya!
    public void GenerateReport() { /* ... */ }           // Bukan tugasnya!
}

// ✅ GOOD — pisah tanggung jawab
public class UserService
{
    private readonly IUserRepository _repo;
    private readonly IEmailService _email;

    public UserService(IUserRepository repo, IEmailService email)
    {
        _repo = repo; _email = email;
    }

    public async Task CreateUserAsync(User user)
    {
        await _repo.SaveAsync(user);
        await _email.SendWelcomeEmailAsync(user.Email);
    }
}

public class EmailService : IEmailService { /* hanya email */ }
public class UserRepository : IUserRepository { /* hanya database */ }
```

### O — Open/Closed Principle (OCP)
> Class harus **terbuka untuk ekstensi, tertutup untuk modifikasi**.

```csharp
// ❌ BAD — setiap tambah diskon baru harus modifikasi class ini
public class HargaCalculator
{
    public decimal Hitung(decimal harga, string tipeDiskon)
    {
        if (tipeDiskon == "pelajar")  return harga * 0.8m;
        if (tipeDiskon == "senior")   return harga * 0.7m;
        // Harus tambah if lagi kalau ada diskon baru!
        return harga;
    }
}

// ✅ GOOD — tambah diskon baru cukup buat class baru
public interface IDiskon
{
    decimal Terapkan(decimal harga);
}

public class DiskonPelajar : IDiskon { public decimal Terapkan(decimal h) => h * 0.8m; }
public class DiskonSenior  : IDiskon { public decimal Terapkan(decimal h) => h * 0.7m; }
public class DiskonMember  : IDiskon { public decimal Terapkan(decimal h) => h * 0.9m; }

public class HargaCalculator
{
    public decimal Hitung(decimal harga, IDiskon diskon) => diskon.Terapkan(harga);
}
```

### L — Liskov Substitution Principle (LSP)
> Object dari class turunan harus bisa menggantikan class induknya **tanpa merusak program**.

```csharp
// ❌ BAD — Burung tidak bisa terbang! Ini melanggar LSP
public class Burung
{
    public virtual void Terbang() => Console.WriteLine("Terbang!");
}

public class Pinguin : Burung
{
    public override void Terbang()
        => throw new NotSupportedException("Pinguin tidak bisa terbang!");
}

// ✅ GOOD — pisahkan kemampuan terbang ke interface
public class Burung
{
    public virtual void Makan() => Console.WriteLine("Makan");
}

public interface IBisaTerbang { void Terbang(); }

public class Elang : Burung, IBisaTerbang
{
    public void Terbang() => Console.WriteLine("Elang terbang tinggi!");
}

public class Pinguin : Burung  // Tidak implement IBisaTerbang
{
    public void Berenang() => Console.WriteLine("Pinguin berenang!");
}
```

### I — Interface Segregation Principle (ISP)
> Jangan paksa class mengimplementasikan interface yang tidak mereka butuhkan.

```csharp
// ❌ BAD — interface terlalu gemuk
public interface IWorker
{
    void Bekerja();
    void Makan();
    void Tidur();
}

// ✅ GOOD — interface kecil dan spesifik
public interface IBisa Bekerja { void Bekerja(); }
public interface IBisa Makan   { void Makan(); }
public interface IBisa Tidur   { void Tidur(); }

public class Manusia : IBekerja, IMakan, ITidur { /* ... */ }
public class Robot    : IBekerja { /* tidak perlu tidur/makan */ }
```

### D — Dependency Inversion Principle (DIP)
> Depend pada **abstraksi (interface)**, bukan pada implementasi konkret.

```csharp
// ❌ BAD — tightly coupled ke implementasi spesifik
public class OrderService
{
    private SqlDatabase _db = new SqlDatabase();  // Langsung pakai SQL!
    public void Save(Order o) => _db.Save(o);
}

// ✅ GOOD — depend pada interface
public interface IOrderRepository
{
    Task SaveAsync(Order order);
    Task<Order?> GetByIdAsync(int id);
}

public class OrderService
{
    private readonly IOrderRepository _repo;

    // Injeksi dari luar (Dependency Injection)
    public OrderService(IOrderRepository repo) => _repo = repo;

    public async Task ProcessOrderAsync(Order order)
    {
        // ... logic ...
        await _repo.SaveAsync(order);
    }
}

// Implementasi bisa diganti kapan saja tanpa ubah OrderService
public class SqlOrderRepository  : IOrderRepository { /* SQL */    }
public class MongoOrderRepository: IOrderRepository { /* MongoDB */ }
```

---

## 🧹 3. Clean Code

### Penamaan yang Bermakna
```csharp
// ❌ BAD
int d;              // d itu apa?
bool flag;          // flag apa?
void proc(int x) {} // proc singkatan dari apa?

// ✅ GOOD
int hariDalamBulan;
bool isUserAuthenticated;
void UpdateUserProfile(int userId) {}
```

### Method Pendek dan Fokus
```csharp
// ❌ BAD — method terlalu panjang dan bercampur logika
public void ProcessOrder(Order order)
{
    // validasi
    if (order.Items == null || !order.Items.Any())
        throw new Exception("Kosong");
    if (order.UserId <= 0)
        throw new Exception("User tidak valid");

    // hitung harga
    decimal total = 0;
    foreach (var item in order.Items)
        total += item.Price * item.Quantity;
    order.TotalPrice = total;

    // simpan
    _db.Save(order);

    // kirim email
    _emailService.Send(order.UserEmail, "Order berhasil!");
}

// ✅ GOOD — setiap method punya satu tanggung jawab
public async Task ProcessOrderAsync(Order order)
{
    ValidateOrder(order);
    CalculateTotalPrice(order);
    await _repo.SaveAsync(order);
    await _emailService.SendConfirmationAsync(order);
}

private void ValidateOrder(Order order)
{
    if (order.Items == null || !order.Items.Any())
        throw new ArgumentException("Order tidak boleh kosong.");
    if (order.UserId <= 0)
        throw new ArgumentException("User ID tidak valid.");
}

private void CalculateTotalPrice(Order order)
{
    order.TotalPrice = order.Items.Sum(x => x.Price * x.Quantity);
}
```

### Hindari Magic Numbers
```csharp
// ❌ BAD
if (userAge < 18) // 18 itu apa?
    return false;

Thread.Sleep(5000); // 5000 itu berapa?

// ✅ GOOD
private const int MinimumAge = 18;
private const int TimeoutMilliseconds = 5_000;

if (userAge < MinimumAge)
    return false;

Thread.Sleep(TimeoutMilliseconds);
```

---

## ⚡ 4. Async/Await

Gunakan `async`/`await` untuk operasi I/O (database, network, file) agar aplikasi tidak blocking.

```csharp
// ❌ BAD — memblokir thread!
public User GetUser(int id)
{
    return _db.FindUser(id);  // Thread menunggu, tidak bisa melakukan hal lain
}

// ✅ GOOD — non-blocking
public async Task<User?> GetUserAsync(int id)
{
    return await _db.FindUserAsync(id);  // Thread bebas saat menunggu
}

// Konvensi async:
// 1. Tambah suffix "Async" pada nama method
// 2. Kembalikan Task atau Task<T>, bukan void (kecuali event handler)
// 3. Gunakan CancellationToken untuk operasi yang bisa dibatalkan
public async Task<User?> GetUserAsync(int id, CancellationToken ct = default)
{
    return await _db.FindUserAsync(id, ct);
}
```

---

## 🛡️ 5. Null Safety

```csharp
// Aktifkan Nullable di .csproj: <Nullable>enable</Nullable>

// ❌ BAD — potensi NullReferenceException
string nama = null;
Console.WriteLine(nama.Length); // Crash!

// ✅ GOOD — gunakan null checks
string? nama = GetNama(); // ? berarti bisa null

// Null-coalescing operator (??)
string display = nama ?? "Tanpa Nama";

// Null-conditional operator (?.)
int? panjang = nama?.Length;  // null kalau nama null, tidak crash

// Null-coalescing assignment (??=)
nama ??= "Default";  // Assign hanya kalau null

// Pattern matching
if (nama is not null)
{
    Console.WriteLine(nama.Length);
}

// ArgumentNullException
public void Proses(string input)
{
    ArgumentNullException.ThrowIfNull(input);
    // ...
}
```

---

## 📂 6. Struktur Project yang Baik

```
MyProject/
├── src/
│   └── MyProject/
│       ├── Controllers/        ← Handle HTTP request (API)
│       ├── Services/           ← Business logic
│       ├── Repositories/       ← Akses database
│       ├── Models/             ← Data models/entities
│       ├── DTOs/               ← Data Transfer Objects
│       ├── Interfaces/         ← Kontrak/abstraksi
│       ├── Exceptions/         ← Custom exceptions
│       ├── Extensions/         ← Extension methods
│       └── Program.cs
├── tests/
│   └── MyProject.Tests/
│       ├── UnitTests/
│       └── IntegrationTests/
└── MyProject.sln
```

---

## 🪵 7. Logging yang Benar

```csharp
// ❌ BAD — Console.WriteLine di production
Console.WriteLine("User berhasil dibuat");
Console.WriteLine($"Error: {ex.Message}");

// ✅ GOOD — gunakan ILogger
public class UserService
{
    private readonly ILogger<UserService> _logger;

    public UserService(ILogger<UserService> logger) => _logger = logger;

    public async Task CreateUserAsync(User user)
    {
        _logger.LogInformation("Membuat user baru: {UserId}", user.Id);
        try
        {
            await _repo.SaveAsync(user);
            _logger.LogInformation("User {UserId} berhasil dibuat.", user.Id);
        }
        catch (Exception ex)
        {
            _logger.LogError(ex, "Gagal membuat user {UserId}", user.Id);
            throw;
        }
    }
}
```

---

## 🔁 8. Exception Handling

```csharp
// ❌ BAD — tangkap semua tanpa tindakan
try { DoSomething(); }
catch (Exception ex) { }  // Silent fail — sangat berbahaya!

// ❌ BAD — terlalu umum
try { DoSomething(); }
catch (Exception ex) { Console.WriteLine(ex.Message); }

// ✅ GOOD — spesifik dan bermakna
try
{
    await _repo.SaveUserAsync(user);
}
catch (DbUpdateException ex) when (ex.InnerException?.Message.Contains("UNIQUE") == true)
{
    throw new DuplicateEmailException($"Email {user.Email} sudah terdaftar.", ex);
}
catch (TimeoutException ex)
{
    _logger.LogError(ex, "Timeout saat menyimpan user");
    throw; // Re-throw agar caller tahu
}
```

---

## ✍️ 9. Ringkasan Do's & Don'ts

### ✅ DO:
- Gunakan PascalCase untuk class, method, property
- Gunakan `_camelCase` untuk private fields
- Satu class, satu tanggung jawab (SRP)
- Depend pada interface, bukan implementasi
- Gunakan `async`/`await` untuk I/O
- Log dengan `ILogger`, bukan `Console.WriteLine`
- Aktifkan Nullable (`<Nullable>enable</Nullable>`)
- Tulis unit test

### ❌ DON'T:
- Abreviasi nama yang tidak jelas (`d`, `temp`, `flag`, `x`)
- Method yang terlalu panjang (>20 baris mulai patut dicurigai)
- Magic numbers tanpa konstanta bernama
- Catch `Exception` tanpa tindakan (silent fail)
- Langsung akses `null` tanpa pengecekan
- Buat class yang melakukan terlalu banyak hal
