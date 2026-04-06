 var angka = new List<int> { 3, 7, -1, 9, 4, 6, 2, 8, 5, 10 };

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