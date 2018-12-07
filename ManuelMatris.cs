using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Microsoft.VisualBasic;

namespace yazLab
{
    public partial class ManuelMatris : Form
    {
        int boyut1, boyut2;
        int i = 0, j = 0;
        double[,] matrix = new double[7,7];
        int toplam_sayisi = 0;
        int carpim_sayisi = 0;
        public ManuelMatris()
        {
            InitializeComponent();
            toplam_sayisi = 0;
            carpim_sayisi = 0;
            toplamcarpimlabel.Text = "";
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (sutun.Text != "" || satir.Text != "")
            {
                int tmp;
                if (int.TryParse(satir.Text, out tmp) && int.TryParse(sutun.Text, out tmp))
                {
                    boyut1 = Int32.Parse(satir.Text);
                    boyut2 = Int32.Parse(sutun.Text);
                    if (boyut1 < 1 || boyut1 > 5)
                        hatalabel.Text = "Satir sayisi 1 ile 5 arasında olmalıdır.";
                    else if (boyut2 < 1 || boyut2 > 5)
                        hatalabel.Text = "Sutun sayisi 1 ile 5 arasında olmalıdır.";
                    else if (boyut1 < 1 || boyut1 > 5 && boyut2 < 1 || boyut2 > 5)
                        hatalabel.Text = "Boyutları 1 ile 5 arasında girin.";
                    else if (boyut1 == boyut2)
                        hatalabel.Text = "Boyutlar aynı olamaz.";
                    else
                    {
                        sutun.Visible = false;
                        label2.Visible = false;
                        label1.Text = "Matrisin 1.1. elemanını girin:";
                        button1.Visible=false;
                        button2.Visible=true;
                        hatalabel.Text = "";
                        satir.Text = "";
                    }
                }
                else
                {
                    hatalabel.Text = "Sayı giriniz.";
                }
            }
            else
            {
                hatalabel.Text = "Giriş yapmalısınız.";
            }

        }

