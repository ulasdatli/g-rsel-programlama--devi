using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace OkulProje
{
    public partial class okulyönetimekran : Form
    {
        public okulyönetimekran()
        {
            InitializeComponent();
        }

        ulasdbEntities db = new ulasdbEntities();
        public string deger;

        void listele()
        {
            dataGridView1.DataSource = db.okulyonetimtablo.ToList();
            dataGridView1.Columns[4].Visible = false;

            var yonetimlist = db.okulyonetimtablo.ToList();


        }
        private void OkulYonetim_Load(object sender, EventArgs e)
        {
            listele();
            cmbpozisyon.Items.Add("İdare");
            cmbpozisyon.Items.Add("Öğretmen");
            cmbpozisyon.Items.Add("Öğrenci İşleri");
         
           

        }

        private void dataGridView1_CellFormatting(object sender, DataGridViewCellFormattingEventArgs e)
        {
            if (e.ColumnIndex == 3)
            {
                int sum1 = Convert.ToInt32(e.Value);
                if (sum1 == 11)
                {
                    e.Value = "İdare";
                }
                else if (sum1 == 12)
                {
                    e.Value = "Öğretmen";
                }
                else if (sum1 == 13)
                {
                    e.Value = "Öğrenci İşleri";
                }
            }
        }

        

        private void btnkaydet_Click(object sender, EventArgs e)
        {
            okulyonetimtablo ekle = new okulyonetimtablo();
            ekle.yonetimadsoyad = txtadsoyad.Text;
            ekle.yonetimgorevi = txtgorev.Text;

           
            if (cmbpozisyon.Text == "İdare")
            {
                ekle.yonetimtipi = "11";
            }
            else if (cmbpozisyon.Text == "Öğretmen")
            {
                ekle.yonetimtipi = "12";
            }
            else if (cmbpozisyon.Text == "Öğrenci İşleri")
            {
                ekle.yonetimtipi = "13";
            }
            
    
            db.okulyonetimtablo.Add(ekle);
            db.SaveChanges();
            MessageBox.Show("Yönetim Kaydı Oluşturuldu.", "Sistem Mesajı", MessageBoxButtons.OK, MessageBoxIcon.Information);
            listele();
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            
            int secilen = dataGridView1.SelectedCells[0].RowIndex;
            txtid.Text = dataGridView1.Rows[secilen].Cells[0].Value.ToString();
            txtadsoyad.Text = dataGridView1.Rows[secilen].Cells[1].Value.ToString();
            txtgorev.Text = dataGridView1.Rows[secilen].Cells[2].Value.ToString();
            int deger = Convert.ToInt32(dataGridView1.Rows[secilen].Cells[3].Value) ;
            if (deger == 11)
            {
                label5.Text = "İdare";
            }
            else if(deger == 12)
            {
                label5.Text = "Öğretmen";
            }
            else if (deger == 13)
            {
                label5.Text = "Öğrenci İşleri";
            }


            
        }

        

        private void btnguncelle_Click(object sender, EventArgs e)
        {
            btnkaydet.Enabled = true;
            int YonetimID = Convert.ToInt32(txtid.Text);

            var guncelle = db.okulyonetimtablo.Find(YonetimID);
            guncelle.yonetimadsoyad = txtadsoyad.Text;
            guncelle.yonetimgorevi = txtgorev.Text;
            if (label8.Text == "İdare")
            {
                guncelle.yonetimtipi = "11";
            }
            else if (label8.Text == "Öğretmen")
            {
                guncelle.yonetimtipi = "12";
            }
            else if (label8.Text == "Öğrenci İşleri")
            {
                guncelle.yonetimtipi = "13";
            }
            
          
            db.SaveChanges();
            MessageBox.Show("Yönetim Kayıdı Güncellendi", "Sistem Mesajı", MessageBoxButtons.OK, MessageBoxIcon.Information);
            listele();
        }

        private void cmbpozisyon_SelectedIndexChanged(object sender, EventArgs e)
        {
            label8.Text = cmbpozisyon.Text;
        }

        private void groupBox2_Enter(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (comboBox1.SelectedItem == "Görevli Adı")
            {
                var sonuc = from rec in db.okulyonetimtablo where rec.yonetimadsoyad.Contains(textBox1.Text) select rec;
                dataGridView1.DataSource = sonuc.ToList();
            }
            else if (comboBox1.SelectedItem == "Görevi")
            {
                var sonuc = from rec in db.okulyonetimtablo where rec.yonetimgorevi.Contains(textBox1.Text) select rec;
                dataGridView1.DataSource = sonuc.ToList();
            }
            
        }

        private void button2_Click(object sender, EventArgs e)
        {
            listele();
        }
    }
}
