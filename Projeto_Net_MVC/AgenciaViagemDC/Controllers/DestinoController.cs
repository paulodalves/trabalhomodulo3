using AgenciaViagemDC.Models;
using Microsoft.AspNetCore.Mvc;

namespace AgenciaViagemDC.Controllers
{
    public class DestinoController : Controller
    {
        
        private ContextoGeral _context;

        public DestinoController(ContextoGeral context)
        {
            _context = context;
        }

        // GET - Chama a View Index e trás todos os destinos
        public IActionResult Index()
        {
            var destino = _context.Destino.ToList();

            return View(destino);
        }

        // GET - Chama a View Cadastrar
        public IActionResult Create()
        {
            return View();
        }

        // POST - Periste o destino no banco de dados
        [HttpPost]
        public IActionResult Create(Destino destino)
        {
            _context.Destino.Add(destino); // Adicona ao contexto
            _context.SaveChanges(); // Salva no banco

            return RedirectToAction("Index"); // Retorna pra página Index
        }

        // GET - Chama a View Atualizar
        public IActionResult Edit(int id)
        {

            // // busca no contexto qual registro tem o mesmo id do parametro e retorna e armazena no objeto
            var destino = _context.Destino.SingleOrDefault(d => d.Id == id);

            if (destino == null)
            {
                return NotFound();
            }

            return View(destino);
        }

        [HttpPost]
        public IActionResult Edit(int id, Destino destino)
        {
            if (id != destino.Id) // Verifica se o id do objeto é o certo
            {
                return NotFound();
            }

            if (ModelState.IsValid) // Verifica se é válido e persiste
            {
                _context.Destino.Update(destino);
                _context.SaveChanges();

                return RedirectToAction("Index");
            }

            return View(destino);
        }

        // GET -  Retorna a View Excluir
        public IActionResult Delete(int id)
        {
            var destino = _context.Destino.SingleOrDefault(d => d.Id == id);

            if (destino == null)
            {
                return NotFound();
            }

            return View(destino);

        }

        // Marcação obrigatoria, para que ele saiba que esse metodo referencia a View Delete 
        [HttpPost, ActionName("Delete")]
        public IActionResult DeleteConfirma(int id)
        {
            var destino = _context.Destino.SingleOrDefault(d => d.Id == id);

            if (destino == null)
            {
                return NotFound();
            }

            _context.Destino.Remove(destino);
            _context.SaveChanges();

            return RedirectToAction("Index");
        }

        // GET - Chama a View Consultar e retorna o destino
        public IActionResult Details(int id)
        {
            var destino = _context.Destino.SingleOrDefault(d => d.Id == id);

            if (destino == null)
            {
                return NotFound();
            }

            return View(destino);
        }
    }
}
