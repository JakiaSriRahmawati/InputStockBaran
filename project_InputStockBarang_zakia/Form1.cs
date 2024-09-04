using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using MySql.Data.MySqlClient;

namespace project_InputStockBarang_zakia
{
    public partial class Form1 : Form
    {
        string database = ("server=localhost; uid=root; database=db_barang1; pwd='';");
        public MySqlConnection koneksi;
        public MySqlCommand cmd;
        public MySqlDataAdapter adp;
        public Form1()
        {
            InitializeComponent();
        }
        public void konek()
        {
            koneksi = new MySqlConnection(database);
            koneksi.Open();
        }
        public void disconek()
        {
            koneksi = new MySqlConnection(database);
            koneksi.Close();
        }
        public DataTable TampilData()
        {
            string sql = "SELECT * FROM barang";
            DataTable dt = new DataTable();
            try
            {
                konek();
                cmd = new MySqlCommand(sql,koneksi);
                adp = new MySqlDataAdapter(cmd);
                cmd.ExecuteNonQuery();
                adp.Fill(dt);
                dataGridView1.DataSource = dt;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            disconek();
            return dt;
        }
        
        public void Query(string strQuery)
        {
            koneksi = new MySqlConnection(database);
            try
            {
                koneksi.Open();
                cmd = new MySqlCommand(strQuery, koneksi);
                cmd.ExecuteNonQuery();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            finally
            {
                MessageBox.Show("Data Berhasil di Proses");
                koneksi.Close();
            }
        }
        void Simpan()
        {
            Query("INSERT INTO barang VALUES('','" + this.txtKodebarang.Text +
                "','" + this.txtNamabarang.Text + "','" + this.txtHargabarang.Text +
                "','" + this.txtJumlahbarang.Text + "','" + this.txtSatuan.Text +
                "')");
        }
        void Hapus()
        {
            try
            {
                koneksi = new MySqlConnection(database);
                koneksi.Open();
                string strQuery = "DELETE FROM barang WHERE id_barang ='" + idBarang+"'";
                cmd = new MySqlCommand(strQuery, koneksi);
                cmd.ExecuteNonQuery();
                koneksi.Close();
                MessageBox.Show("Data Berhasil di Hapus");
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
        void Batal()
        {
            txtKodebarang.ResetText();
            txtNamabarang.ResetText();
            txtHargabarang.ResetText();
            txtJumlahbarang.ResetText();
            txtSatuan.ResetText();
        }
        void Ubah()
        {
            try
            {
                koneksi = new MySqlConnection(database);
                koneksi.Open();
                string update = "UPDATE barang SET kode_barang=" + txtKodebarang.Text +
                "',nama_barang ='" + txtNamabarang.Text + "',harga_barang ='" + txtHargabarang.Text +
                "',jumlah_barang='" + txtJumlahbarang.Text + "',satuan='" + txtSatuan.Text +
                "'WHERE idBarang='" + idBarang + "'";
                cmd = new MySqlCommand(update, koneksi);
                cmd.ExecuteNonQuery();
                koneksi.Close();
                MessageBox.Show("Data Berhasil di Ubah");
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            txtKodebarang.Focus();
            TampilData();
        }

        private void txtKodebarang_TextChanged(object sender, EventArgs e)
        {

        }

        private void btnSimpan_Click(object sender, EventArgs e)
        {
            
        }

        private void btnHapus_Click(object sender, EventArgs e)
        {
            
        }
        string idBarang = "";

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if(e.RowIndex >=0)
            {
                DataGridViewRow row = this.dataGridView1.Rows[e.RowIndex];
                idBarang = row.Cells["id_barang"].Value.ToString();
                txtKodebarang.Text = row.Cells["kode_barang"].Value.ToString();
                txtNamabarang.Text = row.Cells["nama_barang"].Value.ToString();
                txtHargabarang.Text = row.Cells["harga_barang"].Value.ToString();
                txtJumlahbarang.Text = row.Cells["jumlah_barang"].Value.ToString();
                txtSatuan.Text = row.Cells["satuan"].Value.ToString();
                //btnsimpn.Text = "Ubah";
            }
        }

        private void btnBatal_Click(object sender, EventArgs e)
        {
            //keSemula();
        }
        void keSemula()
        {
            txtKodebarang.ResetText();
            txtNamabarang.ResetText();
            txtHargabarang.ResetText();
            txtJumlahbarang.ResetText();
            txtSatuan.Clear();
            btnsimpn.Text = "";
            TampilData();
            txtKodebarang.Focus();
        }

        private void BtnBatal_Click_1(object sender, EventArgs e)
        {

            
        }

        private void BtnLihat_Click(object sender, EventArgs e)
        {
            
        }

        private void PictureBox3_Click(object sender, EventArgs e)
        {
           
        }

        private void PictureBox2_Click(object sender, EventArgs e)
        {
           
        }

        private void PictureBox1_Click(object sender, EventArgs e)
        {
            
        }

        private void Label7_Click(object sender, EventArgs e)
        {

        }

        private void label9_Click(object sender, EventArgs e)
        {

        }

        private void btnsimpn_Click(object sender, EventArgs e)
        {
            if (btnsimpn.Text == "")
            {
                Simpan();
                TampilData();
            }
            //else if (btnsimpn.Text == "Ubah")
            {
                //Ubah();
                btnsimpn.Text = "";
                TampilData();
            }
        }

        private void btnbatl_Click(object sender, EventArgs e)
        {
            DialogResult di = MessageBox.Show("Yakin mau di Hapus??", "Informasi", MessageBoxButtons.YesNo,
                MessageBoxIcon.Question, MessageBoxDefaultButton.Button1);
            if (di == DialogResult.No)
            {
                TampilData();
            }
            else
            {
                Hapus();
                TampilData();
            }
        }

        private void btnhaps_Click(object sender, EventArgs e)
        {
            keSemula();
        }
    }
}
