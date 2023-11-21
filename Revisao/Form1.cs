using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics.Eventing.Reader;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using MySql.Data.MySqlClient;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace Revisao
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void btnCadastrar_Click(object sender, EventArgs e)
        {
            if (txtId.Text != "" && txtName.Text != "" && txtCpf.Text != "" && txtRg.Text != "" && txtCpf.Text != "" && txtNasc.Text != "")
            {
                try
                {
                    MySqlConnection conect_db = new MySqlConnection("server=localhost;database=db_alunos;uid=root;pwd=123456");
                    conect_db.Open();
                    MySqlCommand cadastro = new MySqlCommand("INSERT INTO tb_aluno(id,nome,cpf,rm) values (" + txtId.Text + ",'" + txtName.Text + "','" + txtCpf.Text + "','" + txtRg.Text + "');", conect_db);
                    cadastro.ExecuteNonQuery();

                    MessageBox.Show("Cadastro Realizado com Sucesso!");

                    MySqlDataAdapter adaptar = new MySqlDataAdapter("select * from tb_aluno", conect_db);
                    DataTable dt = new DataTable();
                    adaptar.Fill(dt);
                    dgvAlunos.DataSource = dt;

                    txtId.Text = "";
                    txtName.Text = "";
                    txtRg.Text = "";
                    txtCpf.Text = "";
                    txtRm.Text = "";
                    txtNasc.Text = "";
                } catch
                {
                    MessageBox.Show("Id ja cadastrado");
                }
            }
            else
            {
                MessageBox.Show("Nenhum campo deve ficar Vazio!");
            }
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            MySqlConnection conect_db = new MySqlConnection("server=localhost;database=db_alunos;uid=root;pwd=123456");
            conect_db.Open();
            MySqlDataAdapter adaptar = new MySqlDataAdapter("select * from tb_aluno", conect_db);
            DataTable dt = new DataTable();
            adaptar.Fill(dt);
            dgvAlunos.DataSource = dt;
        }

        private void dgvAlunos_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void btnAlterar_Click(object sender, EventArgs e)
        {
            string conexao = "server=localhost;database=db_alunos;uid=root;pwd=123456";
            MySqlConnection conexaoMYSQL = new MySqlConnection(conexao);
            conexaoMYSQL.Open();

            MySqlCommand comando = new MySqlCommand("update tb_aluno set nome='" +txtName.Text+ "',Rg_aluno='"+txtRg.Text+"',cpf='"+txtCpf.Text+"',Rm='"+txtRm.Text+"',dt_nasc='"+txtNasc.Text+"' where id=" +txtId.Text, conexaoMYSQL);
            comando.ExecuteNonQuery();

            MessageBox.Show("Dados alterados com Sucesso!");
            txtId.Text = "";
            txtName.Text = "";
            txtRg.Text = "";
            txtCpf.Text = "";
            txtRm.Text = "";
            txtNasc.Text = "";


        }

        private void btnDelete_Click(object sender, EventArgs e)
        {

        }

        private void dgvAlunos_CellMouseDoubleClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            txtId.Text = dgvAlunos.Rows[e.RowIndex].Cells[0].Value.ToString();;
            txtName.Text = dgvAlunos.Rows[e.RowIndex].Cells[1].Value.ToString();
            txtRg.Text = dgvAlunos.Rows[e.RowIndex].Cells[2].Value.ToString();
            txtCpf.Text = dgvAlunos.Rows[e.RowIndex].Cells[3].Value.ToString();
            txtRm.Text = dgvAlunos.Rows[e.RowIndex].Cells[4].Value.ToString();
            txtNasc.Text = dgvAlunos.Rows[e.RowIndex].Cells[5].Value.ToString();
        }
    }
}
