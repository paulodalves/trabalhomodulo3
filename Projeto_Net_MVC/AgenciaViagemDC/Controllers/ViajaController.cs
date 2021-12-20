using AgenciaViagemDC.Models;
using Microsoft.AspNetCore.Mvc;

namespace AgenciaViagemDC.Controllers
{
    public class ViajaController : Controller
    {
        private ContextoGeral _context;

        public ViajaController(ContextoGeral context)
        {
            _context = context;
        }

        // GET - Chama a View Index e trás todos as viajens
        public IActionResult Index()
        {
            var viaja = _context.Viaja.ToList();

            return View(viaja);
        }

        // GET - Chama a View Cadastrar
        public IActionResult Create()
        {
            return View();
        }

        // POST - Periste a viajem no banco de dados
        [HttpPost]
        public IActionResult Create(Viaja viaja)
        {
            // Calcula o desconto
            viaja.ValorTotal = viaja.calcula(viaja.PrecoPassagem,viaja.QtdPassagem);

            _context.Viaja.Add(viaja); // Adicona ao contexto
            _context.SaveChanges(); // Salva no banco

            return RedirectToAction("Index"); // Retorna pra página Index
        }

        // GET - Chama a View Atualizar
        public IActionResult Edit(int id)
        {

            // // busca no contexto qual registro tem o mesmo id do parametro e retorna e armazena no objeto
            var viaja = _context.Viaja.SingleOrDefault(v => v.Id == id);

            if (viaja == null)
            {
                return NotFound();
            }

            return View(viaja);
        }

        [HttpPost]
        public IActionResult Edit(int id, Viaja viaja)
        {
            if (id != viaja.Id) // Verifica se o id do objeto é o certo
            {
                return NotFound();
            }

            if (ModelState.IsValid) // Verifica se é válido e persiste
            {
                _context.Viaja.Update(viaja);
                _context.SaveChanges();

                return RedirectToAction("Index");
            }

            return View(viaja);
        }

        // GET -  Retorna a View Excluir
        public IActionResult Delete(int id)
        {
            var viaja = _context.Viaja.SingleOrDefault(v => v.Id == id);

            if (viaja == null)
            {
                return NotFound();
            }

            return View(viaja);

        }

        // Marcação obrigatoria, para que ele saiba que esse metodo referencia a View Delete 
        [HttpPost, ActionName("Delete")]
        public IActionResult DeleteConfirma(int id)
        {
            var viaja = _context.Viaja.SingleOrDefault(v => v.Id == id);

            if (viaja == null)
            {
                return NotFound();
            }

            _context.Viaja.Remove(viaja);
            _context.SaveChanges();

            return RedirectToAction("Index");
        }

        // GET - Chama a View Consultar e retorna o destino
        public IActionResult Details(int id)
        {
            var viaja = _context.Viaja.SingleOrDefault(v => v.Id == id);

            if (viaja == null)
            {
                return NotFound();
            }

            return View(viaja);
        }
    }
}
