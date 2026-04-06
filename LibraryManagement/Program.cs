// ============================================================
//   MINI PROJECT: Library Management System
//   Fitur: Tambah, Lihat, Cari, Hapus buku
// ============================================================

// ─── MODEL ───────────────────────────────────────────────────
class Book
{
    public int    Id     { get; set; }
    public string Title  { get; set; } = "";
    public string Author { get; set; } = "";
    public string ISBN   { get; set; } = "";
    public int    Year   { get; set; }
    public bool   IsAvailable { get; set; } = true;

    // Constructor utama
    public Book(int id, string title, string author, string isbn = "-", int year = 0)
    {
        Id     = id;
        Title  = title;
        Author = author;
        ISBN   = isbn;
        Year   = year;
    }

    // Override ToString untuk display singkat
    public override string ToString()
        => $"[{Id}] {Title} – {Author} ({Year})";
}

// ─── PROGRAM ─────────────────────────────────────────────────
class Program
{
    // Data buku (List sebagai "database" sementara)
    static List<Book> books = new List<Book>()
    {
        new Book(1, "C# in Depth",  "Jon Skeet",      "978-1617294532", 2019),
        new Book(2, "Clean Code",   "Robert C. Martin","978-0132350884", 2008),
        new Book(3, "Pro .NET 8",   "Andrew Troelsen", "978-1484293577", 2023),
    };

    static int nextId = 4; // auto-increment ID

    // ─── ENTRY POINT ─────────────────────────────────────────
    static void Main()
    {
        Console.OutputEncoding = System.Text.Encoding.UTF8;

        bool running = true;
        while (running)
        {
            ShowMenu();
            string choice = Console.ReadLine()?.Trim() ?? "";
            Console.WriteLine();

            switch (choice)
            {
                case "1": TambahBuku();   break;
                case "2": LihatSemuaBuku(); break;
                case "3": CariBuku();     break;
                case "4": HapusBuku();    break;
                case "5": UpdateBuku();   break;
                case "0":
                    Console.WriteLine("👋  Terima kasih! Sampai jumpa.");
                    running = false;
                    break;
                default:
                    Warn("Pilihan tidak valid. Silakan coba lagi.");
                    break;
            }

            if (running)
            {
                Console.WriteLine("\nTekan ENTER untuk kembali ke menu...");
                Console.ReadLine();
            }
        }
    }

    // ─── MENU ────────────────────────────────────────────────
    static void ShowMenu()
    {
        Console.Clear();
        Header("📚  LIBRARY MANAGEMENT SYSTEM");
        Console.WriteLine("  1. ➕  Tambah Buku");
        Console.WriteLine("  2. 📋  Lihat Semua Buku");
        Console.WriteLine("  3. 🔍  Cari Buku");
        Console.WriteLine("  4. 🗑️   Hapus Buku");
        Console.WriteLine("  5. ✏️   Update Buku");
        Console.WriteLine("  0. 🚪  Keluar");
        Divider();
        Console.Write("  Pilihan Anda: ");
    }

    // ─── FITUR 1 : TAMBAH BUKU ───────────────────────────────
    static void TambahBuku()
    {
        Header("➕  TAMBAH BUKU BARU");

        Console.Write("  Judul  : ");
        string title = Console.ReadLine()?.Trim() ?? "";

        Console.Write("  Penulis: ");
        string author = Console.ReadLine()?.Trim() ?? "";

        Console.Write("  ISBN   : ");
        string isbn = Console.ReadLine()?.Trim() ?? "-";

        Console.Write("  Tahun  : ");
        int year = int.TryParse(Console.ReadLine(), out int y) ? y : 0;

        if (string.IsNullOrWhiteSpace(title) || string.IsNullOrWhiteSpace(author))
        {
            Warn("Judul dan Penulis tidak boleh kosong!");
            return;
        }

        var book = new Book(nextId++, title, author, isbn, year);
        books.Add(book);
        Success($"Buku '{book.Title}' berhasil ditambahkan! (ID: {book.Id})");
    }

    // ─── FITUR 2 : LIHAT SEMUA BUKU ─────────────────────────
    static void LihatSemuaBuku()
    {
        Header("📋  DAFTAR SEMUA BUKU");

        if (books.Count == 0)
        {
            Warn("Belum ada buku dalam koleksi.");
            return;
        }

        Console.WriteLine($"  Total koleksi: {books.Count} buku\n");
        Console.WriteLine($"  {"ID",-4} {"Judul",-28} {"Penulis",-22} {"Tahun",-6} {"Status"}");
        Divider();

        foreach (var b in books)
        {
            string status = b.IsAvailable ? "✅ Tersedia" : "❌ Dipinjam";
            Console.WriteLine($"  {b.Id,-4} {b.Title,-28} {b.Author,-22} {b.Year,-6} {status}");
        }

        Divider();
    }

