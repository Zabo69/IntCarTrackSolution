using System;
using System.Text;

namespace RestWsAutarquias
{
    public class Log
    {
        private System.IO.StreamWriter fp;
        private String fich = "";

        public Log(String filename)
        {
            try
            {
                // fp = new System.IO.StreamWriter(filename, true, Encoding.Default);
                fich = filename;
            }
            catch (Exception ex)
            {
                // System.Windows.Forms.MessageBox.Show(ex.Message);
            }
        }

        public void escreve(String linha)
         {
            try
            {
                fp = new System.IO.StreamWriter(fich, true, Encoding.Default);
                fp.WriteLine(linha);
                this.fecha();
            }
            catch
            {
            }
        }

        public void fecha()
        {
            try
            {
                fp.Close();
            }
            catch
            {
            }
        }
    }
}