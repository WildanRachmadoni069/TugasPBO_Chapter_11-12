using System;
using System.Collections.Generic;

public interface Hutang
{
    decimal DapatkanJumlahPembayaran();
}
public class Faktur : Hutang
{
    public string NoBagian { get; }
    public string DeskripsiBagian { get; }
    private int kualitas;
    private decimal hargaPerItem;
    public Faktur(string Nobagian, string Deskripsibagian, int kualitas, decimal hargaPerItem)
    {
        NoBagian = Nobagian;
        DeskripsiBagian = Deskripsibagian;
        Kualitas = kualitas;
        HargaPerItem = hargaPerItem;
    }
    public int Kualitas
    {
        get
        {
            return kualitas;
        }
        set
        {
            if (value < 0)
            {
                throw new ArgumentOutOfRangeException(nameof(value), value,
                    $"{nameof(Kualitas)} harus >=0");
            }
            kualitas = value;
        }
    }
    public decimal HargaPerItem
    {
        get
        {
            return hargaPerItem;
        }
        set
        {
            if (value < 0)
            {
                throw new ArgumentOutOfRangeException(nameof(value), value,
                    $"{nameof(HargaPerItem)} harus >= 0");
            }
            hargaPerItem = value;
        }
    }
    public override string ToString() => $"Faktur:\nNomor Bagian\t\t: {NoBagian}({DeskripsiBagian})\n" +
        $"Kualitas\t\t: {Kualitas}\nHarga Per Item\t\t: {HargaPerItem:C}";
    public decimal DapatkanJumlahPembayaran() => Kualitas * HargaPerItem;
}
public abstract class Karyawan : Hutang
{
    public string NamaAwal { get; }
    public string NamaAkhir { get; }
    public string KTP { get; }
    public Karyawan(string Namadepan, string Namabelakang, string ktp)
    {
        NamaAwal = Namadepan;
        NamaAkhir = Namabelakang;
        KTP = ktp;
    }
    public override string ToString() => $"{NamaAwal}{NamaAkhir}\n" +
        $"No.KTP\t\t\t: {KTP}";
    public abstract decimal Pendapatan();
    public decimal DapatkanJumlahPembayaran() => Pendapatan();
}
public class GajiKaryawan : Karyawan
{
    private decimal Gajimingguan;
    public GajiKaryawan(string Namadepan, string Namabelakang, string ktp, decimal Gajimingguan)
        : base(Namadepan, Namabelakang, ktp)
    {
        GajiMingguan = Gajimingguan;
    }
    public decimal GajiMingguan
    {
        get
        {
            return Gajimingguan;
        }
        set
        {
            if (value < 0)
            {
                throw new ArgumentOutOfRangeException(nameof(value),
                    value, $"{nameof(GajiMingguan)} harus >= 0");
            }
            Gajimingguan = value;
        }
    }
    public override decimal Pendapatan() => GajiMingguan;
    public override string ToString() => $"Gaji Karyawan\t\t: {base.ToString()}\n" +
        $"Gaji Mingguan\t\t: {GajiMingguan:C}";
}
class tes_HutangInterface
{
    static void Main()
    {
        var Objekhutang = new List<Hutang>() {
            new Faktur ("01234", "Seat",2,375.00M),
            new Faktur("56789","Tire", 4, 79.95M),
            new GajiKaryawan ("John ","Smith", "111-11-1111", 800.00M),
            new GajiKaryawan("Lisa ", "Barnes", "888-88-8888", 1200.00M)};
        Console.WriteLine("Faktur dan Karyawan diproses polymorphitally:\n");
        foreach (var hutang in Objekhutang)
        {
            Console.WriteLine($"{hutang}");
            Console.WriteLine($"Tanggal Jatuh Tempo\t: {hutang.DapatkanJumlahPembayaran():C}\n");
        }
    }
}