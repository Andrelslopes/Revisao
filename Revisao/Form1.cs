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
            if (txtId.Text.Length == 0 && txtName.Text.Length == 0 && txtCpf.Text.Length == 0 && txtRm.Text.Length == 0)
            {
                MessageBox.Show("Nenhum campo deve ficar Vazio!");
            }
            else
            {
                MySqlConnection conect_db = new MySqlConnection("server=localhost;database=db_alunos;uid=root;pwd=123456");
                conect_db.Open();
                MySqlCommand cadastro = new MySqlCommand("INSERT INTO tb_aluno(id,nome,cpf,rm) values (" + txtId.Text + ",'" + txtName.Text + "','" + txtCpf.Text + "','" + txtRm.Text + "');", conect_db);
                cadastro.ExecuteNonQuery();

                MessageBox.Show("Cadastro Realizado com Sucesso!");

                MySqlDataAdapter adaptar = new MySqlDataAdapter("select * from tb_aluno", conect_db);
                DataTable dt = new DataTable();
                adaptar.Fill(dt);
                dgvAlunos.DataSource = dt;

                txtId.Text = "";
                txtName.Text = "";
                txtCpf.Text = "";
                txtRm.Text = "";
            }
            


        }
    }
}
