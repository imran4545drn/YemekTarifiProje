﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data.SqlClient;

public partial class YemekDetay : System.Web.UI.Page
{
    SqlSinif bgl = new SqlSinif();
    string yemekid = "";
    protected void Page_Load(object sender, EventArgs e)
    {
        yemekid = Request.QueryString["Yemekid"];
        SqlCommand komut = new SqlCommand("Select YemekAd From Yemekler where Yemekid=@p1", bgl.baglanti());
        komut.Parameters.AddWithValue("@p1", Convert.ToInt16(yemekid));
        SqlDataReader dr = komut.ExecuteReader();
        while (dr.Read())
        {
            Label3.Text = dr[0].ToString();
        }
        bgl.baglanti().Close();

        SqlCommand komut2 = new SqlCommand("select * from Yorumlar where Yemekid=@p2", bgl.baglanti());
        komut2.Parameters.AddWithValue("@p2", Convert.ToInt16(yemekid));
        SqlDataReader dr2 = komut2.ExecuteReader();
        DataList2.DataSource = dr2;
        DataList2.DataBind();

    }

    protected void Button1_Click(object sender, EventArgs e)
    {
        SqlCommand komut = new SqlCommand("insert into Yorumlar (YorumAdSoyad,YorumMail,Yorumİcerik,Yemekid) values (@p1,@p2,@p3,@p4)", bgl.baglanti());
        komut.Parameters.AddWithValue("@p1", TextBox1.Text);
        komut.Parameters.AddWithValue("@p2", TextBox2.Text);
        komut.Parameters.AddWithValue("@p3", TextBox3.Text);
        komut.Parameters.AddWithValue("@p4", Convert.ToInt16(yemekid));
        komut.ExecuteNonQuery();
        bgl.baglanti().Close();
    }
}