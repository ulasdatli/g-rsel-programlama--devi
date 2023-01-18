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
    public partial class ogrencidersekran : Form
    {
        public ogrencidersekran()
        {
            InitializeComponent();
        }

        ulasdbEntities db = new ulasdbEntities();

        

        private void OgrenciDersPanel_Load(object sender, EventArgs e)
        {
            listele();
            var ogrenciler = (from x in db.ogrencilertablo
                               select new
                               {
                                   x.ogrenciid,
                                   x.ogrenciadsoyad

                               }).ToList();

            cmbogrenci.ValueMember = "ogrenciid";
            cmbogrenci.DisplayMember = "ogrenciadsoyad";
            cmbogrenci.DataSource = ogrenciler; listele();


            var dersler = (from x in db.derstablo
                              select new
                              {
                                  x.dersid,
                                  x.dersadi

                              }).ToList();

            cmbders.ValueMember = "dersid";
            cmbders.DisplayMember = "dersadi";
            cmbders.DataSource = dersler; listele();
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            int secilen = dataGridView1.SelectedCells[0].RowIndex;
            txtid.Text = dataGridView1.Rows[secilen].Cells[0].Value.ToString();
            cmbders.Text = dataGridView1.Rows[secilen].Cells[1].Value.ToString();
            cmbogrenci.Text = dataGridView1.Rows[secilen].Cells[2].Value.ToString();
          
        }

        

        private void button1_Click(object sender, EventArgs e)
        {
            ogrenciderstablo ekle = new ogrenciderstablo();
            ekle.ogrencidersdersid = Convert.ToInt16(cmbders.SelectedValue);
            ekle.ogrencidersogrenciid = Convert.ToInt16(cmbogrenci.SelectedValue);
            db.ogrenciderstablo.Add(ekle);
            db.SaveChanges();
            MessageBox.Show("Öğrenciye Ders Ataması Yapıldı.", "Sistem Mesajı", MessageBoxButtons.OK, MessageBoxIcon.Information);
            listele();
        }

        void listele()
        {
            dataGridView1.DataSource = (from x in db.ogrenciderstablo
                                        select new
                                        {
                                            x.ogrencidersid,
                                            x.derstablo.dersadi,
                                            x.ogrencilertablo.ogrenciadsoyad



                                        }).ToList();






            var derslist = db.derstablo.ToList();


        }



        private void button2_Click(object sender, EventArgs e)
        {
            if (comboBox1.SelectedItem=="Ogrenci")
            {
                {
                    var arama = textBox1.Text;
                    var sonuc = (from x in db.ogrenciderstablo
                                 where x.ogrencilertablo.ogrenciadsoyad.Contains(arama)
                                 select new
                                 {
                                     x.ogrencidersid,
                                     x.derstablo.dersadi,
                                     x.ogrencilertablo.ogrenciadsoyad

                                 }).ToList();
                    dataGridView1.DataSource = sonuc.ToList();


                }
            }
        }

        private void button3_Click(object sender, EventArgs e)
        {
            
                listele();
            
        }
    }
}
