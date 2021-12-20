using AgenciaViagemDC.Models;
using Microsoft.AspNetCore.Mvc;

namespace AgenciaViagemDC.Controllers
{
    public class ClienteController : Controller
    {
        private ContextoGeral _context;

        public ClienteController(ContextoGeral context)
        {
            _context = context;
        }

        // GET - Chama a View Index e trás todos as pessoas cadastradas
        public IActionResult Index()
        {
            var cliente = _context.Cliente.ToList();

            return View(cliente);
        }

        // GET - Chama a View Cadastrar
        public IActionResult Create()
        {
            return View();
        }

        // POST - Periste o cliente no banco de dados
        [HttpPost]
        public IActionResult Create(Cliente cliente)
        {
            _context.Cliente.Add(cliente); // Adicona ao contexto
            _context.SaveChanges(); // Salva no banco

            return RedirectToAction("Index"); // Retorna pra página Index
        }

        // GET - Chama a View Atualizar
        public IActionResult Edit(int id)
        {

            // // busca no contexto qual registro tem o mesmo id do parametro e retorna e armazena no objeto
            var cliente = _context.Cliente.SingleOrDefault(c => c.Id == id);

            if (cliente == null)
            {
                return NotFound();
            }

            return View(cliente);
        }

        [HttpPost]
        public IActionResult Edit(int id, Cliente cliente)
        {
            if (id != cliente.Id) // Verifica se o id do objeto é o certo
            {
                return NotFound();
            }

            if (ModelState.IsValid) // Verifica se é válido e persiste
            {
                _context.Cliente.Update(cliente);
                _context.SaveChanges();

                return RedirectToAction("Index");
            }

            return View(cliente);
        }

        // GET -  Retorna a View Excluir
        public IActionResult Delete(int id)
        {
            var cliente = _context.Cliente.SingleOrDefault(c => c.Id == id);

            if (cliente == null)
            {
                return NotFound();
            }

            return View(cliente);

        }

        // Marcação obrigatoria, para que ele saiba que esse metodo referencia a View Delete 
        [HttpPost,ActionName("Delete")]
        public IActionResult DeleteConfirma(int id)
        {
            var cliente = _context.Cliente.SingleOrDefault(c => c.Id == id);

            if (cliente == null)
            {
                return NotFound();
            }

            _context.Cliente.Remove(cliente);
            _context.SaveChanges();

            return RedirectToAction("Index");
        }

        // GET - Chama a View Consultar e retorna o cliente
        public IActionResult Details(int id)
        {
            var cliente = _context.Cliente.SingleOrDefault(c => c.Id == id);

            if (cliente == null)
            {
                return NotFound();
            }

            return View(cliente);
        }

    }
}
