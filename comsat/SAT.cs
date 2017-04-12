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
using System.IO;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;

namespace comsat
{
    /// <summary>
    /// Classe para comunicação dom os elementos do SAT.
    /// </summary>
    public sealed class SAT
    {
        private string dllPath;
        private IntPtr dllPtr;

        /// <summary>
        /// Encontra o caminho do DLL.
        /// </summary>
        /// <param name="dllPath"></param>
        public SAT(string dllPath)
        {
            if (!File.Exists(dllPath))
                throw new IOException("Arquivo \"" + dllPath + "\" não foi encontrado.");

            this.dllPath = dllPath;
            this.dllPtr = Win32Native.LoadLibrary(this.dllPath);

            #region [DLL] - Referencia todas as funções as DLL.
            this.FNC_ConsultarStatusOperacional = (DEL_ConsultarStatusOperacional)Marshal.GetDelegateForFunctionPointer(
                Win32Native.GetProcAddress(this.dllPtr, "ConsultarStatusOperacional"),
                typeof(DEL_ConsultarStatusOperacional));

            this.FNC_AtivarSAT = (DEL_AtivarSAT)Marshal.GetDelegateForFunctionPointer(
                Win32Native.GetProcAddress(this.dllPtr, "AtivarSAT"),
                typeof(DEL_AtivarSAT));

            this.FNC_ComunicarCertificadoICPBRASIL = (DEL_ComunicarCertificadoICPBRASIL)Marshal.GetDelegateForFunctionPointer(
                Win32Native.GetProcAddress(this.dllPtr, "ComunicarCertificadoICPBRASIL"),
                typeof(DEL_ComunicarCertificadoICPBRASIL));

            this.FNC_EnviarDadosVenda = (DEL_EnviarDadosVenda)Marshal.GetDelegateForFunctionPointer(
                Win32Native.GetProcAddress(this.dllPtr, "EnviarDadosVenda"),
                typeof(DEL_EnviarDadosVenda));

            this.FNC_CancelarUltimaVenda = (DEL_CancelarUltimaVenda)Marshal.GetDelegateForFunctionPointer(
                Win32Native.GetProcAddress(this.dllPtr, "CancelarUltimaVenda"),
                typeof(DEL_CancelarUltimaVenda));

            this.FNC_ConsultarSAT = (DEL_ConsultarSAT)Marshal.GetDelegateForFunctionPointer(
                Win32Native.GetProcAddress(this.dllPtr, "ConsultarSAT"),
                typeof(DEL_ConsultarSAT));

            this.FNC_TesteFimAFim = (DEL_TesteFimAFim)Marshal.GetDelegateForFunctionPointer(
                Win32Native.GetProcAddress(this.dllPtr, "TesteFimAFim"),
                typeof(DEL_TesteFimAFim));

            this.FNC_ConsultarNumeroSessao = (DEL_ConsultarNumeroSessao)Marshal.GetDelegateForFunctionPointer(
                Win32Native.GetProcAddress(this.dllPtr, "ConsultarNumeroSessao"),
                typeof(DEL_ConsultarNumeroSessao));

            this.FNC_ConfigurarInterfaceDeRede = (DEL_ConfigurarInterfaceDeRede)Marshal.GetDelegateForFunctionPointer(
                Win32Native.GetProcAddress(this.dllPtr, "ConfigurarInterfaceDeRede"),
                typeof(DEL_ConfigurarInterfaceDeRede));

            this.FNC_AssociarAssinatura = (DEL_AssociarAssinatura)Marshal.GetDelegateForFunctionPointer(
                Win32Native.GetProcAddress(this.dllPtr, "AssociarAssinatura"),
                typeof(DEL_AssociarAssinatura));

            this.FNC_AtualizarSoftwareSAT = (DEL_AtualizarSoftwareSAT)Marshal.GetDelegateForFunctionPointer(
                Win32Native.GetProcAddress(this.dllPtr, "AtualizarSoftwareSAT"),
                typeof(DEL_AtualizarSoftwareSAT));

            this.FNC_ExtrairLogs = (DEL_ExtrairLogs)Marshal.GetDelegateForFunctionPointer(
                Win32Native.GetProcAddress(this.dllPtr, "ExtrairLogs"),
                typeof(DEL_ExtrairLogs));

            this.FNC_BloquearSAT = (DEL_BloquearSAT)Marshal.GetDelegateForFunctionPointer(
                Win32Native.GetProcAddress(this.dllPtr, "BloquearSAT"),
                typeof(DEL_BloquearSAT));

            this.FNC_DesbloquearSAT = (DEL_DesbloquearSAT)Marshal.GetDelegateForFunctionPointer(
                Win32Native.GetProcAddress(this.dllPtr, "DesbloquearSAT"),
                typeof(DEL_DesbloquearSAT));

            this.FNC_TrocarCodigoDeAtivacao = (DEL_TrocarCodigoDeAtivacao)Marshal.GetDelegateForFunctionPointer(
                Win32Native.GetProcAddress(this.dllPtr, "TrocarCodigoDeAtivacao"),
                typeof(DEL_TrocarCodigoDeAtivacao));
            #endregion

        }

