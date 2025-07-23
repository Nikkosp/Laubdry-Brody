using System;

namespace WinFormLaundry
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
            comboBox1.Items.Add("Reguler");
            comboBox1.Items.Add("Cuci Kering");
            comboBox1.Items.Add("Cuci VIP");
            comboBox1.Items.Add("Cuci Antar");
            comboBox1.SelectedIndex = 0;

            textBox1.TextChanged += new EventHandler(InputChanged);
            comboBox1.SelectedIndexChanged += new EventHandler(InputChanged);
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            string berat = textBox1.Text;
            string layanan = comboBox1.SelectedItem.ToString();
            string estimasiHarga = textBox2.Text;
            string estimasiPengambilan = textBox3.Text;

            string pesan = $"--- DETAIL PESANAN ANDA ---\n" +
                           $"Berat Cucian     : {berat} kg\n" +
                           $"Layanan          : {layanan}\n" +
                           $"Estimasi Harga   : {estimasiHarga}\n" +
                           $"Estimasi Selesai : {estimasiPengambilan}";

            MessageBox.Show(pesan, "Konfirmasi Pesanan", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private void InputChanged(object sender, EventArgs e)
        {
            try
            {
                if (string.IsNullOrWhiteSpace(textBox1.Text)) return;

                double berat = double.Parse(textBox1.Text);
                double unit3kg = berat / 1.0;

                double hargaDasar = unit3kg * 4000;

                string layanan = comboBox1.SelectedItem.ToString();
                double tambahan = 0;
                int estimasiHari = 3;

                switch (layanan)
                {
                    case "Reguler":
                        tambahan = unit3kg * 1000;
                        estimasiHari = 3;
                        break;
                    case "Cuci Kering":
                        tambahan = unit3kg * 1500;
                        estimasiHari = 3;
                        break;
                    case "Cuci VIP":
                        tambahan = unit3kg * 3000;
                        estimasiHari = 1;
                        break;
                    case "Cuci Antar":
                        tambahan = unit3kg * 2000;
                        estimasiHari = 2;
                        break;
                }
                double totalHarga = hargaDasar + tambahan;
                double estimasiHarga = unit3kg * 2;
                DateTime mulai = dateTimePicker1.Value.Date;
                DateTime selesai = mulai.AddDays(estimasiHari);

                textBox2.Text = $"Rp {totalHarga}";
                textBox3.Text = selesai.ToString("dd/MM/yyy");
            }
            catch
            {
                textBox2.Text = "-";
                textBox3.Text = "-";
            }
        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void label1_Click(object sender, EventArgs e)
        {

        }
    }
}
