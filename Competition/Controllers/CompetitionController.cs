using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using way2.Model;

namespace way2.Controllers{

    [Route("api/[Controller]")]
    public class CompetitionController : Controller
    {
        [HttpGet("{id}")]
        public async Task<IActionResult> GetCompetitionByIdAsync(int id){
            CompetitionStandings competitionData = new CompetitionStandings();
            try{
                using (var httpClient = new HttpClient())
                {
                    httpClient.DefaultRequestHeaders.Add("X-Auth-Token", "a039206afb5f4e47b89ec1b99b1898e8");
                    using (var response = await httpClient.GetAsync("http://api.football-data.org/v2/competitions/"+id.ToString()+"/standings"))
                    {
                        string apiResponse = await response.Content.ReadAsStringAsync();
                        competitionData = JsonConvert.DeserializeObject<CompetitionStandings>(apiResponse);
                       
                        if(competitionData.error == 403)
                        {   
                            competitionData.message = "O acesso a esse código é restrito por favor tente outro código.";
                            return Forbid();
                        }
                        else if (competitionData.error == 404)
                        {    
                            competitionData.message = "Código inválido";
                            return NotFound(competitionData);
                        }
                        else if (competitionData.error == 400)
                        {
                            competitionData.message = "O valor enviado é maior que a quantidade permitida, a quantidade máxima é 4 dígitos";
                            return BadRequest(competitionData);
                        }
                    }
                }
            }
            catch(Exception)
            {
                competitionData.message = "ocorreu um erro inesperado por favor tente novamente mais tarde";
            }
            
            return Ok(competitionData);
            
        }
    }
}