        ~SAT()
        {
            Win32Native.FreeLibrary(this.dllPtr);
        }

        /// <summary>
        /// ConsultarStatusOperacional()
        /// </summary>
        /// <param name="numeroSessao"></param>
        /// <param name="codAtivacao"></param>
        /// <returns></returns>
        public string ConsultarStatusOperacional(int numeroSessao, string codAtivacao)
        {
            return Marshal.PtrToStringAnsi(this.FNC_ConsultarStatusOperacional(numeroSessao, codAtivacao));
        }

        /// <summary>
        /// AtivarSAT()
        /// </summary>
        /// <param name="numeroSessao"></param>
        /// <param name="subComando"></param>
        /// <param name="codigoDeAtivacao"></param>
        /// <param name="CNPJ"></param>
        /// <param name="cUF"></param>
        /// <returns></returns>
        public string AtivarSAT(int numeroSessao, int subComando, string codigoDeAtivacao, string CNPJ, int cUF)
        {
            return Marshal.PtrToStringAnsi(this.FNC_AtivarSAT(numeroSessao, subComando, codigoDeAtivacao, CNPJ, cUF));
        }

        /// <summary>
        /// ComunicarCertificadoICPBRASIL()
        /// </summary>
        /// <param name="numeroSessao"></param>
        /// <param name="codigoDeAtivacao"></param>
        /// <param name="certificado"></param>
        /// <returns></returns>
        public string ComunicarCertificadoICPBRASIL(int numeroSessao, string codigoDeAtivacao, string certificado)
        {
            return Marshal.PtrToStringAnsi(this.FNC_ComunicarCertificadoICPBRASIL(numeroSessao, codigoDeAtivacao, certificado));
        }

        /// <summary>
        /// EnviarDadosVenda()
        /// </summary>
        /// <param name="numeroSessao"></param>
        /// <param name="codigoDeAtivacao"></param>
        /// <param name="dadosVenda"></param>
        /// <returns></returns>
        public string EnviarDadosVenda(int numeroSessao, string codigoDeAtivacao, string dadosVenda)
        {
            return Marshal.PtrToStringAnsi(this.FNC_EnviarDadosVenda(numeroSessao, codigoDeAtivacao, dadosVenda));
        }

        /// <summary>
        /// CancelarUltimaVenda()
        /// </summary>
        /// <param name="numeroSessao"></param>
        /// <param name="codigoDeAtivacao"></param>
        /// <param name="chave"></param>
        /// <param name="dadosCancelamento"></param>
        /// <returns></returns>
        public string CancelarUltimaVenda(int numeroSessao, string codigoDeAtivacao, string chave, string dadosCancelamento)
        {
            return Marshal.PtrToStringAnsi(this.FNC_CancelarUltimaVenda(numeroSessao, codigoDeAtivacao, chave, dadosCancelamento));
        }

        /// <summary>
        /// ConsultarSAT()
        /// </summary>
        /// <param name="numeroSessao"></param>
        /// <returns></returns>
        public string ConsultarSAT(int numeroSessao)
        {
            return Marshal.PtrToStringAnsi(this.FNC_ConsultarSAT(numeroSessao));
        }

        /// <summary>
        /// TesteFimAFim()
        /// </summary>
        /// <param name="numeroSessao"></param>
        /// <param name="codigoDeAtivacao"></param>
        /// <param name="dadosVenda"></param>
        /// <returns></returns>
        public string TesteFimAFim(int numeroSessao, string codigoDeAtivacao, string dadosVenda)
        {
            return Marshal.PtrToStringAnsi(this.FNC_TesteFimAFim(numeroSessao, codigoDeAtivacao, dadosVenda));
        }

        /// <summary>
        /// ConsultarNumeroSessao()
        /// </summary>
        /// <param name="numeroSessao"></param>
        /// <param name="codigoDeAtivacao"></param>
        /// <param name="cNumeroDeSessao"></param>
        /// <returns></returns>
        public string ConsultarNumeroSessao(int numeroSessao, string codigoDeAtivacao, int cNumeroDeSessao)
        {
            return Marshal.PtrToStringAnsi(this.FNC_ConsultarNumeroSessao(numeroSessao, codigoDeAtivacao, cNumeroDeSessao));
        }

