using System;
using System.Reflection.Emit;
using System.Reflection.Metadata.Ecma335;
public class Agen
{
    public string id_agen;
    public string nama_agen ;

    public int stok_agen;

    public Agen(string IdAgen, string NamaProduk, int StokProduk)
    {
        this.id_agen = IdAgen;
        this.nama_agen = NamaProduk;
        this.stok_agen = StokProduk;
    }

    public void tampil_info()
    {
        Console.WriteLine($"ID Agen : {this.id_agen}");
        Console.WriteLine($"Nama Agen : {this.nama_agen}");
        Console.WriteLine($"Stok Agen : {this.stok_agen}");
    }

}

abstract class ProdukGalon
{
    private string id_produk;
    private string nama_produk;
    private int stok_gudang;

    public int biaya;
    public int StokGudang
    {
        get { return stok_gudang; }
        set
        {
            if (StokGudang <= 0)
            {
                stok_gudang = StokGudang;
            }
            else
            {
                Console.WriteLine("Stok Gudang Tidak Boleh Nol");
            }
        }
    }
    public ProdukGalon(String IdProduk, string NamaProduk, int stokGudang)
    {
        this.nama_produk = NamaProduk;
        this.id_produk = IdProduk;
        this.stok_gudang = stokGudang;
    }

    public void kurangi_stok(int jumlah)
    {
        this.stok_gudang -= jumlah;
    }

    public virtual void hitung_biaya(int jumlah)
    {
        this.biaya = 100000;
    }

}

class GalonAkua : ProdukGalon
{
    public override void hitung_biaya(int jumlah)
    {
        this.biaya = jumlah * 20000;
    }
}


class GalonBerkeran : ProdukGalon
{
    public override void hitung_biaya(int jumlah)
    {
        this.biaya = jumlah * 12000;
    }
}


interface IDapatDidistribusikan
{
    public void KirimPaket (int jumlah, string penerima) { }
}

public class distribusi_galon : IDapatDidistribusikan
{
    string agen_tujuan;
    string produk_galon;
    int jumlah_galon;

    public void KirimPaket(int jumlah, string penerima)
    {
    if (jumlah <= 0)
        {
            Console.WriteLine("Jumlah Galon yang dikirim tidak 0");
        }
        else if (this.jumlah_galon > jumlah)
        {
            Console.WriteLine("Jumlah Galon yang dikirim tidak boleh melebihi stok yang tersedia");
        }
        else
        {
            this.jumlah_galon -= jumlah;
        
        }
    }
}


class Program
{
    static void Main()
    {
        Agen agen1 = new Agen("ID001", "Joko", 12);
        agen1.tampil_info();

        Agen agen2 = new Agen("ID002", "JoJo", 24);
        agen2.tampil_info();

        GalonAkua GalonJojo = new GalonAkua("G87", "Galon Ori", 60);
        GalonJojo.hitung_biaya();
        GalonBerkeran GalonJoko = new GalonBerkeran("G29", "Galon Isian", 90);
        GalonJoko.hitung_biaya();
    }
}



