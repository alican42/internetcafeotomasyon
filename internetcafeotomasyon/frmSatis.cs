using Microsoft.Data.SqlClient;
using System.Data;

namespace internetcafeotomasyon
{
    public partial class frmSatis : Form
    {
        
        SqlConnection baglanti = new SqlConnection("Data Source=localhost\\SQLEXPRESS;Initial Catalog=InternetCafe2;Integrated Security=True;Pooling=False;Encrypt=False;Trust Server Certificate=False");
        public frmSatis()
        {
            InitializeComponent();
        }

        private void button21_Click(object sender, EventArgs e)
        {

        }
        Button btn;
        private void SecileneGore(object sender, MouseEventArgs e)
        {
            btn = sender as Button;

        }
        RadioButton radio;
        private void RadioButtonSeciliyeGore(object sender, EventArgs e)
        {
            radio = sender as RadioButton;
        }
        private void frmSatis_Load(object sender, EventArgs e)
        {
            radioButtonSuresiz.Checked = true;
            Yenile();
            comboBosMasalar.Text = "";
        }

        private void Yenile()
        {
            baglanti.Open();
            SqlDataAdapter adtr = new SqlDataAdapter("select *from tblmasalar where durumu = 'Boþ'", baglanti);
            DataTable tbl = new DataTable();
            adtr.Fill(tbl);
            comboBosMasalar.DataSource = tbl;
            comboBosMasalar.DisplayMember = "Masalar";
            comboBosMasalar.ValueMember = "MasaID";
            baglanti.Close();
            foreach (Control item in Controls)
            {
                if (item is Button)
                {
                    if (item.Name != btnMasaAc.Name)
                    {
                        baglanti.Open();
                        SqlCommand komut = new SqlCommand("select *from tblmasalar", baglanti);
                        SqlDataReader dr = komut.ExecuteReader();
                        while (dr.Read())
                        {
                            if (dr["durumu"].ToString() == "BOÞ" && dr["Masalar"].ToString() == item.Text)
                            {

                                item.BackColor = Color.LightGreen;

                            }

                            if (dr["durumu"].ToString() == "DOLU" && dr["Masalar"].ToString() == item.Text)
                            {

                                item.BackColor = Color.OrangeRed;

                            }


                        }
                        baglanti.Close();



                    }
                }
            }
        }
    }
}

