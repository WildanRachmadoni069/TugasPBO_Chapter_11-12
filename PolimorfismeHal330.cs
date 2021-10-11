using System;

namespace PolimorfismeHal330
{
    public class KomisiKaryawan
    {
        public string NamaAwal { get; }
        public string NamaAkhir { get; }
        public string KTP { get; }
        private decimal penjualanKotor;
        private decimal Tingkatkomisi;
        public KomisiKaryawan(string Namadepan, string Namabelakang, string ktp, decimal penjualanKotor, decimal Tingkatkomisi)
        {
            NamaAwal = Namadepan;
            NamaAkhir = Namabelakang;
            KTP = ktp;
            PenjualanKotor = penjualanKotor;
            TingkatKomisi = Tingkatkomisi;
        }
        public decimal PenjualanKotor
        {
            get
            {
                return penjualanKotor;
            }
            set
            {
                if (value < 0)
                {
                    throw new ArgumentOutOfRangeException(nameof(value), value, $"{nameof(PenjualanKotor)} harus >= 0");
                }
                penjualanKotor = value;
            }
        }
        public decimal TingkatKomisi
        {
            get
            {
                return Tingkatkomisi;
            }
            set
            {
                if (value <= 0 || value >= 1)
                {
                    throw new ArgumentOutOfRangeException(nameof(value), value, $"{nameof(TingkatKomisi)} harus > 0 dan < 1");
                }
                Tingkatkomisi = value;
            }
        }
        public virtual decimal Pendapatan() => TingkatKomisi * PenjualanKotor;
        public override string ToString() => $"Karyawan Komisi : {NamaAwal}{NamaAkhir}\n" +
            $"No.KTP\t\t: {KTP}\n" + $"Penjualan Kotor\t: {PenjualanKotor:C}\n" + $"Tingkat Komisi\t: {TingkatKomisi:F2}";
    }
    public class KomisiPokokKaryawan : KomisiKaryawan
    {
        private decimal gajiPokok;
        public KomisiPokokKaryawan(string Namadepan, string Namabelakang, string ktp, decimal penjualanKotor,
            decimal Tingkatkomisi, decimal gajiPokok)
            : base(Namadepan, Namabelakang, ktp, penjualanKotor, Tingkatkomisi)
        {
            GajiPokok = gajiPokok;
        }
        public decimal GajiPokok
        {
            get
            {
                return gajiPokok;
            }
            set
            {
                if (value < 0)
                {
                    throw new ArgumentOutOfRangeException(nameof(value), value, $"{nameof(GajiPokok)} harus >= 0");
                }
                gajiPokok = value;
            }
        }
        public override decimal Pendapatan() => GajiPokok + base.Pendapatan();
        public override string ToString() => $"Gaji-Pokok {base.ToString()}\nGaji Pokok\t: {GajiPokok:C}";
    }
    class tes_Polymorphism
    {
        static void Main()
        {
            var komisiKaryawan = new KomisiKaryawan("Sue ", "Jones", "222-22-2222", 10000.00M, .06M);
            var komisiPokokKaryawan = new KomisiPokokKaryawan("Bob ", "Lewis", "333-33-3333", 5000.00M, .04M, 300.00M);
            Console.WriteLine("Memanggil KomisiKaryawan dengan ToString dan metode pendapatan " +
                "dengan referensi kelas-utama ke objek kelas-utama :\n");
            Console.WriteLine(komisiKaryawan.ToString());
            Console.WriteLine($"Pendapatan\t: {komisiKaryawan.Pendapatan()}\n");
            Console.WriteLine("Memanggil KomisiPokokKaryawan dengan ToString dan " +
                "method Pendapatan dengan turunan referensi untuk" + " objek kelas-turunan:\n");
            Console.WriteLine(komisiPokokKaryawan.ToString());
            Console.WriteLine($"Pendapatan\t: {komisiPokokKaryawan.Pendapatan()}\n");
            KomisiKaryawan karyawankomisi2 = komisiPokokKaryawan;
            Console.WriteLine("Memanggil KomisiPokokKaryawan dengan ToString dan Pendapatan " +
                "method dengan kelas-utama untuk objek kelas-turunan:\n");
            Console.WriteLine(karyawankomisi2.ToString());
            Console.WriteLine($"Pendapatan\t: {komisiPokokKaryawan.Pendapatan()}\n");
            Console.ReadLine();
        }
    }

}
