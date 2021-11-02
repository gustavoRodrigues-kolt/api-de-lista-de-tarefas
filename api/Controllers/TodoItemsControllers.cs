using System;
using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;
using api.Models;

namespace api.Controllers
{
    [Route("api/todoItems")]
    [ApiController]
    public class TodoItemsController : ControllerBase
    {
        private static List<TodoItem> todoItems = new List<TodoItem>();

        //Cadastra uma nova tarefa
        [HttpPost]
        public IActionResult Post(TodoItem todoItem)
        {

            //salva a tarefa na lista de tarefas
            todoItems.Add(todoItem);

            //retorna sucesso com a tarefa que foi cadastrada
            return Ok(todoItem);
        }

        //Lista todas as tarefas
        [HttpGet]
        public IActionResult Get()
        {

            //Verifica se existe tarefa na lista
            //Caso não exista retorna 204/NoContent
            if (todoItems.Count == 0)
                return NoContent();

            //Caso exista retorna sucesso com a lista de tarefa
            return Ok(todoItems);
        }

        //Atualiza nossa tarefa
        [HttpPut("{id}")] //https://localhost:5001/api/todoItems/id
        public IActionResult Put(Guid id, TodoItem todoItem)
        {

            //Busca o indice da lista referente a tarefa
            int todoIndex = todoItems.FindIndex(t => t.Id == id);

            //Verifica se a tarefa foi encontrada
            if(todoIndex == -1)
                return BadRequest(new {mensagem = "Id não encontrado"});

            //Atualiza a tarefa
            todoItems[todoIndex] = todoItem;

            //Retorna sucesso com a lista de tarefa atualizada
            return Ok(todoItems);
        }

        [HttpDelete("{id}")]
        public IActionResult Delete(Guid id)
        {
            //Busca o indice da lista referente a tarefa
            int todoIndex = todoItems.FindIndex(t => t.Id == id);
            
            //Verifica se a tarefa foi encontrada
            if(todoIndex == -1)
                return BadRequest(new {message = "Id não encontrado"});

            //Remove a tarefa da lista de tarefa
            todoItems.Remove(todoItems[todoIndex]);

            //retorna Sucesso com a lista de tarefa
            return Ok(todoItems);
        }

        [HttpGet("{id")]
        public IActionResult GetById(Guid id)
        {
            //Busca o indice da lista referente a tarefa
            int todoIndex = todoItems.FindIndex(t => t.Id == id);

            //Verifica se a tarefa foi encontrada
            if(todoIndex == -1)
                return BadRequest(new { message = "Id não encontrado" });

            //retorna sucesso com a tarefa buscada
            return Ok(todoItems[todoIndex]);
        }

    }

}
