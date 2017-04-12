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

namespace TesteDLLSat
{
    partial class Form1
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.txtCodAtivacao = new System.Windows.Forms.TextBox();
            this.lblCodAtivacao = new System.Windows.Forms.Label();
            this.btnConsultarSAT = new System.Windows.Forms.Button();
            this.txtDllPath = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.btnConsultarStatusOperacional = new System.Windows.Forms.Button();
            this.txtUltRetorno = new System.Windows.Forms.RichTextBox();
            this.lblUltRetorno = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // txtCodAtivacao
            // 
            this.txtCodAtivacao.Location = new System.Drawing.Point(29, 121);
            this.txtCodAtivacao.Name = "txtCodAtivacao";
            this.txtCodAtivacao.Size = new System.Drawing.Size(155, 20);
            this.txtCodAtivacao.TabIndex = 0;
            // 
            // lblCodAtivacao
            // 
            this.lblCodAtivacao.AutoSize = true;
            this.lblCodAtivacao.Location = new System.Drawing.Point(26, 105);
            this.lblCodAtivacao.Name = "lblCodAtivacao";
            this.lblCodAtivacao.Size = new System.Drawing.Size(103, 13);
            this.lblCodAtivacao.TabIndex = 1;
            this.lblCodAtivacao.Text = "Código de Ativação:";
            // 
            // btnConsultarSAT
            // 
            this.btnConsultarSAT.Location = new System.Drawing.Point(29, 58);
            this.btnConsultarSAT.Name = "btnConsultarSAT";
            this.btnConsultarSAT.Size = new System.Drawing.Size(155, 23);
            this.btnConsultarSAT.TabIndex = 2;
            this.btnConsultarSAT.Text = "ConsultarSAT";
            this.btnConsultarSAT.UseVisualStyleBackColor = true;
            this.btnConsultarSAT.Click += new System.EventHandler(this.btnConsultarSAT_Click);
            // 
            // txtDllPath
            // 
            this.txtDllPath.Location = new System.Drawing.Point(29, 32);
            this.txtDllPath.Name = "txtDllPath";
            this.txtDllPath.Size = new System.Drawing.Size(155, 20);
            this.txtDllPath.TabIndex = 3;
            this.txtDllPath.Text = "dllsat.dll";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(26, 16);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(74, 13);
            this.label1.TabIndex = 4;
            this.label1.Text = "Caminho DLL:";
            // 
            // btnConsultarStatusOperacional
            // 
            this.btnConsultarStatusOperacional.Location = new System.Drawing.Point(29, 147);
            this.btnConsultarStatusOperacional.Name = "btnConsultarStatusOperacional";
            this.btnConsultarStatusOperacional.Size = new System.Drawing.Size(155, 23);
            this.btnConsultarStatusOperacional.TabIndex = 5;
            this.btnConsultarStatusOperacional.Text = "ConsultarStatusOperacional";
            this.btnConsultarStatusOperacional.UseVisualStyleBackColor = true;
            this.btnConsultarStatusOperacional.Click += new System.EventHandler(this.btnConsultarStatusOperacional_Click);
            // 
            // txtUltRetorno
            // 
            this.txtUltRetorno.Location = new System.Drawing.Point(190, 32);
            this.txtUltRetorno.Name = "txtUltRetorno";
            this.txtUltRetorno.Size = new System.Drawing.Size(465, 138);
            this.txtUltRetorno.TabIndex = 6;
            this.txtUltRetorno.Text = "";
            // 
            // lblUltRetorno
            // 
            this.lblUltRetorno.AutoSize = true;
            this.lblUltRetorno.Location = new System.Drawing.Point(187, 16);
            this.lblUltRetorno.Name = "lblUltRetorno";
            this.lblUltRetorno.Size = new System.Drawing.Size(80, 13);
            this.lblUltRetorno.TabIndex = 7;
            this.lblUltRetorno.Text = "Último Retorno:";
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(684, 195);
            this.Controls.Add(this.lblUltRetorno);
            this.Controls.Add(this.txtUltRetorno);
            this.Controls.Add(this.btnConsultarStatusOperacional);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.txtDllPath);
            this.Controls.Add(this.btnConsultarSAT);
            this.Controls.Add(this.lblCodAtivacao);
            this.Controls.Add(this.txtCodAtivacao);
            this.Name = "Form1";
            this.Text = "Form1";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox txtCodAtivacao;
        private System.Windows.Forms.Label lblCodAtivacao;
        private System.Windows.Forms.Button btnConsultarSAT;
        private System.Windows.Forms.TextBox txtDllPath;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button btnConsultarStatusOperacional;
        private System.Windows.Forms.RichTextBox txtUltRetorno;
        private System.Windows.Forms.Label lblUltRetorno;
    }
}

