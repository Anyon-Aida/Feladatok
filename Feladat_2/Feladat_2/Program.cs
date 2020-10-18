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
            //+debug
            if (File.Exists(@"Kiválasztottak.txt"))
            {
                Console.WriteLine("A szoftvert már egyszer lefutattad!");
                Console.ReadLine();
                Environment.Exit(0);
            }
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
            int[] value = new int[adat.Length];
            for (int a = 1; a < adat.Length; a++)
            {
                try
                {
                    value[a] = int.Parse(adat[a].Split('|')[1]);
                }
                catch (Exception) { }
                if (value[a] > 0) 
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

            /*MySqlCommand view = new MySqlCommand(query, c.connect);
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
            */
            string query2 = "select id,brand,model from car";
            string query = "select user, user.name,car.brand,car.model from ((user_car inner join car on user_car.car = car.id) inner join user on user_car.user = user.id)";

            MySqlCommand view = new MySqlCommand(query, c.connect);
            MySqlCommand view2 = new MySqlCommand(query2, c.connect);
            List<string> szamok = new List<string>();
            List<string> nevek = new List<string>();
            List<string> brand = new List<string>();
            List<string> model = new List<string>();
            MySqlDataReader dr = view.ExecuteReader();
            while (dr.Read())
            {
                szamok.Add(dr.GetValue(0).ToString());
                nevek.Add(dr.GetValue(1).ToString());
                brand.Add(dr.GetValue(2).ToString());
                model.Add(dr.GetValue(3).ToString());
            }
            //key.ForEach(Console.WriteLine);
            StreamWriter feltoltes = new StreamWriter("Kiválasztottak.txt");
            for (int a = 0; a <= szamok.Count-1; a++) 
            {
                for (int b = 0; b <= key.Count-1; b++)
                {
                    if (key[b] == int.Parse(szamok[a])) { feltoltes.WriteLine("{0}\t{1}\t{2}", nevek[a], brand[a], model[a], Encoding.UTF8); }
                }
            }
            Console.WriteLine("Feltöltés sikeres!");
            feltoltes.Close();
            c.CloseConncetion();
            Console.ReadLine();
        }
    }
}
