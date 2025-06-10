using System.Drawing.Imaging;
using System.Media;
using WMPLib;


namespace _17_ScreminLudovico_GiocoYahtzee
{
    public partial class Form1 : Form
    {
        public BloccoFogli bf;

        int aChiTocca;

        int nLanciDelTurno;

        bool partitaFermata = false;

        int contPictureBox = 0;

        bool controlloSelezioneCella;

        private bool[,] cellSelectionMatrix;


        WindowsMediaPlayer player;

        List<PictureBox> pictureBoxes = new List<PictureBox>();

        List<Image> images = new List<Image>();
        public Form1()
        {
            bf = new BloccoFogli();

            player = new WindowsMediaPlayer();

            aChiTocca = 0;

            nLanciDelTurno = 0;

            contPictureBox = 0;

            controlloSelezioneCella = false;

            InitializeComponent();
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {
            btnDado1.PerformClick();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            pictureBox1.Image = Image.FromFile("Dado_Uno.png");
            pictureBox1.SizeMode = PictureBoxSizeMode.Zoom;
            pictureBox1.Anchor = AnchorStyles.None;

            pictureBox2.Image = Image.FromFile("Dado_Due.png");
            pictureBox2.SizeMode = PictureBoxSizeMode.Zoom;
            pictureBox2.Anchor = AnchorStyles.None;

            pictureBox3.Image = Image.FromFile("Dado_Tre.png");
            pictureBox3.SizeMode = PictureBoxSizeMode.Zoom;
            pictureBox3.Anchor = AnchorStyles.None;

            pictureBox4.Image = Image.FromFile("Dado_Quattro.png");
            pictureBox4.SizeMode = PictureBoxSizeMode.Zoom;
            pictureBox4.Anchor = AnchorStyles.None;

            pictureBox5.Image = Image.FromFile("Dado_Cinque.png");
            pictureBox5.SizeMode = PictureBoxSizeMode.Zoom;
            pictureBox5.Anchor = AnchorStyles.None;

            pictureBoxes.Add(pictureBox1);
            pictureBoxes.Add(pictureBox2);
            pictureBoxes.Add(pictureBox3);
            pictureBoxes.Add(pictureBox4);
            pictureBoxes.Add(pictureBox5);

            images.Add(Image.FromFile("Dado_Uno.png"));
            images.Add(Image.FromFile("Dado_Due.png"));
            images.Add(Image.FromFile("Dado_Tre.png"));
            images.Add(Image.FromFile("Dado_Quattro.png"));
            images.Add(Image.FromFile("Dado_Cinque.png"));
            images.Add(Image.FromFile("Dado_Sei.png"));


            lbltextNuovaPartita.Visible = false;



            this.BackColor = Color.FromArgb(144, 65, 175);

            pictureBox1.Visible = false;
            pictureBox2.Visible = false;
            pictureBox3.Visible = false;
            pictureBox4.Visible = false;
            pictureBox5.Visible = false;

            btnFermaPartita.Visible = false;
            btnLanciaDadi.Visible = false;

            lbltextNuovaPartita.Font = new Font(lbltextNuovaPartita.Font.FontFamily, lbltextNuovaPartita.Font.Size + 3, lbltextNuovaPartita.Font.Style);
            lblNomeGiocatore.Visible = true;
            txtNomeGiocatore.Visible = true;
            lblGiocatoreAggiunto.Visible = false;
            lbltextNuovaPartita.Visible = true;

            lblEsitoPartita.Visible = false;

            dataGridView1.Visible = false;

            btnDado1.Visible = false;
            btnDado2.Visible = false;
            btnDado3.Visible = false;
            btnDado4.Visible = false;
            btnDado5.Visible = false;



            pictureBox1.Anchor = AnchorStyles.Top | AnchorStyles.Left;
            pictureBox2.Anchor = AnchorStyles.Top | AnchorStyles.Left;
            pictureBox3.Anchor = AnchorStyles.Top | AnchorStyles.Left;
            pictureBox4.Anchor = AnchorStyles.Top | AnchorStyles.Left;
            pictureBox5.Anchor = AnchorStyles.Top | AnchorStyles.Left;

            lblBloccato1.Visible = false;
            lblBloccato2.Visible = false;
            lblBloccato3.Visible = false;
            lblBloccato4.Visible = false;
            lblBloccato5.Visible = false;

        }

        private void btnAggiungiGiocatore_Click(object sender, EventArgs e)
        {
        }

        private void btnLanciaDadi_Click(object sender, EventArgs e)
        {
            if (nLanciDelTurno <= 3)
            {
                if (nLanciDelTurno == 3)
                {

                    if (nLanciDelTurno == 3 && !controlloSelezioneCella)
                    {
                        btnLanciaDadi.Enabled = false;
                        MessageBox.Show($"Seleziona una combinazione per continuare!");

                    }
                    bf.ListaFogli[aChiTocca].NumeroTurni++;

                    for (int i = 0; i < 5; i++)
                    {
                        if (bf.ListaFogli[aChiTocca].Gioco1.ListaDadi[i].IsOn == false)
                        {
                            if (i == 0)
                            {
                                bf.ListaFogli[aChiTocca].Gioco1.ListaDadi[i].IsOn = true;
                                lblBloccato1.Visible = false;
                            }
                            else if (i == 1)
                            {
                                bf.ListaFogli[aChiTocca].Gioco1.ListaDadi[i].IsOn = true;
                                lblBloccato2.Visible = false;
                            }
                            else if (i == 2)
                            {
                                bf.ListaFogli[aChiTocca].Gioco1.ListaDadi[i].IsOn = true;
                                lblBloccato3.Visible = false;
                            }
                            else if (i == 3)
                            {
                                bf.ListaFogli[aChiTocca].Gioco1.ListaDadi[i].IsOn = true;
                                lblBloccato4.Visible = false;
                            }
                            else if (i == 4)
                            {
                                bf.ListaFogli[aChiTocca].Gioco1.ListaDadi[i].IsOn = true;
                                lblBloccato5.Visible = false;
                            }
                        }
                    }

                    if (aChiTocca == (bf.ListaFogli.Count - 1))
                    {
                        aChiTocca = 0;
                    }

                    else
                    {
                        aChiTocca++;
                    }

                    lblAChiTocca.Text = "Turno di " + bf.ListaFogli[aChiTocca].NomeGiocatore;

                    nLanciDelTurno = 0;
                    contPictureBox = 0;

                }
                else if (bf.ListaFogli[aChiTocca].NumeroTurni < 13) // & statoLancio
                {
                    bf.ListaFogli[aChiTocca].Gioco1.FaiLanci();

                    foreach (Dado d in bf.ListaFogli[aChiTocca].Gioco1.ListaDadi)
                    {
                        if (contPictureBox < pictureBoxes.Count)
                        {
                            pictureBoxes[contPictureBox].Image = images[d.Valore - 1];
                        }
                        contPictureBox++;
                    }

                    List<Configurazione> listaConf = bf.ListaFogli[aChiTocca].Gioco1.SimulaPunteggi();

                    int indice = 1;

                    foreach (Configurazione f in listaConf)
                    {
                        dataGridView1.Rows[indice].Cells[aChiTocca + 1].Value = f.Punteggio;
                        if (indice == 6)
                        {
                            indice = 9;
                        }
                        else
                        {
                            indice++;
                        }
                    }
                    contPictureBox = 0;
                    nLanciDelTurno++;


                    if (nLanciDelTurno == 3 && !controlloSelezioneCella)
                    {
                        btnLanciaDadi.Enabled = false;
                        MessageBox.Show($"Seleziona una combinazione per continuare!");

                    }
                }
                
            }
            if (bf.ListaFogli[aChiTocca].NumeroTurni >= 13)
            {
                int t = 1;

                foreach (Fogliosegnapunti fs in bf.ListaFogli)
                {
                    dataGridView1.Rows[8].Cells[t].Value = bf.ListaFogli[t - 1].CalcolaBonus();
                    dataGridView1.Rows[7].Cells[t].Value = bf.ListaFogli[t - 1].PunteggioParteSuperiore;
                    dataGridView1.Rows[16].Cells[t].Value = bf.ListaFogli[t - 1].CalcolaPunteggioFinale();
                    t++;
                }

                string risultatoPartita = bf.EsitoPartita();
                lblEsitoPartita.Text = risultatoPartita;
                lblEsitoPartita.Visible = true;
            }

        }

        private void pictureBox5_Click(object sender, EventArgs e)
        {
            btnDado5.PerformClick();
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void btnCreaPartita_Click(object sender, EventArgs e)
        {
            if (btnFermaPartita.Visible)
            {

                pictureBox1.Visible = false;
                pictureBox2.Visible = false;
                pictureBox3.Visible = false;
                pictureBox4.Visible = false;
                pictureBox5.Visible = false;

                btnFermaPartita.Visible = false;
                btnLanciaDadi.Visible = false;

                lblNomeGiocatore.Visible = true;
                txtNomeGiocatore.Visible = true;
                lblGiocatoreAggiunto.Visible = false;
                lbltextNuovaPartita.Visible = true;

                btnAggiungiGiocatore.Visible = true;

                lblEsitoPartita.Visible = false;

                lblAChiTocca.Visible = false;

                btnDado1.Visible = false;
                btnDado2.Visible = false;
                btnDado3.Visible = false;
                btnDado4.Visible = false;
                btnDado5.Visible = false;

                dataGridView1.Visible = false;

                dataGridView1.Rows.Clear();

                dataGridView1.Columns.Clear();

                bf.Reset();

                controlloSelezioneCella = true;
                nLanciDelTurno = 0;

                lblBloccato1.Visible = false;
                lblBloccato2.Visible = false;
                lblBloccato3.Visible = false;
                lblBloccato4.Visible = false;
                lblBloccato5.Visible = false;

            }
            else if (bf.ListaFogli.Count > 1)
            {

                dataGridView1.Visible = true;



                dataGridView1.Columns.Add("ColumnName", "/");


                for (int i = 0; i < bf.ListaFogli.Count; i++)
                {
                    dataGridView1.Columns.Add("ColumnName", bf.ListaFogli[i].NomeGiocatore);
                }

                dataGridView1.Rows[0].Cells[0].Value = "/";


                dataGridView1.RowCount = 17;


                dataGridView1.Rows[1].Cells[0].Value = "Uni";
                dataGridView1.Rows[2].Cells[0].Value = "Secondi";
                dataGridView1.Rows[3].Cells[0].Value = "Terzi";
                dataGridView1.Rows[4].Cells[0].Value = "Quarti";
                dataGridView1.Rows[5].Cells[0].Value = "Quinti";
                dataGridView1.Rows[6].Cells[0].Value = "Sesti";
                dataGridView1.Rows[7].Cells[0].Value = "Somma";
                dataGridView1.Rows[8].Cells[0].Value = "Bonus";
                dataGridView1.Rows[9].Cells[0].Value = "Tre di un tipo";
                dataGridView1.Rows[10].Cells[0].Value = "Quattro di un tipo";
                dataGridView1.Rows[11].Cells[0].Value = "Full House";
                dataGridView1.Rows[12].Cells[0].Value = "Scala piccola";
                dataGridView1.Rows[13].Cells[0].Value = "Scala grande";
                dataGridView1.Rows[14].Cells[0].Value = "Chance";
                dataGridView1.Rows[15].Cells[0].Value = "YAHTZEE";
                dataGridView1.Rows[16].Cells[0].Value = "PUNTEGGIO FINALE";


                dataGridView1.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;

                int numeroRighe = dataGridView1.RowCount;
                int altezzaDisponibile = dataGridView1.ClientSize.Height;
                int altezzaPerRiga = altezzaDisponibile / numeroRighe;

                foreach (DataGridViewRow riga in dataGridView1.Rows)
                {
                    riga.Height = altezzaPerRiga;
                }

                cellSelectionMatrix = new bool[dataGridView1.RowCount, dataGridView1.ColumnCount];


                pictureBox1.Visible = true;
                pictureBox2.Visible = true;
                pictureBox3.Visible = true;
                pictureBox4.Visible = true;
                pictureBox5.Visible = true;

                btnFermaPartita.Visible = true;
                btnLanciaDadi.Visible = true;

                lblNomeGiocatore.Visible = false;
                txtNomeGiocatore.Visible = false;
                lblGiocatoreAggiunto.Visible = false;

                btnAggiungiGiocatore.Visible = false;
                btnCreaPartita.Visible = false;

                lbltextNuovaPartita.Visible = false;

                lblEsitoPartita.Visible = false;

                lblAChiTocca.Visible = true;

                btnDado1.Visible = true;
                btnDado2.Visible = true;
                btnDado3.Visible = true;
                btnDado4.Visible = true;
                btnDado5.Visible = true;

                lblAChiTocca.Text = "Turno di " + bf.ListaFogli[aChiTocca].NomeGiocatore;
            }
            else if (bf.ListaFogli.Count == 0)
            {
                MessageBox.Show($"Non si può inziare la partita senza giocatori!");
            }
            else if (bf.ListaFogli.Count == 1)
            {
                MessageBox.Show($"Non si può iniziare la partita con solo 1 giocatore!");
            }
        }

        private void lbltextNuovaPartita_Click(object sender, EventArgs e)
        {

        }

        private void pictureBox6_Click(object sender, EventArgs e)
        {

        }

        private void btnAggiungiGiocatore_Click_1(object sender, EventArgs e)
        {
            if (txtNomeGiocatore.Text != "")
            {
                bf.AggiungiFoglio(txtNomeGiocatore.Text);
                lblGiocatoreAggiunto.Text = bf.ListaFogli.Count + "° Giocatore: " + txtNomeGiocatore.Text;
                lblGiocatoreAggiunto.Visible = true;
                txtNomeGiocatore.Text = "";
            }
            else
            {
                MessageBox.Show($"Nome non valido. Si prega di reinserire il nome!");
                txtNomeGiocatore.Text = "";
            }
            txtNomeGiocatore.Focus();
        }

        private void btnFermaPartita_Click(object sender, EventArgs e)
        {
            if (!partitaFermata)
            {
                btnCreaPartita.Visible = true;
                partitaFermata = true;

                string risultatoPartita = bf.EsitoPartita();
                lblEsitoPartita.Text = risultatoPartita;
                lblEsitoPartita.Visible = true;
            }
            else
            {
                btnCreaPartita.Visible = true;
                partitaFermata = false;
            }
        }

        private void lblAChiTocca_Click(object sender, EventArgs e)
        {

        }

        private void button4_Click(object sender, EventArgs e)
        {
            if (nLanciDelTurno != 0)
            {
                if (bf.ListaFogli[aChiTocca].Gioco1.ListaDadi[3].IsOn)
                {
                    lblBloccato4.Visible = true;
                    bf.ListaFogli[aChiTocca].Gioco1.ListaDadi[3].IsOn = false;
                }
                else
                {
                    lblBloccato4.Visible = false;
                    bf.ListaFogli[aChiTocca].Gioco1.ListaDadi[3].IsOn = true;
                }
            }
        }

        private void btnDado5_Click(object sender, EventArgs e)
        {
            if (nLanciDelTurno != 0)
            {
                if (bf.ListaFogli[aChiTocca].Gioco1.ListaDadi[4].IsOn)
                {
                    lblBloccato5.Visible = true;
                    bf.ListaFogli[aChiTocca].Gioco1.ListaDadi[4].IsOn = false;
                }
                else
                {
                    lblBloccato5.Visible = false;
                    bf.ListaFogli[aChiTocca].Gioco1.ListaDadi[4].IsOn = true;
                }
            }
        }

        private void btnDado1_Click(object sender, EventArgs e)
        {
            if (nLanciDelTurno != 0)
            {
                if (bf.ListaFogli[aChiTocca].Gioco1.ListaDadi[0].IsOn)
                {
                    lblBloccato1.Visible = true;
                    bf.ListaFogli[aChiTocca].Gioco1.ListaDadi[0].IsOn = false;
                }
                else
                {
                    lblBloccato1.Visible = false;
                    bf.ListaFogli[aChiTocca].Gioco1.ListaDadi[0].IsOn = true;
                }
            }

        }

        private void pictureBox2_Click(object sender, EventArgs e)
        {
            btnDado2.PerformClick();
        }

        private void pictureBox3_Click(object sender, EventArgs e)
        {
            btnDado3.PerformClick();
        }

        private void pictureBox4_Click(object sender, EventArgs e)
        {
            btnDado4.PerformClick();
        }

        private void btnDado2_Click(object sender, EventArgs e)
        {
            if (nLanciDelTurno != 0)
            {
                if (bf.ListaFogli[aChiTocca].Gioco1.ListaDadi[1].IsOn)
                {
                    lblBloccato2.Visible = true;
                    bf.ListaFogli[aChiTocca].Gioco1.ListaDadi[1].IsOn = false;
                }
                else
                {
                    lblBloccato2.Visible = false;
                    bf.ListaFogli[aChiTocca].Gioco1.ListaDadi[1].IsOn = true;
                }
            }
        }

        private void btnDado3_Click(object sender, EventArgs e)
        {
            if (nLanciDelTurno != 0)
            {
                if (bf.ListaFogli[aChiTocca].Gioco1.ListaDadi[2].IsOn)
                {
                    lblBloccato3.Visible = true;
                    bf.ListaFogli[aChiTocca].Gioco1.ListaDadi[2].IsOn = false;
                }
                else
                {
                    lblBloccato3.Visible = false;
                    bf.ListaFogli[aChiTocca].Gioco1.ListaDadi[2].IsOn = true;
                }
            }
        }

        private void numericUpDown1_ValueChanged(object sender, EventArgs e)
        {
        }

        private void dataGridView1_CellContentClick_1(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void lblVolume_Click(object sender, EventArgs e)
        {

        }

        private void lblNomeGiocatore_Click(object sender, EventArgs e)
        {

        }

        private void txtNomeGiocatore_TextChanged(object sender, EventArgs e)
        {

        }

        private void lblGiocatoreAggiunto_Click(object sender, EventArgs e)
        {

        }

        private void lblBloccato1_Click(object sender, EventArgs e)
        {

        }

        private void lblBloccato5_Click(object sender, EventArgs e)
        {

        }

        private void txtNomeGiocatore_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                btnAggiungiGiocatore.PerformClick();
                e.Handled = true;

                txtNomeGiocatore.Focus();
            }
        }

        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            int posizioneSelezionata = 0;
            if (e.RowIndex > 0 && e.ColumnIndex > 0 && e.ColumnIndex == (aChiTocca + 1) && nLanciDelTurno != 0 &&
                e.RowIndex != 7 && e.RowIndex != 8 && e.RowIndex != 16)
            {

                if (e.RowIndex <= 6)
                {
                    posizioneSelezionata = e.RowIndex - 1;
                }
                else if (e.RowIndex != 7 && e.RowIndex != 8 && e.RowIndex != 16)
                {
                    posizioneSelezionata = e.RowIndex - 3;
                }
                if (!cellSelectionMatrix[e.RowIndex, e.ColumnIndex])
                {
                    cellSelectionMatrix[e.RowIndex, e.ColumnIndex] = true;



                    MessageBox.Show($"{bf.ListaFogli[aChiTocca].NomeGiocatore} ha selezionato la combinazione {bf.ListaFogli[aChiTocca].Gioco1.ListaConfigurazioni[posizioneSelezionata]}");

                    dataGridView1.Rows[e.RowIndex].Cells[e.ColumnIndex].Style.BackColor = Color.Yellow;

                    bf.ListaFogli[aChiTocca].Gioco1.ListaConfigurazioni[posizioneSelezionata].IsOccupato = true;

                    nLanciDelTurno = 0;
                    contPictureBox = 0;

                    btnLanciaDadi.Enabled = true;

                    controlloSelezioneCella = false;

                    if (nLanciDelTurno < 3)
                    {
                        bf.ListaFogli[aChiTocca].NumeroTurni++;

                        for (int i = 0; i < 5; i++)
                        {
                            if (bf.ListaFogli[aChiTocca].Gioco1.ListaDadi[i].IsOn == false)
                            {
                                if (i == 0)
                                {
                                    bf.ListaFogli[aChiTocca].Gioco1.ListaDadi[i].IsOn = true;
                                    lblBloccato1.Visible = false;
                                }
                                else if (i == 1)
                                {
                                    bf.ListaFogli[aChiTocca].Gioco1.ListaDadi[i].IsOn = true;
                                    lblBloccato2.Visible = false;
                                }
                                else if (i == 2)
                                {
                                    bf.ListaFogli[aChiTocca].Gioco1.ListaDadi[i].IsOn = true;
                                    lblBloccato3.Visible = false;
                                }
                                else if (i == 3)
                                {
                                    bf.ListaFogli[aChiTocca].Gioco1.ListaDadi[i].IsOn = true;
                                    lblBloccato4.Visible = false;
                                }
                                else if (i == 4)
                                {
                                    bf.ListaFogli[aChiTocca].Gioco1.ListaDadi[i].IsOn = true;
                                    lblBloccato5.Visible = false;
                                }
                            }
                        }

                        if (aChiTocca == (bf.ListaFogli.Count - 1))
                        {
                            aChiTocca = 0;
                            nLanciDelTurno = 0;
                        }

                        else
                        {
                            aChiTocca++;
                            nLanciDelTurno = 0;
                        }

                        lblAChiTocca.Text = "Turno di " + bf.ListaFogli[aChiTocca].NomeGiocatore;

                    }
                    if (bf.ListaFogli[aChiTocca].NumeroTurni >= 13)
                    {
                        bf.ListaFogli[aChiTocca].NumeroTurni++;
                        btnLanciaDadi.Enabled = true;
                        controlloSelezioneCella = true;
                    }

                }
                else
                {
                    MessageBox.Show($"{bf.ListaFogli[aChiTocca].NomeGiocatore} ha già selezionato la combinazione {bf.ListaFogli[aChiTocca].Gioco1.ListaConfigurazioni[posizioneSelezionata]}");
                }
            }
            else if (e.RowIndex != 7 && e.RowIndex != 8 && e.RowIndex != 16 && nLanciDelTurno == 0 && e.ColumnIndex == (aChiTocca + 1))
            {
                MessageBox.Show($"{bf.ListaFogli[aChiTocca].NomeGiocatore} deve ancora lanciare i dadi!");
            }
            else
            {
                MessageBox.Show($"È il turno di {bf.ListaFogli[aChiTocca].NomeGiocatore}");
            }

        }

    }
}
