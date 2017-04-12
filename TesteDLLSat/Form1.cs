/*
THIS SOFTWARE IS PROVIDED BY THE COPYRIGHT HOLDERS AND CONTRIBUTORS "AS IS"
AND ANY EXPRESS OR IMPLIED WARRANTIES, INCLUDING, BUT NOT LIMITED TO, THE
IMPLIED WARRANTIES OF MERCHANTABILITY AND FITNESS FOR A PARTICULAR PURPOSE ARE
DISCLAIMED. IN NO EVENT SHALL THE COPYRIGHT HOLDER OR CONTRIBUTORS BE LIABLE
FOR ANY DIRECT, INDIRECT, INCIDENTAL, SPECIAL, EXEMPLARY, OR CONSEQUENTIAL
DAMAGES (INCLUDING, BUT NOT LIMITED TO, PROCUREMENT OF SUBSTITUTE GOODS OR
SERVICES; LOSS OF USE, DATA, OR PROFITS; OR BUSINESS INTERRUPTION) HOWEVER
CAUSED AND ON ANY THEORY OF LIABILITY, WHETHER IN CONTRACT, STRICT LIABILITY,
OR TORT (INCLUDING NEGLIGENCE OR OTHERWISE) ARISING IN ANY WAY OUT OF THE USE
OF THIS SOFTWARE, EVEN IF ADVISED OF THE POSSIBILITY OF SUCH DAMAGE.
*/
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using comsat;

namespace TesteDLLSat
{
    public partial class Form1 : Form
    {
        private Random seed;

        public Form1()
        {
            InitializeComponent();
            this.seed = new Random();

        }

        private void btnConsultarSAT_Click(object sender, EventArgs e)
        {
            SAT sat = new SAT(this.txtDllPath.Text);
            string sRetorno = sat.ConsultarSAT(this.seed.Next(0, 999999));
            sat = null;

            this.txtUltRetorno.Text = sRetorno;
        }

        private void btnConsultarStatusOperacional_Click(object sender, EventArgs e)
        {
            SAT sat = new SAT(this.txtDllPath.Text);
            string sRetorno = sat.ConsultarStatusOperacional(this.seed.Next(0, 999999), this.txtCodAtivacao.Text);
            sat = null;

            this.txtUltRetorno.Text = sRetorno;
        }
    }
}
