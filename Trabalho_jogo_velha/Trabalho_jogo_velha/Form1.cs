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

namespace Trabalho_jogo_velha
{
    public partial class Form1 : Form
    {

        bool xiss = true;
        public Form1()
        {
            InitializeComponent();
        }
        private void Form1_load(object senter, EventArgs e)
        {
            btn_01.Click += new EventHandler(BClick);
            btn_02.Click += new EventHandler(BClick);
            btn_03.Click += new EventHandler(BClick);
            btn_04.Click += new EventHandler(BClick);
            btn_05.Click += new EventHandler(BClick);
            btn_06.Click += new EventHandler(BClick);
            btn_07.Click += new EventHandler(BClick);
            btn_08.Click += new EventHandler(BClick);
            btn_09.Click += new EventHandler(BClick);

            foreach (Control item in this.Controls)
            {
                if (item is Button)
                {
                    item.TabStop = false;
                }
            }
        }
        private void BClick(object sender, EventArgs e)
        {
            ((Button)sender).Text = this.xiss ? "X" : "O"; // se o texto do botão for verdadeiro, coloca x, se não coloca, o
            ((Button)sender).Enabled = false; // desabilita o botão
            Verificar_ganhador();
            xiss = !xiss;
            lbl_info.Text = string.Format("{0}, é a sua vez", this.x ? " X" : "O");
        }
        private void Verificar_ganhador()
        {
            if (btn_01.Text != String.Empty && btn_01.Text == btn_02.Text && btn_02.Text == btn_03.Text || //linha 1
                btn_04.Text != String.Empty && btn_04.Text == btn_05.Text && btn_05.Text == btn_06.Text || //linha 2
                btn_07.Text != String.Empty && btn_07.Text == btn_08.Text && btn_08.Text == btn_09.Text || //linha 3

                btn_01.Text != String.Empty && btn_01.Text == btn_04.Text && btn_08.Text == btn_07.Text || //coluna 1
                btn_02.Text != String.Empty && btn_02.Text == btn_05.Text && btn_05.Text == btn_08.Text || //coluna 2
                btn_03.Text != String.Empty && btn_03.Text == btn_06.Text && btn_06.Text == btn_09.Text || //coluna 3

                btn_01.Text != String.Empty && btn_01.Text == btn_05.Text && btn_05.Text == btn_09.Text || // diagonal principal
                btn_03.Text != String.Empty && btn_03.Text == btn_05.Text && btn_05.Text == btn_07.Text //diagonal secundária
              )

            { MessageBox.Show(string.Format(" O ganhador é o [{0}]", x ? "X" : "O"), "Temos o ganhador",
                MessageBoxButtons.OK, MessageBoxIcon.Information);
                Reiniciar();
            }
            else
            {
                Verificar_empate();
            }
        }
        private void Verificar_empate() {
            bool tudo_inativo = true;
            foreach (Control item in this.Controls)
            {
                if (item is Button && item.Enabled)
                {
                    tudo_inativo = false;
                    break;
                }
            }
            if (tudo_inativo)
            {
                MessageBox.Show(string.Format("Empatou"), "wow",
                MessageBoxButtons.OK, MessageBoxIcon.Warning);
                Reiniciar();
            }
        }
        private void Reiniciar() {
            foreach (Control item in this.Controls)
            {
                if (item is Button)
                {
                    item.Enabled = true;
                    item.Text = String.Empty;
                }
            }
        }
    } 
}
