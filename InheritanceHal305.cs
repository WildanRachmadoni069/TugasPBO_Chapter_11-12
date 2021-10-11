using System;
public class KomisiKaryawan : object
{
	public string NamaDepan { get; }
	public string NamaBelakang { get; }
	public string KTP { get; }
	private decimal penjualanKotor; // penjualan mingguan kotor
	private decimal tingkatKomisi; // persentase komisi
								   // konstruktor lima parameter
	public KomisiKaryawan(string namaDepan, string namaBelakang, string ktp, decimal penjualanKotor, decimal tingkatKomisi)
	{
		// panggilan implisit ke konstruktor objek terjadi di sini 
		NamaDepan = namaDepan;
		NamaBelakang = namaBelakang;
		KTP = ktp;
		PenjualanKotor = penjualanKotor; // memvalidasi penjualan kotor
		TingkatKomisi = tingkatKomisi; // memvalidasi tingkat komisi
	}
	public decimal PenjualanKotor
	{
		get
		{
			return penjualanKotor;
		}
		set
		{
			if (value < 0) // memvalidasi
			{
				throw new ArgumentOutOfRangeException(nameof(value), value, $"{nameof(PenjualanKotor)} must be >= 0");
			}
			penjualanKotor = value;
		}
	}
	// properti yang mendapatkan dan menetapkan tingkat komisi komisi karyawan
	public decimal TingkatKomisi
	{
		get
		{
			return tingkatKomisi;
		}
		set
		{
			if (value <= 0 || value >= 1) // memvalidasi
			{
				throw new ArgumentOutOfRangeException(nameof(value),
				value, $"{nameof(TingkatKomisi)} must be > 0 and < 1");
			}
			tingkatKomisi = value;
		}
	}
	// menghitung komisi gaji karyawan
	public decimal Pendapatan() => tingkatKomisi * penjualanKotor;
	// return string representasi objek KomisiKaryawan
	public override string ToString() =>
		$"Komisi Karyawan\t: {NamaDepan} {NamaBelakang}\n" +
		$"Nomor KTP\t: {KTP}\n" +
		$"Penjualan Kotor\t: {penjualanKotor:C}\n" +
		$"Tingkat Komisi\t: {tingkatKomisi:F2}";
}
class TesKomisiKaryawan
{
	static void Main()
	{
		// instansi objek KomisiKaryawan
		var karyawan = new KomisiKaryawan("Sue", "Jones", "222-22-2222", 10000.00M, .06M);
		// menampilkan data KomisiKaryawan
		Console.WriteLine("Informasi karyawan yang diperoleh berdasarkan properti dan metode: \n");
		Console.WriteLine($"Nama depan adalah {karyawan.NamaDepan}");
		Console.WriteLine($"Nama Belakang adalah {karyawan.NamaBelakang}");
		Console.WriteLine($"Nomor KTP : {karyawan.KTP}");
		Console.WriteLine($"Penjualan kotor adalah {karyawan.PenjualanKotor:C}");
		Console.WriteLine($"Tingkat komisi adalah {karyawan.TingkatKomisi:F2}");
		Console.WriteLine($"Pendapatan adalah {karyawan.Pendapatan():C}");
		karyawan.PenjualanKotor = 5000.00M; // set penjualan kotor 
		karyawan.TingkatKomisi = .1M; // set tingkat komisi
		Console.WriteLine("\nInformasi karyawan yang diperbarui yang diperoleh dari ToString:\n");
		Console.WriteLine(karyawan);
		Console.WriteLine($"Pendapatan\t: {karyawan.Pendapatan():C}");
		Console.ReadLine();
	}
}
