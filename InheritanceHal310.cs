using System;
public class KomisiPokokKaryawan
{
    public string NamaAwal { get; }
    public string NamaBelakang { get; }
    public string KTP { get; }
    private decimal penjualanKotor;
    private decimal tingkatKomisi;
    private decimal gajiPokok;
    public KomisiPokokKaryawan(string Namadepan, string namaBelakang, string ktp, decimal penjualanKotor, decimal tingkatKomisi, decimal gajiPokok)
    {
        NamaAwal = Namadepan;
        NamaBelakang = namaBelakang;
        KTP = ktp;
        PenjualanKotor = penjualanKotor;
        TingkatKomisi = tingkatKomisi;
        GajiPokok = gajiPokok;
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
            return tingkatKomisi;
        }
        set
        {
            if (value <= 0 || value >= 1)
            {
                throw new ArgumentOutOfRangeException(nameof(value), value, $"{nameof(TingkatKomisi)} harus > 0 dan < 1");
            }
            tingkatKomisi = value;
        }
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
    public decimal Pendapatan() => gajiPokok + (tingkatKomisi * penjualanKotor);
    public override string ToString() => $"Gaji Pokok Karyawan Komisi\t: {NamaAwal}{NamaBelakang}\n" + $"Nomor KTP\t\t\t: {KTP}\n" + $"Penjualan Kotor\t\t\t: {penjualanKotor:C}\n" + $"Tingkat Komisi\t\t\t: {tingkatKomisi:F2}\n" + $"Gaji Pokok\t\t\t: {gajiPokok:C}";
}
class TesKomisiPokokKaryawan
{
    static void Main()
    {
        var karyawan = new KomisiPokokKaryawan("Bob ", "Lewis", "333-33-3333", 5000.00M, .04M, 300.00M);
        Console.WriteLine("Informasi Karyawan diperoleh dari properti dan metode : \n");
        Console.WriteLine($"Nama Depan adalah {karyawan.NamaAwal}");
        Console.WriteLine($"Nama Belakang adalah {karyawan.NamaBelakang}");
        Console.WriteLine($"Nomor KTP adalah {karyawan.KTP}");
        Console.WriteLine($"Penjualan Kotornya adalah {karyawan.PenjualanKotor:C}");
        Console.WriteLine($"Tingkat Komisinya adalah {karyawan.TingkatKomisi:F2}");
        Console.WriteLine($"Pendapatannya adalah {karyawan.Pendapatan():C}");
        Console.WriteLine($"Gaji Pokoknya adalah {karyawan.GajiPokok:C}");
        karyawan.GajiPokok = 1000.00M;
        Console.WriteLine("\nInformasi Karyawan yang diperbarui diperoleh dari ToString:\n");
        Console.WriteLine(karyawan);
        Console.WriteLine($"Pendapatan\t\t\t: {karyawan.Pendapatan():C}");
    }
}