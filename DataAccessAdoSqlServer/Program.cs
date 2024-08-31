using System.Data;
using System.Data.SqlClient;

namespace DataAccessAdoSqlServer
{
    internal class Program
    {
        #region Konu Anlatimi
        /*
         *Butun Database'lere (sql server,postgresql v.b..)
         *kullanilan bazi Ado.NEt class lari vardir.
         *1- SqlConnection
         *2- SqlCommand 
         *3- SqlDataReader
         *
         *Ayrica Ado.net icin tasarlanmis hazir vaziyette gelen
         *Dataset ve DataTable nesneleri de kullanilir.
         * 
         * 
         * 
         */
        #endregion

        static void Main(string[] args)
        {

            List<Shipper> shippers = new List<Shipper>();
            #region SqlConnection
            //SqlConnection=> Bu nesne verilen conectionstring uzerinden
            //veri tabanina baglanir. Burada kritik olan yer ConnectionString cumlesidir.
            // ConnectionString 'leri ogrenmek icin www.connectionstrings.com uzerinde
            // Dunyada var butun database'lerin ConnectionString'leri ogrenilebilir.
            string constr = "Server=.; Database = Northwind; Trusted_Connection = True; TrustServerCertificate=true";
            string adventureWork = "Server=.; Database = AdventureWorks2019; Trusted_Connection = True; TrustServerCertificate=true"; ;
            SqlConnection con = new SqlConnection(constr);

            #endregion
            #region SqlCommand => Bu nesne illaki SqlConnection nesnesine ihtiyac duyar
            // Tek basina calismaz. 
            // Calistigi zamana gerekli sql scriptler yazilarak sonuc beklenir.



            #endregion
            try
            {
                con.Open();

                SqlCommand cmd = new SqlCommand();
                cmd.Connection = con;

                #region SqlVEriOkuma
                //                cmd.CommandText = "Select * from Shippers";
                //                SqlDataReader rdr = cmd.ExecuteReader();

                //                while (rdr.Read())
                //                {
                //                    Shipper shipper = new Shipper();
                //                    shipper.ShipperId = int.Parse(rdr[0].ToString());
                //                    shipper.CompanyName = rdr[1].ToString();
                //                    shipper.Phone = rdr[2].ToString();
                //                    shippers.Add(shipper);
                //                }
                //                shippers.ForEach(shipper => Console.WriteLine(shipper.ShipperId + " " + shipper.CompanyName + " " + shipper.Phone));
                #endregion
                //Console.WriteLine("Durum:" + con.State);
                //Console.WriteLine(rdr["ShipperId"]+ " " + rdr["CompanyNAme"] + " " + rdr["Phone"] );
                //

                #region Crud işlemi
                //Create =>Insert
                //string insertSql = "Insert into Shippers (CompanyName,Phone) values ('Yurtici Kargo','444 4644') ";
                ////string updateSql = "Update Shippers set Phone='444 99 88' where CompanyName='Yurtici Kargo'";
                ////string deleteSql = "Delete Shippers where CompanyName='Yurtici Kargo'";
                //cmd.CommandText = insertSql;
                //int sonuc = cmd.ExecuteNonQuery();
                //if ( sonuc > 0 )
                //{
                //    Console.WriteLine(" işlem başarılı");
                //}
                //else
                //{
                //    Console.WriteLine("işlem başarısız");
                //}
                #endregion
                #region DataSet,DataTable,SqlDataAdaptor Kullanımı
                cmd.CommandText = "Select * from Shippers";
                SqlDataAdapter adapter = new SqlDataAdapter(cmd);
                DataSet ds = new DataSet(); //Database'e karşılık gelen nesnedir
                DataTable table = new DataTable(); //Database de tabloya karsılık gelen nesne

                adapter.Fill(ds);
                adapter.Fill(table);
                #endregion 

            }

            catch (Exception ex)
            {
                Console.WriteLine("Hata :" + ex.Message);
            }
            finally
            {
                if (con.State == System.Data.ConnectionState.Open)
                    con.Close();
            }


            Console.WriteLine("Hello, World!");
        }
    }
    public struct Shipper
    {
        public int ShipperId;
        public string CompanyName;
        public string Phone;
    }
}