        private void button2_Click(object sender, EventArgs e)
        {
            int sayac = boyut1 * boyut2;
            if (satir.Text != "")
            {
                int tmp;
                if (int.TryParse(satir.Text, out tmp))
                {
                    if (Double.Parse(satir.Text) > 0.9 && Double.Parse(satir.Text) < 9.1)
                    {
                        matrix[i,j] = Double.Parse(satir.Text);
                        j++;
                        if (j == boyut2)
                        {
                            j = 0;
                            i++;
                        }
                        if (i * boyut2 == sayac)
                        {
                            double[,] matris = new double[boyut1,boyut2];
                            for (int i = 0; i < boyut1; i++)
                            {
                                for (int j = 0; j < boyut2; j++)
                                {
                                    matris[i, j] = matrix[i, j];
                                }
                            }
                            button2.Visible = false;
                            label1.Visible = false;
                            satir.Visible = false;
                            hatalabel.Visible = false;
                            tablo.Visible = true;
                            label3.Visible = true;
                            label4.Visible = true;
                            label5.Visible = true;
                            button3.Visible = true;
                            label6.Visible = true;
                            label7.Visible = true;
                            label8.Visible = true;
                            tabloters.Visible = true;


                          
                            if (boyut1 > boyut2)
                            {
                                tablo.ColumnCount = boyut2;
                                tablo.RowCount = boyut1;
                                tablotranspoz.ColumnCount = boyut1;
                                tablotranspoz.RowCount = boyut2;
                                tablocarpimtranspoz.ColumnCount = boyut2;
                                tablocarpimtranspoz.RowCount = boyut2;
                                tabloters.ColumnCount = boyut2;
                                tabloters.RowCount = boyut2;
                                terstranspozcarpim.ColumnCount = boyut1;
                                terstranspozcarpim.RowCount = boyut2;
                                sozdetersmatriscarpim.ColumnCount = boyut2;
                                sozdetersmatriscarpim.RowCount = boyut2;
                            }
                            else
                            {
                                tablo.ColumnCount = boyut2;
                                tablo.RowCount = boyut1;
                                tablotranspoz.ColumnCount = boyut1;
                                tablotranspoz.RowCount = boyut2;
                                tablocarpimtranspoz.ColumnCount = boyut1;
                                tablocarpimtranspoz.RowCount = boyut1;
                                tabloters.ColumnCount = boyut1;
                                tabloters.RowCount = boyut1;
                                terstranspozcarpim.ColumnCount = boyut1;
                                terstranspozcarpim.RowCount = boyut1;
                                sozdetersmatriscarpim.ColumnCount = boyut2;
                                sozdetersmatriscarpim.RowCount = boyut2;
                            }

                            for (int i = 0; i < boyut1; i++)
                            {
                                for (int j = 0; j < boyut2; j++)
                                {
                                    tablo.Rows[i].Cells[j].Value = matris[i,j];
                                    tablo.Rows[i].DefaultCellStyle.BackColor = Color.White;
                                }
                            }

                            double[,] transpoz = Transpoz(matris);
                            double[,] transpozcarpim;
                            for (int i = 0; i < boyut2; i++)
                            {
                                for (int j = 0; j < boyut1; j++)
                                {
                                    tablotranspoz.Rows[i].Cells[j].Value = transpoz[i, j];
                                    tablotranspoz.Rows[i].DefaultCellStyle.BackColor = Color.White;
                                }
                            }
                            if (boyut1 > boyut2)
                            {
                                transpozcarpim = Carpim(transpoz, matris);
                                for (int i = 0; i < transpozcarpim.GetLength(0); i++)
                                {
                                    for (int j = 0; j < transpozcarpim.GetLength(1); j++)
                                    {
                                        tablocarpimtranspoz.Rows[i].Cells[j].Value = transpozcarpim[i, j];
                                        tablocarpimtranspoz.Rows[i].DefaultCellStyle.BackColor = Color.White;
                                    }
                                }
                            }
                            else
                            {
                                transpozcarpim = Carpim(matris, transpoz);
                                for (int i = 0; i < transpozcarpim.GetLength(1); i++)
                                {
                                    for (int j = 0; j < transpozcarpim.GetLength(0); j++)
                                    {
                                        tablocarpimtranspoz.Rows[i].Cells[j].Value = transpozcarpim[i, j];
                                        tablocarpimtranspoz.Rows[i].DefaultCellStyle.BackColor = Color.White;
                                    }
                                }

                            }
                            for (int i = 0; i < transpozcarpim.GetLength(0); i++)
                            {
                                for (int j = 0; j < transpozcarpim.GetLength(1); j++)
                                {
                                    tablocarpimtranspoz.Rows[i].Cells[j].Value = transpozcarpim[i, j];
                                    tablocarpimtranspoz.Rows[i].DefaultCellStyle.BackColor = Color.White;
                                }
                            }
                            double[,] ters;
                            if (boyut1 > boyut2)
                            {
                                ters = TersiniAl(transpozcarpim, boyut2);
                                for (int i = 0; i < boyut2; i++)
                                {
                                    for (int j = 0; j < boyut2; j++)
                                    {
                                        tabloters.Rows[i].Cells[j].Value = Math.Round(ters[i, j], 2);
                                        tabloters.Rows[i].DefaultCellStyle.BackColor = Color.White;
                                    }
                                }
                            }
                            else
                            {
                                ters = TersiniAl(transpozcarpim, boyut1);
                                for (int i = 0; i < boyut1; i++)
                                {
                                    for (int j = 0; j < boyut1; j++)
                                    {
                                        tabloters.Rows[i].Cells[j].Value = Math.Round(ters[i, j], 2);
                                        tabloters.Rows[i].DefaultCellStyle.BackColor = Color.White;
                                    }
                                }

                            }
                            double[,] terscarpimtranspoz;
                            if (boyut1 > boyut2)
                            {
                                terscarpimtranspoz = Carpim(ters, transpoz);
                                for (int i = 0; i < boyut2; i++)
                                {
                                    for (int j = 0; j < boyut1; j++)
                                    {
                                        terstranspozcarpim.Rows[i].Cells[j].Value = Math.Round(terscarpimtranspoz[i, j], 2);
                                        terstranspozcarpim.Rows[i].DefaultCellStyle.BackColor = Color.White;
                                    }
                                }
                            }
                            else
                            {
                                terscarpimtranspoz = Carpim(transpoz, ters);
                                for (int i = 0; i < boyut1; i++)
                                {
                                    for (int j = 0; j < boyut1; j++)
                                    {
                                        terstranspozcarpim.Rows[i].Cells[j].Value = Math.Round(terscarpimtranspoz[i, j], 2);
                                        terstranspozcarpim.Rows[i].DefaultCellStyle.BackColor = Color.White;
                                    }
                                }
                            }
                            double[,] sozdeterscarpimatris = Carpim(terscarpimtranspoz, matris);
                            for (int i = 0; i < boyut2; i++)
                            {
                                for (int j = 0; j < boyut2; j++)
                                {
                                    sozdetersmatriscarpim.Rows[i].Cells[j].Value = Math.Round(sozdeterscarpimatris[i, j], 2);
                                    sozdetersmatriscarpim.Rows[i].DefaultCellStyle.BackColor = Color.White;
                                }

                            }





                           toplamcarpimlabel.Text = "Toplama-Çıkarma sayısı:" + toplam_sayisi + "\nBölme-Çarpma sayısı:" + carpim_sayisi;



                        }
                        label1.Text = "Matrisin " + (i + 1) + "." + (j + 1) + ". elemanını girin:";
                        hatalabel.Text = "";
                        satir.Text = "";
                    }
                    else
                        hatalabel.Text = "1 ile 9 arasında bir sayı girin.";
                }
                else
                    hatalabel.Text = "Lütfen sayı girin.";
            }
            else
            hatalabel.Text = "Lütfen boş bırakmayın.";
        }

