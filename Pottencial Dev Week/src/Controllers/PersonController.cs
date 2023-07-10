using Microsoft.AspNetCore.Mvc;
using src.Models;

using Microsoft.EntityFrameworkCore;
using src.Persistence;

namespace src.Controllers;

[ApiController]
[Route("[controller]")]
public class PersonController : ControllerBase{

    private DataBaseContext _context { get; set; }

    public PersonController(DataBaseContext context)
    {
        this._context = context;
    }

    //[HttpGet]
    //public List<Person> Get(){
        //Person pessoa = new Person("Thiago Santos", 33, "07811572427");
        //Contract newContract = new Contract("abc123", 60.00);
        //pessoa.contracts.Add(newContract);

      //  return _context.Persons.Include( p => p.contracts).ToList();
    //}

    [HttpGet]
    public ActionResult<List<Person>> Get(){
        var result = _context.Persons.Include( p => p.contracts).ToList();

       // if(result is null) {
            //return NoContent();
       // }

       if(!result.Any()){
        return NoContent();
       }

        return Ok(result);
    }

    //[HttpPost]
    //public Person Post([FromBody] Person person){
    //    _context.Persons.Add(person);
    //    _context.SaveChanges();
    //    return person;
    //}
    [HttpPost]
    public ActionResult<Person> Post([FromBody]Person person){
       try
       {
        _context.Persons.Add(person);
        _context.SaveChanges();
       }
       catch (System.Exception)
       {
        return BadRequest();
       }

        return Created("created", person);
    }

    //[HttpPut("{id}")]
    //public string Update([FromRoute] int id, [FromBody] Person person){

    //    _context.Persons.Update(person);
    //    _context.SaveChanges();

    //    return "Dados do id " + id + " atualizados";
    //}
    [HttpPut("{id}")]
    public ActionResult<Object> Update([FromRoute]int id, [FromBody]Person person){

        var result = _context.Persons.SingleOrDefault(e => e.Id == id);

        if(result is null){
            return NotFound(new {
                msg = "Registro não Encontrado!"
            });
        }
        try
        {
            _context.Persons.Update(person);
            _context.SaveChanges();
        }
        catch (System.Exception)
        {
            
            return BadRequest(new {
                msg = "Erro ao atualizar os dados do id " + id + " "
            });
        }

        return Ok(new {
            msg = "Dados do id " + id + " atualizados"
        });
    }

    //[HttpDelete("{id}")]
    //public string Delete(int id){
        //var result = _context.Persons.SingleOrDefault(e => e.Id = id)

       // _context.Persons.Remove(result);
       // _context.SaveChanges();

       // return "Dados do id " + id + " deletados";
    //}

    [HttpDelete("{id}")]
    public ActionResult<Object> Delete([FromRoute] int id){
      var result = _context.Persons.SingleOrDefault(e => e.Id == id);

        if(result is null){
            return BadRequest(new {
                msg = "Conteúdo Inexistente, solicitação inválida!"
            });
        }

         _context.Persons.Remove(result);
        _context.SaveChanges();

        return Ok(new{
            msg = "Dados do id " + id + " deletados"
        });
    }
}