    // ─── FITUR 3 : CARI BUKU ────────────────────────────────
    static void CariBuku()
    {
        Header("🔍  CARI BUKU");
        Console.Write("  Kata kunci (judul/penulis): ");
        string keyword = Console.ReadLine()?.Trim().ToLower() ?? "";

        if (string.IsNullOrWhiteSpace(keyword))
        {
            Warn("Kata kunci tidak boleh kosong.");
            return;
        }

        // LINQ untuk pencarian
        var results = books.Where(b =>
            b.Title.ToLower().Contains(keyword) ||
            b.Author.ToLower().Contains(keyword)
        ).ToList();

        if (results.Count == 0)
        {
            Warn($"Tidak ditemukan buku dengan kata kunci '{keyword}'.");
            return;
        }

        Console.WriteLine($"\n  Ditemukan {results.Count} buku:\n");
        foreach (var b in results)
        {
            Console.WriteLine($"  ➤  {b}");
            Console.WriteLine($"     ISBN: {b.ISBN} | Status: {(b.IsAvailable ? "Tersedia" : "Dipinjam")}");
        }
    }

    // ─── FITUR 4 : HAPUS BUKU ───────────────────────────────
    static void HapusBuku()
    {
        Header("🗑️   HAPUS BUKU");
        LihatSemuaBuku();

        Console.Write("\n  Masukkan ID buku yang ingin dihapus: ");
        if (!int.TryParse(Console.ReadLine(), out int id))
        {
            Warn("ID tidak valid.");
            return;
        }

        var book = books.FirstOrDefault(b => b.Id == id);
        if (book == null)
        {
            Warn($"Buku dengan ID {id} tidak ditemukan.");
            return;
        }

        Console.Write($"  Yakin ingin menghapus '{book.Title}'? (y/n): ");
        string confirm = Console.ReadLine()?.Trim().ToLower() ?? "";
        if (confirm == "y")
        {
            books.Remove(book);
            Success($"Buku '{book.Title}' berhasil dihapus.");
        }
        else
        {
            Console.WriteLine("  Penghapusan dibatalkan.");
        }
    }

    // ─── FITUR 5 : UPDATE BUKU ──────────────────────────────
    static void UpdateBuku()
    {
        Header("✏️   UPDATE BUKU");
        LihatSemuaBuku();

        Console.Write("\n  Masukkan ID buku yang ingin diupdate: ");
        if (!int.TryParse(Console.ReadLine(), out int id))
        {
            Warn("ID tidak valid.");
            return;
        }

        var book = books.FirstOrDefault(b => b.Id == id);
        if (book == null)
        {
            Warn($"Buku dengan ID {id} tidak ditemukan.");
            return;
        }

        Console.WriteLine($"\n  Update buku: {book.Title}");
        Console.WriteLine("  (Tekan ENTER untuk melewati field)\n");

        Console.Write($"  Judul baru  [{book.Title}]: ");
        string newTitle = Console.ReadLine()?.Trim() ?? "";
        if (!string.IsNullOrWhiteSpace(newTitle)) book.Title = newTitle;

        Console.Write($"  Penulis baru [{book.Author}]: ");
        string newAuthor = Console.ReadLine()?.Trim() ?? "";
        if (!string.IsNullOrWhiteSpace(newAuthor)) book.Author = newAuthor;

        Console.Write($"  ISBN baru   [{book.ISBN}]: ");
        string newIsbn = Console.ReadLine()?.Trim() ?? "";
        if (!string.IsNullOrWhiteSpace(newIsbn)) book.ISBN = newIsbn;

        Console.Write($"  Tahun baru  [{book.Year}]: ");
        string yearStr = Console.ReadLine()?.Trim() ?? "";
        if (int.TryParse(yearStr, out int newYear)) book.Year = newYear;

        Success($"Buku berhasil diupdate: {book}");
    }

    // ─── HELPER UI ───────────────────────────────────────────
    static void Header(string text)
    {
        Console.ForegroundColor = ConsoleColor.Cyan;
        Console.WriteLine($"\n  {text}");
        Console.ResetColor();
        Divider();
    }

    static void Divider()
    {
        Console.ForegroundColor = ConsoleColor.DarkGray;
        Console.WriteLine("  " + new string('─', 60));
        Console.ResetColor();
    }

    static void Warn(string msg)
    {
        Console.ForegroundColor = ConsoleColor.Yellow;
        Console.WriteLine($"\n  ⚠️  {msg}");
        Console.ResetColor();
    }

    static void Success(string msg)
    {
        Console.ForegroundColor = ConsoleColor.Green;
        Console.WriteLine($"\n  ✅  {msg}");
        Console.ResetColor();
    }
}