        public double[,] Transpoz(double[,] matris)
        {
            double[,] transpoz = new double[boyut2,boyut1];
            for (int i = 0; i < boyut1; i++)
            {
                for (int j = 0; j < boyut2; j++)
                {
                    transpoz[j, i] = matris[i, j];
                }
            }
            return transpoz;
        }
        public double[,] Carpim(double[,] matrix, double[,] matris2)
        {
            double[,] carpim = new double[matrix.GetLength(0), matris2.GetLength(1)];
            double toplam = 0;
            for (int i = 0; i < matrix.GetLength(0); i++)
            {
                for (int j = 0; j < matris2.GetLength(1); j++)
                {
                    toplam = 0;
                    for (int k = 0; k < matrix.GetLength(1); k++)
                    {
                        toplam += matrix[i, k] * matris2[k, j];
                        carpim_sayisi++;
                        toplam_sayisi++;
                    }
                    carpim[i, j] = toplam;
                }
            }
            return carpim;
        }
        public double[,] TersiniAl(double[,] matris, int boyut)
        {
            double[,] tmp = new double[boyut, boyut];
            for (int i = 0; i < boyut; i++)
            {
                for (int j = 0; j < boyut; j++)
                {
                    if (i == j)
                        tmp[i, j] = 1;
                    else
                        tmp[i, j] = 0;
                }
            }
            double x, y;
            for (int i = 0; i < boyut; i++)
            {
                x = matris[i, i];
                for (int j = 0; j < boyut; j++)
                {
                    matris[i, j] = matris[i, j] / x;
                    tmp[i, j] = tmp[i, j] / x;
                    carpim_sayisi = carpim_sayisi + 2;
                }
                for (int k = 0; k < boyut; k++)
                {
                    if (k != i)
                    {
                        y = matris[k, i];
                        for (int j = 0; j < boyut; j++)
                        {
                            matris[k, j] = matris[k, j] - (matris[i, j] * y);
                            tmp[k, j] = tmp[k, j] - (tmp[i, j] * y);
                            carpim_sayisi = carpim_sayisi + 2;
                            toplam_sayisi = toplam_sayisi + 2;
                        }
                    }
                }
            }
            return tmp;
        }
        private void button3_Click(object sender, EventArgs e)
        {
            this.Hide();
            GirisEkrani gr = new GirisEkrani();
            gr.Show();
        }

        


        private void ManuelMatris_FormClosed(object sender, FormClosedEventArgs e)
        {
            Application.Exit();
        }
    }
}
