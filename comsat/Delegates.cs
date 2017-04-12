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
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;

namespace comsat
{
    /// <summary>
    /// Delegate para consultar o status operacional.
    /// </summary>
    /// <param name="numeroSessao">Número da sessão</param>
    /// <param name="codigoDeAtivacao">Código de ativação do SAT.</param>
    /// <returns>Ponteiro com informações do código de ativação.</returns>
    [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
    internal delegate IntPtr DEL_ConsultarStatusOperacional(int numeroSessao,
        [MarshalAs(UnmanagedType.LPStr)] string codigoDeAtivacao);

    /// <summary>
    /// Delegate para ativação do SAT.
    /// </summary>
    /// <param name="numeroSessao">Número de sessão.</param>
    /// <param name="subComando">Sub-comando.</param>
    /// <param name="codigoDeAtivacao">Código de ativação do SAT</param>
    /// <param name="CNPJ">CNPJ do contribuinte</param>
    /// <param name="cUF">Código do estado.</param>
    /// <returns>Ponteiro com informações de ativação.</returns>
    [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
    internal delegate IntPtr DEL_AtivarSAT(int numeroSessao, int subComando,
        [MarshalAs(UnmanagedType.LPStr)] string codigoDeAtivacao,
        [MarshalAs(UnmanagedType.LPStr)] string CNPJ, int cUF);

    /// <summary>
    /// Delegate para comunicação com o SEFAZ e troca de certificados.
    /// </summary>
    /// <param name="numeroSessao">Número de sessão</param>
    /// <param name="codigoDeAtivacao">Código de ativação do SAT</param>
    /// <param name="certificado">Opção do certificado.</param>
    /// <returns>Ponteiro com informações do certificado.</returns>
    [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
    internal delegate IntPtr DEL_ComunicarCertificadoICPBRASIL(int numeroSessao,
        [MarshalAs(UnmanagedType.LPStr)] string codigoDeAtivacao,
        [MarshalAs(UnmanagedType.LPStr)] string certificado);

    /// <summary>
    /// Delegate para envio dos dados de venda para o SAT.
    /// </summary>
    /// <param name="numeroSessao">Número de sessão.</param>
    /// <param name="codigoDeAtivacao">Código de ativação do SAT</param>
    /// <param name="dadosVenda">Xml de vendas para envio no equipamento</param>
    /// <returns>Ponteiro com informações de venda.</returns>
    [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
    internal delegate IntPtr DEL_EnviarDadosVenda(int numeroSessao,
        [MarshalAs(UnmanagedType.LPStr)] string codigoDeAtivacao,
        [MarshalAs(UnmanagedType.LPStr)] string dadosVenda);

    /// <summary>
    /// Delegate para cancelar venda.
    /// </summary>
    /// <param name="numeroSessao">Número da sessão.</param>
    /// <param name="codigoDeAtivacao">Código de ativação do SAT</param>
    /// <param name="chave">Chave do CFe cancelamento</param>
    /// <param name="dadosCancelamento">XML dos dados de cancelamento.</param>
    /// <returns>Ponteiro com informações de cancelamento.</returns>
    [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
    internal delegate IntPtr DEL_CancelarUltimaVenda(int numeroSessao,
        [MarshalAs(UnmanagedType.LPStr)] string codigoDeAtivacao,
        [MarshalAs(UnmanagedType.LPStr)] string chave,
        [MarshalAs(UnmanagedType.LPStr)] string dadosCancelamento);

    /// <summary>
    /// Delegate para consulta do SAT.
    /// </summary>
    /// <param name="numeroSessao">Número da sessão.</param>
    /// <returns>Ponteiro com informações da consulta.</returns>
    [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
    internal delegate IntPtr DEL_ConsultarSAT(int numeroSessao);

    /// <summary>
    /// Delegate para realizar o teste fim a fim,
    /// </summary>
    /// <param name="numeroSessao">Número de sessão</param>
    /// <param name="codigoDeAtivacao">Código de ativação do SAT</param>
    /// <param name="dadosVenda">Dados da venda para teste.</param>
    /// <returns>Ponteiro com informações de fim a fim</returns>
    [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
    internal delegate IntPtr DEL_TesteFimAFim(int numeroSessao,
        [MarshalAs(UnmanagedType.LPStr)] string codigoDeAtivacao,
        [MarshalAs(UnmanagedType.LPStr)] string dadosVenda);

    /// <summary>
    /// Delegate para consultar o número de sessão.
    /// </summary>
    /// <param name="numeroSessao">Número de sessão.</param>
    /// <param name="codigoDeAtivacao">Código de ativação do SAT.</param>
    /// <param name="cNumeroDeSessao">Código da sessão para ser consultada.</param>
    /// <returns>Ponteiro com informações da sessão.</returns>
    [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
    internal delegate IntPtr DEL_ConsultarNumeroSessao(int numeroSessao,
        [MarshalAs(UnmanagedType.LPStr)] string codigoDeAtivacao,
        int cNumeroDeSessao);

    /// <summary>
    /// Delegate para configurar interface de rede.
    /// </summary>
    /// <param name="numeroSessao">Número da sessão.</param>
    /// <param name="codigoDeAtivacao">Código de ativação do SAT</param>
    /// <param name="dadosConfiguracao">Dados para configuração em formato XML.</param>
    /// <returns>Ponteiro com informações da configuração.</returns>
    [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
    internal delegate IntPtr DEL_ConfigurarInterfaceDeRede(int numeroSessao,
        [MarshalAs(UnmanagedType.LPStr)] string codigoDeAtivacao,
        [MarshalAs(UnmanagedType.LPStr)] string dadosConfiguracao);

    /// <summary>
    /// Delegate para associar assinatura do equipamento.
    /// </summary>
    /// <param name="numeroSessao">Número de sessão.</param>
    /// <param name="codigoDeAtivacao">Código de ativação do SAT</param>
    /// <param name="CNPJvalue">CNPJ Softwarehouse + Contribuinte</param>
    /// <param name="assinaturaCNPJs">Assinatura dos CNPJs.</param>
    /// <returns>Ponteiro com informações da assinatura.</returns>
    [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
    internal delegate IntPtr DEL_AssociarAssinatura(int numeroSessao, [MarshalAs(UnmanagedType.LPStr)] string codigoDeAtivacao,
        [MarshalAs(UnmanagedType.LPStr)] string CNPJvalue, // CNPJvalue = Desenvolvedor + Emitente
        [MarshalAs(UnmanagedType.LPStr)] string assinaturaCNPJs);

    /// <summary>
    /// Delegate para atualizar o software interno do SAT.
    /// </summary>
    /// <param name="numeroSessao">Numero de sessão.</param>
    /// <param name="codigoDeAtivacao">Código de ativação do SAT.</param>
    /// <returns>Ponteiro com informações de assinatura.</returns>
    [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
    internal delegate IntPtr DEL_AtualizarSoftwareSAT(int numeroSessao,
        [MarshalAs(UnmanagedType.LPStr)] string codigoDeAtivacao);

    /// <summary>
    /// Delegate para extração dos logs do SAT.
    /// </summary>
    /// <param name="numeroSessao">Número de sessão.</param>
    /// <param name="codigoDeAtivacao">Código de ativação do SAT.</param>
    /// <returns>Ponteiro com informações da extração.</returns>
    [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
    internal delegate IntPtr DEL_ExtrairLogs(int numeroSessao,
        [MarshalAs(UnmanagedType.LPStr)] string codigoDeAtivacao);

    /// <summary>
    /// Delegate para bloqueio do SAT.
    /// </summary>
    /// <param name="numeroSessao">Número da sessão.</param>
    /// <param name="codigoDeAtivacao">Código de ativação do SAT</param>
    /// <returns>Ponteiro com informações do bloqueio.</returns>
    [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
    internal delegate IntPtr DEL_BloquearSAT(int numeroSessao,
        [MarshalAs(UnmanagedType.LPStr)] string codigoDeAtivacao);

    /// <summary>
    /// Delegate para desbloqueio do SAT.
    /// </summary>
    /// <param name="numeroSessao">Número da sessão.</param>
    /// <param name="codigoDeAtivacao">Código de ativação do SAT</param>
    /// <returns>Ponteiro com informações do desbloqueio.</returns>
    [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
    internal delegate IntPtr DEL_DesbloquearSAT(int numeroSessao,
        [MarshalAs(UnmanagedType.LPStr)] string codigoDeAtivacao);

    /// <summary>
    /// Delegate para troca do código de ativação do equipamento.
    /// </summary>
    /// <param name="numeroSessao">Número da sessão.</param>
    /// <param name="codigoDeAtivacao">Código de ativação do SAT</param>
    /// <param name="opcao">Opção para troca</param>
    /// <param name="novoCodigo">Novo código de ativação</param>
    /// <param name="confNovoCodigo">Confirmação código de ativação.</param>
    /// <returns>Ponteiro com informações da troca de código.</returns>
    [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
    internal delegate IntPtr DEL_TrocarCodigoDeAtivacao(int numeroSessao,
        [MarshalAs(UnmanagedType.LPStr)] string codigoDeAtivacao,
        [MarshalAs(UnmanagedType.LPStr)] string opcao,
        [MarshalAs(UnmanagedType.LPStr)] string novoCodigo,
        [MarshalAs(UnmanagedType.LPStr)] string confNovoCodigo);
}
