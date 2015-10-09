using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ShellSort
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        int[] arreglo;
        int longitud;
        int num;
        Random rand = new Random();
        private void Form1_Load(object sender, EventArgs e)
        {
            dataGridView1.Columns.Add("","");
        }
        public int[] shellSort()
        {
            bool ban = false;
            int i;
            int aux;
            int acumulador = arreglo.Length / 2 ;//INT
            while (acumulador > 0)
            {
               // acumulador = (acumulador / 2);
                ban = true;
                while (ban == true)
                {
                    ban = false;
                    i = 1;
                    while (i<=(arreglo.Length - acumulador))
                    {
                        if (arreglo[i - 1] > arreglo[(i-1) + acumulador])
                        {
                            aux = arreglo[i - 1 + acumulador];
                            arreglo[(i - 1) + acumulador] = arreglo[i -1];
                            arreglo[i -1] = aux;
                            ban = true;
                        }
                        i++;
                    }

                }
                acumulador = acumulador / 2;
            }
            return arreglo;

        }

        private void btnAceptar_Click(object sender, EventArgs e)
        {
            try
            {
                longitud = Convert.ToInt32(txtBoxElementos.Text);
                arreglo = new int[longitud];
                for (int i = 0; i < longitud - 1; i++)
                {
                    dataGridView1.Rows.Add();
                }
            }
            catch (Exception)
            {
                MessageBox.Show("llenar correctamente");
            }
        }

        private void btnAgregar_Click(object sender, EventArgs e)// llenar random
        {
            try
            {
                
                int j = 0;
                while (j < arreglo.Length)
                {
                    num = rand.Next(0, 200);
                    dataGridView1[0, j].Value = num ;
                    arreglo[j] = num;
                    j++;
                }
                MessageBox.Show("arreglo lleno");

            }
            catch (Exception)
            {
                MessageBox.Show("llenar correctamente");
            }

        }

        private void btnlimpiar_Click(object sender, EventArgs e)
        {
            dataGridView1.Rows.Clear();
            
            
        }

        private void btnOrdenar_Click(object sender, EventArgs e)
        {
            dataGridView1.Columns.Add("", "");
            int[] arreglo2 = new int[longitud];
               arreglo2= shellSort();
            for (int i = 0; i < arreglo2.Length; i++)
            {
                dataGridView1[1, i].Value = arreglo2[i];
            }
            
        }
    }
}
