using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Reflection.Emit;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace OkulProje
{
    public partial class ogrenciekran : Form
    {
        public ogrenciekran()
        {
            InitializeComponent();
        }
        ulasdbEntities db = new ulasdbEntities();

        void listele()
        {
            
            dataGridView1.DataSource = db.ogrencilertablo.ToList();
           
            dataGridView1.Columns[6].Visible = false;
        }
        private void OgrenciPanel_Load(object sender, EventArgs e)
        {
            listele();
        }

        private void btnkaydet_Click(object sender, EventArgs e)
        {
            ogrencilertablo ekle = new ogrencilertablo();
            ekle.ogrenciadsoyad = txtadsoyad.Text;
            ekle.ogrencino = txtogrencino.Text;
            ekle.ogrencidogumtarih = dateTimePicker1.Value;
            ekle.ogrencibolum = txtbolum.Text;
            ekle.ogrencikayittarih = DateTime.Now;
            db.ogrencilertablo.Add(ekle);
            db.SaveChanges();
            MessageBox.Show("Öğrenci Kaydı Oluşturuldu.", "Sistem Mesajı", MessageBoxButtons.OK, MessageBoxIcon.Information);
            listele();
            
        }

       

        

        private void btnguncelle_Click(object sender, EventArgs e)
        {
            int OgrenciId = Convert.ToInt32(txtid.Text);

            var guncelle = db.ogrencilertablo.Find(OgrenciId);
            guncelle.ogrenciadsoyad = txtadsoyad.Text;
            guncelle.ogrencino = txtogrencino.Text;
            guncelle.ogrencidogumtarih = dateTimePicker1.Value;
            guncelle.ogrencibolum = txtbolum.Text;
            guncelle.ogrencikayittarih = DateTime.Now;
            db.SaveChanges();
            MessageBox.Show("Öğrenci Kayıdı Güncellendi", "Sistem Mesajı", MessageBoxButtons.OK, MessageBoxIcon.Information);
            listele();
        }

        private void btnsil_Click(object sender, EventArgs e)
        {
            int OgrenciId = Convert.ToInt32(txtid.Text);

            var ogrencibul = db.ogrencilertablo.Find(OgrenciId);
            db.ogrencilertablo.Remove(ogrencibul);
            db.SaveChanges();
            MessageBox.Show("Öğrenci Kayıdı Silindi", "Sistem Mesajı", MessageBoxButtons.OK, MessageBoxIcon.Information);
            listele();

        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            int secilen = dataGridView1.SelectedCells[0].RowIndex;
            txtid.Text = dataGridView1.Rows[secilen].Cells[0].Value.ToString();
            txtadsoyad.Text = dataGridView1.Rows[secilen].Cells[1].Value.ToString();
            txtogrencino.Text = dataGridView1.Rows[secilen].Cells[5].Value.ToString();
            dateTimePicker1.Text = dataGridView1.Rows[secilen].Cells[3].Value.ToString();
            txtbolum.Text = dataGridView1.Rows[secilen].Cells[4].Value.ToString();

        }

        private void label6_Click(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (comboBox1.SelectedItem== "Ad Soyad")
            {
                var sonuc = from rec in db.ogrencilertablo where rec.ogrenciadsoyad.Contains(textBox1.Text) select rec;
                dataGridView1.DataSource = sonuc.ToList();
            }
            else if (comboBox1.SelectedItem == "Öğrenci No")
            {
                var sonuc = from rec in db.ogrencilertablo where rec.ogrencino.Contains(textBox1.Text) select rec;
                dataGridView1.DataSource = sonuc.ToList();
            }
            else if (comboBox1.SelectedItem == "Bolum")
            {
                var sonuc = from rec in db.ogrencilertablo where rec.ogrencibolum.Contains(textBox1.Text) select rec;
                dataGridView1.DataSource = sonuc.ToList();
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            listele();
        }
    }
}
