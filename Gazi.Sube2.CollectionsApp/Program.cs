using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Gazi.Sube2.CollectionsApp
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.BackgroundColor = ConsoleColor.White;
            Console.ForegroundColor = ConsoleColor.Black;
            Console.Clear();

            #region Collections
            //ArrayList al = new ArrayList();
            //al.Add("2");
            //al.Add(5);
            //al.Add("Ahmet");
            //al.Add("Ahmet");
            //al.Add("Ahmet");
            //al.Add(5);
            //al.Add("Ahmet");
            //al.Add("Ahmet");
            //al.Add("Ahmet");
            //al.Capacity = al.Count;

            //Console.WriteLine(al.Count);
            //Console.WriteLine(al.Capacity);

            //int sayi = (int)al[1];

            //Hashtable ht = new Hashtable();
            //ht.Add(6, "Ankara");
            //ht.Add(34, "İstanbul");
            //ht.Add(44, "Malatya");
            //ht.Add(35, "İzmir");

            //foreach (DictionaryEntry item in ht)
            //{
            //    Console.WriteLine(item.Value);
            //}


            //for (int i = 0; i < al.Count; i++)
            //{
            //    Console.WriteLine(al[i]);
            //}

            //foreach (object item in al)
            //{
            //    Console.WriteLine(item);
            //}

            // Queue q = new Queue();
            // q.Enqueue("Mümin");
            // q.Enqueue("Furkan");
            // q.Enqueue("Uğur");

            //// Console.WriteLine(q.Peek());

            // q.Dequeue();
            // foreach (object item in q)
            // {
            //     Console.WriteLine(item);
            // }

            //Stack s = new Stack();
            //s.Push("Tabak1");
            //s.Push("Tabak2");
            //s.Push("Tabak3");

            //s.Pop();

            //foreach (object item in s)
            //{
            //    Console.WriteLine(item);
            //}

            //Non-Generic
            //Generic Collections

            //Generic Yapılar
            //Deneme<int,string> d = new Deneme<int, string>();
            //d.sayi1 = 5;
            //d.sayi2 = "6";

            //List<int> lst = new List<int>();
            //lst.Add(5);
            //lst.Add(10);

            //foreach (var item in lst)
            //{
            //    Console.WriteLine(item);
            //} 
            #endregion

            //using (OkulContext ctx=new OkulContext())
            //{
            //    ctx.tblSiniflars.Add(new tblSiniflar { SinifAd = "8-A", Kontenjan = 25 });
            //    ctx.SaveChanges();
            //}

            //using (OkulContext ctx = new OkulContext())
            //{
            //    tblSiniflar s = ctx.tblSiniflars.Find(8);
            //    s.Kontenjan = 30;
            //    ctx.SaveChanges();
            //}

            //using (OkulContext ctx = new OkulContext())
            //{  
            //    ctx.tblSiniflars.Remove(ctx.tblSiniflars.Find(8));
            //    ctx.SaveChanges();
            //}

            //using (OkulContext ctx=new OkulContext())
            //{
            //    List<tblSiniflar> lst = ctx.tblSiniflars.ToList();

            //    foreach (tblSiniflar sinif in lst)
            //    {
            //        Console.WriteLine($"Sınıf Adı:{sinif.SinifAd} Kontenjan:{sinif.Kontenjan}");
            //    }
            //}

            //using (OkulContext ctx=new OkulContext())
            //{//Eager Loading
            //    List<tblOgrenciler> lst = ctx.tblOgrencilers.Include("tblSiniflars").ToList();
            //    foreach (tblOgrenciler ogr in lst)
            //    {
            //        Console.WriteLine($"Öğrenci Adı:{ogr.Ad}\nSoyadı:{ogr.Soyad}\nSınıfı:{ogr.tblSiniflar.SinifAd}\n-----------------------");
            //    }
            //}

            using (OkulContext ctx=new OkulContext())
            {
                foreach (var sinif in ctx.tblSiniflars.Include("tblOgrencilers"))
                {
                    Console.WriteLine($"Sınıf Adı:{sinif.SinifAd}");
                    foreach (var ogrenci in sinif.tblOgrencilers)
                    {
                        Console.WriteLine($"\tOgrenci Adı:{ogrenci.Ad}");
                    }
                }
            }


            Console.ReadKey();
        }
    }

    //Generic Constraint-Kısıtlayıcı
    class Deneme<T, M> where T : struct where M : struct
    {
        public T sayi1;
        public M sayi2;
    }
}
