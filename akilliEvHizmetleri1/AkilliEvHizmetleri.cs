﻿using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace akilliEvHizmetleri1
{
    internal class AkilliEvHizmetleri
    {
        SqlConnection baglanti = new SqlConnection("Data Source=VICTUS\\SQLEXPRESS01;Initial Catalog=akilliEvHizmetleri;Integrated Security=True");
        DataTable tablo;
        public void ekle_sil_güncelle(SqlCommand komut,string sorgu)
        {
            baglanti.Open();
            komut.Connection=baglanti;
            komut.CommandText=sorgu;
            komut.ExecuteNonQuery();
            baglanti.Close();
        }
        public DataTable listele(SqlDataAdapter adtr,string sorgu)
        {
            tablo = new DataTable();
            adtr = new SqlDataAdapter(sorgu, baglanti);
            adtr.Fill(tablo);
            baglanti.Close();
            return tablo;
        }
    }
}