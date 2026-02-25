namespace Nyilt
{
    internal class Program
    {
        static void Main(string[] args)
        {
            var ctx = new AppDbContext();
            var barna = ctx.Diakok
                .Where(x => x.Telepules == "Barnamalom")
                .Select(x => x.Nev);
            foreach (var i in barna)
            {
                Console.WriteLine(i);
            }

            var angol = ctx.Orak
                .Where(x => x.Targy == "angol")
                .Select(x => new
                {
                    Datum = x.Datum,
                    Terem = x.Terem,
                    Sorszam = x.Orasorszam
                })
                .OrderBy(x => x.Datum)
                .ThenBy(x => x.Sorszam);
            foreach (var i in angol)
            {
                Console.WriteLine($"{i.Datum.ToString("yy:MM:dd")} - {i.Terem} - {i.Sorszam}");
            }

            var kilenc = ctx.Orak
                .Where(x => x.Csoport.StartsWith("9") && (x.Targy == "matematika" || x.Targy == "fizika"))
                .Select(x => new
                {
                    Csoport = x.Csoport,
                    Tantargy = x.Targy,
                    Datum = x.Datum
                })
                .OrderBy(x => x.Tantargy);
            foreach (var i in kilenc)
            {
                Console.WriteLine($"{i.Tantargy} - {i.Datum.ToString("yy:MM:dd")} - {i.Csoport}");
            }

            var hany = ctx.Diakok
                .GroupBy(x => x.Telepules)
                .Select(x => new
                {
                    Telepules = x.Key,
                    Letszam = x.Count()
                });
                
            foreach (var i in hany)
            {
                Console.WriteLine($"{i.Telepules} - {i.Letszam}");
            }

            var anna = ctx.Kapcsolo
                .Where(x => x.Ora.Tanar == "Angol Anna" && x.Ora.Datum == new DateTime(2028, 11, 10))
                .Select(x => new
                {
                    nev = x.Diak.Nev,
                    email = x.Diak.Email,
                    tel = x.Diak.Telefon
                });
            foreach (var i in anna)
            {
                Console.WriteLine($"{i.nev} - {i.tel} - {i.email}");
            }

            var mayer = ctx.Diakok
                .Where(x => x.Telepules == (ctx.Diakok.Where(y => y.Nev == "Majer Melinda").Select(y => y.Telepules).FirstOrDefault()) && x.Nev !="Majer Melinda")
                .Select(x => x.Nev);
            foreach (var i in mayer)
            {
                Console.WriteLine($"{i}");
            }

            var szabad = ctx.Orak
                .Select(x => new
                {
                    datum = x.Datum,
                    sorsz = x.Orasorszam,
                    targy = x.Targy,
                    tanar = x.Tanar,
                    szabad = x.Ferohely - x.Kapcsolatok.Count
                })
                .Where(x => x.szabad > 0)
                .OrderByDescending(x => x.szabad);

            foreach (var i in szabad)
            {
                Console.WriteLine($"{i.datum.ToString("yy-MM-dd")} - {i.sorsz} - {i.targy} - {i.tanar} - {i.szabad}");
            }
        }
    }
}
