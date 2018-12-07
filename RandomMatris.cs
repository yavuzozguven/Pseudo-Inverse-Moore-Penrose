using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace yazLab
{
    public partial class RandomMatris : Form
    {
        int toplama_sayisi = 0;
        int carpma_sayisi = 0;
        public RandomMatris()
        {
            InitializeComponent();
            Random rast = new Random();
            int boyut1, boyut2;
            label7.Text = "";
            double sayi;
            do
            {
                boyut1 = rast.Next() % 6;
            } while (boyut1 == 0);
            do
            {
                boyut2 = rast.Next() % 6;
            } while (boyut2 == 0 || boyut2 == boyut1);
            double[,] matris = new double[boyut1, boyut2];
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
                    do
                    {
                        sayi = rast.NextDouble() * 10;
                        sayi = Math.Round(sayi, 1);
                    } while (sayi < 1 || sayi > 9);
                    matris[i, j] = sayi;
                    tablo.Rows[i].Cells[j].Value = sayi;
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

            label7.Text = "Toplama-Çıkarma sayısı:" + toplama_sayisi + "\nBölme-Çarpma sayısı:" + carpma_sayisi;
        }








        private void RandomMatris_FormClosed(object sender, FormClosedEventArgs e)
        {
            Application.Exit();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.Hide();
            GirisEkrani gr = new GirisEkrani();
            gr.Show();
        }
        public double[,] Transpoz(double[,] matris)
        {
            double[,] transpoz = new double[matris.GetLength(1), matris.GetLength(0)];
            for (int i = 0; i < matris.GetLength(0); i++)
            {
                for (int j = 0; j < matris.GetLength(1); j++)
                {
                    transpoz[j,i] = matris[i,j];
                }
            }
            return transpoz;
        }
        public double[,] Carpim(double[,] matris,double[,] matris2)
        {
            double[,] carpim = new double[matris.GetLength(0), matris2.GetLength(1)];
            double toplam = 0;
            for (int i = 0; i < matris.GetLength(0); i++)
            {
                for (int j = 0; j < matris2.GetLength(1); j++)
                {
                    toplam = 0;
                    for (int k = 0; k < matris.GetLength(1); k++)
                    {
                        toplam += matris[i, k] * matris2[k, j];
                        carpma_sayisi++;
                        toplama_sayisi++;
                    }
                    carpim[i, j] = toplam;
                }
            }
            return carpim;
        }
        public double[,] TersiniAl(double[,] matris,int boyut)
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
                    carpma_sayisi = carpma_sayisi + 2;
                }
                for (int k = 0; k < boyut; k++)
                {
                    if (k != i)
                    {
                        y = matris[k, i];
                        for (int j = 0; j < boyut; j++)
                        {
                            matris[k, j] = matris[k, j] - (matris[i,j] * y);
                            tmp[k, j] = tmp[k, j] - (tmp[i, j] * y);
                            carpma_sayisi = carpma_sayisi + 2;
                            toplama_sayisi = toplama_sayisi + 2;
                        }
                    }
                }
            }
            return tmp;
        }

    }
}
    