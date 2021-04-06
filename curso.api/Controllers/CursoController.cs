using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;
using curso.api.Models.Cursos;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Swashbuckle.AspNetCore.Annotations;

namespace curso.api.Controllers
{
    [Route("api/v1/cursos")]
    [ApiController]
    [Authorize]
    public class CursoController : ControllerBase
    {
        [SwaggerResponse(statusCode: 201, description: "Sucesso ao cadastrar curso")]
        [SwaggerResponse(statusCode: 401, description: "Não autorizado!")]
        [HttpPost]
        [Route("")]

        public async Task<IActionResult> Post(CursoViewModelInput cursoViewModelInput)
        {
            var codigoUsuario = int.Parse(User.FindFirst(c => c.Type == ClaimTypes.NameIdentifier)?.Value);
            return Created("", cursoViewModelInput);
        }

        //Este serviço permite obter todos os cursos ativos do usuário
        //<returns> Retorna status ok e dados do curso do usuário
        [SwaggerResponse(statusCode: 201, description: "Sucesso ao cadastrar curso")]
        [SwaggerResponse(statusCode: 401, description: "Não autorizado!")]
        [HttpGet]
        [Route("")]

        public async Task<IActionResult> Get()
        {
            var cursos = new List<CursoViewModelOutput>();

          //  var codigoUsuario = int.Parse(User.FindFirst(c => c.Type == ClaimTypes.NameIdentifier)?.Value);
            cursos.Add(new CursoViewModelOutput()
            {
               Login = "TesteLogin",
                Descricao = "TesteDescricao",
                Nome = "TesteNome"
            });

            return Ok(cursos);
        }
    }
}
