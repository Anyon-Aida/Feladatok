using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MySql.Data.MySqlClient;
using System.Data;
using System.IO;

namespace Feladat_2
{
    class Program
    {
        MySqlConnection connect = new MySqlConnection("server=localhost;user id=root;database=cs_beugro;");
        public void OpenConncetion()
        {
            connect.Open();
        }
        public void CloseConncetion()
        {
            connect.Close();
        }
        static void Main(string[] args)
        {
            //2.feladat
            int[] random = new int[10];
            Random rnd = new Random();
            int szam;
            for (int a = 0; a < random.Length; a++)
            {
                do
                {
                    szam = rnd.Next(1, 51);
                } while (random.Contains(szam));
                random[a] = szam;
            }
            //3.feladat
            string[] adat = File.ReadAllLines("olvass.txt", Encoding.Default);
            //3.1 3.2 feladat
            List<int> key = new List<int>();
            double[] value = new double[adat.Length];
            for (int a = 1; a < adat.Length; a++)
            {
                try
                {
                    value[a] = int.Parse(adat[a].Split('|')[1]);
                }
                catch (Exception) { }
                if (value[a] != 0 && value[a] > 0 && value[a]%1==0) 
                {
                    key.Add(int.Parse(adat[a].Split('|')[0]));
                }

            }
            //kiíratas
            Program c = new Program();
            c.OpenConncetion();
            DataTable dt = new DataTable();
            MySqlDataAdapter da = new MySqlDataAdapter("select id from user",c.connect);

            da.Fill(dt);

            //MySqlCommand view = new MySqlCommand(query, c.connect);
            string id_data = ""; 
            for (int a = 0; a <= key.Count; a++) 
            {
                foreach (DataRow row in dt.Rows)
                {
                    Console.WriteLine(row["id"]);
                    if (key[a].Equals(row["id"])) { id_data += "'{0}'" + key[a]; }
                    if (a <= key.Count - 1) { id_data += ","; }
                }
            }
            string query = "select id,name from user where id in (" + id_data + ")";
            Console.WriteLine(id_data);
            /*
            MySqlCommand view = new MySqlCommand(query, c.connect);
            MySqlDataReader dr = view.ExecuteReader();
            while (dr.Read())
            {
                Console.Write(dr.GetValue(0).ToString() + "  ");
                Console.Write(dr.GetValue(1).ToString() + "\n", Encoding.UTF8);
            }
            */
            c.CloseConncetion();
            Console.ReadLine();
        }
    }
}
