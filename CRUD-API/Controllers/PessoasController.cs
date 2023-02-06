using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using crud_api.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace crud_api.Controllers
{
    [ApiController]
    [Route("api/[controller]")]

    public class PessoasController : ControllerBase
    {
        public readonly Context _context;

        public PessoasController(Context context)
        {
            _context = context;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<Pessoa>>> ConsultarPessoa(){
            return await _context.Pessoas.ToListAsync();
        }

        [HttpGet("{pessoaId}")]
        public async Task<ActionResult<Pessoa>> ConsultarPessoaPorId(int idPessoa){
            
            Pessoa pessoa = await _context.Pessoas.FindAsync(idPessoa);

            if(pessoa == null) return NotFound();

            return pessoa;
        }

        [HttpPost]
        public async Task<ActionResult<Pessoa>> SalvarPessoa(Pessoa pessoa){
            await _context.Pessoas.AddAsync(pessoa);
            await _context.SaveChangesAsync();
            
            return Ok();
        }

        [HttpPut]
        public async Task<ActionResult> AtualizarPessoa(Pessoa pessoa){
            _context.Pessoas.Update(pessoa);
            await _context.SaveChangesAsync();

            return Ok();
        }

        [HttpDelete("{pessoaId}")]
        public async Task<ActionResult> ExcluirPessoa(int idPessoa){
            var pessoa = await ConsultarPessoaPorId(idPessoa);

            if(pessoa != null){
                 _context.Remove(pessoa);
            }

            return Ok();
        }

    }
}