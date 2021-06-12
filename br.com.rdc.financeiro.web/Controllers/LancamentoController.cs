using AutoMapper;
using br.com.rdc.financeiro.application.DTO;
using br.com.rdc.financeiro.application.IncluirLancamentos;
using br.com.rdc.financeiro.domain.Financeiro.Model;
using br.com.rdc.financeiro.service.Financeiro.Interfaces;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace br.com.rdc.financeiro.web.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class LancamentoController : ControllerBase
    {
        private readonly IFinanceiroService _financeiroService;
        private readonly IMapper _mapper;
        private readonly ILogger<LancamentoController> _logger;
        private static Contador _CONTADOR = new Contador();

        public LancamentoController(IFinanceiroService financeiroService, IMapper mapper, ILogger<LancamentoController> logger)
        {
            _financeiroService = financeiroService;
            _mapper = mapper;
            _logger = logger;
        }

        [HttpGet]
        public async Task<IActionResult> Get()
        {
            _CONTADOR.Incrementar();
            if (_CONTADOR.ValorAtual % 3 == 0) throw new ApplicationException();
            _logger.LogInformation("Lancamentos Get: ");

            var lancamentos = await _financeiroService.ListarLancamentos();
            IList<LancamentoDTO> lancamentosDTO = _mapper.Map<IList<Lancamento>, LancamentoDTO[]>(lancamentos.Item1);
            var result = new ListarLancamentosResponse() { Totalizadores = lancamentos.Item2, Lancamentos = lancamentosDTO };
            return Ok(result);
        }

        [HttpGet("{data}")]
        public async Task<IActionResult> ListarLancamentos(string data)
        {
            _logger.LogInformation("ListarLancamento: {Data}", data);

            var lancamentos = await _financeiroService.ListarLancamentos(data);
            IList<LancamentoDTO> lancamentosDTO = _mapper.Map<IList<Lancamento>, LancamentoDTO[]>(lancamentos.Item1);
            var result = new ListarLancamentosResponse() { Totalizadores = lancamentos.Item2, Lancamentos = lancamentosDTO};
            return Ok(result);
        }

        [HttpPost]
        [Route("IncluirLancamentos")]
        public async Task<IActionResult> IncluirLancamentos([FromBody] IncluirLancamentosRequest request)
        {
            IList<Lancamento> lancamentos = _mapper.Map<LancamentoDTO[], IList<Lancamento>>(request.Lancamentos);
            return Ok(await _financeiroService.IncluirLancamentos(lancamentos));
        }

    }
}