        /// <summary>
        /// ConfigurarInterfaceDeRede()
        /// </summary>
        /// <param name="numeroSessao"></param>
        /// <param name="codigoDeAtivacao"></param>
        /// <param name="dadosConfiguracao"></param>
        /// <returns></returns>
        public string ConfigurarInterfaceDeRede(int numeroSessao, string codigoDeAtivacao, string dadosConfiguracao)
        {
            return Marshal.PtrToStringAnsi(this.FNC_ConfigurarInterfaceDeRede(numeroSessao, codigoDeAtivacao, dadosConfiguracao));
        }

        /// <summary>
        /// AssociarAssinatura()
        /// </summary>
        /// <param name="numeroSessao"></param>
        /// <param name="codigoDeAtivacao"></param>
        /// <param name="CNPJvalue"></param>
        /// <param name="assinaturaCNPJs"></param>
        /// <returns></returns>
        public string AssociarAssinatura(int numeroSessao, string codigoDeAtivacao, string CNPJvalue, string assinaturaCNPJs)
        {
            return Marshal.PtrToStringAnsi(this.FNC_AssociarAssinatura(numeroSessao, codigoDeAtivacao, CNPJvalue, assinaturaCNPJs));
        }

        /// <summary>
        /// AtualizarSoftwareSAT()
        /// </summary>
        /// <param name="numeroSessao"></param>
        /// <param name="codigoDeAtivacao"></param>
        /// <returns></returns>
        public string AtualizarSoftwareSAT(int numeroSessao, string codigoDeAtivacao)
        {
            return Marshal.PtrToStringAnsi(this.FNC_AtualizarSoftwareSAT(numeroSessao, codigoDeAtivacao));
        }

        /// <summary>
        /// ExtrairLogs()
        /// </summary>
        /// <param name="numeroSessao"></param>
        /// <param name="codigoDeAtivacao"></param>
        /// <returns></returns>
        public string ExtrairLogs(int numeroSessao, string codigoDeAtivacao)
        {
            return Marshal.PtrToStringAnsi(this.FNC_ExtrairLogs(numeroSessao, codigoDeAtivacao));
        }

        /// <summary>
        /// BloquearSAT()
        /// </summary>
        /// <param name="numeroSessao"></param>
        /// <param name="codigoDeAtivacao"></param>
        /// <returns></returns>
        public string BloquearSAT(int numeroSessao, string codigoDeAtivacao)
        {
            return Marshal.PtrToStringAnsi(this.FNC_BloquearSAT(numeroSessao, codigoDeAtivacao));
        }

        /// <summary>
        /// DesbloquearSAT()
        /// </summary>
        /// <param name="numeroSessao"></param>
        /// <param name="codigoDeAtivacao"></param>
        /// <returns></returns>
        public string DesbloquearSAT(int numeroSessao, string codigoDeAtivacao)
        {
            return Marshal.PtrToStringAnsi(this.FNC_DesbloquearSAT(numeroSessao, codigoDeAtivacao));
        }

        /// <summary>
        /// TrocarCodigoDeAtivacao()
        /// </summary>
        /// <param name="numeroSessao"></param>
        /// <param name="codigoDeAtivacao"></param>
        /// <param name="opcao"></param>
        /// <param name="novoCodigo"></param>
        /// <param name="confNovoCodigo"></param>
        /// <returns></returns>
        public string TrocarCodigoDeAtivacao(int numeroSessao, string codigoDeAtivacao, string opcao, string novoCodigo, string confNovoCodigo)
        {
            return Marshal.PtrToStringAnsi(this.FNC_TrocarCodigoDeAtivacao(numeroSessao, codigoDeAtivacao, opcao, novoCodigo, confNovoCodigo));
        }

        #region [DELEGATES] Declarações das chamadas de funções do DLL.

        private DEL_ConsultarStatusOperacional FNC_ConsultarStatusOperacional;
        private DEL_AtivarSAT FNC_AtivarSAT;
        private DEL_ComunicarCertificadoICPBRASIL FNC_ComunicarCertificadoICPBRASIL;
        private DEL_EnviarDadosVenda FNC_EnviarDadosVenda;
        private DEL_CancelarUltimaVenda FNC_CancelarUltimaVenda;
        private DEL_ConsultarSAT FNC_ConsultarSAT;
        private DEL_TesteFimAFim FNC_TesteFimAFim;
        private DEL_ConsultarNumeroSessao FNC_ConsultarNumeroSessao;
        private DEL_ConfigurarInterfaceDeRede FNC_ConfigurarInterfaceDeRede;
        private DEL_AssociarAssinatura FNC_AssociarAssinatura;
        private DEL_AtualizarSoftwareSAT FNC_AtualizarSoftwareSAT;
        private DEL_ExtrairLogs FNC_ExtrairLogs;
        private DEL_BloquearSAT FNC_BloquearSAT;
        private DEL_DesbloquearSAT FNC_DesbloquearSAT;
        private DEL_TrocarCodigoDeAtivacao FNC_TrocarCodigoDeAtivacao;

        #endregion

    }
}
