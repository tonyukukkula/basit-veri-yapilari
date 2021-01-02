using System;

namespace tonyukukkula
{
    class Program
    {
            static void Main(string[] args)
            {
            int x, sayı;
            Console.Write("Standart Sapmasını hesaplamak istediğiniz sayıların boyutunu giriniz:");
            x = Convert.ToInt32(Console.ReadLine());

            double[] dizi = new double[x];
            for (int i = 0; i < x; i++)
            {
                Console.Write(i + 1 + ". Sayıyı giriniz:");
                sayı = Convert.ToInt32(Console.ReadLine());
                dizi[i] = sayı;
            }

            Console.WriteLine("Sapma_recursive: " +standart_sapma(dizi, x));
            Console.WriteLine("Sapma_recursive_ort: " + ort(dizi, x));
            Console.WriteLine("Sapma_recursive_Varyans: " + (varyans(dizi, x, x-1)/2));
            Console.WriteLine("Sapma_iterative_Varyans: " + Varyans(dizi));
            Console.WriteLine("Sapma_iterative: " + standartSapma(dizi));
            Console.WriteLine();
            Console.WriteLine("Hello World!");
            }
            public static float ort(double[] a, int a_length)
            {
                float sum = 0, mean;
                for (int i = 0; i < a_length; i++)
                    sum += (float)a[i];
                mean = sum / a_length;
                return mean;
            }
            public static float varyans(double[] a, int a_length, int max_indis)
            {
                float k=0;
                if (max_indis >= 1)
                {
                    k = (float)(a[max_indis] - ort(a, a_length)) * (float)(a[max_indis] - ort(a ,a_length));

                }
                if (max_indis == 0)
                {
                    return (float)(a[max_indis] - ort(a, a_length)) * (float)(a[max_indis] - ort(a, a_length));
                }
                else
                {
                    return k + varyans(a, a_length,max_indis - 1);
                }
            }
            public static float standart_sapma(double[] a, int a_length)
            {
            float veryansın = varyans(a, a_length, a_length - 1) / (a_length - 1);
            return (float)Math.Sqrt(veryansın);
            }
        public static double Varyans(double[] dizi) 
        {
            double toplam = 0;

            for (int i = 0; i < dizi.Length; i++)
            {
                toplam += dizi[i];
            }
            double ortalama = toplam / (double)dizi.Length;
            double varyans = 0;

            for (int i = 0; i < dizi.Length; i++)
            {
                varyans +=(dizi[i] - ortalama) * (dizi[i] - ortalama);
            }
            return (varyans / (dizi.Length-1));
        }

        public static float standartSapma(double[] dizi) 
        {                                                         
            return (float)Math.Sqrt(Varyans(dizi)); 
        }
    }
}
